#region 
/***********************************************************************************************************
	NOMBRE:       ISegUsuarios
	DESCRIPCION:
		Clase que define los metodos y operaciones sobre la Tabla segusuarios

	REVISIONES:
		Ver        FECHA       Autor            Descripcion 
		---------  ----------  ---------------  ------------------------------------
		1.0        06/10/2017  R Alonzo Vera A  Creacion 

*************************************************************************************************************/
#endregion



#region

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Integrate.SisMed.Api.BusinessObjects;
using Integrate.SisMed.Api.Services.Conn;

#endregion

namespace Integrate.SisMed.Api.Services.Dal.Interface
{
	public interface ISegUsuarios: IDisposable
	{
		string GetTableScript();
		dynamic GetColumnType(object valor,EntSegUsuarios.Fields myField);
		dynamic GetColumnType(object valor, string strField);
		void SetDato(ref EntSegUsuarios obj, string strPropiedad, dynamic dynValor);
		dynamic GetDato(ref EntSegUsuarios obj, string strPropiedad);
		EntSegUsuarios ObtenerObjetoInsertado(string strUsuCre);
		EntSegUsuarios ObtenerObjeto(int intidsus);
		EntSegUsuarios ObtenerObjeto(int intidsus, ref CTrans localTrans);
		EntSegUsuarios ObtenerObjeto(ArrayList arrColumnasWhere, ArrayList arrValoresWhere);
		EntSegUsuarios ObtenerObjeto(Hashtable htbFiltro);
		EntSegUsuarios ObtenerObjeto(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, ref CTrans localTrans);
		EntSegUsuarios ObtenerObjeto(Hashtable htbFiltro, ref CTrans localTrans);
		EntSegUsuarios ObtenerObjeto(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParamAdicionales);
		EntSegUsuarios ObtenerObjeto(Hashtable htbFiltro, string strParamAdicionales);
		EntSegUsuarios ObtenerObjeto(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParamAdicionales, ref CTrans localTrans);
		EntSegUsuarios ObtenerObjeto(Hashtable htbFiltro, string strParamAdicionales, ref CTrans localTrans);
		EntSegUsuarios ObtenerObjeto(EntSegUsuarios.Fields searchField, object searchValue);
		EntSegUsuarios ObtenerObjeto(EntSegUsuarios.Fields searchField, object searchValue, ref CTrans localTrans);
		EntSegUsuarios ObtenerObjeto(EntSegUsuarios.Fields searchField, object searchValue, string strParamAdicionales);
		EntSegUsuarios ObtenerObjeto(EntSegUsuarios.Fields searchField, object searchValue, string strParamAdicionales, ref CTrans localTrans);
		
		Dictionary<String, EntSegUsuarios> ObtenerDiccionario();
		Dictionary<String, EntSegUsuarios> ObtenerDiccionario(ArrayList arrColumnasWhere, ArrayList arrValoresWhere);
		Dictionary<String, EntSegUsuarios> ObtenerDiccionario(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, ref CTrans localTrans);
		Dictionary<String, EntSegUsuarios> ObtenerDiccionario(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParamAdicionales);
		Dictionary<String, EntSegUsuarios> ObtenerDiccionario(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParamAdicionales, ref CTrans localTrans);
		Dictionary<String, EntSegUsuarios> ObtenerDiccionario(EntSegUsuarios.Fields searchField, object searchValue);
		Dictionary<String, EntSegUsuarios> ObtenerDiccionario(EntSegUsuarios.Fields searchField, object searchValue, ref CTrans localTrans);
		Dictionary<String, EntSegUsuarios> ObtenerDiccionario(EntSegUsuarios.Fields searchField, object searchValue, string strParamAdicionales);
		Dictionary<String, EntSegUsuarios> ObtenerDiccionario(EntSegUsuarios.Fields searchField, object searchValue, string strParamAdicionales, ref CTrans localTrans);
		
		List<EntSegUsuarios> ObtenerLista();
		List<EntSegUsuarios> ObtenerLista(ArrayList arrColumnasWhere, ArrayList arrValoresWhere);
		List<EntSegUsuarios> ObtenerLista(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, ref CTrans localTrans);
		List<EntSegUsuarios> ObtenerLista(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParamAdicionales);
		List<EntSegUsuarios> ObtenerLista(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParamAdicionales, ref CTrans localTrans);
		List<EntSegUsuarios> ObtenerLista(EntSegUsuarios.Fields searchField, object searchValue);
		List<EntSegUsuarios> ObtenerLista(EntSegUsuarios.Fields searchField, object searchValue, ref CTrans localTrans);
		List<EntSegUsuarios> ObtenerLista(EntSegUsuarios.Fields searchField, object searchValue, string strParamAdicionales);
		List<EntSegUsuarios> ObtenerLista(EntSegUsuarios.Fields searchField, object searchValue, string strParamAdicionales, ref CTrans localTrans);
		
