using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTekSpeedyAir
{
    public class Flight
    {
        public int FlightNumber { get; }
        public string Departure { get; }
        public string Arrival { get; }
        public int Day { get; }
        public int Capacity { get; }
        public List<Order> Orders { get; } = new List<Order>();

        public Flight(int flightNumber, string departure, string arrival, int day, int capacity)
        {
            FlightNumber = flightNumber;
            Departure = departure;
            Arrival = arrival;
            Day = day;
            Capacity = capacity;
        }

        public bool CanAddOrder() => Orders.Count < Capacity;

        public void AddOrder(Order order)
        {
            if (CanAddOrder())
            {
                Orders.Add(order);
                order.ScheduleFlight(this);
            }
        }
    }
}
