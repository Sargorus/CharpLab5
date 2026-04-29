namespace CharpLab5
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pbMain = new PictureBox();
            timer = new System.Windows.Forms.Timer(components);
            txtLog = new RichTextBox();
            labelSpore = new Label();
            ((System.ComponentModel.ISupportInitialize)pbMain).BeginInit();
            SuspendLayout();
            // 
            // pbMain
            // 
            pbMain.Location = new Point(408, 12);
            pbMain.Name = "pbMain";
            pbMain.Size = new Size(582, 416);
            pbMain.TabIndex = 0;
            pbMain.TabStop = false;
            pbMain.Paint += pbMain_Paint;
            pbMain.MouseClick += pbMain_MouseClick;
            // 
            // timer
            // 
            timer.Enabled = true;
            timer.Interval = 30;
            timer.Tick += timer_Tick;
            // 
            // txtLog
            // 
            txtLog.Location = new Point(12, 12);
            txtLog.Name = "txtLog";
            txtLog.Size = new Size(390, 389);
            txtLog.TabIndex = 1;
            txtLog.Text = "";
            // 
            // labelSpore
            // 
            labelSpore.AutoSize = true;
            labelSpore.Location = new Point(12, 404);
            labelSpore.Name = "labelSpore";
            labelSpore.Size = new Size(50, 20);
            labelSpore.TabIndex = 2;
            labelSpore.Text = "label1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1002, 515);
            Controls.Add(labelSpore);
            Controls.Add(txtLog);
            Controls.Add(pbMain);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pbMain).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbMain;
        private System.Windows.Forms.Timer timer;
        private RichTextBox txtLog;
        private Label labelSpore;
    }
}
