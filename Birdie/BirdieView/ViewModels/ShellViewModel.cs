using BirdieBusiness;
using BirdieModels;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace BirdieView.ViewModels
{
    class ShellViewModel : Screen
    {
        CRUDOperations crud = new CRUDOperations();
        public BindableCollection<Ball> Balls { get; set; }
        public BindableCollection<Colour> Colours { get; set; }

        private Ball _selectedBall;
        public Ball SelectedBall
        {
            get { return _selectedBall; }
            set
            {
                _selectedBall = value;

                DeleteButtonEnabled = value == null ? false : true;
                EditButtonEnabled = value == null ? false : true;

                NotifyOfPropertyChange(() => SelectedBall);
            }
        }

        private Colour _selectedColour;
        public Colour SelectedColour
        {
            get { return _selectedColour; }
            set
            {
                _selectedColour = value;

                if (value == null)
                {
                    LoadBalls();
                    ShowAllBallsVisibility = Visibility.Collapsed;
                }
                else
                {
                    LoadBalls(value);
                    ShowAllBallsVisibility = Visibility.Visible;
                }

                NotifyOfPropertyChange(() => SelectedColour);
            }
        }

        // These regions contain UI Control "On/Off" switches. It needs to be optimised using a
        // dictionary of Control / Switches pairs. 
        #region Button Visibility 

        Visibility _showAllBallsVisibility = Visibility.Collapsed;
        public Visibility ShowAllBallsVisibility
        {
            get { return _showAllBallsVisibility; }
            set
            {
                _showAllBallsVisibility = value;
                NotifyOfPropertyChange(() => ShowAllBallsVisibility);
            }
        }

        Visibility _editButtonVisibility = Visibility.Visible;
        public Visibility EditButtonVisibility
        {
            get { return _editButtonVisibility; }
            set
            {
                _editButtonVisibility = value;
                NotifyOfPropertyChange(() => EditButtonVisibility);
            }
        }

        Visibility _confirmEditButtonVisibility = Visibility.Collapsed;
        public Visibility ConfirmEditButtonVisibility
        {
            get { return _confirmEditButtonVisibility; }
            set
            {
                _confirmEditButtonVisibility = value;
                NotifyOfPropertyChange(() => ConfirmEditButtonVisibility);
            }
        }

        Visibility _addBallButtonVisibility = Visibility.Visible;
        public Visibility AddBallButtonVisibility
        {
            get { return _addBallButtonVisibility; }
            set
            {
                _addBallButtonVisibility = value;
                NotifyOfPropertyChange(() => AddBallButtonVisibility);
            }
        }

        Visibility _confirmAddBallButtonVisibility = Visibility.Collapsed;
        public Visibility ConfirmAddBallButtonVisibility
        {
            get { return _confirmAddBallButtonVisibility; }
            set
            {
                _confirmAddBallButtonVisibility = value;
                NotifyOfPropertyChange(() => ConfirmAddBallButtonVisibility);
            }
        }

        Visibility _deleteBallButtonVisibility = Visibility.Visible;
        public Visibility DeleteBallButtonVisibility
        {
            get { return _deleteBallButtonVisibility; }
            set
            {
                _deleteBallButtonVisibility = value;
                NotifyOfPropertyChange(() => DeleteBallButtonVisibility);
            }
        }

        Visibility _confirmDeleteBallButtonVisibility = Visibility.Collapsed;
        public Visibility ConfirmDeleteBallButtonVisibility
        {
            get { return _confirmDeleteBallButtonVisibility; }
            set
            {
                _confirmDeleteBallButtonVisibility = value;
                NotifyOfPropertyChange(() => ConfirmDeleteBallButtonVisibility);
            }
        }

        Visibility _cancelDeleteBallButtonVisibility = Visibility.Collapsed;
        public Visibility CancelDeleteBallButtonVisibility
        {
            get { return _cancelDeleteBallButtonVisibility; }
            set
            {
                _cancelDeleteBallButtonVisibility = value;
                NotifyOfPropertyChange(() => CancelDeleteBallButtonVisibility);
            }
        }

        #endregion

        #region DataGrid isEnabled

        bool _ballNameDataGridEnabled = true;
        public bool BallNameDataGridEnabled
        {
            get { return _ballNameDataGridEnabled; }
            set
            {
                _ballNameDataGridEnabled = value;
                NotifyOfPropertyChange(() => BallNameDataGridEnabled);
            }
        }

        bool _colourDataGridEnabled = true;
        public bool ColourDataGridEnabled
        {
            get { return _colourDataGridEnabled; }
            set
            {
                _colourDataGridEnabled = value;
                NotifyOfPropertyChange(() => ColourDataGridEnabled);
            }
        }

        bool _selectedBallColourEnabled = false;

        public bool SelectedBallColourEnabled
        {
            get { return _selectedBallColourEnabled; }
            set
            {
                _selectedBallColourEnabled = value;
                NotifyOfPropertyChange(() => SelectedBallColourEnabled);
            }
        }

        #endregion

        #region Button isEnabled

        bool _deleteButtonEnabled = false;
        public bool DeleteButtonEnabled
        {
            get { return _deleteButtonEnabled; }
            set
            {
                _deleteButtonEnabled = value;
                NotifyOfPropertyChange(() => DeleteButtonEnabled);
            }
        }

        bool _editButtonEnabled = false;
        public bool EditButtonEnabled
        {
            get { return _editButtonEnabled; }
            set
            {
                _editButtonEnabled = value;
                NotifyOfPropertyChange(() => EditButtonEnabled);
            }
        }

        bool _addBallButtonEnabled = true;
        public bool AddBallButtonEnabled
        {
            get { return _addBallButtonEnabled; }
            set
            {
                _addBallButtonEnabled = value;
                NotifyOfPropertyChange(() => AddBallButtonEnabled);
            }
        }

        #endregion

        #region Ball Properties Controls isEnabled

        bool _txtBallNameEnabled = false;

        public bool txtBallNameEnabled
        {
            get { return _txtBallNameEnabled; }
            set
            {
                _txtBallNameEnabled = value;
                NotifyOfPropertyChange(() => txtBallNameEnabled);
            }
        }

        #endregion

        public ShellViewModel()
        {
            LoadBalls();
            LoadColours();
        }

        public void LoadBalls()
        {
            Balls = new BindableCollection<Ball>(collection: crud.RetrieveBalls());
            NotifyOfPropertyChange(() => Balls);
        }
        
        public void LoadBalls(Colour colour)
        {
            Balls = new BindableCollection<Ball>(collection: crud.RetrieveBalls(colour));
            NotifyOfPropertyChange(() => Balls);
        }

        public void LoadColours()
        {
            Colours = new BindableCollection<Colour>(collection: crud.RetrieveColours());
            NotifyOfPropertyChange(() => Colours);
        }

        public void EditBall()
        {
            txtBallNameEnabled = true;
            SelectedBallColourEnabled = true;

            ShowAllBallsVisibility = Visibility.Collapsed;
            EditButtonVisibility = Visibility.Collapsed;
            ConfirmEditButtonVisibility = Visibility.Visible;

            ColourDataGridEnabled = false;
            BallNameDataGridEnabled = false;

            DeleteButtonEnabled = false;
            AddBallButtonEnabled = false;
        }
        public void ConfirmEdit()
        {
            var id = SelectedBall.Id;

            crud.UpdateBall(SelectedBall);
            LoadBalls();

            SelectedBall = Balls.Where(b => b.Id == id).Single();

            txtBallNameEnabled = false;
            SelectedBallColourEnabled = false;

            EditButtonVisibility = Visibility.Visible;
            ConfirmEditButtonVisibility = Visibility.Collapsed;

            ColourDataGridEnabled = true;
            BallNameDataGridEnabled = true;

            DeleteButtonEnabled = true;
            AddBallButtonEnabled = true;
        }

        public void AddNewBall()
        {
            txtBallNameEnabled = true;
            SelectedBallColourEnabled = true;

            SelectedBall = new Ball();

            ShowAllBallsVisibility = Visibility.Collapsed;
            AddBallButtonVisibility = Visibility.Collapsed;
            ConfirmAddBallButtonVisibility = Visibility.Visible;

            BallNameDataGridEnabled = false;
            ColourDataGridEnabled = false;

            DeleteButtonEnabled = false;
            EditButtonEnabled = false;
        }
        public void ConfirmAddBall()
        {
            var newBallName = SelectedBall.Name;

            // Validation
            if (SelectedBall.Name == null || SelectedBall.Name == "" || SelectedBall.Colour == null)
            {
                MessageBox.Show("Please give the new ball a name and a colour.");
                return;
            }

            crud.AddBall(SelectedBall);
            LoadBalls();

            // This will not work if balls have the same name. Unfortunately
            SelectedBall = Balls.Where(b => b.Name == newBallName).FirstOrDefault();

            txtBallNameEnabled = false;
            SelectedBallColourEnabled = false;
            AddBallButtonVisibility = Visibility.Visible;
            ConfirmAddBallButtonVisibility = Visibility.Collapsed;

            BallNameDataGridEnabled = true;
            ColourDataGridEnabled = true;

            DeleteButtonEnabled = true;
            EditButtonEnabled = true;
        }

        public void DeleteBall()
        {

            ShowAllBallsVisibility = Visibility.Collapsed;
            DeleteBallButtonVisibility = Visibility.Collapsed;
            ConfirmDeleteBallButtonVisibility = Visibility.Visible;
            CancelDeleteBallButtonVisibility = Visibility.Visible;

            BallNameDataGridEnabled = false;
            ColourDataGridEnabled = false;

            AddBallButtonEnabled = false;
            EditButtonEnabled = false;
        }
        public void ConfirmDeleteBall()
        {
            crud.DeleteBall(SelectedBall);
            LoadBalls();

            SelectedBall = null;
            CancelDeleteBall();
        }
        public void CancelDeleteBall()
        {
            DeleteBallButtonVisibility = Visibility.Visible;
            ConfirmDeleteBallButtonVisibility = Visibility.Collapsed;
            CancelDeleteBallButtonVisibility = Visibility.Collapsed;

            BallNameDataGridEnabled = true;
            ColourDataGridEnabled = true;

            AddBallButtonEnabled = true;
            EditButtonEnabled = true;
        }

        public void ShowAllBalls()
        {
            SelectedColour = null;
        }
    }
}
