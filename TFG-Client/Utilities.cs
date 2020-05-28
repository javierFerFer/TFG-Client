////////////////////////////////////////////////////////////////////////////////////////////////////
/// <file>  TFG-Client\Utilities.cs </file>
///
/// <copyright file="Utilities.cs" company="San José">
/// Copyright (c) 2020 San José. All rights reserved.
/// </copyright>
///
/// <summary>   Implementación de la clase utilidades.\n
///             Implements the utilities class. </summary>
////////////////////////////////////////////////////////////////////////////////////////////////////

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

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Todas las utlilidades del programa.\n
    ///             All utilities of the program. </summary>
    ///
    /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    static class Utilities {

        public static bool showDevelopMessages = false;
        public static bool warningAnser = true;
        private static string emptyString = "";

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Resetea el valor de la variable warning.\n
        ///             Resets the warning anser value. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void resetWarningAnserValue() {
            warningAnser = true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Permite la creación de formularios de advertencia.\n
        ///             Allow to create warnings forms. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <returns>   True si todo va bien, false en caso contrario.\n
        ///             True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool createWarningForm() {
            try {

                resetWarningAnserValue();

                ModelWindowsMessageWithBroderWarning customWarningMessage = new ModelWindowsMessageWithBroderWarning();
                customWarningMessage.StartPosition = FormStartPosition.CenterScreen;
                customWarningMessage.title.Text = "Advertencia";
                customWarningMessage.messageLabel.Text = "Si continua, se perderán todos los cambios que haya realizado\n" +
                                                       "¿Desea continuar?";

                if (customWarningMessage.Width < customWarningMessage.messageLabel.Width) {
                    customWarningMessage.Width = customWarningMessage.messageLabel.Width + 50;

                    customWarningMessage.flowLayoutTitle.Width = customWarningMessage.messageLabel.Width + 60;
                    customWarningMessage.panelDown.Width = customWarningMessage.Width + 10;
                    customWarningMessage.panelUp.Width = customWarningMessage.Width + 10;
                }

                // Se establece propietario del formulario de error para evitar perdida del foco
                if (ConnectionWithServer.LoginForm != null) {
                    ConnectionWithServer.LoginForm.Invoke(new MethodInvoker(delegate {
                        ConnectionWithServer.LoginForm.ModelWindowsMessageWithBroderWarning = customWarningMessage;
                        customWarningMessage.ShowDialog(ConnectionWithServer.LoginForm);
                    }));
                } else {
                    customWarningMessage.ShowDialog();
                }
                if (warningAnser) {
                    return true;
                } else {
                    return false;
                }
            } catch (Exception ex) {
                return false;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Permite la creación de formularios de advertencia con mensaje.\n 
        /// Allow to create warnings forms with message.
        /// </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <param name="messageParam"> Mensaje a mostrar.\n
        ///                             Message to show. </param>
        ///
        /// <returns>
        /// True si todo va bien, false en caso contrario.\n 
        /// True if it succeeds, false if it fails.
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool createWarningForm(string messageParam) {
            try {

                resetWarningAnserValue();

                ModelWindowsMessageWithBroderWarning customWarningMessage = new ModelWindowsMessageWithBroderWarning();
                customWarningMessage.StartPosition = FormStartPosition.CenterScreen;
                customWarningMessage.title.Text = "Advertencia";
                customWarningMessage.messageLabel.Text = messageParam + "\n" +
                                                       "¿Desea continuar?";

                if (customWarningMessage.Width < customWarningMessage.messageLabel.Width) {
                    customWarningMessage.Width = customWarningMessage.messageLabel.Width + 50;

                    customWarningMessage.flowLayoutTitle.Width = customWarningMessage.messageLabel.Width + 60;
                    customWarningMessage.panelDown.Width = customWarningMessage.Width + 10;
                    customWarningMessage.panelUp.Width = customWarningMessage.Width + 10;
                }

                // Se establece propietario del formulario de error para evitar perdida del foco
                if (ConnectionWithServer.LoginForm != null) {
                    ConnectionWithServer.LoginForm.Invoke(new MethodInvoker(delegate {
                        ConnectionWithServer.LoginForm.ModelWindowsMessageWithBroderWarning = customWarningMessage;
                        customWarningMessage.ShowDialog(ConnectionWithServer.LoginForm);
                    }));
                } else {
                    customWarningMessage.ShowDialog();
                }
                if (warningAnser) {
                    return true;
                } else {
                    return false;
                }
            } catch (Exception ex) {
                return false;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Permite la creación de formularios de advertencia con mensaje y título.\n 
        /// Allow to create warnings forms with message and title.
        /// </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <param name="titleParam">   Título.\n
        ///                             The title parameter. </param>
        /// <param name="messageParam"> Mensaje a mostrar.\n 
        ///                             Message to show. </param>
        ///
        /// <returns>
        /// True si todo va bien, false en caso contrario.\n 
        /// True if it succeeds, false if it fails.
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool createWarningForm(string titleParam, string messageParam) {
            try {

                resetWarningAnserValue();

                ModelWindowsMessageWithBroderWarning customWarningMessage = new ModelWindowsMessageWithBroderWarning(4000);
                customWarningMessage.StartPosition = FormStartPosition.CenterScreen;
                customWarningMessage.title.Text = titleParam;
                customWarningMessage.messageLabel.Text = messageParam;

                if (customWarningMessage.Width < customWarningMessage.messageLabel.Width) {
                    customWarningMessage.Width = customWarningMessage.messageLabel.Width + 50;

                    customWarningMessage.flowLayoutTitle.Width = customWarningMessage.messageLabel.Width + 60;
                    customWarningMessage.panelDown.Width = customWarningMessage.Width + 10;
                    customWarningMessage.panelUp.Width = customWarningMessage.Width + 10;
                }

                // Se establece propietario del formulario de error para evitar perdida del foco
                if (ConnectionWithServer.LoginForm != null) {
                    ConnectionWithServer.LoginForm.Invoke(new MethodInvoker(delegate {
                        ConnectionWithServer.LoginForm.ModelWindowsMessageWithBroderWarning = customWarningMessage;
                        customWarningMessage.ShowDialog(ConnectionWithServer.LoginForm);
                    }));
                } else {
                    customWarningMessage.ShowDialog();
                }
                if (warningAnser) {
                    return true;
                } else {
                    return false;
                }
            } catch (Exception ex) {
                return false;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Genera peticiones simples.\n
        ///             Generates a single data request. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <param name="titleMessageParam">    Título del mensaje a enviar.\n
        ///                                     Title of message to send. </param>
        ///
        /// <returns>   Objeto mensaje simple.\n
        ///             Simple object message. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Crea error customizado.\n
        ///             Create custom errror </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <param name="letterParam">  Pregunta errónea.\n
        ///                             Wrong question. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void createCustomErrorTestMessage(string letterParam) {
            Utilities.customErrorInfo("La longitud de la pregunta " + "'" + letterParam + "' " + "tiene una longitud incorrecta. \n" +
                                              "Debe tener al menos 5 caracteres y como máximo 45.");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Genera peticiones simples con título y mensaje.\n 
        ///             Generates a single data request with title and message. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <param name="titleMessageParam">
        /// Título del mensaje a enviar.\n 
        /// Title of message to send.
        /// </param>
        /// <param name="contentParam">         Contenido del mensaje a enviar.\n
        ///                                     Content of the message to send. </param>
        ///
        /// <returns>   Objeto mensaje simple.\n 
        ///             Simple object message. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Genera objetos complejos JSON.\n
        ///             Generate complex JSON objects. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <param name="titleMessageParam">
        /// Título del mensaje a enviar.\n 
        /// Title of message to send.
        /// </param>
        /// <param name="allContentParam">      lista de datos del mensaje.\n
        ///                                     List with all data of the message. </param>
        ///
        /// <returns>   Objeto complejo JSON.\n
        ///             The JSON object array string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string generateJsonObjectArrayString(string titleMessageParam, string[] allContentParam) {
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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Desencripta el mensaje recibido del servidor.\n
        ///             Decrypt the message of the server. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <param name="encryptedInputBase64"> Mensaje encriptado.\n
        ///                                     The encrypted input base 64. </param>
        /// <param name="ivStringParam">        IV param.\n
        ///                                     The iv string parameter. </param>
        /// <param name="passwd">               La contraseña usada en la comunicación.\n
        ///                                     The passwd. </param>
        ///
        /// <returns>   Mensaje desencriptado.\n
        ///             Decrypted message. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Desencriptado interno.\n
        ///             Internal decrypt. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <param name="aesEncryptor">     Objeto que permite el desencriptado.\n
        ///                                 The aes encryptor. </param>
        /// <param name="encryptedData">    Array de bytes de mensaje encriptado.\n
        ///                                 The aes encryptor. </param>
        ///
        /// <returns>   Mensaje desencriptado.\n
        ///             Decrypted message. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Encripta mensajes.\n
        ///             Encrypts messages. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <param name="message">      Mensaje a encriptar.\n
        ///                             Message to ecrypt. </param>
        /// <param name="KeyString">    Key usada en la encriptación.\n
        ///                             Encrypt key. </param>
        /// <param name="IVString">     IV parametro.\n
        ///                             IV param. </param>
        ///
        /// <returns>   Mensaje cifrado.\n
        ///             Encrypted message. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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
                    return null;
                } catch (UnauthorizedAccessException e) {
                    return null;
                } catch (Exception e) {
                } finally {
                    rj.Clear();
                }
                return encrypted;
            } catch (Exception ex) {
                createErrorMessage(ex.Message.ToString(), showDevelopMessages, 706, null);
                return emptyString;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Detecta si el usuario tiene conexión a internet o no.\n
        ///             Determines if we can check for internet connection. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <returns>   True = tiene conexión, false en caso contrario.\n
        ///             True = connect to internet, false in the opposite case. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool CheckForInternetConnection() {
            try {
                WebClient client = new WebClient();
                client.OpenRead("http://google.com/generate_204");
                return true;
            } catch (Exception) {
                return false;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Comprueba la posición de la ventana, el usuario y la imagen del mismo en el registro de
        /// windows y carga los datos en caso de encontrarlos en el mismo.\n
        /// 
        /// 
        /// Check windows form position, user data and user image in the windows registry. Load these
        /// datas if found in the windows registry.
        /// </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <param name="loginForm">    Formulario de login.\n
        ///                             Login form. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Revisa si el valor recibido como parámetro se encuentra en el registro de windows
        /// 
        /// Check if parameter value exist into windows registry.
        /// </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="loginForm">    Formulario de login.\n Login form. </param>
        ///
        /// <returns>
        /// True, si encuentra el valor. False, si no lo encuentra.
        /// 
        /// True, if this valor exist. False, if this valor don't exist.
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Almacena la posición de la ventana al ser cerrada por el usuario
        /// 
        /// Stored position of login form when user close the login screen.
        /// </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <param name="loginForm">    Formulario de login.\n Login form. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Comprueba la posición de la ventana, el usuario y la imagen del mismo en el registro de
        /// windows y carga los datos en caso de encontrarlos en el mismo.\n
        /// 
        /// 
        /// Check windows form position, user data and user image in the windows registry. Load these
        /// datas if found in the windows registry.
        /// </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <param name="userControlPanel"> The user control panel. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Revisa si el valor recibido como parámetro se encuentra en el registro de windows
        /// 
        /// Check if parameter value exist into windows registry.
        /// </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="userControlPanel"> The user control panel. </param>
        ///
        /// <returns>
        /// True, si encuentra el valor. False, si no lo encuentra.
        /// 
        /// True, if this valor exist. False, if this valor don't exist.
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Almacena la posición de la ventana al ser cerrada por el usuario
        /// 
        /// Stored position of login form when user close the login screen.
        /// </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <param name="userControlPanel"> The user control panel. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Crea formulario de soporte.\n
        ///             Creates support form. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void createSupportForm() {
            try {
                ModelWindowsMessage supportForm = new ModelWindowsMessage();
                supportForm.StartPosition = FormStartPosition.CenterParent;
                supportForm.title.Text = "Soporte";
                supportForm.messageLabel.Text = "Para cualquier problema o duda, \n" +
                                                "envíe un correo a javierferfer99@gmail.com \n" +
                                                "gracias por su colaboración";

                Point centerLocation = new Point(supportForm.messageLabel.Location.X + 120, supportForm.messageLabel.Location.Y);
                supportForm.messageLabel.Location = centerLocation;
                supportForm.ImageSchool.Visible = false;
                if (ConnectionWithServer.LoginForm != null) {
                    ConnectionWithServer.LoginForm.Invoke(new MethodInvoker(delegate {
                        ConnectionWithServer.LoginForm.ModelWindowsMessage = supportForm;
                        supportForm.ShowDialog(ConnectionWithServer.LoginForm);
                    }));
                } else {
                    supportForm.ShowDialog(ConnectionWithServer.LoginForm);
                }
            } catch (Exception ex) {
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Crea mensaje de error.\n
        ///             Create error message </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <param name="messageParam"> Mensaje a mostrar.\n 
        ///                             Message to show. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

                // Se establece propietario del formulario de error para evitar perdida del foco
                if (ConnectionWithServer.LoginForm != null) {
                    ConnectionWithServer.LoginForm.Invoke(new MethodInvoker(delegate {
                        ConnectionWithServer.LoginForm.ModelWindowsMessage = customErrorMessage;
                        customErrorMessage.ShowDialog(ConnectionWithServer.LoginForm);
                    }));
                } else {
                    customErrorMessage.ShowDialog();
                }

            } catch (Exception ex) {
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Crea mensaje de error.\n
        ///             Create error message </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <param name="messageParam"> Mensaje a mostrar.\n 
        ///                             Message to show. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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
                // Se establece propietario del formulario de error para evitar perdida del foco
                if (ConnectionWithServer.LoginForm != null) {
                    ConnectionWithServer.LoginForm.Invoke(new MethodInvoker(delegate {
                        ConnectionWithServer.LoginForm.ModelWindowsMessageWithBroder = customErrorMessage;
                        customErrorMessage.ShowDialog(ConnectionWithServer.LoginForm);
                    }));
                } else {
                    customErrorMessage.ShowDialog();
                }
            } catch (Exception ex) {
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Crea formulario para modificaciones de preguntas normales.\n
        ///             Create form to modify normal questions. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <param name="titleParam">   Título.\n 
        ///                             The title parameter. </param>
        /// <param name="id">           ID.\n
        ///                             ID. </param>
        /// <param name="question">     La pregunta.\n
        ///                             The question. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void createFormNewNormalModification(string titleParam, string id, string question) {
            FormNewNormalModification formNewNormalObject = new FormNewNormalModification(id);
            formNewNormalObject.StartPosition = FormStartPosition.CenterParent;
            formNewNormalObject.title.Text = titleParam;
            formNewNormalObject.labelQuestionInfo.Text = question;
            if (ConnectionWithServer.LoginForm != null) {
                ConnectionWithServer.LoginForm.Invoke(new MethodInvoker(delegate {
                    ConnectionWithServer.LoginForm.FormNewNormalModification = formNewNormalObject;
                    formNewNormalObject.ShowDialog(ConnectionWithServer.LoginForm);
                }));
            } else {
                formNewNormalObject.ShowDialog(ConnectionWithServer.LoginForm);
            }

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Crea formularios normales para agregaciones/borados.\n
        ///             Creates form new normal modification add or delete. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <param name="titleParam">   Título.\n 
        ///                             The title parameter. </param>
        /// <param name="id">           ID.\n 
        ///                             ID. </param>
        /// <param name="question">     La pregunta.\n 
        ///                             The question. </param>
        /// <param name="modification"> La modificación.\n
        ///                             The modification. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void createFormNewNormalModificationAddOrDelete(string titleParam, string id, string question, string modification) {
            FormNewNormalModificationAddOrDelete formNewNormalObject = new FormNewNormalModificationAddOrDelete(id);
            formNewNormalObject.StartPosition = FormStartPosition.CenterParent;
            formNewNormalObject.title.Text = titleParam;
            formNewNormalObject.labelQuestionInfo.Text = question;
            formNewNormalObject.labelModification.Text = modification;
            if (modification.Equals("Borrar")) {
                formNewNormalObject.buttonSend.Visible = false;
            } else {
                formNewNormalObject.buttonDelete.Visible = false;
            }
            if (ConnectionWithServer.LoginForm != null) {
                ConnectionWithServer.LoginForm.Invoke(new MethodInvoker(delegate {
                    ConnectionWithServer.LoginForm.FormNewNormalModificationAddOrDelete1 = formNewNormalObject;
                    formNewNormalObject.ShowDialog(ConnectionWithServer.LoginForm);
                }));
            } else {
                formNewNormalObject.ShowDialog(ConnectionWithServer.LoginForm);
            }

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Crea formulario para las modificaciones de tipo test.\n
        ///             Creates form new test modification add or delete. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <param name="titleParam">       Título.\n 
        ///                                 The title parameter. </param>
        /// <param name="idQuestion">       ID.\n
        ///                                 ID. </param>
        /// <param name="dataOfQuestion">   Datos de la pregunta.\n
        ///                                 Data of the question.
        ///                                  </param>
        /// <param name="dataOfMod">        Datos de la modificación.\n
        ///                                 Data of the modification.</param>
        /// <param name="option">            True -> Borrar pregunta, false -> actualizar pregunta.\n
        ///                                  True -> Delete question, false -> update question. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void createFormNewTestModificationAddOrDelete(string titleParam, string idQuestion, string[] dataOfQuestion, string[] dataOfMod, bool option) {
            // true -> delete option, false -> update option
            FormNewTestModificationAddOrDelete formNewTestModificationAddOrDelete = new FormNewTestModificationAddOrDelete(idQuestion);
            formNewTestModificationAddOrDelete.StartPosition = FormStartPosition.CenterParent;
            formNewTestModificationAddOrDelete.title.Text = titleParam;
            formNewTestModificationAddOrDelete.labelQuestion.Text += dataOfQuestion[1];
            formNewTestModificationAddOrDelete.labelAnswerA.Text += dataOfQuestion[2];
            formNewTestModificationAddOrDelete.labelAnswerB.Text += dataOfQuestion[3];
            formNewTestModificationAddOrDelete.labelAnswerC.Text += dataOfQuestion[4];
            formNewTestModificationAddOrDelete.labelAnswerD.Text += dataOfQuestion[5];
            formNewTestModificationAddOrDelete.labelAnswerCorrect.Text += dataOfQuestion[6];
            if (!option) {
                formNewTestModificationAddOrDelete.labelNewQuest.Text += dataOfMod[1];
                formNewTestModificationAddOrDelete.labelNewAnserA.Text += dataOfMod[2];
                formNewTestModificationAddOrDelete.labelNewAnserB.Text += dataOfMod[3];
                formNewTestModificationAddOrDelete.labelNewAnserC.Text += dataOfMod[4];
                formNewTestModificationAddOrDelete.labelNewAnserD.Text += dataOfMod[5];
                formNewTestModificationAddOrDelete.labelNewAnserCorrect.Text += dataOfMod[6];
                formNewTestModificationAddOrDelete.buttonDelete.Visible = false;
            } else {
                formNewTestModificationAddOrDelete.labelNewQuest.Visible = false;
                formNewTestModificationAddOrDelete.labelNewAnserA.Visible = false;
                formNewTestModificationAddOrDelete.labelNewAnserB.Visible = false;
                formNewTestModificationAddOrDelete.labelNewAnserC.Visible = false;
                formNewTestModificationAddOrDelete.labelNewAnserD.Visible = false;
                formNewTestModificationAddOrDelete.labelNewAnserCorrect.Visible = false;
                formNewTestModificationAddOrDelete.labelInfoModifications.Visible = false;
                formNewTestModificationAddOrDelete.buttonSend.Visible = false;
                formNewTestModificationAddOrDelete.buttonDelete.Location = new Point(600, formNewTestModificationAddOrDelete.buttonDelete.Location.Y);
                formNewTestModificationAddOrDelete.buttonDeny.Location = new Point(500, formNewTestModificationAddOrDelete.buttonDelete.Location.Y);
                formNewTestModificationAddOrDelete.Size = new Size(690, formNewTestModificationAddOrDelete.Size.Height);
            }

            if (ConnectionWithServer.LoginForm != null) {
                ConnectionWithServer.LoginForm.Invoke(new MethodInvoker(delegate {
                    ConnectionWithServer.LoginForm.FormNewTestModificationAddOrDelete = formNewTestModificationAddOrDelete;
                    formNewTestModificationAddOrDelete.ShowDialog(ConnectionWithServer.LoginForm);
                }));
            } else {
                formNewTestModificationAddOrDelete.ShowDialog(ConnectionWithServer.LoginForm);
            }

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Crea mensaje Pop-Up con todas las preguntas.\n
        ///             Create Pop-up message with all questions. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <param name="allQuestionsData"> Todos los datos de las preguntas.\n
        ///                                 Information describing all questions. </param>
        /// <param name="dataPanelParam">   Panel donde el programa muestra los datos.\n
        ///                                 Panel where program show all data. </param>
        /// <param name="rightPanelParam">  Panel derecho.\n
        ///                                 Right panel. </param>
        /// <param name="subjectParam">     Tema seleccionado.\n
        ///                                 Selected subject. </param>
        /// <param name="optionParam">      True = normal, false = test. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void createPopUpWithAllQuestions(string[] allQuestionsData, Panel dataPanelParam, Panel rightPanelParam, string subjectParam, bool optionParam) {
            // optionParam = true -> normal, optionParam = false -> test
            FormNormalModelToUse formNormalModelToUseObject = new FormNormalModelToUse(allQuestionsData, dataPanelParam, rightPanelParam, subjectParam);
            formNormalModelToUseObject.StartPosition = FormStartPosition.CenterParent;
            if (ConnectionWithServer.LoginForm != null) {
                ConnectionWithServer.LoginForm.Invoke(new MethodInvoker(delegate {
                    ConnectionWithServer.LoginForm.FormNormalModelToUse = formNormalModelToUseObject;
                    if (optionParam) {
                        formNormalModelToUseObject.fillQuestions();
                        formNormalModelToUseObject.dataGridViewTestData.Visible = false;
                    } else {
                        formNormalModelToUseObject.fillQuestionsTest();
                        formNormalModelToUseObject.dataGridViewAllNormalData.Visible = false;
                    }

                    formNormalModelToUseObject.ShowDialog(ConnectionWithServer.LoginForm);
                }));
            } else {
                formNormalModelToUseObject.ShowDialog(ConnectionWithServer.LoginForm);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Crea mensajes Pop-up con todas las preguntas de tipo test.\n
        ///             Create Pop-Up message with all test questions. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <param name="allQuestionsData">
        /// Todos los datos de las preguntas.\n 
        /// Information describing all questions.
        /// </param>
        /// <param name="dataPanelParam">
        /// Panel donde el programa muestra los datos.\n 
        /// Panel where program show all data.
        /// </param>
        /// <param name="rightPanelParam">  Panel derecho.\n 
        ///                                 Right panel. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void createPopUpWithAllQuestionsTest(string[] allQuestionsData, Panel dataPanelParam, Panel rightPanelParam) {

            FormTestModifications formTestModificationsObject = new FormTestModifications(allQuestionsData, dataPanelParam, rightPanelParam);
            formTestModificationsObject.StartPosition = FormStartPosition.CenterParent;
            if (ConnectionWithServer.LoginForm != null) {
                ConnectionWithServer.LoginForm.Invoke(new MethodInvoker(delegate {
                    ConnectionWithServer.LoginForm.FormTestModifications = formTestModificationsObject;
                    formTestModificationsObject.fillQuestionsTest();

                    formTestModificationsObject.ShowDialog(ConnectionWithServer.LoginForm);
                }));
            } else {
                formTestModificationsObject.ShowDialog(ConnectionWithServer.LoginForm);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Crea formulario para las modificaciones de modelos normales.\n
        ///             Create form to modify normal models. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <param name="idParam">              ID de la pregunta.\n
        ///                                     ID of the question. </param>
        /// <param name="questionParam">        Pregunta a modificar.\n
        ///                                     Question to modify.</param>
        /// <param name="tempRow">              Fila temporal.\n
        ///                                     The temporary row. </param>
        /// <param name="allQuestionsParam">    Lista de todas las preguntas.\n
        ///                                     List with all questions. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void createNewNormalModificationForModel(string idParam, string questionParam, DataGridViewRow tempRow, DataGridView allQuestionsParam) {
            FormNewNormalModificationForModel formNewNormalModificationForModel = new FormNewNormalModificationForModel(idParam, questionParam, tempRow, allQuestionsParam);
            formNewNormalModificationForModel.StartPosition = FormStartPosition.CenterParent;
            if (ConnectionWithServer.LoginForm != null) {
                ConnectionWithServer.LoginForm.Invoke(new MethodInvoker(delegate {
                    ConnectionWithServer.LoginForm.FormNewNormalModificationForModel = formNewNormalModificationForModel;
                    formNewNormalModificationForModel.ShowDialog(ConnectionWithServer.LoginForm);
                }));
            } else {
                formNewNormalModificationForModel.ShowDialog(ConnectionWithServer.LoginForm);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Crea formulario para las modificaciones de modelos test.\n
        ///             Create form to modify test models. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <param name="idParam">              ID de la pregunta.\n 
        ///                                     ID of the question. </param>
        /// <param name="questionParam">        Pregunta a modificar.\n 
        ///                                     Question to modify. </param>
        /// <param name="answer_A">             Respuesta A.\n
        ///                                     The answer a. </param>
        /// <param name="answer_B">             Respuesta B.\n
        ///                                     The answer b. </param>
        /// <param name="answer_C">             Respuesta C.\n
        ///                                     The answer c. </param>
        /// <param name="answer_D">             Respuesta D.\n
        ///                                     The answer d. </param>
        /// <param name="answer_Correct">       La respuesta correcta.\n
        ///                                     The answer correct. </param>
        /// <param name="tempRow">              Fila temporal.\n 
        ///                                     The temporary row. </param>
        /// <param name="allQuestionsParam">
        /// Lista de todas las preguntas.\n 
        /// List with all questions.
        /// </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void createNewTestModificationForModel(string idParam, string questionParam, string answer_A, string answer_B, string answer_C, string answer_D, string answer_Correct, DataGridViewRow tempRow, DataGridView allQuestionsParam) {
            FormNewTestModificationForModel formNewTestModificationForModel = new FormNewTestModificationForModel(idParam, questionParam, answer_A, answer_B, answer_C, answer_D, answer_Correct, tempRow, allQuestionsParam);
            formNewTestModificationForModel.StartPosition = FormStartPosition.CenterParent;
            if (ConnectionWithServer.LoginForm != null) {
                ConnectionWithServer.LoginForm.Invoke(new MethodInvoker(delegate {
                    ConnectionWithServer.LoginForm.FormNewTestModificationForModel = formNewTestModificationForModel;
                    formNewTestModificationForModel.ShowDialog(ConnectionWithServer.LoginForm);
                }));
            } else {
                formNewTestModificationForModel.ShowDialog(ConnectionWithServer.LoginForm);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Crea formulario para modificaciones de tipo test.\n
        ///             Creates form new test modification. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <param name="titleParam">       Título.\n 
        ///                                 The title parameter. </param>
        /// <param name="id">               ID.\n 
        ///                                 ID. </param>
        /// <param name="question">         La pregunta.\n 
        ///                                 The question. </param>
        /// <param name="answer_A">         Respuesta A.\n 
        ///                                 The answer a. </param>
        /// <param name="answer_B">         Respuesta B.\n 
        ///                                 The answer b. </param>
        /// <param name="answer_C">         Respuesta C.\n 
        ///                                 The answer c. </param>
        /// <param name="answer_D">         Respuesta D.\n 
        ///                                 The answer d. </param>
        /// <param name="answer_correct">   La respuesta correcta.\n
        ///                                 The answer correct. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void createFormNewTestModification(string titleParam, string id, string question, string answer_A, string answer_B, string answer_C, string answer_D, string answer_correct) {
            FormNewTestModification formNewTestObject = new FormNewTestModification(id, question, answer_A, answer_B, answer_C, answer_D, answer_correct);
            formNewTestObject.StartPosition = FormStartPosition.CenterParent;
            formNewTestObject.title.Text = titleParam;
            formNewTestObject.labelQuestion.Text += question;
            formNewTestObject.labelAnswerA.Text += answer_A;
            formNewTestObject.labelAnswerB.Text += answer_B;
            formNewTestObject.labelAnswerC.Text += answer_C;
            formNewTestObject.labelAnswerD.Text += answer_D;
            formNewTestObject.labelAnswerCorrect.Text += answer_correct;
            if (ConnectionWithServer.LoginForm != null) {
                ConnectionWithServer.LoginForm.Invoke(new MethodInvoker(delegate {
                    ConnectionWithServer.LoginForm.FormNewTestModification = formNewTestObject;
                    formNewTestObject.ShowDialog(ConnectionWithServer.LoginForm);
                }));
            } else {
                formNewTestObject.ShowDialog(ConnectionWithServer.LoginForm);
            }

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Crea mensaje de error.\n
        ///             The answer correct. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <param name="message">              Mensaje a encriptar.\n 
        ///                                     Message to ecrypt. </param>
        /// <param name="showDevelopMessage">   True = muestra mensaje de desarrollo, false = no lo muestra.\n
        ///                                     True to show, false to hide the develop message. </param>
        /// <param name="codError">             Código de error.\n
        ///                                     Error code. </param>
        /// <param name="activeFormParam">      Formulario activo.\n
        ///                                     The active form parameter. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void createErrorMessage(string message, bool showDevelopMessage, int codError, Form activeFormParam) {
            try {
                ModelWindowsMessage errorForm = new ModelWindowsMessage();
                errorForm.title.Text = "Error";


                if (showDevelopMessage) {
                    errorForm.messageLabel.Text = message;
                } else {
                    errorForm.messageLabel.Text = "Se ha producido un error, cierre el programa e intentelo más tarde.\n" +
                                                   "Si el problema persiste, póngase en contacto con el administrador.";
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
                    // Se establece propietario del formulario de error para evitar perdida del foco
                    if (ConnectionWithServer.LoginForm != null) {
                        ConnectionWithServer.LoginForm.Invoke(new MethodInvoker(delegate {
                            errorForm.ShowDialog(ConnectionWithServer.LoginForm);
                        }));
                    } else {
                        errorForm.ShowDialog();
                    }
                } else {
                    Point centerLocation = new Point(activeFormParam.Location.X + 120, activeFormParam.Location.Y);
                    errorForm.messageLabel.Location = centerLocation;
                    errorForm.ImageSchool.Visible = false;
                    // Se establece propietario del formulario de error para evitar perdida del foco
                    if (ConnectionWithServer.LoginForm != null) {
                        ConnectionWithServer.LoginForm.Invoke(new MethodInvoker(delegate {
                            ConnectionWithServer.LoginForm.ModelWindowsMessage = errorForm;
                            errorForm.ShowDialog(ConnectionWithServer.LoginForm);
                        }));
                    } else {
                        errorForm.ShowDialog();
                    }
                }
            } catch (Exception ex) {
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Crea el formulario Acerca de...\n
        ///             Creates about form. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void createAboutForm() {
            try {
                ModelWindowsMessage aboutForm = new ModelWindowsMessage();
                aboutForm.StartPosition = FormStartPosition.CenterParent;
                aboutForm.title.Text = "Acerca de...";
                aboutForm.messageLabel.Text = "Este proyecto ha sido creado \n" +
                                              "por Javier Fernández Fernández \n" +
                                              "como trabajo de final de grado.\n" +
                                              "Fecha 26/05/2020";
                if (ConnectionWithServer.LoginForm != null) {
                    ConnectionWithServer.LoginForm.Invoke(new MethodInvoker(delegate {
                        ConnectionWithServer.LoginForm.ModelWindowsMessage = aboutForm;
                        aboutForm.ShowDialog(ConnectionWithServer.LoginForm);
                    }));
                } else {
                    aboutForm.ShowDialog(ConnectionWithServer.LoginForm);
                }
            } catch (Exception ex) {
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Obtiene la orientación de la imagen.\n
        ///             Get the orientation of the image </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <param name="image">    imagen como parámetro.\n
        ///                         Image </param>
        ///
        /// <returns>   La orientación.\n
        ///             The orientation. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static ImageOrientation GetOrientation(Image image) {
            PropertyItem pi = SafeGetPropertyItem(image, 0x112);
            return ImageOrientation.Vertical;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Convierte el array de bytes a imagen.\n
        ///             Convert byte array into image. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <param name="byteArrayParam">   Array de bytes.\n
        ///                                 Bytes array. </param>
        ///
        /// <returns>   La imagen.\n
        ///             An Image. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static Image byteArrayToImage(byte[] byteArrayParam) {
            using (MemoryStream ms = new MemoryStream(byteArrayParam)) {
                return Image.FromStream(ms);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Almacena las propiedades de la imagen.\n
        ///             Store image properties </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <param name="image">    imagen como parámetro.\n 
        ///                         Image. </param>
        /// <param name="propid">   Las propiedades.\n
        ///                         The propid. </param>
        ///
        /// <returns>   Las propiedades.\n
        ///             A PropertyItem. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static PropertyItem SafeGetPropertyItem(Image image, int propid) {
            try {
                return image.GetPropertyItem(propid);
            } catch (ArgumentException) {
                return null;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Redimensiona la imagen.\n
        ///             Resize the image. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <param name="image">        imagen como parámetro.\n 
        ///                             Image. </param>
        /// <param name="Width">        La anchura.\n
        ///                             The width. </param>
        /// <param name="Height">       La altura.\n
        ///                             The height. </param>
        /// <param name="needToFill">   Si necesita rellenar la imagen.\n
        ///                             True to need to fill. </param>
        ///
        /// <returns>   La imagen.\n
        ///             An Image. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Permite abrir un formulario.\n
        ///             Allow to open the form. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 22/04/2020. </remarks>
        ///
        /// <param name="childFormParam">   Formulario hijo.\n
        ///                                 The child form parameter. </param>
        /// <param name="DataPanelParam">   Panel de datos donde se muestran los datos.\n
        ///                                 The data panel parameter. </param>
        /// <param name="rightPanelParam">  Panel derecho.\n 
        ///                                 Right panel. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void openForm(object childFormParam, Panel DataPanelParam, Panel rightPanelParam) {
            if (DataPanelParam.Controls.Count > 0) {
                DataPanelParam.Controls.RemoveAt(0);
            }

            Form childFormObject = childFormParam as Form;
            childFormObject.TopLevel = false;
            childFormObject.Dock = DockStyle.Fill;
            DataPanelParam.Controls.Add(childFormObject);
            DataPanelParam.Tag = childFormObject;
            rightPanelParam.Dock = DockStyle.Right;
            childFormObject.Show();
        }

    }
}
