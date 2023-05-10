using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppBLL.ModelViews
{
    public class CartProductView
    {
        public int? ProductId { get; set; }
        public string ProductName { get; set; }
        public int CartCount { get; set; }
        public float CartPrice { get;set; }
        public string ProductDescription { get; set; }
        public float ProductPrice { get; set; }
    }
}
