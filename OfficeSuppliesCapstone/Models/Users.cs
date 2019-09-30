using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OfficeSuppliesCapstone
{
    public partial class Users
    {

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Username { get; set; }
        [Required]
        [StringLength(80)]
        public string Password { get; set; }
        [Required]
        [StringLength(80)]
        public string Firstname { get; set; }
        [Required]
        [StringLength(80)]
        public string Lastname { get; set; }
        [StringLength(12)]
        public string Phone { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        [Required]
        public bool IsReviewer { get; set; } = true;
        [Required]
        public bool IsAdmin { get; set; } = true;

        public Users() {
        }

    }
}
