using ConsoleApp.Controllers;
using ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using WinFormsApp.Models;

namespace WinFormsApp.Views.UserControls
{
    public partial class AddWebUC : UserControl
    {
        private const string prefix = "https://";
        private const string tbxfill = "enter web adress";
        private PsiSet psiSet;
        private Process? process;
        private WebController webController;
        private Button BtnUpdate;
        private Dictionary<string, string> nameBtns;

        public AddWebUC(in Names names)
        {
            this.nameBtns = names.BtnNamesWebUC;

            InitializeComponent();
            Visible = false;
            tBxEnter.Text = tbxfill;
            BtnSave.Enabled = false;
            BtnClose.Enabled = false;
        }

        public AddWebUC(ref PsiSet psiSet, ref WebController webController, in Button BtnUpdate, in Names names) : this(names) 
        {
            this.psiSet = psiSet;
            this.webController = webController;
            this.BtnUpdate = BtnUpdate;            

            //BtnSave.DataBindings.Add(new Binding("Text", BtnUpdate, "Name"));
        }

        private void tBxEnter_Enter(object sender, EventArgs e)
        {
            tBxEnter.Text = prefix;
        }

        private void tBxEnter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) 
            {
                (process, string msg) = UserProcess.OpenWebPage(this.tBxEnter.Text, psiSet.psi);

                if (msg != string.Empty)
                {
                    MessageBox.Show(msg);
                    return;
                }

                (bool flag, webtrack? wt) = WebController.getWebTrack(process);

                if (!flag)
                {
                    webController.AddWebToDb(wt);

                    webController.SaveChanges();
                }

                BtnEnable();
            }            
        }

        private void BtnSave_MouseClick(object sender, MouseEventArgs e)
        {
            (bool flag, webshortcut? wst) = WebController.getWebShortCut(process);

            if (!flag)
            {
                webController.AddWebShortcutToDb(wst);
            }
            
            WebUCNotEnanble();
        }

        private void BtnClose_MouseClick(object sender, MouseEventArgs e)
        {
            WebUCNotEnanble();
        }

        private void WebUCNotEnanble()
        {
            tBxEnter.Text = tbxfill;
            BtnSave.Enabled = false;
            BtnClose.Enabled = false;
            process = null;
            this.Visible = false;
        }

        private void BtnEnable()
        {
            if (tBxEnter.Text != prefix)
            {
                BtnSave.Enabled = true;
                BtnClose.Enabled = true;
            }
        }

    }
}
