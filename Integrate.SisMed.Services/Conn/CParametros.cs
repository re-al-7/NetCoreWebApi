namespace Integrate.SisMed.Services.Conn
{
    static public class CParametros
    {
        private enum miEntornoEnum
        {
            LOCAL
        }

        private const miEntornoEnum miEntorno = miEntornoEnum.LOCAL;

        //Constructor
        static CParametros()
        {
            switch (miEntorno)
            {
                case miEntornoEnum.LOCAL:           
                    bChangeUserOnLogon = true;
                    bUseIntegratedSecurity = false;
                    server = "127.0.0.1";
                    puerto = "5432";
                    defaultUser = "postgres";
                    defaultPass = "Desa2016";
                    schema = "";
                    bd = "db_sismed";
                    break;
            }
        }

        //Parametros de conexion
        public static bool bChangeUserOnLogon;
        public static bool bUseIntegratedSecurity;
        public static string server;
        public static string puerto;
        public static string defaultUser;
        public static string user;
        public static string defaultPass;
        public static string pass;
        public static string schema;
        public static string bd;

        //Otros parametros
        public static string ParFormatoFechaHora = "dd/MM/yyyy HH:mm:ss.ffffff";
        public static string ParFormatoFecha = "dd/MM/yyyy";
    }
}
