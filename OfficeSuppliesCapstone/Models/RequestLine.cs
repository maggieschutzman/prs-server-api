using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OfficeSuppliesCapstone
{
    public partial class RequestLine
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Id")]
        [InverseProperty("RequestLine")]
        public int RequestId { get; set; }
        [ForeignKey("ProductId")]
        [InverseProperty("RequestLine")]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual Request Request { get; set; }
    }
}
