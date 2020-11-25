using System;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using SearchApp.Controllers;
using SearchService;
using SearchService.Model;
using Xunit;

namespace SearchAppTest
{
    public class SearchControllerTest
    {
        [Fact]
        public void ConsturctorTest()
        {
            var fakeService = A.Fake<ISearchService>();
            var controller = new SearchController(fakeService);
            Assert.Throws<ArgumentNullException>(() => new SearchController(null));
            Assert.NotNull(controller);
        }

        [Fact]
        public void GetMethodTest()
        {
            var fakeService = A.Fake<ISearchService>();
            SearchController controller = new SearchController(fakeService);
            var res1 = controller.Get(null);
            var res2 = controller.Get(string.Empty);

            Assert.IsType<BadRequestResult>(res1);
            Assert.IsType<BadRequestResult>(res2);
        }

        [Fact]
        public void GetMethodPosiriveStatus()
        {
            var fakeService = A.Fake<ISearchService>();
            var res3 = A.CallTo(() => fakeService.GetSearchResult("bo")).Returns(Array.Empty<SearchResult>());
            Assert.IsType<NoContentResult>(res3);
        }
    }
}
