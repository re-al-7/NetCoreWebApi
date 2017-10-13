#region 
/***********************************************************************************************************
	NOMBRE:       EntSegParametrosdet
	DESCRIPCION:
		Clase que define un objeto para la Tabla segparametrosdet

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
	[Table("segparametrosdet")]
	public class EntSegParametrosdet
	{
		public const string StrNombreTabla = "SegParametrosdet";
		public const string StrAliasTabla = "Spd";
		public enum Fields
		{
			siglaspa
			,codigospd
			,parint1spd
			,parint2spd
			,parchar1spd
			,parchar2spd
			,parnum1spd
			,parnum2spd
			,parbit1spd
			,parbit2spd
			,apiestadospd
			,apitransaccionspd
			,usucrespd
			,feccrespd
			,usumodspd
			,fecmodspd

		}
		
		#region Constructoress
		
		public EntSegParametrosdet()
		{
			//Inicializacion de Variables
			siglaspa = null;
			parint1spd = null;
			parint2spd = null;
			parchar1spd = null;
			parchar2spd = null;
			parnum1spd = null;
			parnum2spd = null;
			parbit1spd = null;
			parbit2spd = null;
			apiestadospd = null;
			apitransaccionspd = null;
			usucrespd = null;
			usumodspd = null;
			fecmodspd = null;
		}
		
		public EntSegParametrosdet(EntSegParametrosdet obj)
		{
			siglaspa = obj.siglaspa;
			codigospd = obj.codigospd;
			parint1spd = obj.parint1spd;
			parint2spd = obj.parint2spd;
			parchar1spd = obj.parchar1spd;
			parchar2spd = obj.parchar2spd;
			parnum1spd = obj.parnum1spd;
			parnum2spd = obj.parnum2spd;
			parbit1spd = obj.parbit1spd;
			parbit2spd = obj.parbit2spd;
			apiestadospd = obj.apiestadospd;
			apitransaccionspd = obj.apitransaccionspd;
			usucrespd = obj.usucrespd;
			feccrespd = obj.feccrespd;
			usumodspd = obj.usumodspd;
			fecmodspd = obj.fecmodspd;
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
			objApi.nombre = EntSegParametrosdet.StrNombreTabla;
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
				XmlSerializer serializer = new XmlSerializer(typeof(EntSegParametrosdet));
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
		public static bool operator ==(EntSegParametrosdet first, EntSegParametrosdet second)
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
		public static bool operator !=(EntSegParametrosdet first, EntSegParametrosdet second)
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
		/// Propiedad publica de tipo String que representa a la columna siglaspa de la Tabla segparametrosdet
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: Yes
		/// Es ForeignKey: Yes
		/// </summary>
		[StringLength(3, MinimumLength=0)]
		[Display(Name = "siglaspa", Description = " Propiedad publica de tipo String que representa a la columna siglaspa de la Tabla segparametrosdet")]
		[Required(AllowEmptyStrings = true, ErrorMessage = "siglaspa es un campo requerido.")]
		[Key]
		public String siglaspa { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo int que representa a la columna codigospd de la Tabla segparametrosdet
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: Yes
		/// Es ForeignKey: No
		/// </summary>
		[Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
		[Display(Name = "codigospd", Description = " Propiedad publica de tipo int que representa a la columna codigospd de la Tabla segparametrosdet")]
		[Required(ErrorMessage = "codigospd es un campo requerido.")]
		[Key]
		public int codigospd { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo Decimal que representa a la columna parint1spd de la Tabla segparametrosdet
		/// Permite Null: Yes
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[Display(Name = "parint1spd", Description = " Propiedad publica de tipo Decimal que representa a la columna parint1spd de la Tabla segparametrosdet")]
		public Decimal? parint1spd { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo Decimal que representa a la columna parint2spd de la Tabla segparametrosdet
		/// Permite Null: Yes
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[Display(Name = "parint2spd", Description = " Propiedad publica de tipo Decimal que representa a la columna parint2spd de la Tabla segparametrosdet")]
		public Decimal? parint2spd { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo String que representa a la columna parchar1spd de la Tabla segparametrosdet
		/// Permite Null: Yes
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[StringLength(60, MinimumLength=0)]
		[Display(Name = "parchar1spd", Description = " Propiedad publica de tipo String que representa a la columna parchar1spd de la Tabla segparametrosdet")]
		public String parchar1spd { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo String que representa a la columna parchar2spd de la Tabla segparametrosdet
		/// Permite Null: Yes
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[StringLength(180, MinimumLength=0)]
		[Display(Name = "parchar2spd", Description = " Propiedad publica de tipo String que representa a la columna parchar2spd de la Tabla segparametrosdet")]
		public String parchar2spd { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo Decimal que representa a la columna parnum1spd de la Tabla segparametrosdet
		/// Permite Null: Yes
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[Display(Name = "parnum1spd", Description = " Propiedad publica de tipo Decimal que representa a la columna parnum1spd de la Tabla segparametrosdet")]
		public Decimal? parnum1spd { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo Decimal que representa a la columna parnum2spd de la Tabla segparametrosdet
		/// Permite Null: Yes
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[Display(Name = "parnum2spd", Description = " Propiedad publica de tipo Decimal que representa a la columna parnum2spd de la Tabla segparametrosdet")]
		public Decimal? parnum2spd { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo Decimal que representa a la columna parbit1spd de la Tabla segparametrosdet
		/// Permite Null: Yes
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[Display(Name = "parbit1spd", Description = " Propiedad publica de tipo Decimal que representa a la columna parbit1spd de la Tabla segparametrosdet")]
		public Decimal? parbit1spd { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo Decimal que representa a la columna parbit2spd de la Tabla segparametrosdet
		/// Permite Null: Yes
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[Display(Name = "parbit2spd", Description = " Propiedad publica de tipo Decimal que representa a la columna parbit2spd de la Tabla segparametrosdet")]
		public Decimal? parbit2spd { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo String que representa a la columna apiestadospd de la Tabla segparametrosdet
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[StringLength(15, MinimumLength=0)]
		[Display(Name = "apiestadospd", Description = " Propiedad publica de tipo String que representa a la columna apiestadospd de la Tabla segparametrosdet")]
		[EnumDataType(typeof(CApi.Estado))]
		public String apiestadospd { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo String que representa a la columna apitransaccionspd de la Tabla segparametrosdet
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[StringLength(15, MinimumLength=0)]
		[Display(Name = "apitransaccionspd", Description = " Propiedad publica de tipo String que representa a la columna apitransaccionspd de la Tabla segparametrosdet")]
		[EnumDataType(typeof(CApi.Transaccion))]
		public String apitransaccionspd { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo String que representa a la columna usucrespd de la Tabla segparametrosdet
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[StringLength(15, MinimumLength=0)]
		[Display(Name = "usucrespd", Description = " Propiedad publica de tipo String que representa a la columna usucrespd de la Tabla segparametrosdet")]
		public String usucrespd { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo DateTime que representa a la columna feccrespd de la Tabla segparametrosdet
		/// Permite Null: No
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[DataType(DataType.DateTime, ErrorMessage = "Fecha invalida")]
		[DisplayFormat(DataFormatString = "{ 0:dd/MM/yyyy HH:mm:ss.ffffff}", ApplyFormatInEditMode = true)]
		[Display(Name = "feccrespd", Description = " Propiedad publica de tipo DateTime que representa a la columna feccrespd de la Tabla segparametrosdet")]
		public DateTime feccrespd { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo String que representa a la columna usumodspd de la Tabla segparametrosdet
		/// Permite Null: Yes
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[StringLength(15, MinimumLength=0)]
		[Display(Name = "usumodspd", Description = " Propiedad publica de tipo String que representa a la columna usumodspd de la Tabla segparametrosdet")]
		public String usumodspd { get; set; } 

		/// <summary>
		/// Propiedad publica de tipo DateTime que representa a la columna fecmodspd de la Tabla segparametrosdet
		/// Permite Null: Yes
		/// Es Calculada: No
		/// Es RowGui: No
		/// Es PrimaryKey: No
		/// Es ForeignKey: No
		/// </summary>
		[DataType(DataType.DateTime, ErrorMessage = "Fecha invalida")]
		[DisplayFormat(DataFormatString = "{ 0:dd/MM/yyyy HH:mm:ss.ffffff}", ApplyFormatInEditMode = true)]
		[Display(Name = "fecmodspd", Description = " Propiedad publica de tipo DateTime que representa a la columna fecmodspd de la Tabla segparametrosdet")]
		public DateTime? fecmodspd { get; set; } 

	}
}

