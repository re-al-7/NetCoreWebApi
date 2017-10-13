#region 
/***********************************************************************************************************
	NOMBRE:       EntSegPaginas
	DESCRIPCION:
		Clase que define un objeto para la Tabla segpaginas

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
	[Table("segpaginas")]
	public class EntSegPaginas
	{
		public const string StrNombreTabla = "SegPaginas";
		public const string StrAliasTabla = "Spg";
		public enum Fields
		{
			paginaspg
			,aplicacionsap
			,paginapadrespg
			,nombrespg
			,nombremenuspg
			,descripcionspg
			,prioridadspg
			,apiestadospg
			,apitransaccionspg
			,usucrespg
			,feccrespg
			,usumodspg
			,fecmodspg

		}
		
		#region Constructoress
		
		public EntSegPaginas()
		{
			//Inicializacion de Variables
			aplicacionsap = null;
			paginapadrespg = null;
			nombrespg = null;
			nombremenuspg = null;
			descripcionspg = null;
			prioridadspg = null;
			apiestadospg = null;
			apitransaccionspg = null;
			usucrespg = null;
			usumodspg = null;
			fecmodspg = null;
		}
		
		public EntSegPaginas(EntSegPaginas obj)
		{
			paginaspg = obj.paginaspg;
			aplicacionsap = obj.aplicacionsap;
			paginapadrespg = obj.paginapadrespg;
			nombrespg = obj.nombrespg;
			nombremenuspg = obj.nombremenuspg;
			descripcionspg = obj.descripcionspg;
			prioridadspg = obj.prioridadspg;
			apiestadospg = obj.apiestadospg;
			apitransaccionspg = obj.apitransaccionspg;
			usucrespg = obj.usucrespg;
			feccrespg = obj.feccrespg;
			usumodspg = obj.usumodspg;
			fecmodspg = obj.fecmodspg;
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
			objApi.nombre = EntSegPaginas.StrNombreTabla;
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
				XmlSerializer serializer = new XmlSerializer(typeof(EntSegPaginas));
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
		public static bool operator ==(EntSegPaginas first, EntSegPaginas second)
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
		public static bool operator !=(EntSegPaginas first, EntSegPaginas second)
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
		/// Propiedad publica de tipo int que representa a la columna paginaspg de la Tabla segpaginas
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: Yes
		/// Es ForeignKey: No
		/// </summary>
		[Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
		[Display(Name = "paginaspg", Description = " Propiedad publica de tipo int que representa a la columna paginaspg de la Tabla segpaginas")]
		[Required(ErrorMessage = "paginaspg es un campo requerido.")]
		[Key]
		public int paginaspg { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo String que representa a la columna aplicacionsap de la Tabla segpaginas
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: Yes
		/// </summary>
		[StringLength(3, MinimumLength=0)]
		[Display(Name = "aplicacionsap", Description = " Propiedad publica de tipo String que representa a la columna aplicacionsap de la Tabla segpaginas")]
		[Required(AllowEmptyStrings = true, ErrorMessage = "aplicacionsap es un campo requerido.")]
		public String aplicacionsap { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo Decimal que representa a la columna paginapadrespg de la Tabla segpaginas
		/// Permite Null: Yes
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[Display(Name = "paginapadrespg", Description = " Propiedad publica de tipo Decimal que representa a la columna paginapadrespg de la Tabla segpaginas")]
		public Decimal? paginapadrespg { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo String que representa a la columna nombrespg de la Tabla segpaginas
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[StringLength(60, MinimumLength=0)]
		[Display(Name = "nombrespg", Description = " Propiedad publica de tipo String que representa a la columna nombrespg de la Tabla segpaginas")]
		[Required(AllowEmptyStrings = true, ErrorMessage = "nombrespg es un campo requerido.")]
		public String nombrespg { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo String que representa a la columna nombremenuspg de la Tabla segpaginas
		/// Permite Null: Yes
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[StringLength(30, MinimumLength=0)]
		[Display(Name = "nombremenuspg", Description = " Propiedad publica de tipo String que representa a la columna nombremenuspg de la Tabla segpaginas")]
		public String nombremenuspg { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo String que representa a la columna descripcionspg de la Tabla segpaginas
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[StringLength(100, MinimumLength=0)]
		[Display(Name = "descripcionspg", Description = " Propiedad publica de tipo String que representa a la columna descripcionspg de la Tabla segpaginas")]
		[Required(AllowEmptyStrings = true, ErrorMessage = "descripcionspg es un campo requerido.")]
		public String descripcionspg { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo Decimal que representa a la columna prioridadspg de la Tabla segpaginas
		/// Permite Null: Yes
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[Display(Name = "prioridadspg", Description = " Propiedad publica de tipo Decimal que representa a la columna prioridadspg de la Tabla segpaginas")]
		public Decimal? prioridadspg { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo String que representa a la columna apiestadospg de la Tabla segpaginas
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[StringLength(15, MinimumLength=0)]
		[Display(Name = "apiestadospg", Description = " Propiedad publica de tipo String que representa a la columna apiestadospg de la Tabla segpaginas")]
		[EnumDataType(typeof(CApi.Estado))]
		public String apiestadospg { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo String que representa a la columna apitransaccionspg de la Tabla segpaginas
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[StringLength(15, MinimumLength=0)]
		[Display(Name = "apitransaccionspg", Description = " Propiedad publica de tipo String que representa a la columna apitransaccionspg de la Tabla segpaginas")]
		[EnumDataType(typeof(CApi.Transaccion))]
		public String apitransaccionspg { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo String que representa a la columna usucrespg de la Tabla segpaginas
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[StringLength(15, MinimumLength=0)]
		[Display(Name = "usucrespg", Description = " Propiedad publica de tipo String que representa a la columna usucrespg de la Tabla segpaginas")]
		public String usucrespg { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo DateTime que representa a la columna feccrespg de la Tabla segpaginas
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[DataType(DataType.DateTime, ErrorMessage = "Fecha invalida")]
		[DisplayFormat(DataFormatString = "{ 0:dd/MM/yyyy HH:mm:ss.ffffff}", ApplyFormatInEditMode = true)]
		[Display(Name = "feccrespg", Description = " Propiedad publica de tipo DateTime que representa a la columna feccrespg de la Tabla segpaginas")]
		public DateTime feccrespg { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo String que representa a la columna usumodspg de la Tabla segpaginas
		/// Permite Null: Yes
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[StringLength(15, MinimumLength=0)]
		[Display(Name = "usumodspg", Description = " Propiedad publica de tipo String que representa a la columna usumodspg de la Tabla segpaginas")]
		public String usumodspg { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo DateTime que representa a la columna fecmodspg de la Tabla segpaginas
		/// Permite Null: Yes
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[DataType(DataType.DateTime, ErrorMessage = "Fecha invalida")]
		[DisplayFormat(DataFormatString = "{ 0:dd/MM/yyyy HH:mm:ss.ffffff}", ApplyFormatInEditMode = true)]
		[Display(Name = "fecmodspg", Description = " Propiedad publica de tipo DateTime que representa a la columna fecmodspg de la Tabla segpaginas")]
		public DateTime? fecmodspg { get; set; } 

	}
}

