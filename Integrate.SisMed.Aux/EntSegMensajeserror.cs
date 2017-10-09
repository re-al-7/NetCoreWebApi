#region 
/***********************************************************************************************************
	NOMBRE:       EntSegMensajeserror
	DESCRIPCION:
		Clase que define un objeto para la Tabla segmensajeserror

	REVISIONES:
		Ver        FECHA       Autor            Descripcion 
		---------  ----------  ---------------  ------------------------------------
		1.0        09/10/2017  R Alonzo Vera A  Creacion 

*************************************************************************************************************/
#endregion


#region
using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization;
#endregion

namespace Integrate.SisMed.BusinessObjects.Entidades
{
	public class EntSegMensajeserror
	{
		public const string StrNombreTabla = "segmensajeserror";
		public const string StrAliasTabla = "Sme";
		public enum Fields
		{
			errorsme
			,aplicacionsap
			,aplicacionerrorsme
			,descripcionsme
			,causasme
			,accionsme
			,comentariosme
			,origensme
			,apiestadosme
			,apitransaccionsme
			,usucresme
			,feccresme
			,usumodsme
			,fecmodsme

		}
		
		#region Constructoress
		
		public EntSegMensajeserror()
		{
			//Inicializacion de Variables
			aplicacionsap = null;
			aplicacionerrorsme = null;
			descripcionsme = null;
			causasme = null;
			accionsme = null;
			comentariosme = null;
			origensme = null;
			apiestadosme = null;
			apitransaccionsme = null;
			usucresme = null;
			usumodsme = null;
			fecmodsme = null;
		}
		
		public EntSegMensajeserror(EntSegMensajeserror obj)
		{
			errorsme = obj.errorsme;
			aplicacionsap = obj.aplicacionsap;
			aplicacionerrorsme = obj.aplicacionerrorsme;
			descripcionsme = obj.descripcionsme;
			causasme = obj.causasme;
			accionsme = obj.accionsme;
			comentariosme = obj.comentariosme;
			origensme = obj.origensme;
			apiestadosme = obj.apiestadosme;
			apitransaccionsme = obj.apitransaccionsme;
			usucresme = obj.usucresme;
			feccresme = obj.feccresme;
			usumodsme = obj.usumodsme;
			fecmodsme = obj.fecmodsme;
		}
		
		#endregion
		
		#region Metodos Privados
		
		/// <summary>
		/// Obtiene el Hash a partir de un array de Bytes
		/// </summary>
		/// <param name="objectAsBytes"></param>
		/// <returns>string</returns>
		private string ComputeHash(byte[] objectAsBytes)
		{
			MD5 md5 = new MD5CryptoServiceProvider();
			try
			{
				byte[] result = md5.ComputeHash(objectAsBytes);
				
				StringBuilder sb = new StringBuilder();
				for (int i = 0; i < result.Length; i++)
				{
					sb.Append(result[i].ToString("X2"));
				}
				
				return sb.ToString();
			}
			catch (ArgumentNullException ane)
			{
				return null;
			}
		}
		
		/// <summary>
		///     Obtienen el Hash basado en algun algoritmo de Encriptación
		/// </summary>
		/// <typeparam name="T">
		///     Algoritmo de encriptación
		/// </typeparam>
		/// <param name="cryptoServiceProvider">
		///     Provvedor de Servicios de Criptografía
		/// </param>
		/// <returns>
		///     String que representa el Hash calculado
		        /// </returns>
		private string computeHash<T>( T cryptoServiceProvider) where T : HashAlgorithm, new()
		{
			DataContractSerializer serializer = new DataContractSerializer(this.GetType());
			using (MemoryStream memoryStream = new MemoryStream())
			{
				serializer.WriteObject(memoryStream, this);
				cryptoServiceProvider.ComputeHash(memoryStream.ToArray());
				return Convert.ToBase64String(cryptoServiceProvider.Hash);
			}
		}
		
		#endregion
		
		#region Overrides
		
		/// <summary>
		/// Devuelve un String que representa al Objeto
		/// </summary>
		/// <returns>string</returns>
		public override string ToString()
		{
			string hashString;
			
			//Evitar parametros NULL
			if (this == null)
				throw new ArgumentNullException("Parametro NULL no es valido");
			
			//Se verifica si el objeto es serializable.
			try
			{
				MemoryStream memStream = new MemoryStream();
				XmlSerializer serializer = new XmlSerializer(typeof(EntSegMensajeserror));
				serializer.Serialize(memStream, this);
				
				//Ahora se obtiene el Hash del Objeto.
				hashString = ComputeHash(memStream.ToArray());
				
				return hashString;
			}
			catch (AmbiguousMatchException ame)
			{
				throw new ApplicationException("El Objeto no es Serializable. Message:" + ame.Message);
			}
		}
		
		/// <summary>
		/// Verifica que dos objetos sean identicos
		/// </summary>
		public static bool operator ==(EntSegMensajeserror first, EntSegMensajeserror second)
		{
			// Verifica si el puntero en memoria es el mismo
			if (Object.ReferenceEquals(first, second))
				return true;
			
			// Verifica valores nulos
			if ((object) first == null || (object) second == null)
				return false;
			
			return first.GetHashCode() == second.GetHashCode();
		}
		
		/// <summary>
		/// Verifica que dos objetos sean distintos
		/// </summary>
		public static bool operator !=(EntSegMensajeserror first, EntSegMensajeserror second)
		{
			return !(first == second);
		}
		
		/// <summary>
		/// Compara este objeto con otro
		/// </summary>
		/// <param name="obj">El objeto a comparar</param>
		/// <returns>Devuelve Verdadero si ambos objetos son iguales</returns>
		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;
			
			if (obj.GetType() == this.GetType())
				return obj.GetHashCode() == this.GetHashCode();
			
			return false;
		}
		
		#endregion
		
		/// <summary>
		/// Propiedad publica de tipo int que representa a la columna errorsme de la Tabla segmensajeserror
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: Yes
		/// Es ForeignKey: No
		/// </summary>
		public int errorsme { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo String que representa a la columna aplicacionsap de la Tabla segmensajeserror
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: Yes
		/// Es ForeignKey: Yes
		/// </summary>
		public String aplicacionsap { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo String que representa a la columna aplicacionerrorsme de la Tabla segmensajeserror
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		public String aplicacionerrorsme { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo String que representa a la columna descripcionsme de la Tabla segmensajeserror
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		public String descripcionsme { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo String que representa a la columna causasme de la Tabla segmensajeserror
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		public String causasme { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo String que representa a la columna accionsme de la Tabla segmensajeserror
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		public String accionsme { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo String que representa a la columna comentariosme de la Tabla segmensajeserror
		/// Permite Null: Yes
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		public String comentariosme { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo String que representa a la columna origensme de la Tabla segmensajeserror
		/// Permite Null: Yes
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		public String origensme { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo String que representa a la columna apiestadosme de la Tabla segmensajeserror
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		public String apiestadosme { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo String que representa a la columna apitransaccionsme de la Tabla segmensajeserror
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		public String apitransaccionsme { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo String que representa a la columna usucresme de la Tabla segmensajeserror
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		public String usucresme { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo DateTime que representa a la columna feccresme de la Tabla segmensajeserror
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		public DateTime feccresme { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo String que representa a la columna usumodsme de la Tabla segmensajeserror
		/// Permite Null: Yes
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		public String usumodsme { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo DateTime que representa a la columna fecmodsme de la Tabla segmensajeserror
		/// Permite Null: Yes
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		public DateTime? fecmodsme { get; set; } 

	}
}

