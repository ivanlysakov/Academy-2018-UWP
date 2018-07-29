using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportClient.Models
{
    public class Crew : IModel
    {
        
        public int Id { get; set; }

        public int CrewNumber { get; set; }

        public Pilot Pilot { get; set; }

        public ICollection<Hostess> Hostesses { get; set; }

        public int DepartureID { get; set; }

        Departure Departure { get; set; }

    }
}
