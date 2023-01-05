using System;
using System.Collections.Generic;

#nullable disable

namespace SchiflerPatriciaVivienProjekt.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Bills = new HashSet<Bill>();
        }

        public decimal CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhoneNum { get; set; }
        public string CustomerEmail { get; set; }
        public decimal LocationId { get; set; }
        public string CustomerAdress { get; set; }

        public virtual Location Location { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
    }
}
