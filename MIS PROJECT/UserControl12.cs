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

namespace MIS_PROJECT
{
    public partial class UserControl12 : UserControl
    {
        public UserControl12()
        {
            InitializeComponent();
        }

        private void GetItems()
        {

            SqlConnection con = new SqlConnection(@"Data Source=localhost;Initial Catalog=MIS;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT Items,Quantity FROM (SELECT Items,Quantity FROM dbo.Intakes UNION ALL SELECT Items,Quantity FROM dbo.MedicalTapes2 UNION ALL SELECT Items,Quantity FROM dbo.Topicals2 UNION ALL SELECT Items,Quantity FROM Disinfectants2 UNION ALL SELECT Items,Quantity FROM Equipments3) a", con);
            DataTable dt = new DataTable();

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();

            dataGridView1.DataSource = dt;

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void UserControl12_Load(object sender, EventArgs e)
        {
            GetItems();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=MIS;User ID=sa;Password=12345678");
            con.Open();

            con.Close();

            GetItems();
        }
    }
}
