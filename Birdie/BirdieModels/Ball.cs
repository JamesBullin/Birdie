using System;
using System.Collections.Generic;

namespace BirdieModels
{
    public partial class Ball
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ManufacturerId { get; set; }
        public int? OfficialColourId { get; set; }
        public int? BounceInMillimetres { get; set; }
        public int? WeightInTenthsOfGram { get; set; }
        public int? ShoreInTenthsOfDurometre { get; set; }
        public int? SizeInMillimetres { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
        public virtual OfficialColour OfficialColour { get; set; }
    }
}
