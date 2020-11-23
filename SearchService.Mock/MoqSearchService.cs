using System;
using System.Collections.Generic;
using System.Linq;
using SearchService;
using SearchService.Model;

namespace MockSearchService
{
    public class MoqSearchService : ISearchService
    {
         private readonly SearchResult[] _data;

         public MoqSearchService()
        {
            _data = new[]
            {
                new SearchResult() { Id = 1, Text = "cat" },
                new SearchResult() { Id = 2, Text = "dog" },
                new SearchResult() { Id = 3, Text = "koala" },
                new SearchResult() { Id = 4, Text = "rat" },
            };
        }

         public MoqSearchService(IEnumerable<SearchResult> data)
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
    }
}