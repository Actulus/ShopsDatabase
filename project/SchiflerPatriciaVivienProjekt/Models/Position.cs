using System;
using System.Collections.Generic;

#nullable disable

namespace SchiflerPatriciaVivienProjekt.Models
{
    public partial class Position
    {
        public decimal PositionId { get; set; }
        public string PositionName { get; set; }
        public decimal DepartmentId { get; set; }

        public virtual Department Department { get; set; }
    }
}
