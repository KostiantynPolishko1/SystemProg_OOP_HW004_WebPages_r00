namespace WinFormsApp.Views.UserControls
{
    partial class AddWebUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        /// 
        private void InitializeComponent()
        {
            tBxEnter = new TextBox();
            BtnSave = new Button();
            BtnClose = new Button();
            LbMsg = new Label();
            SuspendLayout();
            // 
            // tBxEnter
            // 
            tBxEnter.Location = new Point(10, 10);
            tBxEnter.Name = "tBxEnter";
            tBxEnter.Size = new Size(590, 27);
            tBxEnter.TabIndex = 0;
            tBxEnter.Enter += tBxEnter_Enter;
            tBxEnter.KeyDown += tBxEnter_KeyDown;
            // 
            // BtnSave
            // 
            BtnSave.Location = new Point(10, 50);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(100, 40);
            BtnSave.TabIndex = 1;
            BtnSave.Text = nameBtns["Save"];
            BtnSave.UseVisualStyleBackColor = true;
            BtnSave.MouseClick += BtnSave_MouseClick;
            // 
            // BtnClose
            // 
            BtnClose.Location = new Point(120, 50);
            BtnClose.Name = "BtnClose";
            BtnClose.Size = new Size(100, 40);
            BtnClose.TabIndex = 2;
            BtnClose.Text = nameBtns["Close"];
            BtnClose.UseVisualStyleBackColor = true;
            BtnClose.MouseClick += BtnClose_MouseClick;
            // 
            // LbMsg
            // 
            LbMsg.AutoSize = true;
            LbMsg.ForeColor = Color.Red;
            LbMsg.Location = new Point(230, 50);
            LbMsg.Name = "LbMsg";
            LbMsg.Size = new Size(67, 20);
            LbMsg.TabIndex = 3;
            LbMsg.Text = nameBtns["Message"];
            LbMsg.Visible = false;
            // 
            // AddWebUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(143, 134, 143);
            Controls.Add(LbMsg);
            Controls.Add(BtnClose);
            Controls.Add(BtnSave);
            Controls.Add(tBxEnter);
            Name = "AddWebUC";
            Size = new Size(610, 100);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tBxEnter;
        private Button BtnSave;
        private Button BtnClose;
        private Label LbMsg;
    }
}
