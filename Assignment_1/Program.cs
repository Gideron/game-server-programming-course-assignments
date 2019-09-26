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
            if (input.Any(c => char.IsDigit(c)))
            {
                a.GetBikeCountInStation(input);
            }
            
            

        }
    }

    class RealTimeCityBikeDataFetcher : ICityBikeDataFetcher
    {
        

        public Task<int> GetBikeCountInStation(string stationName)
        {
            
            throw new NotImplementedException(String.Format("Invalid argument: {0} is not a number", stationName));
        }
    }
}
