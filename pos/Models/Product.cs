using Microsoft.AspNetCore.Mvc;
using pos.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pos.Models
{
    public class Product
    {
        [Key]
        [StringLength(50)]
        public string Code { get; set; }

       
        [StringLength(75)]
        public String Name { get; set; }

        [Required]
        [StringLength(255)]
        public String Description { get; set; }

        [Required]         
        [Column(TypeName ="smallmoney")]
        public decimal Cost { get; set; }

        [Required]
        [Column(TypeName = "smallmoney")]
        public decimal Price { get; set; }

        
  
        public int Quantity { get; set; }


        public int? UnitId { get; set; }
        public virtual Unit Units { get; set; }


        
     


        public int? CategoryId { get; set; }
        public virtual Category Categories { get; set; }



 

        public string PhotoUrl { get; set; } = "noimage.png";

        [Display(Name = "Product Photo")]
        [NotMapped]
        public IFormFile ProductPhoto { get; set; }

        [NotMapped]
        public string BreifPhotoName { get; set; }

    }
}
