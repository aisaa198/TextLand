namespace TextLand.BL.Models
{
    public class PayoffDto
    {
        public int PayoffId { get; set; }
        public UserDto RequestingUser { get; set; }
        public double Value { get; set; }
        public bool IsDone { get; set; }
    }
}
