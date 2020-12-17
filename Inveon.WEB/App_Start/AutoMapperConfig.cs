using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Inveon.DataAccess.Concrete.EntityFramework;
using Inveon.WEB.Models;

namespace Inveon.WEB
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration Configure()
        {

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductViewModel>();
                cfg.CreateMap<Media, MediaViewModel>();

            });
            return configuration;
        }
    }
    }