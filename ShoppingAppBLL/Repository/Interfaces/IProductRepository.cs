using ShoppingAppBLL.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppBLL.Repository.Interfaces
{
    public interface IProductRepository
    {
        public IEnumerable<ProductView> GetAllProducts(); //get all items
        public List<ProductView> GetProductByCategoryName(string categoryname); //get items by category name

    }
}
