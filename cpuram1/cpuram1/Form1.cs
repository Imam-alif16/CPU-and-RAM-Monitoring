using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace cpuram1
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        // deklarasi data counter
        private int count;
        //===================
        public Form1()
        {
            count = 0;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // aktifasi Tumer counter per 1 detik
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            //================================
            textBox1.Text = "0";

            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            // counter data
            count++;
            // merubah type data count ke string
            this.textBox1.Text = Convert.ToString(count);

            if (textBox1.Text != "")
            {
                // Menyimpan data ke csv file
                FileStream fs = null;

                fs = new FileStream((@"C:\Users\ASUS\Downloads\cpuram1\test.csv"),
                    FileMode.Append, FileAccess.Write, FileShare.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.AutoFlush = true;

                if (sw == null) return;
                {
                    string datarec = this.textBox1.Text;
                    sw.WriteLine("{0}" , datarec);

                    sw.Close();
                }
            }
            if (Convert.ToInt16(textBox1.Text) == 10)
            {
                count = 0;
            }

            float fcpu = pCPU.NextValue();
            float fram = pRAM.NextValue();
            float finet = pINET.NextValue();
            metroProgressBarCPU.Value = (int)fcpu;
            metroProgressBarRAM.Value = (int)fram;
            metroProgressBarINET.Value = (int)finet;
            lblCPU.Text = string.Format("{0:0.00%}", fcpu);
            lblRAM.Text = string.Format("{0:0.00%}", fram);
            lblINET.Text = string.Format("{0:0.00%}", finet);
            chart1.Series["CPU"].Points.AddY(fcpu);
            chart1.Series["RAM"].Points.AddY(fram);
            chart1.Series["INET"].Points.AddY(finet);
        }

        private void metroLabel4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
