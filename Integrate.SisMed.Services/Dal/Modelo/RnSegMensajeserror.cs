#region 
/***********************************************************************************************************
	NOMBRE:       RnSegMensajeserror
	DESCRIPCION:
		Clase que implmenta los metodos y operaciones sobre la Tabla segmensajeserror

	REVISIONES:
		Ver        FECHA       Autor            Descripcion 
		---------  ----------  ---------------  ------------------------------------
		1.0        09/10/2017  R Alonzo Vera A  Creacion 

*************************************************************************************************************/
#endregion



#region
using System;
using System.Globalization;
using System.Threading;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using Integrate.SisMed.Services.Dal; 
using Integrate.SisMed.Services.Conn; 
using Integrate.SisMed.BusinessObjects.Entidades;
using Integrate.SisMed.Services.Dal.Interface;

#endregion

namespace Integrate.SisMed.Services.Dal.Modelo
{
	public class RnSegMensajeserror: ISegMensajeserror
	{
		//Debe implementar la Interface (Alt + Shift + F10)

		#region ISegMensajeserror Members

		#region Reflection

		/// <summary>
		/// Metodo que devuelve el Script SQL de la Tabla
		/// </summary>
		/// <returns>Script SQL</returns>
		public string GetTableScript()
		{
			TableClass tabla = new TableClass(typeof(EntSegMensajeserror));
			return tabla.CreateTableScript();
		}
		
		/// <summary>
		/// Metodo para castear Dinamicamente un Tipo
		/// </summary>
		/// <param name="valor">Tipo a ser casteado</param>
		/// <param name="myField">Enum de la columna</param>
		/// <returns>Devuelve un objeto del Tipo de la columna especificada en el Enum</returns>
		public dynamic GetColumnType(object valor, EntSegMensajeserror.Fields myField)
		{
			if (DBNull.Value.Equals(valor)) 
				return null;
			Type destino = typeof(EntSegMensajeserror).GetProperty(myField.ToString()).PropertyType;
			var miTipo = Nullable.GetUnderlyingType(destino) ?? destino;
		    try
		    {
		        TypeConverter tc = TypeDescriptor.GetConverter(miTipo);
		        return tc.ConvertFrom(valor);
            }
            catch (Exception)
		    {
		        return Convert.ChangeType(valor, miTipo);
            }
        }

		/// <summary>
		/// Metodo para castear Dinamicamente un Tipo
		/// </summary>
		/// <param name="valor">Tipo a ser casteado</param>
		/// <param name="strField">Nombre de la columna</param>
		/// <returns>Devuelve un objeto del Tipo de la columna especificada en el Enum</returns>
		public dynamic GetColumnType(object valor, string strField)
		{
			if (DBNull.Value.Equals(valor)) 
				return null;
			Type destino = typeof(EntSegMensajeserror).GetProperty(strField).PropertyType;
			var miTipo = Nullable.GetUnderlyingType(destino) ?? destino;
		    try
		    {
		        TypeConverter tc = TypeDescriptor.GetConverter(miTipo);
		        return tc.ConvertFrom(valor);
		    }
		    catch (Exception)
		    {
		        return Convert.ChangeType(valor, miTipo);
		    }
        }

/// <summary>
/// Inserta una valor a una propiedad de un objeto instanciado
/// </summary>
/// <param name="obj">Objeto instanciado</param>
/// <param name="strPropiedad">Es el nombre de la propiedad</param>
/// <param name="dynValor">Es el valor que se insertara a la propiedad</param>
public void SetDato(ref EntSegMensajeserror obj, string strPropiedad, dynamic dynValor)
{
	if (obj == null) throw new ArgumentNullException();
	obj.GetType().GetProperty(strPropiedad).SetValue(obj, GetColumnType(dynValor, strPropiedad), null);
}

/// <summary>
/// Obtiene el valor de una propiedad de un objeto instanciado
/// </summary>
/// <param name="obj">Objeto instanciado</param>
/// <param name="strPropiedad">El nombre de la propiedad de la que se obtendra el valor</param>
/// <returns>Devuelve el valor del a propiedad seleccionada</returns>
public dynamic GetDato(ref EntSegMensajeserror obj, string strPropiedad)
{
	if (obj == null) return null;
	var propertyInfo = obj.GetType().GetProperty(strPropiedad);
	return GetColumnType(propertyInfo.GetValue(obj, null), strPropiedad);
}

		/// <summary>
		/// 	 Funcion que obtiene la llave primaria unica de la tabla segmensajeserror a partir de una cadena
		/// </summary>
		/// <param name="args" type="string[]">
		///     <para>
		/// 		 Cadena desde la que se construye el identificador unico de la tabla segmensajeserror
		///     </para>
		/// </param>
		/// <returns>
		/// 	 Identificador unico de la tabla segmensajeserror
		/// </returns>
		public string CreatePk(string[] args)
		{
			return args[0];
		}
		
		#endregion 

		#region ObtenerObjeto

		/// <summary>
		/// 	Funcion que obtiene los datos de una Clase EntSegMensajeserror a partir de la llave primaria
		/// </summary>
		/// <returns>
		/// 	Valor del Tipo EntSegMensajeserror que cumple con los filtros de los parametros
		/// </returns>
		public EntSegMensajeserror ObtenerObjeto(int interrorsme, String Stringaplicacionsap)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add(EntSegMensajeserror.Fields.errorsme.ToString());
			arrColumnasWhere.Add(EntSegMensajeserror.Fields.aplicacionsap.ToString());
		
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add(interrorsme);
			arrValoresWhere.Add("'" + Stringaplicacionsap + "'");
			
			return ObtenerObjeto(arrColumnasWhere, arrValoresWhere);
		}
		
		/// <summary>
		/// 	Funcion que obtiene los datos de una Clase EntSegMensajeserror a partir del usuario que inserta
		/// </summary>
		/// <param name="strUsuCre">Login o nombre de usuario</param>
		/// <returns>
		/// 	Valor del Tipo EntSegMensajeserror que cumple con los filtros de los parametros
		/// </returns>
		public EntSegMensajeserror ObtenerObjetoInsertado(string strUsuCre)
		{
			throw new NotImplementedException();
		}
		
		/// <summary>
		/// 	Funcion que obtiene los datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="arrColumnasWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las columnas WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="arrValoresWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las valores WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo EntSegMensajeserror que cumple con los filtros de los parametros
		/// </returns>
		public EntSegMensajeserror ObtenerObjeto(ArrayList arrColumnasWhere, ArrayList arrValoresWhere)
		{
			return ObtenerObjeto(arrColumnasWhere, arrValoresWhere, "");
		}
		
