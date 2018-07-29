using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportClient.Models
{
    public class Hostess : IModel
    {
        
        public int Id { get; set; }
       
        public string FirstName { get; set; }

        public string Lastname { get; set; }

        public int CrewID { get; set; }

        public Crew Crew { get; set; }

        public DateTime BirthDay { get; set; }

    }
}
