using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextLand.DAL.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public ICollection<Order> AddedOrders { get; set; }
        public ICollection<Order> ExecutedOrders { get; set; }
        public decimal AccountForAddingOrders { get; set; }
        public decimal AccountForCompletedOrders { get; set; }
        public decimal Rating { get; set; }
        public bool IsAdmin { get; set; }
    }
}
