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
    public partial class AskTypeDataChanges : Form {

        private Panel dataPanel;
        private Panel rightPanel;
        private Form beforeForm;

        private string emailUser;

        public AskTypeDataChanges(Panel dataPanelParam, Panel rightPanelParam, Form beforeFormParam, string emailUserParam) {
            InitializeComponent();
            dataPanel = dataPanelParam;
            rightPanel = rightPanelParam;
            beforeForm = beforeFormParam;
            emailUser = emailUserParam;
            showHideElements(false);
            ConnectionWithServer.LoginForm.AskTypeDataChangesObject1 = this;
            typeOfDataPanel.Focus();

            // Comprobación de permisos por parte del usuario
            string jsonString = Utilities.generateSingleDataRequest("checkPermissions", emailUser);

            byte[] jSonObjectBytes = Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonString, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));

            ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
            // Envio de datos mediante flush
            ConnectionWithServer.ServerStream.Flush();
        }

        public void createErrorCredentials() {
            Utilities.openForm(new EmptyDataForm("Usted no tiene permisos para revisar cambios"), dataPanel, rightPanel);
        }

        private void showHideElements(bool option) {
            labelAskTypeOfOperation.Visible = option;
            checkBoxTest.Visible = option;
            checkBoxNormal.Visible = option;
            buttonBack.Visible = option;
            nextButton.Visible = option;


            labelWaitVerification.Visible = !option;
        }

        private void buttonBack_Click(object sender, EventArgs e) {
            typeOfDataPanel.Focus();
            Utilities.openForm(beforeForm, dataPanel, rightPanel);
        }

        private void nextButton_Click(object sender, EventArgs e) {
            // true = add selected, false = modify
            typeOfDataPanel.Focus();
            AskOperation tempForm = (AskOperation)beforeForm;

                if (checkBoxNormal.Checked || checkBoxTest.Checked) {
                    if (checkBoxNormal.Checked) {
                        // Crear un menu para guardar una pregunta en base a la asignatura seleccionada
                        Utilities.openForm(new AddNewQuestion("normal", tempForm.subjectSelected.Text, dataPanel, rightPanel, this), dataPanel, rightPanel);
                    } else {
                        Utilities.openForm(new AddNewQuestionTypeTest("test", tempForm.subjectSelected.Text, dataPanel, rightPanel, this), dataPanel, rightPanel);
                    }
                } else {
                    Utilities.customErrorInfo("No ha seleccionado ninguna opción");
                }
            
        }

        private void checkBoxModify_CheckedChanged(object sender, EventArgs e) {
            if (checkBoxTest.Checked) {
                checkBoxNormal.Checked = false;
            }
        }

        private void checkBoxAdd_CheckedChanged(object sender, EventArgs e) {
            if (checkBoxNormal.Checked) {
                checkBoxTest.Checked = false;
            }
        }
    }
}
