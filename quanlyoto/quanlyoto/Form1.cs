using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlyoto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChucNang frm_cn = new ChucNang();
            frm_cn.FormClosing += Frm_about_FormClosing;
            frm_cn.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Timkiem frm_search = new Timkiem();
            frm_search.FormClosing += Frm_about_FormClosing;
            frm_search.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thongke frm_tk = new Thongke();
            frm_tk.FormClosing += Frm_about_FormClosing;
            frm_tk.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            About frm_about = new About();           
            frm_about.FormClosing += Frm_about_FormClosing;
            frm_about.Show();
        }

        private void Frm_about_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }
    }
}
