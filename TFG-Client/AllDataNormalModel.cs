using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TFG_Client {
    public partial class AllDataNormalModel : Form {

        private Panel dataPanel;
        private Panel rightPanel;
        private Form beforeForm;
        private string subject;
        private string numberOfAlumns;
        private string idModel;
        private ArrayList allQuestionData;

        public AllDataNormalModel(string typeOfExamParam, string subjectSelectedParam, string numberOfAlumnsParam , ArrayList allQuestionDataParam , Panel dataPanelParam, Panel rightPanelParam, Form beforeFormParam) {
            InitializeComponent();
            dataPanel = dataPanelParam;
            rightPanel = rightPanelParam;
            subject = subjectSelectedParam;
            typeOfModel.Text += typeOfExamParam;
            beforeForm = beforeFormParam;
            numberOfAlumns = numberOfAlumnsParam;
            allQuestionData = allQuestionDataParam;
            ConnectionWithServer.setAllDataNormalMoel(this);
        }

        private void buttonBack_Click(object sender, EventArgs e) {
            bool userOption = Utilities.createWarningForm();
            if (userOption) {
                Utilities.openForm(beforeForm, dataPanel, rightPanel);
            }
        }

        public void openSuccessSaveNormalExamAsModel() {
            Utilities.openForm(new EmptyDataForm("Se ha enviado correctamente la petición de agregación al sistema"), dataPanel, rightPanel);
        }

        private void nextButton_Click(object sender, EventArgs e) {
            if ((textBoxNameOfModel.Text.Length != 0 && textBoxDescription.Text.Length != 0) && (textBoxNameOfModel.Text.Length >= 5 && textBoxDescription.Text.Length >= 5)) {
                // Comprobación de que el nombre del modelo no exista ya antes de crearlo
                // Buscar nombre de la pregunta antes de enviar
                string jsonMessageGetThemes = Utilities.generateSingleDataRequest("findNameNormalModel", textBoxNameOfModel.Text);
                byte[] jSonObjectBytes = Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageGetThemes, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
                ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
                // Envio de datos mediante flush
                ConnectionWithServer.ServerStream.Flush();
            } else {
                if (textBoxNameOfModel.Text.Length == 0 || textBoxNameOfModel.Text.Length < 5) {
                    Utilities.customErrorInfo("La longitud del nombre del modelo debe tener al menos 5 caracteres");
                } else if (textBoxDescription.Text.Length == 0 || textBoxDescription.Text.Length < 5) {
                    Utilities.customErrorInfo("La longitud de la descripción del modelo debe tener al menos 5 caracteres");
                }
            }
        }

        public void generateExamRequest(string idModelParam) {
            idModel = idModelParam;
            Utilities.openForm(new EmptyDataForm("Se ha guardado correctamente el modelo en el servidor.\n Generando examen..."), dataPanel, rightPanel);
            
            // Copia del array

            string[] allData = new string[allQuestionData.Count + 1 ];
            allData[0] = idModel;
            string[] tempArray = (string[])allQuestionData.ToArray(typeof(string));
            tempArray.CopyTo(allData, 1);

            string jsonMessageGetThemes = Utilities.generateJsonObjectArrayString("updateAllNormalQuestionsNewNormalModel", allData);
            byte[] jSonObjectBytes = Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageGetThemes, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
            ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
            // Envio de datos mediante flush
            ConnectionWithServer.ServerStream.Flush();

        }

        private void textBoxQuestion_TextChanged_1(object sender, EventArgs e) {
            try {
                if (textBoxDescription.Text.Length > 120) {
                    if (textBoxDescription.Text.Length == 121) {
                        textBoxDescription.Text = textBoxDescription.Text.Substring(0, textBoxDescription.Text.Length - 1);
                        textBoxDescription.Select(textBoxDescription.Text.Length, 0);
                        Utilities.customErrorInfo("Se ha alcanzado el límite máximo de caracteres en la descripción");
                    } else {
                        Utilities.customErrorInfo("El texto introducido supera el limite máximo de caracteres");
                        textBoxDescription.Text = "";
                    }
                }
            } catch (Exception) {}
            
        }


        private void textBoxNameOfTheme_TextChanged(object sender, EventArgs e) {
            try {
                if (textBoxNameOfModel.Text.Trim().Length != 0) {
                    string textToReplace = textBoxNameOfModel.Text.Substring(0, 1).ToUpper();
                    textToReplace += textBoxNameOfModel.Text.Substring(1, textBoxNameOfModel.Text.Length - 1);
                    textBoxNameOfModel.Text = textToReplace;
                    textBoxNameOfModel.Select(textBoxNameOfModel.Text.Length, 0);
                }
                if (textBoxNameOfModel.Text.Trim().Length > 40) {
                    textBoxNameOfModel.Text = textBoxNameOfModel.Text.Substring(0, textBoxNameOfModel.Text.Length - 1);
                    textBoxNameOfModel.Select(textBoxNameOfModel.Text.Length, 0);
                    Utilities.customErrorInfo("Se ha alcanzado el límite máximo de caracteres en el título del modelo");
                }
            } catch (Exception) {}
        }


        private void textBoxNameOfTheme_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)13) {
                sendButton.PerformClick();
            }
        }

        private void textBoxQuestion_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                e.SuppressKeyPress = true;
            }

            if (e.Control) {
                Utilities.customErrorInfoModificationNormal("No está permitido la función de copiar/pegar");
            }
        }

        private void textBoxNameOfModel_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                e.SuppressKeyPress = true;
            }

            if (e.Control) {
                Utilities.customErrorInfoModificationNormal("No está permitido la función de copiar/pegar");
            }
        }

        public void generateErrorMessage() {
            Utilities.openForm(new EmptyDataForm("Se produjo un error al intentar generar el examen, contacte con el administrador"), dataPanel, rightPanel);

        }

        public void createNormalModelRequest() {
            // Petición de creación del modelo
            string jsonMessageGetThemes = Utilities.generateJsonObjectArrayString("createNormalModel", new string[] { textBoxNameOfModel.Text, textBoxDescription.Text , subject , ConnectionWithServer.EmailUser});
            byte[] jSonObjectBytes = Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageGetThemes, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
            ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
            // Envio de datos mediante flush
            ConnectionWithServer.ServerStream.Flush();
        }

        public void generateFilesExam() {
            // Petición de creación del fichero examen
            allQuestionData.Add("pipóasñ?¿ÑaaÓ");
            string[] tempArray = (string[])allQuestionData.ToArray(typeof(string));
            string jsonMessageGetThemes = Utilities.generateJsonObjectArrayString("createNormalExamFiles", tempArray);
            MessageBox.Show(jsonMessageGetThemes);
            byte[] jSonObjectBytes = Encoding.ASCII.GetBytes(Utilities.Encrypt(jsonMessageGetThemes, ConnectionWithServer.EncryptKey, ConnectionWithServer.IvString));
            ConnectionWithServer.ServerStream.Write(jSonObjectBytes, 0, jSonObjectBytes.Length);
            // Envio de datos mediante flush
            ConnectionWithServer.ServerStream.Flush();
        }
    }
}
