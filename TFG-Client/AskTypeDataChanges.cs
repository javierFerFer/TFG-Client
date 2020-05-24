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
            labelWaitVerification.Text = "Usted no tiene los credenciales necesarios \n" +
                                         "para acceder a esta sección";
        }

        public void showHideElements(bool option) {
            labelAskTypeOfOperation.Visible = option;
            checkBoxTest.Visible = option;
            checkBoxNormal.Visible = option;
            buttonBack.Visible = option;
            nextButton.Visible = option;


            labelWaitVerification.Visible = !option;
        }

        private void buttonBack_Click(object sender, EventArgs e) {
            typeOfDataPanel.Focus();
            Utilities.openForm(new EmptyDataForm(), dataPanel, rightPanel);
        }

        private void nextButton_Click(object sender, EventArgs e) {
            // true = add selected, false = modify
            typeOfDataPanel.Focus();

                if (checkBoxNormal.Checked || checkBoxTest.Checked) {
                    if (checkBoxNormal.Checked) {
                    // Listado de preguntas de tipo normal con su correspondiente modificación pendiente
                    Utilities.openForm(new ListAllNormalQuestionsModifications(dataPanel, rightPanel, this), dataPanel, rightPanel);

                    } else {
                    // Listado de preguntas de tipo test con su correspondiente modificación pendiente
                    Utilities.openForm(new ListAllTestQuestionsModifications(dataPanel, rightPanel, this), dataPanel, rightPanel);
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
