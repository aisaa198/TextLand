using System.Collections.Generic;
using TextLand.Common;

namespace TextLand.DAL.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public TextType TypeOfText { get; set; }
        public string Informations { get; set; }
        public string KeyWords { get; set; }
        public int NumberOfCharacters { get; set; }
        public User ExecutingUser { get; set; }
        public User AddingUser { get; set; }
        public string Content { get; set; }
        public bool Status { get; set; }
    }
}
