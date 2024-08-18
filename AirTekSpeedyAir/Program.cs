using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTekSpeedyAir
{
    class Program
    {
        static void Main(string[] args)
        {
            var scheduler = new FlightScheduler();

            Console.WriteLine("User Story #1: Loading and displaying flight schedule");
            scheduler.LoadFlightSchedule();
            scheduler.PrintFlightSchedule();

            Console.WriteLine("\nPress any key to continue to User Story #2...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("User Story #2: Loading orders and generating flight itineraries");
            scheduler.LoadOrders("coding-assigment-orders.json");
            scheduler.ScheduleOrders();
            scheduler.PrintOrderItineraries();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
