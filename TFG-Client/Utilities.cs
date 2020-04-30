using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
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

        public static bool showDevelopMessages = true;
        private static string emptyString = "";

        public static string generateSingleDataRequest(string titleMessageParam) {
            try {
                JSonSingleData singleDataObject = new JSonSingleData();
                singleDataObject.A_Title = titleMessageParam;

                string jsonFormat = JsonConvert.SerializeObject(singleDataObject);

                return jsonFormat;
            } catch (Exception ex) {
                createErrorMessage(ex.Message.ToString(), showDevelopMessages, 701, null);
                return emptyString;
            }
        }

        public static void createCustomErrorTestMessage(string letterParam) {
            Utilities.customErrorInfo("La longitud de la pregunta " + "'" + letterParam + "' " + "tiene una longitud incorrecta. \n" +
                                              "Debe tener al menos 5 caracteres y como máximo 45.");
        }

        public static string generateSingleDataRequest(string titleMessageParam, string contentParam) {
            try {
                JSonSingleData singleDataObject = new JSonSingleData();
                singleDataObject.A_Title = titleMessageParam;
                singleDataObject.B_Content = contentParam;

                string jsonFormat = JsonConvert.SerializeObject(singleDataObject);

                return jsonFormat;
            } catch (Exception ex) {
                createErrorMessage(ex.Message.ToString(), showDevelopMessages, 702, null);
                return emptyString;
            }
        }

        public static string generateJsonObjectArrayString(string titleMessageParam, string [] allContentParam) {
            try {
                JSonObjectArray objectArray = new JSonObjectArray();
                objectArray.A_Title = titleMessageParam;
                objectArray.B_Content = allContentParam;

                string jsonFormat = JsonConvert.SerializeObject(objectArray);
                return jsonFormat;
            } catch (Exception ex) {
                createErrorMessage(ex.Message.ToString(), showDevelopMessages, 703, null);
                return emptyString;
            }
            
        }



        public static string Decrypt(string encryptedInputBase64, string ivStringParam, string passwd) {
            try {
                using (AesCryptoServiceProvider aesEncryptor = new AesCryptoServiceProvider()) {
                    var encryptedData = Convert.FromBase64String(encryptedInputBase64);
                    var btKey = Encoding.UTF8.GetBytes(passwd);
                    byte[] iv = Encoding.UTF8.GetBytes(ivStringParam);

                    var keyString = System.Text.Encoding.Unicode.GetString(aesEncryptor.Key);
                    aesEncryptor.Mode = CipherMode.CBC;
                    aesEncryptor.Padding = PaddingMode.PKCS7;
                    aesEncryptor.KeySize = 256;
                    aesEncryptor.BlockSize = 128;
                    aesEncryptor.Key = btKey;

                    aesEncryptor.IV = iv;

                    return InternalDecrypt(aesEncryptor, encryptedData);
                }
            } catch (Exception ex) {
                createErrorMessage(ex.Message.ToString(), showDevelopMessages, 704, null);
                return emptyString;
            }
        }


        private static string InternalDecrypt(AesCryptoServiceProvider aesEncryptor, byte[] encryptedData) {
            try {
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
                            string strResult = Encoding.UTF8.GetString(decrypted);
                            int pos = strResult.IndexOf('\0');
                            if (pos >= 0)
                                strResult = strResult.Substring(0, pos);
                            return strResult;
                        }
                    }
                }
            } catch (Exception ex) {
                createErrorMessage(ex.Message.ToString(), showDevelopMessages, 705, null);
                return emptyString;
            }
        }

        public static string Encrypt(string message, string KeyString, string IVString) {
            try {
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
            } catch (Exception ex) {
                createErrorMessage(ex.Message.ToString(), showDevelopMessages, 706, null);
                return emptyString;
            }
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
        /// Comprueba la posición de la ventana, el usuario y la imagen del mismo en el registro de windows y carga los datos en caso de encontrarlos en el mismo.
        /// 
        /// Check windows form position, user data and user image in the windows registry. Load these datas if found in the windows registry.
        /// </summary>
        public static void checkWindowsFormPositon(MainFormProgram loginForm) {

            bool checkPositionRegistryKey = OpenKey(loginForm);

            if (!checkPositionRegistryKey) {
                RegistryKey keyPosition;
                keyPosition = Registry.CurrentUser.CreateSubKey("Software\\SEC\\Config");
                keyPosition.SetValue("positionX", loginForm.Left);
                keyPosition.SetValue("positionY", loginForm.Top);

                ImageConverter imgConv = new ImageConverter();
                byte[] imgArrayBytes = (byte[])imgConv.ConvertTo(loginForm.userImage.Image, typeof(byte[]));
                keyPosition.SetValue("userImage", imgArrayBytes);

                keyPosition.SetValue("user", loginForm.textBoxUser.Text);

                keyPosition.Close();
            } else {
                RegistryKey keyPosition = Registry.CurrentUser.OpenSubKey("Software\\SEC\\Config", true);
                string positionX = keyPosition.GetValue("positionX", true).ToString();
                string positionY = keyPosition.GetValue("positionY", true).ToString();
                string userName = keyPosition.GetValue("user", true).ToString();

                byte[] imageArrayBytes = (byte[])keyPosition.GetValue("userImage", true);
                loginForm.userImage.Image = byteArrayToImage(imageArrayBytes);

                loginForm.Left = Int32.Parse(positionX);
                loginForm.Top = Int32.Parse(positionY);
                loginForm.StartPosition = FormStartPosition.Manual;
                loginForm.Location = new Point(loginForm.Left, loginForm.Top);

                loginForm.textBoxUser.Text = userName;
                /**
                 * Restablece el placeholder del input text asociado al usuario
                 * 
                 * Restarted user input placeholder.
                 */
                if (loginForm.textBoxUser.Text == "Correo") {
                    loginForm.textBoxUser.ForeColor = Color.DarkGray;
                } else {
                    loginForm.textBoxUser.ForeColor = Color.Black;
                }


            }

        }

        /// <summary>
        /// Revisa si el valor recibido como parámetro se encuentra en el registro de windows
        /// 
        /// Check if parameter value exist into windows registry.
        /// </summary>
        /// <param name="value">string, valor a buscar en el registro de windows</param>
        /// <param name="value">string, value to find into windows registry</param>
        /// <returns>
        /// True, si encuentra el valor.
        /// False, si no lo encuentra.
        /// 
        /// True, if this valor exist.
        /// False, if this valor don't exist.
        /// </returns>
        public static bool OpenKey(MainFormProgram loginForm) {
            try {
                RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\SEC\\Config", true);
                if (key == null) {
                    throw new Exception();
                } else {
                    return true;
                }
            } catch (Exception ex) {
                return false;
            }

        }

        /// <summary>
        /// Almacena la posición de la ventana al ser cerrada por el usuario
        /// 
        /// Stored position of login form when user close the login screen
        /// </summary>
        public static void saveWindowsFormPosition(MainFormProgram loginForm) {
            if (loginForm.WindowState != FormWindowState.Minimized) {
                int positionX = loginForm.Left;
                int positionY = loginForm.Top;

                RegistryKey keyPosition;
                keyPosition = Registry.CurrentUser.CreateSubKey("Software\\SEC\\Config");
                keyPosition.SetValue("positionX", positionX);
                keyPosition.SetValue("positionY", positionY);
                ImageConverter imgConv = new ImageConverter();
                byte[] imgArrayBytes = (byte[])imgConv.ConvertTo(loginForm.userImage.Image, typeof(byte[]));
                keyPosition.SetValue("userImage", imgArrayBytes);
                keyPosition.SetValue("user", loginForm.textBoxUser.Text);
                keyPosition.Close();
            }
        }


        /// <summary>
        /// Comprueba la posición de la ventana, el usuario y la imagen del mismo en el registro de windows y carga los datos en caso de encontrarlos en el mismo.
        /// 
        /// Check windows form position, user data and user image in the windows registry. Load these datas if found in the windows registry.
        /// </summary>
        public static void checkWindowsFormPositon(UserControlPanel userControlPanel) {

            bool checkPositionRegistryKey = OpenKey(userControlPanel);

            if (!checkPositionRegistryKey) {
                RegistryKey keyPosition;
                keyPosition = Registry.CurrentUser.CreateSubKey("Software\\SEC\\Config_userPanel");
                keyPosition.SetValue("positionX_userPanel", userControlPanel.Left);
                keyPosition.SetValue("positionY_userPanel", userControlPanel.Top);
                keyPosition.Close();

            } else {
                RegistryKey keyPosition = Registry.CurrentUser.OpenSubKey("Software\\SEC\\Config_userPanel", true);
                string positionX = keyPosition.GetValue("positionX_userPanel", true).ToString();
                string positionY = keyPosition.GetValue("positionY_userPanel", true).ToString();

                userControlPanel.Left = Int32.Parse(positionX);
                userControlPanel.Top = Int32.Parse(positionY);
                userControlPanel.StartPosition = FormStartPosition.Manual;
                userControlPanel.Location = new Point(userControlPanel.Left, userControlPanel.Top);
            }

        }

        /// <summary>
        /// Revisa si el valor recibido como parámetro se encuentra en el registro de windows
        /// 
        /// Check if parameter value exist into windows registry.
        /// </summary>
        /// <param name="value">string, valor a buscar en el registro de windows</param>
        /// <param name="value">string, value to find into windows registry</param>
        /// <returns>
        /// True, si encuentra el valor.
        /// False, si no lo encuentra.
        /// 
        /// True, if this valor exist.
        /// False, if this valor don't exist.
        /// </returns>
        public static bool OpenKey(UserControlPanel userControlPanel) {
            try {
                RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\SEC\\Config_userPanel", true);
                if (key == null) {
                    throw new Exception();
                } else {
                    return true;
                }
            } catch (Exception ex) {
                return false;
            }

        }

        /// <summary>
        /// Almacena la posición de la ventana al ser cerrada por el usuario
        /// 
        /// Stored position of login form when user close the login screen
        /// </summary>
        public static void saveWindowsFormPosition(UserControlPanel userControlPanel) {
            if (userControlPanel.WindowState != FormWindowState.Minimized) {
                int positionX = userControlPanel.Left;
                int positionY = userControlPanel.Top;

                RegistryKey keyPosition;
                keyPosition = Registry.CurrentUser.CreateSubKey("Software\\SEC\\Config_userPanel");
                keyPosition.SetValue("positionX_userPanel", positionX);
                keyPosition.SetValue("positionY_userPanel", positionY);
                keyPosition.Close();
            }
        }



        /// <summary>
        /// Crea y muestra el formulario de soporte al usuario
        /// 
        /// Create and show support form.
        /// </summary>
        public static void createSupportForm() {
            try {
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
            } catch (Exception ex) {
                MessageBox.Show(ex.Message.ToString());
            }
        }


        public static void customErrorInfo(string messageParam) {
            try {
                ModelWindowsMessage customErrorMessage = new ModelWindowsMessage();
                customErrorMessage.StartPosition = FormStartPosition.CenterScreen;
                customErrorMessage.title.Text = "Un error se ha producido";
                customErrorMessage.messageLabel.Text = messageParam;

                if (customErrorMessage.Width < customErrorMessage.messageLabel.Width) {
                    customErrorMessage.Width = customErrorMessage.messageLabel.Width + 50;

                    customErrorMessage.flowLayoutTitle.Width = customErrorMessage.messageLabel.Width + 60;
                    customErrorMessage.panelDown.Width = customErrorMessage.Width + 10;
                    customErrorMessage.panelUp.Width = customErrorMessage.Width + 10;
                }

                customErrorMessage.ImageSchool.Visible = false;
                customErrorMessage.ShowDialog();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        public static void customErrorInfoModificationNormal(string messageParam) {
            try {
                ModelWindowsMessageWithBroder customErrorMessage = new ModelWindowsMessageWithBroder();
                customErrorMessage.StartPosition = FormStartPosition.CenterScreen;
                customErrorMessage.title.Text = "Un error se ha producido";
                customErrorMessage.messageLabel.Text = messageParam;

                if (customErrorMessage.Width < customErrorMessage.messageLabel.Width) {
                    customErrorMessage.Width = customErrorMessage.messageLabel.Width + 50;

                    customErrorMessage.flowLayoutTitle.Width = customErrorMessage.messageLabel.Width + 60;
                    customErrorMessage.panelDown.Width = customErrorMessage.Width + 10;
                    customErrorMessage.panelUp.Width = customErrorMessage.Width + 10;
                }
                customErrorMessage.ShowDialog();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public static void createFormNewNormalModification(string titleParam, string id, string question) {
            FormNewNormalModification formNewNormalObject = new FormNewNormalModification(id);
            formNewNormalObject.StartPosition = FormStartPosition.CenterParent;
            formNewNormalObject.title.Text = titleParam;
            formNewNormalObject.labelQuestionInfo.Text = question;
            formNewNormalObject.ShowDialog();
        }

        public static void createErrorMessage(string message, bool showDevelopMessage, int codError, Form activeFormParam) {
            try {
                ModelWindowsMessage errorForm = new ModelWindowsMessage();
                errorForm.title.Text = "Error";


                if (showDevelopMessage) {
                    errorForm.messageLabel.Text = message;
                } else {
                    errorForm.messageLabel.Text = "Se ha producido un error interno con código: " + codError.ToString() + "\n" +
                                                   "Pongase en contacto con el administrador";
                }

                if (errorForm.Width < errorForm.messageLabel.Width) {
                    errorForm.Width = errorForm.messageLabel.Width + 50;

                    errorForm.flowLayoutTitle.Width = errorForm.messageLabel.Width + 60;
                    errorForm.panelDown.Width = errorForm.Width + 10;
                    errorForm.panelUp.Width = errorForm.Width + 10;
                }

                if (activeFormParam == null) {
                    errorForm.StartPosition = FormStartPosition.CenterScreen;
                    errorForm.ImageSchool.Visible = false;
                    errorForm.ShowDialog();
                } else {
                    Point centerLocation = new Point(activeFormParam.Location.X + 120, activeFormParam.Location.Y);
                    errorForm.messageLabel.Location = centerLocation;
                    errorForm.ImageSchool.Visible = false;
                    errorForm.ShowDialog();
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message.ToString());
            }
        }


        /// <summary>
        /// Crea y muestra el formulario de 'Acerca de...' al usuario
        /// 
        /// Create and show About form.
        /// </summary>
        public static void createAboutForm() {
            try {
                ModelWindowsMessage aboutForm = new ModelWindowsMessage();
                aboutForm.StartPosition = FormStartPosition.CenterParent;
                aboutForm.title.Text = "Acerca de...";
                aboutForm.messageLabel.Text = "Este proyecto ha sido creado \n" +
                                              "por Javier Fernández Fernández \n" +
                                              "como trabajo de final de grado.";
                aboutForm.ShowDialog();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message.ToString());
            }
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
        /// Convierte el array de bytes en una imagen
        /// 
        /// Convert byte array into image
        /// </summary>
        /// <param name="byteArrayParam">byte [], Array de bytes que contiene toda la info sobre la imagen antes de ser convertida a imagen</param>
        /// <param name="byteArrayParam">byte [], array of bytes that contain all information about image before that convert into image</param>
        /// <returns>
        /// El array de bytes convertido a imagen
        /// 
        /// Array of bytes convert into image
        /// </returns>
        public static Image byteArrayToImage(byte[] byteArrayParam) {
            using (MemoryStream ms = new MemoryStream(byteArrayParam)) {
                return Image.FromStream(ms);
            }
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

        public static void openForm(object childFormParam, Panel DataPanelParam, Panel rightPanelParam) {
            if (DataPanelParam.Controls.Count > 0) {
                DataPanelParam.Controls.RemoveAt(0);
            }

            // Agregar comprobante para evitar perdida de datos por parte del usuario
            //MessageBox.Show(childFormParam.GetType().ToString());
            Form childFormObject = childFormParam as Form;
            childFormObject.TopLevel = false;
            childFormObject.Dock = DockStyle.Fill;
            //DataPanelParam.Controls.SetChildIndex(childFormObject, 0, 0);
            DataPanelParam.Controls.Add(childFormObject);
            DataPanelParam.Tag = childFormObject;
            rightPanelParam.Dock = DockStyle.Right;
            childFormObject.Show();
        }

    }
}
