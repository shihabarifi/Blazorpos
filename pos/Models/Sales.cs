using pos.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Models
{
    public class Sales
    {
        [Key]
        public int Id { get; set; }


        [Required]
        
        public int InvoiceId { get; set; }

        public virtual Invoice Invoice { get; private set; }



        [Required]
      
        public string ProductCode { get; set; }

        public virtual Product Product { get; private set; }


       
        [Required]
        [Range(1, 1000, ErrorMessage = "Quantity should be geater than 0 and less then 1000")]
        public decimal Quantity { get; set; }


        [Range(1, 1000000, ErrorMessage = "Price should be geater than 0")]
        [DisplayFormat(DataFormatString = "{0:0.00}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "smallmoney")]
        [Required]
        public decimal Price { get; set; }

        [Required]
        
        public decimal SubTotal { get; set; }

        [NotMapped]
        [MaxLength(100)]
        public string Description { get; set; } = "";

        [NotMapped]
        [MaxLength(100)]
        public string UnitName { get; set; } = "";

        [NotMapped]
        public string Image { get; set; } = "";

        [NotMapped]
        public bool IsDeleted { get; set; } = false;




    }
}
