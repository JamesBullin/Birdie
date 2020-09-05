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
        CRUDOperations crud = new CRUDOperations();
        public BindableCollection<Ball> Balls { get; set; }

        private BindableCollection<Ball> _ballsShown;
        public BindableCollection<Ball> BallsShown
        {
            get { return _ballsShown; }
            set
            {
                _ballsShown = value;
                NotifyOfPropertyChange(() => BallsShown);
            }
        }

        public BindableCollection<BasicColour> BasicColours { get; set; }

        public BindableCollection<Manufacturer> Manufacturers { get; set; }
        private BindableCollection<Manufacturer> _manufacturersShown;
        public BindableCollection<Manufacturer> ManufacturersShown
        {
            get { return _manufacturersShown; }
            set
            {
                _manufacturersShown = value;
                NotifyOfPropertyChange(() => ManufacturersShown);
            }
        }

        public BindableCollection<OfficialColour> OfficialColours { get; set; }
        private BindableCollection<OfficialColour> _officialColoursShown;
        public BindableCollection<OfficialColour> OfficialColoursShown
        {
            get { return _officialColoursShown; }
            set
            {
                _officialColoursShown = value;
                NotifyOfPropertyChange(() => OfficialColoursShown);
            }
        }

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
            OfficialColours = OfficialColoursShown =  new BindableCollection<OfficialColour>(collection: crud.RetrieveOfficialCoulours());
            Manufacturers = ManufacturersShown = new BindableCollection<Manufacturer>(collection: crud.RetrieveManufacturers());
            BasicColours = new BindableCollection<BasicColour>(collection: crud.RetrieveBasicCoulours());
            Balls = BallsShown = new BindableCollection<Ball>(collection: crud.RetrieveBalls());
        }
        public void AddBall()
        {
            // If the ball is already in the database, show a message

            //crud.AddBall(SelectedBall.Name, Manufacturer, OfficialColour, 450, 500, 600, 400);
        }

        public void AddManufacturer()
        {
            crud.AddManufacturer("3D");
        }

        public void AddOfficialColour()
        {
            crud.AddOfficialColour("Crimson", 3);
        }
        /*
        private void SetOfficialColoursShown(BasicColour input)
        {
            BindableCollection<OfficialColour> output = new BindableCollection<OfficialColour>();

            if (BasicColourQuery == null)
            {
                _officialColoursShown = OfficialColours;
            }
            else
            {
                foreach (var item in OfficialColours)
                {
                    if (item.BasicColour.Name == input.Name)
                    {
                        output.Add(item);
                    }
                }
            }
                
            OfficialColoursShown = output;
        }
        */

    }
}
