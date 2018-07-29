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
        
        //public List<Pilot> LoadPilots()
        //{
        //    using (var client = new HttpClient())
        //    {
        //        var content = client.GetStringAsync($"{remoteURL}").Result;
        //        return JsonConvert.DeserializeObject<List<Pilot>>(content);

        //    }

        //}


        //public async Task<ObservableCollection<Pilot>> LoadPilots2()
        //{
        //    using (HttpClient client = new HttpClient())
        //    {


        //        var Response = await client.GetAsync(new Uri(remoteURL)).ConfigureAwait(false); ;
        //        using (var responseStream = await Response.Content.ReadAsStreamAsync())
        //        {
        //            var OrdersList = new DataContractJsonSerializer(typeof(List<Pilot>));
        //            return new ObservableCollection<Pilot>((IEnumerable<Pilot>)OrdersList.ReadObject(responseStream));
        //        }
        //    }
        //}




        //public async Task Create(Pilot p)
        //{

        //    using (var client = new HttpClient())
        //    {
        //        using (var memStream = new MemoryStream())
        //        {
        //            var data = new DataContractJsonSerializer(typeof(Pilot));
        //            data.WriteObject(memStream, p);
        //            memStream.Position = 0;
        //            var contentToPost = new StreamContent(memStream);
        //            contentToPost.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
        //            var response = await client.PostAsync(new Uri(remoteURL), contentToPost);
        //            var dataReceived = response.EnsureSuccessStatusCode();
        //            var dRec = new DataContractJsonSerializer(typeof(Pilot));
        //            var str = await dataReceived.Content.ReadAsStreamAsync();
        //            var RecData = dRec.ReadObject(str) as Pilot;

        //        }
        //    }

        //}



        //public async Task Update(Pilot p)
        //{
        //    try
        //    {
        //        using (var client = new HttpClient())
        //        {
        //            using (var memStream = new MemoryStream())
        //            {
        //                var data = new DataContractJsonSerializer(typeof(Pilot));
        //                data.WriteObject(memStream, p);
        //                memStream.Position = 0;
        //                var contentToPost = new StreamContent(memStream);
        //                contentToPost.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
        //                var response = await client.PutAsync(new Uri(remoteURL + "/" + p.Id), contentToPost);

        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {


        //    }



        //}


        //public async Task delete(int id)
        //{
        //    try
        //    {
        //        using (var client = new HttpClient())
        //        {
        //            var response = await client.DeleteAsync(new Uri(remoteURL + "/" + id));
        //            response.EnsureSuccessStatusCode();
        //        }
        //    }
        //    catch (Exception)
        //    {


        //    }


        //}
    }
}
