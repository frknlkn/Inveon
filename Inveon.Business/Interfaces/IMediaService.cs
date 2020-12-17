using System.Web;
using Inveon.DataAccess.Concrete.EntityFramework;

namespace Inveon.Business.Interfaces
{
    public interface IMediaService : IEntityService<Media>
    {
        void AddMedia(string barcode, HttpPostedFileBase fileBase,string mapPath,int nodeOrder);
    }
}
