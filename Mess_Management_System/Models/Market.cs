using System;
using System.ComponentModel.DataAnnotations;

namespace Mess_Management_System.Models
{
    public class Market
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Amount { get; set; }

        [StringLength(100)]
        public string ReceiptNo { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}