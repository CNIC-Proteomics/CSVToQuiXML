using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CSVtoQuiXML
{
    public partial class frmSelectSchema : Form
    {
        public string schemaSelected;
        private string confFolder = "conf";

        public frmSelectSchema()
        {
            InitializeComponent();

            string[] schemaList = Directory.GetFiles(confFolder, "*.xsd", SearchOption.TopDirectoryOnly);

            cbxSchemas.Items.Clear();

            foreach (string schema in schemaList)
                cbxSchemas.Items.Add(Path.GetFileName(schema));

            cbxSchemas.SelectedIndex = 0;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            schemaSelected = getSchema();

            if(schemaSelected=="")
            {
                MessageBox.Show("You must select a schema");
                Application.DoEvents();
            }
            else
            {
                this.Dispose();
            }
        }

        private string getSchema()
        {
            string schema = "";

            if (txbSchema.Text.Trim().Length > 0)
                schema = txbSchema.Text.Trim();
            else
                schema = string.Concat(confFolder, "\\", cbxSchemas.SelectedItem.ToString());

            return schema;
        }

        private void txbSchema_TextChanged(object sender, EventArgs e)
        {
            // if there is something written in the text box, then you cannot select a schema from the drop list
            cbxSchemas.Enabled = !(txbSchema.Text.Trim().Length > 0);
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Dispose();
            // no schema will be used
        }

        private void txbSchema_DragEnter(object sender, DragEventArgs e)
        {
            // make sure they're actually dropping files (not text or anything else)
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                // make sure the file is a .xsd file and is unique.
                // (without this, the cursor stays a "NO" symbol)
                string[] filePath = (string[])e.Data.GetData(DataFormats.FileDrop);
                string fileExtension = Path.GetExtension(filePath[0]).ToLower();
                if (fileExtension == ".xsd")
                    e.Effect = DragDropEffects.All;
            }
        }

        private void txbSchema_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            txbSchema.Text = files[0].ToString().Trim();
        }


    }
}
