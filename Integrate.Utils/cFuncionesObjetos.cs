using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Integrate.Utils
{
    using System.ComponentModel;
    using System.Data;
    using System.IO;
    using System.Reflection;
    using System.Xml.Serialization;

    public static class cFuncionesObjetos
    {
        public static byte[] SerializeDataRow(DataRow row)
        {
            if (row == default(DataRow))
                return default(byte[]);

            MemoryStream memStream = new MemoryStream();
            XmlSerializer serializer = new XmlSerializer(typeof(object[]));
            serializer.Serialize(memStream, row.ItemArray);

            return memStream.ToArray();
        }

        public static void DeserializeDataRow(DataTable table, byte[] rowBytes)
        {
            if (table == default(DataTable) || rowBytes == default(byte[]))
                return;

            MemoryStream memStream = new MemoryStream(rowBytes);
            XmlSerializer serializer = new XmlSerializer(typeof(object[]));
            table.Rows.Add((object[])serializer.Deserialize(memStream));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static DataTable ConvertToDataTable(Object o)
        {
            PropertyInfo[] properties = o.GetType().GetProperties();
            DataTable dt = CreateDataTable(properties);
            FillData(properties, dt, o);
            return dt;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static DataTable ConvertToDataTable(Object[] array)
        {
            PropertyInfo[] properties = array.GetType().GetElementType().GetProperties();
            DataTable dt = CreateDataTable(properties);

            if (array.Length != 0)
            {
                foreach (object o in array)
                    FillData(properties, dt, o);

            }

            return dt;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="properties"></param>
        /// <returns></returns>
        private static DataTable CreateDataTable(PropertyInfo[] properties)
        {
            DataTable dt = new DataTable();
            DataColumn dc = null;

            foreach (PropertyInfo pi in properties)
            {
                dc = new DataColumn();
                dc.ColumnName = pi.Name;
                dc.DataType = pi.PropertyType;

                dt.Columns.Add(dc);
            }

            return dt;
        }


        /// <summary>
        ///
        /// </summary>
        /// <param name="properties"></param>
        /// <param name="dt"></param>
        /// <param name="o"></param>
        private static void FillData(PropertyInfo[] properties, DataTable dt, Object o)
        {
            DataRow dr = dt.NewRow();

            foreach (PropertyInfo pi in properties)
                dr[pi.Name] = pi.GetValue(o, null);

            dt.Rows.Add(dr);
        }


        public static DataTable ToDataTable<T>(IList<T> data)
        {
            try
            {
                PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
                DataTable table = new DataTable();
                for (int i = 0; i < props.Count; i++)
                {
                    PropertyDescriptor prop = props[i];
                    if (prop.PropertyType.FullName.ToUpper().Contains("NULL"))
                        table.Columns.Add(prop.Name);
                    else
                        table.Columns.Add(prop.Name);
                }
                object[] values = new object[props.Count];
                foreach (T item in data)
                {
                    for (int i = 0; i < values.Length; i++)
                    {
                        values[i] = props[i].GetValue(item).ToString().ToUpper();
                    }
                    table.Rows.Add(values);
                }
                return table;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public static List<T> ToCollection<T>(DataTable dataTable) where T : new()
        {
            List<T> miLista = new List<T>();

            //Obtenemos los nombres de las columnas
            List<string> columnsNames = new List<string>();
            foreach (DataColumn DataColumn in dataTable.Columns)
                columnsNames.Add(DataColumn.ColumnName);

            //Populamos la lista
            T obj = new T();
            string columnname = "";
            string value = "";
            PropertyInfo[] Properties;
            Properties = typeof(T).GetProperties();

            foreach (DataRow row in dataTable.Rows)
            {
                foreach (PropertyInfo objProperty in Properties)
                {
                    columnname = columnsNames.Find(name => name.ToLower() == objProperty.Name.ToLower());
                    if (!string.IsNullOrEmpty(columnname))
                    {
                        value = row[columnname].ToString();
                        if (!string.IsNullOrEmpty(value))
                        {
                            if (Nullable.GetUnderlyingType(objProperty.PropertyType) != null)
                            {
                                value = row[columnname].ToString().Replace("$", "").Replace(",", "");
                                objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(Nullable.GetUnderlyingType(objProperty.PropertyType).ToString())), null);
                            }
                            else
                            {
                                value = row[columnname].ToString().Replace("%", "");
                                objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(objProperty.PropertyType.ToString())), null);
                            }
                        }
                    }
                }
            }
            return miLista;
        }
    }
}
