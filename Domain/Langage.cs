
namespace SnippetsAPI.Domain
{
    using System;

    // Langage class
    public class Langage
    {
        public Langage()
        {

        }
        public Langage(Guid id, string code, string name)
        {
            this.Id = id;
            this.Code = code;
            this.Name = name;
        }
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}