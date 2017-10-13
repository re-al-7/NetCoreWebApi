#region 
/***********************************************************************************************************
	NOMBRE:       ISegMensajeserror
	DESCRIPCION:
		Clase que define los metodos y operaciones sobre la Tabla segmensajeserror

	REVISIONES:
		Ver        FECHA       Autor            Descripcion 
		---------  ----------  ---------------  ------------------------------------
		1.0        09/10/2017  R Alonzo Vera A  Creacion 

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
	public interface ISegMensajeserror: IDisposable
	{
		string GetTableScript();
		dynamic GetColumnType(object valor,EntSegMensajeserror.Fields myField);
		dynamic GetColumnType(object valor, string strField);
		void SetDato(ref EntSegMensajeserror obj, string strPropiedad, dynamic dynValor);
		dynamic GetDato(ref EntSegMensajeserror obj, string strPropiedad);
		EntSegMensajeserror ObtenerObjetoInsertado(string strUsuCre);
		EntSegMensajeserror ObtenerObjeto(int interrorsme, String Stringaplicacionsap);
		EntSegMensajeserror ObtenerObjeto(int interrorsme, String Stringaplicacionsap, ref CTrans localTrans);
		EntSegMensajeserror ObtenerObjeto(ArrayList arrColumnasWhere, ArrayList arrValoresWhere);
		EntSegMensajeserror ObtenerObjeto(Hashtable htbFiltro);
		EntSegMensajeserror ObtenerObjeto(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, ref CTrans localTrans);
		EntSegMensajeserror ObtenerObjeto(Hashtable htbFiltro, ref CTrans localTrans);
		EntSegMensajeserror ObtenerObjeto(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParamAdicionales);
		EntSegMensajeserror ObtenerObjeto(Hashtable htbFiltro, string strParamAdicionales);
		EntSegMensajeserror ObtenerObjeto(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParamAdicionales, ref CTrans localTrans);
		EntSegMensajeserror ObtenerObjeto(Hashtable htbFiltro, string strParamAdicionales, ref CTrans localTrans);
		EntSegMensajeserror ObtenerObjeto(EntSegMensajeserror.Fields searchField, object searchValue);
		EntSegMensajeserror ObtenerObjeto(EntSegMensajeserror.Fields searchField, object searchValue, ref CTrans localTrans);
		EntSegMensajeserror ObtenerObjeto(EntSegMensajeserror.Fields searchField, object searchValue, string strParamAdicionales);
		EntSegMensajeserror ObtenerObjeto(EntSegMensajeserror.Fields searchField, object searchValue, string strParamAdicionales, ref CTrans localTrans);
		
		Dictionary<String, EntSegMensajeserror> ObtenerDiccionario();
		Dictionary<String, EntSegMensajeserror> ObtenerDiccionario(ArrayList arrColumnasWhere, ArrayList arrValoresWhere);
		Dictionary<String, EntSegMensajeserror> ObtenerDiccionario(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, ref CTrans localTrans);
		Dictionary<String, EntSegMensajeserror> ObtenerDiccionario(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParamAdicionales);
		Dictionary<String, EntSegMensajeserror> ObtenerDiccionario(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParamAdicionales, ref CTrans localTrans);
		Dictionary<String, EntSegMensajeserror> ObtenerDiccionario(EntSegMensajeserror.Fields searchField, object searchValue);
		Dictionary<String, EntSegMensajeserror> ObtenerDiccionario(EntSegMensajeserror.Fields searchField, object searchValue, ref CTrans localTrans);
		Dictionary<String, EntSegMensajeserror> ObtenerDiccionario(EntSegMensajeserror.Fields searchField, object searchValue, string strParamAdicionales);
		Dictionary<String, EntSegMensajeserror> ObtenerDiccionario(EntSegMensajeserror.Fields searchField, object searchValue, string strParamAdicionales, ref CTrans localTrans);
		
		List<EntSegMensajeserror> ObtenerLista();
		List<EntSegMensajeserror> ObtenerLista(ArrayList arrColumnasWhere, ArrayList arrValoresWhere);
		List<EntSegMensajeserror> ObtenerLista(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, ref CTrans localTrans);
		List<EntSegMensajeserror> ObtenerLista(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParamAdicionales);
		List<EntSegMensajeserror> ObtenerLista(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParamAdicionales, ref CTrans localTrans);
		List<EntSegMensajeserror> ObtenerLista(EntSegMensajeserror.Fields searchField, object searchValue);
		List<EntSegMensajeserror> ObtenerLista(EntSegMensajeserror.Fields searchField, object searchValue, ref CTrans localTrans);
		List<EntSegMensajeserror> ObtenerLista(EntSegMensajeserror.Fields searchField, object searchValue, string strParamAdicionales);
		List<EntSegMensajeserror> ObtenerLista(EntSegMensajeserror.Fields searchField, object searchValue, string strParamAdicionales, ref CTrans localTrans);
		
		List<EntSegMensajeserror> ObtenerLista(Hashtable htbFiltro);
		List<EntSegMensajeserror> ObtenerLista(Hashtable htbFiltro, string strParamAdicionales);
		List<EntSegMensajeserror> ObtenerLista(Hashtable htbFiltro, ref CTrans localTrans);
		List<EntSegMensajeserror> ObtenerLista(Hashtable htbFiltro, string strParamAdicionales, ref CTrans localTrans);
		
		List<EntSegMensajeserror> ObtenerListaDesdeVista(String strVista);
		List<EntSegMensajeserror> ObtenerListaDesdeVista(String strVista, ArrayList arrColumnasWhere, ArrayList arrValoresWhere);
		List<EntSegMensajeserror> ObtenerListaDesdeVista(String strVista, ArrayList arrColumnasWhere, ArrayList arrValoresWhere, ref CTrans localTrans);
		List<EntSegMensajeserror> ObtenerListaDesdeVista(String strVista, ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParamAdicionales);
		List<EntSegMensajeserror> ObtenerListaDesdeVista(String strVista, ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParamAdicionales, ref CTrans localTrans);
		List<EntSegMensajeserror> ObtenerListaDesdeVista(String strVista, Hashtable htbFiltro);
		List<EntSegMensajeserror> ObtenerListaDesdeVista(String strVista, Hashtable htbFiltro, ref CTrans localTrans);
		List<EntSegMensajeserror> ObtenerListaDesdeVista(String strVista, Hashtable htbFiltro, string strParamAdicionales);
		List<EntSegMensajeserror> ObtenerListaDesdeVista(String strVista, Hashtable htbFiltro, string strParamAdicionales, ref CTrans localTrans);
		List<EntSegMensajeserror> ObtenerListaDesdeVista(String strVista, EntSegMensajeserror.Fields searchField, object searchValue);
		List<EntSegMensajeserror> ObtenerListaDesdeVista(String strVista, EntSegMensajeserror.Fields searchField, object searchValue, ref CTrans localTrans);
		List<EntSegMensajeserror> ObtenerListaDesdeVista(String strVista, EntSegMensajeserror.Fields searchField, object searchValue, string strParamAdicionales);
		List<EntSegMensajeserror> ObtenerListaDesdeVista(String strVista, EntSegMensajeserror.Fields searchField, object searchValue, string strParamAdicionales, ref CTrans localTrans);
		
		Queue<EntSegMensajeserror> ObtenerCola();
		Queue<EntSegMensajeserror> ObtenerCola(ArrayList arrColumnasWhere, ArrayList arrValoresWhere);
		Queue<EntSegMensajeserror> ObtenerCola(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, ref CTrans localTrans);
		Queue<EntSegMensajeserror> ObtenerCola(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParamAdicionales);
		Queue<EntSegMensajeserror> ObtenerCola(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParamAdicionales, ref CTrans localTrans);
		Queue<EntSegMensajeserror> ObtenerCola(EntSegMensajeserror.Fields searchField, object searchValue);
		Queue<EntSegMensajeserror> ObtenerCola(EntSegMensajeserror.Fields searchField, object searchValue, ref CTrans localTrans);
		Queue<EntSegMensajeserror> ObtenerCola(EntSegMensajeserror.Fields searchField, object searchValue, string strParamAdicionales);
		Queue<EntSegMensajeserror> ObtenerCola(EntSegMensajeserror.Fields searchField, object searchValue, string strParamAdicionales, ref CTrans localTrans);
		
		Stack<EntSegMensajeserror> ObtenerPila();
		Stack<EntSegMensajeserror> ObtenerPila(ArrayList arrColumnasWhere, ArrayList arrValoresWhere);
		Stack<EntSegMensajeserror> ObtenerPila(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, ref CTrans localTrans);
		Stack<EntSegMensajeserror> ObtenerPila(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParamAdicionales);
		Stack<EntSegMensajeserror> ObtenerPila(ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParamAdicionales, ref CTrans localTrans);
		Stack<EntSegMensajeserror> ObtenerPila(EntSegMensajeserror.Fields searchField, object searchValue);
		Stack<EntSegMensajeserror> ObtenerPila(EntSegMensajeserror.Fields searchField, object searchValue, ref CTrans localTrans);
		Stack<EntSegMensajeserror> ObtenerPila(EntSegMensajeserror.Fields searchField, object searchValue, string strParamAdicionales);
		Stack<EntSegMensajeserror> ObtenerPila(EntSegMensajeserror.Fields searchField, object searchValue, string strParamAdicionales, ref CTrans localTrans);
		int EjecutarSpDesdeObjeto(string strNombreSp, EntSegMensajeserror obj);
		int EjecutarSpDesdeObjeto(string strNombreSp, EntSegMensajeserror obj, ref CTrans localTrans);
		
		string CreatePk(string[] args);
		
		int Update(EntSegMensajeserror obj, bool bValidar = true);
		int Update(EntSegMensajeserror obj, ref CTrans localTrans, bool bValidar = true);
		int Delete(EntSegMensajeserror obj, bool bValidar = true);
		int Delete(EntSegMensajeserror obj, ref CTrans localTrans, bool bValidar = true);
		int InsertUpdate(EntSegMensajeserror obj);
		int InsertUpdate(EntSegMensajeserror obj, ref CTrans localTrans);
		
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
		DataTable ObtenerDataTable(EntSegMensajeserror.Fields searchField, object searchValue);
		DataTable ObtenerDataTable(EntSegMensajeserror.Fields searchField, object searchValue, string strParamAdicionales);
		DataTable ObtenerDataTable(ArrayList arrColumnas, EntSegMensajeserror.Fields searchField, object searchValue);
		DataTable ObtenerDataTable(ArrayList arrColumnas, EntSegMensajeserror.Fields searchField, object searchValue, string strParametrosAdicionales);
		DataTable ObtenerDataTableOr(ArrayList arrColumnasWhere, ArrayList arrValoresWhere);
		DataTable ObtenerDataTableOr(ArrayList arrColumnas, ArrayList arrColumnasWhere, ArrayList arrValoresWhere);
		DataTable ObtenerDataTableOr(ArrayList arrColumnas, ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParametrosAdicionales);
		
		int FuncionesCount(EntSegMensajeserror.Fields refField);
		int FuncionesCount(EntSegMensajeserror.Fields refField, EntSegMensajeserror.Fields whereField, object valueField);
		int FuncionesCount(EntSegMensajeserror.Fields refField, ArrayList arrColumnasWhere, ArrayList arrValoresWhere);
		int FuncionesMin(EntSegMensajeserror.Fields refField);
		int FuncionesMin(EntSegMensajeserror.Fields refField, EntSegMensajeserror.Fields whereField, object valueField);
		int FuncionesMin(EntSegMensajeserror.Fields refField, ArrayList arrColumnasWhere, ArrayList arrValoresWhere);
		int FuncionesMax(EntSegMensajeserror.Fields refField);
		int FuncionesMax(EntSegMensajeserror.Fields refField, EntSegMensajeserror.Fields whereField, object valueField);
		int FuncionesMax(EntSegMensajeserror.Fields refField, ArrayList arrColumnasWhere, ArrayList arrValoresWhere);
		int FuncionesSum(EntSegMensajeserror.Fields refField);
		int FuncionesSum(EntSegMensajeserror.Fields refField, EntSegMensajeserror.Fields whereField, object valueField);
		int FuncionesSum(EntSegMensajeserror.Fields refField, ArrayList arrColumnasWhere, ArrayList arrValoresWhere);
		int FuncionesAvg(EntSegMensajeserror.Fields refField);
		int FuncionesAvg(EntSegMensajeserror.Fields refField, EntSegMensajeserror.Fields whereField, object valueField);
		int FuncionesAvg(EntSegMensajeserror.Fields refField, ArrayList arrColumnasWhere, ArrayList arrValoresWhere);
	}
}

