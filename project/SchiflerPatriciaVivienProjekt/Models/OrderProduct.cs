using System;
using System.Collections.Generic;

#nullable disable

namespace SchiflerPatriciaVivienProjekt.Models
{
    public partial class OrderProduct
    {
        public decimal OrderProductsId { get; set; }
        public decimal Quantity { get; set; }
        public decimal ProductId { get; set; }
        public decimal BillId { get; set; }
    }
}
