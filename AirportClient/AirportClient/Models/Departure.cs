using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportClient.Models
{
    public class Departure : IModel
    {
        public int Id { get; set; }
               
        public string FlightNumber { get; set; }

        public DateTime Time { get; set; }

        public Crew Crew { get; set; }

        public Airplane Airplane { get; set; }

    }
}

