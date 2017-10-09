using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Integrate.SisMed.BusinessObjects.Entidades;
using Integrate.SisMed.Services.Dal.Modelo;
using Npgsql;

namespace Integrate.SisMed.Services
{
    public static class CUtilsApi
    {
        public static object GetInstance(string strFullyQualifiedName)
        {
            Type type = Type.GetType(strFullyQualifiedName);
            if (type != null)
                return Activator.CreateInstance(type);
            foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                type = asm.GetType(strFullyQualifiedName);
                if (type != null)
                    return Activator.CreateInstance(type);
            }
            return null;
        }

        /// <summary>
        /// Replaces the first occurrence of a string with another string in a given string
        /// The replacement is case insensitive
        /// Test Coverage: Included
        /// </summary>
        /// <param name="val"></param>
        /// <param name="stringToReplace">The string to replace</param>
        /// <param name="replacement">The string by which to be replaced</param>
        /// <returns>Copy of string with the string replaced</returns>
        public static string ReplaceFirst(string val, string stringToReplace, string replacement)
        {
            Regex regEx = new Regex(stringToReplace, RegexOptions.Multiline);
            return regEx.Replace(val, replacement, 1);
        }

        public static void CargarError(Exception _myExp, out string mensaje, out string causa,out string accion,out string comentario,out string origen)
        {
            mensaje = "";
            causa = "";
            accion = "";
            comentario = "";
            origen = "";
            try
            {
                var rn = new RnSegMensajeserror();
                EntSegMensajeserror obj = new EntSegMensajeserror();
                
                if (_myExp.GetType() == typeof(PostgresException))
                {
                    NpgsqlException sqlExp = (NpgsqlException)_myExp;

                    string strCodigoError = sqlExp.Message.Replace("P0001: ", "");

                    obj = rn.ObtenerObjeto(EntSegMensajeserror.Fields.aplicacionerrorsme, "'" + strCodigoError.Substring(0, 9) + "'");

                    if (obj != null)
                    {
                        string descripcionMsg = obj.descripcionsme;
                        string errorMsg = sqlExp.Message;

                        while (descripcionMsg.Contains("%n"))
                        {
                            int indiceInicio = errorMsg.IndexOf("##");
                            errorMsg = ReplaceFirst(errorMsg, "##", " ");
                            int indiceFinal = errorMsg.IndexOf("##");
                            if (indiceFinal < 0)
                            {
                                indiceFinal = errorMsg.Length;
                            }
                            string strVariable = errorMsg.Substring(indiceInicio, indiceFinal - indiceInicio);
                            descripcionMsg = ReplaceFirst(descripcionMsg, "%n", strVariable);
                        }

                        mensaje = obj.aplicacionerrorsme + ": " + descripcionMsg;
                        causa = obj.causasme;
                        accion = obj.accionsme;
                        comentario = obj.comentariosme;
                        origen = obj.origensme;                        
                    }
                    else
                    {
                        mensaje = "Se ha producido un error. Revise el Detalle adjunto.";
                        causa = sqlExp.Message;
                    }
                }
                else
                {
                    obj = rn.ObtenerObjeto(EntSegMensajeserror.Fields.aplicacionerrorsme, "'" + _myExp.Message.Substring(0, 9) + "'");

                    if (obj != null)
                    {
                        string descripcionMsg = obj.descripcionsme;
                        string errorMsg = _myExp.Message;

                        while (descripcionMsg.Contains("%n"))
                        {
                            int indiceInicio = errorMsg.IndexOf("##");
                            errorMsg = ReplaceFirst(errorMsg, "##", " ");
                            int indiceFinal = errorMsg.IndexOf("##");
                            if (indiceFinal < 0)
                            {
                                indiceFinal = errorMsg.Length;
                            }
                            string strVariable = errorMsg.Substring(indiceInicio, indiceFinal - indiceInicio);
                            descripcionMsg = ReplaceFirst(descripcionMsg, "%n", strVariable);
                        }

                        mensaje = obj.aplicacionerrorsme + ": " + descripcionMsg;
                        causa =  obj.causasme;
                        accion = obj.accionsme;
                        comentario = obj.comentariosme;
                        origen = obj.origensme;
                    }
                    else
                    {
                        mensaje = _myExp.Message;
                        causa = _myExp.StackTrace;                        
                    }
                }
            }
            catch (Exception exp)
            {
                mensaje = _myExp.Message;
                causa = _myExp.StackTrace;
            }
        }
    }
}
