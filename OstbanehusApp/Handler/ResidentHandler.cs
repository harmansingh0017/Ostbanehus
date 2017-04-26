using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using OstbanehusApp.Model;
using OstbanehusApp.Persistency;
using OstbanehusApp.ViewModel;

namespace OstbanehusApp.Handler
{
      class ResidentHandler : INotifyPropertyChanged
    {
        public ResidentViewModel ResidentViewModel { get; set; }

        public ResidentHandler(ResidentViewModel residentViewModel)
        {
            ResidentViewModel = residentViewModel;
        }

        public void CreateResident()
        {
            try
            {
                var resident = new Residents()
                {
                    Apartment_No = ResidentViewModel.NewResidents.Apartment_No,
                    FirstName = ResidentViewModel.NewResidents.FirstName,
                    MiddleName = ResidentViewModel.NewResidents.MiddleName,
                    LastName = ResidentViewModel.NewResidents.LastName,
                    Gender = ResidentViewModel.NewResidents.Gender,
                    Phone = ResidentViewModel.NewResidents.Phone,
                    Email = ResidentViewModel.NewResidents.Email,
                    Age = ResidentViewModel.NewResidents.Age


                };

                new PersistenceFacade().PostResident(resident);

                //HotelViewModel.Hotels.Hotels.Add(hotel);
                var residents = new PersistenceFacade().GetResident();

                ResidentViewModel.ResidentsCatalogSingleton.Residents.Clear();
                foreach (var resident1 in residents)
                {
                    ResidentViewModel.ResidentsCatalogSingleton.Residents.Add(resident1);
                }

                ResidentViewModel.NewResidents.Resident_No = 0  ;
                ResidentViewModel.NewResidents.Apartment_No = 0;
                ResidentViewModel.NewResidents.FirstName = "";
                ResidentViewModel.NewResidents.MiddleName = "";
                ResidentViewModel.NewResidents.LastName = "";
                ResidentViewModel.NewResidents.Gender = "";
                ResidentViewModel.NewResidents.Phone = 0;
                ResidentViewModel.NewResidents.Email = "";
                ResidentViewModel.NewResidents.Age = 0;




                ResidentViewModel.NewResidents.Phone = 0;

            }
            catch (ArgumentOutOfRangeException e)
            {
                    ResidentViewModel.ApNoMessage = e.Message;
                    OnPropertyChanged(nameof(ResidentViewModel.ApNoMessage));
            }
        }

        public void DeleteResident()
        {
           // int Resident_No = ResidentViewModel.NewResidents.Resident_No;
            //new PersistenceFacade().DeleteHotel(hotel_No);
            new PersistenceFacade().DeleteApartment(ResidentViewModel.Residentss_No.Resident_No);

            //HotelViewModel.Hotels.Hotels.Add(hotel);
            var residents = new PersistenceFacade().GetResident();

          ResidentViewModel.ResidentsCatalogSingleton.Residents.Clear();
            foreach (var hotel1 in residents)
            {
                ResidentViewModel.ResidentsCatalogSingleton.Residents.Remove(hotel1);
            }

            ResidentViewModel.NewResidents.Resident_No = 0;
            ResidentViewModel.NewResidents.Apartment_No = 0;
            ResidentViewModel.NewResidents.FirstName = "";
            ResidentViewModel.NewResidents.MiddleName = "";
            ResidentViewModel.NewResidents.LastName = "";
            ResidentViewModel.NewResidents.Gender = "";
            ResidentViewModel.NewResidents.Phone = 0;
            ResidentViewModel.NewResidents.Email = "";
            ResidentViewModel.NewResidents.Age = 0;
        }
        public void UpdateResident()
        {
            Residents resident = new Residents()
            {
                Resident_No = ResidentViewModel.NewResidents.Resident_No,
                Apartment_No = ResidentViewModel.NewResidents.Apartment_No,
                FirstName = ResidentViewModel.NewResidents.FirstName,
                MiddleName = ResidentViewModel.NewResidents.MiddleName,
                LastName = ResidentViewModel.NewResidents.LastName,
                Gender = ResidentViewModel.NewResidents.Gender,
                Phone = ResidentViewModel.NewResidents.Phone,
                Email = ResidentViewModel.NewResidents.Email,
                Age = ResidentViewModel.NewResidents.Age

            };


            new PersistenceFacade().UpdateResident(resident);

            //HotelViewModel.Hotels.Hotels.Add(hotel);
            var residents = new PersistenceFacade().GetResident();

            ResidentViewModel.ResidentsCatalogSingleton.Residents.Clear();

            foreach (var hotel1 in residents)
            {
                ResidentViewModel.ResidentsCatalogSingleton.Residents.Add(hotel1);
            }

            ResidentViewModel.NewResidents.Resident_No = 0;
            ResidentViewModel.NewResidents.Apartment_No = 0;
            ResidentViewModel.NewResidents.FirstName = "";
            ResidentViewModel.NewResidents.MiddleName = "";
            ResidentViewModel.NewResidents.LastName = "";
            ResidentViewModel.NewResidents.Gender = "";
            ResidentViewModel.NewResidents.Phone = 0;
            ResidentViewModel.NewResidents.Email = "";
            ResidentViewModel.NewResidents.Age = 0;
             
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

    

