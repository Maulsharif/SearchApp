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
        public void CheckConstructor()
        {
            ISearchService service = A.Fake<ISearchService>();
            using var controller = new SearchController(service);
            Assert.Throws<ArgumentNullException>(() => new SearchController(null));
            Assert.NotNull(controller);
        }

        [Fact]
        public void CheckBadRequestCode()
        {
            ISearchService service = A.Fake<ISearchService>();
            using var controller = new SearchController(service);
            var res1 = controller.Get(null);
            Assert.IsType<BadRequestResult>(res1.Result);
        }

        [Fact]
        public void CheckNoContentCode()
        {
            ISearchService service = A.Fake<ISearchService>();
            using var controller = new SearchController(service);
            A.CallTo(() => service.GetSearchResult("bo")).Returns(Array.Empty<SearchResult>());
            var res = controller.Get("bo");
            Assert.IsType<NoContentResult>(res.Result);
        }

        [Fact]
        public void CheckOkStatusCode()
        {
            ISearchService service = A.Fake<ISearchService>();
            using var controller = new SearchController(service);
            SearchResult[] data = new SearchResult[]
               {
                  new SearchResult { Id = 1, Text = "help me" },
               };

            A.CallTo(() => service.GetSearchResult("me")).Returns(data);
            var res4 = controller.Get("me");
            Assert.IsType<OkObjectResult>(res4.Result);
        }
    }
}
