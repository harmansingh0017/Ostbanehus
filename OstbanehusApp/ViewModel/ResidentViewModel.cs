using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using OstbanehusApp.Common;
using OstbanehusApp.Handler;
using OstbanehusApp.Model;

namespace OstbanehusApp.ViewModel
{
     class ResidentViewModel : INotifyPropertyChanged
    {

        public ResidentsCatalogSingleton ResidentsCatalogSingleton { get; set; }
     //   public Residents resident_no { get; set; }
        public Handler.ResidentHandler ResidentHandler { get; set; }
        public ICommand CreateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        private Residents _selectedEventIndex;

        public Residents Residentss_No
        {
            get ; 
            set;
        }

        public ResidentViewModel()
        {
            ResidentsCatalogSingleton = ResidentsCatalogSingleton.Instance;
            NewResidents = new Residents();
            ResidentHandler = new ResidentHandler(this);
            CreateCommand = new RelayCommand(ResidentHandler.CreateResident);
            DeleteCommand = new RelayCommand(ResidentHandler.DeleteResident);
            UpdateCommand = new RelayCommand(ResidentHandler.UpdateResident);
            Residentss_No = new Residents();
        }
        private string _ApNomessage;
        public string ApNoMessage
        {
            get { return _ApNomessage; }
            set
            {
                _ApNomessage = value;
                OnPropertyChanged(nameof(ApNoMessage));
            }
        }
        //private string _FNamemessage;
        //public string FNameMessage
        //{
        //    get { return _FNamemessage; }
        //    set
        //    {
        //        _ApNomessage = value;
        //        OnPropertyChanged(nameof(FNameMessage));
        //    }
        //}

        private Residents _newResidents;
        

        public Residents NewResidents
        {
            get { return _newResidents; }
            set { _newResidents = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Residents> _selectedListView;

        public ObservableCollection<Residents> SelectedListView
        {
            get { return this._selectedListView; }
            set
            {
                _selectedListView = value;
                OnPropertyChanged(nameof(SelectedListView));
            }
        }
        public Residents SelectedEventIndex
        {
            get { return _selectedEventIndex; }
            set
            {
                _selectedEventIndex = value;
                OnPropertyChanged(nameof(SelectedEventIndex));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}
