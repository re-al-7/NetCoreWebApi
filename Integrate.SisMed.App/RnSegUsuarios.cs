using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace Integrate.SisMed.App
{
    public class RnSegUsuarios
    {
        private string strMiToken = "";

        public RnSegUsuarios(string strToken = "")
        {
            this.strMiToken = strToken;
        }

        /// <summary>
        /// Funcion que obtiene los datos de una Clase EntSegUsuarios a partir de la llave primaria
        /// </summary>
        /// <param name="intidsus">Llave Primaria</param>
        /// <returns>Objeto que coincide con la llave primaria buscada</returns>
        public EntSegUsuarios ObtenerObjeto(int intidsus)
        {
            var obj = new EntSegUsuarios();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(CParametros.strBaseUri);
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                if (!string.IsNullOrEmpty(strMiToken))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", strMiToken);
                
                HttpResponseMessage response = client.GetAsync("/api/values/"+ EntSegUsuarios.StrNombreTabla +"/" + intidsus).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var stringData = response.Content.ReadAsStringAsync().Result;
                    obj = JsonConvert.DeserializeObject<EntSegUsuarios>(stringData);                    
                }
                else
                    throw new CApiExcepcion(response);
            }

            return obj;
        }

        /// <summary>
        /// Funcion que obtiene un conjunto de datos de una Clase EntSegUsuarios a partir de condiciones WHERE
        /// </summary>
        /// <returns>Valor del Tipo System.Collections.Generic.List que cumple con los filtros de los parametros </returns>
        public List<EntSegUsuarios> ObtenerLista()
        {
            var data = new List<EntSegUsuarios>();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(CParametros.strBaseUri);
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                if (!string.IsNullOrEmpty(strMiToken))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", strMiToken);

                HttpResponseMessage response = client.GetAsync("/api/values/SegUsuarios").Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var stringData = response.Content.ReadAsStringAsync().Result;
                    data = JsonConvert.DeserializeObject <List<EntSegUsuarios>>(stringData);
                }
                else
                    throw new CApiExcepcion(response);
            }

            return data;
        }

        /// <summary>
        /// Funcion que inserta un nuevo registro en la tabla segusuarios a partir de un Objeto
        /// </summary>
        /// <param name="obj">Clase desde la que se van a insertar los valores a la tabla</param>
        /// <param name="bValidar">Valor que indica si se debe realizar la validación en base a los DataAnnotation</param>
        /// <returns>Valor TRUE or FALSE que indica el exito de la operacion</returns>
        public bool Insert(EntSegUsuarios obj, bool bValidar = true)
        {
            bool bProcede = false;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(CParametros.strBaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (!string.IsNullOrEmpty(strMiToken))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", strMiToken);

                string stringData = JsonConvert.SerializeObject(obj.CreateApiObject());
                var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync("/api/values/",contentData).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var strResult = response.Content.ReadAsStringAsync().Result;
                    bProcede = true;
                }
                else
                    throw new CApiExcepcion(response);
            }
            return bProcede;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="bValidar"></param>
        /// <returns></returns>
        public bool Update(EntSegUsuarios obj, bool bValidar = true)
        {
            bool bProcede = false;
            if (bValidar)
                if (!obj.IsValid())
                    throw new Exception(obj.ValidationErrorsString());

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(CParametros.strBaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (!string.IsNullOrEmpty(strMiToken))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", strMiToken);

                string stringData = JsonConvert.SerializeObject(obj.CreateApiObject());
                //var contentData = new StringContent("nombre:'SegUsuarios', datos: [" + stringData +"]",Encoding.UTF8, "application/json");
                var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PutAsync
                ("/api/values/" + obj.idsus,
                    contentData).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var strResult = response.Content.ReadAsStringAsync().Result;
                    bProcede = true;
                }
                else
                    throw new CApiExcepcion(response);
            }
            return bProcede;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="bValidar"></param>
        /// <returns></returns>
        public bool Delete(EntSegUsuarios obj, bool bValidar = true)
        {
            bool bProcede = false;
            if (bValidar)
                if (!obj.IsValid())
                    throw new Exception(obj.ValidationErrorsString());

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(CParametros.strBaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (!string.IsNullOrEmpty(strMiToken))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", strMiToken);

                HttpResponseMessage response = client.DeleteAsync("/api/values/"+ EntSegUsuarios.StrNombreTabla +"/" + obj.idsus).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var strResult = response.Content.ReadAsStringAsync().Result;
                    bProcede = true;
                }
                else
                    throw new CApiExcepcion(response);
            }
            return bProcede;
        }
    }
}
