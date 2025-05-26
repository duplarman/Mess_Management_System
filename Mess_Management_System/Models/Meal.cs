using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mess_Management_System.Models
{
    public class Meal
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int MemberId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [Range(0, 3)]
        public int Breakfast { get; set; }

        [Required]
        [Range(0, 3)]
        public int Lunch { get; set; }

        [Required]
        [Range(0, 3)]
        public int Dinner { get; set; }

        // Navigation properties
        [ForeignKey("MemberId")]
        public virtual Member Member { get; set; }
    }
}