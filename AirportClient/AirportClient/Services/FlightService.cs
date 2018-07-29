using AirportClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportClient.Services
{
    public class FlightService : BaseService<Flight>
    {
        public FlightService() : base()
        {
            base.remoteURL = "http://localhost:63674/api/Flights";
        }
    }
}
