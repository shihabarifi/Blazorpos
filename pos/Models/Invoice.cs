using System.ComponentModel.DataAnnotations;

namespace POS.Models
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public string InvoiceNo { get; set; }


        [Required]

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; private set; }


        [DataType(DataType.Date)]
        public DateTime InvoiceDate { get; set; } = DateTime.Now;


        public decimal TotalAmount { get; set; }


        public virtual List<Sales> Sales { get; set; } = new List<Sales>();
    }
}
