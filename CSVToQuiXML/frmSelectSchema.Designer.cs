namespace CSVtoQuiXML
{
    partial class frmSelectSchema
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
            this.cbxSchemas = new System.Windows.Forms.ComboBox();
            this.txbSchema = new System.Windows.Forms.TextBox();
            this.lblSchemas = new System.Windows.Forms.Label();
            this.lblOwnSchema = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbxSchemas
            // 
            this.cbxSchemas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSchemas.FormattingEnabled = true;
            this.cbxSchemas.Location = new System.Drawing.Point(12, 48);
            this.cbxSchemas.Name = "cbxSchemas";
            this.cbxSchemas.Size = new System.Drawing.Size(453, 21);
            this.cbxSchemas.TabIndex = 0;
            // 
            // txbSchema
            // 
            this.txbSchema.AllowDrop = true;
            this.txbSchema.Location = new System.Drawing.Point(12, 116);
            this.txbSchema.Name = "txbSchema";
            this.txbSchema.Size = new System.Drawing.Size(453, 20);
            this.txbSchema.TabIndex = 1;
            this.txbSchema.TextChanged += new System.EventHandler(this.txbSchema_TextChanged);
            this.txbSchema.DragDrop += new System.Windows.Forms.DragEventHandler(this.txbSchema_DragDrop);
            this.txbSchema.DragEnter += new System.Windows.Forms.DragEventHandler(this.txbSchema_DragEnter);
            // 
            // lblSchemas
            // 
            this.lblSchemas.AutoSize = true;
            this.lblSchemas.Location = new System.Drawing.Point(12, 32);
            this.lblSchemas.Name = "lblSchemas";
            this.lblSchemas.Size = new System.Drawing.Size(347, 13);
            this.lblSchemas.TabIndex = 2;
            this.lblSchemas.Text = "Select one of the following recommended schemas (from the conf folder)";
            // 
            // lblOwnSchema
            // 
            this.lblOwnSchema.AutoSize = true;
            this.lblOwnSchema.Location = new System.Drawing.Point(12, 100);
            this.lblOwnSchema.Name = "lblOwnSchema";
            this.lblOwnSchema.Size = new System.Drawing.Size(236, 13);
            this.lblOwnSchema.TabIndex = 3;
            this.lblOwnSchema.Text = "... or paste yourself the path of your own schema";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(373, 160);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(92, 35);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnNo
            // 
            this.btnNo.Location = new System.Drawing.Point(267, 160);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(92, 35);
            this.btnNo.TabIndex = 4;
            this.btnNo.Text = "don\'t use a schema";
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // frmSelectSchema
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 216);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblOwnSchema);
            this.Controls.Add(this.lblSchemas);
            this.Controls.Add(this.txbSchema);
            this.Controls.Add(this.cbxSchemas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmSelectSchema";
            this.Text = "selectSchema";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxSchemas;
        private System.Windows.Forms.TextBox txbSchema;
        private System.Windows.Forms.Label lblSchemas;
        private System.Windows.Forms.Label lblOwnSchema;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnNo;
    }
}