using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Linq;
using Newtonsoft.Json;

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
            if (!input.Any(c => char.IsDigit(c)))
            {
                a.GetBikeCountInStation(input);
            } else
            {
                throw new NotImplementedException(String.Format("Invalid argument: {0} contains a number", input));
            }
        }
    }

    class RealTimeCityBikeDataFetcher : ICityBikeDataFetcher
    {
        private static BikeRentalStationList stationList = new BikeRentalStationList();
        static async Task Main()
        {
            try	
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
            }
        }

        public Task<int> GetBikeCountInStation(string stationName)
        {
            //get bikes from station using BikeRentalStationList
            Console.WriteLine("---stationList.Stations---");
            Console.WriteLine(stationList.Stations);
            Console.WriteLine("------");
            throw new NotImplementedException(String.Format("Could not find station {0}", stationName));
        }
    }

    class BikeRentalStationList
    {
        public string Stations { get; set; }
    }
}
