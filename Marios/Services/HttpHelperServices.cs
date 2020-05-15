using System;
using System.Collections.Generic;
using System.Text;


namespace Marios.Services
{
    using Newtonsoft.Json;
    using System.Net.Http;
    using System.Threading.Tasks;
    class HttpHelperServices<T>//esto quiere decir que va a recibir un generico de mi modelo de datos
    {
        //genero mi conexion httpclient
        public async Task<T> GetRestServiceDataAsync(string serviceAddress)//direccion
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(serviceAddress);
            var response = await client.GetAsync(client.BaseAddress);
            response.EnsureSuccessStatusCode();
            var jsonResult =  await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(jsonResult);
            return result;
        }  
    }
}
