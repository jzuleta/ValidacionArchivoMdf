namespace CopyFiles
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxOut = new System.Windows.Forms.TextBox();
            this.textBoxIn = new System.Windows.Forms.TextBox();
            this.buttonCopy = new System.Windows.Forms.Button();
            this.panelContentBar = new System.Windows.Forms.Panel();
            this.backgroundWorkerCheckThread = new System.ComponentModel.BackgroundWorker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageCopy = new System.Windows.Forms.TabPage();
            this.tabPageValidate = new System.Windows.Forms.TabPage();
            this.panelValidateContent = new System.Windows.Forms.Panel();
            this.labelSource = new System.Windows.Forms.Label();
            this.buttonValidate = new System.Windows.Forms.Button();
            this.textBoxPathSource = new System.Windows.Forms.TextBox();
            this.tabPageCreateText = new System.Windows.Forms.TabPage();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.panelCreateTextStat = new System.Windows.Forms.Panel();
            this.checkedListBoxDbList = new System.Windows.Forms.CheckedListBox();
            this.buttonFinder = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSourceDb = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPageCopy.SuspendLayout();
            this.tabPageValidate.SuspendLayout();
            this.tabPageCreateText.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Origen";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Destino";
            // 
            // textBoxOut
            // 
            this.textBoxOut.Location = new System.Drawing.Point(55, 35);
            this.textBoxOut.Name = "textBoxOut";
            this.textBoxOut.Size = new System.Drawing.Size(420, 20);
            this.textBoxOut.TabIndex = 2;
            // 
            // textBoxIn
            // 
            this.textBoxIn.Location = new System.Drawing.Point(55, 9);
            this.textBoxIn.Name = "textBoxIn";
            this.textBoxIn.Size = new System.Drawing.Size(420, 20);
            this.textBoxIn.TabIndex = 3;
            this.textBoxIn.Text = "\\\\star\\fileserver\\proceso-244\\periodo-20956\\empresa-4";
            // 
            // buttonCopy
            // 
            this.buttonCopy.Location = new System.Drawing.Point(481, 9);
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(75, 46);
            this.buttonCopy.TabIndex = 4;
            this.buttonCopy.Text = "Copiar";
            this.buttonCopy.UseVisualStyleBackColor = true;
            this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
            // 
            // panelContentBar
            // 
            this.panelContentBar.AutoSize = true;
            this.panelContentBar.BackColor = System.Drawing.Color.White;
            this.panelContentBar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelContentBar.Location = new System.Drawing.Point(4, 72);
            this.panelContentBar.Name = "panelContentBar";
            this.panelContentBar.Size = new System.Drawing.Size(552, 160);
            this.panelContentBar.TabIndex = 5;
            // 
            // backgroundWorkerCheckThread
            // 
            this.backgroundWorkerCheckThread.WorkerReportsProgress = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageCopy);
            this.tabControl1.Controls.Add(this.tabPageValidate);
            this.tabControl1.Controls.Add(this.tabPageCreateText);
            this.tabControl1.ItemSize = new System.Drawing.Size(120, 20);
            this.tabControl1.Location = new System.Drawing.Point(8, 7);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(570, 265);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 6;
            // 
            // tabPageCopy
            // 
            this.tabPageCopy.Controls.Add(this.label1);
            this.tabPageCopy.Controls.Add(this.panelContentBar);
            this.tabPageCopy.Controls.Add(this.label2);
            this.tabPageCopy.Controls.Add(this.buttonCopy);
            this.tabPageCopy.Controls.Add(this.textBoxOut);
            this.tabPageCopy.Controls.Add(this.textBoxIn);
            this.tabPageCopy.Location = new System.Drawing.Point(4, 24);
            this.tabPageCopy.Name = "tabPageCopy";
            this.tabPageCopy.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCopy.Size = new System.Drawing.Size(562, 237);
            this.tabPageCopy.TabIndex = 0;
            this.tabPageCopy.Text = "Copiar Archvios";
            this.tabPageCopy.UseVisualStyleBackColor = true;
            // 
            // tabPageValidate
            // 
            this.tabPageValidate.Controls.Add(this.panelValidateContent);
            this.tabPageValidate.Controls.Add(this.labelSource);
            this.tabPageValidate.Controls.Add(this.buttonValidate);
            this.tabPageValidate.Controls.Add(this.textBoxPathSource);
            this.tabPageValidate.Location = new System.Drawing.Point(4, 24);
            this.tabPageValidate.Name = "tabPageValidate";
            this.tabPageValidate.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageValidate.Size = new System.Drawing.Size(562, 237);
            this.tabPageValidate.TabIndex = 1;
            this.tabPageValidate.Text = "Validación";
            this.tabPageValidate.UseVisualStyleBackColor = true;
            // 
            // panelValidateContent
            // 
            this.panelValidateContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelValidateContent.Location = new System.Drawing.Point(4, 37);
            this.panelValidateContent.Name = "panelValidateContent";
            this.panelValidateContent.Size = new System.Drawing.Size(552, 194);
            this.panelValidateContent.TabIndex = 8;
            // 
            // labelSource
            // 
            this.labelSource.AutoSize = true;
            this.labelSource.Location = new System.Drawing.Point(6, 13);
            this.labelSource.Name = "labelSource";
            this.labelSource.Size = new System.Drawing.Size(40, 13);
            this.labelSource.TabIndex = 5;
            this.labelSource.Text = "Fuente";
            // 
            // buttonValidate
            // 
            this.buttonValidate.Location = new System.Drawing.Point(481, 7);
            this.buttonValidate.Name = "buttonValidate";
            this.buttonValidate.Size = new System.Drawing.Size(75, 25);
            this.buttonValidate.TabIndex = 7;
            this.buttonValidate.Text = "Validar";
            this.buttonValidate.UseVisualStyleBackColor = true;
            this.buttonValidate.Click += new System.EventHandler(this.buttonValidate_Click);
            // 
            // textBoxPathSource
            // 
            this.textBoxPathSource.Location = new System.Drawing.Point(55, 10);
            this.textBoxPathSource.Name = "textBoxPathSource";
            this.textBoxPathSource.Size = new System.Drawing.Size(420, 20);
            this.textBoxPathSource.TabIndex = 6;
            this.textBoxPathSource.Text = "C:\\STAR\\FILESERVER\\PROCESO-244";
            // 
            // tabPageCreateText
            // 
            this.tabPageCreateText.Controls.Add(this.buttonCreate);
            this.tabPageCreateText.Controls.Add(this.panelCreateTextStat);
            this.tabPageCreateText.Controls.Add(this.checkedListBoxDbList);
            this.tabPageCreateText.Controls.Add(this.buttonFinder);
            this.tabPageCreateText.Controls.Add(this.label3);
            this.tabPageCreateText.Controls.Add(this.textBoxSourceDb);
            this.tabPageCreateText.Location = new System.Drawing.Point(4, 24);
            this.tabPageCreateText.Name = "tabPageCreateText";
            this.tabPageCreateText.Size = new System.Drawing.Size(562, 237);
            this.tabPageCreateText.TabIndex = 2;
            this.tabPageCreateText.Text = "Archivos de Texto";
            this.tabPageCreateText.UseVisualStyleBackColor = true;
            // 
            // buttonCreate
            // 
            this.buttonCreate.Enabled = false;
            this.buttonCreate.Location = new System.Drawing.Point(455, 208);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(101, 28);
            this.buttonCreate.TabIndex = 12;
            this.buttonCreate.Text = "Crear archivos";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // panelCreateTextStat
            // 
            this.panelCreateTextStat.Location = new System.Drawing.Point(4, 208);
            this.panelCreateTextStat.Name = "panelCreateTextStat";
            this.panelCreateTextStat.Size = new System.Drawing.Size(445, 29);
            this.panelCreateTextStat.TabIndex = 11;
            // 
            // checkedListBoxDbList
            // 
            this.checkedListBoxDbList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.checkedListBoxDbList.ColumnWidth = 150;
            this.checkedListBoxDbList.FormattingEnabled = true;
            this.checkedListBoxDbList.HorizontalExtent = 3;
            this.checkedListBoxDbList.HorizontalScrollbar = true;
            this.checkedListBoxDbList.Location = new System.Drawing.Point(4, 37);
            this.checkedListBoxDbList.MultiColumn = true;
            this.checkedListBoxDbList.Name = "checkedListBoxDbList";
            this.checkedListBoxDbList.Size = new System.Drawing.Size(552, 167);
            this.checkedListBoxDbList.TabIndex = 10;
            // 
            // buttonFinder
            // 
            this.buttonFinder.Location = new System.Drawing.Point(481, 7);
            this.buttonFinder.Name = "buttonFinder";
            this.buttonFinder.Size = new System.Drawing.Size(75, 25);
            this.buttonFinder.TabIndex = 9;
            this.buttonFinder.Text = "Buscar";
            this.buttonFinder.UseVisualStyleBackColor = true;
            this.buttonFinder.Click += new System.EventHandler(this.buttonFinder_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Fuente";
            // 
            // textBoxSourceDb
            // 
            this.textBoxSourceDb.Location = new System.Drawing.Point(55, 10);
            this.textBoxSourceDb.Name = "textBoxSourceDb";
            this.textBoxSourceDb.Size = new System.Drawing.Size(420, 20);
            this.textBoxSourceDb.TabIndex = 8;
            this.textBoxSourceDb.Text = "C:\\STAR\\FILESERVER\\PROCESO-244";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(584, 280);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Copiar Bases Moviles";
            this.tabControl1.ResumeLayout(false);
            this.tabPageCopy.ResumeLayout(false);
            this.tabPageCopy.PerformLayout();
            this.tabPageValidate.ResumeLayout(false);
            this.tabPageValidate.PerformLayout();
            this.tabPageCreateText.ResumeLayout(false);
            this.tabPageCreateText.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxOut;
        private System.Windows.Forms.TextBox textBoxIn;
        private System.Windows.Forms.Button buttonCopy;
        private System.Windows.Forms.Panel panelContentBar;
        private System.ComponentModel.BackgroundWorker backgroundWorkerCheckThread;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageCopy;
        private System.Windows.Forms.TabPage tabPageValidate;
        private System.Windows.Forms.TabPage tabPageCreateText;
        private System.Windows.Forms.Label labelSource;
        private System.Windows.Forms.Button buttonValidate;
        private System.Windows.Forms.TextBox textBoxPathSource;
        private System.Windows.Forms.Panel panelValidateContent;
        private System.Windows.Forms.CheckedListBox checkedListBoxDbList;
        private System.Windows.Forms.Button buttonFinder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSourceDb;
        private System.Windows.Forms.Panel panelCreateTextStat;
        private System.Windows.Forms.Button buttonCreate;
    }
}

