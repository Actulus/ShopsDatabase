using System;
using System.Collections.Generic;

#nullable disable

namespace SchiflerPatriciaVivienProjekt.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Supplyings = new HashSet<Supplying>();
        }

        public decimal SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string SupplierPhoneNumber { get; set; }
        public string SupplierEmail { get; set; }
        public string SupplierAddress { get; set; }
        public decimal LocationId { get; set; }

        public virtual Location Location { get; set; }
        public virtual ICollection<Supplying> Supplyings { get; set; }
    }
}
