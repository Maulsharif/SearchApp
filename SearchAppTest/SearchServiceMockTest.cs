using System;
using System.Collections.Generic;
using SearchService.Models;
using SearchServiceMock;
using Xunit;

namespace SearchAppTest
{
    public class SearchServiceMockTest
    {

        [Fact]
        public void CheckConstructor()
        {
            var service = new SearchServiceMock.SearchServiceMock();
            Assert.NotNull(service);
            Assert.Throws<ArgumentNullException>(() => new SearchServiceMock.SearchServiceMock(null));
        }

        [Fact]
        public void CheckOnExceptions()
        {
            var service = new SearchServiceMock.SearchServiceMock();
            Assert.Throws<ArgumentException>(() => service.GetSearchResult(string.Empty));
            Assert.Throws<ArgumentNullException>(() => service.GetSearchResult(null));
        }

        [Fact]
        public void CheckOnPositiveResults()
        {
            IEnumerable<SearchResult> data = FakeData();
            var service = new SearchServiceMock.SearchServiceMock(data);
            var result = service.GetSearchResult("bull");
            var result2 = service.GetSearchResult("boo");
            Assert.Empty(result);
            Assert.NotEmpty(result2);
        }

        public static SearchResult[] FakeData()
        {
            var data = new SearchResult[]
           {
               new SearchResult { Id = 1, Text = "boo boo" },
               new SearchResult { Id = 2, Text = "ha-ha-ha" },
               new SearchResult { Id = 3, Text = "aaa aaa" },
           };
            return data;
        }
    }
}