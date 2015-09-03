namespace CopyFiles
{
    partial class CopyControl
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
            this.labelDetailCopy = new System.Windows.Forms.Label();
            this.progressBarCopy = new System.Windows.Forms.ProgressBar();
            this.labelPercent = new System.Windows.Forms.Label();
            this.backgroundWorkerCopy = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // labelDetailCopy
            // 
            this.labelDetailCopy.AutoSize = true;
            this.labelDetailCopy.Location = new System.Drawing.Point(2, 5);
            this.labelDetailCopy.Name = "labelDetailCopy";
            this.labelDetailCopy.Size = new System.Drawing.Size(16, 13);
            this.labelDetailCopy.TabIndex = 0;
            this.labelDetailCopy.Text = "...";
            // 
            // progressBarCopy
            // 
            this.progressBarCopy.Location = new System.Drawing.Point(5, 21);
            this.progressBarCopy.Name = "progressBarCopy";
            this.progressBarCopy.Size = new System.Drawing.Size(508, 7);
            this.progressBarCopy.TabIndex = 1;
            // 
            // labelPercent
            // 
            this.labelPercent.AutoSize = true;
            this.labelPercent.Location = new System.Drawing.Point(515, 18);
            this.labelPercent.Name = "labelPercent";
            this.labelPercent.Size = new System.Drawing.Size(33, 13);
            this.labelPercent.TabIndex = 2;
            this.labelPercent.Text = "100%";
            // 
            // backgroundWorkerCopy
            // 
            this.backgroundWorkerCopy.WorkerReportsProgress = true;
            this.backgroundWorkerCopy.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerCopy_DoWork);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(552, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // CopyControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelPercent);
            this.Controls.Add(this.progressBarCopy);
            this.Controls.Add(this.labelDetailCopy);
            this.Name = "CopyControl";
            this.Size = new System.Drawing.Size(552, 40);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDetailCopy;
        private System.Windows.Forms.ProgressBar progressBarCopy;
        private System.Windows.Forms.Label labelPercent;
        private System.ComponentModel.BackgroundWorker backgroundWorkerCopy;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
