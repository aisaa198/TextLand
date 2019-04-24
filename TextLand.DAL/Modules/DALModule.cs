using Ninject.Modules;
using TextLand.DAL.Repositories;

namespace TextLand.DAL.Modules
{
    public class DalModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IOrdersRepository>().To<OrdersRepository>();
            Bind<IUsersRepository>().To<UsersRepository>();
        }
    }
}
