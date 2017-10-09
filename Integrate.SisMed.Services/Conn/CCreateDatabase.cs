using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Integrate.SisMed.Services.Conn
{
    internal static class ExtensionMethod
    {
        public static T GetMyAttributeFrom<T>(this object instance, string propertyName) where T : Attribute
        {
            var attrType = typeof(T);
            var property = instance.GetType().GetProperty(propertyName);

            if (property.GetCustomAttributes(attrType, false).Length > 0)
                return (T)property.GetCustomAttributes(attrType, false).First();
            else
                return null;
        }
    }

    public class TableClass
    {
        private List<KeyValuePair<String, Type>> _miColumna = new List<KeyValuePair<string, Type>>();
        private string _miTabla = string.Empty;
        private Type _miClase = null;

        private Dictionary<Type, String> dataMapper
        {
            get
            {
                //
                Dictionary<Type, String> miDataMapper = new Dictionary<Type, string>();
                miDataMapper.Add(typeof(Int64), "BIGINT");
                miDataMapper.Add(typeof(Int64?), "BIGINT");
                miDataMapper.Add(typeof(int), "INTEGER");
                miDataMapper.Add(typeof(int?), "INTEGER");
                miDataMapper.Add(typeof(string), "CHARACTER VARYING");
                miDataMapper.Add(typeof(bool), "BOOLEAN");
                miDataMapper.Add(typeof(bool?), "BOOLEAN");
                miDataMapper.Add(typeof(DateTime), "TIMESTAMP WITHOUT TIME ZONE");
                miDataMapper.Add(typeof(DateTime?), "TIMESTAMP WITHOUT TIME ZONE");
                miDataMapper.Add(typeof(float), "FLOAT");
                miDataMapper.Add(typeof(float?), "FLOAT");
                //miDataMapper.Add(typeof(decimal), "DECIMAL(10,2)");
                //miDataMapper.Add(typeof(decimal?), "DECIMAL(10,2)");
                miDataMapper.Add(typeof(decimal), "NUMERIC");
                miDataMapper.Add(typeof(decimal?), "NUMERIC");
                miDataMapper.Add(typeof(Byte), "BYTEA");
                miDataMapper.Add(typeof(Byte?), "BYTEA");
                miDataMapper.Add(typeof(Guid), "UNIQUEIDENTIFIER");
                return miDataMapper;
            }
        }

        public List<KeyValuePair<String, Type>> Fields
        {
            get { return this._miColumna; }
            set { this._miColumna = value; }
        }

        public string ClassName
        {
            get { return this._miTabla; }
            set { this._miTabla = value; }
        }

        public TableClass(Type t)
        {
            this._miTabla = t.Name;
            this._miClase = t;

            foreach (PropertyInfo property in t.GetProperties())
            {
                KeyValuePair<String, Type> field = new KeyValuePair<string, Type>(property.Name, property.PropertyType);
                this.Fields.Add(field);
            }
        }

        public string CreateTableScript()
        {
            StringBuilder script = new StringBuilder();

            StringBuilder scriptPK = new StringBuilder();
            bool bPrimerElemntoPk = true;

            var instance = Activator.CreateInstance(this._miClase);
            script.AppendLine("CREATE TABLE " + this._miTabla);
            script.AppendLine("(");
            for (int i = 0; i < this.Fields.Count; i++)
            {
                KeyValuePair<String, Type> field = this.Fields[i];

                if (dataMapper.ContainsKey(field.Value))
                {
                    if (dataMapper[field.Value] == "CHARACTER VARYING")
                    {
                        if (instance.GetMyAttributeFrom<StringLengthAttribute>(field.Key) != null)
                            script.Append("\t" + field.Key + " " + dataMapper[field.Value] + "(" + instance.GetMyAttributeFrom<StringLengthAttribute>(field.Key).MaximumLength + ")");
                        else
                            script.Append("\t" + field.Key + " " + dataMapper[field.Value] + "(100)");
                    }
                    else
                    {
                        script.Append("\t" + field.Key + " " + dataMapper[field.Value]);
                    }
                }
                else
                {
                    //Complex Type
                    script.Append("\t" + field.Key + " COMPLEX");
                }

                //Ahora los DataAnnotations
                if (instance.GetMyAttributeFrom<RequiredAttribute>(field.Key) != null)
                    script.Append(" NOT NULL ");

                //Para los Defaults
                if (field.Key.ToUpper() == "APIESTADO")
                    script.Append(" DEFAULT 'ELABORADO'::character varying ");
                if (field.Key.ToUpper() == "APITRANSACCION")
                    script.Append(" DEFAULT 'CREAR'::character varying ");
                if (field.Key.ToUpper() == "USUCRE")
                    script.Append(" DEFAULT \"current_user\"() ");
                if (field.Key.ToUpper() == "FECCRE")
                    script.Append(" DEFAULT now() ");

                //Para los PK
                if (instance.GetMyAttributeFrom<KeyAttribute>(field.Key) != null)
                {
                    if (bPrimerElemntoPk)
                    {
                        scriptPK.Append(field.Key);
                        bPrimerElemntoPk = false;
                    }
                    else
                        scriptPK.Append(", " + field.Key);
                }

                if (i != this.Fields.Count - 1)
                    script.Append(",");

                //Para los COmentarios
                //if (instance.GetMyAttributeFrom<DisplayAttribute>(field.Key) != null)
                //    script.Append("//" + instance.GetMyAttributeFrom<DisplayAttribute>(field.Key).Description);

                script.Append(Environment.NewLine);
            }

            if (!bPrimerElemntoPk)
                script.AppendLine("\t, CONSTRAINT " + this._miTabla + "_pk PRIMARY KEY (" + scriptPK.ToString() + ")");

            script.AppendLine(");");

            return script.ToString();
        }
    }
}