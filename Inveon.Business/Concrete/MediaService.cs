using System.IO;
using System.Linq;
using System.Web;
using AutoMapper;
using Inveon.Business.Interfaces;
using Inveon.DataAccess.Concrete.EntityFramework;
using Inveon.DataAccess.Interfaces;

namespace Inveon.Business.Concrete
{
    public class MediaService : EntityService<Media>, IMediaService
    {
        IUnitOfWork _unitOfWork;
        IMediaRepository _mediaRepository;
        IProductRepository _productRepository;

        public MediaService(IUnitOfWork unitOfWork, IMediaRepository mediaRepository, IProductRepository productRepository)
            : base(unitOfWork, mediaRepository)
        {
            _unitOfWork = unitOfWork;
            _mediaRepository = mediaRepository;
            _productRepository = productRepository;
        }

        public void AddMedia(string barcode, HttpPostedFileBase fileBase, string mapPath,int nodeOrder)
        {

            SaveFilePath(fileBase, mapPath);
            var media = new Media()
            {
                Name =fileBase.FileName,
                ProductId = _productRepository.FindBy(x => x.Barcode == barcode).Select(x => x.Id).FirstOrDefault(),
                NodeOrder = nodeOrder,
                Path = Path.GetFileName(fileBase.FileName)
            };
            Add(media);
        }

        private void SaveFilePath(HttpPostedFileBase fileBase, string mapPath)
        {
            var inputFileName = Path.GetFileName(fileBase.FileName);
            var serverSavePath = Path.Combine(mapPath + inputFileName);
            fileBase.SaveAs(serverSavePath);
        }
    }

}
