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
        private PsiSet psiSet;
        private WebController webController;
        public WebUC()
        {
            InitializeComponent();
            psiSet = new PsiSet();
        }

        public WebUC(int id, in string name, in string href, ref WebController webController) : this()
        {
            this.webController = webController;

            this.Name = (name != "New" ? $"WebUC_{id}" : $"{name}WebUC_{id}");
            LbId.Text = id.ToString();
            LbName.Text = name;
            LbHref.Text = href;

            WebUC_Events(name);
        }

        private void WebUC_Events(in string name)
        {
            if (name != "New")
            {
                PnWeb.BackgroundImage = Properties.Resources.GoogleChromeLogo;
                PnWeb.MouseClick += PnWeb_MouseClick;
                PnWeb.MouseLeave += PnWeb_MouseLeave;
                PnWeb.MouseHover += PnWeb_MouseHover;
            }
            else
            {
                PnWeb.BackgroundImage = Properties.Resources.newtab;
                PnWeb.MouseClick += NewWebUC_MouseClick;
                PnWeb.MouseLeave += NewWebUC_MouseLeave;
                PnWeb.MouseHover += NewWebUC_MouseHover;

                this.cBxSelect.Visible = false;
                this.cBxSelect.Enabled = false;
                this.LbHref.Visible = true;
            }
        }

        private void NewWebUC_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void NewWebUC_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(249, 255, 64);
        }

        private void NewWebUC_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(224, 224, 224);
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
                webController.AddWebToDb(wt);

                //webController.webtracks.Add(wt);
                webController.SaveChanges();
            }
        }
    }
}
