using MIS_PROJECT.Properties;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MIS_PROJECT
{
    public partial class UserControl13 : UserControl
    {

        public UserControl13()
        {
            InitializeComponent();

        }
        Bitmap BitmapToPrint;
        private void CaptureFormShot()
        {
            BitmapToPrint = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(BitmapToPrint, new Rectangle(0,0,this.Width,this.Height));

        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Rectangle m = e.PageBounds;           
            e.Graphics.DrawImage(BitmapToPrint, m);
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CaptureFormShot();
            printPreviewDialog1.WindowState = FormWindowState.Maximized;
            printPreviewDialog1.ShowDialog();
           
        }

        private void GetItems()
        {

            SqlConnection con = new SqlConnection(@"Data Source=localhost;Initial Catalog=MIS;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Patients", con);
            DataTable dt = new DataTable();

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();

            dataGridView1.DataSource = dt;

        }

        void FillChart()
        {
            SqlConnection con = new SqlConnection(@"Data Source=localhost;Initial Catalog=MIS;Integrated Security=True");
            DataTable dt = new DataTable();
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter("SELECT Quantity,Date_Issued FROM dbo.Patients", con);
            da.Fill(dt);
            chart1.DataSource = dt;
            con.Close();

            chart1.Series["Quantity"].XValueMember = "Date_Issued";
            chart1.Series["Quantity"].YValueMembers = "Quantity";


        }

        void FillChart2()
        {
            SqlConnection con = new SqlConnection(@"Data Source=localhost;Initial Catalog=MIS;Integrated Security=True");
            DataTable dt = new DataTable();
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter("SELECT Quantity,Course FROM dbo.Patients", con);
            da.Fill(dt);
            chart2.DataSource = dt;
            con.Close();

            chart2.Series["Quantity"].XValueMember = "Course";
            chart2.Series["Quantity"].YValueMembers = "Quantity";


        }

        public void searchData(string valueToFind)
        {
            SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=MIS;User ID=sa;Password=12345678");
            string searchQuery = "SELECT * FROM dbo.Patients WHERE (Name) LIKE '%" + valueToFind + "%'";
            SqlDataAdapter adapter = new SqlDataAdapter(searchQuery, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

  

        private void UserControl13_Load(object sender, EventArgs e)
        {
            panel1.Hide();
            panel5.Hide();
            GetItems();
            FillChart();
            FillChart2();


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            searchData(textBox1.Text);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            button1.Image = Resources.add_circle_line__2_;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.panel1.Visible == false)
            {

                button3.Image = Resources.delete_bin_6_line__1_;
                button1.Image = Resources.indeterminate_circle_line;
                this.panel1.Visible = true;
                panel5.Hide();
               
            }
            else if (this.panel1.Visible == true)
            {
                button3.Image = Resources.delete_bin_6_line__1_;
                button1.Image = Resources.add_circle_line__2_;
                this.panel1.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.panel5.Visible == false)
            {
                button1.Image = Resources.add_circle_line__2_;
                button3.Image = Resources.delete_bin_fill;
                this.panel5.Visible = true;
                panel1.Hide();
               
            }
            else if (this.panel5.Visible == true)
            {
                button1.Image = Resources.add_circle_line__2_;
                button3.Image = Resources.delete_bin_6_line__1_;

                this.panel5.Visible = false;

            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            panel5.Hide();
            button3.Image = Resources.delete_bin_6_line__1_;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button3.Image = Resources.delete_bin_6_line__1_;
            SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=MIS;User ID=sa;Password=12345678");
            con.Open();

            SqlCommand cmd = new SqlCommand("DELETE dbo.Patients WHERE Student_No=@Student_No", con);
            cmd.Parameters.AddWithValue("Student_No", int.Parse(textBox3.Text));



            cmd.ExecuteNonQuery();
            con.Close();
            GetItems();
            panel5.Hide();
            this.textBox3.Clear();

            chart1.Series["Quantity"].XValueMember = "Date_Issued";
            chart1.Series["Quantity"].YValueMembers = "Quantity";
            chart1.DataBind();

            chart2.Series["Quantity"].XValueMember = "Course";
            chart2.Series["Quantity"].YValueMembers = "Quantity";
            chart2.DataBind();

            FillChart();
            FillChart2();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=MIS;User ID=sa;Password=12345678");
            con.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Patients ([Name],[Course],[Department], [Medicine],[Quantity],[Description],[Date_Issued]) Values (@Name,@Course,@Department,@Medicine,@Quantity,@Description,@Date_Issued)", con);
            cmd.Parameters.AddWithValue("@Name", textBox5.Text);
            cmd.Parameters.AddWithValue("@Course", textBox2.Text);
            cmd.Parameters.AddWithValue("@Department", comboBox2.Text);
            cmd.Parameters.AddWithValue("@Medicine", textBox4.Text);
            cmd.Parameters.AddWithValue("@Quantity", textBox6.Text);
            cmd.Parameters.AddWithValue("@Description", textBox7.Text);
            cmd.Parameters.AddWithValue("@Date_Issued", (dateTimePicker1.Value));


            cmd.ExecuteNonQuery();
            con.Close();
            GetItems();
            this.textBox5.Clear();
            this.textBox2.Clear();
            this.textBox4.Clear();
            this.textBox6.Clear();
            this.textBox7.Clear();

            MessageBox.Show("Saved Succesfully!");

            chart1.Series["Quantity"].XValueMember = "Date_Issued";
            chart1.Series["Quantity"].YValueMembers = "Quantity";
            chart1.DataBind();

            chart2.Series["Quantity"].XValueMember = "Course";
            chart2.Series["Quantity"].YValueMembers = "Quantity";
            chart2.DataBind();

            FillChart();
            FillChart2();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

           
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {
           
        }
    }
}
