using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TextLand.DAL.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public string Address { get; set; }
        public ICollection<Order> AddedOrders { get; set; }
        public ICollection<Order> ExecutedOrders { get; set; }
        public double AccountForAddingOrders { get; set; }
        public double AccountForCompletedOrders { get; set; }
        public double Rating { get; set; }
        public bool IsAdmin { get; set; }
    }
}
