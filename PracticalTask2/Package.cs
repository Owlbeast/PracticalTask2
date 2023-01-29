using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticalTask2
{
    public class Package
    {
        [Key]
        public int Id { get; set; }

        public string PackageIdentifier { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [RegularExpression("DELIVERED|RECEIVED", ErrorMessage = "Invalid Status")]
        public string Status { get; set; }

        public int RecipientId { get; set; }

        public DateTime LastUpdated { get; set; }
        
        [ForeignKey("RecipientId")]
        public Recipient Recipient { get; set; }

    }
}