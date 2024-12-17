using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eşleştirme_Oyunu
{
    public partial class Form1 : Form
    {
        List<string> icons = new List<string>()
        {
           "!",",","b","k","v","w","z","N",
           "!",",","b","k","v","w","z","N"
        };
        Random rnd = new Random();
        int randomindex;

        Timer t = new Timer();
        Timer t2 = new Timer();
        Button first, second;
        public Form1()
        {
            InitializeComponent();
            t.Tick += T_Tick;
            t.Start();
            t.Interval = 1000;
            show();
            t2.Tick += T2_Tick;
        }

        private void T2_Tick(object sender, EventArgs e)
        {
            t2.Stop();
            first.ForeColor = first.BackColor;
            second.ForeColor = second.BackColor;
            first = null;
            second = null;
        }

        private void T_Tick(object sender, EventArgs e)
        {
            t.Stop();
            foreach (Button item in Controls)
            {
                item.ForeColor = item.BackColor;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void show()
        {
            Button btn;
            foreach (Button item in Controls)
            {
                btn = item as Button;
                randomindex = rnd.Next(icons.Count);
                btn.Text = icons[randomindex];
                btn.ForeColor = Color.Black;
                icons.RemoveAt(randomindex);
            }
        }
        int sayac = 0;
        private void Buton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (first==null)
            {
                first = btn;
                first.ForeColor = Color.Black;
                return;
            }
            second = btn;
            second.ForeColor = Color.Black;
            if (first.Text==second.Text)
            {
                first.ForeColor = Color.Black;
                second.ForeColor = Color.Black;
                first = null;
                second = null;
                sayac++;
                if (sayac==8)
                {
                    MessageBox.Show("Kazandınız Tebrikler.");
                    Close();
                }
            }
            else
            {
                t2.Start();
                t2.Interval = 1000;
            }
        }
    }
}
