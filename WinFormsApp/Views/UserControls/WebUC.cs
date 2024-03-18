using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsoleApp.Controllers;
using System.Diagnostics;
using ConsoleApp.Models;

namespace WinFormsApp.Views.UserControls
{
    public partial class WebUC : UserControl
    {
        //private List<Process> processes;
        private PsiSet psiSet;
        private WebController webController;
        public WebUC()
        {
            InitializeComponent();
            //processes = new List<Process>(3);
            psiSet = new PsiSet();
        }

        public WebUC(int id, in string name, in string href, ref WebController webController) : this()
        {
            this.Name = $"WebUC_{id}";
            LbId.Text = id.ToString();
            LbName.Text = name;
            LbHref.Text = href;

            this.webController = webController;
        }

        private void PnWeb_MouseHover(object sender, EventArgs e)
        {
            PnWeb.BackgroundImage = Properties.Resources.iconopen;
        }

        private void PnWeb_MouseLeave(object sender, EventArgs e)
        {
            PnWeb.BackgroundImage = Properties.Resources.GoogleChromeLogo;
        }

        private void PnWeb_MouseClick(object sender, MouseEventArgs e)
        {
            (Process? prc, string msg) = UserProcess.OpenWebPage(this.LbHref.Text, psiSet.psi);

            if (msg != string.Empty)
            {
                MessageBox.Show(msg);
                return;
            }

            this.LbWebState.Text = "open";
            this.LbWebState.Visible = true;

            (bool flag, webtrack? wt) = WebController.getWebTrack(prc);

            if (!flag)
            {
                //webController.AddWebToDb(wt);

                webController.webtracks.Add(wt);
                webController.SaveChanges();
            }
        }
    }
}
