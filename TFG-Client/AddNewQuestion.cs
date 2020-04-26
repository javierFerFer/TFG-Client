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

        public AddNewQuestion(string typeOfExamParam, string subjectSelectedParam, Panel dataPanelParam, Panel rightPanelParam, Form beforeFormParam) {
            InitializeComponent();
            dataPanel = dataPanelParam;
            rightPanel = rightPanelParam;
            subjectSelected.Text += subjectSelectedParam;
            labelRequestTypeOfQuestion.Text += typeOfExamParam;
            beforeForm = beforeFormParam;
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
    }
}
