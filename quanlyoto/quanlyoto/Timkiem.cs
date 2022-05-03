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
    public partial class Timkiem : Form
    {
        public Timkiem()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Bạn có chắc muôn thoát", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           Service1Client service1Client = new Service1Client();
            car c = new car() { Id = Convert.ToInt32(textBox1.Text)};
            if (service1Client.findCar(c)!=0)
            {
                MessageBox.Show("Success");
                dataGridView1.DataSource = service1Client.getSelect(c);
            }

        }
    }
}
