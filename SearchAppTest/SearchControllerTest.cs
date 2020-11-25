using System;
using System.Threading;
using System.Threading.Tasks;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using SearchApp.Controllers;
using SearchService;
using SearchService.Models;
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
        public void Get_BadRequestCode()
        {
            ISearchService service = A.Fake<ISearchService>();
            using var controller = new SearchController(service);
            var res1 = controller.Get(null);
            Assert.IsType<BadRequestResult>(res1.Result);
        }

        [Fact]
        public void Get_NoContentCode()
        {
            ISearchService service = A.Fake<ISearchService>();
            using var controller = new SearchController(service);
            A.CallTo(() => service.GetSearchResult("bo")).Returns(Array.Empty<SearchResult>());
            var res = controller.Get("bo");
            Assert.IsType<NoContentResult>(res.Result);
        }

        [Fact]
        public void Get_OkStatusCode()
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
        public async Task Get2_BadRequestCodeAsync()
        {
            ISearchService service = A.Fake<ISearchService>();
            using var controller = new SearchController(service);

            var res1 = await controller.Get2(null, CancellationToken.None);
            Assert.IsType<BadRequestResult>(res1.Result);
        }

        [Fact]
        public async Task Get2_NoContentCodeAsync()
        {
            ISearchService service = A.Fake<ISearchService>();
            using var controller = new SearchController(service);
            A.CallTo(() => service.GetSearchResultAsync("bo", CancellationToken.None)).ReturnsLazily(() => Array.Empty<SearchResult>());
            var res = await controller.Get2("bo", CancellationToken.None);
            Assert.IsType<NoContentResult>(res.Result);
        }

        [Fact]
        public async Task Get2_OkStatusCodeAsync()
        {
            ISearchService service = A.Fake<ISearchService>();
            using var controller = new SearchController(service);
            SearchResult[] data1 = new SearchResult[]
               {
                  new SearchResult { Id = 1, Text = "black and white" },
               };

            A.CallTo(() => service.GetSearchResultAsync("and", CancellationToken.None)).ReturnsLazily(() => data1);
            var res4 = await controller.Get2("and", CancellationToken.None);
            Assert.IsType<OkObjectResult>(res4.Result);
        }
    }
}
