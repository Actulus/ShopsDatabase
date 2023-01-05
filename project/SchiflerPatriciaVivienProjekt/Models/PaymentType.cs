using System;
using System.Collections.Generic;

#nullable disable

namespace SchiflerPatriciaVivienProjekt.Models
{
    public partial class PaymentType
    {
        public PaymentType()
        {
            Bills = new HashSet<Bill>();
        }

        public decimal PaymentTypeId { get; set; }
        public string PaymentTypeName { get; set; }

        public virtual ICollection<Bill> Bills { get; set; }
    }
}
