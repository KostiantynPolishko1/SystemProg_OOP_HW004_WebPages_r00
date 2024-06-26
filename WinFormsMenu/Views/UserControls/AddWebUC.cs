﻿using ConsoleApp.Controllers;
using ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

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
        public Thread th = null;
        public CancellationTokenSource cts;
        private Animation animation;
        public delegate void Animation(in CancellationToken token);

        public AddWebUC()
        {
            InitializeComponent();
            Visible = false;
            tBxEnter.Text = tbxfill;
            BtnSave.Enabled = false;
        }

        public AddWebUC(ref PsiSet psiSet, ref WebController webController, in Button BtnUpdate,
            Animation animation) : this() 
        {
            this.psiSet = psiSet;
            this.webController = webController;
            this.BtnUpdate = BtnUpdate;
            this.animation = animation;
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
            startAnime();
        }

        private void BtnClose_MouseClick(object sender, MouseEventArgs e)
        {
            WebUCNotEnanble();
            startAnime();
        }

        private void startAnime()
        {
            if (th == null || !th.IsAlive)
            {
                cts = new CancellationTokenSource();
                th = new Thread(new ParameterizedThreadStart(_ => animation(cts.Token)));
                th.Start();
            }
        }

        private void WebUCNotEnanble()
        {
            tBxEnter.Text = tbxfill;
            BtnSave.Enabled = false;
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
