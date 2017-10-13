#region 
/***********************************************************************************************************
	NOMBRE:       EntSegTablas
	DESCRIPCION:
		Clase que define un objeto para la Tabla segtablas

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
	[Table("segtablas")]
	public class EntSegTablas
	{
		public const string StrNombreTabla = "SegTablas";
		public const string StrAliasTabla = "Sta";
		public enum Fields
		{
			tablasta
			,aplicacionsap
			,aliassta
			,descripcionsta
			,apiestadosta
			,apitransaccionsta
			,usucresta
			,feccresta
			,usumodsta
			,fecmodsta

		}
		
		#region Constructoress
		
		public EntSegTablas()
		{
			//Inicializacion de Variables
			tablasta = null;
			aplicacionsap = null;
			aliassta = null;
			descripcionsta = null;
			apiestadosta = null;
			apitransaccionsta = null;
			usucresta = null;
			usumodsta = null;
			fecmodsta = null;
		}
		
		public EntSegTablas(EntSegTablas obj)
		{
			tablasta = obj.tablasta;
			aplicacionsap = obj.aplicacionsap;
			aliassta = obj.aliassta;
			descripcionsta = obj.descripcionsta;
			apiestadosta = obj.apiestadosta;
			apitransaccionsta = obj.apitransaccionsta;
			usucresta = obj.usucresta;
			feccresta = obj.feccresta;
			usumodsta = obj.usumodsta;
			fecmodsta = obj.fecmodsta;
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
			objApi.nombre = EntSegTablas.StrNombreTabla;
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
				XmlSerializer serializer = new XmlSerializer(typeof(EntSegTablas));
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
		public static bool operator ==(EntSegTablas first, EntSegTablas second)
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
		public static bool operator !=(EntSegTablas first, EntSegTablas second)
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
		/// Propiedad publica de tipo String que representa a la columna tablasta de la Tabla segtablas
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: Yes
		/// Es ForeignKey: No
		/// </summary>
		[StringLength(30, MinimumLength=0)]
		[Display(Name = "tablasta", Description = " Propiedad publica de tipo String que representa a la columna tablasta de la Tabla segtablas")]
		[Required(AllowEmptyStrings = true, ErrorMessage = "tablasta es un campo requerido.")]
		[Key]
		public String tablasta { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo String que representa a la columna aplicacionsap de la Tabla segtablas
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: Yes
		/// </summary>
		[StringLength(3, MinimumLength=0)]
		[Display(Name = "aplicacionsap", Description = " Propiedad publica de tipo String que representa a la columna aplicacionsap de la Tabla segtablas")]
		[Required(AllowEmptyStrings = true, ErrorMessage = "aplicacionsap es un campo requerido.")]
		public String aplicacionsap { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo String que representa a la columna aliassta de la Tabla segtablas
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[StringLength(3, MinimumLength=0)]
		[Display(Name = "aliassta", Description = " Propiedad publica de tipo String que representa a la columna aliassta de la Tabla segtablas")]
		[Required(AllowEmptyStrings = true, ErrorMessage = "aliassta es un campo requerido.")]
		public String aliassta { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo String que representa a la columna descripcionsta de la Tabla segtablas
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[StringLength(240, MinimumLength=0)]
		[Display(Name = "descripcionsta", Description = " Propiedad publica de tipo String que representa a la columna descripcionsta de la Tabla segtablas")]
		[Required(AllowEmptyStrings = true, ErrorMessage = "descripcionsta es un campo requerido.")]
		public String descripcionsta { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo String que representa a la columna apiestadosta de la Tabla segtablas
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[StringLength(15, MinimumLength=0)]
		[Display(Name = "apiestadosta", Description = " Propiedad publica de tipo String que representa a la columna apiestadosta de la Tabla segtablas")]
		[EnumDataType(typeof(CApi.Estado))]
		public String apiestadosta { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo String que representa a la columna apitransaccionsta de la Tabla segtablas
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[StringLength(15, MinimumLength=0)]
		[Display(Name = "apitransaccionsta", Description = " Propiedad publica de tipo String que representa a la columna apitransaccionsta de la Tabla segtablas")]
		[EnumDataType(typeof(CApi.Transaccion))]
		public String apitransaccionsta { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo String que representa a la columna usucresta de la Tabla segtablas
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[StringLength(15, MinimumLength=0)]
		[Display(Name = "usucresta", Description = " Propiedad publica de tipo String que representa a la columna usucresta de la Tabla segtablas")]
		public String usucresta { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo DateTime que representa a la columna feccresta de la Tabla segtablas
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[DataType(DataType.DateTime, ErrorMessage = "Fecha invalida")]
		[DisplayFormat(DataFormatString = "{ 0:dd/MM/yyyy HH:mm:ss.ffffff}", ApplyFormatInEditMode = true)]
		[Display(Name = "feccresta", Description = " Propiedad publica de tipo DateTime que representa a la columna feccresta de la Tabla segtablas")]
		public DateTime feccresta { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo String que representa a la columna usumodsta de la Tabla segtablas
		/// Permite Null: Yes
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[StringLength(15, MinimumLength=0)]
		[Display(Name = "usumodsta", Description = " Propiedad publica de tipo String que representa a la columna usumodsta de la Tabla segtablas")]
		public String usumodsta { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo DateTime que representa a la columna fecmodsta de la Tabla segtablas
		/// Permite Null: Yes
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[DataType(DataType.DateTime, ErrorMessage = "Fecha invalida")]
		[DisplayFormat(DataFormatString = "{ 0:dd/MM/yyyy HH:mm:ss.ffffff}", ApplyFormatInEditMode = true)]
		[Display(Name = "fecmodsta", Description = " Propiedad publica de tipo DateTime que representa a la columna fecmodsta de la Tabla segtablas")]
		public DateTime? fecmodsta { get; set; } 

	}
}

