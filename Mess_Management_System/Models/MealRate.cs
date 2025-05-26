using System;
using System.ComponentModel.DataAnnotations;

namespace Mess_Management_System.Models
{
    public class MealRate
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public int Month { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Rate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }
    }
}