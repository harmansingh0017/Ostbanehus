using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OstbanehusApp.Persistency;

namespace OstbanehusApp.Model
{
    class ResidentsCatalogSingleton
    {
        private static ResidentsCatalogSingleton instance = new ResidentsCatalogSingleton();

        public static ResidentsCatalogSingleton Instance
        {
            get { return instance; }
        }

        public ObservableCollection<Residents> Residents { get; set; }

        private ResidentsCatalogSingleton()
        {
            // Apartments = new ObservableCollection<Apartments>();

            Residents = new ObservableCollection<Residents>(new PersistenceFacade().GetResident());
        }

        public void Add(int Resident_No, int Apartment_No, string FirstName, string MiddleName, string LastName, string Gender, int Phone, string Email, int Age)
        {
            Residents.Add(new Residents(Resident_No, Apartment_No, FirstName, MiddleName, LastName, Gender, Phone, Email, Age));
        }

        public void Removeevent(int selectedindex)
        {
            Residents.RemoveAt(selectedindex);
        }
    }
}
