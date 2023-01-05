using System;
using System.Collections.Generic;

#nullable disable

namespace SchiflerPatriciaVivienProjekt.Models
{
    public partial class Bill
    {
        public decimal BillId { get; set; }
        public string BillDatetime { get; set; }
        public decimal LocationId { get; set; }
        public decimal PaymentTypeId { get; set; }
        public decimal CustomerId { get; set; }
        public decimal EmployeeId { get; set; }
        public decimal ShopId { get; set; }
        public decimal Total { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Location Location { get; set; }
        public virtual PaymentType PaymentType { get; set; }
        public virtual Shop Shop { get; set; }
    }
}
