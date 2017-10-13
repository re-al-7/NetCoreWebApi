#region 
/***********************************************************************************************************
	NOMBRE:       EntSegUsuarios
	DESCRIPCION:
		Clase que define un objeto para la Tabla segusuarios

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
	[Table("segusuarios")]
	public class EntSegUsuarios
	{
		public const string StrNombreTabla = "SegUsuarios";
		public const string StrAliasTabla = "Sus";
		public enum Fields
		{
			idsus
			,loginsus
			,passsus
			,nombresus
			,apellidosus
			,vigentesus
			,fechavigentesus
			,fechapasssus
			,apiestadosus
			,apitransaccionsus
			,usucresus
			,feccresus
			,usumodsus
			,fecmodsus

		}
		
		#region Constructoress
		
		public EntSegUsuarios()
		{
			//Inicializacion de Variables
			loginsus = null;
			passsus = null;
			nombresus = null;
			apellidosus = null;
			fechapasssus = null;
			apiestadosus = null;
			apitransaccionsus = null;
			usucresus = null;
			usumodsus = null;
			fecmodsus = null;
		}
		
		public EntSegUsuarios(EntSegUsuarios obj)
		{
			idsus = obj.idsus;
			loginsus = obj.loginsus;
			passsus = obj.passsus;
			nombresus = obj.nombresus;
			apellidosus = obj.apellidosus;
			vigentesus = obj.vigentesus;
			fechavigentesus = obj.fechavigentesus;
			fechapasssus = obj.fechapasssus;
			apiestadosus = obj.apiestadosus;
			apitransaccionsus = obj.apitransaccionsus;
			usucresus = obj.usucresus;
			feccresus = obj.feccresus;
			usumodsus = obj.usumodsus;
			fecmodsus = obj.fecmodsus;
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
			objApi.nombre = EntSegUsuarios.StrNombreTabla;
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
				XmlSerializer serializer = new XmlSerializer(typeof(EntSegUsuarios));
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
		public static bool operator ==(EntSegUsuarios first, EntSegUsuarios second)
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
		public static bool operator !=(EntSegUsuarios first, EntSegUsuarios second)
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
		/// Propiedad publica de tipo int que representa a la columna idsus de la Tabla segusuarios
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: Yes
		/// Es ForeignKey: No
		/// </summary>
		[Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
		[Display(Name = "idsus", Description = " Propiedad publica de tipo int que representa a la columna idsus de la Tabla segusuarios")]
		[Required(ErrorMessage = "idsus es un campo requerido.")]
		[Key]
		public int idsus { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo String que representa a la columna loginsus de la Tabla segusuarios
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[StringLength(15, MinimumLength=0)]
		[Display(Name = "loginsus", Description = " Propiedad publica de tipo String que representa a la columna loginsus de la Tabla segusuarios")]
		[Required(AllowEmptyStrings = true, ErrorMessage = "loginsus es un campo requerido.")]
		public String loginsus { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo String que representa a la columna passsus de la Tabla segusuarios
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[StringLength(256, MinimumLength=0)]
		[Display(Name = "passsus", Description = " Propiedad publica de tipo String que representa a la columna passsus de la Tabla segusuarios")]
		[Required(AllowEmptyStrings = true, ErrorMessage = "passsus es un campo requerido.")]
		public String passsus { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo String que representa a la columna nombresus de la Tabla segusuarios
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[StringLength(256, MinimumLength=0)]
		[Display(Name = "nombresus", Description = " Propiedad publica de tipo String que representa a la columna nombresus de la Tabla segusuarios")]
		[Required(AllowEmptyStrings = true, ErrorMessage = "nombresus es un campo requerido.")]
		public String nombresus { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo String que representa a la columna apellidosus de la Tabla segusuarios
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[StringLength(256, MinimumLength=0)]
		[Display(Name = "apellidosus", Description = " Propiedad publica de tipo String que representa a la columna apellidosus de la Tabla segusuarios")]
		[Required(AllowEmptyStrings = true, ErrorMessage = "apellidosus es un campo requerido.")]
		public String apellidosus { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo int que representa a la columna vigentesus de la Tabla segusuarios
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
		[Display(Name = "vigentesus", Description = " Propiedad publica de tipo int que representa a la columna vigentesus de la Tabla segusuarios")]
		[Required(ErrorMessage = "vigentesus es un campo requerido.")]
		public int vigentesus { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo DateTime que representa a la columna fechavigentesus de la Tabla segusuarios
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[DataType(DataType.DateTime, ErrorMessage = "Fecha invalida")]
		[DisplayFormat(DataFormatString = "{ 0:dd/MM/yyyy HH:mm:ss.ffffff}", ApplyFormatInEditMode = true)]
		[Display(Name = "fechavigentesus", Description = " Propiedad publica de tipo DateTime que representa a la columna fechavigentesus de la Tabla segusuarios")]
		[Required(ErrorMessage = "fechavigentesus es un campo requerido.")]
		public DateTime fechavigentesus { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo DateTime que representa a la columna fechapasssus de la Tabla segusuarios
		/// Permite Null: Yes
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[DataType(DataType.DateTime, ErrorMessage = "Fecha invalida")]
		[DisplayFormat(DataFormatString = "{ 0:dd/MM/yyyy HH:mm:ss.ffffff}", ApplyFormatInEditMode = true)]
		[Display(Name = "fechapasssus", Description = " Propiedad publica de tipo DateTime que representa a la columna fechapasssus de la Tabla segusuarios")]
		public DateTime? fechapasssus { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo String que representa a la columna apiestadosus de la Tabla segusuarios
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[StringLength(15, MinimumLength=0)]
		[Display(Name = "apiestadosus", Description = " Propiedad publica de tipo String que representa a la columna apiestadosus de la Tabla segusuarios")]
		[EnumDataType(typeof(CApi.Estado))]
		public String apiestadosus { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo String que representa a la columna apitransaccionsus de la Tabla segusuarios
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[StringLength(15, MinimumLength=0)]
		[Display(Name = "apitransaccionsus", Description = " Propiedad publica de tipo String que representa a la columna apitransaccionsus de la Tabla segusuarios")]
		[EnumDataType(typeof(CApi.Transaccion))]
		public String apitransaccionsus { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo String que representa a la columna usucresus de la Tabla segusuarios
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[StringLength(15, MinimumLength=0)]
		[Display(Name = "usucresus", Description = " Propiedad publica de tipo String que representa a la columna usucresus de la Tabla segusuarios")]
		public String usucresus { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo DateTime que representa a la columna feccresus de la Tabla segusuarios
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[DataType(DataType.DateTime, ErrorMessage = "Fecha invalida")]
		[DisplayFormat(DataFormatString = "{ 0:dd/MM/yyyy HH:mm:ss.ffffff}", ApplyFormatInEditMode = true)]
		[Display(Name = "feccresus", Description = " Propiedad publica de tipo DateTime que representa a la columna feccresus de la Tabla segusuarios")]
		public DateTime feccresus { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo String que representa a la columna usumodsus de la Tabla segusuarios
		/// Permite Null: Yes
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[StringLength(15, MinimumLength=0)]
		[Display(Name = "usumodsus", Description = " Propiedad publica de tipo String que representa a la columna usumodsus de la Tabla segusuarios")]
		public String usumodsus { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo DateTime que representa a la columna fecmodsus de la Tabla segusuarios
		/// Permite Null: Yes
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[DataType(DataType.DateTime, ErrorMessage = "Fecha invalida")]
		[DisplayFormat(DataFormatString = "{ 0:dd/MM/yyyy HH:mm:ss.ffffff}", ApplyFormatInEditMode = true)]
		[Display(Name = "fecmodsus", Description = " Propiedad publica de tipo DateTime que representa a la columna fecmodsus de la Tabla segusuarios")]
		public DateTime? fecmodsus { get; set; } 

	}
}

