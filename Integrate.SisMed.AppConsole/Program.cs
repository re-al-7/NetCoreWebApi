using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Integrate.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Integrate.SisMed.AppConsole
{
    class CUserCredentials
    {
        public string username { get; set; }
        public string password { get; set; }
    }

    class Program
    {
        private static string strBaseUri = "http://localhost:59386";
        private static string strToken = "";

        static void Main(string[] args)
        {
            //Obj para la modificacion
            EntSegUsuarios objMod = null;

            //Primero nos autenticamos
            using (HttpClient client = new HttpClient())
            {
                var objUser = new CUserCredentials();
                objUser.username = "rvera";
                objUser.password = "Desa2016";

                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("username", objUser.username),
                    new KeyValuePair<string, string>("password", objUser.password)
                });

                client.BaseAddress = new Uri(strBaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string stringData = JsonConvert.SerializeObject(objUser);
                //var contentData = new StringContent("nombre:'SegUsuarios', datos: [" + stringData +"]",Encoding.UTF8, "application/json");
                var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync
                ("/api/token",
                    formContent).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    dynamic stResult = JObject.Parse(response.Content.ReadAsStringAsync().Result);

                    strToken = stResult.access_token;
                }
            }

            //Obtener los datos
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(strBaseUri);
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", strToken);


                HttpResponseMessage response = client.GetAsync("/api/values/SegUsuarios").Result;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var stringData = response.Content.ReadAsStringAsync().Result;

                    List<EntSegUsuarios> data = JsonConvert.DeserializeObject
                        <List<EntSegUsuarios>>(stringData);

                    foreach (EntSegUsuarios objUsu in data)
                    {
                        if (objUsu.idsus == 1)
                            objMod = objUsu;
                    }
                }
            }
            //Console.ReadKey();

            //Insertar un dato
            try
            {
                var obj = new EntSegUsuarios();
                obj.idsus = 15;
                obj.loginsus = "aaaalo";
                obj.passsus = "aaaalo";
                obj.nombresus = "aaaalo";
                obj.apellidosus = "vera";
                obj.fechapasssus = DateTime.Now;


                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(strBaseUri);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", strToken);

                    string stringData = JsonConvert.SerializeObject(CUtilsApi.PostTable(obj));
                    //var contentData = new StringContent("nombre:'SegUsuarios', datos: [" + stringData +"]",Encoding.UTF8, "application/json");
                    var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = client.PostAsync
                    ("/api/values/",
                        contentData).Result;
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var strResult = response.Content.ReadAsStringAsync().Result;
                    }
                    else
                    {
                        throw new CApiExcepcion(response);
                    }
                }

            }
            catch (Exception exp)
            {
                if (exp is CApiExcepcion)
                {
                    var miExp = (CApiExcepcion) exp;
                    Console.WriteLine(miExp.error);
                    Console.WriteLine(miExp.causa);
                    Console.WriteLine(miExp.accion);
                    Console.WriteLine(miExp.comentario);
                    Console.WriteLine(miExp.origen);
                }
                else
                    Console.WriteLine(exp);
            }

            //Modificar un dato
            try
            {
                if (objMod != null)
                {
                    objMod.nombresus = "R. ALonzo";
                    using (HttpClient client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(strBaseUri);
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", strToken);

                        string stringData = JsonConvert.SerializeObject(CUtilsApi.PostTable(objMod));
                        //var contentData = new StringContent("nombre:'SegUsuarios', datos: [" + stringData +"]",Encoding.UTF8, "application/json");
                        var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");

                        HttpResponseMessage response = client.PutAsync
                        ("/api/values/" + objMod.idsus,
                            contentData).Result;
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            var strResult = response.Content.ReadAsStringAsync().Result;
                        }
                        else
                        {
                            throw new CApiExcepcion(response);
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                if (exp is CApiExcepcion)
                {
                    var miExp = (CApiExcepcion)exp;
                    Console.WriteLine(miExp.error);
                    Console.WriteLine(miExp.causa);
                    Console.WriteLine(miExp.accion);
                    Console.WriteLine(miExp.comentario);
                    Console.WriteLine(miExp.origen);
                }
                else
                    Console.WriteLine(exp);

                Console.ReadKey();
            }


            Console.ReadKey();
        }
    }
}
