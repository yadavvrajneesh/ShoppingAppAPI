using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppBLL.ModelViews
{
    public class OrderView
    {
        public int? OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string ProductName { get; set; }
        public int ProductCount { get; set; }
        public int ShippingAddressHouseNumber { get; set; }
        public string ShippingAddressBuildingName { get; set; }
        public string ShippingAddressAreaName { get; set; }
        public string? ShippingAddressType { get; set; }
        public int ShippingAddressPincode { get; set; }
        public string ShippingAddressCity { get; set; }
        public string ShippingAddressState { get; set; }
        public int BillingAddressHouseNumber { get; set; }
        public string BillingAddressBuildingName { get; set; }
        public string BillingAddressAreaName { get; set; }
        public string? BillingAddressType { get; set; }
        public int BillingAddressPincode { get; set; }
        public string BillingAddressCity { get; set; }
        public string BillingAddressState { get; set; }
        public double TotalPrice { get; set; }
    }
}
