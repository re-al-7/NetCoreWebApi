#region 
/***********************************************************************************************************
	NOMBRE:       EntSegParametros
	DESCRIPCION:
		Clase que define un objeto para la Tabla segparametros

	REVISIONES:
		Ver        FECHA       Autor            Descripcion 
		---------  ----------  ---------------  ------------------------------------
		1.0        13/10/2017  R Alonzo Vera A  Creacion 

*************************************************************************************************************/
#endregion


#region
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Numerics;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization;
#endregion

namespace Integrate.SisMed.App.Dal.Entidades
{
	[Table("segparametros")]
	public class EntSegParametros
	{
		public const string StrNombreTabla = "SegParametros";
		public const string StrAliasTabla = "Spa";
		public enum Fields
		{
			siglaspa
			,descripcionspa
			,apiestadospa
			,apitransaccionspa
			,usucrespa
			,feccrespa
			,usumodspa
			,fecmodspa

		}
		
		#region Constructoress
		
		public EntSegParametros()
		{
			//Inicializacion de Variables
			siglaspa = null;
			descripcionspa = null;
			apiestadospa = null;
			apitransaccionspa = null;
			usucrespa = null;
			usumodspa = null;
			fecmodspa = null;
		}
		
		public EntSegParametros(EntSegParametros obj)
		{
			siglaspa = obj.siglaspa;
			descripcionspa = obj.descripcionspa;
			apiestadospa = obj.apiestadospa;
			apitransaccionspa = obj.apitransaccionspa;
			usucrespa = obj.usucrespa;
			feccrespa = obj.feccrespa;
			usumodspa = obj.usumodspa;
			fecmodspa = obj.fecmodspa;
		}
		
		#endregion
		
		#region Metodos Estaticos
		/// <summary>
		/// Funcion para obtener un objeto para el API y sus datos
		/// </summary>
		/// <returns>Objeto de tipo CApiObject con los datos para enviar al API</returns>
		public CApiObject CreateApiObject()
		{
			var objApi = new CApiObject();
			objApi.nombre = EntSegParametros.StrNombreTabla;
			objApi.datos = this;
			return objApi;
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
				XmlSerializer serializer = new XmlSerializer(typeof(EntSegParametros));
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
		public static bool operator ==(EntSegParametros first, EntSegParametros second)
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
		public static bool operator !=(EntSegParametros first, EntSegParametros second)
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
		
		#region DataAnnotations
		
		/// <summary>
		/// Obtiene los errores basado en los DataAnnotations 
		/// </summary>
		/// <returns>Devuelve un IList del tipo ValidationResult con los errores obtenidos</returns>
		public IList<ValidationResult> ValidationErrors()
		{
			ValidationContext context = new ValidationContext(this, null, null);
			IList<ValidationResult> errors = new List<ValidationResult>();
			
			if (!Validator.TryValidateObject(this, context, errors, true))
				return errors;
			
			return new List<ValidationResult>(0);
		}
		
		/// <summary>
		/// Obtiene los errores basado en los DataAnnotations 
		/// </summary>
		/// <returns>Devuelve un String con los errores obtenidos</returns>
		public string ValidationErrorsString()
		{
			string strErrors = "";
			ValidationContext context = new ValidationContext(this, null, null);
			IList<ValidationResult> errors = new List<ValidationResult>();
			
			if (!Validator.TryValidateObject(this, context, errors, true))
			{
				foreach (ValidationResult result in errors)
					strErrors = strErrors + result.ErrorMessage + Environment.NewLine;
			}
			return strErrors;
		}
		
		/// <summary>
		/// Funcion que determina si un objeto es valido o no
		/// </summary>
		/// <returns>Resultado de la validacion</returns>
		public bool IsValid()
		{
			ValidationContext context = new ValidationContext(this, null, null);
			IList<ValidationResult> errors = new List<ValidationResult>();
			
			return Validator.TryValidateObject(this, context, errors, true);
		}
		
		#endregion
		
		/// <summary>
		/// Propiedad publica de tipo String que representa a la columna siglaspa de la Tabla segparametros
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: Yes
		/// Es ForeignKey: No
		/// </summary>
		[StringLength(3, MinimumLength=0)]
		[Display(Name = "siglaspa", Description = " Propiedad publica de tipo String que representa a la columna siglaspa de la Tabla segparametros")]
		[Required(AllowEmptyStrings = true, ErrorMessage = "siglaspa es un campo requerido.")]
		[Key]
		public String siglaspa { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo String que representa a la columna descripcionspa de la Tabla segparametros
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[StringLength(180, MinimumLength=0)]
		[Display(Name = "descripcionspa", Description = " Propiedad publica de tipo String que representa a la columna descripcionspa de la Tabla segparametros")]
		[Required(AllowEmptyStrings = true, ErrorMessage = "descripcionspa es un campo requerido.")]
		public String descripcionspa { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo String que representa a la columna apiestadospa de la Tabla segparametros
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[StringLength(15, MinimumLength=0)]
		[Display(Name = "apiestadospa", Description = " Propiedad publica de tipo String que representa a la columna apiestadospa de la Tabla segparametros")]
		[EnumDataType(typeof(CApi.Estado))]
		public String apiestadospa { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo String que representa a la columna apitransaccionspa de la Tabla segparametros
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[StringLength(15, MinimumLength=0)]
		[Display(Name = "apitransaccionspa", Description = " Propiedad publica de tipo String que representa a la columna apitransaccionspa de la Tabla segparametros")]
		[EnumDataType(typeof(CApi.Transaccion))]
		public String apitransaccionspa { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo String que representa a la columna usucrespa de la Tabla segparametros
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[StringLength(15, MinimumLength=0)]
		[Display(Name = "usucrespa", Description = " Propiedad publica de tipo String que representa a la columna usucrespa de la Tabla segparametros")]
		public String usucrespa { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo DateTime que representa a la columna feccrespa de la Tabla segparametros
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[DataType(DataType.DateTime, ErrorMessage = "Fecha invalida")]
		[DisplayFormat(DataFormatString = "{ 0:dd/MM/yyyy HH:mm:ss.ffffff}", ApplyFormatInEditMode = true)]
		[Display(Name = "feccrespa", Description = " Propiedad publica de tipo DateTime que representa a la columna feccrespa de la Tabla segparametros")]
		public DateTime feccrespa { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo String que representa a la columna usumodspa de la Tabla segparametros
		/// Permite Null: Yes
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[StringLength(15, MinimumLength=0)]
		[Display(Name = "usumodspa", Description = " Propiedad publica de tipo String que representa a la columna usumodspa de la Tabla segparametros")]
		public String usumodspa { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo DateTime que representa a la columna fecmodspa de la Tabla segparametros
		/// Permite Null: Yes
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[DataType(DataType.DateTime, ErrorMessage = "Fecha invalida")]
		[DisplayFormat(DataFormatString = "{ 0:dd/MM/yyyy HH:mm:ss.ffffff}", ApplyFormatInEditMode = true)]
		[Display(Name = "fecmodspa", Description = " Propiedad publica de tipo DateTime que representa a la columna fecmodspa de la Tabla segparametros")]
		public DateTime? fecmodspa { get; set; } 

	}
}

