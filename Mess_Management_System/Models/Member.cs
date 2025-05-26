using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mess_Management_System.Models
{
    public class Member
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        public DateTime JoinDate { get; set; }

        public bool IsActive { get; set; } = true;

        // Navigation properties
        public virtual ICollection<Meal> Meals { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}