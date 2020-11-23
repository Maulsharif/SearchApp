using System;
using Microsoft.AspNetCore.Mvc;
using SearchService;

namespace SearchApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        private readonly ISearchService _service;

        public SearchController(ISearchService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet("{word}")]
        public IActionResult Get(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                return BadRequest();
            }

            var res = _service.GetSearchResult(word);

            return res.Count > 0 ? Ok(res) : (IActionResult)NoContent();
        }
    }
}