using System.Collections.Generic;

namespace SearchService
{
    public interface ISearchService
    {
        List<string> GetSearchResult(string word);
    }
}