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

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog file_Dialog = new OpenFileDialog();

            if (file_Dialog.ShowDialog() == DialogResult.OK)
            {
                FileStream stream = File.Open(file_Dialog.FileName, FileMode.Open);
                MessageBox.Show("文件大小" + stream.Length + "字节", "提示！");
            }
        }
    }
}
