﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppDAL.Models
{
    [Table("Order")]
    public class Order
    {
        [Key]
        [Column("ID")]
        public int OrderId { get; set; } //autogenerated
        [DataType("date")]
        [Column("OrderDate")]
        public DateTime OrderDate { get; set; }
        [ForeignKey("Cart")]
        public int? CartId { get; set; } //adding foreign key from carttable //make sure it's non nullable
        public virtual Cart? Cart { get; set; }
        [DataType("int")]
        [Column("ShippingAddressId")]
        public int ShippingAddressId { get; set; }
        [DataType("int")]
        [Column("BillingAddressId")]
        public int BillingAddressId { get; set; }

        [ForeignKey("User")]
        public int? UserId { get; set; }
        public virtual User? User { get; set; }
        public float OrderPrice { get; set; }

    }
}