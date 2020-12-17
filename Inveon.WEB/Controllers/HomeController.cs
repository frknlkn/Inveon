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
        private readonly IMediaService mMediaService;
        private readonly IMapper mMapper;

        public HomeController(IProductService productService, IMapper mapper, IMediaService mediaService)
        {
            mMapper = mapper;
            mProductService = productService;
            mMediaService = mediaService;
        }
        public ActionResult Index()
        {
            List<Product> products = mProductService.GetAllProducts();
            List<ProductViewModel> models = new List<ProductViewModel>();
            foreach (var product in products)
            {
                ProductViewModel data = mMapper.Map<ProductViewModel>(product);
                var productMediaList = mMediaService.FindBy(x => x.ProductId == data.Id);
                data.MediaList = new List<MediaViewModel>();
                foreach (var media in productMediaList)
                {
                    MediaViewModel mediaModel = mMapper.Map<MediaViewModel>(media);
                    data.MediaList.Add(mediaModel);
                }
                models.Add(data);
            }
            return View(models);
        }
        [HttpGet, Route("urun/{id:int}")]

        public ActionResult Detail(int id)
        {
            Product product = mProductService.GetProduct(id);
            var productMediaList = mMediaService.FindBy(x => x.ProductId == id);
            ProductViewModel model = mMapper.Map<ProductViewModel>(product);
            model.MediaList = new List<MediaViewModel>();
            foreach (var media in productMediaList)
            {
                MediaViewModel mediaModel = mMapper.Map<MediaViewModel>(media);
                model.MediaList.Add(mediaModel);
            }
            return View(model);
        }

    }
}