using System;
using System.Collections.Generic;

#nullable disable

namespace SchiflerPatriciaVivienProjekt.Models
{
    public partial class Shop
    {
        public Shop()
        {
            Bills = new HashSet<Bill>();
            Employees = new HashSet<Employee>();
        }

        public decimal ShopId { get; set; }
        public string ShopName { get; set; }
        public string ShopAddress { get; set; }
        public decimal LocationId { get; set; }
        public decimal DepartmentId { get; set; }

        public virtual Department Department { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
