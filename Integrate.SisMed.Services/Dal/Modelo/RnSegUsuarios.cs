#region 
/***********************************************************************************************************
	NOMBRE:       RnSegUsuarios
	DESCRIPCION:
		Clase que implmenta los metodos y operaciones sobre la Tabla segusuarios

	REVISIONES:
		Ver        FECHA       Autor            Descripcion 
		---------  ----------  ---------------  ------------------------------------
		1.0        06/10/2017  R Alonzo Vera A  Creacion 

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
using Integrate.SisMed.BusinessObjects;
using Integrate.SisMed.Services.Dal; 
using Integrate.SisMed.Services.Conn;
using Integrate.SisMed.Services.Dal.Interface;
#endregion

namespace Integrate.SisMed.Services.Dal.Modelo
{
	public class RnSegUsuarios: ISegUsuarios
	{
		//Debe implementar la Interface (Alt + Shift + F10)

		#region ISegUsuarios Members

		#region Reflection

		/// <summary>
		/// Metodo que devuelve el Script SQL de la Tabla
		/// </summary>
		/// <returns>Script SQL</returns>
		public string GetTableScript()
		{
			TableClass tabla = new TableClass(typeof(EntSegUsuarios));
			return tabla.CreateTableScript();
		}
		
		/// <summary>
		/// Metodo para castear Dinamicamente un Tipo
		/// </summary>
		/// <param name="valor">Tipo a ser casteado</param>
		/// <param name="myField">Enum de la columna</param>
		/// <returns>Devuelve un objeto del Tipo de la columna especificada en el Enum</returns>
		public dynamic GetColumnType(object valor, EntSegUsuarios.Fields myField)
		{
			if (DBNull.Value.Equals(valor)) 
				return null;
			Type destino = typeof(EntSegUsuarios).GetProperty(myField.ToString()).PropertyType;
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
			Type destino = typeof(EntSegUsuarios).GetProperty(strField).PropertyType;
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
        public void SetDato(ref EntSegUsuarios obj, string strPropiedad, object dynValor)
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
        public dynamic GetDato(ref EntSegUsuarios obj, string strPropiedad)
        {
	        if (obj == null) return null;
	        var propertyInfo = obj.GetType().GetProperty(strPropiedad);
	        return GetColumnType(propertyInfo.GetValue(obj, null), strPropiedad);
        }

		/// <summary>
		/// 	 Funcion que obtiene la llave primaria unica de la tabla segusuarios a partir de una cadena
		/// </summary>
		/// <param name="args" type="string[]">
		///     <para>
		/// 		 Cadena desde la que se construye el identificador unico de la tabla segusuarios
		///     </para>
		/// </param>
		/// <returns>
		/// 	 Identificador unico de la tabla segusuarios
		/// </returns>
		public string CreatePk(string[] args)
		{
			return args[0];
		}
		
		#endregion 

		#region ObtenerObjeto

		/// <summary>
		/// 	Funcion que obtiene los datos de una Clase EntSegUsuarios a partir de la llave primaria
		/// </summary>
		/// <returns>
		/// 	Valor del Tipo EntSegUsuarios que cumple con los filtros de los parametros
		/// </returns>
		public EntSegUsuarios ObtenerObjeto(int intidsus)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add(EntSegUsuarios.Fields.idsus.ToString());
		
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add(intidsus);
			
			return ObtenerObjeto(arrColumnasWhere, arrValoresWhere);
		}
		
		/// <summary>
		/// 	Funcion que obtiene los datos de una Clase EntSegUsuarios a partir del usuario que inserta
		/// </summary>
		/// <param name="strUsuCre">Login o nombre de usuario</param>
		/// <returns>
		/// 	Valor del Tipo EntSegUsuarios que cumple con los filtros de los parametros
		/// </returns>
		public EntSegUsuarios ObtenerObjetoInsertado(string strUsuCre)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add(EntSegUsuarios.Fields.usucresus.ToString());
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add("'" + strUsuCre + "'");
			
			int iIdInsertado = FuncionesMax(EntSegUsuarios.Fields.idsus, arrColumnasWhere, arrValoresWhere);
			
			return ObtenerObjeto(iIdInsertado);
		}
		
		/// <summary>
		/// 	Funcion que obtiene los datos de una Clase EntSegUsuarios a partir de condiciones WHERE
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
		/// 	Valor del Tipo EntSegUsuarios que cumple con los filtros de los parametros
		/// </returns>
		public EntSegUsuarios ObtenerObjeto(ArrayList arrColumnasWhere, ArrayList arrValoresWhere)
		{
			return ObtenerObjeto(arrColumnasWhere, arrValoresWhere, "");
		}
		
		/// <summary>
		/// 	Funcion que obtiene los datos de una Clase EntSegUsuarios a partir de condiciones WHERE
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
		/// 	Valor del Tipo EntSegUsuarios que cumple con los filtros de los parametros
		/// </returns>
		public EntSegUsuarios ObtenerObjeto(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParamAdicionales)
		{
			try
			{
				ArrayList arrColumnas = new ArrayList();
				arrColumnas.Add(EntSegUsuarios.Fields.idsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.loginsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.passsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.nombresus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.apellidosus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.vigentesus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.fechavigentesus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.fechapasssus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.apiestadosus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.apitransaccionsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.usucresus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.feccresus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.usumodsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.fecmodsus.ToString());
				
				CConn local = new CConn();
				DataTable table = local.cargarDataTableAnd(CParametros.Schema + EntSegUsuarios.StrNombreTabla, arrColumnas, arrColumnasWhere, arrValoresWhere, strParamAdicionales);
				
				if (table.Rows.Count == 1)
				{
					EntSegUsuarios obj = new EntSegUsuarios();
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
		/// 	Funcion que obtiene los datos de una Clase EntSegUsuarios a partir de condiciones WHERE
		/// </summary>
		/// <param name="htbFiltro" type="System.Collections.Hashtable">
		///     <para>
		/// 		 Hashtable que contienen los pares para filtrar el resultado
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo EntSegUsuarios que cumple con los filtros de los parametros
		/// </returns>
		public EntSegUsuarios ObtenerObjeto(Hashtable htbFiltro)
		{
			return ObtenerObjeto(htbFiltro, "");
		}
		
		/// <summary>
		/// 	Funcion que obtiene los datos de una Clase EntSegUsuarios a partir de condiciones WHERE
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
		/// 	Valor del Tipo EntSegUsuarios que cumple con los filtros de los parametros
		/// </returns>
		public EntSegUsuarios ObtenerObjeto(Hashtable htbFiltro, string strParamAdicionales)
		{
			try
			{
				ArrayList arrColumnas = new ArrayList();
				arrColumnas.Add(EntSegUsuarios.Fields.idsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.loginsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.passsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.nombresus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.apellidosus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.vigentesus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.fechavigentesus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.fechapasssus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.apiestadosus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.apitransaccionsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.usucresus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.feccresus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.usumodsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.fecmodsus.ToString());
				
				ArrayList arrColumnasWhere = new ArrayList();
				ArrayList arrValoresWhere = new ArrayList();
				
				foreach (DictionaryEntry entry in htbFiltro)
				{
					arrColumnasWhere.Add(entry.Key.ToString());
					arrValoresWhere.Add(entry.Value.ToString());
				}
				
				CConn local = new CConn();
				DataTable table = local.cargarDataTableAnd(CParametros.Schema + EntSegUsuarios.StrNombreTabla, arrColumnas, arrColumnasWhere, arrValoresWhere, strParamAdicionales);
				
				if (table.Rows.Count == 1)
				{
					EntSegUsuarios obj = new EntSegUsuarios();
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
		/// 	Funcion que obtiene los datos de una Clase EntSegUsuarios a partir de condiciones WHERE
		/// </summary>
		/// <param name="searchField" type="EntSegUsuarios.Fileds">
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
		/// 	Valor del Tipo EntSegUsuarios que cumple con los filtros de los parametros
		/// </returns>
		public EntSegUsuarios ObtenerObjeto(EntSegUsuarios.Fields searchField, object searchValue)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add(searchField.ToString());
			
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add(searchValue);
			
			return ObtenerObjeto(arrColumnasWhere, arrValoresWhere);
		}
		
		/// <summary>
		/// 	Funcion que obtiene los datos de una Clase EntSegUsuarios a partir de condiciones WHERE
		/// </summary>
		/// <param name="searchField" type="EntSegUsuarios.Fileds">
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
		/// 	Valor del Tipo EntSegUsuarios que cumple con los filtros de los parametros
		/// </returns>
		public EntSegUsuarios ObtenerObjeto(EntSegUsuarios.Fields searchField, object searchValue, string strParamAdicionales)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add(searchField.ToString());
			
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add(searchValue);
			
			return ObtenerObjeto(arrColumnasWhere, arrValoresWhere, strParamAdicionales);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un Business Object del Tipo EntSegUsuarios a partir de su llave promaria
		/// </summary>
		/// <returns>
		/// 	Objeto del Tipo EntSegUsuarios
		/// </returns>
		public EntSegUsuarios ObtenerObjeto(int intidsus, ref CTrans localTrans )
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add(EntSegUsuarios.Fields.idsus.ToString());
		
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add(intidsus);
			return ObtenerObjeto(arrColumnasWhere, arrValoresWhere, ref localTrans);
		}
		
		/// <summary>
		/// 	Funcion que obtiene los datos de una Clase EntSegUsuarios a partir de condiciones WHERE
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
		/// 		 Clase desde la que se va a utilizar una transaccion segusuarios
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo EntSegUsuarios que cumple con los filtros de los parametros
		/// </returns>
		public EntSegUsuarios ObtenerObjeto(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, ref CTrans localTrans)
		{
			return ObtenerObjeto(arrColumnasWhere, arrValoresWhere, "", ref localTrans);
		}
		
		/// <summary>
		/// 	Funcion que obtiene los datos de una Clase EntSegUsuarios a partir de condiciones WHERE
		/// </summary>
		/// <param name="htbFiltro" type="System.Collections.Hashtable">
		///     <para>
		/// 		 Hashtable que contienen los pares para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="localTrans" type="App_Class.Conexion.CTrans">
		///     <para>
		/// 		 Clase desde la que se va a utilizar una transaccion segusuarios
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo EntSegUsuarios que cumple con los filtros de los parametros
		/// </returns>
		public EntSegUsuarios ObtenerObjeto(Hashtable htbFiltro, ref CTrans localTrans)
		{
			return ObtenerObjeto(htbFiltro, "", ref localTrans);
		}
		
		/// <summary>
		/// 	Funcion que obtiene los datos de una Clase EntSegUsuarios a partir de condiciones WHERE
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
		/// 		 Clase desde la que se va a utilizar una transaccion segusuarios
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo EntSegUsuarios que cumple con los filtros de los parametros
		/// </returns>
		public EntSegUsuarios ObtenerObjeto(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParamAdicionales,  ref CTrans localTrans)
		{
			return ObtenerObjeto(arrColumnasWhere, arrValoresWhere, strParamAdicionales, ref localTrans);
		}
		
		/// <summary>
		/// 	Funcion que obtiene los datos de una Clase EntSegUsuarios a partir de condiciones WHERE
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
		/// 		 Clase desde la que se va a utilizar una transaccion segusuarios
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo EntSegUsuarios que cumple con los filtros de los parametros
		/// </returns>
		public EntSegUsuarios ObtenerObjeto(Hashtable htbFiltro, string strParamAdicionales, ref CTrans localTrans)
		{
			try
			{
				ArrayList arrColumnas = new ArrayList();
				arrColumnas.Add(EntSegUsuarios.Fields.idsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.loginsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.passsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.nombresus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.apellidosus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.vigentesus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.fechavigentesus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.fechapasssus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.apiestadosus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.apitransaccionsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.usucresus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.feccresus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.usumodsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.fecmodsus.ToString());
				
				ArrayList arrColumnasWhere = new ArrayList();
				ArrayList arrValoresWhere = new ArrayList();
				
				foreach (DictionaryEntry entry in htbFiltro)
				{
					arrColumnasWhere.Add(entry.Key.ToString());
					arrValoresWhere.Add(entry.Value.ToString());
				}
				
				CConn local = new CConn();
				DataTable table = local.cargarDataTableAnd(CParametros.Schema + EntSegUsuarios.StrNombreTabla, arrColumnas, arrColumnasWhere, arrValoresWhere, strParamAdicionales, ref localTrans);
				
				if (table.Rows.Count == 1)
				{
					EntSegUsuarios obj = new EntSegUsuarios();
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
		/// 	Funcion que obtiene los datos de una Clase EntSegUsuarios a partir de condiciones WHERE
		/// </summary>
		/// <param name="searchField" type="EntSegUsuarios.Fileds">
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
		/// 		 Clase desde la que se va a utilizar una transaccion segusuarios
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo EntSegUsuarios que cumple con los filtros de los parametros
		/// </returns>
		public EntSegUsuarios ObtenerObjeto(EntSegUsuarios.Fields searchField, object searchValue, ref CTrans localTrans)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add(searchField.ToString());
			
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add(searchValue);
			
			return ObtenerObjeto(arrColumnasWhere, arrValoresWhere, ref localTrans);
		}
		
		/// <summary>
		/// 	Funcion que obtiene los datos de una Clase EntSegUsuarios a partir de condiciones WHERE
		/// </summary>
		/// <param name="searchField" type="EntSegUsuarios.Fileds">
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
		/// 		 Clase desde la que se va a utilizar una transaccion segusuarios
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo EntSegUsuarios que cumple con los filtros de los parametros
		/// </returns>
		public EntSegUsuarios ObtenerObjeto(EntSegUsuarios.Fields searchField, object searchValue, string strParamAdicionales, ref CTrans localTrans)
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
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegUsuarios a partir de condiciones WHERE
		/// </summary>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.List que cumple con los filtros de los parametros
		/// </returns>
		public List<EntSegUsuarios> ObtenerLista()
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add("'1'");
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add("'1'");
			
			return ObtenerLista(arrColumnasWhere, arrValoresWhere);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegUsuarios a partir de condiciones WHERE
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
		public List<EntSegUsuarios> ObtenerLista(ArrayList arrColumnasWhere, ArrayList arrValoresWhere)
		{
			return ObtenerLista(arrColumnasWhere, arrValoresWhere, "");
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegUsuarios a partir de condiciones WHERE
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
		public List<EntSegUsuarios> ObtenerLista(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParamAdicionales)
		{
			try
			{
				ArrayList arrColumnas = new ArrayList();
				arrColumnas.Add(EntSegUsuarios.Fields.idsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.loginsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.passsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.nombresus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.apellidosus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.vigentesus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.fechavigentesus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.fechapasssus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.apiestadosus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.apitransaccionsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.usucresus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.feccresus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.usumodsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.fecmodsus.ToString());
				
				CConn local = new CConn();
				DataTable table = local.cargarDataTableAnd(CParametros.Schema + EntSegUsuarios.StrNombreTabla, arrColumnas, arrColumnasWhere, arrValoresWhere, strParamAdicionales);
				
				if (table.Rows.Count > 0)
				{
					return crearLista(table);
				}
				else
					return new List<EntSegUsuarios>();
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegUsuarios a partir de condiciones WHERE
		/// </summary>
		/// <param name="searchField" type="EntSegUsuarios.Fileds">
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
		public List<EntSegUsuarios> ObtenerLista(EntSegUsuarios.Fields searchField, object searchValue)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add(searchField.ToString());
			
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add(searchValue);
			
			return ObtenerLista(arrColumnasWhere, arrValoresWhere);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegUsuarios a partir de condiciones WHERE
		/// </summary>
		/// <param name="searchField" type="EntSegUsuarios.Fileds">
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
		public List<EntSegUsuarios> ObtenerLista(EntSegUsuarios.Fields searchField, object searchValue, string strParamAdicionales)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add(searchField.ToString());
			
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add(searchValue);
			
			return ObtenerLista(arrColumnasWhere, arrValoresWhere, strParamAdicionales);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegUsuarios a partir de condiciones WHERE
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
		/// 		 Clase desde la que se va a utilizar una transaccion segusuarios
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.List que cumple con los filtros de los parametros
		/// </returns>
		public List<EntSegUsuarios> ObtenerLista(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, ref CTrans localTrans)
		{
			return ObtenerLista(arrColumnasWhere, arrValoresWhere, "", ref localTrans);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegUsuarios a partir de condiciones WHERE
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
		/// 		 Clase desde la que se va a utilizar una transaccion segusuarios
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.List que cumple con los filtros de los parametros
		/// </returns>
		public List<EntSegUsuarios> ObtenerLista(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParamAdicionales, ref CTrans localTrans)
		{
			try
			{
				ArrayList arrColumnas = new ArrayList();
				arrColumnas.Add(EntSegUsuarios.Fields.idsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.loginsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.passsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.nombresus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.apellidosus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.vigentesus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.fechavigentesus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.fechapasssus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.apiestadosus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.apitransaccionsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.usucresus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.feccresus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.usumodsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.fecmodsus.ToString());
				
				CConn local = new CConn();
				DataTable table = local.cargarDataTableAnd(CParametros.Schema + EntSegUsuarios.StrNombreTabla, arrColumnas, arrColumnasWhere, arrValoresWhere, strParamAdicionales, ref localTrans);
				
				if (table.Rows.Count > 0)
				{
					return crearLista(table);
				}
				else
					return new List<EntSegUsuarios>();
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegUsuarios a partir de condiciones WHERE
		/// </summary>
		/// <param name="searchField" type="EntSegUsuarios.Fileds">
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
		/// 		 Clase desde la que se va a utilizar una transaccion segusuarios
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.List que cumple con los filtros de los parametros
		/// </returns>
		public List<EntSegUsuarios> ObtenerLista(EntSegUsuarios.Fields searchField, object searchValue, ref CTrans localTrans)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add(searchField.ToString());
			
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add(searchValue);
			
			return ObtenerLista(arrColumnasWhere, arrValoresWhere, ref localTrans);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegUsuarios a partir de condiciones WHERE
		/// </summary>
		/// <param name="searchField" type="EntSegUsuarios.Fileds">
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
		/// 		 Clase desde la que se va a utilizar una transaccion segusuarios
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.List que cumple con los filtros de los parametros
		/// </returns>
		public List<EntSegUsuarios> ObtenerLista(EntSegUsuarios.Fields searchField, object searchValue, string strParamAdicionales, ref CTrans localTrans)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add(searchField.ToString());
			
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add(searchValue);
			
			return ObtenerLista(arrColumnasWhere, arrValoresWhere, strParamAdicionales, ref localTrans);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegUsuarios a partir de condiciones WHERE
		/// </summary>
		/// <param name="htbFiltro" type="System.Collections.Hashtable">
		///     <para>
		/// 		 Hashtable que contienen los pares para filtrar el resultado
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.List que cumple con los filtros de los parametros
		/// </returns>
		public List<EntSegUsuarios> ObtenerLista(Hashtable htbFiltro)
		{
			return ObtenerLista(htbFiltro, "");
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegUsuarios a partir de condiciones WHERE
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
		public List<EntSegUsuarios> ObtenerLista(Hashtable htbFiltro, string strParamAdicionales)
		{
			try
			{
				ArrayList arrColumnas = new ArrayList();
				arrColumnas.Add(EntSegUsuarios.Fields.idsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.loginsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.passsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.nombresus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.apellidosus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.vigentesus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.fechavigentesus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.fechapasssus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.apiestadosus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.apitransaccionsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.usucresus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.feccresus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.usumodsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.fecmodsus.ToString());
				
				ArrayList arrColumnasWhere = new ArrayList();
				ArrayList arrValoresWhere = new ArrayList();
				
				foreach (DictionaryEntry entry in htbFiltro)
				{
					arrColumnasWhere.Add(entry.Key.ToString());
					arrValoresWhere.Add(entry.Value.ToString());
				}
				
				CConn local = new CConn();
				DataTable table = local.cargarDataTableAnd(CParametros.Schema + EntSegUsuarios.StrNombreTabla, arrColumnas, arrColumnasWhere, arrValoresWhere, strParamAdicionales);
				
				if (table.Rows.Count > 0)
				{
					return crearLista(table);
				}
				else
					return new List<EntSegUsuarios>();
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegUsuarios a partir de condiciones WHERE
		/// </summary>
		/// <param name="htbFiltro" type="System.Collections.Hashtable">
		///     <para>
		/// 		 Hashtable que contienen los pares para filtrar el resultado
		///     </para>
		/// </param>
		/// <param name="localTrans" type="App_Class.Conexion.CTrans">
		///     <para>
		/// 		 Clase desde la que se va a utilizar una transaccion segusuarios
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.List que cumple con los filtros de los parametros
		/// </returns>
		public List<EntSegUsuarios> ObtenerLista(Hashtable htbFiltro, ref CTrans localTrans)
		{
			return ObtenerLista(htbFiltro, "", ref localTrans);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegUsuarios a partir de condiciones WHERE
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
		/// 		 Clase desde la que se va a utilizar una transaccion segusuarios
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.List que cumple con los filtros de los parametros
		/// </returns>
		public List<EntSegUsuarios> ObtenerLista(Hashtable htbFiltro, string strParamAdicionales, ref CTrans localTrans)
		{
			try
			{
				ArrayList arrColumnas = new ArrayList();
				arrColumnas.Add(EntSegUsuarios.Fields.idsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.loginsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.passsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.nombresus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.apellidosus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.vigentesus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.fechavigentesus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.fechapasssus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.apiestadosus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.apitransaccionsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.usucresus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.feccresus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.usumodsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.fecmodsus.ToString());
				
				ArrayList arrColumnasWhere = new ArrayList();
				ArrayList arrValoresWhere = new ArrayList();
				
				foreach (DictionaryEntry entry in htbFiltro)
				{
					arrColumnasWhere.Add(entry.Key.ToString());
					arrValoresWhere.Add(entry.Value.ToString());
				}
				
				CConn local = new CConn();
				DataTable table = local.cargarDataTableAnd(CParametros.Schema + EntSegUsuarios.StrNombreTabla, arrColumnas, arrColumnasWhere, arrValoresWhere, strParamAdicionales, ref localTrans);
				
				if (table.Rows.Count > 0)
				{
					return crearLista(table);
				}
				else
					return new List<EntSegUsuarios>();
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegUsuarios a partir de condiciones WHERE
		/// </summary>
		/// <param name="strVista" type="String">
		///     <para>
		/// 		 Nombre de la Vista desde que se van ha obtener los datos
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.List que cumple con los filtros de los parametros
		/// </returns>
		public List<EntSegUsuarios> ObtenerListaDesdeVista(String strVista)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add("'1'");
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add("'1'");
			
			return ObtenerListaDesdeVista(strVista, arrColumnasWhere, arrValoresWhere);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegUsuarios a partir de condiciones WHERE
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
		public List<EntSegUsuarios> ObtenerListaDesdeVista(String strVista, ArrayList arrColumnasWhere, ArrayList arrValoresWhere)
		{
			return ObtenerListaDesdeVista(strVista, arrColumnasWhere, arrValoresWhere, "");
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegUsuarios a partir de condiciones WHERE
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
		public List<EntSegUsuarios> ObtenerListaDesdeVista(String strVista, ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParamAdicionales)
		{
			try
			{
				ArrayList arrColumnas = new ArrayList();
				arrColumnas.Add("*");
				
				CConn local = new CConn();
				DataTable table = local.cargarDataTableAnd(CParametros.Schema + strVista, arrColumnas, arrColumnasWhere, arrValoresWhere, strParamAdicionales);
				
				if (table.Rows.Count > 0)
				{
					return crearListaRevisada(table);
				}
				else
					return new List<EntSegUsuarios>();
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegUsuarios a partir de condiciones WHERE
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
		public List<EntSegUsuarios> ObtenerListaDesdeVista(String strVista, Hashtable htbFiltro)
		{
			return ObtenerListaDesdeVista(strVista, htbFiltro, "");
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegUsuarios a partir de condiciones WHERE
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
		public List<EntSegUsuarios> ObtenerListaDesdeVista(String strVista, Hashtable htbFiltro, string strParamAdicionales)
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
				DataTable table = local.cargarDataTableAnd(CParametros.Schema + strVista, arrColumnas, arrColumnasWhere, arrValoresWhere, strParamAdicionales);
				
				if (table.Rows.Count > 0)
				{
					return crearListaRevisada(table);
				}
				else
					return new List<EntSegUsuarios>();
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegUsuarios a partir de condiciones WHERE
		/// </summary>
		/// <param name="strVista" type="String">
		///     <para>
		/// 		 Nombre de la Vista desde que se van ha obtener los datos
		///     </para>
		/// </param>
		/// <param name="searchField" type="EntSegUsuarios.Fileds">
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
		public List<EntSegUsuarios> ObtenerListaDesdeVista(String strVista, EntSegUsuarios.Fields searchField, object searchValue)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add(searchField.ToString());
			
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add(searchValue);
			
			return ObtenerListaDesdeVista(strVista, arrColumnasWhere, arrValoresWhere);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegUsuarios a partir de condiciones WHERE
		/// </summary>
		/// <param name="strVista" type="String">
		///     <para>
		/// 		 Nombre de la Vista desde que se van ha obtener los datos
		///     </para>
		/// </param>
		/// <param name="searchField" type="EntSegUsuarios.Fileds">
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
		public List<EntSegUsuarios> ObtenerListaDesdeVista(String strVista, EntSegUsuarios.Fields searchField, object searchValue, string strParamAdicionales)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add(searchField.ToString());
			
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add(searchValue);
			
			return ObtenerListaDesdeVista(strVista, arrColumnasWhere, arrValoresWhere, strParamAdicionales);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegUsuarios a partir de condiciones WHERE
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
		/// 		 Clase desde la que se va a utilizar una transaccion segusuarios
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.List que cumple con los filtros de los parametros
		/// </returns>
		public List<EntSegUsuarios> ObtenerListaDesdeVista(String strVista, ArrayList arrColumnasWhere, ArrayList arrValoresWhere, ref CTrans localTrans)
		{
			return ObtenerListaDesdeVista(strVista, arrColumnasWhere, arrValoresWhere, "", ref localTrans);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegUsuarios a partir de condiciones WHERE
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
		/// 		 Clase desde la que se va a utilizar una transaccion segusuarios
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.List que cumple con los filtros de los parametros
		/// </returns>
		public List<EntSegUsuarios> ObtenerListaDesdeVista(String strVista, ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParamAdicionales, ref CTrans localTrans)
		{
			try
			{
				ArrayList arrColumnas = new ArrayList();
				arrColumnas.Add("*");
				
				CConn local = new CConn();
				DataTable table = local.cargarDataTableAnd(CParametros.Schema + strVista, arrColumnas, arrColumnasWhere, arrValoresWhere, strParamAdicionales, ref localTrans);
				
				if (table.Rows.Count > 0)
				{
					return crearListaRevisada(table);
				}
				else
					return new List<EntSegUsuarios>();
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegUsuarios a partir de condiciones WHERE
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
		/// 		 Clase desde la que se va a utilizar una transaccion segusuarios
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.List que cumple con los filtros de los parametros
		/// </returns>
		public List<EntSegUsuarios> ObtenerListaDesdeVista(String strVista, Hashtable htbFiltro, ref CTrans localTrans)
		{
			return ObtenerListaDesdeVista(strVista, htbFiltro, "", ref localTrans);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegUsuarios a partir de condiciones WHERE
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
		/// 		 Clase desde la que se va a utilizar una transaccion segusuarios
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.List que cumple con los filtros de los parametros
		/// </returns>
		public List<EntSegUsuarios> ObtenerListaDesdeVista(String strVista, Hashtable htbFiltro, string strParamAdicionales, ref CTrans localTrans)
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
				DataTable table = local.cargarDataTableAnd(CParametros.Schema + strVista, arrColumnas, arrColumnasWhere, arrValoresWhere, strParamAdicionales, ref localTrans);
				
				if (table.Rows.Count > 0)
				{
					return crearListaRevisada(table);
				}
				else
					return new List<EntSegUsuarios>();
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegUsuarios a partir de condiciones WHERE
		/// </summary>
		/// <param name="strVista" type="String">
		///     <para>
		/// 		 Nombre de la Vista desde que se van ha obtener los datos
		///     </para>
		/// </param>
		/// <param name="searchField" type="EntSegUsuarios.Fileds">
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
		/// 		 Clase desde la que se va a utilizar una transaccion segusuarios
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.List que cumple con los filtros de los parametros
		/// </returns>
		public List<EntSegUsuarios> ObtenerListaDesdeVista(String strVista, EntSegUsuarios.Fields searchField, object searchValue, ref CTrans localTrans)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add(searchField.ToString());
			
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add(searchValue);
			
			return ObtenerListaDesdeVista(strVista, arrColumnasWhere, arrValoresWhere, ref localTrans);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegUsuarios a partir de condiciones WHERE
		/// </summary>
		/// <param name="strVista" type="String">
		///     <para>
		/// 		 Nombre de la Vista desde que se van ha obtener los datos
		///     </para>
		/// </param>
		/// <param name="searchField" type="EntSegUsuarios.Fileds">
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
		/// 		 Clase desde la que se va a utilizar una transaccion segusuarios
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.List que cumple con los filtros de los parametros
		/// </returns>
		public List<EntSegUsuarios> ObtenerListaDesdeVista(String strVista, EntSegUsuarios.Fields searchField, object searchValue, string strParamAdicionales, ref CTrans localTrans)
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
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegUsuarios a partir de condiciones WHERE
		/// </summary>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.Queue que cumple con los filtros de los parametros
		/// </returns>
		public Queue<EntSegUsuarios> ObtenerCola()
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add("'1'");
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add("'1'");
			
			return ObtenerCola(arrColumnasWhere, arrValoresWhere);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegUsuarios a partir de condiciones WHERE
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
		public Queue<EntSegUsuarios> ObtenerCola(ArrayList arrColumnasWhere, ArrayList arrValoresWhere)
		{
			return ObtenerCola(arrColumnasWhere, arrValoresWhere, "");
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegUsuarios a partir de condiciones WHERE
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
		public Queue<EntSegUsuarios> ObtenerCola(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParamAdicionales)
		{
			try
			{
				ArrayList arrColumnas = new ArrayList();
				arrColumnas.Add(EntSegUsuarios.Fields.idsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.loginsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.passsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.nombresus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.apellidosus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.vigentesus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.fechavigentesus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.fechapasssus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.apiestadosus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.apitransaccionsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.usucresus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.feccresus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.usumodsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.fecmodsus.ToString());
				
				CConn local = new CConn();
				DataTable table = local.cargarDataTableAnd(CParametros.Schema + EntSegUsuarios.StrNombreTabla, arrColumnas, arrColumnasWhere, arrValoresWhere, strParamAdicionales);
				
				if (table.Rows.Count > 0)
				{
					return crearCola(table);
				}
				else
					return new Queue<EntSegUsuarios>();
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegUsuarios a partir de condiciones WHERE
		/// </summary>
		/// <param name="searchField" type="EntSegUsuarios.Fileds">
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
		public Queue<EntSegUsuarios> ObtenerCola(EntSegUsuarios.Fields searchField, object searchValue)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add(searchField.ToString());
			
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add(searchValue);
			
			return ObtenerCola(arrColumnasWhere, arrValoresWhere);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegUsuarios a partir de condiciones WHERE
		/// </summary>
		/// <param name="searchField" type="EntSegUsuarios.Fileds">
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
		public Queue<EntSegUsuarios> ObtenerCola(EntSegUsuarios.Fields searchField, object searchValue, string strParamAdicionales)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add(searchField.ToString());
			
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add(searchValue);
			
			return ObtenerCola(arrColumnasWhere, arrValoresWhere, strParamAdicionales);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegUsuarios a partir de condiciones WHERE
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
		/// 		 Clase desde la que se va a utilizar una transaccion segusuarios
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.Queue que cumple con los filtros de los parametros
		/// </returns>
		public Queue<EntSegUsuarios> ObtenerCola(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, ref CTrans localTrans)
		{
			return ObtenerCola(arrColumnasWhere, arrValoresWhere, "", ref localTrans);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegUsuarios a partir de condiciones WHERE
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
		/// 		 Clase desde la que se va a utilizar una transaccion segusuarios
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.Queue que cumple con los filtros de los parametros
		/// </returns>
		public Queue<EntSegUsuarios> ObtenerCola(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParamAdicionales, ref CTrans localTrans)
		{
			try
			{
				ArrayList arrColumnas = new ArrayList();
				arrColumnas.Add(EntSegUsuarios.Fields.idsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.loginsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.passsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.nombresus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.apellidosus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.vigentesus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.fechavigentesus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.fechapasssus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.apiestadosus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.apitransaccionsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.usucresus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.feccresus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.usumodsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.fecmodsus.ToString());
				
				CConn local = new CConn();
				DataTable table = local.cargarDataTableAnd(CParametros.Schema + EntSegUsuarios.StrNombreTabla, arrColumnas, arrColumnasWhere, arrValoresWhere, strParamAdicionales, ref localTrans);
				
				if (table.Rows.Count > 0)
				{
					return crearCola(table);
				}
				else
					return new Queue<EntSegUsuarios>();
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegUsuarios a partir de condiciones WHERE
		/// </summary>
		/// <param name="searchField" type="EntSegUsuarios.Fileds">
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
		/// 		 Clase desde la que se va a utilizar una transaccion segusuarios
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.Queue que cumple con los filtros de los parametros
		/// </returns>
		public Queue<EntSegUsuarios> ObtenerCola(EntSegUsuarios.Fields searchField, object searchValue, ref CTrans localTrans)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add(searchField.ToString());
			
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add(searchValue);
			
			return ObtenerCola(arrColumnasWhere, arrValoresWhere, ref localTrans);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegUsuarios a partir de condiciones WHERE
		/// </summary>
		/// <param name="searchField" type="EntSegUsuarios.Fileds">
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
		/// 		 Clase desde la que se va a utilizar una transaccion segusuarios
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.Stack que cumple con los filtros de los parametros
		/// </returns>
		public Queue<EntSegUsuarios> ObtenerCola(EntSegUsuarios.Fields searchField, object searchValue, string strParamAdicionales, ref CTrans localTrans)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add(searchField.ToString());
			
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add(searchValue);
			
			return ObtenerCola(arrColumnasWhere, arrValoresWhere, strParamAdicionales, ref localTrans);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegUsuarios a partir de condiciones WHERE
		/// </summary>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.Stack que cumple con los filtros de los parametros
		/// </returns>
		public Stack<EntSegUsuarios> ObtenerPila()
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add("'1'");
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add("'1'");
			
			return ObtenerPila(arrColumnasWhere, arrValoresWhere);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegUsuarios a partir de condiciones WHERE
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
		public Stack<EntSegUsuarios> ObtenerPila(ArrayList arrColumnasWhere, ArrayList arrValoresWhere)
		{
			return ObtenerPila(arrColumnasWhere, arrValoresWhere, "");
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegUsuarios a partir de condiciones WHERE
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
		public Stack<EntSegUsuarios> ObtenerPila(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParamAdicionales)
		{
			try
			{
				ArrayList arrColumnas = new ArrayList();
				arrColumnas.Add(EntSegUsuarios.Fields.idsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.loginsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.passsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.nombresus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.apellidosus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.vigentesus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.fechavigentesus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.fechapasssus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.apiestadosus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.apitransaccionsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.usucresus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.feccresus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.usumodsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.fecmodsus.ToString());
				
				CConn local = new CConn();
				DataTable table = local.cargarDataTableAnd(CParametros.Schema + EntSegUsuarios.StrNombreTabla, arrColumnas, arrColumnasWhere, arrValoresWhere, strParamAdicionales);
				
				if (table.Rows.Count > 0)
				{
					return crearPila(table);
				}
				else
					return new Stack<EntSegUsuarios>();
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegUsuarios a partir de condiciones WHERE
		/// </summary>
		/// <param name="searchField" type="EntSegUsuarios.Fileds">
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
		public Stack<EntSegUsuarios> ObtenerPila(EntSegUsuarios.Fields searchField, object searchValue)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add(searchField.ToString());
			
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add(searchValue);
			
			return ObtenerPila(arrColumnasWhere, arrValoresWhere);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegUsuarios a partir de condiciones WHERE
		/// </summary>
		/// <param name="searchField" type="EntSegUsuarios.Fileds">
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
		public Stack<EntSegUsuarios> ObtenerPila(EntSegUsuarios.Fields searchField, object searchValue, string strParamAdicionales)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add(searchField.ToString());
			
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add(searchValue);
			
			return ObtenerPila(arrColumnasWhere, arrValoresWhere, strParamAdicionales);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegUsuarios a partir de condiciones WHERE
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
		/// 		 Clase desde la que se va a utilizar una transaccion segusuarios
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo Stack que cumple con los filtros de los parametros
		/// </returns>
		public Stack<EntSegUsuarios> ObtenerPila(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, ref CTrans localTrans)
		{
			return ObtenerPila(arrColumnasWhere, arrValoresWhere, "", ref localTrans);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegUsuarios a partir de condiciones WHERE
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
		/// 		 Clase desde la que se va a utilizar una transaccion segusuarios
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.Stack que cumple con los filtros de los parametros
		/// </returns>
		public Stack<EntSegUsuarios> ObtenerPila(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParamAdicionales, ref CTrans localTrans)
		{
			try
			{
				ArrayList arrColumnas = new ArrayList();
				arrColumnas.Add(EntSegUsuarios.Fields.idsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.loginsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.passsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.nombresus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.apellidosus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.vigentesus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.fechavigentesus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.fechapasssus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.apiestadosus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.apitransaccionsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.usucresus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.feccresus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.usumodsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.fecmodsus.ToString());
				
				CConn local = new CConn();
				DataTable table = local.cargarDataTableAnd(CParametros.Schema + EntSegUsuarios.StrNombreTabla, arrColumnas, arrColumnasWhere, arrValoresWhere, strParamAdicionales, ref localTrans);
				
				if (table.Rows.Count > 0)
				{
					return crearPila(table);
				}
				else
					return new Stack<EntSegUsuarios>();
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegUsuarios a partir de condiciones WHERE
		/// </summary>
		/// <param name="searchField" type="EntSegUsuarios.Fileds">
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
		/// 		 Clase desde la que se va a utilizar una transaccion segusuarios
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.Stack que cumple con los filtros de los parametros
		/// </returns>
		public Stack<EntSegUsuarios> ObtenerPila(EntSegUsuarios.Fields searchField, object searchValue, ref CTrans localTrans)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add(searchField.ToString());
			
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add(searchValue);
			
			return ObtenerPila(arrColumnasWhere, arrValoresWhere, ref localTrans);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegUsuarios a partir de condiciones WHERE
		/// </summary>
		/// <param name="searchField" type="EntSegUsuarios.Fileds">
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
		/// 		 Clase desde la que se va a utilizar una transaccion segusuarios
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.Stack que cumple con los filtros de los parametros
		/// </returns>
		public Stack<EntSegUsuarios> ObtenerPila(EntSegUsuarios.Fields searchField, object searchValue, string strParamAdicionales, ref CTrans localTrans)
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
		/// 	 Funcion que llena un DataTable con los registros de una tabla segusuarios
		/// </summary>
		/// <returns>
		/// 	 DataTable con los datos obtenidos de segusuarios
		/// </returns>
		public DataTable NuevoDataTable()
		{
			try
			{
				DataTable table = new DataTable ();
				DataColumn dc;
				dc = new DataColumn(EntSegUsuarios.Fields.idsus.ToString(),typeof(EntSegUsuarios).GetProperty(EntSegUsuarios.Fields.idsus.ToString()).PropertyType);
				table.Columns.Add(dc);

				dc = new DataColumn(EntSegUsuarios.Fields.loginsus.ToString(),typeof(EntSegUsuarios).GetProperty(EntSegUsuarios.Fields.loginsus.ToString()).PropertyType);
				table.Columns.Add(dc);

				dc = new DataColumn(EntSegUsuarios.Fields.passsus.ToString(),typeof(EntSegUsuarios).GetProperty(EntSegUsuarios.Fields.passsus.ToString()).PropertyType);
				table.Columns.Add(dc);

				dc = new DataColumn(EntSegUsuarios.Fields.nombresus.ToString(),typeof(EntSegUsuarios).GetProperty(EntSegUsuarios.Fields.nombresus.ToString()).PropertyType);
				table.Columns.Add(dc);

				dc = new DataColumn(EntSegUsuarios.Fields.apellidosus.ToString(),typeof(EntSegUsuarios).GetProperty(EntSegUsuarios.Fields.apellidosus.ToString()).PropertyType);
				table.Columns.Add(dc);

				dc = new DataColumn(EntSegUsuarios.Fields.vigentesus.ToString(),typeof(EntSegUsuarios).GetProperty(EntSegUsuarios.Fields.vigentesus.ToString()).PropertyType);
				table.Columns.Add(dc);

				dc = new DataColumn(EntSegUsuarios.Fields.fechavigentesus.ToString(),typeof(EntSegUsuarios).GetProperty(EntSegUsuarios.Fields.fechavigentesus.ToString()).PropertyType);
				table.Columns.Add(dc);

				dc = new DataColumn(EntSegUsuarios.Fields.fechapasssus.ToString(),typeof(EntSegUsuarios).GetProperty(EntSegUsuarios.Fields.fechapasssus.ToString()).PropertyType);
				table.Columns.Add(dc);

				dc = new DataColumn(EntSegUsuarios.Fields.apiestadosus.ToString(),typeof(EntSegUsuarios).GetProperty(EntSegUsuarios.Fields.apiestadosus.ToString()).PropertyType);
				table.Columns.Add(dc);

				dc = new DataColumn(EntSegUsuarios.Fields.apitransaccionsus.ToString(),typeof(EntSegUsuarios).GetProperty(EntSegUsuarios.Fields.apitransaccionsus.ToString()).PropertyType);
				table.Columns.Add(dc);

				dc = new DataColumn(EntSegUsuarios.Fields.usucresus.ToString(),typeof(EntSegUsuarios).GetProperty(EntSegUsuarios.Fields.usucresus.ToString()).PropertyType);
				table.Columns.Add(dc);

				dc = new DataColumn(EntSegUsuarios.Fields.feccresus.ToString(),typeof(EntSegUsuarios).GetProperty(EntSegUsuarios.Fields.feccresus.ToString()).PropertyType);
				table.Columns.Add(dc);

				dc = new DataColumn(EntSegUsuarios.Fields.usumodsus.ToString(),typeof(EntSegUsuarios).GetProperty(EntSegUsuarios.Fields.usumodsus.ToString()).PropertyType);
				table.Columns.Add(dc);

				dc = new DataColumn(EntSegUsuarios.Fields.fecmodsus.ToString(),typeof(EntSegUsuarios).GetProperty(EntSegUsuarios.Fields.fecmodsus.ToString()).PropertyType);
				table.Columns.Add(dc);

				
				return table;
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	 Funcion que genera un DataTable con determinadas columnas de una segusuarios
		/// </summary>
		/// <param name="arrColumnas" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las columnas que se va a seleccionar para mostrarlas en el resultado
		///     </para>
		/// </param>
		/// <returns>
		/// 	 DataTable con los datos obtenidos de segusuarios
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
				DataTable table = local.cargarDataTableAnd(CParametros.Schema + EntSegUsuarios.StrNombreTabla, arrColumnas, arrColumnasWhere, arrValoresWhere);
				
				return table;
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	 Funcion que llena un DataTable con los registros de una tabla segusuarios
		/// </summary>
		/// <returns>
		/// 	 DataTable con los datos obtenidos de segusuarios
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
		/// 	 Funcion que llena un DataTable con los registros de una tabla y n condicion WHERE segusuarios
		/// </summary>
		/// <param name="strParamAdicionales" type="String">
		///     <para>
		/// 		 Condiciones que van en la clausula WHERE. Deben ir sin WHERE
		///     </para>
		/// </param>
		/// <returns>
		/// 	 DataTable con los datos obtenidos de segusuarios
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
		/// 	 Funcion que llena un DataTable con los registro de una tabla segusuarios
		/// </summary>
		/// <param name="arrColumnas" type="System.Collections.ArrayList">
		///     <para>
		/// 		 Array de las columnas que se va a seleccionar para mostrarlas en el resultado
		///     </para>
		/// </param>
		/// <returns>
		/// 	 DataTable con los datos obtenidos de segusuarios
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
		/// 	 Funcion que llena un DataTable con los registro de una tabla segusuarios
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
		/// 	 DataTable con los datos obtenidos de segusuarios
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
		/// 	 Funcion que llena un DataTable con los registro de una tabla segusuarios
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
		/// 	 DataTable con los datos obtenidos de segusuarios
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
		/// 	 Funcion que llena un DataTable con los registro de una tabla segusuarios
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
		/// 	 DataTable con los datos obtenidos de segusuarios
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
		/// 	 Funcion que llena un DataTable con los registro de una tabla segusuarios
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
		/// 	 DataTable con los datos obtenidos de segusuarios
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
		/// 	 Funcion que llena un DataTable con los registro de una tabla segusuarios
		/// </summary>
		/// <param name="htbFiltro" type="System.Collections.Hashtable">
		///     <para>
		/// 		 Hashtable que contienen los pares para filtrar el resultado
		///     </para>
		/// </param>
		/// <returns>
		/// 	 DataTable con los datos obtenidos de segusuarios
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
		/// 	 Funcion que llena un DataTable con los registro de una tabla segusuarios
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
		/// 	 DataTable con los datos obtenidos de segusuarios
		/// </returns>
		public DataTable ObtenerDataTable(ArrayList arrColumnas, ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParametrosAdicionales)
		{
			try
			{
				CConn local = new CConn();
				DataTable table = local.cargarDataTableAnd(CParametros.Schema + EntSegUsuarios.StrNombreTabla, arrColumnas, arrColumnasWhere, arrValoresWhere, strParametrosAdicionales);
				
				return table;
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	 Funcion que llena un DataTable con los registro de una tabla segusuarios
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
		/// 	 DataTable con los datos obtenidos de segusuarios
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
				DataTable table = local.cargarDataTableAnd(CParametros.Schema + EntSegUsuarios.StrNombreTabla, arrColumnas, arrColumnasWhere, arrValoresWhere, strParametrosAdicionales);
				
				return table;
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	 Funcion que llena un DataTable con los registro de una tabla segusuarios
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
		/// 	 DataTable con los datos obtenidos de segusuarios
		/// </returns>
		public DataTable ObtenerDataTable(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParametrosAdicionales)
		{
			try
			{
				ArrayList arrColumnas = new ArrayList();
				arrColumnas.Add(EntSegUsuarios.Fields.idsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.loginsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.passsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.nombresus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.apellidosus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.vigentesus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.fechavigentesus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.fechapasssus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.apiestadosus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.apitransaccionsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.usucresus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.feccresus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.usumodsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.fecmodsus.ToString());
				
				return ObtenerDataTable(arrColumnas, arrColumnasWhere, arrValoresWhere, strParametrosAdicionales);
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	 Funcion que llena un DataTable con los registro de una tabla segusuarios
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
		/// 	 DataTable con los datos obtenidos de segusuarios
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
				arrColumnas.Add(EntSegUsuarios.Fields.idsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.loginsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.passsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.nombresus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.apellidosus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.vigentesus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.fechavigentesus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.fechapasssus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.apiestadosus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.apitransaccionsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.usucresus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.feccresus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.usumodsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.fecmodsus.ToString());
				
				return ObtenerDataTable(arrColumnas, arrColumnasWhere, arrValoresWhere, strParametrosAdicionales);
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	 Funcion que llena un DataTable con los registro de una tabla segusuarios
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
		/// 	 DataTable con los datos obtenidos de segusuarios
		/// </returns>
		public DataTable ObtenerDataTableOr(ArrayList arrColumnasWhere, ArrayList arrValoresWhere)
		{
			try
			{
				ArrayList arrColumnas = new ArrayList();
				arrColumnas.Add(EntSegUsuarios.Fields.idsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.loginsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.passsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.nombresus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.apellidosus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.vigentesus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.fechavigentesus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.fechapasssus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.apiestadosus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.apitransaccionsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.usucresus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.feccresus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.usumodsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.fecmodsus.ToString());
				return ObtenerDataTableOr(arrColumnas, arrColumnasWhere, arrValoresWhere, "");
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	 Funcion que llena un DataTable con los registro de una tabla segusuarios
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
		/// 	 DataTable con los datos obtenidos de segusuarios
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
		/// 	 Funcion que llena un DataTable con los registro de una tabla segusuarios
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
		/// 	 DataTable con los datos obtenidos de segusuarios
		/// </returns>
		public DataTable ObtenerDataTableOr(ArrayList arrColumnas, ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParametrosAdicionales)
		{
			try
			{
				CConn local = new CConn();
				DataTable table = local.cargarDataTableOr(CParametros.Schema + EntSegUsuarios.StrNombreTabla, arrColumnas, arrColumnasWhere, arrValoresWhere, strParametrosAdicionales);
				
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
		/// <param name="searchField" type="EntSegUsuarios.Fileds">
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
		public DataTable ObtenerDataTable(EntSegUsuarios.Fields searchField, object searchValue)
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
		/// <param name="searchField" type="EntSegUsuarios.Fileds">
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
		public DataTable ObtenerDataTable(EntSegUsuarios.Fields searchField, object searchValue, string strParametrosAdicionales)
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
		/// <param name="searchField" type="EntSegUsuarios.Fileds">
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
		public DataTable ObtenerDataTable(ArrayList arrColumnas, EntSegUsuarios.Fields searchField, object searchValue, string strParametrosAdicionales)
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
		/// <param name="searchField" type="EntSegUsuarios.Fileds">
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
		public DataTable ObtenerDataTable(ArrayList arrColumnas, EntSegUsuarios.Fields searchField, object searchValue)
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
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegUsuarios a partir de condiciones WHERE
		/// </summary>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.Dictionary que cumple con los filtros de los parametros
		/// </returns>
		public Dictionary<String, EntSegUsuarios> ObtenerDiccionario()
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add("'1'");
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add("'1'");
			
			return ObtenerDiccionario(arrColumnasWhere, arrValoresWhere);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegUsuarios a partir de condiciones WHERE
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
		public Dictionary<String, EntSegUsuarios> ObtenerDiccionario(ArrayList arrColumnasWhere, ArrayList arrValoresWhere)
		{
			return ObtenerDiccionario(arrColumnasWhere, arrValoresWhere, "");
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegUsuarios a partir de condiciones WHERE
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
		public Dictionary<String, EntSegUsuarios> ObtenerDiccionario(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParamAdicionales)
		{
			try
			{
				ArrayList arrColumnas = new ArrayList();
				arrColumnas.Add(EntSegUsuarios.Fields.idsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.loginsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.passsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.nombresus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.apellidosus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.vigentesus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.fechavigentesus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.fechapasssus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.apiestadosus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.apitransaccionsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.usucresus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.feccresus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.usumodsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.fecmodsus.ToString());
				
				CConn local = new CConn();
				DataTable table = local.cargarDataTableAnd(CParametros.Schema + EntSegUsuarios.StrNombreTabla, arrColumnas, arrColumnasWhere, arrValoresWhere, strParamAdicionales);
				
				if (table.Rows.Count > 0)
				{
					return crearDiccionario(table);
				}
				else
					return new Dictionary<string, EntSegUsuarios>();
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegUsuarios a partir de condiciones WHERE
		/// </summary>
		/// <param name="searchField" type="EntSegUsuarios.Fileds">
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
		public Dictionary<String, EntSegUsuarios> ObtenerDiccionario(EntSegUsuarios.Fields searchField, object searchValue)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add(searchField.ToString());
			
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add(searchValue);
			
			return ObtenerDiccionario(arrColumnasWhere, arrValoresWhere);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegUsuarios a partir de condiciones WHERE
		/// </summary>
		/// <param name="searchField" type="EntSegUsuarios.Fileds">
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
		public Dictionary<String, EntSegUsuarios> ObtenerDiccionario(EntSegUsuarios.Fields searchField, object searchValue, string strParamAdicionales)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add(searchField.ToString());
			
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add(searchValue);
			
			return ObtenerDiccionario(arrColumnasWhere, arrValoresWhere, strParamAdicionales);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegUsuarios a partir de condiciones WHERE
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
		/// 		 Clase desde la que se va a utilizar una transaccion segusuarios
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.Dictionary que cumple con los filtros de los parametros
		/// </returns>
		public Dictionary<String, EntSegUsuarios> ObtenerDiccionario(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, ref CTrans localTrans)
		{
			return ObtenerDiccionario(arrColumnasWhere, arrValoresWhere, "", ref localTrans);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegUsuarios a partir de condiciones WHERE
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
		/// 		 Clase desde la que se va a utilizar una transaccion segusuarios
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.Dictionary que cumple con los filtros de los parametros
		/// </returns>
		public Dictionary<String, EntSegUsuarios> ObtenerDiccionario(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParamAdicionales, ref CTrans localTrans)
		{
			try
			{
				ArrayList arrColumnas = new ArrayList();
				arrColumnas.Add(EntSegUsuarios.Fields.idsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.loginsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.passsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.nombresus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.apellidosus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.vigentesus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.fechavigentesus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.fechapasssus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.apiestadosus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.apitransaccionsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.usucresus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.feccresus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.usumodsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.fecmodsus.ToString());
				
				CConn local = new CConn();
				DataTable table = local.cargarDataTableAnd(CParametros.Schema + EntSegUsuarios.StrNombreTabla, arrColumnas, arrColumnasWhere, arrValoresWhere, strParamAdicionales, ref localTrans);
				
				if (table.Rows.Count > 0)
				{
					return crearDiccionario(table);
				}
				else
					return new Dictionary<string, EntSegUsuarios>();
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegUsuarios a partir de condiciones WHERE
		/// </summary>
		/// <param name="searchField" type="EntSegUsuarios.Fileds">
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
		/// 		 Clase desde la que se va a utilizar una transaccion segusuarios
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.Dictionary que cumple con los filtros de los parametros
		/// </returns>
		public Dictionary<String, EntSegUsuarios> ObtenerDiccionario(EntSegUsuarios.Fields searchField, object searchValue, ref CTrans localTrans)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add(searchField.ToString());
			
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add(searchValue);
			
			return ObtenerDiccionario(arrColumnasWhere, arrValoresWhere, ref localTrans);
		}
		
		/// <summary>
		/// 	Funcion que obtiene un conjunto de datos de una Clase EntSegUsuarios a partir de condiciones WHERE
		/// </summary>
		/// <param name="searchField" type="EntSegUsuarios.Fileds">
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
		/// 		 Clase desde la que se va a utilizar una transaccion segusuarios
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo System.Collections.Generic.Dictionary que cumple con los filtros de los parametros
		/// </returns>
		public Dictionary<String, EntSegUsuarios> ObtenerDiccionario(EntSegUsuarios.Fields searchField, object searchValue, string strParamAdicionales, ref CTrans localTrans)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add(searchField.ToString());
			
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add(searchValue);
			
			return ObtenerDiccionario(arrColumnasWhere, arrValoresWhere, strParamAdicionales, ref localTrans);
		}
		
		public Dictionary<String, EntSegUsuarios> ObtenerDiccionarioKey(EntSegUsuarios.Fields dicKey)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add("'1'");
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add("'1'");
			
			return ObtenerDiccionarioKey(arrColumnasWhere, arrValoresWhere, dicKey);
		}
		
		public Dictionary<String, EntSegUsuarios> ObtenerDiccionarioKey(String strParamAdic, EntSegUsuarios.Fields dicKey)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add("'1'");
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add("'1'");
			
			return ObtenerDiccionarioKey(arrColumnasWhere, arrValoresWhere, strParamAdic, dicKey);
		}
		
		public Dictionary<String, EntSegUsuarios> ObtenerDiccionarioKey(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, EntSegUsuarios.Fields dicKey)
		{
			return ObtenerDiccionarioKey(arrColumnasWhere, arrValoresWhere, "", dicKey);
		}
		
		public Dictionary<String, EntSegUsuarios> ObtenerDiccionarioKey(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParamAdicionales, EntSegUsuarios.Fields dicKey)
		{
			try
			{
				ArrayList arrColumnas = new ArrayList();
				arrColumnas.Add(EntSegUsuarios.Fields.idsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.loginsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.passsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.nombresus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.apellidosus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.vigentesus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.fechavigentesus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.fechapasssus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.apiestadosus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.apitransaccionsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.usucresus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.feccresus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.usumodsus.ToString());
				arrColumnas.Add(EntSegUsuarios.Fields.fecmodsus.ToString());
				
				CConn local = new CConn();
				DataTable table = local.cargarDataTableAnd(CParametros.Schema + EntSegUsuarios.StrNombreTabla, arrColumnas, arrColumnasWhere, arrValoresWhere, strParamAdicionales);
				
				if (table.Rows.Count > 0)
				{
					return crearDiccionario(table, dicKey);
				}
				else
					return new Dictionary<string, EntSegUsuarios>();
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}
		
		public Dictionary<String, EntSegUsuarios> ObtenerDiccionarioKey(EntSegUsuarios.Fields searchField, object searchValue, EntSegUsuarios.Fields dicKey)
		{
			ArrayList arrColumnasWhere = new ArrayList();
			arrColumnasWhere.Add(searchField.ToString());
			
			ArrayList arrValoresWhere = new ArrayList();
			arrValoresWhere.Add(searchValue);
			
			return ObtenerDiccionarioKey(arrColumnasWhere, arrValoresWhere, dicKey);
		}
		
		public Dictionary<String, EntSegUsuarios> ObtenerDiccionarioKey(EntSegUsuarios.Fields searchField, object searchValue, string strParamAdicionales, EntSegUsuarios.Fields dicKey)
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
		/// 	Funcion que inserta un nuevo registro en la tabla segusuarios a partir de una clase del tipo Esegusuarios
		/// </summary>
		/// <param name="strNombreSp" type="System.string">
		///     <para>
		/// 		 Nombre del Procedimiento a ejecutar sobre el SP
		///     </para>
		/// </param>
		/// <param name="obj" type="Entidades.EntSegUsuarios">
		///     <para>
		/// 		 Clase desde la que se va a ejecutar el SP de la tabla segusuarios
		///     </para>
		/// </param>
		/// <returns>
		/// 	 Valor de registros afectados en el Procedimiento de la tabla segusuarios
		/// </returns>
		public int EjecutarSpDesdeObjeto(string strNombreSp, EntSegUsuarios obj)
		{
			try
			{
				if (!obj.IsValid())
				{
					throw new Exception(obj.ValidationErrorsString());
				}
				
				ArrayList arrNombreParam = new ArrayList();
				arrNombreParam.Add(EntSegUsuarios.Fields.idsus.ToString());
				arrNombreParam.Add(EntSegUsuarios.Fields.loginsus.ToString());
				arrNombreParam.Add(EntSegUsuarios.Fields.passsus.ToString());
				arrNombreParam.Add(EntSegUsuarios.Fields.nombresus.ToString());
				arrNombreParam.Add(EntSegUsuarios.Fields.apellidosus.ToString());
				arrNombreParam.Add(EntSegUsuarios.Fields.vigentesus.ToString());
				arrNombreParam.Add(EntSegUsuarios.Fields.fechavigentesus.ToString());
				arrNombreParam.Add(EntSegUsuarios.Fields.fechapasssus.ToString());
				arrNombreParam.Add(EntSegUsuarios.Fields.apiestadosus.ToString());
				arrNombreParam.Add(EntSegUsuarios.Fields.apitransaccionsus.ToString());
				arrNombreParam.Add(EntSegUsuarios.Fields.usucresus.ToString());
				arrNombreParam.Add(EntSegUsuarios.Fields.feccresus.ToString());
				arrNombreParam.Add(EntSegUsuarios.Fields.usumodsus.ToString());
				arrNombreParam.Add(EntSegUsuarios.Fields.fecmodsus.ToString());
				
				ArrayList arrValoresParam = new ArrayList();
				arrValoresParam.Add(obj.idsus);
				arrValoresParam.Add(obj.loginsus == null ? null : "'" + obj.loginsus + "'");
				arrValoresParam.Add(obj.passsus == null ? null : "'" + obj.passsus + "'");
				arrValoresParam.Add(obj.nombresus == null ? null : "'" + obj.nombresus + "'");
				arrValoresParam.Add(obj.apellidosus == null ? null : "'" + obj.apellidosus + "'");
				arrValoresParam.Add(obj.vigentesus);
				arrValoresParam.Add(obj.fechavigentesus == null ? null : "'" + Convert.ToDateTime(obj.fechavigentesus).ToString(CParametros.ParFormatoFechaHora) + "'");
				arrValoresParam.Add(obj.fechapasssus == null ? null : "'" + Convert.ToDateTime(obj.fechapasssus).ToString(CParametros.ParFormatoFechaHora) + "'");
				arrValoresParam.Add(obj.apiestadosus == null ? null : "'" + obj.apiestadosus + "'");
				arrValoresParam.Add(obj.apitransaccionsus == null ? null : "'" + obj.apitransaccionsus + "'");
				arrValoresParam.Add(obj.usucresus == null ? null : "'" + obj.usucresus + "'");
				arrValoresParam.Add(obj.feccresus == null ? null : "'" + Convert.ToDateTime(obj.feccresus).ToString(CParametros.ParFormatoFechaHora) + "'");
				arrValoresParam.Add(obj.usumodsus == null ? null : "'" + obj.usumodsus + "'");
				arrValoresParam.Add(obj.fecmodsus == null ? null : "'" + Convert.ToDateTime(obj.fecmodsus).ToString(CParametros.ParFormatoFechaHora) + "'");

				
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
		/// 	Funcion que inserta un nuevo registro en la tabla segusuarios a partir de una clase del tipo Esegusuarios
		/// </summary>
		/// <param name="strNombreSp" type="System.string">
		///     <para>
		/// 		 Nombre del Procedimiento a ejecutar sobre el SP
		///     </para>
		/// </param>
		/// <param name="obj" type="Entidades.EntSegUsuarios">
		///     <para>
		/// 		 Clase desde la que se va a ejecutar el SP de la tabla segusuarios
		///     </para>
		/// </param>
		/// <param name="localTrans" type="App_Class.Conexion.CTrans">
		///     <para>
		/// 		 Clase desde la que se va a utilizar una transaccion segusuarios
		///     </para>
		/// </param>
		/// <returns>
		/// 	 Valor de registros afectados en el Procedimiento de la tabla segusuarios
		/// </returns>
		public int EjecutarSpDesdeObjeto(string strNombreSp, EntSegUsuarios obj, ref CTrans localTrans)
		{
			try
			{
				if (!obj.IsValid())
				{
					throw new Exception(obj.ValidationErrorsString());
				}
				
				ArrayList arrNombreParam = new ArrayList();
				arrNombreParam.Add(EntSegUsuarios.Fields.idsus.ToString());
				arrNombreParam.Add(EntSegUsuarios.Fields.loginsus.ToString());
				arrNombreParam.Add(EntSegUsuarios.Fields.passsus.ToString());
				arrNombreParam.Add(EntSegUsuarios.Fields.nombresus.ToString());
				arrNombreParam.Add(EntSegUsuarios.Fields.apellidosus.ToString());
				arrNombreParam.Add(EntSegUsuarios.Fields.vigentesus.ToString());
				arrNombreParam.Add(EntSegUsuarios.Fields.fechavigentesus.ToString());
				arrNombreParam.Add(EntSegUsuarios.Fields.fechapasssus.ToString());
				arrNombreParam.Add(EntSegUsuarios.Fields.apiestadosus.ToString());
				arrNombreParam.Add(EntSegUsuarios.Fields.apitransaccionsus.ToString());
				arrNombreParam.Add(EntSegUsuarios.Fields.usucresus.ToString());
				arrNombreParam.Add(EntSegUsuarios.Fields.feccresus.ToString());
				arrNombreParam.Add(EntSegUsuarios.Fields.usumodsus.ToString());
				arrNombreParam.Add(EntSegUsuarios.Fields.fecmodsus.ToString());
				
				ArrayList arrValoresParam = new ArrayList();
				arrValoresParam.Add(obj.idsus);
				arrValoresParam.Add(obj.loginsus == null ? null : "'" + obj.loginsus + "'");
				arrValoresParam.Add(obj.passsus == null ? null : "'" + obj.passsus + "'");
				arrValoresParam.Add(obj.nombresus == null ? null : "'" + obj.nombresus + "'");
				arrValoresParam.Add(obj.apellidosus == null ? null : "'" + obj.apellidosus + "'");
				arrValoresParam.Add(obj.vigentesus);
				arrValoresParam.Add(obj.fechavigentesus == null ? null : "'" + Convert.ToDateTime(obj.fechavigentesus).ToString(CParametros.ParFormatoFechaHora) + "'");
				arrValoresParam.Add(obj.fechapasssus == null ? null : "'" + Convert.ToDateTime(obj.fechapasssus).ToString(CParametros.ParFormatoFechaHora) + "'");
				arrValoresParam.Add(obj.apiestadosus == null ? null : "'" + obj.apiestadosus + "'");
				arrValoresParam.Add(obj.apitransaccionsus == null ? null : "'" + obj.apitransaccionsus + "'");
				arrValoresParam.Add(obj.usucresus == null ? null : "'" + obj.usucresus + "'");
				arrValoresParam.Add(obj.feccresus == null ? null : "'" + Convert.ToDateTime(obj.feccresus).ToString(CParametros.ParFormatoFechaHora) + "'");
				arrValoresParam.Add(obj.usumodsus == null ? null : "'" + obj.usumodsus + "'");
				arrValoresParam.Add(obj.fecmodsus == null ? null : "'" + Convert.ToDateTime(obj.fecmodsus).ToString(CParametros.ParFormatoFechaHora) + "'");

				
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
		/// <param name="refField" type="EntSegUsuarios.Fileds">
		///     <para>
		/// 		 Campo al que se va a aplicar la funcion
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo EntSegUsuarios que cumple con los filtros de los parametros
		/// </returns>
		public int FuncionesCount(EntSegUsuarios.Fields refField)
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
		/// <param name="refField" type="EntSegUsuarios.Fileds">
		///     <para>
		/// 		 Campo al que se va a aplicar la funcion
		///     </para>
		/// </param>
		/// <param name="whereField" type="EntSegUsuarios.Fileds">
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
		/// 	Valor del Tipo EntSegUsuarios que cumple con los filtros de los parametros
		/// </returns>
		public int FuncionesCount(EntSegUsuarios.Fields refField, EntSegUsuarios.Fields whereField, object valueField)
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
		/// <param name="refField" type="EntSegUsuarios.Fileds">
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
		/// 	Valor del Tipo EntSegUsuarios que cumple con los filtros de los parametros
		/// </returns>
		public int FuncionesCount(EntSegUsuarios.Fields refField, ArrayList arrColumnasWhere, ArrayList arrValoresWhere)
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
		/// <param name="refField" type="EntSegUsuarios.Fileds">
		///     <para>
		/// 		 Campo al que se va a aplicar la funcion
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo EntSegUsuarios que cumple con los filtros de los parametros
		/// </returns>
		public int FuncionesMin(EntSegUsuarios.Fields refField)
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
		/// <param name="refField" type="EntSegUsuarios.Fileds">
		///     <para>
		/// 		 Campo al que se va a aplicar la funcion
		///     </para>
		/// </param>
		/// <param name="whereField" type="EntSegUsuarios.Fileds">
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
		/// 	Valor del Tipo EntSegUsuarios que cumple con los filtros de los parametros
		/// </returns>
		public int FuncionesMin(EntSegUsuarios.Fields refField, EntSegUsuarios.Fields whereField, object valueField)
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
		/// <param name="refField" type="EntSegUsuarios.Fileds">
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
		/// 	Valor del Tipo EntSegUsuarios que cumple con los filtros de los parametros
		/// </returns>
		public int FuncionesMin(EntSegUsuarios.Fields refField, ArrayList arrColumnasWhere, ArrayList arrValoresWhere)
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
		/// <param name="refField" type="EntSegUsuarios.Fileds">
		///     <para>
		/// 		 Campo al que se va a aplicar la funcion
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo EntSegUsuarios que cumple con los filtros de los parametros
		/// </returns>
		public int FuncionesMax(EntSegUsuarios.Fields refField)
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
		/// <param name="refField" type="EntSegUsuarios.Fileds">
		///     <para>
		/// 		 Campo al que se va a aplicar la funcion
		///     </para>
		/// </param>
		/// <param name="whereField" type="EntSegUsuarios.Fileds">
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
		/// 	Valor del Tipo EntSegUsuarios que cumple con los filtros de los parametros
		/// </returns>
		public int FuncionesMax(EntSegUsuarios.Fields refField, EntSegUsuarios.Fields whereField, object valueField)
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
		/// <param name="refField" type="EntSegUsuarios.Fileds">
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
		/// 	Valor del Tipo EntSegUsuarios que cumple con los filtros de los parametros
		/// </returns>
		public int FuncionesMax(EntSegUsuarios.Fields refField, ArrayList arrColumnasWhere, ArrayList arrValoresWhere)
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
		/// <param name="refField" type="EntSegUsuarios.Fileds">
		///     <para>
		/// 		 Campo al que se va a aplicar la funcion
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo EntSegUsuarios que cumple con los filtros de los parametros
		/// </returns>
		public int FuncionesSum(EntSegUsuarios.Fields refField)
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
		/// <param name="refField" type="EntSegUsuarios.Fileds">
		///     <para>
		/// 		 Campo al que se va a aplicar la funcion
		///     </para>
		/// </param>
		/// <param name="whereField" type="EntSegUsuarios.Fileds">
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
		/// 	Valor del Tipo EntSegUsuarios que cumple con los filtros de los parametros
		/// </returns>
		public int FuncionesSum(EntSegUsuarios.Fields refField, EntSegUsuarios.Fields whereField, object valueField)
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
		/// <param name="refField" type="EntSegUsuarios.Fileds">
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
		/// 	Valor del Tipo EntSegUsuarios que cumple con los filtros de los parametros
		/// </returns>
		public int FuncionesSum(EntSegUsuarios.Fields refField, ArrayList arrColumnasWhere, ArrayList arrValoresWhere)
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
		/// <param name="refField" type="EntSegUsuarios.Fileds">
		///     <para>
		/// 		 Campo al que se va a aplicar la funcion
		///     </para>
		/// </param>
		/// <returns>
		/// 	Valor del Tipo EntSegUsuarios que cumple con los filtros de los parametros
		/// </returns>
		public int FuncionesAvg(EntSegUsuarios.Fields refField)
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
		/// <param name="refField" type="EntSegUsuarios.Fileds">
		///     <para>
		/// 		 Campo al que se va a aplicar la funcion
		///     </para>
		/// </param>
		/// <param name="whereField" type="EntSegUsuarios.Fileds">
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
		/// 	Valor del Tipo EntSegUsuarios que cumple con los filtros de los parametros
		/// </returns>
		public int FuncionesAvg(EntSegUsuarios.Fields refField, EntSegUsuarios.Fields whereField, object valueField)
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
		/// <param name="refField" type="EntSegUsuarios.Fileds">
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
		/// 	Valor del Tipo EntSegUsuarios que cumple con los filtros de los parametros
		/// </returns>
		public int FuncionesAvg(EntSegUsuarios.Fields refField, ArrayList arrColumnasWhere, ArrayList arrValoresWhere)
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
		/// 	Funcion que inserta un nuevo registro en la tabla segusuarios a partir de una clase del tipo Esegusuarios
		/// </summary>
		/// <param name="obj" type="Entidades.EntSegUsuarios">
		///     <para>
		/// 		 Clase desde la que se van a insertar los valores a la tabla segusuarios
		///     </para>
		/// </param>
		/// <returns>
		/// 	 Valor TRUE or FALSE que indica el exito de la operacionsegusuarios
		/// </returns>
		public bool Insert(EntSegUsuarios obj, bool bValidar = true)
		{
			try
			{
				if (bValidar)
					if (!obj.IsValid())
						throw new Exception(obj.ValidationErrorsString());
				ArrayList arrNombreParam = new ArrayList();
				ArrayList arrValoresParam = new ArrayList();
				arrNombreParam.Add("idsus");
				arrValoresParam.Add(null);
				arrNombreParam.Add(EntSegUsuarios.Fields.loginsus.ToString());
				arrValoresParam.Add(obj.loginsus);
				
				arrNombreParam.Add(EntSegUsuarios.Fields.passsus.ToString());
				arrValoresParam.Add(obj.passsus);
				
				arrNombreParam.Add(EntSegUsuarios.Fields.nombresus.ToString());
				arrValoresParam.Add(obj.nombresus);
				
				arrNombreParam.Add(EntSegUsuarios.Fields.apellidosus.ToString());
				arrValoresParam.Add(obj.apellidosus);
				
				arrNombreParam.Add(EntSegUsuarios.Fields.vigentesus.ToString());
				arrValoresParam.Add(obj.vigentesus);
				
				arrNombreParam.Add(EntSegUsuarios.Fields.fechavigentesus.ToString());
				arrValoresParam.Add(obj.fechavigentesus);
				
				arrNombreParam.Add(EntSegUsuarios.Fields.fechapasssus.ToString());
				arrValoresParam.Add(obj.fechapasssus);
				
				arrNombreParam.Add(EntSegUsuarios.Fields.usucresus.ToString());
				arrValoresParam.Add(obj.usucresus);
				
				
				//Llamamos al Procedmiento Almacenado
				CConn local = new CConn();
				string nombreSp = CListadoSp.SegUsuarios.spSusIns.ToString();
				return (local.execStoreProcedure(nombreSp, arrNombreParam, arrValoresParam) > 0);
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}

		/// <summary>
		/// 	Funcion que inserta un nuevo registro en la tabla segusuarios a partir de una clase del tipo Esegusuarios
		/// </summary>
		/// <param name="obj" type="Entidades.EntSegUsuarios">
		///     <para>
		/// 		 Clase desde la que se van a insertar los valores a la tabla segusuarios
		///     </para>
		/// </param>
		/// <param name="localTrans" type="App_Class.Conexion.CTrans">
		///     <para>
		/// 		 Clase desde la que se va a utilizar una transaccion segusuarios
		///     </para>
		/// </param>
		/// <returns>
		/// 	 Valor TRUE or FALSE que indica el exito de la operacionsegusuarios
		/// </returns>
		public bool Insert(EntSegUsuarios obj, ref CTrans localTrans, bool bValidar = true)
		{
			try
			{
				if (bValidar)
					if (!obj.IsValid())
						throw new Exception(obj.ValidationErrorsString());
				ArrayList arrNombreParam = new ArrayList();
				ArrayList arrValoresParam = new ArrayList();
				arrNombreParam.Add("idsus");
				arrValoresParam.Add("");
				arrNombreParam.Add(EntSegUsuarios.Fields.loginsus.ToString());
				arrValoresParam.Add(obj.loginsus);
				
				arrNombreParam.Add(EntSegUsuarios.Fields.passsus.ToString());
				arrValoresParam.Add(obj.passsus);
				
				arrNombreParam.Add(EntSegUsuarios.Fields.nombresus.ToString());
				arrValoresParam.Add(obj.nombresus);
				
				arrNombreParam.Add(EntSegUsuarios.Fields.apellidosus.ToString());
				arrValoresParam.Add(obj.apellidosus);
				
				arrNombreParam.Add(EntSegUsuarios.Fields.vigentesus.ToString());
				arrValoresParam.Add(obj.vigentesus);
				
				arrNombreParam.Add(EntSegUsuarios.Fields.fechavigentesus.ToString());
				arrValoresParam.Add(obj.fechavigentesus);
				
				arrNombreParam.Add(EntSegUsuarios.Fields.fechapasssus.ToString());
				arrValoresParam.Add(obj.fechapasssus);
				
				arrNombreParam.Add(EntSegUsuarios.Fields.usucresus.ToString());
				arrValoresParam.Add(obj.usucresus);
				
				
				//Llamamos al Procedmiento Almacenado
				CConn local = new CConn();
				string nombreSp = CListadoSp.SegUsuarios.spSusIns.ToString();
				return (local.execStoreProcedure(nombreSp, arrNombreParam, arrValoresParam, ref localTrans) > 0);
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}

		/// <summary>
		/// 	Funcion que inserta un nuevo registro en la tabla segusuarios a partir de una clase del tipo Esegusuarios
		/// </summary>
		/// <param name="obj" type="Entidades.EntSegUsuarios">
		///     <para>
		/// 		 Clase desde la que se van a insertar los valores a la tabla segusuarios
		///     </para>
		/// </param>
		/// <returns>
		/// 	 Valor que indica la cantidad de registros actualizados en segusuarios
		/// </returns>
		public int Update(EntSegUsuarios obj, bool bValidar = true)
		{
			try
			{
				if (bValidar)
					if (!obj.IsValid())
						throw new Exception(obj.ValidationErrorsString());
				ArrayList arrNombreParam = new ArrayList();
				ArrayList arrValoresParam = new ArrayList();
				arrNombreParam.Add(EntSegUsuarios.Fields.idsus.ToString());
				arrValoresParam.Add(obj.idsus);
				
				arrNombreParam.Add(EntSegUsuarios.Fields.loginsus.ToString());
				arrValoresParam.Add(obj.loginsus);
				
				arrNombreParam.Add(EntSegUsuarios.Fields.passsus.ToString());
				arrValoresParam.Add(obj.passsus);
				
				arrNombreParam.Add(EntSegUsuarios.Fields.nombresus.ToString());
				arrValoresParam.Add(obj.nombresus);
				
				arrNombreParam.Add(EntSegUsuarios.Fields.apellidosus.ToString());
				arrValoresParam.Add(obj.apellidosus);
				
				arrNombreParam.Add(EntSegUsuarios.Fields.vigentesus.ToString());
				arrValoresParam.Add(obj.vigentesus);
				
				arrNombreParam.Add(EntSegUsuarios.Fields.fechavigentesus.ToString());
				arrValoresParam.Add(obj.fechavigentesus);
				
				arrNombreParam.Add(EntSegUsuarios.Fields.fechapasssus.ToString());
				arrValoresParam.Add(obj.fechapasssus);
				
				arrNombreParam.Add(EntSegUsuarios.Fields.apitransaccionsus.ToString());
				arrValoresParam.Add(obj.apitransaccionsus);
				
				arrNombreParam.Add(EntSegUsuarios.Fields.usumodsus.ToString());
				arrValoresParam.Add(obj.usumodsus);
				
				
				//Llamamos al Procedmiento Almacenado
				CConn local = new CConn();
				string nombreSp = CListadoSp.SegUsuarios.spSusUpd.ToString();
				return local.execStoreProcedure(nombreSp, arrNombreParam, arrValoresParam);
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}

		/// <summary>
		/// 	Funcion que inserta un nuevo registro en la tabla segusuarios a partir de una clase del tipo Esegusuarios
		/// </summary>
		/// <param name="obj" type="Entidades.EntSegUsuarios">
		///     <para>
		/// 		 Clase desde la que se van a insertar los valores a la tabla segusuarios
		///     </para>
		/// </param>
		/// <param name="localTrans" type="App_Class.Conexion.CTrans">
		///     <para>
		/// 		 Clase desde la que se va a utilizar una transaccion segusuarios
		///     </para>
		/// </param>
		/// <returns>
		/// 	 Valor TRUE or FALSE que indica el exito de la operacionsegusuarios
		/// </returns>
		public int Update(EntSegUsuarios obj, ref CTrans localTrans, bool bValidar = true)
		{
			try
			{
				if (bValidar)
					if (!obj.IsValid())
						throw new Exception(obj.ValidationErrorsString());
				ArrayList arrNombreParam = new ArrayList();
				ArrayList arrValoresParam = new ArrayList();
				arrNombreParam.Add(EntSegUsuarios.Fields.idsus.ToString());
				arrValoresParam.Add(obj.idsus);
				
				arrNombreParam.Add(EntSegUsuarios.Fields.loginsus.ToString());
				arrValoresParam.Add(obj.loginsus);
				
				arrNombreParam.Add(EntSegUsuarios.Fields.passsus.ToString());
				arrValoresParam.Add(obj.passsus);
				
				arrNombreParam.Add(EntSegUsuarios.Fields.nombresus.ToString());
				arrValoresParam.Add(obj.nombresus);
				
				arrNombreParam.Add(EntSegUsuarios.Fields.apellidosus.ToString());
				arrValoresParam.Add(obj.apellidosus);
				
				arrNombreParam.Add(EntSegUsuarios.Fields.vigentesus.ToString());
				arrValoresParam.Add(obj.vigentesus);
				
				arrNombreParam.Add(EntSegUsuarios.Fields.fechavigentesus.ToString());
				arrValoresParam.Add(obj.fechavigentesus);
				
				arrNombreParam.Add(EntSegUsuarios.Fields.fechapasssus.ToString());
				arrValoresParam.Add(obj.fechapasssus);
				
				arrNombreParam.Add(EntSegUsuarios.Fields.apitransaccionsus.ToString());
				arrValoresParam.Add(obj.apitransaccionsus);
				
				arrNombreParam.Add(EntSegUsuarios.Fields.usumodsus.ToString());
				arrValoresParam.Add(obj.usumodsus);
				
				
				//Llamamos al Procedmiento Almacenado
				CConn local = new CConn();
				string nombreSp = CListadoSp.SegUsuarios.spSusUpd.ToString();
				return local.execStoreProcedure(nombreSp, arrNombreParam, arrValoresParam, ref localTrans);
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}

		/// <summary>
		/// 	Funcion que inserta un nuevo registro en la tabla segusuarios a partir de una clase del tipo Esegusuarios
		/// </summary>
		/// <param name="obj" type="Entidades.EntSegUsuarios">
		///     <para>
		/// 		 Clase desde la que se van a insertar los valores a la tabla segusuarios
		///     </para>
		/// </param>
		/// <returns>
		/// 	 Valor TRUE or FALSE que indica el exito de la operacionsegusuarios
		/// </returns>
		public int Delete(EntSegUsuarios obj, bool bValidar = true)
		{
			try
			{
				if (bValidar)
					if (!obj.IsValid())
						throw new Exception(obj.ValidationErrorsString());
				ArrayList arrNombreParam = new ArrayList();
				ArrayList arrValoresParam = new ArrayList();
				arrNombreParam.Add(EntSegUsuarios.Fields.idsus.ToString());
				arrValoresParam.Add(obj.idsus);
				
				
				//Llamamos al Procedmiento Almacenado
				CConn local = new CConn();
				string nombreSp = CListadoSp.SegUsuarios.spSusDel.ToString();
				return local.execStoreProcedure(nombreSp, arrNombreParam, arrValoresParam);
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}

		/// <summary>
		/// 	Funcion que inserta un nuevo registro en la tabla segusuarios a partir de una clase del tipo Esegusuarios
		/// </summary>
		/// <param name="obj" type="Entidades.EntSegUsuarios">
		///     <para>
		/// 		 Clase desde la que se van a insertar los valores a la tabla segusuarios
		///     </para>
		/// </param>
		/// <param name="localTrans" type="App_Class.Conexion.CTrans">
		///     <para>
		/// 		 Clase desde la que se va a utilizar una transaccion segusuarios
		///     </para>
		/// </param>
		/// <returns>
		/// 	 Valor TRUE or FALSE que indica el exito de la operacionsegusuarios
		/// </returns>
		public int Delete(EntSegUsuarios obj, ref CTrans localTrans, bool bValidar = true)
		{
			try
			{
				if (bValidar)
					if (!obj.IsValid())
						throw new Exception(obj.ValidationErrorsString());
				ArrayList arrNombreParam = new ArrayList();
				ArrayList arrValoresParam = new ArrayList();
				arrNombreParam.Add(EntSegUsuarios.Fields.idsus.ToString());
				arrValoresParam.Add(obj.idsus);
				
				
				//Llamamos al Procedmiento Almacenado
				CConn local = new CConn();
				string nombreSp = CListadoSp.SegUsuarios.spSusDel.ToString();
				return local.execStoreProcedure(nombreSp, arrNombreParam, arrValoresParam, ref localTrans);
			}
			catch (Exception exp)
			{
				throw exp;
			}
		}

		/// <summary>
		/// 	Funcion que inserta o actualiza un registro un nuevo registro en la tabla segusuarios a partir de una clase del tipo Esegusuarios
		/// </summary>
		/// <param name="obj" type="Entidades.EntSegUsuarios">
		///     <para>
		/// 		 Clase desde la que se van a insertar o actualizar los valores a la tabla segusuarios
		///     </para>
		/// </param>
		/// <returns>
		/// 	 Valor TRUE or FALSE que indica el exito de la operacionsegusuarios
		/// </returns>
		public int InsertUpdate(EntSegUsuarios obj)
		{
			try
			{
				bool esInsertar = true;
				
					esInsertar = (esInsertar && (obj.idsus == null));
				
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
		/// 	Funcion que inserta o actualiza un registro un nuevo registro en la tabla segusuarios a partir de una clase del tipo Esegusuarios
		/// </summary>
		/// <param name="obj" type="Entidades.EntSegUsuarios">
		///     <para>
		/// 		 Clase desde la que se van a insertar o actualizar los valores a la tabla segusuarios
		///     </para>
		/// </param>
		/// <param name="localTrans" type="App_Class.Conexion.CTrans">
		///     <para>
		/// 		 Clase desde la que se va a utilizar una transaccion segusuarios
		///     </para>
		/// </param>
		/// <returns>
		/// 	 Valor TRUE or FALSE que indica el exito de la operacionsegusuarios
		/// </returns>
		public int InsertUpdate(EntSegUsuarios obj, ref CTrans localTrans)
		{
			try
			{
				bool esInsertar = false;
				
					esInsertar = (esInsertar && (obj.idsus == null));
				
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
		/// 	 Objeto segusuarios
		/// </returns>
		internal EntSegUsuarios crearObjeto(DataRow row)
		{
			EntSegUsuarios obj = new EntSegUsuarios();
			obj.idsus = GetColumnType(row[EntSegUsuarios.Fields.idsus.ToString()], EntSegUsuarios.Fields.idsus);
			obj.loginsus = GetColumnType(row[EntSegUsuarios.Fields.loginsus.ToString()], EntSegUsuarios.Fields.loginsus);
			obj.passsus = GetColumnType(row[EntSegUsuarios.Fields.passsus.ToString()], EntSegUsuarios.Fields.passsus);
			obj.nombresus = GetColumnType(row[EntSegUsuarios.Fields.nombresus.ToString()], EntSegUsuarios.Fields.nombresus);
			obj.apellidosus = GetColumnType(row[EntSegUsuarios.Fields.apellidosus.ToString()], EntSegUsuarios.Fields.apellidosus);
			obj.vigentesus = GetColumnType(row[EntSegUsuarios.Fields.vigentesus.ToString()], EntSegUsuarios.Fields.vigentesus);
			obj.fechavigentesus = GetColumnType(row[EntSegUsuarios.Fields.fechavigentesus.ToString()], EntSegUsuarios.Fields.fechavigentesus);
			obj.fechapasssus = GetColumnType(row[EntSegUsuarios.Fields.fechapasssus.ToString()], EntSegUsuarios.Fields.fechapasssus);
			obj.apiestadosus = GetColumnType(row[EntSegUsuarios.Fields.apiestadosus.ToString()], EntSegUsuarios.Fields.apiestadosus);
			obj.apitransaccionsus = GetColumnType(row[EntSegUsuarios.Fields.apitransaccionsus.ToString()], EntSegUsuarios.Fields.apitransaccionsus);
			obj.usucresus = GetColumnType(row[EntSegUsuarios.Fields.usucresus.ToString()], EntSegUsuarios.Fields.usucresus);
			obj.feccresus = GetColumnType(row[EntSegUsuarios.Fields.feccresus.ToString()], EntSegUsuarios.Fields.feccresus);
			obj.usumodsus = GetColumnType(row[EntSegUsuarios.Fields.usumodsus.ToString()], EntSegUsuarios.Fields.usumodsus);
			obj.fecmodsus = GetColumnType(row[EntSegUsuarios.Fields.fecmodsus.ToString()], EntSegUsuarios.Fields.fecmodsus);
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
		/// 	 Objeto segusuarios
		/// </returns>
		internal EntSegUsuarios crearObjetoRevisado(DataRow row)
		{
			EntSegUsuarios obj = new EntSegUsuarios();
			if (row.Table.Columns.Contains(EntSegUsuarios.Fields.idsus.ToString()))
				obj.idsus = GetColumnType(row[EntSegUsuarios.Fields.idsus.ToString()], EntSegUsuarios.Fields.idsus);
			if (row.Table.Columns.Contains(EntSegUsuarios.Fields.loginsus.ToString()))
				obj.loginsus = GetColumnType(row[EntSegUsuarios.Fields.loginsus.ToString()], EntSegUsuarios.Fields.loginsus);
			if (row.Table.Columns.Contains(EntSegUsuarios.Fields.passsus.ToString()))
				obj.passsus = GetColumnType(row[EntSegUsuarios.Fields.passsus.ToString()], EntSegUsuarios.Fields.passsus);
			if (row.Table.Columns.Contains(EntSegUsuarios.Fields.nombresus.ToString()))
				obj.nombresus = GetColumnType(row[EntSegUsuarios.Fields.nombresus.ToString()], EntSegUsuarios.Fields.nombresus);
			if (row.Table.Columns.Contains(EntSegUsuarios.Fields.apellidosus.ToString()))
				obj.apellidosus = GetColumnType(row[EntSegUsuarios.Fields.apellidosus.ToString()], EntSegUsuarios.Fields.apellidosus);
			if (row.Table.Columns.Contains(EntSegUsuarios.Fields.vigentesus.ToString()))
				obj.vigentesus = GetColumnType(row[EntSegUsuarios.Fields.vigentesus.ToString()], EntSegUsuarios.Fields.vigentesus);
			if (row.Table.Columns.Contains(EntSegUsuarios.Fields.fechavigentesus.ToString()))
				obj.fechavigentesus = GetColumnType(row[EntSegUsuarios.Fields.fechavigentesus.ToString()], EntSegUsuarios.Fields.fechavigentesus);
			if (row.Table.Columns.Contains(EntSegUsuarios.Fields.fechapasssus.ToString()))
				obj.fechapasssus = GetColumnType(row[EntSegUsuarios.Fields.fechapasssus.ToString()], EntSegUsuarios.Fields.fechapasssus);
			if (row.Table.Columns.Contains(EntSegUsuarios.Fields.apiestadosus.ToString()))
				obj.apiestadosus = GetColumnType(row[EntSegUsuarios.Fields.apiestadosus.ToString()], EntSegUsuarios.Fields.apiestadosus);
			if (row.Table.Columns.Contains(EntSegUsuarios.Fields.apitransaccionsus.ToString()))
				obj.apitransaccionsus = GetColumnType(row[EntSegUsuarios.Fields.apitransaccionsus.ToString()], EntSegUsuarios.Fields.apitransaccionsus);
			if (row.Table.Columns.Contains(EntSegUsuarios.Fields.usucresus.ToString()))
				obj.usucresus = GetColumnType(row[EntSegUsuarios.Fields.usucresus.ToString()], EntSegUsuarios.Fields.usucresus);
			if (row.Table.Columns.Contains(EntSegUsuarios.Fields.feccresus.ToString()))
				obj.feccresus = GetColumnType(row[EntSegUsuarios.Fields.feccresus.ToString()], EntSegUsuarios.Fields.feccresus);
			if (row.Table.Columns.Contains(EntSegUsuarios.Fields.usumodsus.ToString()))
				obj.usumodsus = GetColumnType(row[EntSegUsuarios.Fields.usumodsus.ToString()], EntSegUsuarios.Fields.usumodsus);
			if (row.Table.Columns.Contains(EntSegUsuarios.Fields.fecmodsus.ToString()))
				obj.fecmodsus = GetColumnType(row[EntSegUsuarios.Fields.fecmodsus.ToString()], EntSegUsuarios.Fields.fecmodsus);
			return obj;
		}

		/// <summary>
		/// 	 Funcion que crea una Lista de objetos a partir de un DataTable
		/// </summary>
		/// <param name="dtsegusuarios" type="System.Data.DateTable">
		///     <para>
		/// 		 DataTable con el conjunto de Datos recuperados 
		///     </para>
		/// </param>
		/// <returns>
		/// 	 Lista de Objetos segusuarios
		/// </returns>
		internal List<EntSegUsuarios> crearLista(DataTable dtsegusuarios)
		{
			List<EntSegUsuarios> list = new List<EntSegUsuarios>();
			
			EntSegUsuarios obj = new EntSegUsuarios();
			foreach (DataRow row in dtsegusuarios.Rows)
			{
				obj = crearObjeto(row);
				list.Add(obj);
			}
			return list;
		}
		
		/// <summary>
		/// 	 Funcion que crea una Lista de objetos a partir de un DataTable y con solo algunas columnas
		/// </summary>
		/// <param name="dtsegusuarios" type="System.Data.DateTable">
		///     <para>
		/// 		 DataTable con el conjunto de Datos recuperados 
		///     </para>
		/// </param>
		/// <returns>
		/// 	 Lista de Objetos segusuarios
		/// </returns>
		internal List<EntSegUsuarios> crearListaRevisada(DataTable dtsegusuarios)
		{
			List<EntSegUsuarios> list = new List<EntSegUsuarios>();
			
			EntSegUsuarios obj = new EntSegUsuarios();
			foreach (DataRow row in dtsegusuarios.Rows)
			{
				obj = crearObjetoRevisado(row);
				list.Add(obj);
			}
			return list;
		}
		
		/// <summary>
		/// 	 Funcion que crea una Lista de objetos a partir de un DataTable
		/// </summary>
		/// <param name="dtsegusuarios" type="System.Data.DateTable">
		///     <para>
		/// 		 DataTable con el conjunto de Datos recuperados 
		///     </para>
		/// </param>
		/// <returns>
		/// 	 Cola de Objetos segusuarios
		/// </returns>
		internal Queue<EntSegUsuarios> crearCola(DataTable dtsegusuarios)
		{
			Queue<EntSegUsuarios> cola = new Queue<EntSegUsuarios>();
			
			EntSegUsuarios obj = new EntSegUsuarios();
			foreach (DataRow row in dtsegusuarios.Rows)
			{
				obj = crearObjeto(row);
				cola.Enqueue(obj);
			}
			return cola;
		}
		
		/// <summary>
		/// 	 Funcion que crea una Lista de objetos a partir de un DataTable
		/// </summary>
		/// <param name="dtsegusuarios" type="System.Data.DateTable">
		///     <para>
		/// 		 DataTable con el conjunto de Datos recuperados 
		///     </para>
		/// </param>
		/// <returns>
		/// 	 Pila de Objetos segusuarios
		/// </returns>
		internal Stack<EntSegUsuarios> crearPila(DataTable dtsegusuarios)
		{
			Stack<EntSegUsuarios> pila = new Stack<EntSegUsuarios>();
			
			EntSegUsuarios obj = new EntSegUsuarios();
			foreach (DataRow row in dtsegusuarios.Rows)
			{
				obj = crearObjeto(row);
				pila.Push(obj);
			}
			return pila;
		}
		
		/// <summary>
		/// 	 Funcion que crea un Dicionario a partir de un DataTable
		/// </summary>
		/// <param name="dtsegusuarios" type="System.Data.DateTable">
		///     <para>
		/// 		 DataTable con el conjunto de Datos recuperados 
		///     </para>
		/// </param>
		/// <returns>
		/// 	 Diccionario de Objetos segusuarios
		/// </returns>
		internal Dictionary<String, EntSegUsuarios> crearDiccionario(DataTable dtsegusuarios)
		{
			Dictionary<String, EntSegUsuarios>  miDic = new Dictionary<String, EntSegUsuarios>();
			
			EntSegUsuarios obj = new EntSegUsuarios();
			foreach (DataRow row in dtsegusuarios.Rows)
			{
				obj = crearObjeto(row);
				miDic.Add(obj.idsus.ToString(), obj);
			}
			return miDic;
		}
		
		/// <summary>
		/// 	 Funcion que crea un Dicionario a partir de un DataTable
		/// </summary>
		/// <param name="dtsegusuarios" type="System.Data.DateTable">
		///     <para>
		/// 		 DataTable con el conjunto de Datos recuperados 
		///     </para>
		/// </param>
		/// <returns>
		/// 	 HashTable de Objetos segusuarios
		/// </returns>
		internal Hashtable crearHashTable(DataTable dtsegusuarios)
		{
			Hashtable miTabla = new Hashtable();
			
			EntSegUsuarios obj = new EntSegUsuarios();
			foreach (DataRow row in dtsegusuarios.Rows)
			{
				obj = crearObjeto(row);
				miTabla.Add(obj.idsus.ToString(), obj);
			}
			return miTabla;
		}
		
		/// <summary>
		/// 	 Funcion que crea un Dicionario a partir de un DataTable y solo con columnas existentes
		/// </summary>
		/// <param name="dtsegusuarios" type="System.Data.DateTable">
		///     <para>
		/// 		 DataTable con el conjunto de Datos recuperados 
		///     </para>
		/// </param>
		/// <returns>
		/// 	 Diccionario de Objetos segusuarios
		/// </returns>
		internal Dictionary<String, EntSegUsuarios> crearDiccionarioRevisado(DataTable dtsegusuarios)
		{
			Dictionary<String, EntSegUsuarios>  miDic = new Dictionary<String, EntSegUsuarios>();
			
			EntSegUsuarios obj = new EntSegUsuarios();
			foreach (DataRow row in dtsegusuarios.Rows)
			{
				obj = crearObjetoRevisado(row);
				miDic.Add(obj.idsus.ToString(), obj);
			}
			return miDic;
		}
		
		internal Dictionary<String, EntSegUsuarios> crearDiccionario(DataTable dtsegusuarios, EntSegUsuarios.Fields dicKey)
		{
			Dictionary<String, EntSegUsuarios>  miDic = new Dictionary<String, EntSegUsuarios>();
			
			EntSegUsuarios obj = new EntSegUsuarios();
			foreach (DataRow row in dtsegusuarios.Rows)
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

