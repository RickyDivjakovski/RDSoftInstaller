using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RDUninstaller
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://forum.xda-developers.com/android/software-hacking/code-editor-developmentpad-plus-t3506076");
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                checkBox1.Checked = true;
                checkBox2.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                if (File.Exists("C:\\Program Files\\RDSoft\\RDEditor.exe"))
                {
                    File.Delete("C:\\Program Files\\RDSoft\\RDEditor.exe");
                }
                if (File.Exists("C:\\Users\\" + Environment.UserName +"\\Desktop\\RDEditor.lnk"))
                {
                    File.Delete("C:\\Users\\" + Environment.UserName + "\\Desktop\\RDEditor.lnk");
                }
                if (File.Exists("C:\\Program Files\\RDSoft\\contextmenu.reg"))
                {
                    File.Delete("C:\\Program Files\\RDSoft\\contextmenu.reg");
                }
                if (File.Exists("C:\\Program Files\\RDSoft\\removecontextmenu.reg"))
                {
                    System.Diagnostics.Process NewProcess = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo NewStartInfo = new System.Diagnostics.ProcessStartInfo();
                    NewStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    NewStartInfo.CreateNoWindow = true;
                    NewStartInfo.UseShellExecute = false;
                    NewStartInfo.RedirectStandardOutput = true;
                    NewStartInfo.FileName = "cmd.exe";
                    NewStartInfo.Arguments = " /C \"reg import \"C:\\Program Files\\RDSoft\\removecontextmenu.reg\"\"";
                    NewProcess.StartInfo = NewStartInfo;
                    NewProcess.Start();
                    File.Delete("C:\\Program Files\\RDSoft\\uninstall.reg");
                }
            }
            if (checkBox2.Checked == true)
            {
                if (File.Exists("C:\\Program Files\\RDSoft\\RDExplorer.exe"))
                {
                    File.Delete("C:\\Program Files\\RDSoft\\RDExplorer.exe");
                }
                if (File.Exists("C:\\Users\\" + Environment.UserName + "\\Desktop\\RDExplorer.lnk"))
                {
                    File.Delete("C:\\Users\\" + Environment.UserName + "\\Desktop\\RDExplorer.lnk");
                }
            }
            if (checkBox1.Checked == true && checkBox2.Checked == true)
            {
                if (File.Exists("C:\\Program Files\\RDSoft\\RDSoft.ico"))
                {
                    File.Delete("C:\\Program Files\\RDSoft\\RDSoft.ico");
                }
                if (File.Exists("C:\\Program Files\\RDSoft\\uninstall.reg"))
                {
                    System.Diagnostics.Process NewProcess = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo NewStartInfo = new System.Diagnostics.ProcessStartInfo();
                    NewStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    NewStartInfo.CreateNoWindow = true;
                    NewStartInfo.UseShellExecute = false;
                    NewStartInfo.RedirectStandardOutput = true;
                    NewStartInfo.FileName = "cmd.exe";
                    NewStartInfo.Arguments = " /C \"reg import \"C:\\Program Files\\RDSoft\\uninstall.reg\"\"";
                    NewProcess.StartInfo = NewStartInfo;
                    NewProcess.Start();
                    File.Delete("C:\\Program Files\\RDSoft\\uninstall.reg");
                }
            }
            label1.Visible = false;
            label2.Visible = false;
            linkLabel1.Visible = false;
            checkBox1.Visible = false;
            checkBox2.Visible = false;
            checkBox3.Visible = false;
            button1.Visible = false;
            button2.Visible = true;
            label3.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists("C:\\Program Files\\RDSoft\\RDEditor.exe"))
            {
                checkBox1.Visible = false;
                checkBox3.Visible = false;
            }
            if (!File.Exists("C:\\Program Files\\RDSoft\\RDExplorer.exe"))
            {
                checkBox2.Visible = false;
                checkBox3.Visible = false;
            }
        }
    }
}
