using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTekSpeedyAir
{
    public class Order
    {
        public string OrderNumber { get; }
        public string Destination { get; }
        public Flight? ScheduledFlight { get; private set; }

        public Order(string orderNumber, string destination)
        {
            OrderNumber = orderNumber;
            Destination = destination;
        }

        public void ScheduleFlight(Flight flight)
        {
            ScheduledFlight = flight;
        }
    }
}
