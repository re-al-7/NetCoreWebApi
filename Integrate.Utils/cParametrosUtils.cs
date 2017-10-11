namespace Integrate.Utils
{
    static public class cParametrosUtils
    {
        //-----Parametros para la conexion al servidor de smtp
        public static bool mailNotificarError = false;

        public static string mailHost = "smtp.gmail.com";
        public static int mailPort = 587;

        public static string mailFrom = "7.re.al.7@gmail.com";
        public static string mailUsername = "7.re.al.7@gmail.com";
        public static string mailPassword = "kgcpudhaoovzoiij";
        //public static string mailPassword = "ReAl5989513";

        //----Parametros para el envio de correos desde la clase cExceptionManager
        public static string errorDestino = "siaps@ap.gob.bo";
        public static string errorMsj = "Le pedimos tomar nota.";
    }
}
