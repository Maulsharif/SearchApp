namespace ISearchService.Model
{
    public class SearchResult
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public SearchResult(int id, string text)
        {
            Id = id;
            Text = text;
        }

        public SearchResult(string text)
        {
            Text = text;
        }

       
        
    }
}