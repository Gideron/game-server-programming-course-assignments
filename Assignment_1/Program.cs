using System;

namespace Assignment_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(args[0]);
            RealTimeCityBikeDataFetcher();
        }
    }

    public interface ICityBikeDataFetcher
    {
        Task<int> GetBikeCountInStation(string stationName);
    }

    class RealTimeCityBikeDataFetcher : ICityBikeDataFetcher
    {
        string api = "http://api.digitransit.fi/routing/v1/routers/hsl/bike_rental";
        System.Net.HttpClient client = new System.Net.HttpClient();
 
        static async Task Main()
        {
            try	
            {
                HttpResponseMessage response = await client.GetAsync(api);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                Console.WriteLine(responseBody);
            }  
            catch(HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");	
                Console.WriteLine("Message :{0} ",e.Message);
            }
            return 0;
        }
    }
}
