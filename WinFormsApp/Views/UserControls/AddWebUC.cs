using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace WinFormsApp.Views.UserControls
{
    public partial class AddWebUC : UserControl
    {
        private const string prefix = "https://";
        private const string tbxfill = "enter web adress";
        public AddWebUC()
        {
            InitializeComponent();
            Visible = false;
            tBxEnter.Text = tbxfill;
        }

        private void tBxEnter_Enter(object sender, EventArgs e)
        {
            tBxEnter.Text = prefix;
        }
        private void tBxEnter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) { HideAddWebUC(); }
        }

        private void BtnSave_MouseClick(object sender, MouseEventArgs e)
        {
            HideAddWebUC();
        }

        private void BtnClose_MouseClick(object sender, MouseEventArgs e)
        {
            HideAddWebUC();
        }

        private void HideAddWebUC()
        {
            this.Visible = false;
            tBxEnter.Text = tbxfill;
        }

    }
}
