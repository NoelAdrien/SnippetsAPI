
namespace SnippetsAPI.Controllers
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using SnippetsAPI.Configuration;
    using Microsoft.Extensions.Options;
    using SnippetsAPI.Domain;
    using SnippetsAPI.Service;

    [Route("api/[controller]")]
    public class SnippetController : Controller
    {
        private readonly ConnectionStrings _connString;
        private SnippetService _snippetService;

        public SnippetController(IOptions<ConnectionStrings> connStrings)
        {
            this._connString = connStrings.Value;
            this._snippetService = new SnippetService(_connString.SnippetConnection);
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Snippet> Get()
        {
            return this._snippetService.GetSnippets();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
