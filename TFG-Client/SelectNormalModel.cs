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

            if (typeOfExam == "normal") {
                string jsonMessageAddNewNormalModification = Utilities.generateSingleDataRequest("getAllNormalModels", subject);
                byte[] jSonObjectBytes = System.Text.Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageAddNewNormalModification, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
                ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
                // Envio de datos mediante flush
                ConnectionWithServer.ServerStream.Flush();
            } else {
                string jsonMessageAddNewNormalModification = Utilities.generateSingleDataRequest("getAllTestModels", subject);
                byte[] jSonObjectBytes = System.Text.Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageAddNewNormalModification, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
                ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
                // Envio de datos mediante flush
                ConnectionWithServer.ServerStream.Flush();
            }
            

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
            if (typeOfExam == "normal") {
                for (int counterOfModels = 0; counterOfModels < allDataModelsParam.Length; counterOfModels += 4) {
                    ModelOfModels newModel = new ModelOfModels(allDataModelsParam[counterOfModels], allDataModelsParam[counterOfModels + 1], allDataModelsParam[counterOfModels + 2], allDataModelsParam[counterOfModels + 3], true);
                    newModel.Tag = counterOfModels;
                    newModel.TopLevel = false;
                    flowLayoutPanelAllModels.Controls.Add(newModel);
                    newModel.Show();
                }
            } else {
                for (int counterOfModels = 0; counterOfModels < allDataModelsParam.Length; counterOfModels += 4) {
                    ModelOfModels newModel = new ModelOfModels(allDataModelsParam[counterOfModels], allDataModelsParam[counterOfModels + 1], allDataModelsParam[counterOfModels + 2], allDataModelsParam[counterOfModels + 3], false);
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


        public async void createPopUpMessage(string[] allDataParam) {
            if (typeOfExam == "normal") {
                await Task.Run(() => { Utilities.createPopUpWithAllQuestions(allDataParam, dataPanel, rightPanel, subject, true); });
            } else {
                await Task.Run(() => { Utilities.createPopUpWithAllQuestions(allDataParam, dataPanel, rightPanel, subject, false); });
            }

        }

        private void buttonBack_Click(object sender, EventArgs e) {
            typeOfDataPanel.Focus();
            Utilities.openForm(beforeForm, dataPanel, rightPanel);
        }
    }
}
