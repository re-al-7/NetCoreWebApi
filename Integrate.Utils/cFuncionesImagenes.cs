using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Integrate.Utils
{
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Windows.Forms;

    public static class cFuncionesImagenes
    {
        /// <summary>
        /// Se rota una imagen desde un punto medioa con un angulo de inclinacion
        /// </summary>
        /// <param name="imagen">Objeto Imagen</param>
        /// <param name="angulo">Float angulo de inclinacion</param>
        /// <returns>Objeto Imagen rotada x grados</returns>
        public static Image rotarImagen(Image imagen, float angulo)
        {
            Bitmap imagenBitmap = new Bitmap(imagen.Width, imagen.Height, imagen.PixelFormat);
            imagenBitmap.SetResolution(imagen.HorizontalResolution, imagen.VerticalResolution);
            using (Graphics imagenGraphics = Graphics.FromImage(imagenBitmap))
            {
                imagenGraphics.SmoothingMode = SmoothingMode.AntiAlias;
                imagenGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                imagenGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                imagenGraphics.TranslateTransform((float)imagen.Width / 2, (float)imagen.Height / 2);
                imagenGraphics.RotateTransform(angulo);
                imagenGraphics.TranslateTransform(-(float)imagen.Width / 2, -(float)imagen.Height / 2);
                imagenGraphics.DrawImage(imagen, new Point(0, 0));
            }
            return (Image)imagenBitmap;
        }

        /// <summary>
        /// Se genera una imagen desde memory stream
        /// </summary>
        /// <param name="bytesImagen">Array de bytes</param>
        /// <returns>Objeto Imagen</returns>
        public static Image generarMemoryStreamImagen(byte[] bytesImagen)
        {
            MemoryStream msImagen = new MemoryStream();
            msImagen.Write(bytesImagen, 0, bytesImagen.Length);
            msImagen.Position = 0;
            return Image.FromStream(msImagen);
        }


        /// <summary>
        /// Devuelve un array tipo byte[] desde un path donde se encuentra una imagen
        /// </summary>
        /// <param name="pathOrigenImagen">Path de la imagen</param>
        /// <returns>Tipo byte[]</returns>
        public static byte[] generarImagenMemoryStream(Image imagen)
        {
            // Image imagen = Image.FromFile(pathOrigenImagen);
            byte[] imageToByteArray = null;
            //Bitmap como capa
            using (Bitmap imagenBitmap = new Bitmap(imagen.Width, imagen.Height, PixelFormat.Format32bppRgb))
            {
                imagenBitmap.SetResolution(imagen.HorizontalResolution, imagen.VerticalResolution);
                //preparo mi capa

                using (Graphics imagenGraphics = Graphics.FromImage(imagenBitmap))
                {
                    imagenGraphics.SmoothingMode = SmoothingMode.AntiAlias;
                    imagenGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    imagenGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    imagenGraphics.DrawImage(imagen, new Rectangle(0, 0, imagen.Width, imagen.Height), new Rectangle(0, 0, imagen.Width, imagen.Height), GraphicsUnit.Pixel);
                    MemoryStream imagenMemoryStream = new MemoryStream();
                    imagenBitmap.Save(imagenMemoryStream, ImageFormat.Jpeg);
                    imageToByteArray = imagenMemoryStream.ToArray();
                    imagenMemoryStream.Close();
                    imagen.Dispose();
                }
            }
            return imageToByteArray;
        }


        /// <summary>
        /// Metodo para el tratamiento de imagenes, retorna un objeto imagen
        /// </summary>
        /// <param name="Imagen">Objeto de tipo Imagen</param>
        /// <param name="Ancho">Ancho en pixeles</param>
        /// <param name="Alto">Alto en pixeles</param>
        /// <param name="resolucion">Resolucion en DPI</param>
        /// <returns>Un objeto Imagen</returns>
        public static Image redimensionarImagen(Image imagen, int imageAncho, int imagenAlto, int imagenResolucion)
        {
            //Bitmap como capa
            using (Bitmap imagenBitmap = new Bitmap(imageAncho, imagenAlto, PixelFormat.Format32bppRgb))
            {
                imagenBitmap.SetResolution(imagenResolucion, imagenResolucion);

                //preparo mi capa

                using (Graphics imagenGraphics = Graphics.FromImage(imagenBitmap))
                {
                    imagenGraphics.SmoothingMode = SmoothingMode.AntiAlias;
                    imagenGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    imagenGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    imagenGraphics.DrawImage(imagen, new Rectangle(0, 0, imageAncho, imagenAlto), new Rectangle(0, 0, imagen.Width, imagen.Height), GraphicsUnit.Pixel);
                    MemoryStream imagenMemoryStream = new MemoryStream();
                    imagenBitmap.Save(imagenMemoryStream, ImageFormat.Jpeg);
                    imagen = Image.FromStream(imagenMemoryStream);
                }
            }
            return imagen;
        }

        /// <summary>
        /// Corta una zona parcial de la imagen
        /// </summary>
        /// <param name="imagen"></param>
        /// <returns></returns>
        private static Image cortarImagen(Image imagen, Rectangle rectOrigen, Rectangle rectDestino)
        {
            Bitmap bmpDestino;
            Graphics g;

            bmpDestino = new Bitmap(rectDestino.Width, rectDestino.Height);
            g = Graphics.FromImage(bmpDestino);
            g.DrawImage(imagen, rectDestino, rectOrigen, GraphicsUnit.Pixel);
            return (Image)bmpDestino;
        }


        /// <summary>
        ///     Devuelve un tipo de dato Byte a partir de una imagen que se encuentra fisicamente en el equipo
        /// </summary>
        /// <param name="fileName" type="string">
        ///     <para>
        ///         PictureBox ue contiene a la imagen que se quiere leer
        ///     </para>
        /// </param>
        /// <returns>
        ///     Conjunto de Bytes que representan a la imagen del PictureBox
        /// </returns>
        public static Byte[] imageReadBinaryFile(string fileName)
        {

            if (File.Exists(fileName))
            {
                try
                {
                    FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                    Byte[] data = new Byte[Convert.ToInt32(fs.Length)];
                    fs.Read(data, 0, Convert.ToInt32(fs.Length));
                    fs.Close();
                    return data;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR AL LEER EL ARCHIVO DE IMAGEN");
                    return new Byte[1];
                }
            }

            else
                return new Byte[1];
        }

        /// <summary>
        ///     Devuelve un tipo de dato Byte a partir de una imagen en un picturebox
        /// </summary>
        /// <param name="pbImage" type="System.Windows.Forms.PictureBox">
        ///     <para>
        ///         PictureBox ue contiene a la imagen que se quiere leer
        ///     </para>
        /// </param>
        /// <returns>
        ///     Conjunto de Bytes que representan a la imagen del PictureBox
        /// </returns>
        public static Byte[] imageReadBinaryPictureBox(ref PictureBox pbImage)
        {
            MemoryStream ms = new MemoryStream();
            pbImage.Image.Save(ms, ImageFormat.Jpeg);
            return ms.ToArray();
        }

        /// <summary>
        ///     Funcion q redimensiona una imagen a un ancho, alto y resolucion dados
        /// </summary>
        /// <param name="imageFile" type="byte[]">
        ///     <para>
        ///         Imagen representada en un conjunto de Bytes que se quiere redimensionar
        ///     </para>
        /// </param>
        /// <param name="Ancho" type="int">
        ///     <para>
        ///         Ancho de la Imagen
        ///     </para>
        /// </param>
        /// <param name="Alto" type="int">
        ///     <para>
        ///         Alto de la Imagen
        ///     </para>
        /// </param>
        /// <param name="targetSize" type="int">
        ///     <para>
        ///         Resolución de la imagen
        ///     </para>
        /// </param>
        /// <returns>
        ///     Imagen representada en un conjunto de Bytes con el tamaño y la resolución ajustada
        /// </returns>
        private static Byte[] imageResizeFile(Byte[] imageFile, int Ancho, int Alto, int targetSize)
        {
            Image original = Image.FromStream(new MemoryStream(imageFile));
            int targetH, targetW;

            if (original.Height > original.Width)
            {
                targetH = targetSize;
                targetW = (int)(original.Width * (targetSize / (float)original.Height));
            }

            else
            {
                targetW = targetSize;
                targetH = (int)(original.Height * (targetSize / (float)original.Width));
            }
            Image imgPhoto = Image.FromStream(new MemoryStream(imageFile));
            // Create a new blank canvas.  The resized image will be drawn on this canvas.
            Bitmap bmPhoto = new Bitmap(targetW, targetH, PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(Ancho, Alto);
            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.SmoothingMode = SmoothingMode.AntiAlias;
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
            grPhoto.PixelOffsetMode = PixelOffsetMode.HighQuality;
            grPhoto.DrawImage(imgPhoto, new Rectangle(0, 0, targetW, targetH), 0, 0, original.Width, original.Height, GraphicsUnit.Pixel);
            // Save out to memory and then to a file.  We dispose of all objects to make sure the files don't stay locked.
            MemoryStream mm = new MemoryStream();
            bmPhoto.Save(mm, ImageFormat.Jpeg);
            original.Dispose();
            imgPhoto.Dispose();
            bmPhoto.Dispose();
            grPhoto.Dispose();
            return mm.GetBuffer();
        }
    }
}
