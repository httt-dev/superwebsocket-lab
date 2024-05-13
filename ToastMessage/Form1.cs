using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToastMessage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }

        private void btnSuccess_Click(object sender, EventArgs e)
        {
            this.Alert("Success msg" , Form_Alert.enmType.Success);
        }

        public void ShowToast(string type , string message)
        {
            ToastForm toastForm = new ToastForm(type, message);

            toastForm.Show();
        }
        private void btnInfo_Click(object sender, EventArgs e)
        {
            ShowToast("INFO", "This is a information message");
        }
    }
}
