using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SearchService.Model;

namespace SearchService
{
    public interface ISearchService
    {
        IReadOnlyCollection<SearchResult> GetSearchResult(string word);

        Task<IReadOnlyCollection<SearchResult>> GetSearchResultAsync(string word, CancellationToken cancellationToken);
    }
}