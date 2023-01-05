using System;
using System.Collections.Generic;

#nullable disable

namespace SchiflerPatriciaVivienProjekt.Models
{
    public partial class SupplyPlace
    {
        public SupplyPlace()
        {
            Supplyings = new HashSet<Supplying>();
        }

        public decimal SupplyPlaceId { get; set; }
        public string SupplyPlaceName { get; set; }
        public string SupplyPlaceAddress { get; set; }
        public decimal LocationId { get; set; }

        public virtual Location Location { get; set; }
        public virtual ICollection<Supplying> Supplyings { get; set; }
    }
}
