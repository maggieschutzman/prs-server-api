using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OfficeSuppliesCapstone
{
    public partial class Request
    {

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(80)]
        public string Description { get; set; }
        [Required]
        [StringLength(80)]
        public string Justification { get; set; }
        [StringLength(80)]
        public string RejectionReason { get; set; }
        [StringLength(20)]
        public string DeliveryMode { get; set; } = "Pick Up";
        [Required]
        [StringLength(10)]
        public string Status { get; set; } = "NEW";
        [Required]
        public decimal Total { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("Request")]
        public int UserId { get; set; }

        public Request() {
            //RequestLine = new HashSet<RequestLine>();
        }

        public virtual Users User { get; set; }
        //public virtual ICollection<RequestLine> RequestLine { get; set; }
    }
}
