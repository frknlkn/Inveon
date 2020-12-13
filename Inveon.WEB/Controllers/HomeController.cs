using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Inveon.Business.Interfaces;
using Inveon.DataAccess.Concrete.EntityFramework;
using Inveon.WEB.Models;

namespace Inveon.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService mProductService;
        private readonly IMapper mMapper;

        public HomeController(IProductService productService, IMapper mapper)
        {
            mMapper = mapper;
            mProductService = productService;
        }
        public ActionResult Index()
        {
            List<Product> products = mProductService.GetAllProducts();
            List<ProductViewModel> models = new List<ProductViewModel>();
            foreach (var product in products)
            {
                ProductViewModel data = mMapper.Map<ProductViewModel>(product);
                models.Add(data);
            }
            return View(models);
        }

        public ActionResult Detail(int productId)
        {
            Product product = mProductService.GetProduct(productId);
            ProductViewModel model = mMapper.Map<ProductViewModel>(product);
            model.MediaList = new List<MediaViewModel>();
            foreach (var media in product.Media)
            {
                MediaViewModel mediaModel = mMapper.Map<MediaViewModel>(media);
                model.MediaList.Add(mediaModel);
            }
            return View(model);
        }

    }
}