		List<EntSegUsuarios> ObtenerLista(Hashtable htbFiltro);
		List<EntSegUsuarios> ObtenerLista(Hashtable htbFiltro, string strParamAdicionales);
		List<EntSegUsuarios> ObtenerLista(Hashtable htbFiltro, ref CTrans localTrans);
		List<EntSegUsuarios> ObtenerLista(Hashtable htbFiltro, string strParamAdicionales, ref CTrans localTrans);
		
		List<EntSegUsuarios> ObtenerListaDesdeVista(String strVista);
		List<EntSegUsuarios> ObtenerListaDesdeVista(String strVista, ArrayList arrColumnasWhere, ArrayList arrValoresWhere);
		List<EntSegUsuarios> ObtenerListaDesdeVista(String strVista, ArrayList arrColumnasWhere, ArrayList arrValoresWhere, ref CTrans localTrans);
		List<EntSegUsuarios> ObtenerListaDesdeVista(String strVista, ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParamAdicionales);
		List<EntSegUsuarios> ObtenerListaDesdeVista(String strVista, ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParamAdicionales, ref CTrans localTrans);
		List<EntSegUsuarios> ObtenerListaDesdeVista(String strVista, Hashtable htbFiltro);
		List<EntSegUsuarios> ObtenerListaDesdeVista(String strVista, Hashtable htbFiltro, ref CTrans localTrans);
		List<EntSegUsuarios> ObtenerListaDesdeVista(String strVista, Hashtable htbFiltro, string strParamAdicionales);
		List<EntSegUsuarios> ObtenerListaDesdeVista(String strVista, Hashtable htbFiltro, string strParamAdicionales, ref CTrans localTrans);
		List<EntSegUsuarios> ObtenerListaDesdeVista(String strVista, EntSegUsuarios.Fields searchField, object searchValue);
		List<EntSegUsuarios> ObtenerListaDesdeVista(String strVista, EntSegUsuarios.Fields searchField, object searchValue, ref CTrans localTrans);
		List<EntSegUsuarios> ObtenerListaDesdeVista(String strVista, EntSegUsuarios.Fields searchField, object searchValue, string strParamAdicionales);
		List<EntSegUsuarios> ObtenerListaDesdeVista(String strVista, EntSegUsuarios.Fields searchField, object searchValue, string strParamAdicionales, ref CTrans localTrans);
		
		Queue<EntSegUsuarios> ObtenerCola();
		Queue<EntSegUsuarios> ObtenerCola(ArrayList arrColumnasWhere, ArrayList arrValoresWhere);
		Queue<EntSegUsuarios> ObtenerCola(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, ref CTrans localTrans);
		Queue<EntSegUsuarios> ObtenerCola(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParamAdicionales);
		Queue<EntSegUsuarios> ObtenerCola(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParamAdicionales, ref CTrans localTrans);
		Queue<EntSegUsuarios> ObtenerCola(EntSegUsuarios.Fields searchField, object searchValue);
		Queue<EntSegUsuarios> ObtenerCola(EntSegUsuarios.Fields searchField, object searchValue, ref CTrans localTrans);
		Queue<EntSegUsuarios> ObtenerCola(EntSegUsuarios.Fields searchField, object searchValue, string strParamAdicionales);
		Queue<EntSegUsuarios> ObtenerCola(EntSegUsuarios.Fields searchField, object searchValue, string strParamAdicionales, ref CTrans localTrans);
		
		Stack<EntSegUsuarios> ObtenerPila();
		Stack<EntSegUsuarios> ObtenerPila(ArrayList arrColumnasWhere, ArrayList arrValoresWhere);
		Stack<EntSegUsuarios> ObtenerPila(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, ref CTrans localTrans);
		Stack<EntSegUsuarios> ObtenerPila(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParamAdicionales);
		Stack<EntSegUsuarios> ObtenerPila(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParamAdicionales, ref CTrans localTrans);
		Stack<EntSegUsuarios> ObtenerPila(EntSegUsuarios.Fields searchField, object searchValue);
		Stack<EntSegUsuarios> ObtenerPila(EntSegUsuarios.Fields searchField, object searchValue, ref CTrans localTrans);
		Stack<EntSegUsuarios> ObtenerPila(EntSegUsuarios.Fields searchField, object searchValue, string strParamAdicionales);
		Stack<EntSegUsuarios> ObtenerPila(EntSegUsuarios.Fields searchField, object searchValue, string strParamAdicionales, ref CTrans localTrans);
		int EjecutarSpDesdeObjeto(string strNombreSp, EntSegUsuarios obj);
		int EjecutarSpDesdeObjeto(string strNombreSp, EntSegUsuarios obj, ref CTrans localTrans);
		
