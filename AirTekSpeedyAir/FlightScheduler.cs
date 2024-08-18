using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace AirTekSpeedyAir
{
    public class FlightScheduler
    {
        private List<Flight> _flights = new List<Flight>();
        private List<Order> _orders = new List<Order>();

        public void LoadFlightSchedule()
        {
            _flights.Add(new Flight(1, "YUL", "YYZ", 1, 20));
            _flights.Add(new Flight(2, "YUL", "YYC", 1, 20));
            _flights.Add(new Flight(3, "YUL", "YVR", 1, 20));
            _flights.Add(new Flight(4, "YUL", "YYZ", 2, 20));
            _flights.Add(new Flight(5, "YUL", "YYC", 2, 20));
            _flights.Add(new Flight(6, "YUL", "YVR", 2, 20));
        }

        public void LoadOrders(string jsonFilePath)
        {
            string jsonString = File.ReadAllText(jsonFilePath);
            var ordersDict = JsonSerializer.Deserialize<Dictionary<string, OrderData>>(jsonString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (ordersDict == null)
            {
                Console.WriteLine("Failed to deserialize orders data.");
                return;
            }

            foreach (var kvp in ordersDict)
            {
                _orders.Add(new Order(kvp.Key, kvp.Value.Destination));
            }
        }

        public void ScheduleOrders()
        {
            foreach (var order in _orders)
            {
                var availableFlights = _flights.Where(f => f.Arrival == order.Destination && f.CanAddOrder()).ToList();
                if (availableFlights.Any())
                {
                    var flight = availableFlights.First();
                    flight.AddOrder(order);
                }
            }
        }

        public void PrintFlightSchedule()
        {
            foreach (var flight in _flights)
            {
                Console.WriteLine($"Flight: {flight.FlightNumber}, departure: {flight.Departure}, arrival: {flight.Arrival}, day: {flight.Day}");
            }
        }

        public void PrintOrderItineraries()
        {
            foreach (var order in _orders)
            {
                if (order.ScheduledFlight != null)
                {
                    Console.WriteLine($"order: {order.OrderNumber}, flightNumber: {order.ScheduledFlight.FlightNumber}, " +
                                      $"departure: {order.ScheduledFlight.Departure}, arrival: {order.ScheduledFlight.Arrival}, " +
                                      $"day: {order.ScheduledFlight.Day}");
                }
                else
                {
                    Console.WriteLine($"order: {order.OrderNumber}, flightNumber: not scheduled");
                }
            }
        }

        private class OrderData
        {
            public string Destination { get; set; }
        }
    }
}
