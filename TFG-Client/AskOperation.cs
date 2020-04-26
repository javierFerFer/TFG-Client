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

        public AskOperation(string subjectSelectedParam, Panel dataPanelParam, Panel rightPanelParam) {
            InitializeComponent();
            dataPanel = dataPanelParam;
            rightPanel = rightPanelParam;
            subjectSelected.Text += subjectSelectedParam;
        }

        private void buttonBack_Click(object sender, EventArgs e) {
            Utilities.openForm(new EmptyDataForm(), dataPanel, rightPanel);
        }

        private void nextButton_Click(object sender, EventArgs e) {
            if (checkBoxAdd.Checked || checkBoxModify.Checked) {
                Utilities.openForm(new AskTypeOfData(dataPanel, rightPanel, this), dataPanel, rightPanel);
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
    }
}
