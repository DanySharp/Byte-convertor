using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Byte_convertor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OpenFileDialog opp = new OpenFileDialog();
        SaveFileDialog svv = new SaveFileDialog();
        private void button1_Click(object sender, EventArgs e)
        {
            if (opp.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = opp.FileName;
            }
            if (!string.IsNullOrEmpty(textBox1.Text))

            {

                FileStream fs = new FileStream(textBox1.Text, FileMode.Open, FileAccess.Read);
                byte[] filebytes = new byte[fs.Length];
                fs.Read(filebytes, 0, Convert.ToInt32(fs.Length));
                if (svv.ShowDialog() == DialogResult.OK)
                {
                    string encodedData = Convert.ToBase64String(filebytes, Base64FormattingOptions.InsertLineBreaks);
                    StreamWriter sw = new StreamWriter(svv.FileName, true);
                    sw.Write(encodedData.ToString());
                    richTextBox1.Text = encodedData.ToString();
                    sw.Close();
                    sw.Dispose();

                }



                // richTextBox1.Text = encodedData.ToString();
                MessageBox.Show("ok");

            }
            else
            {
                MessageBox.Show("Error");
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //if (opp.ShowDialog()==DialogResult.OK)
            //{
            //    textBox1.Text = opp.FileName;
            //}
        }
       
        private void button3_Click(object sender, EventArgs e)
        {
            opp.ShowDialog();
            textBox1.Text = opp.FileName;
            FileStream fstream = new FileStream(opp.FileName, FileMode.Open, FileAccess.Read);
            StreamReader sr1 = new StreamReader(fstream);
            // richTextBox1.Text = sr1.ReadToEnd();
            if (svv.ShowDialog() == DialogResult.OK)
            {
                byte[] filebytes = Convert.FromBase64String(sr1.ReadToEnd());
                // svv.ShowDialog();
                string sss = Path.GetExtension(svv.FileName);
                FileStream fs = new FileStream(svv.FileName+sss, FileMode.CreateNew, FileAccess.Write, FileShare.None);
               

                fs.Write(filebytes, 0, filebytes.Length);


                fs.Close();
                MessageBox.Show("ok");
            }
        }
    }
}
