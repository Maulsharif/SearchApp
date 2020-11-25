using System;
using System.Collections.Generic;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SearchService;
using SearchService.Model;

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
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<SearchResult>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<SearchResult>> Get(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                return BadRequest();
            }

            var res = _service.GetSearchResult(word);

            if (res.Count > 0)
            {
                return Ok(res);
            }

            return NoContent();
        }
    }
}