namespace Controls
{
    partial class ValidateControl
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
            this.textBoxValidation = new System.Windows.Forms.TextBox();
            this.backgroundWorkerValidate = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // textBoxValidation
            // 
            this.textBoxValidation.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxValidation.Location = new System.Drawing.Point(0, 0);
            this.textBoxValidation.Multiline = true;
            this.textBoxValidation.Name = "textBoxValidation";
            this.textBoxValidation.ReadOnly = true;
            this.textBoxValidation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxValidation.Size = new System.Drawing.Size(552, 186);
            this.textBoxValidation.TabIndex = 0;
            // 
            // backgroundWorkerValidate
            // 
            this.backgroundWorkerValidate.WorkerReportsProgress = true;
            this.backgroundWorkerValidate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ValidateFilesThreadDoWork);
            this.backgroundWorkerValidate.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.ValidateFilesProgressChanged);
            this.backgroundWorkerValidate.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ValidateFilesRunWorkerCompleted);
            // 
            // ValidateControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxValidation);
            this.Name = "ValidateControl";
            this.Size = new System.Drawing.Size(552, 186);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxValidation;
        private System.ComponentModel.BackgroundWorker backgroundWorkerValidate;
    }
}
