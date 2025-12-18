using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CarRentai
{
    public partial class FormMERCEDES : Form
    {
        private FormTypes _typesForm;

        public FormMERCEDES()
        {
            InitializeComponent();
        }

        public FormMERCEDES(FormTypes typesForm) : this()
        {
            _typesForm = typesForm;
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            if (_typesForm != null)
            {
                _typesForm.Show();
            }
            this.Hide();
        }

        // ========== دالة حفظ الحجز ==========
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
        

        // ========== أزرار السيارات ==========
        private void btnCCLASS_Click(object sender, EventArgs e)
        {
            AddBooking("C-CLASS");
        }

        private void btnGCLASS_Click(object sender, EventArgs e)
        {
            AddBooking("G-CLASS");
        }

        private void btnSCLASS_Click(object sender, EventArgs e)
        {
            AddBooking("S-CLASS");
        }
    }
}