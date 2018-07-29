using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportClient.Models
{
    public class Airplane : IModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public AirplaneType Type { get; set; }

        public DateTime CreationDate { get; set; }

        public int Lifetime { get; set; }

        public int DepartureID { get; set; }
    }
}
