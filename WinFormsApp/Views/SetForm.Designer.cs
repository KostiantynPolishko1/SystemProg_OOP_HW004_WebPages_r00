namespace WinFormsApp.Views
{
    partial class SetForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LbAutoRun = new Label();
            cBxAutoRun = new CheckBox();
            SuspendLayout();
            // 
            // LbAutoRun
            // 
            LbAutoRun.AutoSize = true;
            LbAutoRun.Location = new Point(10, 10);
            LbAutoRun.Name = "LbAutoRun";
            LbAutoRun.Size = new Size(54, 15);
            LbAutoRun.TabIndex = 0;
            LbAutoRun.Text = "AutoRun";
            // 
            // cBxAutoRun
            // 
            cBxAutoRun.AutoSize = true;
            cBxAutoRun.Location = new Point(80, 10);
            cBxAutoRun.Name = "cBxAutoRun";
            cBxAutoRun.Size = new Size(15, 14);
            cBxAutoRun.TabIndex = 1;
            cBxAutoRun.UseVisualStyleBackColor = true;
            cBxAutoRun.CheckedChanged += cBxAutoRun_CheckedChanged;
            // 
            // SetForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 100);
            Controls.Add(cBxAutoRun);
            Controls.Add(LbAutoRun);
            Name = "SetForm";
            Text = "SetForm";

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LbAutoRun;
        private CheckBox cBxAutoRun;
    }
}