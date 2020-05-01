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
    public partial class AddNewQuestion : Form {

        private Panel dataPanel;
        private Panel rightPanel;
        private Form beforeForm;
        private string subject;
        private const string bannerComboBox = "Temas";
        private const string nothingToShow = "Ningún tema encontrado";

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
        }

        private void buttonBack_Click(object sender, EventArgs e) {
            bool userOption = Utilities.createWarningForm();
            if (userOption) {
                Utilities.openForm(beforeForm, dataPanel, rightPanel);
            }
        }

        public void openSuccessAddQuestionForm() {
            Utilities.openForm(new EmptyDataForm("Se ha enviado correctamente la petición de agregación al sistema"), dataPanel, rightPanel);
        }

        private void nextButton_Click(object sender, EventArgs e) {
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

        public void addNewQuestionRequest() {
            string jsonMessageCreateTheme = Utilities.generateJsonObjectArrayString("insertNewTheme", new string[] { textBoxNameOfTheme.Text.Trim(), subject });
            byte[] jSonObjectBytes = Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageCreateTheme, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
            ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
            // Envio de datos mediante flush
            ConnectionWithServer.ServerStream.Flush();

            // AQUI, FALTA QUE EL SERVIDOR ENVIE UN MENSAJE DE QUE SE AGREGÓ CORRECTAMENTE EL TEMA A LA ASIGNATURA Y ENVIO DEL CLIENTE AL SERVIDOR DE LA PREGUNTA A AGREGAR

        }

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

        private void textBoxQuestion_TextChanged_1(object sender, EventArgs e) {
            if (textBoxQuestion.Text.Length > 90) {
                if (textBoxQuestion.Text.Length == 91) {
                    textBoxQuestion.Text = textBoxQuestion.Text.Substring(0, textBoxQuestion.Text.Length - 1);
                    textBoxQuestion.Select(textBoxQuestion.Text.Length, 0);
                    Utilities.customErrorInfo("Se ha alcanzado el límite máximo de caracteres en la pregunta");
                    MessageBox.Show(textBoxQuestion.Text.Length.ToString());
                } else {
                    Utilities.customErrorInfo("El texto introducido supera el limite máximo de caracteres");
                    textBoxQuestion.Text = "";
                }
            }
        }

        private void checkBoxNewTheme_CheckedChanged(object sender, EventArgs e) {
            if (checkBoxNewTheme.Checked) {
                checkBoxSelectedTheme.Checked = false;
                comboBoxOfThemes.Visible = false;
                textBoxNameOfTheme.Visible = true;
            }
        }

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

        private void textBoxQuestion_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)13) {
                sendButton.PerformClick();
            }
        }

        private void textBoxNameOfTheme_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)13) {
                sendButton.PerformClick();
            }
        }
    }
}
