
namespace SnippetsAPI.Service
{
    using SnippetsAPI.Domain;
    using System.Collections.Generic;

    // Configuration Class
    public class SnippetService : ISnippetService
    {
        private string _connString;

        public SnippetService(string conn)
        {
            this._connString = conn;
        }

        public IEnumerable<Snippet> GetSnippets()
        {
            return new Snippet[0];
        }
    }
}