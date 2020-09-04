using BirdieBusiness;
using BirdieModels;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdieView.ViewModels
{
    class ShellViewModel : Screen
    {
        // listboxDBContext = RetrieveAll()
        CRUDOperations crud = new CRUDOperations();
        public BindableCollection<Ball> Balls { get; set; }
        public BindableCollection<BasicColour> BasicColours { get; set; }
        public BindableCollection<Manufacturer> Manufacturers { get; set; }
        public BindableCollection<OfficialColour> OfficialColours { get; set; }

        private Ball _selectedBall;
        public Ball SelectedBall
        {
            get { return _selectedBall; }
            set
            {
                _selectedBall = value;
                NotifyOfPropertyChange(() => SelectedBall);
            }
        }

        public ShellViewModel()
        {
            OfficialColours = new BindableCollection<OfficialColour>(collection: crud.RetrieveOfficialCoulours());
            Manufacturers = new BindableCollection<Manufacturer>(collection: crud.RetrieveManufacturers());
            BasicColours = new BindableCollection<BasicColour>(collection: crud.RetrieveBasicCoulours());
            Balls = new BindableCollection<Ball>(collection: crud.RetrieveBalls());
        }
        public void AddBall()
        {
            // If the ball is already in the database, show a message

            //crud.AddBall(BallName, Manufacturer, Colour, 450, 500, 600, 400);
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
