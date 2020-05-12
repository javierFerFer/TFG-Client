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
    public partial class AskOperation : Form {

        private Panel dataPanel;
        private Panel rightPanel;
        private string subject;


        public AskOperation(string subjectSelectedParam, Panel dataPanelParam, Panel rightPanelParam) {
            InitializeComponent();
            dataPanel = dataPanelParam;
            rightPanel = rightPanelParam;
            subjectSelected.Text += subjectSelectedParam;
            Subject = subjectSelectedParam;
            typeOfDataPanel.Focus();
        }

        private void buttonBack_Click(object sender, EventArgs e) {
            typeOfDataPanel.Focus();
            Utilities.openForm(new EmptyDataForm(), dataPanel, rightPanel);
        }

        private void nextButton_Click(object sender, EventArgs e) {
            typeOfDataPanel.Focus();
            if (checkBoxAdd.Checked || checkBoxModify.Checked) {
                if (checkBoxAdd.Checked) {
                    Utilities.openForm(new AskTypeData(dataPanel, rightPanel, this, true), dataPanel, rightPanel);
                } else {
                    Utilities.openForm(new AskTypeData(dataPanel, rightPanel, this, false), dataPanel, rightPanel);
                }
            } else {
                Utilities.customErrorInfo("No ha seleccionado ninguna opción");
            }
        }

        private void checkBoxModify_CheckedChanged(object sender, EventArgs e) {
            if (checkBoxModify.Checked) {
                checkBoxAdd.Checked = false;
            }
        }

        private void checkBoxAdd_CheckedChanged(object sender, EventArgs e) {
            if (checkBoxAdd.Checked) {
                checkBoxModify.Checked = false;
            }
        }

        public string Subject { get => subject; set => subject = value; }

        private void subjectSelected_Click(object sender, EventArgs e) {

        }

        private void labelAskTypeOfOperation_Click(object sender, EventArgs e) {

        }
    }
}
