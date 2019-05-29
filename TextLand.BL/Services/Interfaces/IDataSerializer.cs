using TextLand.DAL.Models;

namespace TextLand.BL.Services.Interfaces
{
    public interface IDataSerializer
    {
        bool Export(string fileName, Order order);
    }
}
