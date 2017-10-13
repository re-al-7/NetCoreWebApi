



#region

using System.Collections;
using System.Data;
using Integrate.SisMed.Api.Services.Conn;

#endregion


namespace Integrate.SisMed.Api.Services.Dal.Interface
{
    interface IVista
    {
        DataTable ObtenerDatos(string vista);
        DataTable ObtenerDatos(string vista, string condicionesWhere);
		DataTable ObtenerDatos(string vista, ArrayList arrColumnas);
		DataTable ObtenerDatos(string vista, ArrayList arrColumnasWhere, ArrayList arrValoresWhere);
		DataTable ObtenerDatosOr(string vista, ArrayList arrColumnasWhere, ArrayList arrValoresWhere);		
		DataTable ObtenerDatos(string vista, ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParametrosAdicionales);
		DataTable ObtenerDatosOr(string vista, ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParametrosAdicionales);
		DataTable ObtenerDatos(string vista, ArrayList arrColumnas, ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParametrosAdicionales);
		DataTable ObtenerDatosOr(string vista, ArrayList arrColumnas, ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParametrosAdicionales);				
        DataTable ObtenerDatosProcAlm(string nombreProcAlm, ArrayList arrParametros);
        DataTable ObtenerDatosProcAlm(string nombreProcAlm);
        DataTable ObtenerDatosProcAlm(string nombreProcAlm, ArrayList arrNombreParametros, ArrayList arrParametros);
        DataTable ObtenerDatosProcAlm(string nombreProcAlm, ArrayList arrNombreParametros, ArrayList arrParametros, ref CTrans myTrans);

        int EjecutarProcAlm(string nombreProcAlm, ArrayList arrNombreParametros, ArrayList arrParametros);
        int EjecutarProcAlm(string nombreProcAlm, ArrayList arrNombreParametros, ArrayList arrParametros, ref CTrans myTrans);

		//void CargarGridView(string vista, ref GridView dtg, ArrayList arrColumnas);
		//void CargarGridView(string vista, ref GridView dtg);
		//void CargarGridView(string vista,ref GridView dtg, ArrayList arrColumnasWhere, ArrayList arrValoresWhere);
		//void CargarGridViewOr(string vista,ref GridView dtg, ArrayList arrColumnasWhere, ArrayList arrValoresWhere);
		//void CargarReAlView(string vista, ref ReAlFind_Control.ReAlListView dtg);
		//void CargarReAlView(string vista, ref ReAlFind_Control.ReAlListView dtg, string strParametrosAdicionales);
		//void CargarReAlView(string vista, ref ReAlFind_Control.ReAlListView dtg, ArrayList arrColumnas);
		//void CargarReAlView(string vista, ref ReAlFind_Control.ReAlListView dtg, ArrayList arrColumnas, ArrayList arrColumnasWhere, ArrayList arrValoresWhere);
		//void CargarReAlView(string vista, ref ReAlFind_Control.ReAlListView dtg, ArrayList arrColumnas, ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParametrosAdicionales);
		//void CargarReAlView(string vista, ref ReAlFind_Control.ReAlListView dtg, ArrayList arrColumnasWhere, ArrayList arrValoresWhere);
		//void CargarReAlView(string vista, ref ReAlFind_Control.ReAlListView dtg, ArrayList arrColumnasWhere, ArrayList arrValoresWhere, bool CondicionOR);
		//void CargarReAlView(string vista, ref DevExpress.XtraGrid.GridControl dtg, ArrayList arrColumnas, ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParametrosAdicionales);
    }
}
