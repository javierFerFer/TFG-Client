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
    public partial class AskTypeData : Form {

        private Panel dataPanel;
        private Panel rightPanel;
        private Form beforeForm;
        // true = add selected, false = modify selected
        private bool selectedOption;

        public AskTypeData(Panel dataPanelParam, Panel rightPanelParam, Form beforeFormParam, bool addOrModifyOption) {
            InitializeComponent();
            dataPanel = dataPanelParam;
            rightPanel = rightPanelParam;
            beforeForm = beforeFormParam;
            selectedOption = addOrModifyOption;
        }

        private void buttonBack_Click(object sender, EventArgs e) {
            Utilities.openForm(beforeForm, dataPanel, rightPanel);
        }

        private void nextButton_Click(object sender, EventArgs e) {
            // true = add selected, false = modify
            AskOperation tempForm = (AskOperation)beforeForm;
            if (selectedOption) {
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
            } else {
                if (checkBoxNormal.Checked || checkBoxTest.Checked) {
                    if (checkBoxNormal.Checked) {
                        // Muestra panel con toda la lista de preguntas de tipo normal de la asignatura seleccionada
                        Utilities.openForm(new ListAllNormalQuestions("normal", tempForm.Subject, dataPanel, rightPanel), dataPanel, rightPanel);
                    } else { 
                        // Muestra panel con toda la lista de preguntas de tipo test de la asignatura seleccionada
                    }
                    //Utilities.openForm(new AskTypeOfData(dataPanel, rightPanel, this), dataPanel, rightPanel);
                } else {
                    Utilities.customErrorInfo("No ha seleccionado ninguna opción");
                }
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
