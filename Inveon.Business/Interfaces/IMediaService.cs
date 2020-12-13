using System.Collections.Generic;
using Inveon.DataAccess.Concrete.EntityFramework;

namespace Inveon.Business.Interfaces
{
    public interface IMediaService : IEntityService<Media>
    {
        void AddMedia(string barcode, Media media);
    }
}
