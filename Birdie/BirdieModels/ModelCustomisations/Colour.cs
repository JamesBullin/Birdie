using System;
using System.Collections.Generic;
using System.Text;

namespace BirdieModels
{
    public partial class Colour
    {
        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            Colour otherColour;
            try
            {
                otherColour = (Colour)obj;
            }
            catch (Exception)
            { return false; }

            return (otherColour.Id == this.Id);
        }

        public override int GetHashCode()
        {
            return this.Id;
        }
    }
}
