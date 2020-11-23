using System;
using System.Collections.Generic;
using System.Linq;
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
            _service = service;
        }

        [HttpGet("{word}")]
        public IActionResult Get(string word)
        {
            
            if (String.IsNullOrWhiteSpace(word))
                            return BadRequest();

            var res = _service.GetSearchResult(word);
            
            if (res.Count > 0)
            {
                return Ok(res);
            }
            else
            {
                return NoContent();
            }
           
        }

       
    }
}