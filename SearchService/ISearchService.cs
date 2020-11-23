using System.Collections.Generic;
using SearchService.Model;

namespace SearchService
{
    public interface ISearchService
    {
        IReadOnlyCollection<SearchResult> GetSearchResult(string word);
    }
}