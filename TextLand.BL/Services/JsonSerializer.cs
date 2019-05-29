using Newtonsoft.Json;
using System.IO;
using TextLand.BL.Services.Interfaces;
using TextLand.DAL.Models;

namespace TextLand.BL.Services
{
    class JsonSerializer : IDataSerializer
    {
        public bool Export(string fileName, Order order)
        {
            var fileContent = JsonConvert.SerializeObject(order, Formatting.Indented);
            File.WriteAllText(fileName, fileContent);
            return true;
        }
    }
}
