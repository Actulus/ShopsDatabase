using System;
using System.Collections.Generic;

#nullable disable

namespace SchiflerPatriciaVivienProjekt.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Bills = new HashSet<Bill>();
        }

        public decimal EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpPhoneNum { get; set; }
        public string EmpEmail { get; set; }
        public decimal LocationId { get; set; }
        public string EmpAddress { get; set; }
        public decimal ShopId { get; set; }
        public decimal DepartmentId { get; set; }
        public string EmpPosition { get; set; }
        public decimal EmpSalary { get; set; }

        public virtual Department Department { get; set; }
        public virtual Location Location { get; set; }
        public virtual Shop Shop { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
    }
}
