using ShoppingAppBLL.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppBLL.Repository.Interfaces
{
    public interface ICartRepository
    {
        //public Tuple<List<CartProductView>, float> GetCartItemsyByUserID(int id);
        public List<CartProductView> GetCartItemsyByUserID(int id);
    }
}
