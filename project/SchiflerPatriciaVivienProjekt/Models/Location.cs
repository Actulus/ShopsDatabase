using System;
using System.Collections.Generic;

#nullable disable

namespace SchiflerPatriciaVivienProjekt.Models
{
    public partial class Location
    {
        public Location()
        {
            Bills = new HashSet<Bill>();
            Customers = new HashSet<Customer>();
            Employees = new HashSet<Employee>();
            Shops = new HashSet<Shop>();
            Suppliers = new HashSet<Supplier>();
            SupplyPlaces = new HashSet<SupplyPlace>();
        }

        public decimal LocationId { get; set; }
        public string LocationName { get; set; }
        public string LocationCountry { get; set; }
        public string ShortLocationCountry { get; set; }
        public string LocationCounty { get; set; }
        public string ShortLocationCounty { get; set; }

        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Shop> Shops { get; set; }
        public virtual ICollection<Supplier> Suppliers { get; set; }
        public virtual ICollection<SupplyPlace> SupplyPlaces { get; set; }
    }
}
