using System;
using System.Collections.Generic;
using ISearchService.Model;

namespace ISearchService
{
    public interface ISearchService
    {
        IReadOnlyCollection<SearchResult> GetSearchResult(string word);
    }
}