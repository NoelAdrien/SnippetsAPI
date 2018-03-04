
namespace SnippetsAPI.Service
{
    using SnippetsAPI.Domain;
    using System.Collections.Generic;

    // Configuration Class
    public interface ISnippetService
    {
        IEnumerable<Snippet> GetSnippets();
    }
}