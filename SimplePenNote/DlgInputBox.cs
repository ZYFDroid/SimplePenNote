using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Launchkit_Backend
{
    public partial class DlgInputBox : Form
    {
        public DlgInputBox()
        {
            InitializeComponent();
        }

        private void txtText_TextChanged(object sender, EventArgs e)
        {
            TextBox ctl = (TextBox)sender;
            String str = ctl.Text;
            bool enterPressed = false;
            if (str.Contains("\r"))
            {
                str = str.Replace("\r","");
                enterPressed = true;
            }
            if (str.Contains("\n"))
            {
                str = str.Replace("\n", "");
                enterPressed = true;
            }

            btnOk.Enabled = str != "";

            if (enterPressed && btnOk.Enabled)
            {
                DialogResult = DialogResult.OK;
            }
            else {
                txtText.Text = str;
            }

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public static bool InputText(Form container, String title, String prompt, ref String content) {
            DlgInputBox dlg = new DlgInputBox();
            dlg.Text = title;
            dlg.lblMsg.Text = prompt;
            dlg.txtText.Text = content;
            if (dlg.ShowDialog(container) == DialogResult.OK) {
                content = dlg.txtText.Text;
                dlg.Dispose();
                return true;
            }
            dlg.Dispose();
            return false;
        }
    }
}
