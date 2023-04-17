using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;



namespace NotePad
{
   
    public partial class Form1 : Form
    {
        string Path;//Global Path 
        public Form1()
        {
           
            InitializeComponent();
        }
        //ERRORS TO FIXED THANK YOU 

        #region Exit Button
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult Answer = MessageBox.Show("Want to Exit?","Exit",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            if(Answer == DialogResult.Yes)
            {
                Application.Exit();//Quits the Program
            }
            else if(Answer ==DialogResult.No)
            {
                return;//Used as a Cancel Function
            }
        }
        #endregion
        #region Saved Button
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Path == string.Empty)
                {
                    DialogResult SaveResult = saveFileDialog1.ShowDialog();
                    if (SaveResult == DialogResult.OK)
                    {
                        Path = saveFileDialog1.FileName;
                    }
                    try
                    {
                        StreamWriter sw = new StreamWriter(Path);
                        sw.Write(richTextBox1.Text);
                        sw.Close();
                    }
                    catch (IOException Ex)
                    {
                        MessageBox.Show("Error : " + Ex.Message);

                    }
                }
                else
                {
                    try
                    {
                        //Clean Code 
                        StreamWriter sw = new StreamWriter(Path);
                        sw.Write(richTextBox1.Text);
                        sw.Close();
                    }
                    catch (Exception ex)
                    {
                        //Add a Message Box 
                        MessageBox.Show("Error Can't Save File " + ex.Message);
                    }
                }
               
                

                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);

            }

        }
        #endregion//Needs to fixed Errors Files states to Saved But Are not 
        #region Open Button
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //    DialogResult OpenResult = openFileDialog1.ShowDialog();
                //    if(OpenResult == DialogResult.OK)
                //    {

                //        Path = openFileDialog1.FileName;
                //        try
                //        {
                //            StreamReader Reader = new StreamReader(Path);
                //            string Contents = Reader.ReadToEnd();
                //            Reader.Close();
                //        }
                //        catch(IOException ex)
                //        {
                //            MessageBox.Show("Error : " + ex.Message);
                //         }

                try
                {
                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.Filter = "txt files(*.txt)|*.txt|All Files(*.*)|*.*";
                    if(ofd.ShowDialog() == DialogResult.OK)
                    {
                        richTextBox1.Text = ofd.FileName;
                        richTextBox1.Text = File.ReadAllText(ofd.FileName);

                    }
                }
                catch(IOException ex)
                {
                    MessageBox.Show("Error : " + ex.Message);
                }
            
                
            }
           catch(Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }



        }
        #endregion//Still needs to be fixed Error Cant Detect Files 
        #region New
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            Path = "";//Creates a new Page for the User
        }
        #endregion

        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        
        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //FontDialog Font = new FontDialog();
            //Font.ShowColor = true;
            //Font.Font = richTextBox1.Font;
            //Font.Color = richTextBox1.ForeColor;
            //if(Font.ShowDialog()!= DialogResult.Cancel)
            //{
            //   richTextBox1.Font = Font.Font;
            //   richTextBox1.ForeColor = Font.Color;
            //}


            DialogResult FontResult = fontDialog2.ShowDialog();
            if(FontResult == DialogResult.OK)
            {
                richTextBox1.Font = fontDialog2.Font;
            }

            
        }

        private void formatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DO NOT ADD CODE HERE 
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(wordWrapToolStripMenuItem.Checked == false)
            {
                wordWrapToolStripMenuItem.Checked = true;
                richTextBox1.WordWrap = true;

            }
            else
            {
                wordWrapToolStripMenuItem.Checked = false;
                richTextBox1.WordWrap = false;
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult SaveFile = saveFileDialog1.ShowDialog();
                if (SaveFile == DialogResult.OK)
                {
                    Path = saveFileDialog1.FileName;
                }
                try
                {
                    StreamWriter sw = new StreamWriter(Path);
                    sw.Write(richTextBox1.Text);
                    sw.Close();
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Error : " + ex.Message);
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Developed By Nathan James " +
                "Date : 13 September 2022");
        }
    }
}
