using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteRunner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        WebClient wc;
        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.url = textBox1.Text;
            Properties.Settings.Default.Save();
            try
            {
                wc.DownloadFile(textBox1.Text, "targetapp.exe");
                Process.Start("targetapp.exe");
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = Properties.Settings.Default.url;
            wc = new WebClient();
        }
    }
}
