using System.Collections.Generic;
using Inveon.DataAccess.Concrete.EntityFramework;

namespace Inveon.DataAccess.Interfaces
{
    public interface IMediaRepository : IRepository<Media>
    {
        /// <summary>
        /// Get product images by product Id
        /// </summary>
        /// <param name="productId"></param>
        List<Media> GetProductImages(int productId);
    }
}
