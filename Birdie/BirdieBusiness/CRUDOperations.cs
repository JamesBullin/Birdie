using BirdieModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BirdieBusiness
{
    public class CRUDOperations
    {
        public void AddBall(string name, int? manufacturerID = null,
            int? officialColourID = null, int? bounceInMillimetres = null,
            int? weightInTenthsOfGram = null, int? shoreInTenthsOfDurometre = null,
            int? SizeInMillimetres = null)
        {
            using (var db = new BirdieContext())
            {
                var newBall = new Ball()
                {
                    Name = name,
                    ManufacturerId = manufacturerID,
                    OfficialColourId = officialColourID,
                    BounceInMillimetres = bounceInMillimetres,
                    WeightInTenthsOfGram = weightInTenthsOfGram,
                    ShoreInTenthsOfDurometre = shoreInTenthsOfDurometre,
                    SizeInMillimetres = SizeInMillimetres
                };

                db.Ball.Add(newBall);
                db.SaveChanges();
            }
        }

        public void AddManufacturer(string name)
        {
            using (var db = new BirdieContext())
            {
                var newManufacturer = new Manufacturer()
                {
                    Name = name,
                };

                db.Manufacturer.Add(newManufacturer);
                db.SaveChanges();
            }
        }

        public void AddOfficialColour(string name, int basicColourID)
        {
            using (var db = new BirdieContext())
            {
                var newOfficialColour = new OfficialColour()
                {
                    Name = name,
                    BasicColourId = basicColourID
                };

                db.OfficialColour.Add(newOfficialColour);
                db.SaveChanges();
            }
        }

        public List<Ball> SelectAllBalls()
        {
            var output = new List<Ball>();

            using (var db = new BirdieContext())
            {
                output = db.Ball.ToList();
            }

            return output;
        }

    }
}
