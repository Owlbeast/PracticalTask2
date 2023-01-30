using System.ComponentModel.DataAnnotations;

namespace PracticalTask2.Entities
{
    public class Recipient
    {
        [Required, Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public List<Package>? Packages { get; set; }
    }
}
