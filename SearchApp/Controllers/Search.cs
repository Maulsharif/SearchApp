using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SearchService;
using SearchService = SearchService.SearchService;

namespace SearchApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 

    public class Search : Controller
    {
        private readonly ISearchService _service;

        public Search(ISearchService service)
        {
            _service = service;
        }

        [HttpGet("{word}")]
        public IActionResult Get(string word)
        {
            
            
            List<string> res = _service.GetSearchResult(word);
            if (word=="")
                return NotFound();

            if (res.Any())
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