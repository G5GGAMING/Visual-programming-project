using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentai
{
    public partial class FormTypes : Form
    {
        private Form1 _mainForm;
        public FormTypes(Form1 mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;//حفظ المرجع
        }

        private void btnHYUNDAI_Click(object sender, EventArgs e)
        {
            FormHYUNDAI hyundai = new FormHYUNDAI(this);
            hyundai.Show();
            this.Hide();
        }

        private void btnTOYOTA_Click(object sender, EventArgs e)
        {
            FormTOYOTA toyotaForm = new FormTOYOTA(this);
            toyotaForm.Show();
            this.Hide();
        }

        private void btnMERCEDES_Click(object sender, EventArgs e)
        {
            FormMERCEDES mer = new FormMERCEDES(this);
            mer.Show();
            this.Hide();
        }

        private void btnNISSAN_Click(object sender, EventArgs e)
        {
            FormNISSAN nissanForm = new FormNISSAN(this);
            nissanForm.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _mainForm.Show();
            this.Hide();
            
        }

        private void btnViewBookings_Click(object sender, EventArgs e)
        {
            FormBookings bookingsForm = new FormBookings();
            bookingsForm.ShowDialog(); // عرض الفورم كنافذة مستقلة
        
    }
    }
}
