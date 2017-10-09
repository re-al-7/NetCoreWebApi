using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Integrate.SisMed.AppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Obtener los datos
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:59386");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync("/api/values/SegUsuarios").Result;
                var stringData = response.Content.ReadAsStringAsync().Result;

                List<EntSegUsuarios> data = JsonConvert.DeserializeObject
                    <List<EntSegUsuarios>>(stringData);                
            }
            Console.ReadKey();
        }
    }
}
