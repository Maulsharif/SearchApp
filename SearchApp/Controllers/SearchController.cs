using System;
using Microsoft.AspNetCore.Mvc;

namespace SearchApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class SearchController : Controller
    {
        private readonly ISearchService.ISearchService _service;

        public SearchController(ISearchService.ISearchService service)
        {
            if (service == null)
            {
                throw new ArgumentNullException(nameof(service));
            }

            _service = service;
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