using System;
using System.Collections.Generic;
using System.Web;

namespace Inveon.ADMIN.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Barcode { get; set; }
        public DateTime RecordDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool RecordIsDeleted { get; set; }
        public List<MediaViewModel> MediaList { get; set; }
        public List<HttpPostedFileBase> MediaFiles { get; set; }
    }
}