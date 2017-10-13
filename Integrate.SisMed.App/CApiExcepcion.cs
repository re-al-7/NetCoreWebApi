using System;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using Newtonsoft.Json.Linq;

namespace Integrate.SisMed.App
{
    class CApiExcepcion: Exception
    {
        
        public string error { get; set; }
        public string causa { get; set; }
        public string accion { get; set; }
        public string comentario { get; set; }
        public string origen { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public CApiExcepcion(HttpResponseMessage response)
        {
            if (response.StatusCode != HttpStatusCode.OK)
            {
                dynamic strErrorResult = JObject.Parse(response.Content.ReadAsStringAsync().Result);
                this.error = strErrorResult.error;
                this.causa = strErrorResult.causa;
                this.accion = strErrorResult.accion;
                this.comentario = strErrorResult.comentario;
                this.origen = strErrorResult.origen;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Mensaje de la excepcion</param>
        public CApiExcepcion(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="format">Formato de la excepcion</param>
        /// <param name="args">Array de argumentos</param>
        public CApiExcepcion(string format, params object[] args)
            : base(string.Format(format, args))
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Mensaje de la excepcion</param>
        /// <param name="innerException">Inner exception</param>
        public CApiExcepcion(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="format">Formato de la excepcion</param>
        /// <param name="innerException">Inner excepction</param>
        /// <param name="args">Array de argumentos</param>
        public CApiExcepcion(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="info">Información</param>
        /// <param name="context">Contexto de la excepcion</param>
        protected CApiExcepcion(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
