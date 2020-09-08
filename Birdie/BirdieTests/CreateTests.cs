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
        public void AddBallDetailsCorrectTest()
        {
            crud.AddBall(NewTestBall);

            using (var db = new BirdieDBContext())
            {
                var dbBall = db.Ball
                .Where(b => b.Name == "New Test Ball")
                .Single();

                Assert.AreEqual("New Test Ball", dbBall.Name);
                Assert.AreEqual(3, dbBall.ColourId);
            }
        }

        [Test]
        public void AddBallRowCountIncreases()
        {
            int numRows;
            int newNumRows;

            using (var db = new BirdieDBContext())
            {
                numRows = db.Ball.Count();

                crud.AddBall(NewTestBall);

                newNumRows = db.Ball.Count();
            }

            Assert.AreEqual(numRows + 1, newNumRows);
        }

        [Test]
        public void AddBallSQLInjectionTest()
        {
            NewTestBall.Name = "Test; DROP TABLE Balls;";

            crud.AddBall(NewTestBall);

            using (var db = new BirdieDBContext())
            {
                var Balls = db.Ball.ToList();

                Assert.AreNotEqual(0, Balls.Count());
            }
        }
    }
}
