using System.Windows.Forms;

namespace WinFormsApp.Views.UserControls
{
    partial class GridWebsUC
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Panel PnWeb;

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
            PnWeb = new Panel();
            pcBx = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pcBx).BeginInit();
            SuspendLayout();
            // 
            // PnWeb
            // 
            PnWeb.AutoScroll = true;
            PnWeb.BackColor = Color.Aquamarine;
            PnWeb.Location = new Point(0, 60);
            PnWeb.Name = "PnWeb";
            PnWeb.Size = new Size(625, 530);
            PnWeb.TabIndex = 0;
            // 
            // pcBx
            // 
            pcBx.BackColor = Color.Lime;
            pcBx.SizeMode = PictureBoxSizeMode.Zoom;
            pcBx.BorderStyle = BorderStyle.FixedSingle;
            pcBx.Location = new Point(5, 595);
            pcBx.Margin = new Padding(0);
            pcBx.Name = "pcBx";
            pcBx.Size = new Size(100, 100);
            pcBx.TabIndex = 2;
            pcBx.TabStop = false;
            // 
            // GridWebsUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(147, 153, 250);
            Controls.Add(pcBx);
            Controls.Add(PnWeb);
            Name = "GridWebsUC";
            Size = new Size(625, 700);
            Load += GridWebsUC_Load;
            Control.CheckForIllegalCrossThreadCalls = false;
            ((System.ComponentModel.ISupportInitialize)pcBx).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pcBx;
    }
}
