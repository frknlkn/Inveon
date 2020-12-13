using System.Linq;
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

        public void AddMedia(string barcode, Media media)
        {
            media.ProductId = _productRepository.FindBy(x => x.Barcode == barcode).Select(x => x.Id).FirstOrDefault();
            Add(media);
        }
    }

}
