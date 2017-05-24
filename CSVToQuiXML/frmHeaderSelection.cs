using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CSVtoQuiXML
{
    public partial class frmHeaderSelection : Form
    {
        int sampleLine = 2;
        public string[] listForReading = new string[200];
        private string folder;
        private DataSet dsSchema;

        public frmHeaderSelection(string _folder, bool _useSchema, string _schemaToUse)
        {
            InitializeComponent();
            folder = _folder;
            fillOriginal(sampleLine);

            ttpButtons.SetToolTip(this.btnUp, "move selected item up [Shift + upArrow]");
            ttpButtons.SetToolTip(this.btnDown, "move selected item down [Shift + downArrow]");
            ttpButtons.SetToolTip(this.btnInclude, "include selected item [Shift + rightArrow]");
            ttpButtons.SetToolTip(this.btnOmit, "remove selected item [Shift + leftArrow]");
            ttpButtons.SetToolTip(this.btnExtra, "show more sample rows from text file [+ (add key)]");

            if (_useSchema && _schemaToUse.Trim().Length > 0) fillTarget(_schemaToUse);
        }

        private void fillOriginal(int sample)
        {
            fillOriginal(sample, lbxOriginal.TopIndex);
        }

        private void fillOriginal(int sample, int topIndex)
        {
            // provisionalmente pongo esta carpeta
            

            string header = getHeader(Directory.GetFiles(folder, "*.txt", System.IO.SearchOption.AllDirectories), 1);
            string headerSample = getHeader(Directory.GetFiles(folder, "*.txt", System.IO.SearchOption.AllDirectories), sample);
            string[] headerList = header.Split('\t');
            string[] headerSampleList = headerSample.Split('\t');

            for (int i = 0; i < headerList.Count(); i++)
            {
                headerList[i] = string.Concat(headerList[i], " [", headerSampleList[i], "]");
            }


            lbxOriginal.Items.Clear();
            foreach (string val in headerList)
            {
                string val2 = val;
                int maxLenght = 33;

                if (val.Length < maxLenght)
                {

                    for(int i=val.Length;i<maxLenght;i++)
                    {
                        val2 = string.Concat(val2.Trim(), ".");
                    }

                }

                lbxOriginal.Items.Add(val2);
            }

            lbxOriginal.TopIndex = topIndex;
            lbxAssign.TopIndex = topIndex;
        }

        private void fillTarget(string _schemaToUse)
        {
            dsSchema = new DataSet("DataSetRecords");

            lbxAssign.Items.Clear();

            dsSchema.ReadXmlSchema(_schemaToUse);
            //dsSchema.ReadXmlSchema(CSVtoQuiXML.Properties.Settings.Default.idSchema);
            //dsSchema.ReadXml(idfileTxt.Text.Trim(), XmlReadMode.Auto);
            DataColumnCollection dc = dsSchema.Tables["peptide_match"].Columns;

            for (int i = 0; i < dc.Count; i++)
            {
                lbxAssign.Items.Add(String.Concat("(", dc[i].ToString(), ")"));
            }

            while (lbxOriginal.Items.Count > lbxAssign.Items.Count)
            {
                lbxAssign.Items.Add("(omit)");
            }

        }

        private string getHeader(string[] txtFiles, int line)
        {
            string[] header = new string[line + 1];
            int i = 1;

            while(i<=line)
            {
                foreach (string file in txtFiles)
                {
                    try
                    {
                        StreamReader sr = new StreamReader(File.OpenRead(file));

                        try
                        {
                            // reads i times the files to reach line #i
                            for (int i2 = 1; i2 <= i; i2++)
                            {
                                header[i] = sr.ReadLine();
                            }
                        }
                        catch { }

                        sr.Close();

                        if (header.Length > 10)
                        {

                        }

                        i++;

                    }
                    catch { }

                }
            }

            return header[line];
        }

        private void select_changed(object sender, EventArgs e)
        {
            if (lbxAssign.SelectedItems.Count == 1)
            {
                char initialCh = lbxAssign.SelectedItem.ToString().ToCharArray()[0];
                char finalCh = lbxAssign.SelectedItem.ToString().ToCharArray()[lbxAssign.SelectedItem.ToString().Length - 1];

                btnUp.Enabled = true;

                if (initialCh == '(' && finalCh == ')')
                {
                    btnOmit.Enabled = false;
                    btnInclude.Enabled = true;
                }
                else
                {
                    btnOmit.Enabled = true;
                    btnInclude.Enabled = false;
                }

                if (lbxAssign.SelectedItem.ToString() == "(omit)")
                {
                    btnOmit.Enabled = false;
                    btnInclude.Enabled = false;
                }

                // items starting with "*" cannot be removed
                if (lbxAssign.SelectedItem.ToString()[0] == '*')
                {
                    btnOmit.Enabled = false;
                    btnInclude.Enabled = false;
                }

                //btnInclude.Enabled = true;
                btnDown.Enabled = true;
                //lbxOriginal.SelectionMode = SelectionMode.One;
                //lbxOriginal.SelectedIndex = lbxAssign.SelectedIndex;
            }
            else
            {
                btnUp.Enabled = false;
                btnOmit.Enabled = false;
                btnInclude.Enabled = false;
                btnDown.Enabled = false;
            }

            lbxOriginal.TopIndex = lbxAssign.TopIndex;
        }

        private void item_up(object sender, EventArgs e)
        {
            bool fromKeyboard = false;
            item_move(direction.up, fromKeyboard);

            lbxOriginal.TopIndex = lbxAssign.TopIndex;
        }

        private void item_down(object sender, EventArgs e)
        {
            bool fromKeyboard = false;
            item_move(direction.down, fromKeyboard);

            lbxOriginal.TopIndex = lbxAssign.TopIndex;
        }

        private void item_move(direction direct, bool fromKeyboard)
        {
            if ((lbxAssign.SelectedIndex > 0 && direct == direction.up) || (lbxAssign.SelectedIndex < lbxAssign.Items.Count - 1 && direct == direction.down))
            {
                string[] itemsInBox = new string[lbxAssign.Items.Count];
                string itemAbove;
                string itemBelow;
                int selectedItem = lbxAssign.SelectedIndex;
                int addValue = 0;

                if (direct == direction.up)
                {
                    addValue = -1;
                }
                else
                {
                    addValue = 1;
                }

                lbxAssign.Items.CopyTo(itemsInBox, 0);

                itemAbove = itemsInBox[selectedItem + addValue];
                itemBelow = itemsInBox[selectedItem];

                replaceItem(itemAbove, selectedItem);
                replaceItem(itemBelow, selectedItem + addValue);

                if (fromKeyboard) addValue = 0;
                lbxAssign.SelectedIndex = selectedItem + addValue;
            }

            lbxOriginal.TopIndex = lbxAssign.TopIndex;
        }

        private enum direction
        {
            up,
            down
        }

        private void extra_sampleLine(object sender, EventArgs e)
        {
            sampleLine++;
            fillOriginal(sampleLine);
        }

        private void click_Done(object sender, EventArgs e)
        {
            lbxAssign.Items.CopyTo(listForReading, 0);
            this.Dispose();
        }

        private void btnOmit_Click(object sender, EventArgs e)
        {
            string newSelectedItem = string.Concat("(", lbxAssign.SelectedItem.ToString(), ")");
            lbxAssign.SelectedItem = newSelectedItem;

            replaceItem(newSelectedItem, lbxAssign.SelectedIndex);

            lbxOriginal.TopIndex = lbxAssign.TopIndex;
        }

        private void btnInclude_Click(object sender, EventArgs e)
        {
            string newSelectedItem = lbxAssign.SelectedItem.ToString().Substring(1, lbxAssign.SelectedItem.ToString().Length - 2);
            lbxAssign.SelectedItem = newSelectedItem;

            replaceItem(newSelectedItem, lbxAssign.SelectedIndex);

            lbxOriginal.TopIndex = lbxAssign.TopIndex;
        }

        private void replaceItem(string newItem, int position)
        {
            int previouslySelected = lbxAssign.SelectedIndex;

            string[] inBox = new string[lbxAssign.Items.Count];

            lbxAssign.Items.CopyTo(inBox, 0);

            inBox[position] = newItem;

            lbxAssign.Items.Clear();
            foreach (string val in inBox)
            {
                lbxAssign.Items.Add(val);
            }

            lbxAssign.SelectedIndex = previouslySelected;
        }

        private void key_pressed(object sender, KeyEventArgs e)
        {
            bool fromKeyboard = true;
            int selIndex = lbxAssign.SelectedIndex;

            if (e.Shift)
            {
                if (e.KeyCode == Keys.Down)
                    item_move(direction.down, fromKeyboard);

                if (e.KeyCode == Keys.Up)
                    item_move(direction.up, fromKeyboard);

                if (e.KeyCode == Keys.Left && btnOmit.Enabled)
                {
                    btnOmit_Click(sender, e);
                    lbxAssign.SelectedIndex = selIndex;
                }

                if (e.KeyCode == Keys.Right && btnInclude.Enabled)
                {
                    btnInclude_Click(sender, e);
                    lbxAssign.SelectedIndex = selIndex;
                }

                if (e.KeyCode == Keys.Right)
                    lbxAssign.SelectedIndex = Math.Max(0, selIndex - 1);

                if (e.KeyCode == Keys.Left)
                    lbxAssign.SelectedIndex = Math.Min(selIndex + 1, lbxAssign.Items.Count - 1);
            }

            if (e.KeyCode == Keys.Add)
            {
                extra_sampleLine(sender, e);
            }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            selectUnselectAll(true);
        }

        private void selectUnselectAll(bool select)
        {
            int totItems = lbxAssign.Items.Count;
            for (int i = 0; i < totItems; i++)
            {
                lbxAssign.SelectedIndex = i;
                if (select) btnInclude.PerformClick();
                else btnOmit.PerformClick();
            }
        }

        private void btnNone_Click(object sender, EventArgs e)
        {
            selectUnselectAll(false);
        }

        //private void selectOriginal_changed(object sender, EventArgs e)
        //{
        //    if (lbxAssign.SelectedItems.Count == 1)
        //    {
        //        lbxOriginal.SelectedIndex = lbxAssign.SelectedIndex;
        //    }
        //}


    }
}