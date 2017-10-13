#region 
/***********************************************************************************************************
	NOMBRE:       EntSegUsuariosrestriccion
	DESCRIPCION:
		Clase que define un objeto para la Tabla segusuariosrestriccion

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
	[Table("segusuariosrestriccion")]
	public class EntSegUsuariosrestriccion
	{
		public const string StrNombreTabla = "SegUsuariosrestriccion";
		public const string StrAliasTabla = "Sur";
		public enum Fields
		{
			idsur
			,idsus
			,rolsro
			,rolactivosur
			,fechavigentesur
			,apiestadosur
			,apitransaccionsur
			,usucresur
			,feccresur
			,usumodsur
			,fecmodsur

		}
		
		#region Constructoress
		
		public EntSegUsuariosrestriccion()
		{
			//Inicializacion de Variables
			fechavigentesur = null;
			apiestadosur = null;
			apitransaccionsur = null;
			usucresur = null;
			usumodsur = null;
			fecmodsur = null;
		}
		
		public EntSegUsuariosrestriccion(EntSegUsuariosrestriccion obj)
		{
			idsur = obj.idsur;
			idsus = obj.idsus;
			rolsro = obj.rolsro;
			rolactivosur = obj.rolactivosur;
			fechavigentesur = obj.fechavigentesur;
			apiestadosur = obj.apiestadosur;
			apitransaccionsur = obj.apitransaccionsur;
			usucresur = obj.usucresur;
			feccresur = obj.feccresur;
			usumodsur = obj.usumodsur;
			fecmodsur = obj.fecmodsur;
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
			objApi.nombre = EntSegUsuariosrestriccion.StrNombreTabla;
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
				XmlSerializer serializer = new XmlSerializer(typeof(EntSegUsuariosrestriccion));
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
		public static bool operator ==(EntSegUsuariosrestriccion first, EntSegUsuariosrestriccion second)
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
		public static bool operator !=(EntSegUsuariosrestriccion first, EntSegUsuariosrestriccion second)
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
		/// Identificador unico de la tabla
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: Yes
		/// Es ForeignKey: No
		/// </summary>
		[Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
		[Display(Name = "idsur", Description = "Identificador unico de la tabla")]
		[Required(ErrorMessage = "idsur es un campo requerido.")]
		[Key]
		public int idsur { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo int que representa a la columna idsus de la Tabla segusuariosrestriccion
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: Yes
		/// </summary>
		[Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
		[Display(Name = "idsus", Description = " Propiedad publica de tipo int que representa a la columna idsus de la Tabla segusuariosrestriccion")]
		[Required(ErrorMessage = "idsus es un campo requerido.")]
		public int idsus { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo int que representa a la columna rolsro de la Tabla segusuariosrestriccion
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: Yes
		/// </summary>
		[Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
		[Display(Name = "rolsro", Description = " Propiedad publica de tipo int que representa a la columna rolsro de la Tabla segusuariosrestriccion")]
		[Required(ErrorMessage = "rolsro es un campo requerido.")]
		public int rolsro { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo int que representa a la columna rolactivosur de la Tabla segusuariosrestriccion
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
		[Display(Name = "rolactivosur", Description = " Propiedad publica de tipo int que representa a la columna rolactivosur de la Tabla segusuariosrestriccion")]
		[Required(ErrorMessage = "rolactivosur es un campo requerido.")]
		public int rolactivosur { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo DateTime que representa a la columna fechavigentesur de la Tabla segusuariosrestriccion
		/// Permite Null: Yes
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[DataType(DataType.DateTime, ErrorMessage = "Fecha invalida")]
		[DisplayFormat(DataFormatString = "{ 0:dd/MM/yyyy HH:mm:ss.ffffff}", ApplyFormatInEditMode = true)]
		[Display(Name = "fechavigentesur", Description = " Propiedad publica de tipo DateTime que representa a la columna fechavigentesur de la Tabla segusuariosrestriccion")]
		public DateTime? fechavigentesur { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo String que representa a la columna apiestadosur de la Tabla segusuariosrestriccion
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[StringLength(15, MinimumLength=0)]
		[Display(Name = "apiestadosur", Description = " Propiedad publica de tipo String que representa a la columna apiestadosur de la Tabla segusuariosrestriccion")]
		[EnumDataType(typeof(CApi.Estado))]
		public String apiestadosur { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo String que representa a la columna apitransaccionsur de la Tabla segusuariosrestriccion
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[StringLength(15, MinimumLength=0)]
		[Display(Name = "apitransaccionsur", Description = " Propiedad publica de tipo String que representa a la columna apitransaccionsur de la Tabla segusuariosrestriccion")]
		[EnumDataType(typeof(CApi.Transaccion))]
		public String apitransaccionsur { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo String que representa a la columna usucresur de la Tabla segusuariosrestriccion
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[StringLength(15, MinimumLength=0)]
		[Display(Name = "usucresur", Description = " Propiedad publica de tipo String que representa a la columna usucresur de la Tabla segusuariosrestriccion")]
		public String usucresur { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo DateTime que representa a la columna feccresur de la Tabla segusuariosrestriccion
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[DataType(DataType.DateTime, ErrorMessage = "Fecha invalida")]
		[DisplayFormat(DataFormatString = "{ 0:dd/MM/yyyy HH:mm:ss.ffffff}", ApplyFormatInEditMode = true)]
		[Display(Name = "feccresur", Description = " Propiedad publica de tipo DateTime que representa a la columna feccresur de la Tabla segusuariosrestriccion")]
		public DateTime feccresur { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo String que representa a la columna usumodsur de la Tabla segusuariosrestriccion
		/// Permite Null: Yes
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[StringLength(15, MinimumLength=0)]
		[Display(Name = "usumodsur", Description = " Propiedad publica de tipo String que representa a la columna usumodsur de la Tabla segusuariosrestriccion")]
		public String usumodsur { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo DateTime que representa a la columna fecmodsur de la Tabla segusuariosrestriccion
		/// Permite Null: Yes
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[DataType(DataType.DateTime, ErrorMessage = "Fecha invalida")]
		[DisplayFormat(DataFormatString = "{ 0:dd/MM/yyyy HH:mm:ss.ffffff}", ApplyFormatInEditMode = true)]
		[Display(Name = "fecmodsur", Description = " Propiedad publica de tipo DateTime que representa a la columna fecmodsur de la Tabla segusuariosrestriccion")]
		public DateTime? fecmodsur { get; set; } 

	}
}

