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
        private readonly SearchController _controller;
        private readonly ISearchService _service;

        public SearchControllerTest()
        {
            _service = A.Fake<ISearchService>();
            _controller = new SearchController(_service);
        }

        [Fact]
        public void CheckConstructor()
        {
            Assert.Throws<ArgumentNullException>(() => new SearchController(null));
            Assert.NotNull(_controller);
        }

        [Fact]
        public void CheckBadRequestCode()
        {
            var res1 = _controller.Get(null);
            Assert.IsType<BadRequestResult>(res1.Result);
        }

        [Fact]
        public void CheckNoContentCode()
        {
            A.CallTo(() => _service.GetSearchResult("bo")).Returns(Array.Empty<SearchResult>());
            var res = _controller.Get("bo");
            Assert.IsType<NoContentResult>(res.Result);
        }

        [Fact]
        public void CheckOkStatusCode()
        {
               SearchResult[] data = new SearchResult[]
               {
                  new SearchResult { Id = 1, Text = "help me" },
               };

               A.CallTo(() => _service.GetSearchResult("me")).Returns(data);

               var res4 = _controller.Get("me");
               Assert.IsType<OkObjectResult>(res4.Result);
               //Assert.NotEmpty(res4.Value);
        }
    }
}
