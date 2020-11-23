using System.Collections.Generic;
using System.Linq;
using ISearchService.Model;


namespace MockSearchService
{
    public class MoqSearchService : ISearchService.ISearchService
    {
        public IReadOnlyCollection<SearchResult> GetSearchResult(string word)
        {
            var res = InitializeList();
            return (IReadOnlyCollection<SearchResult>)res.Where(predicate: w =>
            {
                return w.Text.ToUpper().Contains(word.ToUpper());
            });
        }

        private List<SearchResult> InitializeList()
        {
            var res = new List<SearchResult>()
                     {
                      new SearchResult() { Id = 1, Text = "cat" },
                      new SearchResult() { Id = 2, Text = "dog" },
                      new SearchResult() { Id = 3, Text = "koala" },
                      new SearchResult() { Id = 4, Text = "rat" },
                     };

            return res;
        }
    }
}