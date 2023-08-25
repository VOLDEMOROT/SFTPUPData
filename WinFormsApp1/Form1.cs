using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {


        public string FUploadLogDir;
        public string FConfigDir;
        public string FLogFile;
        public Form1()
        {
            InitializeComponent();
            FormShow();
        }

        private void FormShow()
        {
            FUploadLogDir = Application.StartupPath + "UplodaLog" + "/";
            FConfigDir = Application.StartupPath + "Config" + "/";
            InitSystemDir();
            //FLogFile = Application.StartupPath + DateTime.Now.ToString("yyyy-MM-dd HH-MM-ss") + ".log";
            //if (Directory.Exists(FLogFile))
            //{

            //}
            GetSystemParam();
        }

        private void InitSystemDir()
        {
            CreateFolder(FUploadLogDir);
            CreateFolder(FConfigDir);
        }
        
        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="AFolderName"></param>
        /// <returns></returns>
        private bool CreateFolder(string AFolderName)
        {
            bool Result = false;
            try
            {
                if (AFolderName == "")
                {
                    return Result;
                }
                if (!Directory.Exists(AFolderName))
                {
                    Directory.CreateDirectory(AFolderName);
                    Result = true;
                }
                else { Result = true; }
            }
            catch (Exception) { }
            return Result;
        }

        /// <summary>
        /// 获取系统参数
        /// </summary>
        private void GetSystemParam()
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string host = "10.210.91.242";
            string username = "FTP_Readonly";
            string password = "QsxWaz246!#%";
            int port = 2300;

            using (var client = new SftpClient(host, port, username, password))
            {
                try
                {
                    client.Connect();
                }
                catch (Exception E)
                {
                    Console.WriteLine("连接SFTP异常:" + E);
                }
                // 在这里可以执行SFTP操作，例如上传、下载文件等
                client.Disconnect();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtDirectory.Text = dialog.SelectedPath;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
