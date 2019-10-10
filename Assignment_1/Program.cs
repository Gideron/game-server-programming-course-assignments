using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Assignment_1
{
    public interface ICityBikeDataFetcher
    {
        Task<int> GetBikeCountInStation(string stationName);
    }

    class Program
    {
        static void Main(string[] args)
        {
            string input = args[0].ToString();
            var a = new RealTimeCityBikeDataFetcher();
            var bikeCount = a.GetBikeCountInStation(input);
            //if(bikeCount.IsDigit)
                Console.WriteLine("Station " + input + " has " + bikeCount.Result + " bikes available");
        }
    }

    class RealTimeCityBikeDataFetcher : ICityBikeDataFetcher
    {
        //private static BikeRentalStationList stationList = new BikeRentalStationList();
        static async Task Main()
        {
            /*try	
            {
                string api = "http://api.digitransit.fi/routing/v1/routers/hsl/bike_rental";
                System.Net.HttpClient client = new System.Net.HttpClient();
                HttpResponseMessage response = await client.GetAsync(api);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine("---responseBody---");
                Console.WriteLine(responseBody);
                Console.WriteLine("------");

                //convert response to BikeRentalStationList
                stationList = JsonConvert.DeserializeObject<BikeRentalStationList>(responseBody);
                
            }  
            catch(HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");	
                Console.WriteLine("Message :{0} ", e.Message);
            }*/
        }

        public async Task<int> GetBikeCountInStation(string stationName)
        {
            if (stationName.Any(c => char.IsDigit(c)))
                throw new NotImplementedException(String.Format("Station name '{0}' should not contain numbers", stationName));
            
            try	
            {
                string api = "http://api.digitransit.fi/routing/v1/routers/hsl/bike_rental";
                System.Net.HttpClient client = new System.Net.HttpClient();
                HttpResponseMessage response = await client.GetAsync(api);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                //string responseBody = await client.GetStringAsync(api);
                Console.WriteLine("---responseBody---");
                Console.WriteLine(responseBody);
                Console.WriteLine("------");

                //convert response to BikeRentalStationList
                BikeRentalStationList stationList = JsonConvert.DeserializeObject<BikeRentalStationList>(responseBody);

                bool found = false;
                foreach(Station s in stationList.stations){
                    Console.WriteLine("- Station " + s.name);
                    if(s.name.Equals(stationName)){
                        found = true;
                        Console.WriteLine("Station " + stationName + " has " + s.bikesAvailable + " bikes available");
                        return s.bikesAvailable;
                    }
                }
                if(!found)
                    throw new NotImplementedException(String.Format("Could not find station {0}", stationName));
                //throw NotFoundException(String.Format("Could not find station {0}", stationName));
            }  
            catch(HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");	
                Console.WriteLine("Message :{0} ", e.Message);
                throw new NotImplementedException("Could not get stations");
            }
            throw new NotImplementedException(String.Format("Something happened while fetching station {0}", stationName));
        }
    }

    public class Station
    {
        
        public string id { get; set; }
        public string name { get; set; }
        public double x { get; set; }
        public double y { get; set; }
        public int bikesAvailable { get; set; }
        public int spacesAvailable { get; set; }
        public bool allowDropoff { get; set; }
        public bool isFloatingBike { get; set; }
        public bool isCarStation { get; set; }
        public string state { get; set; }
        public List<string> networks { get; set; }
        public bool realTimeData { get; set; }
    }
    class BikeRentalStationList
    {
        //public string Stations { get; set; }
        public List<Station> stations { get; set; }
    }
}
