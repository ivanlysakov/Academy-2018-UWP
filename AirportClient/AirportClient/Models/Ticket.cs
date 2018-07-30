using AirportClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportClient.Models
{
    public class Ticket : IModel
    {
        public int Id { get; set; }
                
        public decimal Price { get; set; }

        public string FlightNumber { get; set; }

        public int FlightId { get; set; }

        public Flight Flight { get; set; }
    }
}
