using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TFG_Client {
    public partial class SelectSubjectFormModels : Form {

        private Panel dataPanel;
        private Panel rightPanel;
        private Form beforeForm;
        private string subject;
        private string typeOfExam;
        private string idModelCreated;
        private const string bannerComboBox = "Seleccione un tema";
        private const string nothingToShow = "Ningún tema encontrado";

        public SelectSubjectFormModels(string typeOfExamParam, string subjectParam, Panel dataPanelParam, Panel rightPanelParam, Form beforeFormParam) {
            InitializeComponent();
            dataPanel = dataPanelParam;
            rightPanel = rightPanelParam;
            subject = subjectParam;
            subjectSelected.Text += subjectParam;
            labelRequestTypeOfExam.Text += typeOfExamParam;
            typeOfExam = typeOfExamParam;
            beforeForm = beforeFormParam;
            comboBoxOfThemes.Items.Add(bannerComboBox);
            ConnectionWithServer.setNewSelectSubjectFormModels(this);
            showHideElements(false);

            string jsonMessageAddNewNormalModification = Utilities.generateSingleDataRequest("getAllModelsThemesFromSignature", subject);
            byte[] jSonObjectBytes = System.Text.Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageAddNewNormalModification, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
            ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
            // Envio de datos mediante flush
            ConnectionWithServer.ServerStream.Flush();

            typeOfDataPanel.Focus();
        }

        private void showHideElements(bool option) {
            labelRequestTypeOfExam.Visible = option;
            subjectSelected.Visible = option;
            comboBoxOfThemes.Visible = option;
            buttonBack.Visible = option;
            sendButton.Visible = option;
            labelThemes.Visible = option;

            labelWaitData.Visible = !option;
        }

        private void buttonBack_Click(object sender, EventArgs e) {
            typeOfDataPanel.Focus();
            Utilities.openForm(beforeForm, dataPanel, rightPanel);
        }

        private void nextButton_Click(object sender, EventArgs e) {
            // Open form formulario para crear examen tipo normal;
            typeOfDataPanel.Focus();
            if (comboBoxOfThemes.SelectedItem.ToString().Equals(bannerComboBox) || comboBoxOfThemes.SelectedItem.ToString().Equals(nothingToShow)) {
                Utilities.customErrorInfo("No se ha seleccionado tema");
            } else {
                if (typeOfExam.Equals("normal")) {
                    Utilities.openForm(new SelectNormalModel(typeOfExam, comboBoxOfThemes.SelectedItem.ToString(), dataPanel, rightPanel, this), dataPanel, rightPanel);
                } else {
                    // Creación de examen tipo test
                    //Utilities.openForm(new CreateTestExam(typeOfExam, comboBoxOfThemes.SelectedItem.ToString(), dataPanel, rightPanel, this, true), dataPanel, rightPanel);
                }
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
                showHideElements(true);
            } else {
                comboBoxOfThemes.Items.RemoveAt(0);
                comboBoxOfThemes.Items.Add(nothingToShow);
                indexComboBox = comboBoxOfThemes.FindString(nothingToShow);
                comboBoxOfThemes.SelectedIndex = indexComboBox;
                showHideElements(true);
                sendButton.Visible = false;
                comboBoxOfThemes.Enabled = false;
            }
        }
    }
}
