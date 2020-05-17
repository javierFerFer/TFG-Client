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
    public partial class SelectNormalModel : Form {

        private Panel dataPanel;
        private Panel rightPanel;
        private Form beforeForm;
        private string subject;
        private string typeOfExam;
        private string idModelCreated;

        public SelectNormalModel(string typeOfExamParam, string subjectParam, Panel dataPanelParam, Panel rightPanelParam, Form beforeFormParam) {
            InitializeComponent();
            dataPanel = dataPanelParam;
            rightPanel = rightPanelParam;
            subject = subjectParam;
            typeOfExam = typeOfExamParam;
            beforeForm = beforeFormParam;
            ConnectionWithServer.setNewSelectNormalModel(this);
            showHideElements(false);

            string jsonMessageAddNewNormalModification = Utilities.generateSingleDataRequest("getAllNormalModels", subject);
            byte[] jSonObjectBytes = System.Text.Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageAddNewNormalModification, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
            ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
            // Envio de datos mediante flush
            ConnectionWithServer.ServerStream.Flush();

            typeOfDataPanel.Focus();
        }

        private void showHideElements(bool option) {
            labelWaitData.Visible = !option;
            buttonBack.Visible = option;
            flowLayoutPanelAllModels.Visible = option;
        }

        public void createAndShowModels(string [] allDataModelsParam) {
            buttonBack.Visible = true;
            labelWaitData.Visible = false;
            for (int i = 0; i < 15; i++) {
                for (int counterOfModels = 0; counterOfModels < allDataModelsParam.Length; counterOfModels += 4) {
                    ModelOfModels newModel = new ModelOfModels(allDataModelsParam[counterOfModels], allDataModelsParam[counterOfModels + 1], allDataModelsParam[counterOfModels + 2], allDataModelsParam[counterOfModels + 3]);
                    newModel.Tag = counterOfModels;
                    newModel.TopLevel = false;
                    flowLayoutPanelAllModels.Controls.Add(newModel);
                    newModel.Show();
                }
            }
            flowLayoutPanelAllModels.Visible = true;
        }

        public void showNothingMessage() {
            labelWaitData.Text = "No se ha encontrado ningún modelo perteneciente a este tema";
            buttonBack.Visible = true;
        }

        private void buttonBack_Click(object sender, EventArgs e) {
            typeOfDataPanel.Focus();
            Utilities.openForm(beforeForm, dataPanel, rightPanel);
        }

        private void nextButton_Click(object sender, EventArgs e) {

        }
    }
}
