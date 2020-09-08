using BirdieBusiness;
using BirdieModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BirdieTests
{
    partial class CRUDTests
    {
        [Test]
        public void UpdateBallTest()
        {
            using (var db = new BirdieDBContext())
            {
                var newColour = db.Colour.Where(c => c.Name == "Blue").Single();

                TestBall.Name = "Test NameChange";
                TestBall.Colour = newColour;

                crud.UpdateBall(TestBall);

                var newBall = db.Ball
                    .Where(b => b.Id == TestBall.Id)
                    .Single();

                Assert.AreEqual("Test NameChange", newBall.Name);
                Assert.AreEqual(newColour.Id, newBall.ColourId);
            }
        }

        // Change a ball's colour from red to white. Then check that another red ball is still red.
    }
}
