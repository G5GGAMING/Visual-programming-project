using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CarRentai
{
    public partial class FormHYUNDAI : Form
    {
        private FormTypes _typesForm;

        public FormHYUNDAI(FormTypes typesForm)
        {
            InitializeComponent();
            _typesForm = typesForm;   // حفظ مرجع الفورم الأساسي
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _typesForm.Show();
            this.Hide();
        }

        private void btnSONATA_Click(object sender, EventArgs e)
        {
            AddBooking("Sonata");
        }

        private void AddBooking(string carName)
        {
            string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;
                   AttachDbFilename=D:\Mohammed Mustafa\A\CarRentai\CarRentai\CarRentalBD.mdf;
                   Integrated Security=True;Connect Timeout=30";
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();

                string queryCar = "SELECT CarID, RentPrice FROM Cars WHERE Name = @Name";
                SqlCommand cmdCar = new SqlCommand(queryCar, con);
                cmdCar.Parameters.AddWithValue("@Name", carName);

                SqlDataReader reader = cmdCar.ExecuteReader();

                if (reader.Read())
                {
                    int carID = (int)reader["CarID"];
                    decimal price = (decimal)reader["RentPrice"];
                    reader.Close();

                    string insertBooking = "INSERT INTO Bookings (CarID, Price) VALUES (@CarID, @Price)";
                    SqlCommand cmdBooking = new SqlCommand(insertBooking, con);
                    cmdBooking.Parameters.AddWithValue("@CarID", carID);
                    cmdBooking.Parameters.AddWithValue("@Price", price);
                    cmdBooking.ExecuteNonQuery();

                    MessageBox.Show("✔ تم حجز السيارة بنجاح!");

                    // فتح الفورم لعرض جميع الحجوزات
                    FormBookings bookingsForm = new FormBookings();
                    bookingsForm.ShowDialog();
                }
            }
        }

        

           private void btnTUCSON_Click(object sender, EventArgs e)
           {
               
           }

           private void btnELANTRA_Click(object sender, EventArgs e)
           {
               AddBooking("Elantra");
           }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void FormHYUNDAI_Load(object sender, EventArgs e)
        {

        }
    }
}
