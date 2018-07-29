using System;
using System.Collections.Generic;

namespace AirportClient.Models
{
    public class Flight : IModel
    {
       
        public int Id { get; set; }

        public string Number { get; set; }

        public string Departure { get; set; }

        public DateTime DepartureTime { get; set; }

        public string Destination { get; set; }

        public DateTime ArrivalTime { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
