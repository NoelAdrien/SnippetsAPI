
using System;

namespace SnippetsAPI.Domain
{
    // Snippet class
    public class Snippet
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Keywords { get; set; }
        public string Code { get; set; }
        public Langage Langage { get; set; }
        public bool isPublic { get; set; }
        public User User { get; set; }
    }
}
