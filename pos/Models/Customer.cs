using System.ComponentModel.DataAnnotations;

namespace POS.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Name { get; set; }

        [Required]
       
        public int? Contact { get; set; }

        public string Address { get; set; }
    }
}
