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
        CRUDOperations crud = new CRUDOperations();
        Ball TestBall; // Starts with an ID from the database, name = "Test Ball", ColourID == 1;
        Ball NewTestBall; // Starts without an ID or ColourID, name = "New Test Ball", Colour = {Red};



        [SetUp]
        public void Setup()
        {
            // Prepare TestBall
            using (var db = new BirdieDBContext())
            {
                var newBall = new Ball()
                {
                    Name = "Test Ball",
                    ColourId = 1
                };

                db.Ball.Add(newBall);
                db.SaveChanges();

                TestBall = db.Ball
                    .Where(b => b.Name == "Test Ball")
                    .Single();
            }

            // Prepare NewTestBall
            using (var db = new BirdieDBContext())
            {
                var dbColour = db.Colour.Where(c => c.Name == "Red").Single();

                NewTestBall = new Ball()
                {
                    Name = "New Test Ball",
                    Colour = dbColour
                };
            }
        }

        [TearDown]
        public void TearDown()
        {
            using (var db = new BirdieDBContext())
            {
                var TestBalls = db.Ball
                    .Where(b => b.Name.Contains("Test"))
                    .ToList();

                foreach (var item in TestBalls)
                {
                    db.Ball.Remove(item);
                }

                db.SaveChanges();
            }
        }
    }
}