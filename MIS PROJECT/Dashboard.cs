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
using System.Windows.Forms.DataVisualization.Charting;

namespace MIS_PROJECT
{

    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();


        }

        void FillChart()
        {
            SqlConnection con = new SqlConnection(@"Data Source=localhost;Initial Catalog=MIS;Integrated Security=True");
            DataTable dt = new DataTable();
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter("SELECT Items,Quantity FROM (SELECT Items,Quantity FROM dbo.Intakes UNION ALL SELECT Items,Quantity FROM dbo.MedicalTapes2 UNION ALL SELECT Items,Quantity FROM dbo.Topicals2 UNION ALL SELECT Items,Quantity FROM Disinfectants2 UNION ALL SELECT Items,Quantity FROM Equipments3) a", con);
            da.Fill(dt);
            chart1.DataSource = dt;
            con.Close();

            chart1.Series["Quantity"].XValueMember = "Items";
            chart1.Series["Quantity"].YValueMembers = "Quantity";


        }

        void FillChart1()
        {
            SqlConnection con = new SqlConnection(@"Data Source=localhost;Initial Catalog=MIS;Integrated Security=True");
            DataTable dt = new DataTable();
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter("SELECT Items,Quantity FROM dbo.Intakes", con);
            da.Fill(dt);
            chart2.DataSource = dt;
            con.Close();

            chart2.Series["Quantity"].XValueMember = "Items";
            chart2.Series["Quantity"].YValueMembers = "Quantity";


        }

        void FillChart2()
        {
            SqlConnection con = new SqlConnection(@"Data Source=localhost;Initial Catalog=MIS;Integrated Security=True");
            DataTable dt = new DataTable();
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter("SELECT Items,Quantity FROM dbo.MedicalTapes2", con);
            da.Fill(dt);
            chart3.DataSource = dt;
            con.Close();

            chart3.Series["Quantity"].XValueMember = "Items";
            chart3.Series["Quantity"].YValueMembers = "Quantity";


        }

        void FillChart3()
        {
            SqlConnection con = new SqlConnection(@"Data Source=localhost;Initial Catalog=MIS;Integrated Security=True");
            DataTable dt = new DataTable();
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter("SELECT Items,Quantity FROM dbo.Topicals2", con);
            da.Fill(dt);
            chart4.DataSource = dt;
            con.Close();

            chart4.Series["Quantity"].XValueMember = "Items";
            chart4.Series["Quantity"].YValueMembers = "Quantity";


        }

        void FillChart4()
        {
            SqlConnection con = new SqlConnection(@"Data Source=localhost;Initial Catalog=MIS;Integrated Security=True");
            DataTable dt = new DataTable();
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter("SELECT Items,Quantity FROM dbo.Disinfectants2", con);
            da.Fill(dt);
            chart5.DataSource = dt;
            con.Close();

            chart5.Series["Quantity"].XValueMember = "Items";
            chart5.Series["Quantity"].YValueMembers = "Quantity";


        }

        void FillChart5()
        {
            SqlConnection con = new SqlConnection(@"Data Source=localhost;Initial Catalog=MIS;Integrated Security=True");
            DataTable dt = new DataTable();
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter("SELECT Items,Quantity FROM dbo.Equipments3", con);
            da.Fill(dt);
            chart6.DataSource = dt;
            con.Close();

            chart6.Series["Quantity"].XValueMember = "Items";
            chart6.Series["Quantity"].YValueMembers = "Quantity";


        }



        private void Form2_Load(object sender, EventArgs e)
        {

            //For Automatic FullScreen
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);

            Default();
            userControl72.Hide();
            userControl81.Hide();
            userControl91.Hide();
            userControl101.Hide();
            userControl111.Hide();
            userControl121.Hide();
            userControl131.Hide();
            panel10.Hide();


            FillChart();
            FillChart1();
            FillChart2();
            FillChart3();
            FillChart4();
            FillChart5();


            panel9.Height = button8.Height;
            panel9.Top = button8.Top;



        }

        bool Dropdown = false;


        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Back
            this.Close();
            Dashboard back = new Dashboard();
            back.Show();
            back.Close();
        }

        private void Default()
        {
            panel1.Height = 0;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //TOPICALS
            userControl121.Hide();
            userControl111.Hide();
            userControl101.Hide();
            userControl91.Hide();
            userControl81.Hide();
            userControl72.Hide();
            userControl11.Hide();
            userControl22.Hide();
            userControl32.Hide();
            userControl51.Hide();
            userControl62.Hide();
            userControl42.Show();
            userControl42.BringToFront();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }

        private void button1_Click_3(object sender, EventArgs e)
        {

        }

        private void button1_Click_4(object sender, EventArgs e)
        {



        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

            panel9.Height = button8.Height;
            panel9.Top = button8.Top;
            userControl11.Hide();
            userControl22.Hide();
            userControl32.Hide();
            userControl42.Hide();
            userControl51.Hide();
            userControl62.Hide();
            panel2.Show();
            panel2.BringToFront();

            chart1.Series["Quantity"].XValueMember = "Items";
            chart1.Series["Quantity"].YValueMembers = "Quantity";
            chart1.DataBind();

            chart2.Series["Quantity"].XValueMember = "Items";
            chart2.Series["Quantity"].YValueMembers = "Quantity";
            chart2.DataBind();

            chart3.Series["Quantity"].XValueMember = "Items";
            chart3.Series["Quantity"].YValueMembers = "Quantity";
            chart3.DataBind();

            chart4.Series["Quantity"].XValueMember = "Items";
            chart4.Series["Quantity"].YValueMembers = "Quantity";
            chart4.DataBind();

            chart5.Series["Quantity"].XValueMember = "Items";
            chart5.Series["Quantity"].YValueMembers = "Quantity";
            chart5.DataBind();

            chart6.Series["Quantity"].XValueMember = "Items";
            chart6.Series["Quantity"].YValueMembers = "Quantity";
            chart6.DataBind();

            FillChart();
            FillChart1();
            FillChart2();
            FillChart3();
            FillChart4();
            FillChart5();


        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //INTAKES
            userControl121.Hide();
            userControl111.Hide();
            userControl101.Hide();
            userControl91.Hide();
            userControl81.Hide();
            userControl72.Hide();
            userControl11.Hide();
            userControl32.Hide();
            userControl42.Hide();
            userControl51.Hide();
            userControl62.Hide();
            userControl22.Show();
            userControl22.BringToFront();




        }

        private void button3_Click(object sender, EventArgs e)
        {
            //MEDICAL TAPES

            userControl121.Hide();
            userControl111.Hide();
            userControl101.Hide();
            userControl91.Hide();
            userControl81.Hide();
            userControl72.Hide();
            userControl11.Hide();
            userControl22.Hide();
            userControl42.Hide();
            userControl51.Hide();
            userControl62.Hide();
            userControl32.Show();
            userControl32.BringToFront();


        }

        private void button5_Click(object sender, EventArgs e)
        {
            //DISINFECTANTS
            userControl121.Hide();
            userControl111.Hide();
            userControl101.Hide();
            userControl91.Hide();
            userControl81.Hide();
            userControl72.Hide();
            userControl11.Hide();
            userControl22.Hide();
            userControl32.Hide();
            userControl42.Hide();
            userControl62.Hide();
            userControl51.Show();
            userControl51.BringToFront();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //MEDICAL EQUIPMENTS
            userControl121.Hide();
            userControl111.Hide();
            userControl101.Hide();
            userControl91.Hide();
            userControl81.Hide();
            userControl72.Hide();
            userControl11.Hide();
            userControl22.Hide();
            userControl32.Hide();
            userControl42.Hide();
            userControl51.Hide();
            userControl62.Show();
            userControl62.BringToFront();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //ABOUT
            userControl121.Hide();
            userControl111.Hide();
            userControl91.Hide();
            userControl81.Hide();
            userControl72.Hide();
            userControl101.Hide();
            panel9.Height = button9.Height;
            panel9.Top = button9.Top;
            userControl62.Hide();
            userControl22.Hide();
            userControl32.Hide();
            userControl42.Hide();
            userControl51.Hide();
            userControl11.Show();
            userControl11.BringToFront();
        }

        private void userControl32_Load(object sender, EventArgs e)
        {

        }

        private void Animation_Tick(object sender, EventArgs e)
        {

            //DROPDOWN EFFECT
            if (Dropdown == true)
            {
                panel1.Height += 8;
            }


            else if (Dropdown == false)
            {
                panel1.Height -= 8;
            }

        }

        private void button8_MouseEnter(object sender, EventArgs e)
        {
            button8.Size = new Size(459, 59);
            button8.Location = new Point(-72, 330);
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
            button8.Size = new Size(423, 59);
            button8.Location = new Point(-72, 330);
        }

        private void button7_MouseEnter(object sender, EventArgs e)
        {
            button7.Size = new Size(459, 59);
            button7.Location = new Point(-90, 386);
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            button7.Size = new Size(423, 59);
            button7.Location = new Point(-90, 386);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            userControl121.Hide();
            userControl111.Hide();
            userControl101.Hide();
            userControl91.Hide();
            userControl81.Hide();
            userControl72.Hide();
            panel9.Height = button7.Height;
            panel9.Top = button7.Top;
            userControl11.Hide();
            userControl22.Hide();
            userControl32.Hide();
            userControl42.Hide();
            userControl51.Hide();
            userControl62.Hide();
            panel2.Hide();
            panel10.Show();
            userControl131.Show();





        }

        private void button7_MouseLeave_1(object sender, EventArgs e)
        {

        }

        private void button9_MouseEnter(object sender, EventArgs e)
        {
            button9.Size = new Size(459, 59);
            button9.Location = new Point(-89, 797);
        }

        private void button9_MouseLeave(object sender, EventArgs e)
        {
            button9.Size = new Size(423, 59);
            button9.Location = new Point(-89, 797);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel9.Height = button10.Height;
            panel9.Top = button10.Top;

            if (Dropdown == true)
            {
                Dropdown = false;
            }


            else if (Dropdown == false)
            {
                Dropdown = true;
            }
        }

        private void button10_MouseEnter(object sender, EventArgs e)
        {
            button10.Size = new Size(459, 59);
            button10.Location = new Point(-80, 443);
        }

        private void button10_MouseLeave(object sender, EventArgs e)
        {
            button10.Size = new Size(423, 59);
            button10.Location = new Point(-80, 443);
        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=localhost;Initial Catalog=MIS;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT SUM (Quantity) FROM dbo.Intakes", conn);
            SqlCommand cmd2 = new SqlCommand("SELECT SUM (Quantity) FROM dbo.MedicalTapes2", conn);
            SqlCommand cmd3 = new SqlCommand("SELECT SUM (Quantity)  FROM dbo.Topicals2", conn);
            SqlCommand cmd4 = new SqlCommand("SELECT SUM (Quantity) FROM dbo.Disinfectants2", conn);
            SqlCommand cmd5 = new SqlCommand("SELECT SUM (Quantity) FROM dbo.Equipments3", conn);
            SqlCommand cmd6 = new SqlCommand("SELECT SUM (Quantity) FROM (SELECT Quantity FROM dbo.Intakes UNION ALL SELECT Quantity FROM dbo.MedicalTapes2 UNION ALL SELECT Quantity FROM dbo.Topicals2 UNION ALL SELECT Quantity FROM Disinfectants2 UNION ALL SELECT Quantity FROM Equipments3) a", conn);


            var count1 = cmd.ExecuteScalar();
            var count2 = cmd2.ExecuteScalar();
            var count3 = cmd3.ExecuteScalar();
            var count4 = cmd4.ExecuteScalar();
            var count5 = cmd5.ExecuteScalar();
            var count6 = cmd6.ExecuteScalar();



            label2.Text = count1.ToString();
            label7.Text = count2.ToString();
            label8.Text = count3.ToString();
            label11.Text = count4.ToString();
            label14.Text = count5.ToString();
            label19.Text = count6.ToString();


            conn.Close();







        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            //Intakes
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {
            userControl121.Hide();
            userControl111.Hide();
            userControl101.Hide();
            userControl91.Hide();
            userControl72.Hide();
            userControl81.Show();
        }

        private void label20_Click(object sender, EventArgs e)
        {
            userControl121.Hide();
            userControl111.Hide();
            userControl101.Hide();
            userControl91.Hide();
            userControl81.Hide();
            userControl72.Show();

        }

        private void userControl71_Load(object sender, EventArgs e)
        {

        }

        private void userControl72_Load(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {
            userControl72.Hide();
            userControl81.Hide();
            userControl101.Hide();
            userControl111.Hide();
            userControl121.Hide();
            userControl91.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }



        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label21_Click_1(object sender, EventArgs e)
        {
            userControl72.Hide();
            userControl81.Hide();
            userControl91.Hide();
            userControl111.Hide();
            userControl121.Hide();
            userControl101.Show();
        }

        private void label23_Click(object sender, EventArgs e)
        {
            userControl72.Hide();
            userControl81.Hide();
            userControl91.Hide();
            userControl101.Hide();
            userControl121.Hide();
            userControl111.Show();
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }
       


            private void label25_Click(object sender, EventArgs e)
        {
           
            userControl72.Hide();
            userControl81.Hide();
            userControl91.Hide();
            userControl101.Hide();
            userControl111.Hide();
            userControl121.Show();
        }

        private void chart5_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void chart3_Click(object sender, EventArgs e)
        {

        }

        private void chart4_Click(object sender, EventArgs e)
        {

        }

        private void chart6_Click(object sender, EventArgs e)
        {

        }

        private void chart3_Click_1(object sender, EventArgs e)
        {

        }

        private void chart5_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }
    }
}