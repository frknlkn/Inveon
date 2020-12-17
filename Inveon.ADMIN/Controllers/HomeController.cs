using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Inveon.ADMIN.Helpers;
using Inveon.ADMIN.Models;
using Inveon.Business.Interfaces;
using Inveon.DataAccess.Concrete.EntityFramework;

namespace Inveon.ADMIN.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private readonly IProductService mProductService;
        private readonly IMediaService mMediaService;
        private readonly IMapper mMapper;

        public HomeController(IProductService productService, IMediaService mediaService, IMapper mapper)
        {
            mMapper = mapper;
            mProductService = productService;
            mMediaService = mediaService;
        }
        [HttpGet]
        public ActionResult Index()
        {
            List<Product> products = mProductService.GetAllProducts();
            List<ProductViewModel> models = new List<ProductViewModel>();
            foreach (var product in products)
            {
                ProductViewModel data = mMapper.Map<ProductViewModel>(product);
                data.MediaList = new List<MediaViewModel>();
                foreach (var media in product.Media)
                {
                    MediaViewModel mediaModel = mMapper.Map<MediaViewModel>(media);
                    data.MediaList.Add(mediaModel);
                }
                models.Add(data);
            }
            return View(models);
        }
        [HttpGet, Route("ekle")]
        public ActionResult Create()
        {
            return View(new ProductViewModel());
        }

        [HttpPost, Route("ekle")]
        public ActionResult Create(ProductViewModel model)
        {
            var product = mMapper.Map<Product>(model);
            product.Barcode = BarcodeHelper.RandomProductCode();
            mProductService.AddProduct(product);
            string mapPath = Server.MapPath(ReadSettingsHelper.ImagePath());
            int nodeOrder = 1;
            foreach (var item in model.MediaFiles)
            {
                //var media = mMapper.Map<Media>(item);
                mMediaService.AddMedia(product.Barcode, item, mapPath,nodeOrder);
                nodeOrder++;
            }

            return RedirectToAction("Index","Home") ;
        }



    }
}