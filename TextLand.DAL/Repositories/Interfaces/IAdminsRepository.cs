using System.Collections.Generic;
using TextLand.DAL.Models;

namespace TextLand.DAL.Repositories.Interfaces
{
    public interface IAdminsRepository
    {
        List<Payoff> GetUndonePayoffs();
        Payoff RealizePayoff(int id);
    }
}
