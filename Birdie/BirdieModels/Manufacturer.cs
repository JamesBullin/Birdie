using System;
using System.Collections.Generic;

namespace BirdieModels
{
    public partial class Manufacturer
    {
        public Manufacturer()
        {
            Ball = new HashSet<Ball>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Ball> Ball { get; set; }
    }
}
