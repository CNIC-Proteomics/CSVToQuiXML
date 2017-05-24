using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace CSVtoQuiXML
{
    public partial class frmMain : Form
    {
        string[] listForReading;
        string firstTitle;
        char[] split_chars;
        int scanField;
        bool locateMS2precMasses;
        bool substitute_mgf_raw;
        bool useSchema;
        string schemaToUse = "";
 
        public frmMain()
        {
            InitializeComponent();
            locateMS2precMasses = false;
            substitute_mgf_raw = false;
            useSchema = false;
            this.Text = this.Text + CSVtoQuiXML.Properties.Resources.version;

            //DA_txtReader.test();

            this.trackBarFDR.ValueChanged += new EventHandler(trackBarFDR_ValueChanged);
            this.groupBox1.AllowDrop = true;
        }

        void trackBarFDR_ValueChanged(object sender, EventArgs e)
        {
            float FDRval = (float)trackBarFDR.Value / 10;
            FDRtxt.Text = FDRval.ToString();
        }

        public void runBtn_Click(object sender, EventArgs e)
        {
            readTXT(listForReading);
        }

        private void readTXT(string[] listShowingReadingOrder)
        {
            try
            {
                string[] targetFiles;
                targetFiles = Directory.GetFiles(linkDirSrfFolder.Text, "*.txt", System.IO.SearchOption.AllDirectories);
                double FDR = double.Parse(this.FDRtxt.Text);

                ArrayList scans=new ArrayList();
                
                if(!useSchema)
                {
                    scans = DA_txtReader.readTXT(targetFiles, listShowingReadingOrder, OutData.databases.Target);

                    if (locateMS2precMasses)
                    {
                        scans = Utilities.getMHplusFromMgf(scans, this.ms2mgf.Text.Trim(), split_chars, scanField);
                    }
               
                    Utilities.writeQuiXML(scans, FDR, this.linkDirSrfFolder.Text);
               
                }

                if (useSchema)
                {
                    Utilities.writeQuiXML(targetFiles, listShowingReadingOrder,
                                        FDR, this.linkDirSrfFolder.Text);
                    
                    if (locateMS2precMasses)
                    {

                        string foldername = this.linkDirSrfFolder.Text;
                        System.IO.DirectoryInfo di = System.IO.Directory.GetParent(foldername);
                        string QuiXMLcreated = foldername.Trim() + "\\" + di.Name.Trim() + "_QuiXML.xml";
                        
                        Utilities.getMHplusFromMgf(QuiXMLcreated,
                                                    schemaToUse,
                                                    this.ms2mgf.Text.Trim(), 
                                                    split_chars, 
                                                    scanField,
                                                    substitute_mgf_raw);
                    
                    }

                }
                                
                
                MessageBox.Show("QuiXML file/s created at " + this.linkDirSrfFolder.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error creating the QuiXML file: " + ex.Message + ex.StackTrace);
            }
        }


        private void lblTargetSearch_DragDrop(object sender, DragEventArgs e)
        {

            string[] folder = (string[])e.Data.GetData(DataFormats.FileDrop);

            string[] files = Directory.GetFiles(folder[0].ToString(), "*.*", System.IO.SearchOption.AllDirectories);

            foreach (string fil in files)
            {
                if (fil.ToLower().Contains(".txt"))
                {
                    linkDirSrfFolder.Text = folder[0].ToString().Trim();
                    break;
                }
            }

            // esto luego habrá que pasarlo al lector
            DialogResult reply = MessageBox.Show("Do you want to use a schema?",
                                 "Use of a schema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (reply == DialogResult.Yes)
            {
                useSchema = true;
                frmSelectSchema frmSS = new frmSelectSchema();

                frmSS.Focus();
                frmSS.ShowDialog();

                schemaToUse = frmSS.schemaSelected;
            }
            else
            {
                useSchema = false;
            }

            if (schemaToUse == null)
                useSchema = false;


            frmHeaderSelection frmHeader = new frmHeaderSelection(linkDirSrfFolder.Text, useSchema, schemaToUse);
            frmHeader.ShowDialog();
            listForReading = frmHeader.listForReading;

        }

        private void lblTargetSearch_DragEnter(object sender, DragEventArgs e)
        {
            // make sure they're actually dropping files (not text or anything else)


            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                // make sure the file is a txt file and is unique.
                // (without this, the cursor stays a "NO" symbol)
                string[] folder = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (folder.GetUpperBound(0) == 0)
                {
                    if (Directory.Exists(folder[0].ToString()))
                    {
                        e.Effect = DragDropEffects.All;
                    }
                }
            }
        }

        private void ms2mgf_DragDrop(object sender, DragEventArgs e)
        {
            string[] folder = (string[])e.Data.GetData(DataFormats.FileDrop);

            string[] files = Directory.GetFiles(folder[0].ToString(), "*.*");

            foreach (string fil in files)
            {
                if (fil.ToUpper().Contains(".MGF"))
                {
                    ms2mgf.Text = folder[0].ToString().Trim();
                    break;
                }
            }


        }

        private void ms2mgf_DragEnter(object sender, DragEventArgs e)
        {
            // make sure they're actually dropping files (not text or anything else)


            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                // make sure the file is a xml file and is unique.
                // (without this, the cursor stays a "NO" symbol)
                string[] folder = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (folder.GetUpperBound(0) == 0)
                {
                    if (Directory.Exists(folder[0].ToString()))
                    {
                        e.Effect = DragDropEffects.All;
                    }
                }
            }


        }

        private void ms2mgf_TextChanged(object sender, EventArgs e)
        {
            firstTitle = Mgfutils.getFirstTitle(this.ms2mgf.Text.Trim());

            this.titleLbl.Text = firstTitle;
            this.mgfParser.Enabled = true;

        }

        private void scanFieldsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox.SelectedIndexCollection selection = this.scanFieldsBox.SelectedIndices;

            //scanField = new int[selection.Count];
            for (int i = 0; i < selection.Count; i++)
            {
                scanField = (int)selection[i];
            }

            this.scanNumberResTxt.Text = Mgfutils.getScanNumber(firstTitle, split_chars, scanField).ToString();
            locateMS2precMasses = true;


        }

        private void splitCharsTxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                split_chars = splitCharsTxt.Text.Trim().ToCharArray();

                string[] fields = this.titleLbl.Text.Split(split_chars);

                this.scanFieldsBox.Items.Clear();
                foreach (string f in fields)
                {
                    this.scanFieldsBox.Items.Add(f);
                }

                char[] comma = new char[1];
                comma[0] = ',';

                string[] scanFieldsStr = this.splitCharsTxt.Text.Split(comma, StringSplitOptions.RemoveEmptyEntries);



            }
            catch
            {
                this.scanNumberResTxt.Text = "No scan";
            }
        }

        private void substMgfRaw_CheckedChanged(object sender, EventArgs e)
        {
            substitute_mgf_raw = this.substMgfRaw.Checked;
        }
    }
}