using System;
using System.Collections.Generic;

#nullable disable

namespace SchiflerPatriciaVivienProjekt.Models
{
    public partial class Product
    {
        public decimal ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal CategoryId { get; set; }
        public decimal Quantity { get; set; }
        public decimal NormalPricePerPiece { get; set; }
        public decimal? DiscountPricePerPiece { get; set; }
        public decimal? DiscountId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Discount Discount { get; set; }
    }
}
