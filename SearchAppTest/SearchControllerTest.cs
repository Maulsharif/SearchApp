using System;
using System.Threading;
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

        [Fact]
        public void CheckBadRequestCodeAsync()
        {
            ISearchService service = A.Fake<ISearchService>();
            using var controller = new SearchController(service);

            var res1 = controller.Get2(null, CancellationToken.None);
            Assert.IsType<BadRequestResult>(res1.Result.Result);
        }

        [Fact]
        public void CheckNoContentCodeAsync()
        {
            ISearchService service = A.Fake<ISearchService>();
            using var controller = new SearchController(service);
            A.CallTo(() => service.GetSearchResult("bo")).Returns(Array.Empty<SearchResult>());
            var res = controller.Get2("bo", CancellationToken.None);
            Assert.IsType<NoContentResult>(res.Result.Result);
        }

        [Fact]
        public void CheckOkStatusCodeAsync()
        {
            ISearchService service = A.Fake<ISearchService>();
            using var controller = new SearchController(service);
            SearchResult[] data1 = new SearchResult[]
               {
                  new SearchResult { Id = 1, Text = "black and white" },
               };

            A.CallTo(() => service.GetSearchResult("and")).Returns(data1);
            var res4 = controller.Get2("and", CancellationToken.None);
            Assert.IsType<OkObjectResult>(res4.Result.Result);
        }
    }
}
