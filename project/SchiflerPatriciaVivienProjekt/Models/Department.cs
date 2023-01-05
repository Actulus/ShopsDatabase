using System;
using System.Collections.Generic;

#nullable disable

namespace SchiflerPatriciaVivienProjekt.Models
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
            Positions = new HashSet<Position>();
            Shops = new HashSet<Shop>();
        }

        public decimal DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Position> Positions { get; set; }
        public virtual ICollection<Shop> Shops { get; set; }
    }
}
