using System.Collections.Generic;
using System.Linq;
using GenerateTextService;
namespace SearchService
{
    public class SearchService:ISearchService
    {
        public List<string> GetSearchResult(string word)
        {
            TextGenerator textGenerator=new TextGenerator();
            return textGenerator.Texts.Where(p=>p.ToUpper().Contains(word.ToUpper())).ToList();
        }
    }
}