



#region

using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using Integrate.SisMed.Api.Services.Conn;
using Integrate.SisMed.Api.Services.Dal.Interface;

#endregion


namespace Integrate.SisMed.Api.Services.Dal.Modelo
{
    public class RnVista : IVista
    {
        /// <summary>
        /// Funcion que carga el resultado de una consulta SELECT de un DataTable
        /// </summary>
        /// <param name="vista">Nombre de la Vista</param>
        /// <returns>DataTable con el resultado de las consultas</returns>
        public DataTable ObtenerDatos(string vista)
        {
            try
            {
                ArrayList arrColumnasWhere = new ArrayList();
                arrColumnasWhere.Add("'1'");
                ArrayList arrValoresWhere = new ArrayList();
                arrValoresWhere.Add("'1'");

                ArrayList arrColumnas = new ArrayList();
                arrColumnas.Add("*");

                CConn local = new CConn();
                DataTable table = new DataTable();
                table = local.cargarDataTableAnd(vista, arrColumnas, arrColumnasWhere, arrValoresWhere);

                return table;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        /// <summary>
        /// Funcion que carga el resultado de una consulta SELECT de una vista a un DataTable
        /// </summary>
        /// <param name="vista">Nombre de la Vista</param>
        /// <param name="arrColumnas">Array de Columnas  seleccionadas en la Vista</param>
        /// <returns>DataTable con el resultado de la consulta</returns>
        public DataTable ObtenerDatos(string vista, ArrayList arrColumnas)
        {
            try
            {
                ArrayList arrColumnasWhere = new ArrayList();
                arrColumnasWhere.Add("'1'");
                ArrayList arrValoresWhere = new ArrayList();
                arrValoresWhere.Add("'1'");

                DataTable table = new DataTable();
                CConn local = new CConn();
                table = local.cargarDataTableAnd(vista.ToString(), arrColumnas, arrColumnasWhere, arrValoresWhere);

                return table;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        /// <summary>
        /// Funcion que carga el resultado de una consulta SELECT de una vista a un DataTable
        /// </summary>
        /// <param name="vista">Nombre de la Vista</param>
        /// <param name="arrColumnas">Array de Columnas  seleccionadas en la Vista</param>
        /// <param name="strParametrosAdicionales">Parametros adicionales</param>
        /// <returns>DataTable con el resultado de la consulta</returns>
        public DataTable ObtenerDatos(string vista, ArrayList arrColumnas, string strParametrosAdicionales)
        {
            try
            {
                ArrayList arrColumnasWhere = new ArrayList();
                arrColumnasWhere.Add("'1'");
                ArrayList arrValoresWhere = new ArrayList();
                arrValoresWhere.Add("'1'");

                DataTable table = new DataTable();
                CConn local = new CConn();
                table = local.cargarDataTableAnd(vista.ToString(), arrColumnas, arrColumnasWhere, arrValoresWhere, strParametrosAdicionales);

                return table;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        /// <summary>
        /// Funcion que carga el resultado de una consulta SELECT de una vista a un DataTable a partir de columnas filtradas
        /// </summary>
        /// <param name="vista">Nombre de la Vista</param>
        /// <param name="arrColumnasWhere">Nombre de las columnas por las que se va a filtrar el resultado</param>
        /// <param name="arrValoresWhere">Valor para cada una de las columnas con las que se va a filtrar el resultado</param>
        /// <returns>DatatTable con el resultado de la consulta</returns>
        public DataTable ObtenerDatos(string vista, ArrayList arrColumnasWhere, ArrayList arrValoresWhere)
        {
            try
            {
                ArrayList arrColumnas = new ArrayList();
                arrColumnas.Add("*");

                DataTable table = new DataTable();
                CConn local = new CConn();
                table = local.cargarDataTableAnd(vista.ToString(), arrColumnas, arrColumnasWhere, arrValoresWhere);

                return table;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        /// <summary>
        /// Funcion que carga el resultado de una consulta SELECT de determinadas columnas de una vista a un DataTable a partir de columnas filtradas
        /// </summary>
        /// <param name="vista">Nombre de la Vista</param>
        /// <param name="htbFiltro">HashTable con el filtro</param>
        /// <returns>DataTable con el resultado de la consulta</returns>
        public DataTable ObtenerDatos(string vista, Hashtable htbFiltro)
        {
            return ObtenerDatos(vista, htbFiltro, "");
        }


        public DataTable ObtenerDatos(string vista, Hashtable htbFiltro, string strParametrosAdicionales)
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
                
                return ObtenerDatos(vista, arrColumnasWhere, arrValoresWhere, strParametrosAdicionales);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }


        /// <summary>
        /// Funcion que carga el resultado de una consulta SELECT de determinadas columnas de una vista a un DataTable a partir de columnas filtradas
        /// </summary>
        /// <param name="vista">Nombre de la Vista</param>
        /// <param name="arrColumnas">Array de columnas seleccionadas de la Vista</param>
        /// <param name="arrColumnasWhere">Nombre de las columnas por las que se va a filtrar el resultado</param>
        /// <param name="arrValoresWhere">Valor para cada una de las columnas con las que se va a filtrar el resultado</param>
        /// <param name="strParametrosAdicionales">Condiciones adicionales concatenadas al final de la consulta</param>
        /// <returns>DataTable con el resultado de la consulta</returns>
        public DataTable ObtenerDatos(string vista, ArrayList arrColumnas, ArrayList arrColumnasWhere,
                                      ArrayList arrValoresWhere, string strParametrosAdicionales)
        {
            try
            {
                DataTable table = new DataTable();
                CConn local = new CConn();

                table = local.cargarDataTableAnd(vista.ToString(), arrColumnas, arrColumnasWhere, arrValoresWhere,
                                                 strParametrosAdicionales);

                return table;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public DataTable ObtenerDatosLike(string vista, ArrayList arrColumnas, ArrayList arrColumnasWhere, ArrayList arrValoresWhere, string strParametrosAdicionales)
        {
            try
            {
                DataTable table = new DataTable();
                CConn local = new CConn();

                table = local.cargarDataTableLike(vista.ToString(), arrColumnas, arrColumnasWhere, arrValoresWhere,
                                                 strParametrosAdicionales);

                return table;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        /// <summary>
        /// Funcion que carga el resultado de una consulta SELECT de determinadas columnas de una vista a un DataTable a partir de columnas filtradas
        /// </summary>
        /// <param name="vista">Nombre de la Vista</param>
        /// <param name="arrColumnas">Array de columnas seleccionadas de la Vista</param>
        /// <param name="arrColumnasWhere">Nombre de las columnas por las que se va a filtrar el resultado</param>
        /// <param name="arrValoresWhere">Valor para cada una de las columnas con las que se va a filtrar el resultado</param>
        /// <returns>DataTable con el resultado de la consulta</returns>
        public DataTable ObtenerDatos(string vista, ArrayList arrColumnas, ArrayList arrColumnasWhere,
                                      ArrayList arrValoresWhere)
        {
            try
            {
                DataTable table = new DataTable();
                CConn local = new CConn();

                table = local.cargarDataTableAnd(vista.ToString(), arrColumnas, arrColumnasWhere, arrValoresWhere);

                return table;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        
        /// <summary>
        /// Funcion que carga el resultado de una consulta SELECT de una vista a un DataTable a partir de columnas filtradas
        /// </summary>
        /// <param name="vista">Nombre de la Vista</param>
        /// <param name="arrColumnasWhere">Nombre de las columnas por las que se va a filtrar el resultado</param>
        /// <param name="arrValoresWhere">Valor para cada una de las columnas con las que se va a filtrar el resultado</param>
        /// <param name="strParametrosAdicionales">Condiciones adicionales concatenadas al final de la consulta</param>
        /// <returns>DataTable con el resultado de la Consulta</returns>
        public DataTable ObtenerDatos(string vista, ArrayList arrColumnasWhere, ArrayList arrValoresWhere,
                                      string strParametrosAdicionales)
        {
            try
            {
                ArrayList arrColumnas = new ArrayList();
                arrColumnas.Add("*");

                DataTable table = new DataTable();
                CConn local = new CConn();
                table = local.cargarDataTableAnd(vista.ToString(), arrColumnas, arrColumnasWhere, arrValoresWhere,
                                                 strParametrosAdicionales);
                
                return table;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public DbDataReader ObtenerDataReader(string vista, ArrayList arrColumnasWhere, ArrayList arrValoresWhere,
            string strParametrosAdicionales)
        {
            try
            {
                ArrayList arrColumnas = new ArrayList();
                arrColumnas.Add("*");

                CConn local = new CConn();
                DbDataReader table = local.cargarDataReaderAnd(vista.ToString(), arrColumnas, arrColumnasWhere, arrValoresWhere,
                    strParametrosAdicionales);
                return table;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        /// <summary>
        /// Funcion que carga el resultado de una consulta SELECT de una vista a un DataTable a partir de un filtro escrito manualmente
        /// </summary>
        /// <param name="vista">Nombre de la Vista</param>
        /// <param name="condicionesWhere">Condiciones adicionales concatenadas al final de la consulta</param>
        /// <returns>DataTable con el resultado de la Consulta</returns>
        public DataTable ObtenerDatos(string vista, string condicionesWhere)
        {
            try
            {
                ArrayList arrColumnas = new ArrayList();
                arrColumnas.Add("*");

                ArrayList arrColumnasWhere = new ArrayList();
                arrColumnasWhere.Add("'1'");
                ArrayList arrValoresWhere = new ArrayList();
                arrValoresWhere.Add("'1'");

                DataTable table = new DataTable();
                CConn local = new CConn();
                table = local.cargarDataTableOr(vista.ToString(), arrColumnas, arrColumnasWhere, arrValoresWhere,
                                                " AND (" + condicionesWhere + ")");

                return table;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }        

        /// <summary>
        /// Funcion que carga el resultado de una consulta SELECT de una vista a un DataTable a partir de columnas filtradas (Condiciones OR)
        /// </summary>
        /// <param name="vista">Nombre de la Vista</param>
        /// <param name="arrColumnasWhere">Nombre de las columnas por las que se va a filtrar el resultado</param>
        /// <param name="arrValoresWhere">Valor para cada una de las columnas con las que se va a filtrar el resultado</param>
        /// <returns>DataTable con el resultado de la consulta</returns>
        public DataTable ObtenerDatosOr(string vista, ArrayList arrColumnasWhere, ArrayList arrValoresWhere)
        {
            try
            {
                ArrayList arrColumnas = new ArrayList();
                arrColumnas.Add("*");

                DataTable table = new DataTable();
                CConn local = new CConn();
                table = local.cargarDataTableOr(vista.ToString(), arrColumnas, arrColumnasWhere, arrValoresWhere);

                return table;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        /// <summary>
        /// Funcion que carga el resultado de una consulta SELECT de determinadas columnas de una vista a un DataTable a partir de columnas filtradas (Condiciones OR)
        /// </summary>
        /// <param name="vista">Nombre de la Vista</param>
        /// <param name="arrColumnas">Nombre de las columnas seleccionadas</param>
        /// <param name="arrColumnasWhere">Nombre de las columnas por las que se va a filtrar el resultado</param>
        /// <param name="arrValoresWhere">Valor para cada una de las columnas con las que se va a filtrar el resultado</param>
        /// <param name="strParametrosAdicionales"></param>
        /// <returns>DataTable con el resultado de la consulta</returns>
        public DataTable ObtenerDatosOr(string vista, ArrayList arrColumnas, ArrayList arrColumnasWhere,
                                        ArrayList arrValoresWhere, string strParametrosAdicionales)
        {
            try
            {
                DataTable table = new DataTable();
                CConn local = new CConn();

                table = local.cargarDataTableOr(vista.ToString(), arrColumnas, arrColumnasWhere, arrValoresWhere,
                                                strParametrosAdicionales);

                return table;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vista"></param>
        /// <param name="arrColumnasWhere"></param>
        /// <param name="arrValoresWhere"></param>
        /// <param name="strParametrosAdicionales"></param>
        /// <returns></returns>
        public DataTable ObtenerDatosOr(string vista, ArrayList arrColumnasWhere, ArrayList arrValoresWhere,
                                        string strParametrosAdicionales)
        {
            try
            {
                ArrayList arrColumnas = new ArrayList();
                arrColumnas.Add("*");

                DataTable table = new DataTable();
                CConn local = new CConn();
                table = local.cargarDataTableOr(vista.ToString(), arrColumnas, arrColumnasWhere, arrValoresWhere,
                                                strParametrosAdicionales);

                return table;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombreProcAlm"></param>
        /// <param name="arrParametros"></param>
        /// <returns></returns>
        public DataTable ObtenerDatosProcAlm(string nombreProcAlm, ArrayList arrParametros)
        {
            try
            {
                DataTable table = new DataTable();
                CConn local = new CConn();
                table = local.execStoreProcedureToDataTable(nombreProcAlm, arrParametros);

                return table;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombreProcAlm"></param>
        /// <returns></returns>
        public DataTable ObtenerDatosProcAlm(string nombreProcAlm)
        {
            try
            {
                DataTable table = new DataTable();
                CConn local = new CConn();
                table = local.execStoreProcedureToDataTable(nombreProcAlm);

                return table;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombreProcAlm"></param>
        /// <param name="arrNombreParametros"></param>
        /// <param name="arrParametros"></param>
        /// <returns></returns>
        public DataTable ObtenerDatosProcAlm(string nombreProcAlm, ArrayList arrNombreParametros, ArrayList arrParametros)
        {
            try
            {
                DataTable table = new DataTable();
                CConn local = new CConn();
                table = local.execStoreProcedureToDataTable(nombreProcAlm, arrNombreParametros, arrParametros);

                return table;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombreProcAlm"></param>
        /// <param name="arrNombreParametros"></param>
        /// <param name="arrParametros"></param>
        /// <returns></returns>
        public DataTable ObtenerDatosProcAlm(string nombreProcAlm, ArrayList arrNombreParametros, ArrayList arrParametros, ref CTrans myTrans)
        {
            try
            {
                DataTable table = new DataTable();
                CConn local = new CConn();
                table = local.execStoreProcedureToDataTable(nombreProcAlm, arrNombreParametros, arrParametros, ref myTrans);

                return table;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombreProcAlm"></param>                
        /// <returns></returns>
        public int EjecutarProcAlm(string nombreProcAlm)
        {
            try
            {
                CConn local = new CConn();
                int iTotal = local.execStoreProcedure(nombreProcAlm) ? 1 :0;
                return iTotal;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombreProcAlm"></param>        
        /// <param name="arrParametros"></param>
        /// <returns></returns>
        public int EjecutarProcAlm(string nombreProcAlm, ArrayList arrParametros)
        {
            try
            {
                CConn local = new CConn();
                int iTotal = local.execStoreProcedure(nombreProcAlm, arrParametros) ? 1 :0;
                return iTotal;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombreProcAlm"></param>
        /// <param name="arrNombreParametros"></param>
        /// <param name="arrParametros"></param>
        /// <returns></returns>
        public int EjecutarProcAlm(string nombreProcAlm, ArrayList arrNombreParametros, ArrayList arrParametros)
        {
            try
            {
                CConn local = new CConn();
                int iTotal = local.execStoreProcedure(nombreProcAlm, arrNombreParametros, arrParametros);
                return iTotal;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombreProcAlm"></param>
        /// <param name="arrNombreParametros"></param>
        /// <param name="arrParametros"></param>
        /// <returns></returns>
        public int EjecutarProcAlm(string nombreProcAlm, ArrayList arrNombreParametros, ArrayList arrParametros, ref CTrans myTrans)
        {
            try
            {
                CConn local = new CConn();
                int iTotal = local.execStoreProcedure(nombreProcAlm, arrNombreParametros, arrParametros, ref myTrans);
                return iTotal;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
    }
}
