using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Inveon.DataAccess.Interfaces;

namespace Inveon.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EFMediaRepository: Repository<Media>, IMediaRepository
    {
        public EFMediaRepository(DbContext context) : base(context)
        {
        }

        public List<Media> GetProductImages(int productId)
        {
            return FindBy(x => x.ProductId == productId).ToList();
        }
    }
}
