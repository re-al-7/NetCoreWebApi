namespace Integrate.SisMed.Api.Services.Conn
{
    public static class CParametros
    {
        private enum MiEntornoEnum
        {
            Local
        }

        private const MiEntornoEnum MiEntorno = MiEntornoEnum.Local;

        //Constructor
        static CParametros()
        {
            switch (MiEntorno)
            {
                case MiEntornoEnum.Local:           
                    BChangeUserOnLogon = true;
                    BUseIntegratedSecurity = false;
                    Server = "127.0.0.1";
                    Puerto = "5432";
                    User = "postgres";
                    Pass = "Desa2016";
                    Schema = "";
                    Bd = "db_sismed";
                    break;
            }
        }

        //Parametros de conexion
        public static bool BChangeUserOnLogon;
        public static bool BUseIntegratedSecurity;
        public static string Server;
        public static string Puerto;
        public static string User;
        public static string Pass;
        public static string Schema;
        public static string Bd;

        //Otros parametros
        public static string ParFormatoFechaHora = "dd/MM/yyyy HH:mm:ss.ffffff";
        public static string ParFormatoFecha = "dd/MM/yyyy";
    }
}
