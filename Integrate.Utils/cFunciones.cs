#region

/* ****************************************************** */
/* GENERADO POR: ReAl ClassGenerator
/* SISTEMA: AP
/* AUTOR: R. Alonzo Vera
/* FECHA: 04/10/2010  -  18:15
/* ****************************************************** */

#endregion

namespace Integrate.Utils
{
    using System;
    using System.Text;
    using System.Data;
    using System.IO;
    using System.Diagnostics;

    public static class cFunciones
    {
        /// <summary>
        ///     Sentencia IF
        /// </summary>
        /// <param name="condicion" type="bool">
        ///     <para>
        ///         Condicion
        ///     </para>
        /// </param>
        /// <param name="TruePart" type="string">
        ///     <para>
        ///         TRUE part
        ///     </para>
        /// </param>
        /// <param name="FalsePart" type="string">
        ///     <para>
        ///         FALSE part
        ///     </para>
        /// </param>
        /// <returns>
        ///     Valor que varia dependiendo de la condicion
        /// </returns>
        public static object iif(bool condicion, object TruePart, object FalsePart)
        {
            if (condicion)
                return TruePart;
            return FalsePart;
        }

        /// <summary>
        ///     Función que exporta un DataTable a una hoja excel temporal
        /// </summary>
        /// <param name="Data" type="System.Data.DataTable">
        ///     <para>
        ///         DataTable para ser exportado
        ///     </para>
        /// </param>
        /// <param name="Titulo" type="string">
        ///     <para>
        ///         Titulo de la hoja Excel
        ///     </para>
        /// </param>
        public static void convertDataTableToExcel(DataTable Data, string Titulo)
        {
            string Separador = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator;

            StringBuilder sb = new StringBuilder();
            string aux = string.Empty;

            sb.Append(aux.Substring(0, aux.Length));

            aux = Titulo;
            sb.AppendLine(aux.Substring(0, aux.Length));

            aux = "";
            sb.AppendLine(aux.Substring(0, aux.Length));
            aux = string.Empty;

            foreach (DataColumn col in Data.Columns)
            {
                aux = (String.Format("{0}{1}" + Separador, aux, col.ColumnName));
            }

            if (aux.Length == 0)
                sb.AppendLine(aux.Substring(0, aux.Length));

            else
                sb.AppendLine(aux.Substring(0, aux.Length - 1));
            aux = String.Empty;

            foreach (DataRow row in Data.Rows)
            {

                foreach (DataColumn col in Data.Columns)
                {
                    string celda;

                    if (row[col.ColumnName].ToString().StartsWith("01/01/0001"))
                        celda = row[col.ColumnName].ToString().Replace("01/01/0001", "");

                    else if (row[col.ColumnName].ToString().EndsWith("00:00"))
                        celda = row[col.ColumnName].ToString().Replace("00:00", "");

                    else if (row[col.ColumnName].ToString().EndsWith("12:00:00 a.m."))
                        celda = row[col.ColumnName].ToString().Replace("12:00:00 a.m.", "");

                    else
                        celda = row[col.ColumnName].ToString();

                    aux = (String.Format("{0}{1}" + Separador, aux, celda));
                }

                if (aux.Length == 0)
                    sb.AppendLine(aux.Substring(0, aux.Length));

                else
                    sb.AppendLine(aux.Substring(0, aux.Length - 1));
                aux = String.Empty;
            }

            //CREAMOS UN ARCHIVO TEMPORAL
            string FileName = string.Format("{0}{1}.csv", Environment.GetEnvironmentVariable("TEMP"), Guid.NewGuid());
            StreamWriter str = new StreamWriter(FileName, false, Encoding.UTF8);

            str.Write(sb);
            str.Close();

            Process.Start("excel", FileName);
        }

        /// <summary>
        ///     Funcion que UNE dos DataTables en uno solo
        /// </summary>
        /// <param name="first" type="DataTable">
        ///     <para>
        ///         Primer DataTable
        ///     </para>
        /// </param>
        /// <param name="second" type="DataTable">
        ///     <para>
        ///         Segundo DataTable
        ///     </para>
        /// </param>
        public static DataTable unionDataTable(DataTable first, DataTable second)
        {
            //Result table
            DataTable table = new DataTable("Union");
            //Build new columns
            DataColumn[] newcolumns = new DataColumn[first.Columns.Count];

            for (int i = 0; i < first.Columns.Count; i++)
            {
                newcolumns[i] = new DataColumn(first.Columns[i].ColumnName,
                first.Columns[i].DataType);
            }
            //add new columns to result table
            table.Columns.AddRange(newcolumns);
            table.BeginLoadData();

            //Load data from first table
            foreach (DataRow row in first.Rows)
            {
                table.LoadDataRow(row.ItemArray, true);
            }

            //Load data from second table
            foreach (DataRow row in second.Rows)
            {
                table.LoadDataRow(row.ItemArray, true);
            }
            table.EndLoadData();
            return table;
        }

        /// <summary>
        ///     Funcion que evalua si un dia es laboral o no
        /// </summary>
        /// <param name="Fecha" type="System.DateTime">
        ///     <para>
        ///         Fecha a ser evaluada
        ///     </para>
        /// </param>
        /// <returns>
        ///     Valor TRUE si el dia es laboral, FALSE si no es dia laboral
        /// </returns>
        public static bool esDiaLaboral(DateTime fecha)
        {
            //Domingo   = 0
            //Lunes     = 1
            //Martes    = 2
            //Miercoles = 3
            //Jueves    = 4
            //Viernes   = 5
            //Sabado    = 6
            int day = (int)fecha.DayOfWeek;

            if (day > 0 && day < 6)
                return true;

            else
                return false;
        }

    }
}

