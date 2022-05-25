using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace laba6oop1lab
{
    public partial class Form1 : Form
    {
        class Secundomer
        {
            public DateTime times1;
            public DateTime times2;
            public TimeSpan diff;
            public string seconds;
            public void Start()
            {
                times1 = DateTime.UtcNow;
            }
            public string Stop()
            {
                times2 = DateTime.UtcNow;
                diff = times2 - times1;
                seconds = diff.TotalSeconds.ToString();
                return seconds;
            }

        }
        List<string> mydata = new List<string>();
        Secundomer mysec = new Secundomer();
        int countsec = 1;
        int sec;
        bool secplus;

        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            secplus = true;
            button1.Enabled = false;
            button2.Enabled = true;
            mysec.Start();
            sec = 0;
            await Task.Run(() => {
                while (secplus)
                {
                    textBox3.Text = Convert.ToString(sec);
                    sec++;
                    Thread.Sleep(900);
                }
            });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = false;
            secplus = false;
            textBox1.Text = "";
            textBox2.Text = "";
            mydata.Add(Convert.ToString(countsec) + " - " + mysec.Stop());
            countsec++;
            for (int i = 0; i < mydata.Count; i++)
            {
                textBox1.Text = textBox1.Text + mydata[i] + Environment.NewLine;
            }
            int check = mydata.Count - 10;
            if (check < 0)
            {
                for (int i = 0; i < mydata.Count; i++)
                {
                    textBox2.Text = textBox2.Text + mydata[i] + Environment.NewLine;
                }
            }
            else
            {
                for (int i = check; i < mydata.Count; i++)
                {
                    textBox2.Text = textBox2.Text + mydata[i] + Environment.NewLine;
                }
            }

        }
    }
}
