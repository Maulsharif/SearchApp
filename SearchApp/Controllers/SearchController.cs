using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SearchService;
using SearchService.Models;

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

        [HttpGet("2/{word}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<SearchResult>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<SearchResult>>> Get2(string word, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                return BadRequest();
            }

            var result = await _service.GetSearchResultAsync(word, cancellationToken);
            if (result.Count > 0)
            {
                return Ok(result);
            }

            return NoContent();
        }
    }
}