using System.Collections.Generic;

namespace Inveon.WEB.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Barcode { get; set; }
        public List<MediaViewModel> MediaList { get; set; }

    }
}