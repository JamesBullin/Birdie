using System;
using System.Collections.Generic;

namespace BirdieModels
{
    public partial class BasicColour
    {
        public BasicColour()
        {
            OfficialColour = new HashSet<OfficialColour>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<OfficialColour> OfficialColour { get; set; }
    }
}
