namespace Controls
{
    partial class CreateTextControl
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
        private void InitializeComponent()
        {
            this.labelCreation = new System.Windows.Forms.Label();
            this.backgroundWorkerCreateText = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // labelCreation
            // 
            this.labelCreation.AutoSize = true;
            this.labelCreation.Location = new System.Drawing.Point(4, 7);
            this.labelCreation.Name = "labelCreation";
            this.labelCreation.Size = new System.Drawing.Size(16, 13);
            this.labelCreation.TabIndex = 0;
            this.labelCreation.Text = "...";
            // 
            // backgroundWorkerCreateText
            // 
            this.backgroundWorkerCreateText.WorkerReportsProgress = true;
            this.backgroundWorkerCreateText.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerCreateText_DoWork);
            this.backgroundWorkerCreateText.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerCreateText_ProgressChanged);
            this.backgroundWorkerCreateText.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerCreateText_RunWorkerCompleted);
            // 
            // CreateTextControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelCreation);
            this.Name = "CreateTextControl";
            this.Size = new System.Drawing.Size(445, 29);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCreation;
        private System.ComponentModel.BackgroundWorker backgroundWorkerCreateText;
    }
}
