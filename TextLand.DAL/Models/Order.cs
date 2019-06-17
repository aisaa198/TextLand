using System.ComponentModel.DataAnnotations;
using TextLand.Common;

namespace TextLand.DAL.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public TextType TypeOfText { get; set; }
        public string Informations { get; set; }
        [Required]
        public string KeyWords { get; set; }
        [Required]
        public int NumberOfCharacters { get; set; }
        public User ExecutingUser { get; set; }
        [Required]
        public User AddingUser { get; set; }
        public string Content { get; set; }
        public bool IsDone { get; set; }
        public bool IsPaid { get; set; }
        [Required]
        public double Value { get; set; }
    }
}
