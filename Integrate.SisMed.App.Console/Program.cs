using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Integrate.SisMed.App.Dal;
using Integrate.SisMed.App.Dal.Entidades;
using Integrate.SisMed.App.Dal.Modelo;
using Newtonsoft.Json.Linq;

namespace Integrate.SisMed.App.Console
{
    class Program
    {
        private static string strBaseUri = "http://localhost:59386";
        private static string strToken = "";

        static void Main(string[] args)
        {
            //Primero nos autenticamos
            using (HttpClient client = new HttpClient())
            {
                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("username", "deferarib"),
                    new KeyValuePair<string, string>("password", "Desa2016")
                });

                client.BaseAddress = new Uri(strBaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

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
            try
            {
                //Obtenemos lista
                var rn = new RnSegMensajeserror(strToken);
                List<EntSegMensajeserror> lista = rn.ObtenerLista();
                System.Console.WriteLine("Lista: " + lista.Count);
                System.Console.WriteLine("-------------------------------");

                //EntSegMensajeserror obj = rn.ObtenerObjeto(1);
                //Console.WriteLine("Objeto: " + obj.accionsme);
                //Console.WriteLine("-------------------------------");

                //obj.apiestadosme = "R. Alonzo";
                //rn.Update(obj);
            }
            catch (Exception exp)
            {
                if (exp is CApiExcepcion)
                {
                    var miExp = (CApiExcepcion)exp;
                    System.Console.WriteLine(miExp.error);
                    System.Console.WriteLine(miExp.causa);
                    System.Console.WriteLine(miExp.accion);
                    System.Console.WriteLine(miExp.comentario);
                    System.Console.WriteLine(miExp.origen);
                }
                else
                    System.Console.WriteLine(exp);                
            }


            System.Console.ReadKey();
        }
    }
}
