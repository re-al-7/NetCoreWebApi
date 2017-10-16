#region 
/***********************************************************************************************************
	NOMBRE:       RnSegRoles
	DESCRIPCION:
		Clase que implmenta los metodos y operaciones sobre la Tabla segroles

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
	public class RnSegRoles
	{
		private string strMiToken = "";
		
		public RnSegRoles(string strToken = "")
		{
			this.strMiToken = strToken;
		}
		
		/// <summary>
		/// Funcion que obtiene los datos de un Objeto a partir de la llave primaria
		/// </summary>
		/// <param name="intidsus">Llave Primaria</param>
		/// <returns>Objeto que coincide con la llave primaria buscada</returns>
		public EntSegRoles ObtenerObjeto(int introlsro)
		{
			var obj = new EntSegRoles();
			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri(CParametros.StrBaseUri);
				MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
				client.DefaultRequestHeaders.Accept.Add(contentType);
				if (!string.IsNullOrEmpty(strMiToken))
					client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", strMiToken);
				
				HttpResponseMessage response = client.GetAsync(CParametros.StrApiTables + EntSegRoles.StrNombreTabla + "/" + introlsro).Result;
				if (response.StatusCode == HttpStatusCode.OK)
				{
					var stringData = response.Content.ReadAsStringAsync().Result;
					obj = JsonConvert.DeserializeObject<EntSegRoles>(stringData);
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
		public List<EntSegRoles> ObtenerLista()
		{
			var data = new List<EntSegRoles>();
			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri(CParametros.StrBaseUri);
				MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
				client.DefaultRequestHeaders.Accept.Add(contentType);
				if (!string.IsNullOrEmpty(strMiToken))
					client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", strMiToken);
				
				HttpResponseMessage response = client.GetAsync(CParametros.StrApiTables + EntSegRoles.StrNombreTabla).Result;
				if (response.StatusCode == HttpStatusCode.OK)
				{
					var stringData = response.Content.ReadAsStringAsync().Result;
					data = JsonConvert.DeserializeObject <List<EntSegRoles>>(stringData);
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
		public bool Insert(EntSegRoles obj, bool bValidar = true)
		{
			bool bProcede = false;
			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri(CParametros.StrBaseUri);
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				if (!string.IsNullOrEmpty(strMiToken))
					client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", strMiToken);
				
				string stringData = JsonConvert.SerializeObject(obj.CreateApiObject());
				var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
				HttpResponseMessage response = client.PostAsync(CParametros.StrApiTables,contentData).Result;
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
		public bool Update(EntSegRoles obj, bool bValidar = true)
		{
			bool bProcede = false;
			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri(CParametros.StrBaseUri);
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				if (!string.IsNullOrEmpty(strMiToken))
					client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", strMiToken);
				
				string stringData = JsonConvert.SerializeObject(obj.CreateApiObject());
				var contentData = new StringContent(stringData, Encoding.UTF8, "application/json");
				HttpResponseMessage response = client.PutAsync(CParametros.StrApiTables,contentData).Result;
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
		public bool Delete(EntSegRoles obj, bool bValidar = true)
		{
			bool bProcede = false;
			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri(CParametros.StrBaseUri);
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				if (!string.IsNullOrEmpty(strMiToken))
					client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", strMiToken);
				
				HttpResponseMessage response = client.DeleteAsync(CParametros.StrApiTables+ EntSegRoles.StrNombreTabla +"/" + obj.rolsro).Result;
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

