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
        const string bannerComboBox = "Temas";

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
        }

        private void buttonBack_Click(object sender, EventArgs e) {
            Utilities.openForm(beforeForm, dataPanel, rightPanel);
        }

        private void nextButton_Click(object sender, EventArgs e) {
            if (true) {
                // envio de petición al servidor
            } else {
                Utilities.customErrorInfo("No ha seleccionado ninguna opción");
            }
        }

        private void textBoxQuestion_TextChanged(object sender, EventArgs e) {
            MessageBox.Show(textBoxQuestion.Text.Length.ToString());
        }

        private void textBoxQuestion_TextChanged_1(object sender, EventArgs e) {
            if (textBoxQuestion.Text.Length > 50) {
                textBoxQuestion.Text = textBoxQuestion.Text.Substring(0, textBoxQuestion.Text.Length-1);
                textBoxQuestion.Select(textBoxQuestion.Text.Length, 0);
                Utilities.customErrorInfo("Se ha alcanzado el límite máximo de caracteres");
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
                ConnectionWithServer.setNewQuestionFrom(this);

                string jsonMessageGetThemes = Utilities.generateSingleDataRequest("getThemes", subject);
                byte[] jSonObjectBytes = Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageGetThemes, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
                ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
                // Envio de datos mediante flush
                ConnectionWithServer.ServerStream.Flush();
            }
        }

        public void fillAllThemes(string [] allThemesNames) {

            // Limpieza del combobox para evitar errores
            comboBoxOfThemes.Items.Clear();
            comboBoxOfThemes.Items.Add(bannerComboBox);

            for (int themesCounter = 0; themesCounter < allThemesNames.Length; themesCounter++) {
                comboBoxOfThemes.Items.Add(allThemesNames[themesCounter]);
            }

            int indexComboBox = comboBoxOfThemes.FindString(bannerComboBox);
            comboBoxOfThemes.SelectedIndex = indexComboBox;

            checkBoxNewTheme.Checked = false;
            textBoxNameOfTheme.Visible = false;
            comboBoxOfThemes.Visible = true;
        }
    }
}
