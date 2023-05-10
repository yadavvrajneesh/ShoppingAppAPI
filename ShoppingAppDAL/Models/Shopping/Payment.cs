using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppDAL.Models.Shopping
{
    [Table("Payment")]
    public class Payment
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [ForeignKey("Order")]
        public int? OrderId { get; set; }
        public virtual Order? Order { get; set; }
        [Required]
        [DataType("varchar")]
        [Column("Mode")]
        [MaxLength(20, ErrorMessage = "Mode not Available.")]
        public string Mode { get; set; }
        [Required]
        [DataType("varchar")]
        [Column("Status")]
        [MaxLength(30)]
        public string Status { get; set; }
        [DataType("float")]
        [Column("Paid")]
        public double Paid { get; set; }
        [DataType("float")]
        [Column("Balance")]
        public double Balance { get; set; }
    }
}
