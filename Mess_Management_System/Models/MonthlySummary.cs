using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mess_Management_System.Models
{
    public class MonthlySummary
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int MemberId { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public int Month { get; set; }

        [Required]
        public int TotalMeals { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal TotalPayment { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal TotalDue { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        [ForeignKey("MemberId")]
        public virtual Member Member { get; set; }
    }
}