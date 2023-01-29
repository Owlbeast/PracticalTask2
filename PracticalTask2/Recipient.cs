using System.ComponentModel.DataAnnotations;

namespace PracticalTask2
{
    public class Recipient
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public List<Package> Packages { get; set; }
    }
}
