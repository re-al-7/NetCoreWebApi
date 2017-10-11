using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Integrate.Utils
{
    using System.IO;
    using System.Windows.Forms;

    public static class cFuncionesFicheros
    {


        /// <summary>
        /// Crear un directorio
        /// </summary>
        /// <param name="pathDirectorio"></param>
        /// <returns></returns>
        public static bool crearDirectorio(string pathDirectorio)
        {
            try
            {
                DirectoryInfo directorio = new DirectoryInfo(pathDirectorio);
                if (!directorio.Exists)
                {
                    directorio.Create();
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Borrar Un directorio 
        /// </summary>
        /// <param name="pathDirectorio"></param>
        /// <returns></returns>
        public static bool borrarDirectorio(string pathDirectorio)
        {
            try
            {
                DirectoryInfo directorio = new DirectoryInfo(pathDirectorio);
                if (directorio.Exists)
                {
                    directorio.Delete();
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Borrar un archivo fisico
        /// </summary>
        /// <param name="pathDirectorio"></param>
        /// <param name="pathNombreArchivo"></param>
        /// <returns></returns>
        public static bool borrarArchivo(string pathDirectorio, string pathNombreArchivo)
        {
            if (File.Exists(pathDirectorio + "\\" + pathNombreArchivo))
            {
                File.Delete(pathDirectorio + "\\" + pathNombreArchivo);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Borrar archivos fisicos de una carpeta
        /// </summary>
        /// <param name="pathDirectorio"></param>
        /// <param name="pathNombreArchivo"></param>
        /// <returns></returns>
        public static void borrarArchivos(string pathDirectorio, string tipoArchivo)
        {
            DirectoryInfo dir = new DirectoryInfo(pathDirectorio);
            FileInfo[] file = dir.GetFiles(tipoArchivo);
            int inc = 0;
            while (inc < file.Length)
            {
                if (File.Exists(pathDirectorio + "\\" + file.GetValue(inc).ToString()))
                {
                    File.Delete(pathDirectorio + "\\" + file.GetValue(inc).ToString());
                    inc++;
                }
            }
        }

        /// <summary>
        /// Buscar el path de un directorio
        /// </summary>
        /// <returns></returns>
        public static string buscarDirectorio()
        {
            FolderBrowserDialog dialogoRuta = new FolderBrowserDialog();
            return (dialogoRuta.ShowDialog() == DialogResult.OK)
                ? dialogoRuta.SelectedPath : null;
        }

        public static string buscarArchivo(string pathDirectorioInicio, string criterioFiltrado)
        {
            //Stream myStream = null;
            string pathArchivo = "";
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = pathDirectorioInicio;
            openFileDialog1.Filter = criterioFiltrado;
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pathArchivo = openFileDialog1.FileName;

                    //if ((myStream = openFileDialog1.OpenFile()) != null)
                    //{
                    //    using (myStream)
                    //    {
                    //        // Insert code to read the stream here.
                    //    }
                    //}
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: No se puede leer el archivo. " + ex.Message);
                    pathArchivo = null;
                }

            }
            return pathArchivo;

        }


        /// <summary>
        /// Busca archivos desde un path hallando las coincidencias en una lista 
        /// </summary>
        /// <param name="pathDirectorio"></param>
        /// <param name="pathNombreArchivo"></param>
        /// <returns></returns>
        public static List<string> generarListaArchivos(string pathDirectorio, string patronFiltrado)
        {

            List<string> listaResultado = new List<string>();
            Stack<string> pilaCoincidencia = new Stack<string>();

            pilaCoincidencia.Push(pathDirectorio);

            while (pilaCoincidencia.Count > 0)
            {
                string directorio = pilaCoincidencia.Pop();
                try
                {
                    listaResultado.AddRange(Directory.GetFiles(directorio));

                    foreach (string nombreArchivo in Directory.GetDirectories(directorio))
                    {
                        pilaCoincidencia.Push(nombreArchivo);
                    }
                }
                catch
                {
                }
            }
            return listaResultado;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombreArchivo"></param>
        public static void crearArchivo(string nombreArchivo)
        {
            StreamWriter writer = File.CreateText(nombreArchivo);
            writer.Close();
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <param name="texto"></param>
        public static void escribirDentroArchivo(string nombreArchivo, string texto)
        {
            try
            {
                // esto inserta texto en un archivo existente, si el archivo no existe lo crea
                StreamWriter writer = File.AppendText(nombreArchivo);
                writer.WriteLine(texto);
                writer.Close();
            }
            catch
            {
                Console.WriteLine("Error");
            }
        }

        /// <summary>
        ///     Funcion que realiza la copia recursiva de un directorio Origen a un path de destino
        /// </summary>
        /// <param name="sourceFolder" type="string">
        ///     <para>
        ///         Directorio Origen
        ///     </para>
        /// </param>
        /// <param name="destFolder" type="string">
        ///     <para>
        ///         Directorio Destino
        ///     </para>
        /// </param>	
        public static void copiarDirectorioRecursivo(string sourceFolder, string destFolder)
        {

            if (!Directory.Exists(destFolder))
                Directory.CreateDirectory(destFolder);

            string[] files = Directory.GetFiles(sourceFolder);

            foreach (string file in files)
            {
                string name = Path.GetFileName(file);
                string dest = Path.Combine(destFolder, name);
                File.Copy(file, dest);
            }
            string[] folders = Directory.GetDirectories(sourceFolder);

            foreach (string folder in folders)
            {
                string name = Path.GetFileName(folder);
                string dest = Path.Combine(destFolder, name);
                copiarDirectorioRecursivo(folder, dest);
            }

        }

        /// <summary>
        ///     Funcion que abre un OpenFileDialog para poder seleccionar un archivo imagen
        /// </summary>
        /// <returns>
        ///     Cadena que representa la dirección fisica del archivo cargado
        /// </returns>
        public static string abrirArchivoImagen()
        {
            try
            {
                string filePath = "";
                Stream myStream;
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.InitialDirectory = Environment.SpecialFolder.DesktopDirectory.ToString();

                openFileDialog1.Filter = "Image files (*.jpg)|*.jpg|All image files (*.*)|*.*";
                openFileDialog1.FilterIndex = 1;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    myStream = openFileDialog1.OpenFile();

                    filePath = openFileDialog1.FileName;
                    myStream.Close();
                }

                return filePath;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }
        }

        /// <summary>
        ///     Funcion que crea un archivo de texto plano
        /// </summary>
        /// <param name="FilePath" type="string">
        ///     <para>
        ///         Path y nombre del archivo
        ///     </para>
        /// </param>
        /// <param name="FileData" type="string">
        ///     <para>
        ///         Contenido del archivo
        ///     </para>
        /// </param>
        public static void guardarArchivo(string FilePath, string FileData)
        {
            StreamWriter writer = new StreamWriter(FilePath);
            writer.Write(FileData);
            writer.Close();
        }


    }
}
