using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SearchService;
using SearchService.Models;

namespace SearchServiceMock
{
    public class SearchServiceMock : ISearchService
    {
        private readonly SearchResult[] _data;

        public SearchServiceMock()
        {
            _data = new[]
             {
                new SearchResult() { Id = 1, Text = "You need to ensure qualifications are recognised, robust and most importantly that learners are receiving practical English and maths solutions that enable progression and achievement in their lives, education and work" },
                new SearchResult() { Id = 2, Text = "Type errors will show up in the same console as the build one." },
                new SearchResult() { Id = 3, Text = "You will have to fix these type errors before you continue development or build your project." },
                new SearchResult() { Id = 4, Text = "You can optionally enable an extension for your IDE" },
            };
        }

        public SearchServiceMock(IEnumerable<SearchResult> data)
        {
            _data = data?.ToArray() ?? throw new ArgumentNullException(nameof(data));
        }

        public IReadOnlyCollection<SearchResult> GetSearchResult(string word)
        {
            if (word == null)
            {
                throw new ArgumentNullException(nameof(word));
            }

            if (word.Length == 0)
            {
                throw new ArgumentException("Should not be empty.", nameof(word));
            }

            return _data
                .Where(w => w.Text.Contains(word, StringComparison.OrdinalIgnoreCase))
                .ToArray();
        }

        public Task<IReadOnlyCollection<SearchResult>> GetSearchResultAsync(string word, CancellationToken cancellationToken)
        {
            var result = GetSearchResult(word);
            return Task.FromResult(result);
        }
    }
}