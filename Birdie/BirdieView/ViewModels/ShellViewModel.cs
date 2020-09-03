using BirdieBusiness;
using BirdieModels;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;

namespace BirdieView.ViewModels
{
    class ShellViewModel : Screen
    {
        CRUDOperations crud = new CRUDOperations();

        Ball selectBall;

        List<Ball> balls = crud.SelectAllBalls();

        public string BallName { get; set; } = "Funsports 4";
        public string Manufacturer { get; set; } = "3D";
        public string Colour { get; set; } = "Red";
        public int Bounce { get; set; } = 400;
        public int Weight { get; set; } = 650;
        public int Shore { get; set; } = 500;

        public void AddBall()
        {
            // If the ball is already in the database, show a message

            crud.AddBall("Funsports 4", 1, 2, 450, 500, 600, 400);
        }

        public void AddManufacturer()
        {
            crud.AddManufacturer("3D");
        }

        public void AddOfficialColour()
        {
            crud.AddOfficialColour("Crimson", 3);
        }
    }
}
