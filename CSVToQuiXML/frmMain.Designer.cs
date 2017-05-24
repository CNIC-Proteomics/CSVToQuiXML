namespace CSVtoQuiXML
{
    partial class frmMain
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.runBtn = new System.Windows.Forms.Button();
            this.FDRtxt = new System.Windows.Forms.TextBox();
            this.trackBarFDR = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.linkDirSrfFolder = new System.Windows.Forms.Label();
            this.lblTargetSearch = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ms2mgf = new System.Windows.Forms.Label();
            this.mgfParser = new System.Windows.Forms.GroupBox();
            this.scanFieldsBox = new System.Windows.Forms.ListBox();
            this.scanNumberResTxt = new System.Windows.Forms.Label();
            this.splitCharsTxt = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.titleLbl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.substMgfRaw = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFDR)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.mgfParser.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(198, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // runBtn
            // 
            this.runBtn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runBtn.Location = new System.Drawing.Point(374, 398);
            this.runBtn.Name = "runBtn";
            this.runBtn.Size = new System.Drawing.Size(75, 34);
            this.runBtn.TabIndex = 14;
            this.runBtn.Text = "Run !";
            this.runBtn.UseVisualStyleBackColor = true;
            this.runBtn.Click += new System.EventHandler(this.runBtn_Click);
            // 
            // FDRtxt
            // 
            this.FDRtxt.Location = new System.Drawing.Point(213, 396);
            this.FDRtxt.Name = "FDRtxt";
            this.FDRtxt.Size = new System.Drawing.Size(43, 20);
            this.FDRtxt.TabIndex = 18;
            this.FDRtxt.Text = "1";
            // 
            // trackBarFDR
            // 
            this.trackBarFDR.Location = new System.Drawing.Point(141, 387);
            this.trackBarFDR.Name = "trackBarFDR";
            this.trackBarFDR.Size = new System.Drawing.Size(66, 45);
            this.trackBarFDR.TabIndex = 17;
            this.trackBarFDR.Value = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(73, 399);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "FDR cut-off";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.linkDirSrfFolder);
            this.groupBox1.Controls.Add(this.lblTargetSearch);
            this.groupBox1.Location = new System.Drawing.Point(37, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(604, 65);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select folder with TXT files";
            this.groupBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.lblTargetSearch_DragDrop);
            this.groupBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.lblTargetSearch_DragEnter);
            // 
            // linkDirSrfFolder
            // 
            this.linkDirSrfFolder.AllowDrop = true;
            this.linkDirSrfFolder.AutoSize = true;
            this.linkDirSrfFolder.Location = new System.Drawing.Point(104, 29);
            this.linkDirSrfFolder.Name = "linkDirSrfFolder";
            this.linkDirSrfFolder.Size = new System.Drawing.Size(94, 13);
            this.linkDirSrfFolder.TabIndex = 9;
            this.linkDirSrfFolder.Text = "folder not selected";
            this.linkDirSrfFolder.DragDrop += new System.Windows.Forms.DragEventHandler(this.lblTargetSearch_DragDrop);
            this.linkDirSrfFolder.DragEnter += new System.Windows.Forms.DragEventHandler(this.lblTargetSearch_DragEnter);
            // 
            // lblTargetSearch
            // 
            this.lblTargetSearch.AllowDrop = true;
            this.lblTargetSearch.AutoSize = true;
            this.lblTargetSearch.Location = new System.Drawing.Point(19, 29);
            this.lblTargetSearch.Name = "lblTargetSearch";
            this.lblTargetSearch.Size = new System.Drawing.Size(79, 13);
            this.lblTargetSearch.TabIndex = 5;
            this.lblTargetSearch.Text = "Target search :";
            this.lblTargetSearch.DragDrop += new System.Windows.Forms.DragEventHandler(this.lblTargetSearch_DragDrop);
            this.lblTargetSearch.DragEnter += new System.Windows.Forms.DragEventHandler(this.lblTargetSearch_DragEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(318, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Get the previous MS2 precursor mass from MGF files in the folder :";
            // 
            // ms2mgf
            // 
            this.ms2mgf.AllowDrop = true;
            this.ms2mgf.AutoSize = true;
            this.ms2mgf.Location = new System.Drawing.Point(371, 114);
            this.ms2mgf.Name = "ms2mgf";
            this.ms2mgf.Size = new System.Drawing.Size(48, 13);
            this.ms2mgf.TabIndex = 20;
            this.ms2mgf.Text = "no folder";
            this.ms2mgf.TextChanged += new System.EventHandler(this.ms2mgf_TextChanged);
            this.ms2mgf.DragDrop += new System.Windows.Forms.DragEventHandler(this.ms2mgf_DragDrop);
            this.ms2mgf.DragEnter += new System.Windows.Forms.DragEventHandler(this.ms2mgf_DragEnter);
            // 
            // mgfParser
            // 
            this.mgfParser.Controls.Add(this.scanFieldsBox);
            this.mgfParser.Controls.Add(this.scanNumberResTxt);
            this.mgfParser.Controls.Add(this.splitCharsTxt);
            this.mgfParser.Controls.Add(this.label10);
            this.mgfParser.Controls.Add(this.label7);
            this.mgfParser.Controls.Add(this.titleLbl);
            this.mgfParser.Controls.Add(this.label5);
            this.mgfParser.Enabled = false;
            this.mgfParser.Location = new System.Drawing.Point(37, 159);
            this.mgfParser.Name = "mgfParser";
            this.mgfParser.Size = new System.Drawing.Size(604, 217);
            this.mgfParser.TabIndex = 21;
            this.mgfParser.TabStop = false;
            this.mgfParser.Text = "Mascot Generic Format file parser";
            // 
            // scanFieldsBox
            // 
            this.scanFieldsBox.FormattingEnabled = true;
            this.scanFieldsBox.Location = new System.Drawing.Point(249, 71);
            this.scanFieldsBox.Name = "scanFieldsBox";
            this.scanFieldsBox.Size = new System.Drawing.Size(171, 134);
            this.scanFieldsBox.TabIndex = 10;
            this.scanFieldsBox.SelectedIndexChanged += new System.EventHandler(this.scanFieldsBox_SelectedIndexChanged);
            // 
            // scanNumberResTxt
            // 
            this.scanNumberResTxt.AutoSize = true;
            this.scanNumberResTxt.Location = new System.Drawing.Point(378, 55);
            this.scanNumberResTxt.Name = "scanNumberResTxt";
            this.scanNumberResTxt.Size = new System.Drawing.Size(47, 13);
            this.scanNumberResTxt.TabIndex = 9;
            this.scanNumberResTxt.Text = "No scan";
            // 
            // splitCharsTxt
            // 
            this.splitCharsTxt.Location = new System.Drawing.Point(75, 52);
            this.splitCharsTxt.Name = "splitCharsTxt";
            this.splitCharsTxt.Size = new System.Drawing.Size(105, 20);
            this.splitCharsTxt.TabIndex = 6;
            this.splitCharsTxt.TextChanged += new System.EventHandler(this.splitCharsTxt_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(246, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(126, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Choose a Scan Number :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "split chars : ";
            // 
            // titleLbl
            // 
            this.titleLbl.AutoSize = true;
            this.titleLbl.Location = new System.Drawing.Point(58, 32);
            this.titleLbl.Name = "titleLbl";
            this.titleLbl.Size = new System.Drawing.Size(37, 13);
            this.titleLbl.TabIndex = 1;
            this.titleLbl.Text = "No file";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Title : ";
            // 
            // substMgfRaw
            // 
            this.substMgfRaw.AutoSize = true;
            this.substMgfRaw.Location = new System.Drawing.Point(78, 139);
            this.substMgfRaw.Name = "substMgfRaw";
            this.substMgfRaw.Size = new System.Drawing.Size(366, 17);
            this.substMgfRaw.TabIndex = 22;
            this.substMgfRaw.Text = "Substitute .mgf extensions for .raw (check this if you need to use RAWs)";
            this.substMgfRaw.UseVisualStyleBackColor = true;
            this.substMgfRaw.CheckedChanged += new System.EventHandler(this.substMgfRaw_CheckedChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 440);
            this.Controls.Add(this.substMgfRaw);
            this.Controls.Add(this.mgfParser);
            this.Controls.Add(this.ms2mgf);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.runBtn);
            this.Controls.Add(this.FDRtxt);
            this.Controls.Add(this.trackBarFDR);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmMain";
            this.Text = "CSVtoQuiXML v ";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFDR)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.mgfParser.ResumeLayout(false);
            this.mgfParser.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button runBtn;
        private System.Windows.Forms.TextBox FDRtxt;
        private System.Windows.Forms.TrackBar trackBarFDR;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label linkDirSrfFolder;
        private System.Windows.Forms.Label lblTargetSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ms2mgf;
        private System.Windows.Forms.GroupBox mgfParser;
        private System.Windows.Forms.ListBox scanFieldsBox;
        private System.Windows.Forms.Label scanNumberResTxt;
        private System.Windows.Forms.TextBox splitCharsTxt;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label titleLbl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox substMgfRaw;
    }
}

