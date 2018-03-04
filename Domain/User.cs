using System;

namespace SnippetsAPI.Domain
{
    // Snippet class
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
    }
}