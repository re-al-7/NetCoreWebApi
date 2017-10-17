using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Integrate.SisMed.App.Dal
{
    public static class CApiAuth
    {
        internal static string StrToken = string.Empty;
        public static bool IsAuthenticated
        {
            get { return (!string.IsNullOrEmpty(StrToken)); }
        }

        public static bool GetToken(string strUserName, string strPassword)
        {
            bool bProcede = false;
            StrToken = string.Empty;
            using (HttpClient client = new HttpClient())
            {
                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("username", strUserName),
                    new KeyValuePair<string, string>("password", strPassword)
                });

                client.BaseAddress = new Uri(CParametros.StrBaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.PostAsync
                ("/api/token",
                    formContent).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    dynamic stResult = JObject.Parse(response.Content.ReadAsStringAsync().Result);
                    StrToken = stResult.access_token;
                    bProcede = true;
                }
            }
            return bProcede;
        }
    }
}
