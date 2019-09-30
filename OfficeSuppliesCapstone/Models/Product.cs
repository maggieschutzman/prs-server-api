using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OfficeSuppliesCapstone
{
    public partial class Product
    {

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string PartNbr { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        [StringLength(30)]
        public string Unit { get; set; }
        [StringLength(255)]
        public string PhotoPath { get; set; }
        [ForeignKey("VendorId")]
        [InverseProperty("Product")]
        public int VendorId { get; set; }

        public Product() {
        }

        public virtual Vendor Vendor { get; set; }
    }
}
