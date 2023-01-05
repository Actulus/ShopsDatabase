using System;
using System.Collections.Generic;

#nullable disable

namespace SchiflerPatriciaVivienProjekt.Models
{
    public partial class Supplying
    {
        public decimal SupplyingId { get; set; }
        public DateTime SupplyingDate { get; set; }
        public string SupplyingTime { get; set; }
        public decimal SupplyingPlaceId { get; set; }
        public decimal SupplierId { get; set; }

        public virtual Supplier Supplier { get; set; }
        public virtual SupplyPlace SupplyingPlace { get; set; }
    }
}
