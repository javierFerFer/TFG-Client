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
    public partial class AskTypeOfData : Form {

        private Panel dataPanel;
        private Panel rightPanel;
        private Form beforePanel;

        public AskTypeOfData(Panel dataPanelParam, Panel rightPanelParam, Form beforePanelParam) {
            InitializeComponent();
            dataPanel = dataPanelParam;
            rightPanel = rightPanelParam;
            beforePanel = beforePanelParam;
        }

        private void buttonBack_Click(object sender, EventArgs e) {
            Utilities.openForm(beforePanel, dataPanel, rightPanel);
        }

        private void nextButton_Click(object sender, EventArgs e) {
            if (checkBoxNormal.Checked || checkBoxTest.Checked) {

            } else {
                Utilities.customErrorInfo("No ha seleccionado ninguna opción");
            }
        }

        private void checkBoxTest_CheckedChanged(object sender, EventArgs e) {
            if (checkBoxTest.Checked) {
                checkBoxNormal.Checked = false;
            }
        }

        private void checkBoxNormal_CheckedChanged(object sender, EventArgs e) {
            if (checkBoxNormal.Checked) {
                checkBoxTest.Checked = false;
            }
        }
    }
}
