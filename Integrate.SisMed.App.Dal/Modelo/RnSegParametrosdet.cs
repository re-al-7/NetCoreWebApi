#region 
/***********************************************************************************************************
	NOMBRE:       RnSegParametrosdet
	DESCRIPCION:
		Clase que implmenta los metodos y operaciones sobre la Tabla segparametrosdet

	REVISIONES:
		Ver        FECHA       Autor            Descripcion 
		---------  ----------  ---------------  ------------------------------------
		1.0        13/10/2017  R Alonzo Vera A  Creacion 

*************************************************************************************************************/
#endregion



#region
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Integrate.SisMed.App.Dal; 
using Integrate.SisMed.App.Dal.Entidades;
#endregion

namespace Integrate.SisMed.App.Dal.Modelo
{
	public class RnSegParametrosdet
	{
		private string strMiToken = "";
		
		public RnSegParametrosdet(string strToken = "")
		{
			this.strMiToken = strToken;
		}
		
		/// <summary>
		/// Funcion que obtiene los datos de un Objeto a partir de la llave primaria
		/// </summary>
		/// <param name="intidsus">Llave Primaria</param>
		/// <returns>Objeto que coincide con la llave primaria buscada</returns>
		public EntSegParametrosdet ObtenerObjeto(String Stringsiglaspa, int intcodigospd)
		{
			var obj = new EntSegParametrosdet();
			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri(CParametros.strBaseUri);
				MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
				client.DefaultRequestHeaders.Accept.Add(contentType);
				if (!string.IsNullOrEmpty(strMiToken))
					client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", strMiToken);
				
				HttpResponseMessage response = client.GetAsync(CParametros.strApiTables + EntSegParametrosdet.StrNombreTabla + "/" + Stringsiglaspa+ "/" + intcodigospd).Result;
				if (response.StatusCode == HttpStatusCode.OK)
				{
					var stringData = response.Content.ReadAsStringAsync().Result;
					obj = JsonConvert.DeserializeObject<EntSegParametrosdet>(stringData);
				}
				else
					throw new CApiExcepcion(response);
			}
			return obj;
		}
		
		/// <summary>
		/// Funcion que obtiene un conjunto de Objetos
		/// </summary>
		/// <returns>Valor del Tipo System.Collections.Generic.List que cumple con los filtros de los parametros </returns>
		public List<EntSegParametrosdet> ObtenerLista()
		{
			var data = new List<EntSegParametrosdet>();
			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri(CParametros.strBaseUri);
				MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
				client.DefaultRequestHeaders.Accept.Add(contentType);
				if (!string.IsNullOrEmpty(strMiToken))
					client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", strMiToken);
				
				HttpResponseMessage response = client.GetAsync(CParametros.strApiTables + EntSegParametrosdet.StrNombreTabla).Result;
				if (response.StatusCode == HttpStatusCode.OK)
				{
					var stringData = response.Content.ReadAsStringAsync().Result;
					data = JsonConvert.DeserializeObject <List<EntSegParametrosdet>>(stringData);
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
		public bool Insert(EntSegParametrosdet obj, bool bValidar = true)
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
				HttpResponseMessage response = client.PostAsync(CParametros.strApiTables,contentData).Result;
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
		/// Funcion que actualiza un registro en la tabla a partir de un Objeto
		/// </summary>
		/// <param name="obj">Clase desde la que se van a actualizar los valores a la tabla</param>
		/// <param name="bValidar">Valor que indica si se debe realizar la validación en base a los DataAnnotation</param>
		/// <returns>Valor TRUE or FALSE que indica el exito de la operacion</returns>
		public bool Update(EntSegParametrosdet obj, bool bValidar = true)
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
				HttpResponseMessage response = client.PutAsync(CParametros.strApiTables,contentData).Result;
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
		/// Funcion que elimina un registro en la tabla a partir de un Objeto
		/// </summary>
		/// <param name="obj">Clase desde la que se van a eliminar los valores a la tabla</param>
		/// <param name="bValidar">Valor que indica si se debe realizar la validación en base a los DataAnnotation</param>
		/// <returns>Valor TRUE or FALSE que indica el exito de la operacion</returns>
		public bool Delete(EntSegParametrosdet obj, bool bValidar = true)
		{
			bool bProcede = false;
			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri(CParametros.strBaseUri);
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				if (!string.IsNullOrEmpty(strMiToken))
					client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", strMiToken);
				
				HttpResponseMessage response = client.DeleteAsync(CParametros.strApiTables+ EntSegParametrosdet.StrNombreTabla +"/" + obj.siglaspa+ "/" + obj.codigospd).Result;
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

