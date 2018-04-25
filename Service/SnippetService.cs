
namespace SnippetsAPI.Service
{
    using SnippetsAPI.Domain;
    using System.Collections.Generic;
    using SnippetsAPI.Configuration;
    using Microsoft.Extensions.Options;

    // Configuration Class
    public class SnippetService : ISnippetService
    {
        private ConnectionStrings _conn;

        public SnippetService(IOptions<ConnectionStrings> connString)
        {
            this._conn = connString.Value;
        }

        public IEnumerable<Snippet> GetSnippets()
        {
            using (SnippetDal dal = new SnippetDal(_conn.SnippetConnection))
            {
                return dal.GetSnippets();
            }
        }
    }
}