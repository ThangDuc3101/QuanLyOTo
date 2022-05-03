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
    public partial class ChucNang : Form
    {
        public ChucNang()
        {
            InitializeComponent();
        }
        Service1Client service1Client;
        private void btnTroVe_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            service1Client = new Service1Client();
            car c = new car()
            {
                Id = Convert.ToInt32(txtID.Text),
                Name = txtName.Text,
                number = Convert.ToInt32(txtNumber.Text),
                price = Convert.ToDecimal(txtPrice.Text),
                original = txtOriginal.Text,                
                daBan = Convert.ToInt32(txtDaban.Text),
                conLai = Convert.ToInt32(txtCoblai.Text)               
            };
            if (service1Client.insertCar(c) > 0) MessageBox.Show("Success");
            else
            {
                MessageBox.Show("Đối tuong thêm không hợp lệ","Thông báo",MessageBoxButtons.YesNo);
            }
            dataGridView1.DataSource = service1Client.getInfo();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            car c = new car()
            {
                Id=Convert.ToInt32(txtID.Text),
                Name=txtName.Text,
                number=Convert.ToInt32(txtNumber.Text),
                original=txtOriginal.Text,
                price = Convert.ToDecimal(txtPrice.Text),
                daBan = Convert.ToInt32(txtDaban.Text),
                conLai = Convert.ToInt32(txtCoblai.Text),
            };
            if (service1Client.editCar(c)>0)
            {
                MessageBox.Show("Sucess");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            car c = new car() { Id = Convert.ToInt32(txtID.Text)};
            
            if (service1Client.deleteCar(c)!=0)
            {
                MessageBox.Show("Success");
            }
        }

        private void ChucNang_Load(object sender, EventArgs e)
        {
            List<car> cars = new List<car>();
            service1Client = new Service1Client();

            dataGridView1.DataSource = service1Client.getInfo();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1[0,e.RowIndex].Value.ToString();
            txtName.Text = dataGridView1[1, e.RowIndex].Value.ToString();
            txtNumber.Text = dataGridView1[4, e.RowIndex].Value.ToString();
            txtPrice.Text = dataGridView1[6, e.RowIndex].Value.ToString();
            txtOriginal.Text = dataGridView1[5, e.RowIndex].Value.ToString();
            txtDaban.Text = dataGridView1[2, e.RowIndex].Value.ToString();
            txtCoblai.Text = dataGridView1[3, e.RowIndex].Value.ToString();
          
        }
    }
}
