using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace notepad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
        }
        private RichTextBox GetRichTextBox()
        {
            
            RichTextBox rtb = null; //making it initially null
            TabPage tp = tabControl1.SelectedTab; // saves the tab selection status in a tabpage type variable
            if (tp != null)
            {
                rtb = tp.Controls[0] as RichTextBox; //sets the selected rich text box index as primary
            }
            return rtb;
        }
        
        
       
        

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream;
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if ((myStream = openFileDialog1.OpenFile()) != null)
                {
                    string filename = openFileDialog1.FileName;//copies the path of the file into a variable
                    string readfiletext = File.ReadAllText(filename);//reads all the text from the opened file
                    TabPage tp = new TabPage("New Document"); //creates a new tab page
                    RichTextBox rtb = new RichTextBox(); //creates a new richtext box object
                    rtb.Dock = DockStyle.Fill; //docks rich text box 
                    tp.Controls.Add(rtb); // adds rich text box to the tab page
                    tabControl1.TabPages.Add(tp); //adds the tab pages to tab control
                    rtb.Text = readfiletext;
                }
            }
        }

        private void cuteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRichTextBox().Cut();
        }

        private void copyToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            GetRichTextBox().Copy();
        }

        private void pasteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            GetRichTextBox().Paste();
        }
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRichTextBox().ClearUndo();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox rtb = new RichTextBox();
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = "*.txt(textfile)|*.txt";
            rtb.Dock = DockStyle.Fill;
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                rtb.SaveFile(savefile.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void gToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            TabPage tp = new TabPage("New Document"); //creates a new tab page
            RichTextBox rtb = new RichTextBox(); //creates a new richtext box object
            rtb.Dock = DockStyle.Fill; //docks rich text box 
            tp.Controls.Add(rtb); // adds rich text box to the tab page
            tabControl1.TabPages.Add(tp); //adds the tab pages to tab control
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.MessageLoop)
            {
                // WinForms app
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                // Console app
                System.Environment.Exit(1);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRichTextBox().Cut();
            
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void aboutMeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 a = new AboutBox1();
            a.Show();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Create FontDialog instance
            FontDialog fontDialog1 = new FontDialog();
            // Show the dialog.
            DialogResult result = fontDialog1.ShowDialog();
            // See if OK was pressed.
            if (result == DialogResult.OK)
            {
                // Get Font.
                Font font = fontDialog1.Font;
                // Set TextBox properties.
                this.GetRichTextBox().Text = string.Format("Font is: {0}", font.Name);
                this.GetRichTextBox().Font = font;
            }
        }

       

        
       

        

       

        

    }
}