		/// <summary>
		/// 	Funcion que obtiene los datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="arrColumnasWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las columnas WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="arrValoresWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las valores WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="strParamAdicionales" type="String">
		///     <para>
		/// 		 Condiciones que van en la clausula WHERE. Deben ir sin WHERE
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo EntSegMensajeserror que cumple con los filtros de los parametros
		/// </returns>
		public EntSegMensajeserror ObtenerObjeto(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParamAdicionales)
		{
			try
			{
				ArrayList arrColumnas = new ArrayList();
				arrColumnas.Add(EntSegMensajeserror.Fields.errorsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.aplicacionsap.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.aplicacionerrorsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.descripcionsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.causasme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.accionsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.comentariosme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.origensme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.apiestadosme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.apitransaccionsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.usucresme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.feccresme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.usumodsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.fecmodsme.ToString());
				
				CConn local = new CConn();
				DataTable table = local.cargarDataTableAnd(CParametros.schema + EntSegMensajeserror.StrNombreTabla, arrColumnas, arrColumnasWhere, arrValoresWhere, strParamAdicionales);
				
				if (table.Rows.Count == 1)
				{
					EntSegMensajeserror obj = new EntSegMensajeserror();
					obj = crearObjeto(table.Rows[0]);
					return obj;
				}
				else if (table.Rows.Count > 1)
					throw new Exception("Se ha devuelto mas de un objeto");
				else
					return null;
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	Funcion que obtiene los datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="htbFiltro" type="System.Collections.Hashtable">
		///     <para>
		/// 		 Hashtable que contienen los pares para filtrar el resultado
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo EntSegMensajeserror que cumple con los filtros de los parametros
		/// </returns>
		public EntSegMensajeserror ObtenerObjeto(Hashtable htbFiltro)
		{
			return ObtenerObjeto(htbFiltro, "");
		}
		
		/// <summary>
		/// 	Funcion que obtiene los datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="htbFiltro" type="System.Collections.Hashtable">
		///     <para>
		/// 		 Hashtable que contienen los pares para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="strParamAdicionales" type="String">
		///     <para>
		/// 		 Condiciones que van en la clausula WHERE. Deben ir sin WHERE
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo EntSegMensajeserror que cumple con los filtros de los parametros
		/// </returns>
		public EntSegMensajeserror ObtenerObjeto(Hashtable htbFiltro, string strParamAdicionales)
		{
			try
			{
				ArrayList arrColumnas = new ArrayList();
				arrColumnas.Add(EntSegMensajeserror.Fields.errorsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.aplicacionsap.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.aplicacionerrorsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.descripcionsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.causasme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.accionsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.comentariosme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.origensme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.apiestadosme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.apitransaccionsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.usucresme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.feccresme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.usumodsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.fecmodsme.ToString());
				
				ArrayList arrColumnasWhere = new ArrayList();
				ArrayList arrValoresWhere = new ArrayList();
				
				foreach (DictionaryEntry entry in htbFiltro)
				{
					arrColumnasWhere.Add(entry.Key.ToString());
					arrValoresWhere.Add(entry.Value.ToString());
				}
				
				CConn local = new CConn();
				DataTable table = local.cargarDataTableAnd(CParametros.schema + EntSegMensajeserror.StrNombreTabla, arrColumnas, arrColumnasWhere, arrValoresWhere, strParamAdicionales);
				
				if (table.Rows.Count == 1)
				{
					EntSegMensajeserror obj = new EntSegMensajeserror();
					obj = crearObjeto(table.Rows[0]);
					return obj;
				}
				else if (table.Rows.Count > 1)
					throw new Exception("Se ha devuelto mas de un objeto");
				else
					return null;
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	Funcion que obtiene los datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="searchField" type="EntSegMensajeserror.Fileds">
		///     <para>
		/// 		 Campo por el que se va a filtrar la busqueda
		///     </para>
		/// </param>
		/// <param name="searchValue" type="object">
		///     <para>
		/// 		 Valor para la busqueda
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo EntSegMensajeserror que cumple con los filtros de los parametros
		/// </returns>
		public EntSegMensajeserror ObtenerObjeto(EntSegMensajeserror.Fields searchField, object searchValue)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add(searchField.ToString());
			
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add(searchValue);
			
			return ObtenerObjeto(arrColumnasWhere, arrValoresWhere);
		}
		
		/// <summary>
		/// 	Funcion que obtiene los datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="searchField" type="EntSegMensajeserror.Fileds">
		///     <para>
		/// 		 Campo por el que se va a filtrar la busqueda
		///     </para>
		/// </param>
		/// <param name="searchValue" type="object">
		///     <para>
		/// 		 Valor para la busqueda
		///     </para>
		/// </param>
		/// <param name="strParamAdicionales" type="String">
		///     <para>
		/// 		 Condiciones que van en la clausula WHERE. Deben ir sin WHERE
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo EntSegMensajeserror que cumple con los filtros de los parametros
		/// </returns>
		public EntSegMensajeserror ObtenerObjeto(EntSegMensajeserror.Fields searchField, object searchValue, string strParamAdicionales)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add(searchField.ToString());
			
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add(searchValue);
			
			return ObtenerObjeto(arrColumnasWhere, arrValoresWhere, strParamAdicionales);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un Business Object del Tipo EntSegMensajeserror a partir de su llave promaria
		/// </summary>
		/// <returns>
		/// 	Objeto del Tipo EntSegMensajeserror
		/// </returns>
		public EntSegMensajeserror ObtenerObjeto(int interrorsme, String Stringaplicacionsap, ref CTrans localTrans )
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add(EntSegMensajeserror.Fields.errorsme.ToString());
			arrColumnasWhere.Add(EntSegMensajeserror.Fields.aplicacionsap.ToString());
		
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add(interrorsme);
			arrValoresWhere.Add("'" + Stringaplicacionsap + "'");
			return ObtenerObjeto(arrColumnasWhere, arrValoresWhere, ref localTrans);
		}
		
		/// <summary>
		/// 	Funcion que obtiene los datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="arrColumnasWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las columnas WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="arrValoresWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las valores WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="localTrans" type="App_Class.Conexion.CTrans">
		///     <para>
		/// 		 Clase desde la que se va a utilizar una transaccion segmensajeserror
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo EntSegMensajeserror que cumple con los filtros de los parametros
		/// </returns>
		public EntSegMensajeserror ObtenerObjeto(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, ref CTrans localTrans)
		{
			return ObtenerObjeto(arrColumnasWhere, arrValoresWhere, "", ref localTrans);
		}
		
		/// <summary>
		/// 	Funcion que obtiene los datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="htbFiltro" type="System.Collections.Hashtable">
		///     <para>
		/// 		 Hashtable que contienen los pares para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="localTrans" type="App_Class.Conexion.CTrans">
		///     <para>
		/// 		 Clase desde la que se va a utilizar una transaccion segmensajeserror
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo EntSegMensajeserror que cumple con los filtros de los parametros
		/// </returns>
		public EntSegMensajeserror ObtenerObjeto(Hashtable htbFiltro, ref CTrans localTrans)
		{
			return ObtenerObjeto(htbFiltro, "", ref localTrans);
		}
		
		/// <summary>
		/// 	Funcion que obtiene los datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="arrColumnasWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las columnas WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="arrValoresWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las valores WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="strParamAdicionales" type="String">
		///     <para>
		/// 		 Condiciones que van en la clausula WHERE. Deben ir sin WHERE
		///     </para>
		/// </param>
		/// <param name="localTrans" type="App_Class.Conexion.CTrans">
		///     <para>
		/// 		 Clase desde la que se va a utilizar una transaccion segmensajeserror
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo EntSegMensajeserror que cumple con los filtros de los parametros
		/// </returns>
		public EntSegMensajeserror ObtenerObjeto(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParamAdicionales,  ref CTrans localTrans)
		{
			return ObtenerObjeto(arrColumnasWhere, arrValoresWhere, strParamAdicionales, ref localTrans);
		}
		
		/// <summary>
		/// 	Funcion que obtiene los datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="htbFiltro" type="System.Collections.Hashtable">
		///     <para>
		/// 		 Hashtable que contienen los pares para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="strParamAdicionales" type="String">
		///     <para>
		/// 		 Condiciones que van en la clausula WHERE. Deben ir sin WHERE
		///     </para>
		/// </param>
		/// <param name="localTrans" type="App_Class.Conexion.CTrans">
		///     <para>
		/// 		 Clase desde la que se va a utilizar una transaccion segmensajeserror
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo EntSegMensajeserror que cumple con los filtros de los parametros
		/// </returns>
		public EntSegMensajeserror ObtenerObjeto(Hashtable htbFiltro, string strParamAdicionales, ref CTrans localTrans)
		{
			try
			{
				ArrayList arrColumnas = new ArrayList();
				arrColumnas.Add(EntSegMensajeserror.Fields.errorsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.aplicacionsap.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.aplicacionerrorsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.descripcionsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.causasme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.accionsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.comentariosme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.origensme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.apiestadosme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.apitransaccionsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.usucresme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.feccresme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.usumodsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.fecmodsme.ToString());
				
				ArrayList arrColumnasWhere = new ArrayList();
				ArrayList arrValoresWhere = new ArrayList();
				
				foreach (DictionaryEntry entry in htbFiltro)
				{
					arrColumnasWhere.Add(entry.Key.ToString());
					arrValoresWhere.Add(entry.Value.ToString());
				}
				
				CConn local = new CConn();
				DataTable table = local.cargarDataTableAnd(CParametros.schema + EntSegMensajeserror.StrNombreTabla, arrColumnas, arrColumnasWhere, arrValoresWhere, strParamAdicionales, ref localTrans);
				
				if (table.Rows.Count == 1)
				{
					EntSegMensajeserror obj = new EntSegMensajeserror();
					obj = crearObjeto(table.Rows[0]);
					return obj;
				}
				else if (table.Rows.Count > 1)
					throw new Exception("Se ha devuelto mas de un objeto");
				else
					return null;
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	Funcion que obtiene los datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="searchField" type="EntSegMensajeserror.Fileds">
		///     <para>
		/// 		 Campo por el que se va a filtrar la busqueda
		///     </para>
		/// </param>
		/// <param name="searchValue" type="object">
		///     <para>
		/// 		 Valor para la busqueda
		///     </para>
		/// </param>
		/// <param name="localTrans" type="App_Class.Conexion.CTrans">
		///     <para>
		/// 		 Clase desde la que se va a utilizar una transaccion segmensajeserror
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo EntSegMensajeserror que cumple con los filtros de los parametros
		/// </returns>
		public EntSegMensajeserror ObtenerObjeto(EntSegMensajeserror.Fields searchField, object searchValue, ref CTrans localTrans)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add(searchField.ToString());
			
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add(searchValue);
			
			return ObtenerObjeto(arrColumnasWhere, arrValoresWhere, ref localTrans);
		}
		
		/// <summary>
		/// 	Funcion que obtiene los datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="searchField" type="EntSegMensajeserror.Fileds">
		///     <para>
		/// 		 Campo por el que se va a filtrar la busqueda
		///     </para>
		/// </param>
		/// <param name="searchValue" type="object">
		///     <para>
		/// 		 Valor para la busqueda
		///     </para>
		/// </param>
		/// <param name="strParamAdicionales" type="String">
		///     <para>
		/// 		 Condiciones que van en la clausula WHERE. Deben ir sin WHERE
		///     </para>
		/// </param>
		/// <param name="localTrans" type="App_Class.Conexion.CTrans">
		///     <para>
		/// 		 Clase desde la que se va a utilizar una transaccion segmensajeserror
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo EntSegMensajeserror que cumple con los filtros de los parametros
		/// </returns>
		public EntSegMensajeserror ObtenerObjeto(EntSegMensajeserror.Fields searchField, object searchValue, string strParamAdicionales, ref CTrans localTrans)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add(searchField.ToString());
			
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add(searchValue);
			
			return ObtenerObjeto(arrColumnasWhere, arrValoresWhere, strParamAdicionales, ref localTrans);
		}
		

		#endregion

		#region ObtenerLista

		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.List que cumple con los filtros de los parametros
		/// </returns>
		public List<EntSegMensajeserror> ObtenerLista()
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add("'1'");
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add("'1'");
			
			return ObtenerLista(arrColumnasWhere, arrValoresWhere);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="arrColumnasWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las columnas WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="arrValoresWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las valores WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.List que cumple con los filtros de los parametros
		/// </returns>
		public List<EntSegMensajeserror> ObtenerLista(ArrayList arrColumnasWhere, ArrayList arrValoresWhere)
		{
			return ObtenerLista(arrColumnasWhere, arrValoresWhere, "");
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="arrColumnasWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las columnas WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="arrValoresWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las valores WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="strParamAdicionales" type="String">
		///     <para>
		/// 		 Condiciones que van en la clausula WHERE. Deben ir sin WHERE
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.List que cumple con los filtros de los parametros
		/// </returns>
		public List<EntSegMensajeserror> ObtenerLista(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParamAdicionales)
		{
			try
			{
				ArrayList arrColumnas = new ArrayList();
				arrColumnas.Add(EntSegMensajeserror.Fields.errorsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.aplicacionsap.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.aplicacionerrorsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.descripcionsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.causasme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.accionsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.comentariosme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.origensme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.apiestadosme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.apitransaccionsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.usucresme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.feccresme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.usumodsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.fecmodsme.ToString());
				
				CConn local = new CConn();
				DataTable table = local.cargarDataTableAnd(CParametros.schema + EntSegMensajeserror.StrNombreTabla, arrColumnas, arrColumnasWhere, arrValoresWhere, strParamAdicionales);
				
				if (table.Rows.Count > 0)
				{
					return crearLista(table);
				}
				else
					return new List<EntSegMensajeserror>();
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="searchField" type="EntSegMensajeserror.Fileds">
		///     <para>
		/// 		 Campo por el que se va a filtrar la busqueda
		///     </para>
		/// </param>
		/// <param name="searchValue" type="object">
		///     <para>
		/// 		 Valor para la busqueda
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.List que cumple con los filtros de los parametros
		/// </returns>
		public List<EntSegMensajeserror> ObtenerLista(EntSegMensajeserror.Fields searchField, object searchValue)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add(searchField.ToString());
			
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add(searchValue);
			
			return ObtenerLista(arrColumnasWhere, arrValoresWhere);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="searchField" type="EntSegMensajeserror.Fileds">
		///     <para>
		/// 		 Campo por el que se va a filtrar la busqueda
		///     </para>
		/// </param>
		/// <param name="searchValue" type="object">
		///     <para>
		/// 		 Valor para la busqueda
		///     </para>
		/// </param>
		/// <param name="strParamAdicionales" type="String">
		///     <para>
		/// 		 Condiciones que van en la clausula WHERE. Deben ir sin WHERE
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.List que cumple con los filtros de los parametros
		/// </returns>
		public List<EntSegMensajeserror> ObtenerLista(EntSegMensajeserror.Fields searchField, object searchValue, string strParamAdicionales)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add(searchField.ToString());
			
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add(searchValue);
			
			return ObtenerLista(arrColumnasWhere, arrValoresWhere, strParamAdicionales);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="arrColumnasWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las columnas WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="arrValoresWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las valores WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="localTrans" type="App_Class.Conexion.CTrans">
		///     <para>
		/// 		 Clase desde la que se va a utilizar una transaccion segmensajeserror
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.List que cumple con los filtros de los parametros
		/// </returns>
		public List<EntSegMensajeserror> ObtenerLista(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, ref CTrans localTrans)
		{
			return ObtenerLista(arrColumnasWhere, arrValoresWhere, "", ref localTrans);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="arrColumnasWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las columnas WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="arrValoresWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las valores WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="strParamAdicionales" type="String">
		///     <para>
		/// 		 Condiciones que van en la clausula WHERE. Deben ir sin WHERE
		///     </para>
		/// </param>
		/// <param name="localTrans" type="App_Class.Conexion.CTrans">
		///     <para>
		/// 		 Clase desde la que se va a utilizar una transaccion segmensajeserror
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.List que cumple con los filtros de los parametros
		/// </returns>
		public List<EntSegMensajeserror> ObtenerLista(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParamAdicionales, ref CTrans localTrans)
		{
			try
			{
				ArrayList arrColumnas = new ArrayList();
				arrColumnas.Add(EntSegMensajeserror.Fields.errorsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.aplicacionsap.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.aplicacionerrorsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.descripcionsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.causasme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.accionsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.comentariosme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.origensme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.apiestadosme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.apitransaccionsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.usucresme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.feccresme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.usumodsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.fecmodsme.ToString());
				
				CConn local = new CConn();
				DataTable table = local.cargarDataTableAnd(CParametros.schema + EntSegMensajeserror.StrNombreTabla, arrColumnas, arrColumnasWhere, arrValoresWhere, strParamAdicionales, ref localTrans);
				
				if (table.Rows.Count > 0)
				{
					return crearLista(table);
				}
				else
					return new List<EntSegMensajeserror>();
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="searchField" type="EntSegMensajeserror.Fileds">
		///     <para>
		/// 		 Campo por el que se va a filtrar la busqueda
		///     </para>
		/// </param>
		/// <param name="searchValue" type="object">
		///     <para>
		/// 		 Valor para la busqueda
		///     </para>
		/// </param>
		/// <param name="localTrans" type="App_Class.Conexion.CTrans">
		///     <para>
		/// 		 Clase desde la que se va a utilizar una transaccion segmensajeserror
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.List que cumple con los filtros de los parametros
		/// </returns>
		public List<EntSegMensajeserror> ObtenerLista(EntSegMensajeserror.Fields searchField, object searchValue, ref CTrans localTrans)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add(searchField.ToString());
			
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add(searchValue);
			
			return ObtenerLista(arrColumnasWhere, arrValoresWhere, ref localTrans);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="searchField" type="EntSegMensajeserror.Fileds">
		///     <para>
		/// 		 Campo por el que se va a filtrar la busqueda
		///     </para>
		/// </param>
		/// <param name="searchValue" type="object">
		///     <para>
		/// 		 Valor para la busqueda
		///     </para>
		/// </param>
		/// <param name="strParamAdicionales" type="String">
		///     <para>
		/// 		 Condiciones que van en la clausula WHERE. Deben ir sin WHERE
		///     </para>
		/// </param>
		/// <param name="localTrans" type="App_Class.Conexion.CTrans">
		///     <para>
		/// 		 Clase desde la que se va a utilizar una transaccion segmensajeserror
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.List que cumple con los filtros de los parametros
		/// </returns>
		public List<EntSegMensajeserror> ObtenerLista(EntSegMensajeserror.Fields searchField, object searchValue, string strParamAdicionales, ref CTrans localTrans)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add(searchField.ToString());
			
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add(searchValue);
			
			return ObtenerLista(arrColumnasWhere, arrValoresWhere, strParamAdicionales, ref localTrans);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="htbFiltro" type="System.Collections.Hashtable">
		///     <para>
		/// 		 Hashtable que contienen los pares para filtrar el resultado
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.List que cumple con los filtros de los parametros
		/// </returns>
		public List<EntSegMensajeserror> ObtenerLista(Hashtable htbFiltro)
		{
			return ObtenerLista(htbFiltro, "");
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="htbFiltro" type="System.Collections.Hashtable">
		///     <para>
		/// 		 Hashtable que contienen los pares para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="strParamAdicionales" type="String">
		///     <para>
		/// 		 Condiciones que van en la clausula WHERE. Deben ir sin WHERE
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.List que cumple con los filtros de los parametros
		/// </returns>
		public List<EntSegMensajeserror> ObtenerLista(Hashtable htbFiltro, string strParamAdicionales)
		{
			try
			{
				ArrayList arrColumnas = new ArrayList();
				arrColumnas.Add(EntSegMensajeserror.Fields.errorsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.aplicacionsap.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.aplicacionerrorsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.descripcionsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.causasme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.accionsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.comentariosme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.origensme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.apiestadosme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.apitransaccionsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.usucresme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.feccresme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.usumodsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.fecmodsme.ToString());
				
				ArrayList arrColumnasWhere = new ArrayList();
				ArrayList arrValoresWhere = new ArrayList();
				
				foreach (DictionaryEntry entry in htbFiltro)
				{
					arrColumnasWhere.Add(entry.Key.ToString());
					arrValoresWhere.Add(entry.Value.ToString());
				}
				
				CConn local = new CConn();
				DataTable table = local.cargarDataTableAnd(CParametros.schema + EntSegMensajeserror.StrNombreTabla, arrColumnas, arrColumnasWhere, arrValoresWhere, strParamAdicionales);
				
				if (table.Rows.Count > 0)
				{
					return crearLista(table);
				}
				else
					return new List<EntSegMensajeserror>();
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="htbFiltro" type="System.Collections.Hashtable">
		///     <para>
		/// 		 Hashtable que contienen los pares para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="localTrans" type="App_Class.Conexion.CTrans">
		///     <para>
		/// 		 Clase desde la que se va a utilizar una transaccion segmensajeserror
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.List que cumple con los filtros de los parametros
		/// </returns>
		public List<EntSegMensajeserror> ObtenerLista(Hashtable htbFiltro, ref CTrans localTrans)
		{
			return ObtenerLista(htbFiltro, "", ref localTrans);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="htbFiltro" type="System.Collections.Hashtable">
		///     <para>
		/// 		 Hashtable que contienen los pares para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="strParamAdicionales" type="String">
		///     <para>
		/// 		 Condiciones que van en la clausula WHERE. Deben ir sin WHERE
		///     </para>
		/// </param>
		/// <param name="localTrans" type="App_Class.Conexion.CTrans">
		///     <para>
		/// 		 Clase desde la que se va a utilizar una transaccion segmensajeserror
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.List que cumple con los filtros de los parametros
		/// </returns>
		public List<EntSegMensajeserror> ObtenerLista(Hashtable htbFiltro, string strParamAdicionales, ref CTrans localTrans)
		{
			try
			{
				ArrayList arrColumnas = new ArrayList();
				arrColumnas.Add(EntSegMensajeserror.Fields.errorsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.aplicacionsap.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.aplicacionerrorsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.descripcionsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.causasme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.accionsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.comentariosme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.origensme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.apiestadosme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.apitransaccionsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.usucresme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.feccresme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.usumodsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.fecmodsme.ToString());
				
				ArrayList arrColumnasWhere = new ArrayList();
				ArrayList arrValoresWhere = new ArrayList();
				
				foreach (DictionaryEntry entry in htbFiltro)
				{
					arrColumnasWhere.Add(entry.Key.ToString());
					arrValoresWhere.Add(entry.Value.ToString());
				}
				
				CConn local = new CConn();
				DataTable table = local.cargarDataTableAnd(CParametros.schema + EntSegMensajeserror.StrNombreTabla, arrColumnas, arrColumnasWhere, arrValoresWhere, strParamAdicionales, ref localTrans);
				
				if (table.Rows.Count > 0)
				{
					return crearLista(table);
				}
				else
					return new List<EntSegMensajeserror>();
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="strVista" type="String">
		///     <para>
		/// 		 Nombre de la Vista desde que se van ha obtener los datos
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.List que cumple con los filtros de los parametros
		/// </returns>
		public List<EntSegMensajeserror> ObtenerListaDesdeVista(String strVista)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add("'1'");
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add("'1'");
			
			return ObtenerListaDesdeVista(strVista, arrColumnasWhere, arrValoresWhere);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="strVista" type="String">
		///     <para>
		/// 		 Nombre de la Vista desde que se van ha obtener los datos
		///     </para>
		/// </param>
		/// <param name="arrColumnasWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las columnas WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="arrValoresWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las valores WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.List que cumple con los filtros de los parametros
		/// </returns>
		public List<EntSegMensajeserror> ObtenerListaDesdeVista(String strVista, ArrayList arrColumnasWhere, ArrayList arrValoresWhere)
		{
			return ObtenerListaDesdeVista(strVista, arrColumnasWhere, arrValoresWhere, "");
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="strVista" type="String">
		///     <para>
		/// 		 Nombre de la Vista desde que se van ha obtener los datos
		///     </para>
		/// </param>
		/// <param name="arrColumnasWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las columnas WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="arrValoresWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las valores WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="strParamAdicionales" type="String">
		///     <para>
		/// 		 Condiciones que van en la clausula WHERE. Deben ir sin WHERE
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.List que cumple con los filtros de los parametros
		/// </returns>
		public List<EntSegMensajeserror> ObtenerListaDesdeVista(String strVista, ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParamAdicionales)
		{
			try
			{
				ArrayList arrColumnas = new ArrayList();
				arrColumnas.Add("*");
				
				CConn local = new CConn();
				DataTable table = local.cargarDataTableAnd(CParametros.schema + strVista, arrColumnas, arrColumnasWhere, arrValoresWhere, strParamAdicionales);
				
				if (table.Rows.Count > 0)
				{
					return crearListaRevisada(table);
				}
				else
					return new List<EntSegMensajeserror>();
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="strVista" type="String">
		///     <para>
		/// 		 Nombre de la Vista desde que se van ha obtener los datos
		///     </para>
		/// </param>
		/// <param name="htbFiltro" type="System.Collections.Hashtable">
		///     <para>
		/// 		 Hashtable que contienen los pares para filtrar el resultado
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.List que cumple con los filtros de los parametros
		/// </returns>
		public List<EntSegMensajeserror> ObtenerListaDesdeVista(String strVista, Hashtable htbFiltro)
		{
			return ObtenerListaDesdeVista(strVista, htbFiltro, "");
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="strVista" type="String">
		///     <para>
		/// 		 Nombre de la Vista desde que se van ha obtener los datos
		///     </para>
		/// </param>
		/// <param name="htbFiltro" type="System.Collections.Hashtable">
		///     <para>
		/// 		 Hashtable que contienen los pares para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="strParamAdicionales" type="String">
		///     <para>
		/// 		 Condiciones que van en la clausula WHERE. Deben ir sin WHERE
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.List que cumple con los filtros de los parametros
		/// </returns>
		public List<EntSegMensajeserror> ObtenerListaDesdeVista(String strVista, Hashtable htbFiltro, string strParamAdicionales)
		{
			try
			{
				ArrayList arrColumnas = new ArrayList();
				arrColumnas.Add("*");
				
				ArrayList arrColumnasWhere = new ArrayList();
				ArrayList arrValoresWhere = new ArrayList();
				
				foreach (DictionaryEntry entry in htbFiltro)
				{
					arrColumnasWhere.Add(entry.Key.ToString());
					arrValoresWhere.Add(entry.Value.ToString());
				}
				
				CConn local = new CConn();
				DataTable table = local.cargarDataTableAnd(CParametros.schema + strVista, arrColumnas, arrColumnasWhere, arrValoresWhere, strParamAdicionales);
				
				if (table.Rows.Count > 0)
				{
					return crearListaRevisada(table);
				}
				else
					return new List<EntSegMensajeserror>();
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="strVista" type="String">
		///     <para>
		/// 		 Nombre de la Vista desde que se van ha obtener los datos
		///     </para>
		/// </param>
		/// <param name="searchField" type="EntSegMensajeserror.Fileds">
		///     <para>
		/// 		 Campo por el que se va a filtrar la busqueda
		///     </para>
		/// </param>
		/// <param name="searchValue" type="object">
		///     <para>
		/// 		 Valor para la busqueda
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.List que cumple con los filtros de los parametros
		/// </returns>
		public List<EntSegMensajeserror> ObtenerListaDesdeVista(String strVista, EntSegMensajeserror.Fields searchField, object searchValue)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add(searchField.ToString());
			
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add(searchValue);
			
			return ObtenerListaDesdeVista(strVista, arrColumnasWhere, arrValoresWhere);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="strVista" type="String">
		///     <para>
		/// 		 Nombre de la Vista desde que se van ha obtener los datos
		///     </para>
		/// </param>
		/// <param name="searchField" type="EntSegMensajeserror.Fileds">
		///     <para>
		/// 		 Campo por el que se va a filtrar la busqueda
		///     </para>
		/// </param>
		/// <param name="searchValue" type="object">
		///     <para>
		/// 		 Valor para la busqueda
		///     </para>
		/// </param>
		/// <param name="strParamAdicionales" type="String">
		///     <para>
		/// 		 Condiciones que van en la clausula WHERE. Deben ir sin WHERE
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.List que cumple con los filtros de los parametros
		/// </returns>
		public List<EntSegMensajeserror> ObtenerListaDesdeVista(String strVista, EntSegMensajeserror.Fields searchField, object searchValue, string strParamAdicionales)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add(searchField.ToString());
			
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add(searchValue);
			
			return ObtenerListaDesdeVista(strVista, arrColumnasWhere, arrValoresWhere, strParamAdicionales);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="strVista" type="String">
		///     <para>
		/// 		 Nombre de la Vista desde que se van ha obtener los datos
		///     </para>
		/// </param>
		/// <param name="arrColumnasWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las columnas WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="arrValoresWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las valores WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="localTrans" type="App_Class.Conexion.CTrans">
		///     <para>
		/// 		 Clase desde la que se va a utilizar una transaccion segmensajeserror
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.List que cumple con los filtros de los parametros
		/// </returns>
		public List<EntSegMensajeserror> ObtenerListaDesdeVista(String strVista, ArrayList arrColumnasWhere, ArrayList arrValoresWhere, ref CTrans localTrans)
		{
			return ObtenerListaDesdeVista(strVista, arrColumnasWhere, arrValoresWhere, "", ref localTrans);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="strVista" type="String">
		///     <para>
		/// 		 Nombre de la Vista desde que se van ha obtener los datos
		///     </para>
		/// </param>
		/// <param name="arrColumnasWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las columnas WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="arrValoresWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las valores WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="strParamAdicionales" type="String">
		///     <para>
		/// 		 Condiciones que van en la clausula WHERE. Deben ir sin WHERE
		///     </para>
		/// </param>
		/// <param name="localTrans" type="App_Class.Conexion.CTrans">
		///     <para>
		/// 		 Clase desde la que se va a utilizar una transaccion segmensajeserror
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.List que cumple con los filtros de los parametros
		/// </returns>
		public List<EntSegMensajeserror> ObtenerListaDesdeVista(String strVista, ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParamAdicionales, ref CTrans localTrans)
		{
			try
			{
				ArrayList arrColumnas = new ArrayList();
				arrColumnas.Add("*");
				
				CConn local = new CConn();
				DataTable table = local.cargarDataTableAnd(CParametros.schema + strVista, arrColumnas, arrColumnasWhere, arrValoresWhere, strParamAdicionales, ref localTrans);
				
				if (table.Rows.Count > 0)
				{
					return crearListaRevisada(table);
				}
				else
					return new List<EntSegMensajeserror>();
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="strVista" type="String">
		///     <para>
		/// 		 Nombre de la Vista desde que se van ha obtener los datos
		///     </para>
		/// </param>
		/// <param name="htbFiltro" type="System.Collections.Hashtable">
		///     <para>
		/// 		 Hashtable que contienen los pares para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="localTrans" type="App_Class.Conexion.CTrans">
		///     <para>
		/// 		 Clase desde la que se va a utilizar una transaccion segmensajeserror
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.List que cumple con los filtros de los parametros
		/// </returns>
		public List<EntSegMensajeserror> ObtenerListaDesdeVista(String strVista, Hashtable htbFiltro, ref CTrans localTrans)
		{
			return ObtenerListaDesdeVista(strVista, htbFiltro, "", ref localTrans);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="strVista" type="String">
		///     <para>
		/// 		 Nombre de la Vista desde que se van ha obtener los datos
		///     </para>
		/// </param>
		/// <param name="htbFiltro" type="System.Collections.Hashtable">
		///     <para>
		/// 		 Hashtable que contienen los pares para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="strParamAdicionales" type="String">
		///     <para>
		/// 		 Condiciones que van en la clausula WHERE. Deben ir sin WHERE
		///     </para>
		/// </param>
		/// <param name="localTrans" type="App_Class.Conexion.CTrans">
		///     <para>
		/// 		 Clase desde la que se va a utilizar una transaccion segmensajeserror
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.List que cumple con los filtros de los parametros
		/// </returns>
		public List<EntSegMensajeserror> ObtenerListaDesdeVista(String strVista, Hashtable htbFiltro, string strParamAdicionales, ref CTrans localTrans)
		{
			try
			{
				ArrayList arrColumnas = new ArrayList();
				arrColumnas.Add("*");
				
				ArrayList arrColumnasWhere = new ArrayList();
				ArrayList arrValoresWhere = new ArrayList();
				
				foreach (DictionaryEntry entry in htbFiltro)
				{
					arrColumnasWhere.Add(entry.Key.ToString());
					arrValoresWhere.Add(entry.Value.ToString());
				}
				
				CConn local = new CConn();
				DataTable table = local.cargarDataTableAnd(CParametros.schema + strVista, arrColumnas, arrColumnasWhere, arrValoresWhere, strParamAdicionales, ref localTrans);
				
				if (table.Rows.Count > 0)
				{
					return crearListaRevisada(table);
				}
				else
					return new List<EntSegMensajeserror>();
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="strVista" type="String">
		///     <para>
		/// 		 Nombre de la Vista desde que se van ha obtener los datos
		///     </para>
		/// </param>
		/// <param name="searchField" type="EntSegMensajeserror.Fileds">
		///     <para>
		/// 		 Campo por el que se va a filtrar la busqueda
		///     </para>
		/// </param>
		/// <param name="searchValue" type="object">
		///     <para>
		/// 		 Valor para la busqueda
		///     </para>
		/// </param>
		/// <param name="localTrans" type="App_Class.Conexion.CTrans">
		///     <para>
		/// 		 Clase desde la que se va a utilizar una transaccion segmensajeserror
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.List que cumple con los filtros de los parametros
		/// </returns>
		public List<EntSegMensajeserror> ObtenerListaDesdeVista(String strVista, EntSegMensajeserror.Fields searchField, object searchValue, ref CTrans localTrans)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add(searchField.ToString());
			
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add(searchValue);
			
			return ObtenerListaDesdeVista(strVista, arrColumnasWhere, arrValoresWhere, ref localTrans);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="strVista" type="String">
		///     <para>
		/// 		 Nombre de la Vista desde que se van ha obtener los datos
		///     </para>
		/// </param>
		/// <param name="searchField" type="EntSegMensajeserror.Fileds">
		///     <para>
		/// 		 Campo por el que se va a filtrar la busqueda
		///     </para>
		/// </param>
		/// <param name="searchValue" type="object">
		///     <para>
		/// 		 Valor para la busqueda
		///     </para>
		/// </param>
		/// <param name="strParamAdicionales" type="String">
		///     <para>
		/// 		 Condiciones que van en la clausula WHERE. Deben ir sin WHERE
		///     </para>
		/// </param>
		/// <param name="localTrans" type="App_Class.Conexion.CTrans">
		///     <para>
		/// 		 Clase desde la que se va a utilizar una transaccion segmensajeserror
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.List que cumple con los filtros de los parametros
		/// </returns>
		public List<EntSegMensajeserror> ObtenerListaDesdeVista(String strVista, EntSegMensajeserror.Fields searchField, object searchValue, string strParamAdicionales, ref CTrans localTrans)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add(searchField.ToString());
			
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add(searchValue);
			
			return ObtenerListaDesdeVista(strVista, arrColumnasWhere, arrValoresWhere, strParamAdicionales, ref localTrans);
		}
		

		#endregion 

		#region ObtenerCola y Obtener Pila

		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.Queue que cumple con los filtros de los parametros
		/// </returns>
		public Queue<EntSegMensajeserror> ObtenerCola()
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add("'1'");
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add("'1'");
			
			return ObtenerCola(arrColumnasWhere, arrValoresWhere);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="arrColumnasWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las columnas WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="arrValoresWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las valores WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.Queue que cumple con los filtros de los parametros
		/// </returns>
		public Queue<EntSegMensajeserror> ObtenerCola(ArrayList arrColumnasWhere, ArrayList arrValoresWhere)
		{
			return ObtenerCola(arrColumnasWhere, arrValoresWhere, "");
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="arrColumnasWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las columnas WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="arrValoresWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las valores WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="strParamAdicionales" type="String">
		///     <para>
		/// 		 Condiciones que van en la clausula WHERE. Deben ir sin WHERE
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.Queue que cumple con los filtros de los parametros
		/// </returns>
		public Queue<EntSegMensajeserror> ObtenerCola(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParamAdicionales)
		{
			try
			{
				ArrayList arrColumnas = new ArrayList();
				arrColumnas.Add(EntSegMensajeserror.Fields.errorsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.aplicacionsap.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.aplicacionerrorsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.descripcionsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.causasme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.accionsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.comentariosme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.origensme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.apiestadosme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.apitransaccionsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.usucresme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.feccresme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.usumodsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.fecmodsme.ToString());
				
				CConn local = new CConn();
				DataTable table = local.cargarDataTableAnd(CParametros.schema + EntSegMensajeserror.StrNombreTabla, arrColumnas, arrColumnasWhere, arrValoresWhere, strParamAdicionales);
				
				if (table.Rows.Count > 0)
				{
					return crearCola(table);
				}
				else
					return new Queue<EntSegMensajeserror>();
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="searchField" type="EntSegMensajeserror.Fileds">
		///     <para>
		/// 		 Campo por el que se va a filtrar la busqueda
		///     </para>
		/// </param>
		/// <param name="searchValue" type="object">
		///     <para>
		/// 		 Valor para la busqueda
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.Queue que cumple con los filtros de los parametros
		/// </returns>
		public Queue<EntSegMensajeserror> ObtenerCola(EntSegMensajeserror.Fields searchField, object searchValue)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add(searchField.ToString());
			
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add(searchValue);
			
			return ObtenerCola(arrColumnasWhere, arrValoresWhere);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="searchField" type="EntSegMensajeserror.Fileds">
		///     <para>
		/// 		 Campo por el que se va a filtrar la busqueda
		///     </para>
		/// </param>
		/// <param name="searchValue" type="object">
		///     <para>
		/// 		 Valor para la busqueda
		///     </para>
		/// </param>
		/// <param name="strParamAdicionales" type="String">
		///     <para>
		/// 		 Condiciones que van en la clausula WHERE. Deben ir sin WHERE
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.Queue que cumple con los filtros de los parametros
		/// </returns>
		public Queue<EntSegMensajeserror> ObtenerCola(EntSegMensajeserror.Fields searchField, object searchValue, string strParamAdicionales)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add(searchField.ToString());
			
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add(searchValue);
			
			return ObtenerCola(arrColumnasWhere, arrValoresWhere, strParamAdicionales);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="arrColumnasWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las columnas WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="arrValoresWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las valores WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="localTrans" type="App_Class.Conexion.CTrans">
		///     <para>
		/// 		 Clase desde la que se va a utilizar una transaccion segmensajeserror
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.Queue que cumple con los filtros de los parametros
		/// </returns>
		public Queue<EntSegMensajeserror> ObtenerCola(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, ref CTrans localTrans)
		{
			return ObtenerCola(arrColumnasWhere, arrValoresWhere, "", ref localTrans);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="arrColumnasWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las columnas WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="arrValoresWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las valores WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="strParamAdicionales" type="String">
		///     <para>
		/// 		 Condiciones que van en la clausula WHERE. Deben ir sin WHERE
		///     </para>
		/// </param>
		/// <param name="localTrans" type="App_Class.Conexion.CTrans">
		///     <para>
		/// 		 Clase desde la que se va a utilizar una transaccion segmensajeserror
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.Queue que cumple con los filtros de los parametros
		/// </returns>
		public Queue<EntSegMensajeserror> ObtenerCola(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParamAdicionales, ref CTrans localTrans)
		{
			try
			{
				ArrayList arrColumnas = new ArrayList();
				arrColumnas.Add(EntSegMensajeserror.Fields.errorsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.aplicacionsap.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.aplicacionerrorsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.descripcionsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.causasme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.accionsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.comentariosme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.origensme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.apiestadosme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.apitransaccionsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.usucresme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.feccresme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.usumodsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.fecmodsme.ToString());
				
				CConn local = new CConn();
				DataTable table = local.cargarDataTableAnd(CParametros.schema + EntSegMensajeserror.StrNombreTabla, arrColumnas, arrColumnasWhere, arrValoresWhere, strParamAdicionales, ref localTrans);
				
				if (table.Rows.Count > 0)
				{
					return crearCola(table);
				}
				else
					return new Queue<EntSegMensajeserror>();
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="searchField" type="EntSegMensajeserror.Fileds">
		///     <para>
		/// 		 Campo por el que se va a filtrar la busqueda
		///     </para>
		/// </param>
		/// <param name="searchValue" type="object">
		///     <para>
		/// 		 Valor para la busqueda
		///     </para>
		/// </param>
		/// <param name="localTrans" type="App_Class.Conexion.CTrans">
		///     <para>
		/// 		 Clase desde la que se va a utilizar una transaccion segmensajeserror
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.Queue que cumple con los filtros de los parametros
		/// </returns>
		public Queue<EntSegMensajeserror> ObtenerCola(EntSegMensajeserror.Fields searchField, object searchValue, ref CTrans localTrans)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add(searchField.ToString());
			
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add(searchValue);
			
			return ObtenerCola(arrColumnasWhere, arrValoresWhere, ref localTrans);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="searchField" type="EntSegMensajeserror.Fileds">
		///     <para>
		/// 		 Campo por el que se va a filtrar la busqueda
		///     </para>
		/// </param>
		/// <param name="searchValue" type="object">
		///     <para>
		/// 		 Valor para la busqueda
		///     </para>
		/// </param>
		/// <param name="strParamAdicionales" type="String">
		///     <para>
		/// 		 Condiciones que van en la clausula WHERE. Deben ir sin WHERE
		///     </para>
		/// </param>
		/// <param name="localTrans" type="App_Class.Conexion.CTrans">
		///     <para>
		/// 		 Clase desde la que se va a utilizar una transaccion segmensajeserror
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.Stack que cumple con los filtros de los parametros
		/// </returns>
		public Queue<EntSegMensajeserror> ObtenerCola(EntSegMensajeserror.Fields searchField, object searchValue, string strParamAdicionales, ref CTrans localTrans)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add(searchField.ToString());
			
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add(searchValue);
			
			return ObtenerCola(arrColumnasWhere, arrValoresWhere, strParamAdicionales, ref localTrans);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.Stack que cumple con los filtros de los parametros
		/// </returns>
		public Stack<EntSegMensajeserror> ObtenerPila()
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add("'1'");
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add("'1'");
			
			return ObtenerPila(arrColumnasWhere, arrValoresWhere);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="arrColumnasWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las columnas WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="arrValoresWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las valores WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo Stack que cumple con los filtros de los parametros
		/// </returns>
		public Stack<EntSegMensajeserror> ObtenerPila(ArrayList arrColumnasWhere, ArrayList arrValoresWhere)
		{
			return ObtenerPila(arrColumnasWhere, arrValoresWhere, "");
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="arrColumnasWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las columnas WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="arrValoresWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las valores WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="strParamAdicionales" type="String">
		///     <para>
		/// 		 Condiciones que van en la clausula WHERE. Deben ir sin WHERE
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo Stack que cumple con los filtros de los parametros
		/// </returns>
		public Stack<EntSegMensajeserror> ObtenerPila(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParamAdicionales)
		{
			try
			{
				ArrayList arrColumnas = new ArrayList();
				arrColumnas.Add(EntSegMensajeserror.Fields.errorsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.aplicacionsap.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.aplicacionerrorsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.descripcionsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.causasme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.accionsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.comentariosme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.origensme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.apiestadosme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.apitransaccionsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.usucresme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.feccresme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.usumodsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.fecmodsme.ToString());
				
				CConn local = new CConn();
				DataTable table = local.cargarDataTableAnd(CParametros.schema + EntSegMensajeserror.StrNombreTabla, arrColumnas, arrColumnasWhere, arrValoresWhere, strParamAdicionales);
				
				if (table.Rows.Count > 0)
				{
					return crearPila(table);
				}
				else
					return new Stack<EntSegMensajeserror>();
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="searchField" type="EntSegMensajeserror.Fileds">
		///     <para>
		/// 		 Campo por el que se va a filtrar la busqueda
		///     </para>
		/// </param>
		/// <param name="searchValue" type="object">
		///     <para>
		/// 		 Valor para la busqueda
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo Stack que cumple con los filtros de los parametros
		/// </returns>
		public Stack<EntSegMensajeserror> ObtenerPila(EntSegMensajeserror.Fields searchField, object searchValue)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add(searchField.ToString());
			
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add(searchValue);
			
			return ObtenerPila(arrColumnasWhere, arrValoresWhere);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="searchField" type="EntSegMensajeserror.Fileds">
		///     <para>
		/// 		 Campo por el que se va a filtrar la busqueda
		///     </para>
		/// </param>
		/// <param name="searchValue" type="object">
		///     <para>
		/// 		 Valor para la busqueda
		///     </para>
		/// </param>
		/// <param name="strParamAdicionales" type="String">
		///     <para>
		/// 		 Condiciones que van en la clausula WHERE. Deben ir sin WHERE
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo Stack que cumple con los filtros de los parametros
		/// </returns>
		public Stack<EntSegMensajeserror> ObtenerPila(EntSegMensajeserror.Fields searchField, object searchValue, string strParamAdicionales)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add(searchField.ToString());
			
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add(searchValue);
			
			return ObtenerPila(arrColumnasWhere, arrValoresWhere, strParamAdicionales);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="arrColumnasWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las columnas WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="arrValoresWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las valores WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="localTrans" type="App_Class.Conexion.CTrans">
		///     <para>
		/// 		 Clase desde la que se va a utilizar una transaccion segmensajeserror
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo Stack que cumple con los filtros de los parametros
		/// </returns>
		public Stack<EntSegMensajeserror> ObtenerPila(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, ref CTrans localTrans)
		{
			return ObtenerPila(arrColumnasWhere, arrValoresWhere, "", ref localTrans);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="arrColumnasWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las columnas WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="arrValoresWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las valores WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="strParamAdicionales" type="String">
		///     <para>
		/// 		 Condiciones que van en la clausula WHERE. Deben ir sin WHERE
		///     </para>
		/// </param>
		/// <param name="localTrans" type="App_Class.Conexion.CTrans">
		///     <para>
		/// 		 Clase desde la que se va a utilizar una transaccion segmensajeserror
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.Stack que cumple con los filtros de los parametros
		/// </returns>
		public Stack<EntSegMensajeserror> ObtenerPila(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParamAdicionales, ref CTrans localTrans)
		{
			try
			{
				ArrayList arrColumnas = new ArrayList();
				arrColumnas.Add(EntSegMensajeserror.Fields.errorsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.aplicacionsap.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.aplicacionerrorsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.descripcionsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.causasme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.accionsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.comentariosme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.origensme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.apiestadosme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.apitransaccionsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.usucresme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.feccresme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.usumodsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.fecmodsme.ToString());
				
				CConn local = new CConn();
				DataTable table = local.cargarDataTableAnd(CParametros.schema + EntSegMensajeserror.StrNombreTabla, arrColumnas, arrColumnasWhere, arrValoresWhere, strParamAdicionales, ref localTrans);
				
				if (table.Rows.Count > 0)
				{
					return crearPila(table);
				}
				else
					return new Stack<EntSegMensajeserror>();
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="searchField" type="EntSegMensajeserror.Fileds">
		///     <para>
		/// 		 Campo por el que se va a filtrar la busqueda
		///     </para>
		/// </param>
		/// <param name="searchValue" type="object">
		///     <para>
		/// 		 Valor para la busqueda
		///     </para>
		/// </param>
		/// <param name="localTrans" type="App_Class.Conexion.CTrans">
		///     <para>
		/// 		 Clase desde la que se va a utilizar una transaccion segmensajeserror
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.Stack que cumple con los filtros de los parametros
		/// </returns>
		public Stack<EntSegMensajeserror> ObtenerPila(EntSegMensajeserror.Fields searchField, object searchValue, ref CTrans localTrans)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add(searchField.ToString());
			
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add(searchValue);
			
			return ObtenerPila(arrColumnasWhere, arrValoresWhere, ref localTrans);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="searchField" type="EntSegMensajeserror.Fileds">
		///     <para>
		/// 		 Campo por el que se va a filtrar la busqueda
		///     </para>
		/// </param>
		/// <param name="searchValue" type="object">
		///     <para>
		/// 		 Valor para la busqueda
		///     </para>
		/// </param>
		/// <param name="strParamAdicionales" type="String">
		///     <para>
		/// 		 Condiciones que van en la clausula WHERE. Deben ir sin WHERE
		///     </para>
		/// </param>
		/// <param name="localTrans" type="App_Class.Conexion.CTrans">
		///     <para>
		/// 		 Clase desde la que se va a utilizar una transaccion segmensajeserror
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.Stack que cumple con los filtros de los parametros
		/// </returns>
		public Stack<EntSegMensajeserror> ObtenerPila(EntSegMensajeserror.Fields searchField, object searchValue, string strParamAdicionales, ref CTrans localTrans)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add(searchField.ToString());
			
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add(searchValue);
			
			return ObtenerPila(arrColumnasWhere, arrValoresWhere, strParamAdicionales, ref localTrans);
		}
		

		#endregion 

		#region ObtenerDataTable

		/// <summary>
		/// 	 Funcion que llena un DataTable con los registros de una tabla segmensajeserror
		/// </summary>
		/// <returns>
		/// 	 DataTable con los datos obtenidos de segmensajeserror
		/// </returns>
		public DataTable NuevoDataTable()
		{
			try
			{
				DataTable table = new DataTable ();
				DataColumn dc;
				dc = new DataColumn(EntSegMensajeserror.Fields.errorsme.ToString(),typeof(EntSegMensajeserror).GetProperty(EntSegMensajeserror.Fields.errorsme.ToString()).PropertyType);
				table.Columns.Add(dc);

				dc = new DataColumn(EntSegMensajeserror.Fields.aplicacionsap.ToString(),typeof(EntSegMensajeserror).GetProperty(EntSegMensajeserror.Fields.aplicacionsap.ToString()).PropertyType);
				table.Columns.Add(dc);

				dc = new DataColumn(EntSegMensajeserror.Fields.aplicacionerrorsme.ToString(),typeof(EntSegMensajeserror).GetProperty(EntSegMensajeserror.Fields.aplicacionerrorsme.ToString()).PropertyType);
				table.Columns.Add(dc);

				dc = new DataColumn(EntSegMensajeserror.Fields.descripcionsme.ToString(),typeof(EntSegMensajeserror).GetProperty(EntSegMensajeserror.Fields.descripcionsme.ToString()).PropertyType);
				table.Columns.Add(dc);

				dc = new DataColumn(EntSegMensajeserror.Fields.causasme.ToString(),typeof(EntSegMensajeserror).GetProperty(EntSegMensajeserror.Fields.causasme.ToString()).PropertyType);
				table.Columns.Add(dc);

				dc = new DataColumn(EntSegMensajeserror.Fields.accionsme.ToString(),typeof(EntSegMensajeserror).GetProperty(EntSegMensajeserror.Fields.accionsme.ToString()).PropertyType);
				table.Columns.Add(dc);

				dc = new DataColumn(EntSegMensajeserror.Fields.comentariosme.ToString(),typeof(EntSegMensajeserror).GetProperty(EntSegMensajeserror.Fields.comentariosme.ToString()).PropertyType);
				table.Columns.Add(dc);

				dc = new DataColumn(EntSegMensajeserror.Fields.origensme.ToString(),typeof(EntSegMensajeserror).GetProperty(EntSegMensajeserror.Fields.origensme.ToString()).PropertyType);
				table.Columns.Add(dc);

				dc = new DataColumn(EntSegMensajeserror.Fields.apiestadosme.ToString(),typeof(EntSegMensajeserror).GetProperty(EntSegMensajeserror.Fields.apiestadosme.ToString()).PropertyType);
				table.Columns.Add(dc);

				dc = new DataColumn(EntSegMensajeserror.Fields.apitransaccionsme.ToString(),typeof(EntSegMensajeserror).GetProperty(EntSegMensajeserror.Fields.apitransaccionsme.ToString()).PropertyType);
				table.Columns.Add(dc);

				dc = new DataColumn(EntSegMensajeserror.Fields.usucresme.ToString(),typeof(EntSegMensajeserror).GetProperty(EntSegMensajeserror.Fields.usucresme.ToString()).PropertyType);
				table.Columns.Add(dc);

				dc = new DataColumn(EntSegMensajeserror.Fields.feccresme.ToString(),typeof(EntSegMensajeserror).GetProperty(EntSegMensajeserror.Fields.feccresme.ToString()).PropertyType);
				table.Columns.Add(dc);

				dc = new DataColumn(EntSegMensajeserror.Fields.usumodsme.ToString(),typeof(EntSegMensajeserror).GetProperty(EntSegMensajeserror.Fields.usumodsme.ToString()).PropertyType);
				table.Columns.Add(dc);

				dc = new DataColumn(EntSegMensajeserror.Fields.fecmodsme.ToString(),typeof(EntSegMensajeserror).GetProperty(EntSegMensajeserror.Fields.fecmodsme.ToString()).PropertyType);
				table.Columns.Add(dc);

				
				return table;
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	 Funcion que genera un DataTable con determinadas columnas de una segmensajeserror
		/// </summary>
		/// <param name="arrColumnas" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las columnas que se va a seleccionar para mostrarlas en el resultado
		///     </para>
		/// </param>
		/// <returns>
		/// 	 DataTable con los datos obtenidos de segmensajeserror
		/// </returns>
		public DataTable NuevoDataTable(ArrayList arrColumnas)
		{
			try
			{
				ArrayList arrColumnasWhere = new ArrayList();
				arrColumnasWhere.Add("'1'");
				ArrayList arrValoresWhere = new ArrayList();
				arrValoresWhere.Add("'2'");
				
				CConn local = new CConn();
				DataTable table = local.cargarDataTableAnd(CParametros.schema + EntSegMensajeserror.StrNombreTabla, arrColumnas, arrColumnasWhere, arrValoresWhere);
				
				return table;
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	 Funcion que llena un DataTable con los registros de una tabla segmensajeserror
		/// </summary>
		/// <returns>
		/// 	 DataTable con los datos obtenidos de segmensajeserror
		/// </returns>
		public DataTable ObtenerDataTable()
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add("'1'");
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add("'1'");
			
			return ObtenerDataTable(arrColumnasWhere, arrValoresWhere);
		}
		
		/// <summary>
		/// 	 Funcion que llena un DataTable con los registros de una tabla y n condicion WHERE segmensajeserror
		/// </summary>
		/// <param name="strParamAdicionales" type="String">
		///     <para>
		/// 		 Condiciones que van en la clausula WHERE. Deben ir sin WHERE
		///     </para>
		/// </param>
		/// <returns>
		/// 	 DataTable con los datos obtenidos de segmensajeserror
		/// </returns>
		public DataTable ObtenerDataTable(String strParamAdicionales)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add("'1'");
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add("'1'");
			
			return ObtenerDataTable(arrColumnasWhere, arrValoresWhere, strParamAdicionales);
		}
		
		/// <summary>
		/// 	 Funcion que llena un DataTable con los registro de una tabla segmensajeserror
		/// </summary>
		/// <param name="arrColumnas" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las columnas que se va a seleccionar para mostrarlas en el resultado
		///     </para>
		/// </param>
		/// <returns>
		/// 	 DataTable con los datos obtenidos de segmensajeserror
		/// </returns>
		public DataTable ObtenerDataTable(ArrayList arrColumnas)
		{
			try
			{
				ArrayList arrColumnasWhere = new ArrayList();
				arrColumnasWhere.Add("'1'");
				ArrayList arrValoresWhere = new ArrayList();
				arrValoresWhere.Add("'1'");
				
				return ObtenerDataTable(arrColumnas, arrColumnasWhere, arrValoresWhere);
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	 Funcion que llena un DataTable con los registro de una tabla segmensajeserror
		/// </summary>
		/// <param name="arrColumnas" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las columnas que se va a seleccionar para mostrarlas en el resultado
		///     </para>
		/// </param>
		/// <param name="strParametrosAdicionales" type="string">
		///     <para>
		/// 		 Parametros adicionales
		///     </para>
		/// </param>
		/// <returns>
		/// 	 DataTable con los datos obtenidos de segmensajeserror
		/// </returns>
		public DataTable ObtenerDataTable(ArrayList arrColumnas, string strParametrosAdicionales)
		{
			try
			{
				ArrayList arrColumnasWhere = new ArrayList();
				arrColumnasWhere.Add("'1'");
				ArrayList arrValoresWhere = new ArrayList();
				arrValoresWhere.Add("'1'");
				
				return ObtenerDataTable(arrColumnas, arrColumnasWhere, arrValoresWhere, strParametrosAdicionales);
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	 Funcion que llena un DataTable con los registro de una tabla segmensajeserror
		/// </summary>
		/// <param name="arrColumnas" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las columnas que se va a seleccionar para mostrarlas en el resultado
		///     </para>
		/// </param>
		/// <param name="arrColumnasWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las columnas WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="arrValoresWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las valores WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <returns>
		/// 	 DataTable con los datos obtenidos de segmensajeserror
		/// </returns>
		public DataTable ObtenerDataTable(ArrayList arrColumnas, ArrayList arrColumnasWhere, ArrayList arrValoresWhere)
		{
			try
			{
				return ObtenerDataTable(arrColumnas, arrColumnasWhere, arrValoresWhere, "");
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	 Funcion que llena un DataTable con los registro de una tabla segmensajeserror
		/// </summary>
		/// <param name="arrColumnas" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las columnas que se va a seleccionar para mostrarlas en el resultado
		///     </para>
		/// </param>
		/// <param name="htbFiltro" type="System.Collections.Hashtable">
		///     <para>
		/// 		 Hashtable que contienen los pares para filtrar el resultado
		///     </para>
		/// </param>
		/// <returns>
		/// 	 DataTable con los datos obtenidos de segmensajeserror
		/// </returns>
		public DataTable ObtenerDataTable(ArrayList arrColumnas, Hashtable htbFiltro)
		{
			try
			{
				return ObtenerDataTable(arrColumnas, htbFiltro, "");
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	 Funcion que llena un DataTable con los registro de una tabla segmensajeserror
		/// </summary>
		/// <param name="arrColumnasWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las columnas WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="arrValoresWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las valores WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <returns>
		/// 	 DataTable con los datos obtenidos de segmensajeserror
		/// </returns>
		public DataTable ObtenerDataTable(ArrayList arrColumnasWhere, ArrayList arrValoresWhere)
		{
			try
			{
				return ObtenerDataTable(arrColumnasWhere, arrValoresWhere, "");
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	 Funcion que llena un DataTable con los registro de una tabla segmensajeserror
		/// </summary>
		/// <param name="htbFiltro" type="System.Collections.Hashtable">
		///     <para>
		/// 		 Hashtable que contienen los pares para filtrar el resultado
		///     </para>
		/// </param>
		/// <returns>
		/// 	 DataTable con los datos obtenidos de segmensajeserror
		/// </returns>
		public DataTable ObtenerDataTable(Hashtable htbFiltro)
		{
			try
			{
				return ObtenerDataTable(htbFiltro, "");
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	 Funcion que llena un DataTable con los registro de una tabla segmensajeserror
		/// </summary>
		/// <param name="arrColumnas" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las columnas que se va a seleccionar para mostrarlas en el resultado
		///     </para>
		/// </param>
		/// <param name="arrColumnasWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las columnas WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="arrValoresWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las valores WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="strParametrosAdicionales" type="string">
		///     <para>
		/// 		 Parametros adicionales
		///     </para>
		/// </param>
		/// <returns>
		/// 	 DataTable con los datos obtenidos de segmensajeserror
		/// </returns>
		public DataTable ObtenerDataTable(ArrayList arrColumnas, ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParametrosAdicionales)
		{
			try
			{
				CConn local = new CConn();
				DataTable table = local.cargarDataTableAnd(CParametros.schema + EntSegMensajeserror.StrNombreTabla, arrColumnas, arrColumnasWhere, arrValoresWhere, strParametrosAdicionales);
				
				return table;
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	 Funcion que llena un DataTable con los registro de una tabla segmensajeserror
		/// </summary>
		/// <param name="arrColumnas" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las columnas que se va a seleccionar para mostrarlas en el resultado
		///     </para>
		/// </param>
		/// <param name="htbFiltro" type="System.Collections.Hashtable">
		///     <para>
		/// 		 Hashtable que contienen los pares para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="strParametrosAdicionales" type="string">
		///     <para>
		/// 		 Parametros adicionales
		///     </para>
		/// </param>
		/// <returns>
		/// 	 DataTable con los datos obtenidos de segmensajeserror
		/// </returns>
		public DataTable ObtenerDataTable(ArrayList arrColumnas, Hashtable htbFiltro, string strParametrosAdicionales)
		{
			try
			{
				ArrayList arrColumnasWhere = new ArrayList();
				ArrayList arrValoresWhere = new ArrayList();
				
				foreach (DictionaryEntry entry in htbFiltro)
				{
					arrColumnasWhere.Add(entry.Key.ToString());
					arrValoresWhere.Add(entry.Value.ToString());
				}
				
				CConn local = new CConn();
				DataTable table = local.cargarDataTableAnd(CParametros.schema + EntSegMensajeserror.StrNombreTabla, arrColumnas, arrColumnasWhere, arrValoresWhere, strParametrosAdicionales);
				
				return table;
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	 Funcion que llena un DataTable con los registro de una tabla segmensajeserror
		/// </summary>
		/// <param name="arrColumnasWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las columnas WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="arrValoresWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las valores WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="strParametrosAdicionales" type="string">
		///     <para>
		/// 		 Parametros adicionales
		///     </para>
		/// </param>
		/// <returns>
		/// 	 DataTable con los datos obtenidos de segmensajeserror
		/// </returns>
		public DataTable ObtenerDataTable(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParametrosAdicionales)
		{
			try
			{
				ArrayList arrColumnas = new ArrayList();
				arrColumnas.Add(EntSegMensajeserror.Fields.errorsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.aplicacionsap.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.aplicacionerrorsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.descripcionsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.causasme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.accionsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.comentariosme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.origensme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.apiestadosme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.apitransaccionsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.usucresme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.feccresme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.usumodsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.fecmodsme.ToString());
				
				return ObtenerDataTable(arrColumnas, arrColumnasWhere, arrValoresWhere, strParametrosAdicionales);
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	 Funcion que llena un DataTable con los registro de una tabla segmensajeserror
		/// </summary>
		/// <param name="htbFiltro" type="System.Collections.Hashtable">
		///     <para>
		/// 		 Hashtable que contienen los pares para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="strParametrosAdicionales" type="string">
		///     <para>
		/// 		 Parametros adicionales
		///     </para>
		/// </param>
		/// <returns>
		/// 	 DataTable con los datos obtenidos de segmensajeserror
		/// </returns>
		public DataTable ObtenerDataTable(Hashtable htbFiltro, string strParametrosAdicionales)
		{
			try
			{
				ArrayList arrColumnasWhere = new ArrayList();
				ArrayList arrValoresWhere = new ArrayList();
				
				foreach (DictionaryEntry entry in htbFiltro)
				{
					arrColumnasWhere.Add(entry.Key.ToString());
					arrValoresWhere.Add(entry.Value.ToString());
				}
				
				ArrayList arrColumnas = new ArrayList();
				arrColumnas.Add(EntSegMensajeserror.Fields.errorsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.aplicacionsap.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.aplicacionerrorsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.descripcionsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.causasme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.accionsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.comentariosme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.origensme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.apiestadosme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.apitransaccionsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.usucresme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.feccresme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.usumodsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.fecmodsme.ToString());
				
				return ObtenerDataTable(arrColumnas, arrColumnasWhere, arrValoresWhere, strParametrosAdicionales);
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	 Funcion que llena un DataTable con los registro de una tabla segmensajeserror
		/// </summary>
		/// <param name="arrColumnasWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las columnas WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="arrValoresWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las valores WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <returns>
		/// 	 DataTable con los datos obtenidos de segmensajeserror
		/// </returns>
		public DataTable ObtenerDataTableOr(ArrayList arrColumnasWhere, ArrayList arrValoresWhere)
		{
			try
			{
				ArrayList arrColumnas = new ArrayList();
				arrColumnas.Add(EntSegMensajeserror.Fields.errorsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.aplicacionsap.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.aplicacionerrorsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.descripcionsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.causasme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.accionsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.comentariosme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.origensme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.apiestadosme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.apitransaccionsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.usucresme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.feccresme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.usumodsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.fecmodsme.ToString());
				return ObtenerDataTableOr(arrColumnas, arrColumnasWhere, arrValoresWhere, "");
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	 Funcion que llena un DataTable con los registro de una tabla segmensajeserror
		/// </summary>
		/// <param name="arrColumnas" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las columnas que se va a seleccionar para mostrarlas en el resultado
		///     </para>
		/// </param>
		/// <param name="arrColumnasWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las columnas WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="arrValoresWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las valores WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <returns>
		/// 	 DataTable con los datos obtenidos de segmensajeserror
		/// </returns>
		public DataTable ObtenerDataTableOr(ArrayList arrColumnas, ArrayList arrColumnasWhere, ArrayList arrValoresWhere)
		{
			try
			{
				return ObtenerDataTableOr(arrColumnas, arrColumnasWhere, arrValoresWhere, "");
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	 Funcion que llena un DataTable con los registro de una tabla segmensajeserror
		/// </summary>
		/// <param name="arrColumnas" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las columnas que se va a seleccionar para mostrarlas en el resultado
		///     </para>
		/// </param>
		/// <param name="arrColumnasWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las columnas WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="arrValoresWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las valores WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="strParametrosAdicionales" type="string">
		///     <para>
		/// 		 Parametros adicionales
		///     </para>
		/// </param>
		/// <returns>
		/// 	 DataTable con los datos obtenidos de segmensajeserror
		/// </returns>
		public DataTable ObtenerDataTableOr(ArrayList arrColumnas, ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParametrosAdicionales)
		{
			try
			{
				CConn local = new CConn();
				DataTable table = local.cargarDataTableOr(CParametros.schema + EntSegMensajeserror.StrNombreTabla, arrColumnas, arrColumnasWhere, arrValoresWhere, strParametrosAdicionales);
				
				return table;
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	Funcion que obtiene los datos a partir de un filtro realizado por algun campo
		/// </summary>
		/// <param name="searchField" type="EntSegMensajeserror.Fileds">
		///     <para>
		/// 		 Campo por el que se va a filtrar la busqueda
		///     </para>
		/// </param>
		/// <param name="searchValue" type="object">
		///     <para>
		/// 		 Valor para la busqueda
		///     </para>
		/// </param>
		/// <returns>
		/// 	DataTable que cumple con los filtros de los parametros
		/// </returns>
		public DataTable ObtenerDataTable(EntSegMensajeserror.Fields searchField, object searchValue)
		{
			try
			{
				ArrayList arrColumnasWhere = new ArrayList();
				arrColumnasWhere.Add(searchField.ToString());
				
				ArrayList arrValoresWhere = new ArrayList();
				arrValoresWhere.Add(searchValue);
				
				return ObtenerDataTable(arrColumnasWhere, arrValoresWhere);
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	Funcion que obtiene los datos a partir de un filtro realizado por algun campo
		/// </summary>
		/// <param name="searchField" type="EntSegMensajeserror.Fileds">
		///     <para>
		/// 		 Campo por el que se va a filtrar la busqueda
		///     </para>
		/// </param>
		/// <param name="searchValue" type="object">
		///     <para>
		/// 		 Valor para la busqueda
		///     </para>
		/// </param>
		/// <param name="strParametrosAdicionales" type="string">
		///     <para>
		/// 		 Parametros adicionales
		///     </para>
		/// </param>
		/// <returns>
		/// 	DataTable que cumple con los filtros de los parametros
		/// </returns>
		public DataTable ObtenerDataTable(EntSegMensajeserror.Fields searchField, object searchValue, string strParametrosAdicionales)
		{
			try
			{
				ArrayList arrColumnasWhere = new ArrayList();
				arrColumnasWhere.Add(searchField.ToString());
				
				ArrayList arrValoresWhere = new ArrayList();
				arrValoresWhere.Add(searchValue);
				
				return ObtenerDataTable(arrColumnasWhere, arrValoresWhere, strParametrosAdicionales);
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	Funcion que obtiene los datos a partir de un filtro realizado por algun campo
		/// </summary>
		/// <param name="arrColumnas" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las columnas que se va a seleccionar para mostrarlas en el resultado
		///     </para>
		/// </param>
		/// <param name="searchField" type="EntSegMensajeserror.Fileds">
		///     <para>
		/// 		 Campo por el que se va a filtrar la busqueda
		///     </para>
		/// </param>
		/// <param name="searchValue" type="object">
		///     <para>
		/// 		 Valor para la busqueda
		///     </para>
		/// </param>
		/// <param name="strParametrosAdicionales" type="string">
		///     <para>
		/// 		 Parametros adicionales
		///     </para>
		/// </param>
		/// <returns>
		/// 	DataTable que cumple con los filtros de los parametros
		/// </returns>
		public DataTable ObtenerDataTable(ArrayList arrColumnas, EntSegMensajeserror.Fields searchField, object searchValue, string strParametrosAdicionales)
		{
			try
			{
				ArrayList arrColumnasWhere = new ArrayList();
				arrColumnasWhere.Add(searchField.ToString());
				
				ArrayList arrValoresWhere = new ArrayList();
				arrValoresWhere.Add(searchValue);
				
				return ObtenerDataTable(arrColumnas, arrColumnasWhere, arrValoresWhere, strParametrosAdicionales);
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	Funcion que obtiene los datos a partir de un filtro realizado por algun campo
		/// </summary>
		/// <param name="arrColumnas" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las columnas que se va a seleccionar para mostrarlas en el resultado
		///     </para>
		/// </param>
		/// <param name="searchField" type="EntSegMensajeserror.Fileds">
		///     <para>
		/// 		 Campo por el que se va a filtrar la busqueda
		///     </para>
		/// </param>
		/// <param name="searchValue" type="object">
		///     <para>
		/// 		 Valor para la busqueda
		///     </para>
		/// </param>
		/// <returns>
		/// 	DataTable que cumple con los filtros de los parametros
		/// </returns>
		public DataTable ObtenerDataTable(ArrayList arrColumnas, EntSegMensajeserror.Fields searchField, object searchValue)
		{
			try
			{
				ArrayList arrColumnasWhere = new ArrayList();
				arrColumnasWhere.Add(searchField.ToString());
				
				ArrayList arrValoresWhere = new ArrayList();
				arrValoresWhere.Add(searchValue);
				
				return ObtenerDataTable(arrColumnas, arrColumnasWhere, arrValoresWhere);
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		

		#endregion 

		#region ObtenerDiccionario

		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.Dictionary que cumple con los filtros de los parametros
		/// </returns>
		public Dictionary<String, EntSegMensajeserror> ObtenerDiccionario()
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add("'1'");
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add("'1'");
			
			return ObtenerDiccionario(arrColumnasWhere, arrValoresWhere);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="arrColumnasWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las columnas WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="arrValoresWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las valores WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.Dictionary que cumple con los filtros de los parametros
		/// </returns>
		public Dictionary<String, EntSegMensajeserror> ObtenerDiccionario(ArrayList arrColumnasWhere, ArrayList arrValoresWhere)
		{
			return ObtenerDiccionario(arrColumnasWhere, arrValoresWhere, "");
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="arrColumnasWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las columnas WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="arrValoresWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las valores WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="strParamAdicionales" type="String">
		///     <para>
		/// 		 Condiciones que van en la clausula WHERE. Deben ir sin WHERE
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.Dictionary que cumple con los filtros de los parametros
		/// </returns>
		public Dictionary<String, EntSegMensajeserror> ObtenerDiccionario(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParamAdicionales)
		{
			try
			{
				ArrayList arrColumnas = new ArrayList();
				arrColumnas.Add(EntSegMensajeserror.Fields.errorsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.aplicacionsap.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.aplicacionerrorsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.descripcionsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.causasme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.accionsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.comentariosme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.origensme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.apiestadosme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.apitransaccionsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.usucresme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.feccresme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.usumodsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.fecmodsme.ToString());
				
				CConn local = new CConn();
				DataTable table = local.cargarDataTableAnd(CParametros.schema + EntSegMensajeserror.StrNombreTabla, arrColumnas, arrColumnasWhere, arrValoresWhere, strParamAdicionales);
				
				if (table.Rows.Count > 0)
				{
					return crearDiccionario(table);
				}
				else
					return new Dictionary<string, EntSegMensajeserror>();
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="searchField" type="EntSegMensajeserror.Fileds">
		///     <para>
		/// 		 Campo por el que se va a filtrar la busqueda
		///     </para>
		/// </param>
		/// <param name="searchValue" type="object">
		///     <para>
		/// 		 Valor para la busqueda
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.Dictionary que cumple con los filtros de los parametros
		/// </returns>
		public Dictionary<String, EntSegMensajeserror> ObtenerDiccionario(EntSegMensajeserror.Fields searchField, object searchValue)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add(searchField.ToString());
			
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add(searchValue);
			
			return ObtenerDiccionario(arrColumnasWhere, arrValoresWhere);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="searchField" type="EntSegMensajeserror.Fileds">
		///     <para>
		/// 		 Campo por el que se va a filtrar la busqueda
		///     </para>
		/// </param>
		/// <param name="searchValue" type="object">
		///     <para>
		/// 		 Valor para la busqueda
		///     </para>
		/// </param>
		/// <param name="strParamAdicionales" type="String">
		///     <para>
		/// 		 Condiciones que van en la clausula WHERE. Deben ir sin WHERE
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.Dictionary que cumple con los filtros de los parametros
		/// </returns>
		public Dictionary<String, EntSegMensajeserror> ObtenerDiccionario(EntSegMensajeserror.Fields searchField, object searchValue, string strParamAdicionales)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add(searchField.ToString());
			
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add(searchValue);
			
			return ObtenerDiccionario(arrColumnasWhere, arrValoresWhere, strParamAdicionales);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="arrColumnasWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las columnas WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="arrValoresWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las valores WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="localTrans" type="App_Class.Conexion.CTrans">
		///     <para>
		/// 		 Clase desde la que se va a utilizar una transaccion segmensajeserror
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.Dictionary que cumple con los filtros de los parametros
		/// </returns>
		public Dictionary<String, EntSegMensajeserror> ObtenerDiccionario(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, ref CTrans localTrans)
		{
			return ObtenerDiccionario(arrColumnasWhere, arrValoresWhere, "", ref localTrans);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="arrColumnasWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las columnas WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="arrValoresWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las valores WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="strParamAdicionales" type="String">
		///     <para>
		/// 		 Condiciones que van en la clausula WHERE. Deben ir sin WHERE
		///     </para>
		/// </param>
		/// <param name="localTrans" type="App_Class.Conexion.CTrans">
		///     <para>
		/// 		 Clase desde la que se va a utilizar una transaccion segmensajeserror
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.Dictionary que cumple con los filtros de los parametros
		/// </returns>
		public Dictionary<String, EntSegMensajeserror> ObtenerDiccionario(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParamAdicionales, ref CTrans localTrans)
		{
			try
			{
				ArrayList arrColumnas = new ArrayList();
				arrColumnas.Add(EntSegMensajeserror.Fields.errorsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.aplicacionsap.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.aplicacionerrorsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.descripcionsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.causasme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.accionsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.comentariosme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.origensme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.apiestadosme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.apitransaccionsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.usucresme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.feccresme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.usumodsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.fecmodsme.ToString());
				
				CConn local = new CConn();
				DataTable table = local.cargarDataTableAnd(CParametros.schema + EntSegMensajeserror.StrNombreTabla, arrColumnas, arrColumnasWhere, arrValoresWhere, strParamAdicionales, ref localTrans);
				
				if (table.Rows.Count > 0)
				{
					return crearDiccionario(table);
				}
				else
					return new Dictionary<string, EntSegMensajeserror>();
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="searchField" type="EntSegMensajeserror.Fileds">
		///     <para>
		/// 		 Campo por el que se va a filtrar la busqueda
		///     </para>
		/// </param>
		/// <param name="searchValue" type="object">
		///     <para>
		/// 		 Valor para la busqueda
		///     </para>
		/// </param>
		/// <param name="localTrans" type="App_Class.Conexion.CTrans">
		///     <para>
		/// 		 Clase desde la que se va a utilizar una transaccion segmensajeserror
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.Dictionary que cumple con los filtros de los parametros
		/// </returns>
		public Dictionary<String, EntSegMensajeserror> ObtenerDiccionario(EntSegMensajeserror.Fields searchField, object searchValue, ref CTrans localTrans)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add(searchField.ToString());
			
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add(searchValue);
			
			return ObtenerDiccionario(arrColumnasWhere, arrValoresWhere, ref localTrans);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegMensajeserror a partir de condiciones WHERE
		/// </summary>
		/// <param name="searchField" type="EntSegMensajeserror.Fileds">
		///     <para>
		/// 		 Campo por el que se va a filtrar la busqueda
		///     </para>
		/// </param>
		/// <param name="searchValue" type="object">
		///     <para>
		/// 		 Valor para la busqueda
		///     </para>
		/// </param>
		/// <param name="strParamAdicionales" type="String">
		///     <para>
		/// 		 Condiciones que van en la clausula WHERE. Deben ir sin WHERE
		///     </para>
		/// </param>
		/// <param name="localTrans" type="App_Class.Conexion.CTrans">
		///     <para>
		/// 		 Clase desde la que se va a utilizar una transaccion segmensajeserror
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.Dictionary que cumple con los filtros de los parametros
		/// </returns>
		public Dictionary<String, EntSegMensajeserror> ObtenerDiccionario(EntSegMensajeserror.Fields searchField, object searchValue, string strParamAdicionales, ref CTrans localTrans)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add(searchField.ToString());
			
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add(searchValue);
			
			return ObtenerDiccionario(arrColumnasWhere, arrValoresWhere, strParamAdicionales, ref localTrans);
		}
		
		public Dictionary<String, EntSegMensajeserror> ObtenerDiccionarioKey(EntSegMensajeserror.Fields dicKey)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add("'1'");
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add("'1'");
			
			return ObtenerDiccionarioKey(arrColumnasWhere, arrValoresWhere, dicKey);
		}
		
		public Dictionary<String, EntSegMensajeserror> ObtenerDiccionarioKey(String strParamAdic, EntSegMensajeserror.Fields dicKey)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add("'1'");
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add("'1'");
			
			return ObtenerDiccionarioKey(arrColumnasWhere, arrValoresWhere, strParamAdic, dicKey);
		}
		
		public Dictionary<String, EntSegMensajeserror> ObtenerDiccionarioKey(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, EntSegMensajeserror.Fields dicKey)
		{
			return ObtenerDiccionarioKey(arrColumnasWhere, arrValoresWhere, "", dicKey);
		}
		
		public Dictionary<String, EntSegMensajeserror> ObtenerDiccionarioKey(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParamAdicionales, EntSegMensajeserror.Fields dicKey)
		{
			try
			{
				ArrayList arrColumnas = new ArrayList();
				arrColumnas.Add(EntSegMensajeserror.Fields.errorsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.aplicacionsap.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.aplicacionerrorsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.descripcionsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.causasme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.accionsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.comentariosme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.origensme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.apiestadosme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.apitransaccionsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.usucresme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.feccresme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.usumodsme.ToString());
				arrColumnas.Add(EntSegMensajeserror.Fields.fecmodsme.ToString());
				
				CConn local = new CConn();
				DataTable table = local.cargarDataTableAnd(CParametros.schema + EntSegMensajeserror.StrNombreTabla, arrColumnas, arrColumnasWhere, arrValoresWhere, strParamAdicionales);
				
				if (table.Rows.Count > 0)
				{
					return crearDiccionario(table, dicKey);
				}
				else
					return new Dictionary<string, EntSegMensajeserror>();
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		public Dictionary<String, EntSegMensajeserror> ObtenerDiccionarioKey(EntSegMensajeserror.Fields searchField, object searchValue, EntSegMensajeserror.Fields dicKey)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add(searchField.ToString());
			
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add(searchValue);
			
			return ObtenerDiccionarioKey(arrColumnasWhere, arrValoresWhere, dicKey);
		}
		
		public Dictionary<String, EntSegMensajeserror> ObtenerDiccionarioKey(EntSegMensajeserror.Fields searchField, object searchValue, string strParamAdicionales, EntSegMensajeserror.Fields dicKey)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add(searchField.ToString());
			
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add(searchValue);
			
			return ObtenerDiccionarioKey(arrColumnasWhere, arrValoresWhere, strParamAdicionales, dicKey);
		}
		

		#endregion 

		#region ObjetoASp

		/// <summary>
		/// 	Funcion que inserta un nuevo registro en la tabla segmensajeserror a partir de una clase del tipo Esegmensajeserror
		/// </summary>
		/// <param name="strNombreSp" type="System.string">
		///     <para>
		/// 		 Nombre del Procedimiento a ejecutar sobre el SP
		///     </para>
		/// </param>
		/// <param name="obj" type="Entidades.EntSegMensajeserror">
		///     <para>
		/// 		 Clase desde la que se va a ejecutar el SP de la tabla segmensajeserror
		///     </para>
		/// </param>
		/// <returns>
		/// 	 Valor de registros afectados en el Procedimiento de la tabla segmensajeserror
		/// </returns>
		public int EjecutarSpDesdeObjeto(string strNombreSp, EntSegMensajeserror obj)
		{
			try
			{
				if (!obj.IsValid())
				{
					throw new Exception(obj.ValidationErrorsString());
				}
				
				ArrayList arrNombreParam = new ArrayList();
				arrNombreParam.Add(EntSegMensajeserror.Fields.errorsme.ToString());
				arrNombreParam.Add(EntSegMensajeserror.Fields.aplicacionsap.ToString());
				arrNombreParam.Add(EntSegMensajeserror.Fields.aplicacionerrorsme.ToString());
				arrNombreParam.Add(EntSegMensajeserror.Fields.descripcionsme.ToString());
				arrNombreParam.Add(EntSegMensajeserror.Fields.causasme.ToString());
				arrNombreParam.Add(EntSegMensajeserror.Fields.accionsme.ToString());
				arrNombreParam.Add(EntSegMensajeserror.Fields.comentariosme.ToString());
				arrNombreParam.Add(EntSegMensajeserror.Fields.origensme.ToString());
				arrNombreParam.Add(EntSegMensajeserror.Fields.apiestadosme.ToString());
				arrNombreParam.Add(EntSegMensajeserror.Fields.apitransaccionsme.ToString());
				arrNombreParam.Add(EntSegMensajeserror.Fields.usucresme.ToString());
				arrNombreParam.Add(EntSegMensajeserror.Fields.feccresme.ToString());
				arrNombreParam.Add(EntSegMensajeserror.Fields.usumodsme.ToString());
				arrNombreParam.Add(EntSegMensajeserror.Fields.fecmodsme.ToString());
				
				ArrayList arrValoresParam = new ArrayList();
				arrValoresParam.Add(obj.errorsme);
				arrValoresParam.Add(obj.aplicacionsap == null ? null : "'" + obj.aplicacionsap + "'");
				arrValoresParam.Add(obj.aplicacionerrorsme == null ? null : "'" + obj.aplicacionerrorsme + "'");
				arrValoresParam.Add(obj.descripcionsme == null ? null : "'" + obj.descripcionsme + "'");
				arrValoresParam.Add(obj.causasme == null ? null : "'" + obj.causasme + "'");
				arrValoresParam.Add(obj.accionsme == null ? null : "'" + obj.accionsme + "'");
				arrValoresParam.Add(obj.comentariosme == null ? null : "'" + obj.comentariosme + "'");
				arrValoresParam.Add(obj.origensme == null ? null : "'" + obj.origensme + "'");
				arrValoresParam.Add(obj.apiestadosme == null ? null : "'" + obj.apiestadosme + "'");
				arrValoresParam.Add(obj.apitransaccionsme == null ? null : "'" + obj.apitransaccionsme + "'");
				arrValoresParam.Add(obj.usucresme == null ? null : "'" + obj.usucresme + "'");
				arrValoresParam.Add(obj.feccresme == null ? null : "'" + Convert.ToDateTime(obj.feccresme).ToString(CParametros.ParFormatoFechaHora) + "'");
				arrValoresParam.Add(obj.usumodsme == null ? null : "'" + obj.usumodsme + "'");
				arrValoresParam.Add(obj.fecmodsme == null ? null : "'" + Convert.ToDateTime(obj.fecmodsme).ToString(CParametros.ParFormatoFechaHora) + "'");

				
				//Llamamos al Procedmiento Almacenado
				CConn local = new CConn();
				return local.execStoreProcedure(strNombreSp, arrNombreParam, arrValoresParam);
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}

		/// <summary>
		/// 	Funcion que inserta un nuevo registro en la tabla segmensajeserror a partir de una clase del tipo Esegmensajeserror
		/// </summary>
		/// <param name="strNombreSp" type="System.string">
		///     <para>
		/// 		 Nombre del Procedimiento a ejecutar sobre el SP
		///     </para>
		/// </param>
		/// <param name="obj" type="Entidades.EntSegMensajeserror">
		///     <para>
		/// 		 Clase desde la que se va a ejecutar el SP de la tabla segmensajeserror
		///     </para>
		/// </param>
		/// <param name="localTrans" type="App_Class.Conexion.CTrans">
		///     <para>
		/// 		 Clase desde la que se va a utilizar una transaccion segmensajeserror
		///     </para>
		/// </param>
		/// <returns>
		/// 	 Valor de registros afectados en el Procedimiento de la tabla segmensajeserror
		/// </returns>
		public int EjecutarSpDesdeObjeto(string strNombreSp, EntSegMensajeserror obj, ref CTrans localTrans)
		{
			try
			{
				if (!obj.IsValid())
				{
					throw new Exception(obj.ValidationErrorsString());
				}
				
				ArrayList arrNombreParam = new ArrayList();
				arrNombreParam.Add(EntSegMensajeserror.Fields.errorsme.ToString());
				arrNombreParam.Add(EntSegMensajeserror.Fields.aplicacionsap.ToString());
				arrNombreParam.Add(EntSegMensajeserror.Fields.aplicacionerrorsme.ToString());
				arrNombreParam.Add(EntSegMensajeserror.Fields.descripcionsme.ToString());
				arrNombreParam.Add(EntSegMensajeserror.Fields.causasme.ToString());
				arrNombreParam.Add(EntSegMensajeserror.Fields.accionsme.ToString());
				arrNombreParam.Add(EntSegMensajeserror.Fields.comentariosme.ToString());
				arrNombreParam.Add(EntSegMensajeserror.Fields.origensme.ToString());
				arrNombreParam.Add(EntSegMensajeserror.Fields.apiestadosme.ToString());
				arrNombreParam.Add(EntSegMensajeserror.Fields.apitransaccionsme.ToString());
				arrNombreParam.Add(EntSegMensajeserror.Fields.usucresme.ToString());
				arrNombreParam.Add(EntSegMensajeserror.Fields.feccresme.ToString());
				arrNombreParam.Add(EntSegMensajeserror.Fields.usumodsme.ToString());
				arrNombreParam.Add(EntSegMensajeserror.Fields.fecmodsme.ToString());
				
				ArrayList arrValoresParam = new ArrayList();
				arrValoresParam.Add(obj.errorsme);
				arrValoresParam.Add(obj.aplicacionsap == null ? null : "'" + obj.aplicacionsap + "'");
				arrValoresParam.Add(obj.aplicacionerrorsme == null ? null : "'" + obj.aplicacionerrorsme + "'");
				arrValoresParam.Add(obj.descripcionsme == null ? null : "'" + obj.descripcionsme + "'");
				arrValoresParam.Add(obj.causasme == null ? null : "'" + obj.causasme + "'");
				arrValoresParam.Add(obj.accionsme == null ? null : "'" + obj.accionsme + "'");
				arrValoresParam.Add(obj.comentariosme == null ? null : "'" + obj.comentariosme + "'");
				arrValoresParam.Add(obj.origensme == null ? null : "'" + obj.origensme + "'");
				arrValoresParam.Add(obj.apiestadosme == null ? null : "'" + obj.apiestadosme + "'");
				arrValoresParam.Add(obj.apitransaccionsme == null ? null : "'" + obj.apitransaccionsme + "'");
				arrValoresParam.Add(obj.usucresme == null ? null : "'" + obj.usucresme + "'");
				arrValoresParam.Add(obj.feccresme == null ? null : "'" + Convert.ToDateTime(obj.feccresme).ToString(CParametros.ParFormatoFechaHora) + "'");
				arrValoresParam.Add(obj.usumodsme == null ? null : "'" + obj.usumodsme + "'");
				arrValoresParam.Add(obj.fecmodsme == null ? null : "'" + Convert.ToDateTime(obj.fecmodsme).ToString(CParametros.ParFormatoFechaHora) + "'");

				
				//Llamamos al Procedmiento Almacenado
				CConn local = new CConn();
				return local.execStoreProcedure(strNombreSp, arrNombreParam, arrValoresParam, ref localTrans);
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}


		#endregion 

		#region FuncionesAgregadas

		/// <summary>
		/// 	Funcion que devuelve el resultado de la funcion [SQL] COUNT
		/// </summary>
		/// <param name="refField" type="EntSegMensajeserror.Fileds">
		///     <para>
		/// 		 Campo al que se va a aplicar la funcion
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo EntSegMensajeserror que cumple con los filtros de los parametros
		/// </returns>
		public int FuncionesCount(EntSegMensajeserror.Fields refField)
		{
			try
			{
				ArrayList arrColumnasWhere = new ArrayList();
				arrColumnasWhere.Add(1);
				ArrayList arrValoresWhere = new ArrayList();
				arrValoresWhere.Add(1);
				
				return FuncionesCount(refField, arrColumnasWhere, arrValoresWhere);
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}

		/// <summary>
		/// 	Funcion que devuelve el resultado de la funcion [SQL] COUNT
		/// </summary>
		/// <param name="refField" type="EntSegMensajeserror.Fileds">
		///     <para>
		/// 		 Campo al que se va a aplicar la funcion
		///     </para>
		/// </param>
		/// <param name="whereField" type="EntSegMensajeserror.Fileds">
		///     <para>
		/// 		 Columna que va a filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="valueField" type="System.Object">
		///     <para>
		/// 		 Valor para filtrar el resultado
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo EntSegMensajeserror que cumple con los filtros de los parametros
		/// </returns>
		public int FuncionesCount(EntSegMensajeserror.Fields refField, EntSegMensajeserror.Fields whereField, object valueField)
		{
			try
			{
				ArrayList arrColumnasWhere = new ArrayList();
				arrColumnasWhere.Add(whereField.ToString());
				ArrayList arrValoresWhere = new ArrayList();
				arrValoresWhere.Add(valueField.ToString());
				
				return FuncionesCount(refField, arrColumnasWhere, arrValoresWhere);
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}

		/// <summary>
		/// 	Funcion que devuelve el resultado de la funcion [SQL] COUNT
		/// </summary>
		/// <param name="refField" type="EntSegMensajeserror.Fileds">
		///     <para>
		/// 		 Campo al que se va a aplicar la funcion
		///     </para>
		/// </param>
		/// <param name="arrColumnasWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las columnas WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="arrValoresWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las valores WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo EntSegMensajeserror que cumple con los filtros de los parametros
		/// </returns>
		public int FuncionesCount(EntSegMensajeserror.Fields refField, ArrayList arrColumnasWhere, ArrayList arrValoresWhere)
		{
			try
			{
				ArrayList arrColumnas = new ArrayList();
				arrColumnas.Add("count(" + refField + ")");
				DataTable dtTemp = ObtenerDataTable(arrColumnas, arrColumnasWhere, arrValoresWhere);
				if (dtTemp.Rows.Count == 0)
					throw new Exception("La consulta no ha devuelto resultados.");
				if (dtTemp.Rows.Count > 1)
					throw new Exception("Se ha devuelto mas de una fila.");
				if (dtTemp.Rows[0][0] == null)
					return 0;
				if (dtTemp.Rows[0][0] == "")
					return 0;
				return int.Parse(dtTemp.Rows[0][0].ToString());
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}

		/// <summary>
		/// 	Funcion que devuelve el resultado de la funcion [SQL] MIN
		/// </summary>
		/// <param name="refField" type="EntSegMensajeserror.Fileds">
		///     <para>
		/// 		 Campo al que se va a aplicar la funcion
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo EntSegMensajeserror que cumple con los filtros de los parametros
		/// </returns>
		public int FuncionesMin(EntSegMensajeserror.Fields refField)
		{
			try
			{
				ArrayList arrColumnasWhere = new ArrayList();
				arrColumnasWhere.Add(1);
				ArrayList arrValoresWhere = new ArrayList();
				arrValoresWhere.Add(1);
				
				return FuncionesMin(refField, arrColumnasWhere, arrValoresWhere);
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}

		/// <summary>
		/// 	Funcion que devuelve el resultado de la funcion [SQL] MIN
		/// </summary>
		/// <param name="refField" type="EntSegMensajeserror.Fileds">
		///     <para>
		/// 		 Campo al que se va a aplicar la funcion
		///     </para>
		/// </param>
		/// <param name="whereField" type="EntSegMensajeserror.Fileds">
		///     <para>
		/// 		 Columna que va a filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="valueField" type="System.Object">
		///     <para>
		/// 		 Valor para filtrar el resultado
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo EntSegMensajeserror que cumple con los filtros de los parametros
		/// </returns>
		public int FuncionesMin(EntSegMensajeserror.Fields refField, EntSegMensajeserror.Fields whereField, object valueField)
		{
			try
			{
				ArrayList arrColumnasWhere = new ArrayList();
				arrColumnasWhere.Add(whereField.ToString());
				ArrayList arrValoresWhere = new ArrayList();
				arrValoresWhere.Add(valueField.ToString());
				
				return FuncionesMin(refField, arrColumnasWhere, arrValoresWhere);
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}

		/// <summary>
		/// 	Funcion que devuelve el resultado de la funcion [SQL] MIN
		/// </summary>
		/// <param name="refField" type="EntSegMensajeserror.Fileds">
		///     <para>
		/// 		 Campo al que se va a aplicar la funcion
		///     </para>
		/// </param>
		/// <param name="arrColumnasWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las columnas WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="arrValoresWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las valores WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo EntSegMensajeserror que cumple con los filtros de los parametros
		/// </returns>
		public int FuncionesMin(EntSegMensajeserror.Fields refField, ArrayList arrColumnasWhere, ArrayList arrValoresWhere)
		{
			try
			{
				ArrayList arrColumnas = new ArrayList();
				arrColumnas.Add("min(" + refField + ")");
				DataTable dtTemp = ObtenerDataTable(arrColumnas, arrColumnasWhere, arrValoresWhere);
				if (dtTemp.Rows.Count == 0)
					throw new Exception("La consulta no ha devuelto resultados.");
				if (dtTemp.Rows.Count > 1)
					throw new Exception("Se ha devuelto mas de una fila.");
				if (dtTemp.Rows[0][0] == null)
					return 0;
				if (dtTemp.Rows[0][0] == "")
					return 0;
				return int.Parse(dtTemp.Rows[0][0].ToString());
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}

		/// <summary>
		/// 	Funcion que devuelve el resultado de la funcion [SQL] MAX
		/// </summary>
		/// <param name="refField" type="EntSegMensajeserror.Fileds">
		///     <para>
		/// 		 Campo al que se va a aplicar la funcion
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo EntSegMensajeserror que cumple con los filtros de los parametros
		/// </returns>
		public int FuncionesMax(EntSegMensajeserror.Fields refField)
		{
			try
			{
				ArrayList arrColumnasWhere = new ArrayList();
				arrColumnasWhere.Add(1);
				ArrayList arrValoresWhere = new ArrayList();
				arrValoresWhere.Add(1);
				
				return FuncionesMax(refField, arrColumnasWhere, arrValoresWhere);
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}

		/// <summary>
		/// 	Funcion que devuelve el resultado de la funcion [SQL] MAX
		/// </summary>
		/// <param name="refField" type="EntSegMensajeserror.Fileds">
		///     <para>
		/// 		 Campo al que se va a aplicar la funcion
		///     </para>
		/// </param>
		/// <param name="whereField" type="EntSegMensajeserror.Fileds">
		///     <para>
		/// 		 Columna que va a filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="valueField" type="System.Object">
		///     <para>
		/// 		 Valor para filtrar el resultado
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo EntSegMensajeserror que cumple con los filtros de los parametros
		/// </returns>
		public int FuncionesMax(EntSegMensajeserror.Fields refField, EntSegMensajeserror.Fields whereField, object valueField)
		{
			try
			{
				ArrayList arrColumnasWhere = new ArrayList();
				arrColumnasWhere.Add(whereField.ToString());
				ArrayList arrValoresWhere = new ArrayList();
				arrValoresWhere.Add(valueField.ToString());
				
				return FuncionesMax(refField, arrColumnasWhere, arrValoresWhere);
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}

		/// <summary>
		/// 	Funcion que devuelve el resultado de la funcion [SQL] MAX
		/// </summary>
		/// <param name="refField" type="EntSegMensajeserror.Fileds">
		///     <para>
		/// 		 Campo al que se va a aplicar la funcion
		///     </para>
		/// </param>
		/// <param name="arrColumnasWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las columnas WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="arrValoresWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las valores WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo EntSegMensajeserror que cumple con los filtros de los parametros
		/// </returns>
		public int FuncionesMax(EntSegMensajeserror.Fields refField, ArrayList arrColumnasWhere, ArrayList arrValoresWhere)
		{
			try
			{
				ArrayList arrColumnas = new ArrayList();
				arrColumnas.Add("max(" + refField + ")");
				DataTable dtTemp = ObtenerDataTable(arrColumnas, arrColumnasWhere, arrValoresWhere);
				if (dtTemp.Rows.Count == 0)
					throw new Exception("La consulta no ha devuelto resultados.");
				if (dtTemp.Rows.Count > 1)
					throw new Exception("Se ha devuelto mas de una fila.");
				if (dtTemp.Rows[0][0] == null)
					return 0;
				if (dtTemp.Rows[0][0] == "")
					return 0;
				return int.Parse(dtTemp.Rows[0][0].ToString());
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}

		/// <summary>
		/// 	Funcion que devuelve el resultado de la funcion [SQL] SUM
		/// </summary>
		/// <param name="refField" type="EntSegMensajeserror.Fileds">
		///     <para>
		/// 		 Campo al que se va a aplicar la funcion
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo EntSegMensajeserror que cumple con los filtros de los parametros
		/// </returns>
		public int FuncionesSum(EntSegMensajeserror.Fields refField)
		{
			try
			{
				ArrayList arrColumnasWhere = new ArrayList();
				arrColumnasWhere.Add(1);
				ArrayList arrValoresWhere = new ArrayList();
				arrValoresWhere.Add(1);
				
				return FuncionesSum(refField, arrColumnasWhere, arrValoresWhere);
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}

		/// <summary>
		/// 	Funcion que devuelve el resultado de la funcion [SQL] SUM
		/// </summary>
		/// <param name="refField" type="EntSegMensajeserror.Fileds">
		///     <para>
		/// 		 Campo al que se va a aplicar la funcion
		///     </para>
		/// </param>
		/// <param name="whereField" type="EntSegMensajeserror.Fileds">
		///     <para>
		/// 		 Columna que va a filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="valueField" type="System.Object">
		///     <para>
		/// 		 Valor para filtrar el resultado
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo EntSegMensajeserror que cumple con los filtros de los parametros
		/// </returns>
		public int FuncionesSum(EntSegMensajeserror.Fields refField, EntSegMensajeserror.Fields whereField, object valueField)
		{
			try
			{
				ArrayList arrColumnasWhere = new ArrayList();
				arrColumnasWhere.Add(whereField.ToString());
				ArrayList arrValoresWhere = new ArrayList();
				arrValoresWhere.Add(valueField.ToString());
				
				return FuncionesSum(refField, arrColumnasWhere, arrValoresWhere);
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}

		/// <summary>
		/// 	Funcion que devuelve el resultado de la funcion [SQL] SUM
		/// </summary>
		/// <param name="refField" type="EntSegMensajeserror.Fileds">
		///     <para>
		/// 		 Campo al que se va a aplicar la funcion
		///     </para>
		/// </param>
		/// <param name="arrColumnasWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las columnas WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="arrValoresWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las valores WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo EntSegMensajeserror que cumple con los filtros de los parametros
		/// </returns>
		public int FuncionesSum(EntSegMensajeserror.Fields refField, ArrayList arrColumnasWhere, ArrayList arrValoresWhere)
		{
			try
			{
				ArrayList arrColumnas = new ArrayList();
				arrColumnas.Add("sum(" + refField + ")");
				DataTable dtTemp = ObtenerDataTable(arrColumnas, arrColumnasWhere, arrValoresWhere);
				if (dtTemp.Rows.Count == 0)
					throw new Exception("La consulta no ha devuelto resultados.");
				if (dtTemp.Rows.Count > 1)
					throw new Exception("Se ha devuelto mas de una fila.");
				if (dtTemp.Rows[0][0] == null)
					return 0;
				if (dtTemp.Rows[0][0] == "")
					return 0;
				return int.Parse(dtTemp.Rows[0][0].ToString());
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}

		/// <summary>
		/// 	Funcion que devuelve el resultado de la funcion [SQL] AVG
		/// </summary>
		/// <param name="refField" type="EntSegMensajeserror.Fileds">
		///     <para>
		/// 		 Campo al que se va a aplicar la funcion
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo EntSegMensajeserror que cumple con los filtros de los parametros
		/// </returns>
		public int FuncionesAvg(EntSegMensajeserror.Fields refField)
		{
			try
			{
				ArrayList arrColumnasWhere = new ArrayList();
				arrColumnasWhere.Add(1);
				ArrayList arrValoresWhere = new ArrayList();
				arrValoresWhere.Add(1);
				
				return FuncionesAvg(refField, arrColumnasWhere, arrValoresWhere);
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}

		/// <summary>
		/// 	Funcion que devuelve el resultado de la funcion [SQL] AVG
		/// </summary>
		/// <param name="refField" type="EntSegMensajeserror.Fileds">
		///     <para>
		/// 		 Campo al que se va a aplicar la funcion
		///     </para>
		/// </param>
		/// <param name="whereField" type="EntSegMensajeserror.Fileds">
		///     <para>
		/// 		 Columna que va a filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="valueField" type="System.Object">
		///     <para>
		/// 		 Valor para filtrar el resultado
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo EntSegMensajeserror que cumple con los filtros de los parametros
		/// </returns>
		public int FuncionesAvg(EntSegMensajeserror.Fields refField, EntSegMensajeserror.Fields whereField, object valueField)
		{
			try
			{
				ArrayList arrColumnasWhere = new ArrayList();
				arrColumnasWhere.Add(whereField.ToString());
				ArrayList arrValoresWhere = new ArrayList();
				arrValoresWhere.Add(valueField.ToString());
				
				return FuncionesAvg(refField, arrColumnasWhere, arrValoresWhere);
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}

		/// <summary>
		/// 	Funcion que devuelve el resultado de la funcion [SQL] AVG
		/// </summary>
		/// <param name="refField" type="EntSegMensajeserror.Fileds">
		///     <para>
		/// 		 Campo al que se va a aplicar la funcion
		///     </para>
		/// </param>
		/// <param name="arrColumnasWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las columnas WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="arrValoresWhere" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las valores WHERE para filtrar el resultado
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo EntSegMensajeserror que cumple con los filtros de los parametros
		/// </returns>
		public int FuncionesAvg(EntSegMensajeserror.Fields refField, ArrayList arrColumnasWhere, ArrayList arrValoresWhere)
		{
			try
			{
				ArrayList arrColumnas = new ArrayList();
				arrColumnas.Add("avg(" + refField + ")");
				DataTable dtTemp = ObtenerDataTable(arrColumnas, arrColumnasWhere, arrValoresWhere);
				if (dtTemp.Rows.Count == 0)
					throw new Exception("La consulta no ha devuelto resultados.");
				if (dtTemp.Rows.Count > 1)
					throw new Exception("Se ha devuelto mas de una fila.");
				if (dtTemp.Rows[0][0] == null)
					return 0;
				if (dtTemp.Rows[0][0] == "")
					return 0;
				return int.Parse(dtTemp.Rows[0][0].ToString());
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}


		#endregion 

		#region ABMs

		/// <summary>
		/// 	Funcion que inserta un nuevo registro en la tabla segmensajeserror a partir de una clase del tipo Esegmensajeserror
		/// </summary>
		/// <param name="obj" type="Entidades.EntSegMensajeserror">
		///     <para>
		/// 		 Clase desde la que se van a insertar los valores a la tabla segmensajeserror
		///     </para>
		/// </param>
		/// <returns>
		/// 	 Valor TRUE or FALSE que indica el exito de la operacionsegmensajeserror
		/// </returns>
		public bool Insert(EntSegMensajeserror obj)
		{
			throw new Exception("No existe el Procedimiento Almacenado spSmeIns.");
		}

		/// <summary>
		/// 	Funcion que inserta un nuevo registro en la tabla segmensajeserror a partir de una clase del tipo Esegmensajeserror
		/// </summary>
		/// <param name="obj" type="Entidades.EntSegMensajeserror">
		///     <para>
		/// 		 Clase desde la que se van a insertar los valores a la tabla segmensajeserror
		///     </para>
		/// </param>
		/// <param name="localTrans" type="App_Class.Conexion.CTrans">
		///     <para>
		/// 		 Clase desde la que se va a utilizar una transaccion segmensajeserror
		///     </para>
		/// </param>
		/// <returns>
		/// 	 Valor TRUE or FALSE que indica el exito de la operacionsegmensajeserror
		/// </returns>
		public bool Insert(EntSegMensajeserror obj, ref CTrans localTrans)
		{
			throw new Exception("No existe el Procedimiento Almacenado spSmeIns.");
		}

		/// <summary>
		/// 	Funcion que inserta un nuevo registro en la tabla segmensajeserror a partir de una clase del tipo Esegmensajeserror
		/// </summary>
		/// <param name="obj" type="Entidades.EntSegMensajeserror">
		///     <para>
		/// 		 Clase desde la que se van a insertar los valores a la tabla segmensajeserror
		///     </para>
		/// </param>
		/// <returns>
		/// 	 Valor que indica la cantidad de registros actualizados en segmensajeserror
		/// </returns>
		public int Update(EntSegMensajeserror obj, bool bValidar = true)
		{
			try
			{
				if (bValidar)
					if (!obj.IsValid())
						throw new Exception(obj.ValidationErrorsString());
				ArrayList arrNombreParam = new ArrayList();
				ArrayList arrValoresParam = new ArrayList();
				arrNombreParam.Add(EntSegMensajeserror.Fields.errorsme.ToString());
				arrValoresParam.Add(obj.errorsme);
				
				arrNombreParam.Add(EntSegMensajeserror.Fields.aplicacionsap.ToString());
				arrValoresParam.Add(obj.aplicacionsap);
				
				arrNombreParam.Add(EntSegMensajeserror.Fields.aplicacionerrorsme.ToString());
				arrValoresParam.Add(obj.aplicacionerrorsme);
				
				arrNombreParam.Add(EntSegMensajeserror.Fields.descripcionsme.ToString());
				arrValoresParam.Add(obj.descripcionsme);
				
				arrNombreParam.Add(EntSegMensajeserror.Fields.causasme.ToString());
				arrValoresParam.Add(obj.causasme);
				
				arrNombreParam.Add(EntSegMensajeserror.Fields.accionsme.ToString());
				arrValoresParam.Add(obj.accionsme);
				
				arrNombreParam.Add(EntSegMensajeserror.Fields.comentariosme.ToString());
				arrValoresParam.Add(obj.comentariosme);
				
				arrNombreParam.Add(EntSegMensajeserror.Fields.origensme.ToString());
				arrValoresParam.Add(obj.origensme);
				
				arrNombreParam.Add(EntSegMensajeserror.Fields.apitransaccionsme.ToString());
				arrValoresParam.Add(obj.apitransaccionsme);
				
				arrNombreParam.Add(EntSegMensajeserror.Fields.usumodsme.ToString());
				arrValoresParam.Add(obj.usumodsme);
				
				
				//Llamamos al Procedmiento Almacenado
				CConn local = new CConn();
				string nombreSp = CListadoSp.SegMensajeserror.spSmeUpd.ToString();
				return local.execStoreProcedure(nombreSp, arrNombreParam, arrValoresParam);
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}

		/// <summary>
		/// 	Funcion que inserta un nuevo registro en la tabla segmensajeserror a partir de una clase del tipo Esegmensajeserror
		/// </summary>
		/// <param name="obj" type="Entidades.EntSegMensajeserror">
		///     <para>
		/// 		 Clase desde la que se van a insertar los valores a la tabla segmensajeserror
		///     </para>
		/// </param>
		/// <param name="localTrans" type="App_Class.Conexion.CTrans">
		///     <para>
		/// 		 Clase desde la que se va a utilizar una transaccion segmensajeserror
		///     </para>
		/// </param>
		/// <returns>
		/// 	 Valor TRUE or FALSE que indica el exito de la operacionsegmensajeserror
		/// </returns>
		public int Update(EntSegMensajeserror obj, ref CTrans localTrans, bool bValidar = true)
		{
			try
			{
				if (bValidar)
					if (!obj.IsValid())
						throw new Exception(obj.ValidationErrorsString());
				ArrayList arrNombreParam = new ArrayList();
				ArrayList arrValoresParam = new ArrayList();
				arrNombreParam.Add(EntSegMensajeserror.Fields.errorsme.ToString());
				arrValoresParam.Add(obj.errorsme);
				
				arrNombreParam.Add(EntSegMensajeserror.Fields.aplicacionsap.ToString());
				arrValoresParam.Add(obj.aplicacionsap);
				
				arrNombreParam.Add(EntSegMensajeserror.Fields.aplicacionerrorsme.ToString());
				arrValoresParam.Add(obj.aplicacionerrorsme);
				
				arrNombreParam.Add(EntSegMensajeserror.Fields.descripcionsme.ToString());
				arrValoresParam.Add(obj.descripcionsme);
				
				arrNombreParam.Add(EntSegMensajeserror.Fields.causasme.ToString());
				arrValoresParam.Add(obj.causasme);
				
				arrNombreParam.Add(EntSegMensajeserror.Fields.accionsme.ToString());
				arrValoresParam.Add(obj.accionsme);
				
				arrNombreParam.Add(EntSegMensajeserror.Fields.comentariosme.ToString());
				arrValoresParam.Add(obj.comentariosme);
				
				arrNombreParam.Add(EntSegMensajeserror.Fields.origensme.ToString());
				arrValoresParam.Add(obj.origensme);
				
				arrNombreParam.Add(EntSegMensajeserror.Fields.apitransaccionsme.ToString());
				arrValoresParam.Add(obj.apitransaccionsme);
				
				arrNombreParam.Add(EntSegMensajeserror.Fields.usumodsme.ToString());
				arrValoresParam.Add(obj.usumodsme);
				
				
				//Llamamos al Procedmiento Almacenado
				CConn local = new CConn();
				string nombreSp = CListadoSp.SegMensajeserror.spSmeUpd.ToString();
				return local.execStoreProcedure(nombreSp, arrNombreParam, arrValoresParam, ref localTrans);
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}

		/// <summary>
		/// 	Funcion que inserta un nuevo registro en la tabla segmensajeserror a partir de una clase del tipo Esegmensajeserror
		/// </summary>
		/// <param name="obj" type="Entidades.EntSegMensajeserror">
		///     <para>
		/// 		 Clase desde la que se van a insertar los valores a la tabla segmensajeserror
		///     </para>
		/// </param>
		/// <returns>
		/// 	 Valor TRUE or FALSE que indica el exito de la operacionsegmensajeserror
		/// </returns>
		public int Delete(EntSegMensajeserror obj, bool bValidar = true)
		{
			try
			{
				if (bValidar)
					if (!obj.IsValid())
						throw new Exception(obj.ValidationErrorsString());
				ArrayList arrNombreParam = new ArrayList();
				ArrayList arrValoresParam = new ArrayList();
				arrNombreParam.Add(EntSegMensajeserror.Fields.errorsme.ToString());
				arrValoresParam.Add(obj.errorsme);
				
				arrNombreParam.Add(EntSegMensajeserror.Fields.aplicacionsap.ToString());
				arrValoresParam.Add(obj.aplicacionsap);
				
				
				//Llamamos al Procedmiento Almacenado
				CConn local = new CConn();
				string nombreSp = CListadoSp.SegMensajeserror.spSmeDel.ToString();
				return local.execStoreProcedure(nombreSp, arrNombreParam, arrValoresParam);
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}

		/// <summary>
		/// 	Funcion que inserta un nuevo registro en la tabla segmensajeserror a partir de una clase del tipo Esegmensajeserror
		/// </summary>
		/// <param name="obj" type="Entidades.EntSegMensajeserror">
		///     <para>
		/// 		 Clase desde la que se van a insertar los valores a la tabla segmensajeserror
		///     </para>
		/// </param>
		/// <param name="localTrans" type="App_Class.Conexion.CTrans">
		///     <para>
		/// 		 Clase desde la que se va a utilizar una transaccion segmensajeserror
		///     </para>
		/// </param>
		/// <returns>
		/// 	 Valor TRUE or FALSE que indica el exito de la operacionsegmensajeserror
		/// </returns>
		public int Delete(EntSegMensajeserror obj, ref CTrans localTrans, bool bValidar = true)
		{
			try
			{
				if (bValidar)
					if (!obj.IsValid())
						throw new Exception(obj.ValidationErrorsString());
				ArrayList arrNombreParam = new ArrayList();
				ArrayList arrValoresParam = new ArrayList();
				arrNombreParam.Add(EntSegMensajeserror.Fields.errorsme.ToString());
				arrValoresParam.Add(obj.errorsme);
				
				arrNombreParam.Add(EntSegMensajeserror.Fields.aplicacionsap.ToString());
				arrValoresParam.Add(obj.aplicacionsap);
				
				
				//Llamamos al Procedmiento Almacenado
				CConn local = new CConn();
				string nombreSp = CListadoSp.SegMensajeserror.spSmeDel.ToString();
				return local.execStoreProcedure(nombreSp, arrNombreParam, arrValoresParam, ref localTrans);
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}

		/// <summary>
		/// 	Funcion que inserta o actualiza un registro un nuevo registro en la tabla segmensajeserror a partir de una clase del tipo Esegmensajeserror
		/// </summary>
		/// <param name="obj" type="Entidades.EntSegMensajeserror">
		///     <para>
		/// 		 Clase desde la que se van a insertar o actualizar los valores a la tabla segmensajeserror
		///     </para>
		/// </param>
		/// <returns>
		/// 	 Valor TRUE or FALSE que indica el exito de la operacionsegmensajeserror
		/// </returns>
		public int InsertUpdate(EntSegMensajeserror obj)
		{
			try
			{
				bool esInsertar = true;
				
					esInsertar = (esInsertar && (obj.errorsme == null));
					esInsertar = (esInsertar && (obj.aplicacionsap == null));
				
				if (esInsertar)
					return Insert(obj) ? 1 : 0;
				else
					return Update(obj);
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}

		/// <summary>
		/// 	Funcion que inserta o actualiza un registro un nuevo registro en la tabla segmensajeserror a partir de una clase del tipo Esegmensajeserror
		/// </summary>
		/// <param name="obj" type="Entidades.EntSegMensajeserror">
		///     <para>
		/// 		 Clase desde la que se van a insertar o actualizar los valores a la tabla segmensajeserror
		///     </para>
		/// </param>
		/// <param name="localTrans" type="App_Class.Conexion.CTrans">
		///     <para>
		/// 		 Clase desde la que se va a utilizar una transaccion segmensajeserror
		///     </para>
		/// </param>
		/// <returns>
		/// 	 Valor TRUE or FALSE que indica el exito de la operacionsegmensajeserror
		/// </returns>
		public int InsertUpdate(EntSegMensajeserror obj, ref CTrans localTrans)
		{
			try
			{
				bool esInsertar = false;
				
					esInsertar = (esInsertar && (obj.errorsme == null));
					esInsertar = (esInsertar && (obj.aplicacionsap == null));
				
				if (esInsertar)
					return Insert(obj, ref localTrans) ? 1 : 0;
				else
					return Update(obj, ref localTrans);
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}


		#endregion 

		#region Llenado de elementos


		#endregion 


		#endregion

		#region Funciones Internas

		/// <summary>
		/// 	 Funcion que devuelve un objeto a partir de un DataRow
		/// </summary>
		/// <param name="row" type="System.Data.DataRow">
		///     <para>
		/// 		 DataRow con el conjunto de Datos recuperados 
		///     </para>
		/// </param>
		/// <returns>
		/// 	 Objeto segmensajeserror
		/// </returns>
		internal EntSegMensajeserror crearObjeto(DataRow row)
		{
			EntSegMensajeserror obj = new EntSegMensajeserror();
			obj.errorsme = GetColumnType(row[EntSegMensajeserror.Fields.errorsme.ToString()], EntSegMensajeserror.Fields.errorsme);
			obj.aplicacionsap = GetColumnType(row[EntSegMensajeserror.Fields.aplicacionsap.ToString()], EntSegMensajeserror.Fields.aplicacionsap);
			obj.aplicacionerrorsme = GetColumnType(row[EntSegMensajeserror.Fields.aplicacionerrorsme.ToString()], EntSegMensajeserror.Fields.aplicacionerrorsme);
			obj.descripcionsme = GetColumnType(row[EntSegMensajeserror.Fields.descripcionsme.ToString()], EntSegMensajeserror.Fields.descripcionsme);
			obj.causasme = GetColumnType(row[EntSegMensajeserror.Fields.causasme.ToString()], EntSegMensajeserror.Fields.causasme);
			obj.accionsme = GetColumnType(row[EntSegMensajeserror.Fields.accionsme.ToString()], EntSegMensajeserror.Fields.accionsme);
			obj.comentariosme = GetColumnType(row[EntSegMensajeserror.Fields.comentariosme.ToString()], EntSegMensajeserror.Fields.comentariosme);
			obj.origensme = GetColumnType(row[EntSegMensajeserror.Fields.origensme.ToString()], EntSegMensajeserror.Fields.origensme);
			obj.apiestadosme = GetColumnType(row[EntSegMensajeserror.Fields.apiestadosme.ToString()], EntSegMensajeserror.Fields.apiestadosme);
			obj.apitransaccionsme = GetColumnType(row[EntSegMensajeserror.Fields.apitransaccionsme.ToString()], EntSegMensajeserror.Fields.apitransaccionsme);
			obj.usucresme = GetColumnType(row[EntSegMensajeserror.Fields.usucresme.ToString()], EntSegMensajeserror.Fields.usucresme);
			obj.feccresme = GetColumnType(row[EntSegMensajeserror.Fields.feccresme.ToString()], EntSegMensajeserror.Fields.feccresme);
			obj.usumodsme = GetColumnType(row[EntSegMensajeserror.Fields.usumodsme.ToString()], EntSegMensajeserror.Fields.usumodsme);
			obj.fecmodsme = GetColumnType(row[EntSegMensajeserror.Fields.fecmodsme.ToString()], EntSegMensajeserror.Fields.fecmodsme);
			return obj;
		}

		/// <summary>
		/// 	 Funcion que devuelve un objeto a partir de un DataRow
		/// </summary>
		/// <param name="row" type="System.Data.DataRow">
		///     <para>
		/// 		 DataRow con el conjunto de Datos recuperados 
		///     </para>
		/// </param>
		/// <returns>
		/// 	 Objeto segmensajeserror
		/// </returns>
		internal EntSegMensajeserror crearObjetoRevisado(DataRow row)
		{
			EntSegMensajeserror obj = new EntSegMensajeserror();
			if (row.Table.Columns.Contains(EntSegMensajeserror.Fields.errorsme.ToString()))
				obj.errorsme = GetColumnType(row[EntSegMensajeserror.Fields.errorsme.ToString()], EntSegMensajeserror.Fields.errorsme);
			if (row.Table.Columns.Contains(EntSegMensajeserror.Fields.aplicacionsap.ToString()))
				obj.aplicacionsap = GetColumnType(row[EntSegMensajeserror.Fields.aplicacionsap.ToString()], EntSegMensajeserror.Fields.aplicacionsap);
			if (row.Table.Columns.Contains(EntSegMensajeserror.Fields.aplicacionerrorsme.ToString()))
				obj.aplicacionerrorsme = GetColumnType(row[EntSegMensajeserror.Fields.aplicacionerrorsme.ToString()], EntSegMensajeserror.Fields.aplicacionerrorsme);
			if (row.Table.Columns.Contains(EntSegMensajeserror.Fields.descripcionsme.ToString()))
				obj.descripcionsme = GetColumnType(row[EntSegMensajeserror.Fields.descripcionsme.ToString()], EntSegMensajeserror.Fields.descripcionsme);
			if (row.Table.Columns.Contains(EntSegMensajeserror.Fields.causasme.ToString()))
				obj.causasme = GetColumnType(row[EntSegMensajeserror.Fields.causasme.ToString()], EntSegMensajeserror.Fields.causasme);
			if (row.Table.Columns.Contains(EntSegMensajeserror.Fields.accionsme.ToString()))
				obj.accionsme = GetColumnType(row[EntSegMensajeserror.Fields.accionsme.ToString()], EntSegMensajeserror.Fields.accionsme);
			if (row.Table.Columns.Contains(EntSegMensajeserror.Fields.comentariosme.ToString()))
				obj.comentariosme = GetColumnType(row[EntSegMensajeserror.Fields.comentariosme.ToString()], EntSegMensajeserror.Fields.comentariosme);
			if (row.Table.Columns.Contains(EntSegMensajeserror.Fields.origensme.ToString()))
				obj.origensme = GetColumnType(row[EntSegMensajeserror.Fields.origensme.ToString()], EntSegMensajeserror.Fields.origensme);
			if (row.Table.Columns.Contains(EntSegMensajeserror.Fields.apiestadosme.ToString()))
				obj.apiestadosme = GetColumnType(row[EntSegMensajeserror.Fields.apiestadosme.ToString()], EntSegMensajeserror.Fields.apiestadosme);
			if (row.Table.Columns.Contains(EntSegMensajeserror.Fields.apitransaccionsme.ToString()))
				obj.apitransaccionsme = GetColumnType(row[EntSegMensajeserror.Fields.apitransaccionsme.ToString()], EntSegMensajeserror.Fields.apitransaccionsme);
			if (row.Table.Columns.Contains(EntSegMensajeserror.Fields.usucresme.ToString()))
				obj.usucresme = GetColumnType(row[EntSegMensajeserror.Fields.usucresme.ToString()], EntSegMensajeserror.Fields.usucresme);
			if (row.Table.Columns.Contains(EntSegMensajeserror.Fields.feccresme.ToString()))
				obj.feccresme = GetColumnType(row[EntSegMensajeserror.Fields.feccresme.ToString()], EntSegMensajeserror.Fields.feccresme);
			if (row.Table.Columns.Contains(EntSegMensajeserror.Fields.usumodsme.ToString()))
				obj.usumodsme = GetColumnType(row[EntSegMensajeserror.Fields.usumodsme.ToString()], EntSegMensajeserror.Fields.usumodsme);
			if (row.Table.Columns.Contains(EntSegMensajeserror.Fields.fecmodsme.ToString()))
				obj.fecmodsme = GetColumnType(row[EntSegMensajeserror.Fields.fecmodsme.ToString()], EntSegMensajeserror.Fields.fecmodsme);
			return obj;
		}

		/// <summary>
		/// 	 Funcion que crea una Lista de objetos a partir de un DataTable
		/// </summary>
		/// <param name="dtsegmensajeserror" type="System.Data.DateTable">
		///     <para>
		/// 		 DataTable con el conjunto de Datos recuperados 
		///     </para>
		/// </param>
		/// <returns>
		/// 	 Lista de Objetos segmensajeserror
		/// </returns>
		internal List<EntSegMensajeserror> crearLista(DataTable dtsegmensajeserror)
		{
			List<EntSegMensajeserror> list = new List<EntSegMensajeserror>();
			
			EntSegMensajeserror obj = new EntSegMensajeserror();
			foreach (DataRow row in dtsegmensajeserror.Rows)
			{
				obj = crearObjeto(row);
				list.Add(obj);
			}
			return list;
		}
		
		/// <summary>
		/// 	 Funcion que crea una Lista de objetos a partir de un DataTable y con solo algunas columnas
		/// </summary>
		/// <param name="dtsegmensajeserror" type="System.Data.DateTable">
		///     <para>
		/// 		 DataTable con el conjunto de Datos recuperados 
		///     </para>
		/// </param>
		/// <returns>
		/// 	 Lista de Objetos segmensajeserror
		/// </returns>
		internal List<EntSegMensajeserror> crearListaRevisada(DataTable dtsegmensajeserror)
		{
			List<EntSegMensajeserror> list = new List<EntSegMensajeserror>();
			
			EntSegMensajeserror obj = new EntSegMensajeserror();
			foreach (DataRow row in dtsegmensajeserror.Rows)
			{
				obj = crearObjetoRevisado(row);
				list.Add(obj);
			}
			return list;
		}
		
		/// <summary>
		/// 	 Funcion que crea una Lista de objetos a partir de un DataTable
		/// </summary>
		/// <param name="dtsegmensajeserror" type="System.Data.DateTable">
		///     <para>
		/// 		 DataTable con el conjunto de Datos recuperados 
		///     </para>
		/// </param>
		/// <returns>
		/// 	 Cola de Objetos segmensajeserror
		/// </returns>
		internal Queue<EntSegMensajeserror> crearCola(DataTable dtsegmensajeserror)
		{
			Queue<EntSegMensajeserror> cola = new Queue<EntSegMensajeserror>();
			
			EntSegMensajeserror obj = new EntSegMensajeserror();
			foreach (DataRow row in dtsegmensajeserror.Rows)
			{
				obj = crearObjeto(row);
				cola.Enqueue(obj);
			}
			return cola;
		}
		
		/// <summary>
		/// 	 Funcion que crea una Lista de objetos a partir de un DataTable
		/// </summary>
		/// <param name="dtsegmensajeserror" type="System.Data.DateTable">
		///     <para>
		/// 		 DataTable con el conjunto de Datos recuperados 
		///     </para>
		/// </param>
		/// <returns>
		/// 	 Pila de Objetos segmensajeserror
		/// </returns>
		internal Stack<EntSegMensajeserror> crearPila(DataTable dtsegmensajeserror)
		{
			Stack<EntSegMensajeserror> pila = new Stack<EntSegMensajeserror>();
			
			EntSegMensajeserror obj = new EntSegMensajeserror();
			foreach (DataRow row in dtsegmensajeserror.Rows)
			{
				obj = crearObjeto(row);
				pila.Push(obj);
			}
			return pila;
		}
		
		/// <summary>
		/// 	 Funcion que crea un Dicionario a partir de un DataTable
		/// </summary>
		/// <param name="dtsegmensajeserror" type="System.Data.DateTable">
		///     <para>
		/// 		 DataTable con el conjunto de Datos recuperados 
		///     </para>
		/// </param>
		/// <returns>
		/// 	 Diccionario de Objetos segmensajeserror
		/// </returns>
		internal Dictionary<String, EntSegMensajeserror> crearDiccionario(DataTable dtsegmensajeserror)
		{
			Dictionary<String, EntSegMensajeserror>  miDic = new Dictionary<String, EntSegMensajeserror>();
			
			EntSegMensajeserror obj = new EntSegMensajeserror();
			foreach (DataRow row in dtsegmensajeserror.Rows)
			{
				obj = crearObjeto(row);
				miDic.Add(obj.GetHashCode().ToString(), obj);
			}
			return miDic;
		}
		
		/// <summary>
		/// 	 Funcion que crea un Dicionario a partir de un DataTable
		/// </summary>
		/// <param name="dtsegmensajeserror" type="System.Data.DateTable">
		///     <para>
		/// 		 DataTable con el conjunto de Datos recuperados 
		///     </para>
		/// </param>
		/// <returns>
		/// 	 HashTable de Objetos segmensajeserror
		/// </returns>
		internal Hashtable crearHashTable(DataTable dtsegmensajeserror)
		{
			Hashtable miTabla = new Hashtable();
			
			EntSegMensajeserror obj = new EntSegMensajeserror();
			foreach (DataRow row in dtsegmensajeserror.Rows)
			{
				obj = crearObjeto(row);
				miTabla.Add(obj.GetHashCode().ToString(), obj);
			}
			return miTabla;
		}
		
		/// <summary>
		/// 	 Funcion que crea un Dicionario a partir de un DataTable y solo con columnas existentes
		/// </summary>
		/// <param name="dtsegmensajeserror" type="System.Data.DateTable">
		///     <para>
		/// 		 DataTable con el conjunto de Datos recuperados 
		///     </para>
		/// </param>
		/// <returns>
		/// 	 Diccionario de Objetos segmensajeserror
		/// </returns>
		internal Dictionary<String, EntSegMensajeserror> crearDiccionarioRevisado(DataTable dtsegmensajeserror)
		{
			Dictionary<String, EntSegMensajeserror>  miDic = new Dictionary<String, EntSegMensajeserror>();
			
			EntSegMensajeserror obj = new EntSegMensajeserror();
			foreach (DataRow row in dtsegmensajeserror.Rows)
			{
				obj = crearObjetoRevisado(row);
				miDic.Add(obj.GetHashCode().ToString(), obj);
			}
			return miDic;
		}
		
		internal Dictionary<String, EntSegMensajeserror> crearDiccionario(DataTable dtsegmensajeserror, EntSegMensajeserror.Fields dicKey)
		{
			Dictionary<String, EntSegMensajeserror>  miDic = new Dictionary<String, EntSegMensajeserror>();
			
			EntSegMensajeserror obj = new EntSegMensajeserror();
			foreach (DataRow row in dtsegmensajeserror.Rows)
			{
				obj = crearObjeto(row);
				
				var nameOfProperty = dicKey.ToString();
				var propertyInfo = obj.GetType().GetProperty(nameOfProperty);
				var value = propertyInfo.GetValue(obj, null);
				
				miDic.Add(value.ToString(), obj);
			}
			return miDic;
		}
		
		public void Dispose()
		{
			GC.SuppressFinalize(this);
		}
		
		protected void Finalize()
		{
			Dispose();
		}
		#endregion

	}
}

