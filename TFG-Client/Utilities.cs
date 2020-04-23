using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace TFG_Client {
    static class Utilities {


        public static string generateSingleDataRequest(string titleMessageParam) {
            JSonSingleData singleDataObject = new JSonSingleData();
            singleDataObject.A_Title = titleMessageParam;

            string jsonFormat = JsonConvert.SerializeObject(singleDataObject);

            return jsonFormat;
        }

        public static string generateSingleDataRequest(string titleMessageParam, string contentParam) {
            JSonSingleData singleDataObject = new JSonSingleData();
            singleDataObject.A_Title = titleMessageParam;
            singleDataObject.B_Content = contentParam;

            string jsonFormat = JsonConvert.SerializeObject(singleDataObject);

            return jsonFormat;
        }

        public static string generateJsonObjectArrayString(string titleMessageParam, string [] allContentParam) {
            JSonObjectArray objectArray = new JSonObjectArray();
            objectArray.A_Title = titleMessageParam;
            objectArray.B_Content = allContentParam;

            string jsonFormat = JsonConvert.SerializeObject(objectArray);
            return jsonFormat;
        }



        public static string Decrypt(string encryptedInputBase64, string ivStringParam, string passwd) {

            using (AesCryptoServiceProvider aesEncryptor = new AesCryptoServiceProvider()) {
                var encryptedData = Convert.FromBase64String(encryptedInputBase64);
                var btKey = System.Text.Encoding.ASCII.GetBytes(passwd);
                byte[] iv = Encoding.ASCII.GetBytes(ivStringParam);

                var keyString = System.Text.Encoding.Unicode.GetString(aesEncryptor.Key);
                aesEncryptor.Mode = CipherMode.CBC;
                aesEncryptor.Padding = PaddingMode.PKCS7;
                aesEncryptor.KeySize = 256;
                aesEncryptor.BlockSize = 128;
                aesEncryptor.Key = btKey;

                aesEncryptor.IV = iv;

                return InternalDecrypt(aesEncryptor, encryptedData);
            }
        }


        private static string InternalDecrypt(AesCryptoServiceProvider aesEncryptor, byte[] encryptedData) {
            using (ICryptoTransform decryptor = aesEncryptor.CreateDecryptor(aesEncryptor.Key,
                                                                             aesEncryptor.IV)) {
                byte[] decrypted;
                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(encryptedData)) {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt,
                                                                     decryptor,
                                                                     CryptoStreamMode.Read)) {
                        decrypted = new byte[encryptedData.Length];
                        var byteCount = csDecrypt.Read(decrypted, 0, encryptedData.Length);
                        string strResult = Encoding.ASCII.GetString(decrypted);
                        int pos = strResult.IndexOf('\0');
                        if (pos >= 0)
                            strResult = strResult.Substring(0, pos);
                        return strResult;
                    }
                }
            }
        }

        public static string Encrypt(string message, string KeyString, string IVString) {
            byte[] Key = ASCIIEncoding.UTF8.GetBytes(KeyString);
            byte[] IV = ASCIIEncoding.UTF8.GetBytes(IVString);

            string encrypted = null;
            RijndaelManaged rj = new RijndaelManaged();
            rj.Key = Key;
            rj.IV = IV;
            rj.Mode = CipherMode.CBC;

            try {
                MemoryStream ms = new MemoryStream();

                using (CryptoStream cs = new CryptoStream(ms, rj.CreateEncryptor(Key, IV), CryptoStreamMode.Write)) {
                    using (StreamWriter sw = new StreamWriter(cs)) {
                        sw.Write(message);
                        sw.Close();
                    }
                    cs.Close();
                }
                byte[] encoded = ms.ToArray();
                encrypted = Convert.ToBase64String(encoded);

                ms.Close();
            } catch (CryptographicException e) {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            } catch (UnauthorizedAccessException e) {
                Console.WriteLine("A file error occurred: {0}", e.Message);
                return null;
            } catch (Exception e) {
                Console.WriteLine("An error occurred: {0}", e.Message);
            } finally {
                rj.Clear();
            }
            return encrypted;
        }

        /// <summary>
        /// Detecta si el usuario tiene conexión a internet.
        /// 
        /// Function that detect if this user has a internet connection
        /// </summary>
        /// <returns>
        /// True, si el servidor al que se conecta responde (Tiene conexión)
        /// False, si el servidor al que se conecta no responde (No tiene conexión)
        /// 
        /// True, If the server that you have connected to responds (Have internet connection)
        /// False, If the server that you have connected not to responds (Don't have internet connection)
        /// </returns>
        public static bool CheckForInternetConnection() {
            try {
                WebClient client = new WebClient();
                client.OpenRead("http://google.com/generate_204");
                return true;
            } catch (Exception) {
                return false;
            }
        }

        /// <summary>
        /// Crea y muestra el formulario de soporte al usuario
        /// 
        /// Create and show support form.
        /// </summary>
        public static void createSupportForm() {
            ModelWindowsMessage supportForm = new ModelWindowsMessage();
            supportForm.StartPosition = FormStartPosition.CenterParent;
            supportForm.title.Text = "Soporte";
            supportForm.messageLabel.Text = "Para cualquier problema o duda, \n" +
                                            "envie un correo a javierferfer99@gmail.com \n" +
                                            "gracias por su colaboración";

            Point centerLocation = new Point(supportForm.messageLabel.Location.X + 120, supportForm.messageLabel.Location.Y);
            supportForm.messageLabel.Location = centerLocation;
            supportForm.ImageSchool.Visible = false;
            supportForm.ShowDialog();
        }

        /// <summary>
        /// Crea y muestra el formulario de 'Acerca de...' al usuario
        /// 
        /// Create and show About form.
        /// </summary>
        public static void createAboutForm() {
            ModelWindowsMessage aboutForm = new ModelWindowsMessage();
            aboutForm.StartPosition = FormStartPosition.CenterParent;
            aboutForm.title.Text = "Acerca de...";
            aboutForm.messageLabel.Text = "Este proyecto ha sido creado \n" +
                                          "por Javier Fernández Fernández \n" +
                                          "como trabajo de final de grado.";
            aboutForm.ShowDialog();
        }

        /// <summary>
        /// Permite mirar la horientación de la imagen y establecer en las propiedades de la misma
        /// que esté recta en caso de ser necesario.
        /// 
        /// Check if the image are in wrong position, if this case are real, change the position of image.
        /// </summary>
        /// <param name="image">Image, imagen recibida como parámetro para revisar</param>
        /// <param name="image">Image, image as paramter to check</param>
        /// <returns>
        /// ImageOrientation, Horientación de la imagen en vertical
        /// ImageOrientation, Horientation of image into vertical.
        /// </returns>
        public static ImageOrientation GetOrientation(Image image) {
            PropertyItem pi = SafeGetPropertyItem(image, 0x112);
            return ImageOrientation.Vertical;
        }



        /// <summary>
        /// Almacena las propiedades de la imagen trás ser modificadas para que la imagen esté en vertical.
        /// 
        /// Store image properties when the image has changed.
        /// </summary>
        /// <param name="image">Image, imagen como parámetro</param>
        /// <param name="image">Image, imagen has parameter</param>
        /// <param name="propid">int, Id de la imagen</param>
        /// <param name="propid">int, Id about image</param>
        /// <returns>
        /// PropertyItem, Propiedades de la imagen modificadas
        /// PropertyItem, Properties of image changed.
        /// 
        /// null, Si el archivo que se intentó modificar no tiene un archivo de registro EXIF.
        /// null, If this image hasn't EXIF file (Properties file)
        /// </returns>
        public static PropertyItem SafeGetPropertyItem(Image image, int propid) {
            try {
                return image.GetPropertyItem(propid);
            } catch (ArgumentException) {
                return null;
            }
        }

        /// <summary>
        /// Permite redimensionar la imagen.
        /// 
        /// Resize image
        /// </summary>
        /// <param name="image">Image, imagen como parámetro</param>
        /// <param name="image">Image, image as param</param>
        /// <param name="Width">int, anchura de la imagen deseada</param>
        /// <param name="Width">int, width of image that login form need</param>
        /// <param name="Height">int, altura de la imagen deseada</param>
        /// <param name="Height">int, height of image that login form need</param>
        /// <param name="needToFill">bool, indica si la imagen necesita ser llenada</param>
        /// <param name="needToFill">bool, tell if this image needs to fill</param>
        /// <returns></returns>
        public static Image FixedSize(Image image, int Width, int Height, bool needToFill) {

            int sourceWidth = image.Width;
            int sourceHeight = image.Height;
            int sourceX = 0;
            int sourceY = 0;
            double destX = 0;
            double destY = 0;

            double nScale = 0;
            double nScaleW = 0;
            double nScaleH = 0;

            nScaleW = ((double)Width / (double)sourceWidth);
            nScaleH = ((double)Height / (double)sourceHeight);
            if (!needToFill) {
                nScale = Math.Min(nScaleH, nScaleW);
            } else {
                nScale = Math.Max(nScaleH, nScaleW);
                destY = (Height - sourceHeight * nScale) / 2;
                destX = (Width - sourceWidth * nScale) / 2;
            }

            if (nScale > 1)
                nScale = 1;

            int destWidth = (int)Math.Round(sourceWidth * nScale);
            int destHeight = (int)Math.Round(sourceHeight * nScale);

            Bitmap bmPhoto = null;
            try {
                bmPhoto = new Bitmap(destWidth + (int)Math.Round(2 * destX), destHeight + (int)Math.Round(2 * destY));
            } catch (Exception ex) { }

            using (Graphics grPhoto = Graphics.FromImage(bmPhoto)) {
                grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
                grPhoto.CompositingQuality = CompositingQuality.HighQuality;
                grPhoto.SmoothingMode = SmoothingMode.HighQuality;

                Rectangle to = new Rectangle((int)Math.Round(destX), (int)Math.Round(destY), destWidth, destHeight);
                Rectangle from = new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight);
                grPhoto.DrawImage(image, to, from, GraphicsUnit.Pixel);

                return bmPhoto;
            }
        }

    }
}
