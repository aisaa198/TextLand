using AutoMapper;
using Ninject.Activation;
using System.Linq;
using TextLand.BL.Models;
using TextLand.DAL.Models;

namespace TextLand.BL.Modules
{
    internal class MapperProvider : Provider<IMapper>
    {
        protected override IMapper CreateInstance(IContext context)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {   
                cfg.CreateMap<User, UserDto>().MaxDepth(1);
                cfg.CreateMap<UserDto, User>().MaxDepth(1);
                cfg.CreateMap<Payoff, PayoffDto>().MaxDepth(1);
                cfg.CreateMap<PayoffDto, Payoff>().MaxDepth(1);
                cfg.CreateMap<OrderDto, Order>().ForMember(x => x.KeyWords, opt => opt.MapFrom(src => string.Join(",", src.KeyWords))).MaxDepth(1);
                cfg.CreateMap<Order, OrderDto>().ForMember(dest => dest.KeyWords, m => m.MapFrom(src => src.KeyWords.Split(',').ToList())).MaxDepth(1);
            });

            return new Mapper(mapperConfig);
        }
    }
}
