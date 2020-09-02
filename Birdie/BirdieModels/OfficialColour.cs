using System;
using System.Collections.Generic;

namespace BirdieModels
{
    public partial class OfficialColour
    {
        public OfficialColour()
        {
            Ball = new HashSet<Ball>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int BasicColourId { get; set; }

        public virtual BasicColour BasicColour { get; set; }
        public virtual ICollection<Ball> Ball { get; set; }
    }
}
