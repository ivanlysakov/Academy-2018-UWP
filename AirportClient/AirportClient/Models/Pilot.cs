using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportClient.Models
{
    public class Pilot : IModel
    {

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string Lastname { get; set; }

        public DateTime BirthDay { get; set; }

        public int Experience { get; set; }

        public int CrewID { get; set; }

        public string FullName
        {
            get { return this.FirstName + " " + this.Lastname; }
        }
    }
}
