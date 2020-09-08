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
        public void DeleteBallTest()
        {
            crud.DeleteBall(TestBall);
            int numResults;

            using (var db = new BirdieDBContext())
            {
                numResults = db.Ball
                    .Where(b => b.Id == TestBall.Id).Count();
            }

            Assert.AreEqual(numResults, 0);
        }
    }
}
