using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;

namespace BirdieView.ViewModels
{
    class ShellViewModel : Screen
    {
        public string BallName { get; set; } = "Funsports 4";
        public string Manufacturer { get; set; } = "3D";
        public string Colour { get; set; } = "Red";
        public int Bounce { get; set; } = 400;
        public int Weight { get; set; } = 650;
        public int Shore { get; set; } = 500;
    }
}
