using BirdieModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BirdieBusiness
{
    public class CRUDOperations
    {
        #region CreateOperations

        public void AddBall(Ball inputBall)
        {
            var newBall = new Ball()
            {
                Name = inputBall.Name,
                ColourId = inputBall.Colour.Id
            };

            using (var db = new BirdieDBContext())
            {
                db.Ball.Add(newBall);
                db.SaveChanges();
            }
        }

        #endregion

        #region ReadOperations
        public IEnumerable<Ball> RetrieveBalls()
        {
            var output = new List<Ball>();

            using (var db = new BirdieDBContext())
            {
                output = db.Ball
                    .Include(b => b.Colour)
                    .ToList();
            }

            return output;
        }

        public IEnumerable<Ball> RetrieveBalls(Colour colour)
        {
            var output = new List<Ball>();

            using (var db = new BirdieDBContext())
            {
                output = db.Ball
                    .Where(b => b.ColourId == colour.Id)
                    .Include(b => b.Colour)
                    .ToList();
            }

            return output;
        }

        public IEnumerable<Colour> RetrieveColours()
        {
            var output = new List<Colour>();

            using (var db = new BirdieDBContext())
            {
                output = db.Colour
                    .ToList();
            }

            return output;
        }

        #endregion

        #region UpdateOperations

        public void UpdateBall(Ball inputBall)
        {
            using (var db = new BirdieDBContext())
            {
                var originalBall = db.Ball
                    .Where(b => b.Id == inputBall.Id)
                    .Single();

                originalBall.Name = inputBall.Name;
                originalBall.ColourId = inputBall.Colour.Id;

                db.SaveChanges();
            }
        }

        #endregion

        #region DeleteOperations

        public void DeleteBall(Ball inputBall)
        {
            using (var db = new BirdieDBContext())
            {
                var originalBall = db.Ball
                    .Where(b => b.Id == inputBall.Id)
                    .Single();

                db.Ball.Remove(originalBall);

                db.SaveChanges();
            }
        }

        #endregion
    }
}
