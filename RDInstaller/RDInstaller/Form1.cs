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
using IWshRuntimeLibrary;
using System.Diagnostics;

namespace RDInstaller
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button3.Focus();
            button3.PerformClick();
            checkBox1.Checked = true;
            checkBox2.Checked = true;
            checkBox3.Checked = true;
            checkBox5.Checked = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(textBox1.Text))
            {
                Directory.CreateDirectory(textBox1.Text);
            }
            System.IO.File.WriteAllBytes(textBox1.Text + "\\RDSoft.ico", RDInstaller.Properties.Resources.RDSofticon);
            System.IO.File.WriteAllBytes(textBox1.Text + "\\install.reg", RDInstaller.Properties.Resources.install);
            System.IO.File.WriteAllBytes(textBox1.Text + "\\uninstall.reg", RDInstaller.Properties.Resources.install);
            System.IO.File.WriteAllBytes(textBox1.Text + "\\RDUninstaller.exe", RDInstaller.Properties.Resources.RDUninstaller);
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = " /C \"reg import \"" + textBox1.Text + "\\install.reg\"\"";
            process.StartInfo = startInfo;
            process.Start();
            if (checkBox1.Checked == true)
            {
                System.IO.File.WriteAllBytes(textBox1.Text + "\\RDEditor.exe", RDInstaller.Properties.Resources.RDEditor);
                if (checkBox3.Checked == true)
                {
                    object shDesktop = (object)"Desktop";
                    WshShell shell = new WshShell();
                    string shortcutAddress = (string)shell.SpecialFolders.Item(ref shDesktop) + @"\RDEditor.lnk";
                    IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
                    shortcut.Description = "Shortcut to RDEditor";
                    shortcut.TargetPath = textBox1.Text + "\\RDEditor.exe";
                    shortcut.Save();
                }
                if (checkBox5.Checked == true)
                {
                    System.IO.File.WriteAllBytes(textBox1.Text + "\\contextmenu.reg", RDInstaller.Properties.Resources.contextmenu);
                    System.IO.File.WriteAllBytes(textBox1.Text + "\\removecontextmenu.reg", RDInstaller.Properties.Resources.removecontextmenu);
                    System.Diagnostics.Process NewProcess = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo NewStartInfo = new System.Diagnostics.ProcessStartInfo();
                    NewStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    NewStartInfo.CreateNoWindow = true;
                    NewStartInfo.UseShellExecute = false;
                    NewStartInfo.RedirectStandardOutput = true;
                    NewStartInfo.FileName = "cmd.exe";
                    NewStartInfo.Arguments = " /C \"reg import \"" + textBox1.Text + "\\contextmenu.reg\"\"";
                    NewProcess.StartInfo = NewStartInfo;
                    NewProcess.Start();
                }
                System.IO.File.Delete(textBox1.Text + "\\install.reg");
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                textBox1.Visible = false;
                checkBox1.Visible = false;
                checkBox2.Visible = false;
                checkBox3.Visible = false;
                checkBox5.Visible = false;
                label5.Visible = true;
                button4.Visible = true;

            }
            if (checkBox2.Checked == true)
            {
                System.IO.File.WriteAllBytes(textBox1.Text + "\\RDExplorer.exe", RDInstaller.Properties.Resources.RDExplorer);
                object shDesktop = (object)"Desktop";
                WshShell shell = new WshShell();
                string shortcutAddress = (string)shell.SpecialFolders.Item(ref shDesktop) + @"\RDExplorer.lnk";
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
                shortcut.Description = "Shortcut to RDExplorer";
                shortcut.TargetPath = textBox1.Text + "\\RDExplorer.exe";
                shortcut.Save();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox3.Visible = true;
                checkBox3.Checked = true;
                checkBox5.Visible = true;
                checkBox5.Checked = true;
            }
            else
            {
                checkBox3.Visible = false;
                checkBox5.Visible = false;
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
