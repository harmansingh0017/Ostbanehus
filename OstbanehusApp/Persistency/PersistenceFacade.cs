using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Newtonsoft.Json;
using OstbanehusApp.Model;

namespace OstbanehusApp.Persistency
{
    class PersistenceFacade
    {
        const string ServerUrl = "http://localhost:1820";
        HttpClientHandler handler;

        public PersistenceFacade()
        {
            handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
        }

        //public List<Apartments> GetApartment()
        //{
        //    using (var client = new HttpClient(handler))
        //    {
        //        client.BaseAddress = new Uri(ServerUrl);
        //        client.DefaultRequestHeaders.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        try
        //        {
        //            var response = client.GetAsync("api/Apartments").Result;

        //            if (response.IsSuccessStatusCode)
        //            {
        //                var apartmentList = response.Content.ReadAsAsync<IEnumerable<Apartments>>().Result;
        //                return apartmentList.ToList();
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            // Because this call is not awaited, execution of the current method continues before the call is completed
        //            new MessageDialog(ex.Message).ShowAsync();
        //            // Because this call is not awaited, execution of the current method continues before the call is completed
        //        }
        //        return null;
        //    }
        //}
        public List<Residents> GetResident()
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync("api/Residents").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var residentList = response.Content.ReadAsAsync<IEnumerable<Residents>>().Result;
                        return residentList.ToList();
                    }

                }
                catch (Exception ex)
                {
                    // Because this call is not awaited, execution of the current method continues before the call is completed
                    new MessageDialog(ex.Message).ShowAsync();
                    // Because this call is not awaited, execution of the current method continues before the call is completed
                }
                return null;
            }
        }
        public void PostResident(Residents resident)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    string postBody = JsonConvert.SerializeObject(resident);
                    var response = client.PostAsync("api/Residents", new StringContent(postBody, Encoding.UTF8, "application/json")).Result;
                }
                catch (Exception ex)
                {
                    // Because this call is not awaited, execution of the current method continues before the call is completed
                    new MessageDialog(ex.Message).ShowAsync();
                    // Because this call is not awaited, execution of the current method continues before the call is completed
                }
            }

        }
        public void DeleteApartment(int Resident_No)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    string deleteUrl = "api/Residents/" + Resident_No;
                    var response = client.DeleteAsync(deleteUrl).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        new MessageDialog("Succcesfull delete");
                    }
                    else
                    {
                        new MessageDialog("Someting went wrong, hotel not deleted");
                    }
                }
                catch (Exception ex)
                {
                    new MessageDialog("Someting went wrong, hotel not deleted");
                }
            }
        }
        public void UpdateResident(Residents residentToUpdate)
        {
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    //we have to serialize the hotel object into json format
                    string jsonHotelToUpdate = JsonConvert.SerializeObject(residentToUpdate);

                    //Create the content we want to send with the Http put request
                    StringContent content = new StringContent(jsonHotelToUpdate, Encoding.UTF8, "Application/json");

                    //Using a Http Put Request we can update the Hotel number 
                    var updateResponse = client.PutAsync("api/Residents/" + residentToUpdate.Resident_No, content).Result;
                    var result = updateResponse.StatusCode;

                    //var response = client.GetAsync("api/Hotels").Result;

                    //if (response.IsSuccessStatusCode)
                    //{
                    //    var hotelList = response.Content.ReadAsAsync<IEnumerable<Hotel>>().Result;
                    //    return hotelList.ToList();
                    //}
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }
    }
}
