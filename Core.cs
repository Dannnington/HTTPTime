using System;
using System.Threading.Tasks;
using HTTPFetch;

namespace HTTPTime
{
    class Core
    {

        static void GetASCII()
        {
            
        }

        private static async Task Main(string[] args)
        {
            FetchResponse TimeAPIResponse = (await Fetch.Get<Types.DateTimeAPIObject>("https://worldtimeapi.org/api/ip"));
            FetchResponse IPInfoResponse = (await Fetch.Get<Types.IPInfoObject>("https://ipinfo.io"));
               
            if (TimeAPIResponse.StatusCode != 200 || IPInfoResponse.StatusCode != 200) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There was an error with the request to the APIs used by HTTPTime. Try again later, maybe?");
                return;
            }

            DateTime TimeAPIDate = DateTime.Parse(TimeAPIResponse.BodyAsObject.datetime);

            if (TimeAPIDate.Hour < 12) {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(ASCIIArt.TimeOfDay.Morning());
                Console.WriteLine("Good morning!");
            } else if (TimeAPIDate.Hour < 18) {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(ASCIIArt.TimeOfDay.Noon());
                Console.WriteLine("Good afternoon!");
            } else {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(ASCIIArt.TimeOfDay.Evening());
                Console.WriteLine("Good evening!");
            }
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The time is " + TimeAPIDate.ToString("HH:mm:ss") + ", on " + TimeAPIDate.ToString("dd MMMM yyyy") + ".");
            Console.WriteLine("It is day " + TimeAPIResponse.BodyAsObject.day_of_year + " of this year.");
            Console.Write("You are in the ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(TimeAPIResponse.BodyAsObject.abbreviation);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" timezone.\n");
            Console.ResetColor();
            return;
        }
    }
}