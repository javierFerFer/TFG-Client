////////////////////////////////////////////////////////////////////////////////////////////////////
/// <file>  TFG-Client\AddNewQuestion.cs </file>
///
/// <copyright file="AddNewQuestion.cs" company="San José">
/// Copyright (c) 2020 San José. All rights reserved.
/// </copyright>
///
/// <summary>   
///             Imprementación de la clase AddNewQuestion.\n 
///             Implementation of the class.
///             </summary>
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TFG_Client {

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Clase AddNewQuestion, usada para procesar las peticiones de agregaciones de nuevas preguntas y/o temas.\n
    ///             AddNewQuestion class, this class is used to proccess all request of new questions and new themes.
    ///               </summary>
    ///
    /// <remarks>   Javier Fernández Fernández, 26/04/2020. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class AddNewQuestion : Form {

        private Panel dataPanel;
        private Panel rightPanel;
        private Form beforeForm;
        private string subject;
        private const string bannerComboBox = "Temas";
        private const string nothingToShow = "Ningún tema encontrado";

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor de la clase.\n
        ///             Constructor of the class.
        ///               </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 26/04/2020. </remarks>
        ///
        /// <param name="typeOfExamParam">  Tipo de examen.\n
        ///                                 Type of exam. </param>
        /// <param name="subjectSelectedParam"> Tema seleccionado.\n
        ///                                     Theme selected. </param>
        /// <param name="dataPanelParam">   Panel donde se muestran los datos.\n
        ///                                 Panel when program show all data. </param>
        /// <param name="rightPanelParam">  Panel de la derecha con las opciones de minimizar, cerrar...\n
        ///                                 Right panel with minize, close.... options</param>
        /// <param name="beforeFormParam">  Panel anterior, usado en caso de que el usuario haga click en el botón volver.\n
        ///                                 Before panel, this is used when user click on 'back' button. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AddNewQuestion(string typeOfExamParam, string subjectSelectedParam, Panel dataPanelParam, Panel rightPanelParam, Form beforeFormParam) {
            InitializeComponent();
            dataPanel = dataPanelParam;
            rightPanel = rightPanelParam;
            subjectSelectedParam = subjectSelectedParam.Replace("Asignatura: ", "");
            subject = subjectSelectedParam;
            subjectSelected.Text += subjectSelectedParam;
            labelRequestTypeOfQuestion.Text += typeOfExamParam;
            beforeForm = beforeFormParam;
            comboBoxOfThemes.Items.Add(bannerComboBox);
            comboBoxOfThemes.Visible = false;
            ConnectionWithServer.setNewQuestionFrom(this);
            typeOfDataPanel.Focus();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click sobre el botón 'back'.\n
        ///             Click event on back button. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 26/04/2020. </remarks>
        ///
        /// <param name="sender">   Objeto que activa el evento.\n
        ///                         Object of the event. </param>
        /// <param name="e">        Datos del evento.\n
        ///                         Event data. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void buttonBack_Click(object sender, EventArgs e) {
            typeOfDataPanel.Focus();
            bool userOption = Utilities.createWarningForm();
            if (userOption) {
                Utilities.openForm(beforeForm, dataPanel, rightPanel);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Abre el formulario correspondiente cuando la petición de agregación se procesa correctamente.\n
        ///             Open new form when this request is processed correctly. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 26/04/2020. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void openSuccessAddQuestionForm() {
            Utilities.openForm(new EmptyDataForm("Se ha enviado correctamente la petición de agregación al sistema"), dataPanel, rightPanel);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click sobre el botón next.\n
        ///             Event handler. Called by nextButton for click events. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 26/04/2020. </remarks>
        ///
        /// <param name="sender">   Objeto que activa el evento.\n 
        ///                         Object of the event. </param>
        /// <param name="e">        Datos del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void nextButton_Click(object sender, EventArgs e) {
            typeOfDataPanel.Focus();
            if (checkBoxNewTheme.Checked || checkBoxSelectedTheme.Checked) {
                if (textBoxNameOfTheme.Text == bannerComboBox || textBoxNameOfTheme.Text == nothingToShow) {
                    Utilities.customErrorInfo("Valores introducidos inválidos");
                } else {
                    if (checkBoxNewTheme.Checked) {
                        checkDataForNewTheme();
                    } else if (checkBoxSelectedTheme.Checked) {
                        checkDataForSelectedTheme();
                    }
                }
            } else {
                Utilities.customErrorInfo("No ha seleccionado ninguna opción referente al tema");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Comprueba que el usuario ha seleccionado un tema de la lista.\n
        ///             Check if user select a theme. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 26/04/2020. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void checkDataForSelectedTheme() {
            if (textBoxQuestion.Text.Trim().Length != 0 && textBoxQuestion.Text.Trim().Length >= 5) {
                if (comboBoxOfThemes.SelectedItem.ToString() != bannerComboBox && comboBoxOfThemes.SelectedItem.ToString() != nothingToShow) {
                    sendAlldataNameOfTheme(false);
                } else {
                    Utilities.customErrorInfo("No se ha seleccionado nigún tema de la lista");
                }
            } else {
                Utilities.customErrorInfo("La longitud de la pregunta que desea agregar es demasiado corta. \n" +
                                          "Debe tener al menos 5 caracteres.");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Si el tema es nuevo, realiza una petición al servidor para buscar que no exista ya un tema con ese nombre.
        ///             Si el tema es seleccionado, envía una petición para buscar que la pregunta no exista ya.\n
        ///             If the topic is new, it makes a request to the server to find that there is no longer a topic with that name.
        ///             If the topic is selected, send a request to find that the question does not already exist.</summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 26/04/2020. </remarks>
        ///
        /// <param name="option">   True = busca tema, false = busca pregunta.\n
        ///                         True = find theme, false = find question. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void sendAlldataNameOfTheme(bool option) {
            if (option) {
                // Buscar nombre del tema antes de agregarlo
                string jsonMessageGetThemes = Utilities.generateSingleDataRequest("findNameOfTheme", textBoxNameOfTheme.Text);
                byte[] jSonObjectBytes = Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageGetThemes, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
                ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
                // Envio de datos mediante flush
                ConnectionWithServer.ServerStream.Flush();
            } else {

                string jsonMessageGetThemes = Utilities.generateSingleDataRequest("selectedThemeQuestionAdd", textBoxQuestion.Text);
                byte[] jSonObjectBytes = Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageGetThemes, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
                ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
                // Envio de datos mediante flush
                ConnectionWithServer.ServerStream.Flush();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Comprueba que los datos del tema sean correctos.\n
        ///             Check if all data of theme are correct. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 26/04/2020. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void checkDataForNewTheme() {
            if (textBoxQuestion.Text.Trim().Length != 0 && textBoxQuestion.Text.Trim().Length >= 5) {
                if (textBoxNameOfTheme.Text.Trim().Length != 0 && textBoxNameOfTheme.Text.Trim().Length >= 5) {

                    sendAlldataNameOfTheme(true);

                    // Buscar nombre de la pregunta antes de enviar
                    string jsonMessageGetThemes = Utilities.generateSingleDataRequest("findQuestion", textBoxQuestion.Text);
                    byte[] jSonObjectBytes = Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageGetThemes, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
                    ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
                    // Envio de datos mediante flush
                    ConnectionWithServer.ServerStream.Flush();
                } else {
                    Utilities.customErrorInfo("La longitud del tema que desea agregar es demasiado corta. \n" +
                                              "Debe tener al menos 5 caracteres.");
                }
            } else {
                Utilities.customErrorInfo("La longitud de la pregunta que desea agregar es demasiado corta. \n" +
                                          "Debe tener al menos 5 caracteres.");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Petición de agregación de nuevo tema.\n
        ///             Request of add new theme. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 26/04/2020. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void addNewQuestionRequest() {
            string jsonMessageCreateTheme = Utilities.generateJsonObjectArrayString("insertNewTheme", new string[] { textBoxNameOfTheme.Text.Trim(), subject });
            byte[] jSonObjectBytes = Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageCreateTheme, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
            ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
            // Envio de datos mediante flush
            ConnectionWithServer.ServerStream.Flush();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Petición de agregación de nueva pregunta.\n
        ///             Request of add new question. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 26/04/2020. </remarks>
        ///
        /// <param name="optionParam">  True = tema seleccionado de la lista, false = nuevo tema.\n
        ///                             True = theme selected of list, false = new theme. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void addDataOfNewQuestionRequest(bool optionParam) {
            string jsonMessageCreateTheme = "";

            if (optionParam) {
                jsonMessageCreateTheme = Utilities.generateJsonObjectArrayString("insertNewQuestion", new string[] { textBoxQuestion.Text, comboBoxOfThemes.SelectedItem.ToString() });
            } else {
                jsonMessageCreateTheme = Utilities.generateJsonObjectArrayString("insertNewQuestion", new string[] { textBoxQuestion.Text, textBoxNameOfTheme.Text.Trim() });
            }

            byte[] jSonObjectBytes = Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageCreateTheme, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
            ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
            // Envio de datos mediante flush
            ConnectionWithServer.ServerStream.Flush();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de cambio de texto sobre la pregunta, verifica la longitud del mismo.\n
        ///             Event of text change, check if text is valid or not. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 26/04/2020. </remarks>
        ///
        /// <param name="sender">   Objeto que activa el evento.\n 
        ///                         Object of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void textBoxQuestion_TextChanged_1(object sender, EventArgs e) {
            try {
                if (textBoxQuestion.Text.Length > 230) {
                    if (textBoxQuestion.Text.Length == 231) {
                        textBoxQuestion.Text = textBoxQuestion.Text.Substring(0, textBoxQuestion.Text.Length - 1);
                        textBoxQuestion.Select(textBoxQuestion.Text.Length, 0);
                        Utilities.customErrorInfo("Se ha alcanzado el límite máximo de caracteres en la pregunta");
                    } else {
                        Utilities.customErrorInfo("El texto introducido supera el limite máximo de caracteres");
                        textBoxQuestion.Text = "";
                    }
                }
            } catch (Exception) { }

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de cambio sobre checkBox nuevo tema. comprueba si el checkBox está marcado o no.\n
        ///             Event of change about checkBox new theme. Check if this checkBox is check or not </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 27/05/2020. </remarks>
        ///
        /// <param name="sender">   Objeto que activa el evento.\n 
        ///                         Object of the event. </param>
        /// <param name="e">        Información sobre el evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void checkBoxNewTheme_CheckedChanged(object sender, EventArgs e) {
            if (checkBoxNewTheme.Checked) {
                checkBoxSelectedTheme.Checked = false;
                comboBoxOfThemes.Visible = false;
                textBoxNameOfTheme.Visible = true;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Evento de cambio sobre seleccionar tema, realiza una petición al servidor para obtener todos los temas de la asignatura seleccionada.\n
        /// Event of change about checkBox selected theme. This method does a request to get all themes of selected subject.
        /// </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 26/04/2020. </remarks>
        ///
        /// <param name="sender">   Objeto que activa el evento.\n
        ///                         Object of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void checkBoxSelectedTheme_CheckedChanged(object sender, EventArgs e) {
            if (checkBoxSelectedTheme.Checked) {
                // Petición de datos al servidor sobre los temas de la asignatura
                string jsonMessageGetThemes = Utilities.generateSingleDataRequest("getThemes", subject);
                byte[] jSonObjectBytes = Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageGetThemes, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
                ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
                // Envio de datos mediante flush
                ConnectionWithServer.ServerStream.Flush();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Rellena el listado de temas.\n
        ///             Fill all themes. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 26/04/2020. </remarks>
        ///
        /// <param name="allThemesNames">   Listado de nombres de los temas.\n
        ///                                 List of names of all themes. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void fillAllThemes(string[] allThemesNames) {

            // Limpieza del combobox para evitar errores
            comboBoxOfThemes.Items.Clear();
            comboBoxOfThemes.Items.Add(bannerComboBox);
            int indexComboBox;

            if (allThemesNames.Length != 0) {
                for (int themesCounter = 0; themesCounter < allThemesNames.Length; themesCounter++) {
                    comboBoxOfThemes.Items.Add(allThemesNames[themesCounter]);
                }
                indexComboBox = comboBoxOfThemes.FindString(bannerComboBox);
                comboBoxOfThemes.SelectedIndex = indexComboBox;
            } else {
                comboBoxOfThemes.Items.RemoveAt(0);
                comboBoxOfThemes.Items.Add(nothingToShow);
                indexComboBox = comboBoxOfThemes.FindString(nothingToShow);
                comboBoxOfThemes.SelectedIndex = indexComboBox;
            }


            checkBoxNewTheme.Checked = false;
            textBoxNameOfTheme.Visible = false;
            comboBoxOfThemes.Visible = true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de cambio de texto sobre el nombre del tema. Comprueba que los valores del nuevo tema son correctos.\n
        ///             Event of change text about theme text. Check if this text is correct or not. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 26/04/2020. </remarks>
        ///
        /// <param name="sender">   Objeto que activa el evento.\n
        ///                         Object of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void textBoxNameOfTheme_TextChanged(object sender, EventArgs e) {
            try {
                if (textBoxNameOfTheme.Text.Trim().Length != 0) {
                    string textToReplace = textBoxNameOfTheme.Text.Substring(0, 1).ToUpper();
                    textToReplace += textBoxNameOfTheme.Text.Substring(1, textBoxNameOfTheme.Text.Length - 1);
                    textBoxNameOfTheme.Text = textToReplace;
                    textBoxNameOfTheme.Select(textBoxNameOfTheme.Text.Length, 0);
                }
                if (textBoxNameOfTheme.Text.Trim().Length > 25) {
                    textBoxNameOfTheme.Text = textBoxNameOfTheme.Text.Substring(0, textBoxNameOfTheme.Text.Length - 1);
                    textBoxNameOfTheme.Select(textBoxNameOfTheme.Text.Length, 0);
                    Utilities.customErrorInfo("Se ha alcanzado el límite máximo de caracteres en el tema");
                }
            } catch (Exception) { }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de key press sobre el texto con el nombre del tema, evita que se presione la tecla ENTER.\n
        ///             Event of key press about text with the name of theme, avoid the user press ENTER. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 26/04/2020. </remarks>
        ///
        /// <param name="sender">   Objeto que activa el evento.\n 
        ///                         Object of the event. </param>
        /// <param name="e">        Información sobre la tecla presionada.\n
        ///                         Key press event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void textBoxNameOfTheme_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)13) {
                sendButton.PerformClick();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de tecla presionada, si es enter, la omite.\n
        ///             Event of key down press, if this key is ENTER, avoid. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 26/04/2020. </remarks>
        ///
        /// <param name="sender">   Objeto que activa el evento.\n 
        ///                         Object of the event. </param>
        /// <param name="e">        Información sobre la tecla presionada.\n
        ///                         Key event information.</param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void textBoxQuestion_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                e.SuppressKeyPress = true;
            }

            if (e.Control) {
                Utilities.customErrorInfoModificationNormal("No está permitido la función de copiar/pegar");
            }
        }
    }
}
