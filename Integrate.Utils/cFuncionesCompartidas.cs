namespace Integrate.Utils
{
    using System.IO;

    public static class cFuncionesCompartidas
    {
        public static string mensajeConfirmacion(string mensaje)
        {
            return "var i=confirm('" + mensaje + "');if(i==false){return false;}";
        }

        public static string popUpReporte(string pagina)
        {
            return "javascript:var alto=screen.height;" +
                    "var ancho=screen.width;" +
                    "var yposi=(ancho-800)/2;" +
                    "var xposi=(alto-800)/2;" +
                    "window.open('" + pagina + "','_rep','" +
                    "status=0," +
                    "titlebar=0," +
                    "location=0," +
                    "menubar=0," +
                    "toolbar=0," +
                    "resizable=1," +
                    "width=800,height=800,left='+yposi+',top='+xposi,0);";
        }

        public static string pupUpScript(string mensaje)
        {
            return "alert('" + mensaje + "');";
        }


        public static string readPagina(string path)
        {
            return File.ReadAllText(path);
        }
    }
}

