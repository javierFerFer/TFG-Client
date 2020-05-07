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
    public partial class AskTypeDataNewExam : Form {

        private Panel dataPanel;
        private Panel rightPanel;
        private Form beforeForm;
        private string subjectSelected;

        public AskTypeDataNewExam(Panel dataPanelParam, Panel rightPanelParam, Form beforeFormParam, string subjectSelectedParam) {
            InitializeComponent();
            dataPanel = dataPanelParam;
            rightPanel = rightPanelParam;
            beforeForm = beforeFormParam;
            subjectSelected = subjectSelectedParam;
            labelSelectedSubject.Text += subjectSelected;
        }

        private void buttonBack_Click(object sender, EventArgs e) {
            Utilities.openForm(beforeForm, dataPanel, rightPanel);
        }

        private void nextButton_Click(object sender, EventArgs e) {
            if (checkBoxNormal.Checked || checkBoxTest.Checked) {
                if (checkBoxTest.Checked) {
                    // Mostrar formulario para selección de asignatura

                } else {
                    // Formulario para selección de asignatura
                    Utilities.openForm(new SelectSubjectForm("normal", subjectSelected, dataPanel, rightPanel, this), dataPanel, rightPanel);
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
