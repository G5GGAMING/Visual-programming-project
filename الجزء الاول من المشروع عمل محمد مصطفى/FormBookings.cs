using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CarRentai
{
    public partial class FormBookings : Form
    {
        public FormBookings()
        {
            InitializeComponent();
        }

        private void FormBookings_Load(object sender, EventArgs e)
        {
            string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CarRentalDB.mdf;Integrated Security=True;Connect Timeout=30";

            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();
                string query = @"SELECT b.BookingID, c.Name AS CarName, c.Type AS Company, c.Model, b.Price, b.BookingDate
                         FROM Bookings b
                         INNER JOIN Cars c ON b.CarID = c.CarID
                         ORDER BY b.BookingDate DESC";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }
    }
}