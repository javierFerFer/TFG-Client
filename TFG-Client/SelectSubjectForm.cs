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
    public partial class SelectSubjectForm : Form {

        private Panel dataPanel;
        private Panel rightPanel;
        private Form beforeForm;
        private string subject;
        private string typeOfExam;
        private string idModelCreated;
        private const string bannerComboBox = "Seleccione un tema";
        private const string nothingToShow = "Ningún tema encontrado";

        public SelectSubjectForm(string typeOfExamParam, string subjectParam, Panel dataPanelParam, Panel rightPanelParam, Form beforeFormParam) {
            InitializeComponent();
            dataPanel = dataPanelParam;
            rightPanel = rightPanelParam;
            subject = subjectParam;
            subjectSelected.Text += subjectParam;
            labelRequestTypeOfExam.Text += typeOfExamParam;
            typeOfExam = typeOfExamParam;
            beforeForm = beforeFormParam;
            comboBoxOfThemes.Items.Add(bannerComboBox);
            ConnectionWithServer.setSelectedSUbjectForm(this);
            comboBoxNumberOfStudents.SelectedIndex = comboBoxNumberOfStudents.FindStringExact("1");
            showHideElements(false);

            string jsonMessageAddNewNormalModification = Utilities.generateSingleDataRequest("getAllThemesFromSignature", subject);
            byte[] jSonObjectBytes = System.Text.Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageAddNewNormalModification, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
            ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
            // Envio de datos mediante flush
            ConnectionWithServer.ServerStream.Flush();
        }

        private void showHideElements(bool option) {
            labelRequestTypeOfExam.Visible = option;
            subjectSelected.Visible = option;
            comboBoxOfThemes.Visible = option;
            buttonBack.Visible = option;
            sendButton.Visible = option;
            labelThemes.Visible = option;
            labelStudents.Visible = option;
            comboBoxNumberOfStudents.Visible = option;
            checkBoxSaveAsModel.Visible = option;

            labelWaitData.Visible = !option;
        }

        private void buttonBack_Click(object sender, EventArgs e) {
            Utilities.openForm(beforeForm, dataPanel, rightPanel);
        }

        private void nextButton_Click(object sender, EventArgs e) {
            // Open form formulario para crear examen tipo normal;
            if (comboBoxOfThemes.SelectedItem.ToString().Equals(bannerComboBox) || comboBoxOfThemes.SelectedItem.ToString().Equals(nothingToShow)) {
                Utilities.customErrorInfo("No se ha seleccionado tema");
            } else {
                if (checkBoxSaveAsModel.Checked) {
                    Utilities.openForm(new CreateNormalExam(typeOfExam, comboBoxOfThemes.SelectedItem.ToString(), comboBoxNumberOfStudents.SelectedItem.ToString(), dataPanel, rightPanel, this, true), dataPanel, rightPanel);
                } else {
                    Utilities.openForm(new CreateNormalExam(typeOfExam, comboBoxOfThemes.SelectedItem.ToString(), comboBoxNumberOfStudents.SelectedItem.ToString(), dataPanel, rightPanel, this, false), dataPanel, rightPanel);
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
                comboBoxNumberOfStudents.Enabled = false;
                comboBoxOfThemes.Enabled = false;
            }
        }
    }
}
