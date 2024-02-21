using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace FileDialog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Files (*.txt)|*.txt|image (.jpeg)|*.JPEG|all files(*.*)|*.*" ;
            ofd.FilterIndex = 2;
            ofd.InitialDirectory = @"D:\";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = ofd.FileName;
                string fileContent = File.ReadAllText(ofd.FileName);
                rtxtFileContent.Text = fileContent;
            }
        }

        private void btnBrowse2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Files (*.txt) | *.txt | All |*.*";
            ofd.FilterIndex = 2;
            ofd.InitialDirectory = @"D:\";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = ofd.FileName;
                string [] fileContent = File.ReadAllLines(ofd.FileName);

                textBox1.Text = fileContent.Length.ToString();

               /* foreach (string con in fileContent)
                {
                    rtxtFileContent.Text += con + "\n";
                } */
                
                for (int i = 0; i < fileContent.Length; i++)
                {
                    rtxtFileContent.Text += fileContent[i]+"\n";
                }
                
            }
        }

        private void btnBrowse3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Files (*.txt) | *.txt | All |*.*";
            ofd.FilterIndex = 2;
            ofd.InitialDirectory = @"D:\";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = ofd.FileName;
                byte[] fileContent = File.ReadAllBytes(ofd.FileName);

                foreach (byte b in fileContent)
                {
                    rtxtFileContent.Text += (char)b;
                }

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = @"C:\Users\Nadeera\Documents\ATI\IT\HNDIT1012\Practical";
            sfd.Filter = "Text Files (*.txt) | *.txt|image file (.jpeg)| *.JPEG";
            sfd.AddExtension = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, rtxtFileContent.Text);
            }
        }

       
    }
}
