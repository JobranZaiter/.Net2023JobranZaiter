using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using Nest;
using Project.Models;

namespace Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MyElasticsearchController : ControllerBase
    {
        private readonly IElasticClient _elasticClient;

        public MyElasticsearchController(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }

        [HttpGet]
        public IActionResult Search(string query)
        {
            var searchResponse = _elasticClient.Search<Product>(s => s
                .Query(q => q
                    .Match(m => m
                        .Field(f => f.Slug)
                        .Query(query)
                )
            )
                );
            var searchResults = searchResponse.Documents;
            return Ok(searchResults);
        }
    }
}