		string CreatePk(string[] args);
		
		bool Insert(EntSegUsuarios obj, bool bValidar = true);
		bool Insert(EntSegUsuarios obj, ref CTrans localTrans, bool bValidar = true);
		int Update(EntSegUsuarios obj, bool bValidar = true);
		int Update(EntSegUsuarios obj, ref CTrans localTrans, bool bValidar = true);
		int Delete(EntSegUsuarios obj, bool bValidar = true);
		int Delete(EntSegUsuarios obj, ref CTrans localTrans, bool bValidar = true);
		int InsertUpdate(EntSegUsuarios obj);
		int InsertUpdate(EntSegUsuarios obj, ref CTrans localTrans);
		
		DataTable NuevoDataTable();
		DataTable NuevoDataTable(ArrayList arrColumnas);
		DataTable ObtenerDataTable();
		DataTable ObtenerDataTable(String condicionesWhere);
		DataTable ObtenerDataTable(ArrayList arrColumnas);
		DataTable ObtenerDataTable(ArrayList arrColumnas, String strParametrosAdicionales);
		DataTable ObtenerDataTable(ArrayList arrColumnas, ArrayList arrColumnasWhere, ArrayList arrValoresWhere);
		DataTable ObtenerDataTable(ArrayList arrColumnas, Hashtable htbFiltro);
		DataTable ObtenerDataTable(ArrayList arrColumnasWhere, ArrayList arrValoresWhere);
		DataTable ObtenerDataTable(Hashtable htbFiltro);
		DataTable ObtenerDataTable(ArrayList arrColumnas, ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParametrosAdicionales);
		DataTable ObtenerDataTable(ArrayList arrColumnas, Hashtable htbFiltro, string strParametrosAdicionales);
		DataTable ObtenerDataTable(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParametrosAdicionales);
		DataTable ObtenerDataTable(Hashtable htbFiltro, string strParametrosAdicionales);
		DataTable ObtenerDataTable(EntSegUsuarios.Fields searchField, object searchValue);
		DataTable ObtenerDataTable(EntSegUsuarios.Fields searchField, object searchValue, string strParamAdicionales);
		DataTable ObtenerDataTable(ArrayList arrColumnas, EntSegUsuarios.Fields searchField, object searchValue);
		DataTable ObtenerDataTable(ArrayList arrColumnas, EntSegUsuarios.Fields searchField, object searchValue, string strParametrosAdicionales);
		DataTable ObtenerDataTableOr(ArrayList arrColumnasWhere, ArrayList arrValoresWhere);
		DataTable ObtenerDataTableOr(ArrayList arrColumnas, ArrayList arrColumnasWhere, ArrayList arrValoresWhere);
		DataTable ObtenerDataTableOr(ArrayList arrColumnas, ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParametrosAdicionales);
		
		
		int FuncionesCount(EntSegUsuarios.Fields refField);
		int FuncionesCount(EntSegUsuarios.Fields refField, EntSegUsuarios.Fields whereField, object valueField);
		int FuncionesCount(EntSegUsuarios.Fields refField, ArrayList arrColumnasWhere, ArrayList arrValoresWhere);
		int FuncionesMin(EntSegUsuarios.Fields refField);
		int FuncionesMin(EntSegUsuarios.Fields refField, EntSegUsuarios.Fields whereField, object valueField);
		int FuncionesMin(EntSegUsuarios.Fields refField, ArrayList arrColumnasWhere, ArrayList arrValoresWhere);
		int FuncionesMax(EntSegUsuarios.Fields refField);
		int FuncionesMax(EntSegUsuarios.Fields refField, EntSegUsuarios.Fields whereField, object valueField);
		int FuncionesMax(EntSegUsuarios.Fields refField, ArrayList arrColumnasWhere, ArrayList arrValoresWhere);
		int FuncionesSum(EntSegUsuarios.Fields refField);
		int FuncionesSum(EntSegUsuarios.Fields refField, EntSegUsuarios.Fields whereField, object valueField);
		int FuncionesSum(EntSegUsuarios.Fields refField, ArrayList arrColumnasWhere, ArrayList arrValoresWhere);
		int FuncionesAvg(EntSegUsuarios.Fields refField);
		int FuncionesAvg(EntSegUsuarios.Fields refField, EntSegUsuarios.Fields whereField, object valueField);
		int FuncionesAvg(EntSegUsuarios.Fields refField, ArrayList arrColumnasWhere, ArrayList arrValoresWhere);
	}
}

