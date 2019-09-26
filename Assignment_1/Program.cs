using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Linq;


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
            string input = Console.ReadLine();
            var a = new RealTimeCityBikeDataFetcher();
            if (!input.Any(c => char.IsDigit(c)))
            {
                a.GetBikeCountInStation(input);
            } else
            {
                throw new NotImplementedException(String.Format("Invalid argument: {0} contains a number", stationName));
            }
        }
    }

    class RealTimeCityBikeDataFetcher : ICityBikeDataFetcher
    {
        static async Task Main()
        {
            try	
            {
                string api = "http://api.digitransit.fi/routing/v1/routers/hsl/bike_rental";
                System.Net.HttpClient client = new System.Net.HttpClient();
                HttpResponseMessage response = await client.GetAsync(api);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                //convert response to BikeRentalStationList
                BikeRentalStationList stationList = JsonConvert.DeserializeObject<BikeRentalStationList>(responseBody);
                Console.WriteLine(stationList.Stations);
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
            throw new NotImplementedException(String.Format("Could not find station {0}", stationName));
        }
    }

    class BikeRentalStationList
    {
        public string Stations { get; set; }
    }
}
