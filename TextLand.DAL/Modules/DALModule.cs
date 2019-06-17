using Ninject.Modules;
using TextLand.DAL.Repositories;
using TextLand.DAL.Repositories.Interfaces;

namespace TextLand.DAL.Modules
{
    public class DalModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IOrdersRepository>().To<OrdersRepository>();
            Bind<IUsersRepository>().To<UsersRepository>();
            Bind<IAdminsRepository>().To<AdminsRepository>();
        }
    }
}
