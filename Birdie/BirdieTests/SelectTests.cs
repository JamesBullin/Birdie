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
        public void SelectBallCorrectRowCountTest()
        {
            var balls = crud.RetrieveBalls();
            int numRows;

            using (var db = new BirdieDBContext())
            {
                numRows = db.Ball.Count();
            }

            Assert.AreEqual(balls.Count(), numRows);
        }

        [Test]
        public void SelectColourCorrectRowCountTest()
        {
            var colours = crud.RetrieveColours();
            int numRows;

            using (var db = new BirdieDBContext())
            {
                numRows = db.Colour.Count();
            }

            Assert.AreEqual(colours.Count(), numRows);
        }
    }
}
