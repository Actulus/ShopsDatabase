using System;
using System.Collections.Generic;

#nullable disable

namespace SchiflerPatriciaVivienProjekt.Models
{
    public partial class Discount
    {
        public Discount()
        {
            Products = new HashSet<Product>();
        }

        public decimal DiscountId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? Percentage { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
