using System.ComponentModel.DataAnnotations;

namespace TextLand.DAL.Models
{
    public class Payoff
    {
        [Key]
        public int PayoffId { get; set; }
        [Required]
        public User RequestingUser { get; set; }
        [Required]
        public double Value { get; set; }
        public bool IsDone { get; set; }
    }
}
