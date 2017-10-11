using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Integrate.Utils
{
    public static class cFuncionesPostgres
    {
        public static bool crearBackupBD(string strServer, string strUser, string strPass, string strNameBD)
        {
            bool bProcede = false;
            try
            {
                if (!Directory.Exists(Application.StartupPath + "\\backups"))
                {
                    Directory.CreateDirectory(Application.StartupPath + "\\backups");
                }

                //primero creamos el archivo .Bat
                string strBatFile = "@echo off\r\n" +
                                    "for /f \"tokens=1-4 delims=/ \" %%i in (\"%date%\") do (\r\n" +
                                    " set day=%%i\r\n" +
                                    " set month=%%j\r\n" +
                                    " set year=%%k\r\n" +
                                    ")\r\n" +
                                    "set datestr=%day%_%month%_%year%\r\n" +
                                    "echo datestr is %datestr%\r\n" +
                                    "set BACKUP_FILE=backups\\" + strNameBD + "_%datestr%.dmp\r\n" +
                                    "echo backup file name is %BACKUP_FILE%\r\n" +
                                    "SET PGPASSWORD=" + strPass + "\r\n" +
                                    "echo off\r\n" +
                                    "pg\\pg_dump -h " + strServer + " -U " + strUser + " -f %BACKUP_FILE% " + strNameBD +
                                    "\r\necho PROCESANDO.....";

                cFuncionesFicheros.guardarArchivo(Application.StartupPath + "\\backup.bat", strBatFile);

                ProcessStartInfo info = new ProcessStartInfo();
                info.FileName = Application.StartupPath + "\\backup.bat";
                info.CreateNoWindow = true;
                info.UseShellExecute = true;
                Process proc = new Process();
                proc.StartInfo = info;
                proc.Start();
                proc.WaitForExit();

                File.Delete(Application.StartupPath + "\\backup.bat");


                //Comprimimos el archivo
                cFuncionesZip zip = new cFuncionesZip();
                string mes = (DateTime.Now.Month < 10) ? "0" + DateTime.Now.Month : DateTime.Now.Month.ToString();
                string dia = (DateTime.Now.Day < 10) ? "0" + DateTime.Now.Day : DateTime.Now.Day.ToString();

                string path = Application.StartupPath + "\\backups\\" + strNameBD + "_" + dia + "_" + mes + "_" + DateTime.Now.Year + ".dmp";
                zip = cFuncionesZip.Create(path + ".zip", "Generado por ZipStorer para NeuroDiagnostico");

                zip.AddFile(cFuncionesZip.Compression.Deflate, path, Path.GetFileName(path), "");
                zip.Close();


                //Si se ha creado el ZIP... se borra el backup
                if (File.Exists(path + ".zip"))
                {
                    File.Delete(path);
                }

                bProcede = true;
            }
            catch (Exception exp)
            {
                throw exp;
            }

            return bProcede;
        }
    }
}
