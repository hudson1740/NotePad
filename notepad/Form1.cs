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
        int size = 10;
        public Form1()

        {
            InitializeComponent();

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }






        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream;
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                richTextBox1.SelectAll();
            richTextBox1.BackColor = richTextBox1.SelectionBackColor;
            richTextBox1.DeselectAll();
            {
                if ((myStream = openFileDialog1.OpenFile()) != null)
                {
                    string filename = openFileDialog1.FileName;//copies the path of the file into a variable
                    string readfiletext = File.ReadAllText(filename);//reads all the text from the opened file
                    TabPage tp = new TabPage("New Document"); //creates a new tab page
                    RichTextBox rtb = new RichTextBox(); //creates a new richtext box object
                    rtb.Dock = DockStyle.Fill; //docks rich text box 
                    tp.Controls.Add(rtb); // adds rich text box to the tab page
                    rtb.Text = readfiletext;
                }
            }
        }

        private void cuteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.ClearUndo();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
            richTextBox1.SelectionBackColor = richTextBox1.BackColor;
            richTextBox1.DeselectAll();

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



            if (MessageBox.Show("DO You Want To Save Your Work?", "Save?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                RichTextBox rtb = new RichTextBox();
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.Filter = "*.txt(textfile)|*.txt";
                rtb.Dock = DockStyle.Fill;

                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    rtb.SaveFile(savefile.FileName, RichTextBoxStreamType.PlainText);
                    {

                    }
                    if (MessageBox.Show("DO You Want To Save Your Work?", "Save?", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        richTextBox1.Clear();
                    }
                }
            }

       
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
            richTextBox1.Cut();
            
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
                this.richTextBox1.Text = string.Format("Font is: {0}", font.Name);
                this.richTextBox1.Font = font;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            size = size + 2;

            richTextBox1.SelectionFont = new Font("Arial Rounded MT", size);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            size = size - 2;
            richTextBox1.SelectionFont = new Font("Arial Rounded MT", size);
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionColor = Color.Red;
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionColor = Color.Blue;
        }

        private void limeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionColor = Color.Lime;
        }

        private void blackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionColor = Color.Black;
        }

        private void redToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.BackColor = Color.Black;
        }

        private void marronToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.BackColor = Color.Maroon;
        }

        private void navyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.BackColor = Color.Navy;
        }

        private void whiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.BackColor = Color.White;
        }
    }
    }

