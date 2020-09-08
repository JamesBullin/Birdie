using System;
using System.Collections.Generic;

namespace BirdieModels
{
    public partial class Ball
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ColourId { get; set; }

        public virtual Colour Colour { get; set; }
    }
}
