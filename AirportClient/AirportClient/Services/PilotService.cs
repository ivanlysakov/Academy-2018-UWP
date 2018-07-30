using AirportClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace AirportClient.Services
{
    public class PilotService : BaseService<Pilot>
    {
  
        public PilotService() : base()
       {
            base.remoteURL= "http://localhost:63674/api/Pilots";
        }

    }
}
