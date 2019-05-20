using System.Collections.Generic;

namespace TextLand.BL.Models
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public ICollection<OrderDto> AddedOrders { get; set; }
        public ICollection<OrderDto> ExecutedOrders { get; set; }
        public decimal AccountForAddingOrders { get; set; }
        public decimal AccountForCompletedOrders { get; set; }
        public decimal Rating { get; set; }
        public bool IsAdmin { get; set; }
    }
}
