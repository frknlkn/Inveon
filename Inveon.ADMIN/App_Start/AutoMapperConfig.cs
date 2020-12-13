using AutoMapper;
using Inveon.ADMIN.Models;
using Inveon.DataAccess.Concrete.EntityFramework;

namespace Inveon.ADMIN
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration Configure()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductViewModel>();
                cfg.CreateMap<ProductViewModel, Product>();
                cfg.CreateMap<Media, MediaViewModel>();
                cfg.CreateMap<MediaViewModel, Media>();
            });
            return configuration;
        }
    }
}