using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SearchService.Models;

namespace SearchService
{
    public interface ISearchService
    {
        IReadOnlyCollection<SearchResult> GetSearchResult(string word);

        Task<IReadOnlyCollection<SearchResult>> GetSearchResultAsync(string word, CancellationToken cancellationToken);
    }
}