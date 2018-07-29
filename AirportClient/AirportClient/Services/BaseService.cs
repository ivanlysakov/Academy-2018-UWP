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
    public abstract class BaseService<TEntity> where TEntity : class, IModel
    {

        public string remoteURL;
               
        public List<TEntity> Load()
        {
            using (var client = new HttpClient())
            {
                var content = client.GetStringAsync($"{remoteURL}").Result;
                return JsonConvert.DeserializeObject<List<TEntity>>(content);

            }

        }


        public async Task<ObservableCollection<TEntity>> LoadPilots2()
        {
            using (HttpClient client = new HttpClient())
            {


                var Response = await client.GetAsync(new Uri(remoteURL)).ConfigureAwait(false); ;
                using (var responseStream = await Response.Content.ReadAsStreamAsync())
                {
                    var List = new DataContractJsonSerializer(typeof(List<TEntity>));
                    return new ObservableCollection<TEntity>((IEnumerable<TEntity>)List.ReadObject(responseStream));
                }
            }
        }




        public async Task Create(TEntity entity)
        {

            using (var client = new HttpClient())
            {
                using (var memStream = new MemoryStream())
                {
                    var data = new DataContractJsonSerializer(typeof(TEntity));
                    data.WriteObject(memStream, entity);
                    memStream.Position = 0;
                    var contentToPost = new StreamContent(memStream);
                    contentToPost.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    var response = await client.PostAsync(new Uri(remoteURL), contentToPost);
                    var dataReceived = response.EnsureSuccessStatusCode();
                    var dRec = new DataContractJsonSerializer(typeof(TEntity));
                    var str = await dataReceived.Content.ReadAsStreamAsync();
                    var RecData = dRec.ReadObject(str) as TEntity;

                }
            }

        }



        public async Task Update(TEntity entity)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    using (var memStream = new MemoryStream())
                    {
                        var data = new DataContractJsonSerializer(typeof(TEntity));
                        data.WriteObject(memStream, entity);
                        memStream.Position = 0;
                        var contentToPost = new StreamContent(memStream);
                        contentToPost.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                        var response = await client.PutAsync(new Uri(remoteURL + "/" + entity.Id), contentToPost);

                    }
                }
            }
            catch (Exception)
            {


            }



        }


        public async Task delete(int id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.DeleteAsync(new Uri(remoteURL + "/" + id));
                    response.EnsureSuccessStatusCode();
                }
            }
            catch (Exception)
            {


            }


        }





    }
}
