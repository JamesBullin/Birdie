using BirdieModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BirdieBusiness
{
    public class CRUDOperations
    {
        public void AddBall(string name, Manufacturer manufacturer = null,
            OfficialColour officialColour = null, int? bounceInMillimetres = null,
            int? weightInTenthsOfGram = null, int? shoreInTenthsOfDurometre = null,
            int? SizeInMillimetres = null)
        {
            using (var db = new BirdieContext())
            {
                var newBall = new Ball()
                {
                    Name = name,
                    Manufacturer = manufacturer,
                    OfficialColour = officialColour,
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
        public IEnumerable<BasicColour> RetrieveBasicCoulours()
        {
            var output = new List<BasicColour>();
            using (var db = new BirdieContext())
            {
                output = db.BasicColour.ToList();
            }

            return output;
        }
        public IEnumerable<OfficialColour> RetrieveOfficialCoulours()
        {
            var output = new List<OfficialColour>();
            using (var db = new BirdieContext())
            {
                output = db.OfficialColour.ToList();
            }

            return output;
        }
        public IEnumerable<Manufacturer> RetrieveManufacturers()
        {
            var output = new List<Manufacturer>();
            using (var db = new BirdieContext())
            {
                output = db.Manufacturer.ToList();
            }

            return output;
        }
        public IEnumerable<Ball> RetrieveBalls()
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
