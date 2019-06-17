using System.Collections.Generic;
using TextLand.BL.Models;

namespace TextLand.BL.Services.Interfaces
{
    public interface IAdminsService
    {
        List<PayoffDto> GetUndonePayoffs(int adminId);
        List<PayoffDto> RealizePayoffs(int adminId, int[] payoffsIds);
    }
}
