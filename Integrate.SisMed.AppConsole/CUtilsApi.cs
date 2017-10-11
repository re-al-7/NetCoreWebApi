using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrate.SisMed.AppConsole
{
    public class CApiObject
    {
        public string nombre { get; set; }
        public dynamic datos { get; set; }
    }

    

    public static class CUtilsApi
    {
        public static CApiObject PostTable(dynamic obj)
        {
            var objApi = new CApiObject();
            objApi.nombre = "SegUsuarios";
            objApi.datos = obj;
            return objApi;
        }        
    }
}
