﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppDAL.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [Column("ID")]
        public int ProductId { get; set; } //autogenerated
        [Required]
        [DataType("varchar")]
        [Column("Name")]
        [MaxLength(100, ErrorMessage = "Product Name cannot me more than 100 characters. Consider adding short names")]
        public string ProductName { get; set; }
        [DataType("varchar")]
        [Column("Description")]
        [MaxLength(300, ErrorMessage = "Product Description cannot me more than 300 characters. Consider adding short names")]
        public string? ProductDescription { get; set; }
        [Required]
        [DataType("float")]
        [Column("Price")]
        public float ProductPrice { get; set; }
        [Required]
        [DataType("int")]
        [Column("Count")]
        public int ProductCount { get; set; }
        [ForeignKey("Categories")]
        public int? CategoryId { get; set; } //adding foreign key from category table //make sure it's non nullable
        public virtual Category? Category { get; set; }


    }
}
