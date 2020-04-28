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
    public partial class EmptyDataForm : Form {
        public EmptyDataForm() {
            InitializeComponent();
        }
        public EmptyDataForm(string messageParam) {
            InitializeComponent();
            emptyMessage.Text = messageParam;
        }
    }
}
