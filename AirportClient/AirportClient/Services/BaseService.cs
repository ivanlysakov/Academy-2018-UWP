﻿using AirportClient.Models;
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

        public async Task<List<TEntity>> Load()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var content = await client.GetStringAsync($"{remoteURL}").ConfigureAwait(false);
                    return JsonConvert.DeserializeObject<List<TEntity>>(content);
                }
            }
            catch (Exception)
            {
                
             throw new ArgumentNullException();

            }
        }
 
        public async Task Create(TEntity entity)
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
                        var response = await client.PostAsync(new Uri(remoteURL), contentToPost).ConfigureAwait(false);
                        var dataReceived = response.EnsureSuccessStatusCode();
                        var dRec = new DataContractJsonSerializer(typeof(TEntity));
                        var str = await dataReceived.Content.ReadAsStreamAsync();
                        var RecData = dRec.ReadObject(str) as TEntity;

                    }
                }
            }
            catch (Exception)
            {


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
                        var response = await client.PutAsync(new Uri(remoteURL + "/" + entity.Id), contentToPost).ConfigureAwait(false);

                    }
                }
            }
            catch (Exception)
            {


            }



        }

        public async Task Delete(int id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.DeleteAsync(new Uri(remoteURL + "/" + id)).ConfigureAwait(false);
                    response.EnsureSuccessStatusCode();
                }
            }
            catch (Exception)
            {


            }


        }
                
    }
}
