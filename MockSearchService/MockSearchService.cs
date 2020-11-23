using System;
using System.Collections.Generic;
using System.Linq;
using ISearchService.Model;


namespace MockSearchService
{
    public class MoqSearchService:ISearchService.ISearchService
    {
        public IReadOnlyCollection<SearchResult> GetSearchResult(string word)
        {
           var res= InitializeList();
            return (IReadOnlyCollection<SearchResult>) res.Where(w=>w.Text.ToUpper().Contains(word));
        }

        private List<SearchResult> InitializeList()
        {
          var res= new List<SearchResult>()
                     {
                         new SearchResult(1,"cat"),
                         new SearchResult(1,"dog"),
                         new SearchResult(1,"lion"),
                         new SearchResult(1,"tiger"),
                         
                     };
          return res;
        }
    }
}