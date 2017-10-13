namespace Integrate.SisMed.Api.Services.Dal
{
	public class CListadoSp
	{
	    public enum SegUsuarios
	    {
	        /// <summary>
	        ///     Proc para Insertar datos en la tabla segusuarios
	        /// </summary>
	        spSusIns,

	        /// <summary>
	        ///     Proc para Actualizar datos en la tabla segusuarios
	        /// </summary>
	        spSusUpd,

	        /// <summary>
	        ///     Proc para Eliminar datos en la tabla segusuarios
	        /// </summary>
	        spSusDel
	    }

	    public enum SegMensajeserror
	    {
	        /// <summary>
	        ///     Proc para Insertar datos en la tabla segmensajeserror
	        /// </summary>
	        spSmeIns,

	        /// <summary>
	        ///     Proc para Actualizar datos en la tabla segmensajeserror
	        /// </summary>
	        spSmeUpd,

	        /// <summary>
	        ///     Proc para Eliminar datos en la tabla segmensajeserror
	        /// </summary>
	        spSmeDel
	    }
    }
}

