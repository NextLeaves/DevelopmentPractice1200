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

namespace FileOperationApplication
{
    public partial class getFileLength : Form
    {
        public getFileLength()
        {
            InitializeComponent();
        }

        /// <summary>
        /// key words: OpenFileDialog,File,MessageBox,FileStream
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog file_Dialog = new OpenFileDialog();

            if (file_Dialog.ShowDialog() == DialogResult.OK)
            {
                FileStream stream = File.Open(file_Dialog.FileName, FileMode.Open);
                MessageBox.Show("文件大小" + stream.Length + "字节", "提示！");
            }
        }

        /// <summary>
        /// key words:OpenFileDialog,LastIndexOf()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog file_Dialog = new OpenFileDialog();

            if (file_Dialog.ShowDialog() == DialogResult.OK)
            {
                int index = file_Dialog.FileName.LastIndexOf(".");
                MessageBox.Show("文件后缀：" + file_Dialog.FileName.Substring(index + 1, file_Dialog.FileName.Length - index - 1), "提示！");
            }
        }

        /// <summary>
        /// Key words:OpenFileDialog,FileInfo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog file_Dialog = new OpenFileDialog();

            if (file_Dialog.ShowDialog() == DialogResult.OK)
            {
                FileInfo fileInfo = new FileInfo(file_Dialog.FileName);
                MessageBox.Show("文件创建时间：" + fileInfo.CreationTime.ToString(), "提示！");
            }
        }

        /// <summary>
        /// Key words:OpenFileDialog,FileInfo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog file_Dialog = new OpenFileDialog();

            if (file_Dialog.ShowDialog() == DialogResult.OK)
            {
                FileInfo fileInfo = new FileInfo(file_Dialog.FileName);
                MessageBox.Show("文件上一次修改时间：" + fileInfo.LastWriteTime.ToString(), "提示！");
            }
        }

        /// <summary>
        /// Key Words:Path,GetInvalidPathChars()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            foreach (char item in Path.GetInvalidPathChars())
            {
                textBox1.Text += item + " ";
            }
            foreach (char item in Path.GetInvalidFileNameChars())
            {
                textBox1.Text += item + " ";
            }
        }

        /// <summary>
        /// Key Words:SaveFileDialog,File,Open(),Delete()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void save_btn_Click(object sender, EventArgs e)
        {
            SaveFileDialog save_Dialog = new SaveFileDialog();
            if (save_Dialog.ShowDialog() == DialogResult.OK)
            {
                File.Create(save_Dialog.FileName);
            }
        }

        private void remove_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_Dialog = new OpenFileDialog();
            if (open_Dialog.ShowDialog() == DialogResult.OK)
            {
                File.Delete(open_Dialog.FileName);
            }
        }


        /// <summary>
        /// Key Words:Guid,NewGuid(),FolderBrowserDialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder_Dialog = new FolderBrowserDialog();
            if (folder_Dialog.ShowDialog() == DialogResult.OK)
            {
                File.Create(folder_Dialog.SelectedPath + "\\" + Guid.NewGuid() + ".txt");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder_Dialog = new FolderBrowserDialog();
            if (folder_Dialog.ShowDialog() == DialogResult.OK)
            {
                Directory.CreateDirectory(folder_Dialog.SelectedPath + "\\" + Guid.NewGuid());
            }
        }

        /// <summary>
        /// Key Words:Path,GetTempFileName(),FileInfo,StreamWriter,AppendText()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {
            textBox2.Text = Path.GetTempFileName();
            FileInfo info = new FileInfo(textBox2.Text);
            StreamWriter streamWriter=info.AppendText();
            if (textBox3.Text.Length != 0)
            {
                streamWriter.Write(textBox3.Text);                
            }
        }
    }
}
