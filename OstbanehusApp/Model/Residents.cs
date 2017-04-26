using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstbanehusApp.Model
{
    class Residents
    {
        public int Resident_No { get; set; }
       // private int _apartmentno { get; set; }

        public int Apartment_No
        {
            get;
            //{ return _apartmentno; }

            set;
            //{
            //    _apartmentno = value;
            //    if (_apartmentno == null)
            //    {
            //        throw new ArgumentOutOfRangeException(nameof(Apartment_No), " Apartment No required");
            //    }

            //    //if (_apartmentno <= 30 && _apartmentno >= 1)
            //    //    _apartmentno = value;
            //    //else
            //    //{
            //    //    throw new ArgumentOutOfRangeException(nameof(Apartment_No),
            //    //        "The first name must be less than 30 characters long");
            //    //}
            //}
        }




        public string FirstName
        {
            get;
            //{
            //    return _firstname;
            //}
            set;
            //{

            //_firstname = value;
            //if (_firstname == null)
            //{
            //    throw new ArgumentOutOfRangeException(nameof(FirstName), "The first name field must be filled");
            //}

            ////if (_firstname.Length <= 30 && _firstname.Length >= 1)
            ////    _firstname = value;
            ////else
            ////{
            ////    throw new ArgumentOutOfRangeException(nameof(FirstName), "The first name must be less than 30 characters long");
            ////}
            //}
        }

      //  private string _firstname { get; set; }


        public string MiddleName { get; set; }


        public string LastName { get; set; }

        public string Gender { get; set; }

        public int Phone { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }

        public Residents(int resident_no, int apartment_no, string firstname, string middlename, string lastname, string gender, int phone, string email, int age)
        {
            Resident_No = resident_no;
            Apartment_No = apartment_no;
            FirstName = firstname;
            MiddleName = middlename;
            LastName = lastname;
            Gender = gender;
            Phone = phone;
            Email = email;
            Age = age;
        }

        public Residents()
        {

        }

        public override string ToString()
        {
            return
                string.Format(
                    "Residentno {0} Apartmentno {1} Firstname {2} Middlename {3} Lastname {4} Gender {5} Phone {6} Email{7} Age{8} ", Resident_No, Apartment_No, FirstName, MiddleName, LastName, Gender, Phone, Email, Age);
        }
    }
}
