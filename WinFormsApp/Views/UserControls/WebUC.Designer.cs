using System.ComponentModel;

namespace WinFormsApp.Views.UserControls
{
    partial class WebUC
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LbName = new Label();
            cBxSelect = new CheckBox();
            PnWeb = new Panel();
            LbId = new Label();
            LbHref = new Label();
            LbWebState = new Label();
            SuspendLayout();
            // 
            // LbName
            // 
            LbName.AutoSize = true;
            LbName.Location = new Point(10, 2);
            LbName.Name = "LbName";
            LbName.Size = new Size(49, 20);
            LbName.TabIndex = 0;
            LbName.Text = "Name";
            // 
            // cBxSelect
            // 
            cBxSelect.AutoSize = true;
            cBxSelect.Location = new Point(125, 130);
            cBxSelect.Name = "cBxSelect";
            cBxSelect.Size = new Size(18, 17);
            cBxSelect.TabIndex = 1;
            cBxSelect.UseVisualStyleBackColor = true;
            // 
            // PnWeb
            // 
            PnWeb.BackgroundImage = Properties.Resources.GoogleChromeLogo;
            PnWeb.BackgroundImageLayout = ImageLayout.Zoom;
            PnWeb.Location = new Point(0, 25);
            PnWeb.Name = "PnWeb";
            PnWeb.Size = new Size(150, 100);
            PnWeb.TabIndex = 2;
            PnWeb.MouseClick += PnWeb_MouseClick;
            PnWeb.MouseLeave += PnWeb_MouseLeave;
            PnWeb.MouseHover += PnWeb_MouseHover;
            // 
            // LbId
            // 
            LbId.AutoSize = true;
            LbId.Location = new Point(10, 127);
            LbId.Name = "LbId";
            LbId.Size = new Size(22, 20);
            LbId.TabIndex = 1;
            LbId.Text = "Id";
            // 
            // LbHref
            // 
            LbHref.AutoSize = true;
            LbHref.Location = new Point(96, 2);
            LbHref.Name = "LbHref";
            LbHref.Size = new Size(54, 20);
            LbHref.TabIndex = 3;
            LbHref.Text = "LbHref";
            LbHref.Visible = false;
            // 
            // LbWebState
            // 
            LbWebState.AutoSize = true;
            LbWebState.Location = new Point(38, 127);
            LbWebState.Name = "LbWebState";
            LbWebState.Size = new Size(73, 20);
            LbWebState.TabIndex = 4;
            LbWebState.Text = "WebState";
            LbWebState.Visible = false;
            // 
            // WebUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            Controls.Add(LbWebState);
            Controls.Add(LbHref);
            Controls.Add(LbId);
            Controls.Add(PnWeb);
            Controls.Add(cBxSelect);
            Controls.Add(LbName);
            Name = "WebUC";
            Padding = new Padding(5);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LbName;
        private CheckBox cBxSelect;
        private Panel PnWeb;
        private Label LbId;
        private Label LbHref;
        private Label LbWebState;
    }
}
