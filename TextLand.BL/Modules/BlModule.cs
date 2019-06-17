using AutoMapper;
using Ninject.Modules;
using TextLand.BL.Services;
using TextLand.BL.Services.Interfaces;
using TextLand.DAL.Modules;

namespace TextLand.BL.Modules
{
    public class BlModule : NinjectModule
    {
        public override void Load()
        {
            var kernel = Kernel;
            kernel?.Load(new[] { new DalModule() });
            Bind<IMapper>().ToProvider<MapperProvider>();
            Bind<IUsersService>().To<UsersService>();
            Bind<IOrdersService>().To<OrdersService>();
            Bind<IAdminsService>().To<AdminsService>();
        }
    }
}
