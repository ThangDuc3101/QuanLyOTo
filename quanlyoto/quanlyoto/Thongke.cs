using quanlyoto.ServiceReference1;
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
    public partial class Thongke : Form
    {
        public Thongke()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muôn thoát","Thông báo",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                this.Close();
            }
        }

        Service1Client Service1Client =  new Service1Client();
        car c;

        private void button1_Click(object sender, EventArgs e)
        {
            c = new car();
            dataGridView1.DataSource = Service1Client.banDuoc();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            c = new car();
            dataGridView1.DataSource = Service1Client.conlai();
        }
    }
}
