////////////////////////////////////////////////////////////////////////////////////////////////////
/// <file>  TFG-Client\AddNewQuestionTypeTest.cs </file>
///
/// <copyright file="AddNewQuestionTypeTest.cs" company="San José">
/// Copyright (c) 2020 San José. All rights reserved.
/// </copyright>
///
/// <summary>   Implementación de la clase AddNewQuestionTypeTest.\n
///             Implements the add new question type test class. </summary>
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
    /// <summary>   Permite agregar preguntas tipo test al sistema.\n
    ///             Allow to add new test questions. </summary>
    ///
    /// <remarks>   Javier Fernández Fernández, 29/04/2020. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class AddNewQuestionTypeTest : Form {

        private Panel dataPanel;
        private Panel rightPanel;
        private Form beforeForm;
        private string subject;
        private const string bannerComboBox = "Temas";
        private const string nothingToShow = "Ningún tema encontrado";

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor de la clase.\n
        ///             Constructor of the class </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 29/04/2020. </remarks>
        ///
        /// <param name="typeOfExamParam">      Tipo de examen.\n
        ///                                     Type of exam. </param>
        /// <param name="subjectSelectedParam"> tema seleccionado.\n
        ///                                     Selected theme. </param>
        /// <param name="dataPanelParam">       Panel donde se muestran los datos.\n
        ///                                     Panel where program show all data. </param>
        /// <param name="rightPanelParam">      Panel de la derecha del programa.\n
        ///                                     Right panel. </param>
        /// <param name="beforeFormParam">      Panel anterior.\n
        ///                                     Before panel. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AddNewQuestionTypeTest(string typeOfExamParam, string subjectSelectedParam, Panel dataPanelParam, Panel rightPanelParam, Form beforeFormParam) {
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
            ConnectionWithServer.setNewQuestionFormTestType(this);
            comboBoxCorrectAnswer.SelectedIndex = comboBoxCorrectAnswer.FindStringExact("A");
            typeOfDataPanel.Focus();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click sobre el botón volver.\n
        ///             Event click about back button. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 29/04/2020. </remarks>
        ///
        /// <param name="sender">   Objeto del evento.\n
        ///                         Source of the event.</param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void buttonBack_Click(object sender, EventArgs e) {
            typeOfDataPanel.Focus();
            bool userOption = Utilities.createWarningForm();
            if (userOption) {
                Utilities.openForm(beforeForm, dataPanel, rightPanel);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Abre un nuevo formulario cuando se procesa correctamente la petición de agregación de la pregunta al sistema.\n
        ///             Open new form when the request is insert is proccessed successfully </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 29/04/2020. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void openSuccessAddQuestionForm() {
            Utilities.openForm(new EmptyDataForm("Se ha enviado correctamente la petición de agregación al sistema"), dataPanel, rightPanel);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de click sobre el botón siguiente.\n
        ///             Click event about next button</summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 29/04/2020. </remarks>
        ///
        /// <param name="sender">   Objeto del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void nextButton_Click(object sender, EventArgs e) {
            typeOfDataPanel.Focus();
            if (checkBoxNewTheme.Checked || checkBoxSelectedTheme.Checked) {
                if (textBoxNameOfTheme.Text == bannerComboBox || textBoxNameOfTheme.Text == nothingToShow) {
                    Utilities.customErrorInfo("Valores introducidos inválidos");
                } else {
                    if (checkBoxNewTheme.Checked) {
                        if (textBox_A_answer.Text.Trim().Length < 5 || textBox_A_answer.Text.Trim().Length == 0 || textBox_A_answer.Text.Trim().Length > 45) {
                            Utilities.createCustomErrorTestMessage("A");
                        } else if (textBox_B_answer.Text.Trim().Length < 5 || textBox_B_answer.Text.Trim().Length == 0 || textBox_B_answer.Text.Trim().Length > 45) {
                            Utilities.createCustomErrorTestMessage("B");
                        } else if (textBox_C_answer.Text.Trim().Length < 5 || textBox_C_answer.Text.Trim().Length == 0 || textBox_C_answer.Text.Trim().Length > 45) {
                            Utilities.createCustomErrorTestMessage("C");
                        } else if (textBox_D_answer.Text.Trim().Length < 5 || textBox_D_answer.Text.Trim().Length == 0 || textBox_D_answer.Text.Trim().Length > 45) {
                            Utilities.createCustomErrorTestMessage("D");
                        } else {
                            checkDataForNewTheme();
                        }

                    } else if (checkBoxSelectedTheme.Checked) {
                        checkDataForSelectedTheme();
                    }
                }
            } else {
                Utilities.customErrorInfo("No ha seleccionado ninguna opción referente al tema");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Comprueba los datos del tema seleccionado.\n
        ///             Check all data of selected theme. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 29/04/2020. </remarks>
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
        /// <summary>   Envia los datos al servidor sobre el nuevo tema.\n
        ///             Send all data of new theme to the server </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 29/04/2020. </remarks>
        ///
        /// <param name="option">   True = tema seleccionado, false = pregunta a insertar.\n
        ///                         True = selected theme, false = question to insert</param>
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

                string jsonMessageGetThemes = Utilities.generateSingleDataRequest("selectedTestThemeQuestionAdd", textBoxQuestion.Text);
                byte[] jSonObjectBytes = Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageGetThemes, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
                ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
                // Envio de datos mediante flush
                ConnectionWithServer.ServerStream.Flush();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Comprueba si el nuevo tema es válido.\n
        ///             Check if new theme is valid or not </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 29/04/2020. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void checkDataForNewTheme() {
            if (textBoxQuestion.Text.Trim().Length != 0 && textBoxQuestion.Text.Trim().Length >= 5) {
                if (textBoxNameOfTheme.Text.Trim().Length != 0 && textBoxNameOfTheme.Text.Trim().Length >= 5) {

                    sendAlldataNameOfTheme(true);

                    // Buscar nombre de la pregunta antes de enviar
                    string jsonMessageGetThemes = Utilities.generateSingleDataRequest("findQuestionTest", textBoxQuestion.Text);
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
        /// <summary>   Petición de agregación del nuevo tema al sistema.\n
        ///             Add new theme request. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 29/04/2020. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void addNewQuestionRequest() {
            string jsonMessageCreateTheme = Utilities.generateJsonObjectArrayString("insertTestNewTheme", new string[] { textBoxNameOfTheme.Text.Trim(), subject });
            byte[] jSonObjectBytes = Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageCreateTheme, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
            ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
            // Envio de datos mediante flush
            ConnectionWithServer.ServerStream.Flush();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Petición de agregación de la pregunta de tipo test.\n
        ///             Add new test question request. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 29/04/2020. </remarks>
        ///
        /// <param name="optionParam">  True = inserta pregunta en el tema seleccionado, false = inserta pregunta en el nuevo tema creado.\n
        ///                             True = insert question into selected theme, false = insert question into new theme. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void addDataOfNewQuestionRequest(bool optionParam) {
            string jsonMessageCreateTheme = "";
            if (optionParam) {
                jsonMessageCreateTheme = Utilities.generateJsonObjectArrayString("insertNewTestQuestion", new string[] { textBoxQuestion.Text, textBox_A_answer.Text, textBox_B_answer.Text, textBox_C_answer.Text, textBox_D_answer.Text, comboBoxCorrectAnswer.SelectedItem.ToString(), comboBoxOfThemes.SelectedItem.ToString() });
            } else {
                jsonMessageCreateTheme = Utilities.generateJsonObjectArrayString("insertNewTestQuestion", new string[] { textBoxQuestion.Text, textBox_A_answer.Text, textBox_B_answer.Text, textBox_C_answer.Text, textBox_D_answer.Text, comboBoxCorrectAnswer.SelectedItem.ToString(), textBoxNameOfTheme.Text.Trim() });
            }

            byte[] jSonObjectBytes = Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageCreateTheme, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
            ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
            // Envio de datos mediante flush
            ConnectionWithServer.ServerStream.Flush();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de cambio de texto sobre el texto de la pregunta, comprueba si la misma es valida o no.\n
        ///             Event of text change about text question, check if this question is valid or not </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 29/04/2020. </remarks>
        ///
        /// <param name="sender">   Objeto del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void textBoxQuestion_TextChanged_1(object sender, EventArgs e) {
            if (textBoxQuestion.Text.Length > 45) {
                if (textBoxQuestion.Text.Length == 46) {
                    textBoxQuestion.Text = textBoxQuestion.Text.Substring(0, textBoxQuestion.Text.Length - 1);
                    textBoxQuestion.Select(textBoxQuestion.Text.Length, 0);
                    Utilities.customErrorInfo("Se ha alcanzado el límite máximo de caracteres en la pregunta");
                } else {
                    Utilities.customErrorInfo("El texto introducido supera el limite máximo de caracteres");
                    textBoxQuestion.Text = "";
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de cambio sobre el checkBox nuevo tema, comprueba si el mismo está marcado o no.\n
        ///             Event of status change about new theme checkBox, check if this checkBox is check or not. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 29/04/2020. </remarks>
        ///
        /// <param name="sender">   Objeto del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento.\n
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
        /// Evento de cambio sobre el checkBox de tema seleccionado, comprueba si el mismo está marcado o no.\n
        /// Event of status change about selected theme checkBox, check if this checkBox is check or not.
        /// </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 29/04/2020. </remarks>
        ///
        /// <param name="sender">   Objeto del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void checkBoxSelectedTheme_CheckedChanged(object sender, EventArgs e) {
            if (checkBoxSelectedTheme.Checked) {
                // Petición de datos al servidor sobre los temas de la asignatura
                string jsonMessageGetThemes = Utilities.generateSingleDataRequest("getThemeForTest", subject);
                byte[] jSonObjectBytes = Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageGetThemes, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
                ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
                // Envio de datos mediante flush
                ConnectionWithServer.ServerStream.Flush();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Rellena el listado de temas con los temas recibidos por parámetro.\n
        ///             Fill all themes. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 29/04/2020. </remarks>
        ///
        /// <param name="allThemesNames">   Lista de todos los temas.\n
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
        /// <summary>   Evento de cambio de texto sobre el nombre del tema, comprueba si el mismo es válido o no.\n
        ///             Event of text change, check if this text is valid or not. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 29/04/2020. </remarks>
        ///
        /// <param name="sender">   Objeto del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento.\n
        ///                         Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void textBoxNameOfTheme_TextChanged(object sender, EventArgs e) {
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
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   evento de key press sobre el texto de la pregunta. Comprueba si se ha pulsado el ENTER.\n
        ///             Event of key press about question text. Check if the user presss ENTER key. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 29/04/2020. </remarks>
        ///
        /// <param name="sender">   Objeto del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento de key press.\n
        ///                         Key press event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void textBoxQuestion_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)13) {
                sendButton.PerformClick();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento de key press sobre el texto del nombre del tema. Comprueba si se ha pulsado ENTER.\n
        ///             Event of key press about name of theme text. Check if the user press ENTER key. </summary>
        ///
        /// <remarks>   Javier Fernández Fernández, 29/04/2020. </remarks>
        ///
        /// <param name="sender">   Objeto del evento.\n 
        ///                         Source of the event. </param>
        /// <param name="e">        Información del evento de key press.\n
        ///                         Key press event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void textBoxNameOfTheme_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)13) {
                sendButton.PerformClick();
            }
        }
    }
}
