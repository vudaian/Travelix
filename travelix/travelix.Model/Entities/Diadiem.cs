using System;
using System.Collections.Generic;

#nullable disable

namespace travelix.Model.Entities
{
    public partial class Diadiem
    {
        public Diadiem()
        {
            Tours = new HashSet<Tour>();
        }

        public int IdDiaDiem { get; set; }
        public string DiaChi { get; set; }
        public string TenDiaDanh { get; set; }

        public virtual ICollection<Tour> Tours { get; set; }
    }
}
