﻿using ConsoleApp.Controllers;
using ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp.Views.UserControls
{
    public partial class GridWebsUC : UserControl
    {
        private WebController webController;
        private List<Button> menuBtns;
        private readonly string[] nameBtns;
        public GridWebsUC()
        {
            InitializeComponent();

            nameBtns = new string[] { "Update", "Clear", "Search" };
            menuBtns = new List<Button>(nameBtns.Length);

            int startPosLeft = 570;
            int startPosTop = 10;

            for (int i = 0; i < nameBtns.Length; i++)
            {
                menuBtns.Add(new Button());

                CreateObj(menuBtns[i], new Point(startPosLeft, startPosTop), $"Btn{nameBtns[i]}");
                setBtn(menuBtns[i]);

                startPosLeft -= 50;
            }
        }

        public GridWebsUC(in WebController webController) : this()
        {
            this.webController = webController;

            Reload();
        }

        private void setBtn(in Button btn)
        {
            btn.UseVisualStyleBackColor = true;
            btn.BackgroundImageLayout = ImageLayout.Zoom;

            if (btn.Name == $"Btn{nameBtns[0]}") { btn.BackgroundImage = WinFormsApp.Properties.Resources.refresh; }
            else if (btn.Name == $"Btn{nameBtns[1]}") { btn.BackgroundImage = WinFormsApp.Properties.Resources.clear; }
            else if (btn.Name == $"Btn{nameBtns[2]}") { btn.BackgroundImage = WinFormsApp.Properties.Resources.search; }
        }

        private void CreateObj(in Control control, in Point point, string name, string Text = "")
        {
            control.Name = name;
            control.Size = new Size(40, 40);
            control.Location = point;
            control.TabIndex = 1;

            Controls.Add(control);
        }

        private void Reload()
        {
            int X = 5, Y = 5, space = 5;
            int i = 0;

/*            string msg = webController.GetAllWebShortcuts(out List<webshortcut>? webShortcuts);
            if (msg != string.Empty)
            {
                MessageBox.Show(msg);
                return;
            }*/

            List<webshortcut> webShortcuts = webController.webshortcuts.ToList();

            int offsetX = new WebUC().Width + space;
            int offsetY = new WebUC().Height + space;

            foreach(webshortcut web in webShortcuts)
            {
                this.PnWeb.Controls.Add(new WebUC(web.id, web.name, web.href, ref webController) { Location = new Point(X, Y)});
                X += offsetX;

                i += 1;
                if (i % 3 == 0)
                {
                    Y += offsetY;
                    X = 5;
                }
            }
        }
    }
}