using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Integrate.SisMed.App.Dal.Entidades;
using Newtonsoft.Json;

namespace Integrate.SisMed.App.Dal
{
    public class CApiObject
    {
        public string nombre { get; set; }
        public dynamic datos { get; set; }
    }    
}
