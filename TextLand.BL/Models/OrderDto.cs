using System.Collections.Generic;
using TextLand.Common;

namespace TextLand.BL.Models
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public TextType TypeOfText { get; set; }
        public string Informations { get; set; }
        public List<string> KeyWords { get; set; }
        public int NumberOfCharacters { get; set; }
        public UserDto ExecutingUser { get; set; }
        public UserDto AddingUser { get; set; }
        public string Content { get; set; }
        public bool IsDone { get; set; }
        public bool IsPaid { get; set; }
        public double Value { get; set; }
    }
}
