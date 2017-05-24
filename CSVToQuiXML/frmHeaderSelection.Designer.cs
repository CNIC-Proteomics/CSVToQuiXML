namespace CSVtoQuiXML
{
    partial class frmHeaderSelection
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
            this.components = new System.ComponentModel.Container();
            this.lbxOriginal = new System.Windows.Forms.ListBox();
            this.lbxAssign = new System.Windows.Forms.ListBox();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnOmit = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnInclude = new System.Windows.Forms.Button();
            this.btnExtra = new System.Windows.Forms.Button();
            this.btnDone = new System.Windows.Forms.Button();
            this.ttpButtons = new System.Windows.Forms.ToolTip(this.components);
            this.btnAll = new System.Windows.Forms.Button();
            this.btnNone = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbxOriginal
            // 
            this.lbxOriginal.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxOriginal.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lbxOriginal.FormattingEnabled = true;
            this.lbxOriginal.ItemHeight = 15;
            this.lbxOriginal.Location = new System.Drawing.Point(11, 26);
            this.lbxOriginal.Name = "lbxOriginal";
            this.lbxOriginal.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbxOriginal.Size = new System.Drawing.Size(239, 379);
            this.lbxOriginal.TabIndex = 0;
            // 
            // lbxAssign
            // 
            this.lbxAssign.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxAssign.FormattingEnabled = true;
            this.lbxAssign.ItemHeight = 15;
            this.lbxAssign.Items.AddRange(new object[] {
            "*RAW file name",
            "*FirstScan [- LastScan]",
            "*Protein description",
            "(MH+)",
            "(DeltaM)",
            "*Charge",
            "*Sequence",
            "(P (pep))",
            "(Xcorr1)",
            "(DeltaCn)",
            "(Sp)",
            "(Sp Rank)",
            "(Ions)",
            "(LastScan)",
            "(Xcorr2)",
            "(omit)",
            "(Score)",
            "(omit)",
            "(XcTeoric)",
            "(omit)",
            "(omit)",
            "(omit)",
            "(omit)",
            "(omit)",
            "(omit)"});
            this.lbxAssign.Location = new System.Drawing.Point(256, 26);
            this.lbxAssign.Name = "lbxAssign";
            this.lbxAssign.Size = new System.Drawing.Size(201, 379);
            this.lbxAssign.TabIndex = 1;
            this.lbxAssign.SelectedIndexChanged += new System.EventHandler(this.select_changed);
            this.lbxAssign.KeyDown += new System.Windows.Forms.KeyEventHandler(this.key_pressed);
            // 
            // btnUp
            // 
            this.btnUp.Enabled = false;
            this.btnUp.Image = global::CSVtoQuiXML.Properties.Resources.up;
            this.btnUp.Location = new System.Drawing.Point(463, 26);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(41, 49);
            this.btnUp.TabIndex = 2;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.item_up);
            this.btnUp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.key_pressed);
            // 
            // btnOmit
            // 
            this.btnOmit.Enabled = false;
            this.btnOmit.Image = global::CSVtoQuiXML.Properties.Resources.omit;
            this.btnOmit.Location = new System.Drawing.Point(463, 81);
            this.btnOmit.Name = "btnOmit";
            this.btnOmit.Size = new System.Drawing.Size(41, 49);
            this.btnOmit.TabIndex = 3;
            this.btnOmit.UseVisualStyleBackColor = true;
            this.btnOmit.Click += new System.EventHandler(this.btnOmit_Click);
            this.btnOmit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.key_pressed);
            // 
            // btnDown
            // 
            this.btnDown.Enabled = false;
            this.btnDown.Image = global::CSVtoQuiXML.Properties.Resources.down;
            this.btnDown.Location = new System.Drawing.Point(463, 191);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(41, 49);
            this.btnDown.TabIndex = 5;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.item_down);
            this.btnDown.KeyDown += new System.Windows.Forms.KeyEventHandler(this.key_pressed);
            // 
            // btnInclude
            // 
            this.btnInclude.Enabled = false;
            this.btnInclude.Image = global::CSVtoQuiXML.Properties.Resources.include;
            this.btnInclude.Location = new System.Drawing.Point(463, 136);
            this.btnInclude.Name = "btnInclude";
            this.btnInclude.Size = new System.Drawing.Size(41, 49);
            this.btnInclude.TabIndex = 4;
            this.btnInclude.UseVisualStyleBackColor = true;
            this.btnInclude.Click += new System.EventHandler(this.btnInclude_Click);
            this.btnInclude.KeyDown += new System.Windows.Forms.KeyEventHandler(this.key_pressed);
            // 
            // btnExtra
            // 
            this.btnExtra.AccessibleDescription = "";
            this.btnExtra.Image = global::CSVtoQuiXML.Properties.Resources.extra;
            this.btnExtra.Location = new System.Drawing.Point(463, 356);
            this.btnExtra.Name = "btnExtra";
            this.btnExtra.Size = new System.Drawing.Size(41, 49);
            this.btnExtra.TabIndex = 6;
            this.btnExtra.Tag = "";
            this.btnExtra.UseVisualStyleBackColor = true;
            this.btnExtra.Click += new System.EventHandler(this.extra_sampleLine);
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(288, 421);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(169, 36);
            this.btnDone.TabIndex = 7;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.click_Done);
            // 
            // ttpButtons
            // 
            this.ttpButtons.BackColor = System.Drawing.Color.Khaki;
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(12, 411);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(99, 21);
            this.btnAll.TabIndex = 8;
            this.btnAll.Text = "select all";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnNone
            // 
            this.btnNone.Location = new System.Drawing.Point(12, 438);
            this.btnNone.Name = "btnNone";
            this.btnNone.Size = new System.Drawing.Size(99, 21);
            this.btnNone.TabIndex = 9;
            this.btnNone.Text = "unselect all";
            this.btnNone.UseVisualStyleBackColor = true;
            this.btnNone.Click += new System.EventHandler(this.btnNone_Click);
            // 
            // frmHeaderSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 481);
            this.Controls.Add(this.btnNone);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.btnExtra);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnInclude);
            this.Controls.Add(this.btnOmit);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.lbxAssign);
            this.Controls.Add(this.lbxOriginal);
            this.Name = "frmHeaderSelection";
            this.Text = "Header selector";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.key_pressed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbxOriginal;
        private System.Windows.Forms.ListBox lbxAssign;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnOmit;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnInclude;
        private System.Windows.Forms.Button btnExtra;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.ToolTip ttpButtons;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnNone;
    }
}