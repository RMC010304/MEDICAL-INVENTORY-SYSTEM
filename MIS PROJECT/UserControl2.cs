﻿using MIS_PROJECT.Properties;
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
    public partial class UserControl2 : UserControl
    {
        public UserControl2()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=MIS;User ID=sa;Password=12345678");

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void UserControl2_Load(object sender, EventArgs e)
        {
            panel1.Hide();
            panel3.Hide();
            panel5.Hide();

            searchData("");
            GetItems();
            
        }



        private void button2_Click(object sender, EventArgs e)
        {


            //Update Button

            if (this.panel3.Visible == false)
            {

                button1.Image = Resources.add_circle_line__2_;
                button3.Image = Resources.delete_bin_6_line__1_;
                button2.Image = Resources.loop_left_line;
                this.panel3.Visible = true;
                panel1.Hide();
                panel5.Hide();
            }
            else if (this.panel3.Visible == true)
            {
                button1.Image = Resources.add_circle_line__2_;
                button3.Image = Resources.delete_bin_6_line__1_;
                button2.Image = Resources.loop_right_line;
                this.panel3.Visible = false;
       


            }

            
            

        }

        private void userControl72_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Delete Button

            if (this.panel5.Visible == false)
            {
                button1.Image = Resources.add_circle_line__2_;
                button2.Image = Resources.loop_right_line;
                button3.Image = Resources.delete_bin_fill;
                this.panel5.Visible = true;
                panel1.Hide() ;
                panel3.Hide() ;
            }
            else if (this.panel5.Visible == true)
            {
                button1.Image = Resources.add_circle_line__2_;
                button2.Image = Resources.loop_right_line;
                button3.Image = Resources.delete_bin_6_line__1_;
                this.panel5.Visible = false;
            }
        }


        private void GetItems()
        {

            SqlConnection con = new SqlConnection(@"Data Source=localhost;Initial Catalog=MIS;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Intakes", con);
            DataTable dt = new DataTable();

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();

            dataGridView1.DataSource = dt;




        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {

            //Add Button

            if (this.panel1.Visible == false)
            {
                button2.Image = Resources.loop_right_line;
                button3.Image = Resources.delete_bin_6_line__1_;
                button1.Image = Resources.indeterminate_circle_line;
                this.panel1.Visible = true;
                panel3.Hide();
                panel5.Hide();
            }
            else if (this.panel1.Visible == true)
            {

                button2.Image = Resources.loop_right_line;
                button3.Image = Resources.delete_bin_6_line__1_;
                button1.Image = Resources.add_circle_line__2_;
                this.panel1.Visible = false;

            }

           

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=MIS;User ID=sa;Password=12345678");
            con.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Intakes ([Items],[Quantity],[Exp_Date],[Added_At]) Values (@Items,@Quantity,@Exp_Date,@Added_At)", con);
            cmd.Parameters.AddWithValue("@Items", textBox3.Text);
            cmd.Parameters.AddWithValue("@Quantity", int.Parse(textBox2.Text));
            cmd.Parameters.AddWithValue("@Exp_Date", (dateTimePicker2.Value));
            cmd.Parameters.AddWithValue("@Added_At", DateTime.Now);

            cmd.ExecuteNonQuery();
            con.Close();

            this.textBox2.Clear();
            this.textBox3.Clear();
           

            MessageBox.Show("Added Succesfully!");
            GetItems();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=MIS;User ID=sa;Password=12345678");
            con.Open();

            SqlCommand cmd = new SqlCommand("UPDATE dbo.Intakes set Items=@Items,Quantity=@Quantity,Exp_Date=@Exp_Date,Added_At=@Added_At WHERE Item_No=@Item_No", con);
            cmd.Parameters.AddWithValue("Item_No", int.Parse(textBox4.Text));
            cmd.Parameters.AddWithValue("@Items", textBox5.Text);
            cmd.Parameters.AddWithValue("@Quantity", int.Parse(textBox6.Text));
            cmd.Parameters.AddWithValue("@Exp_Date", (dateTimePicker1.Value));
            cmd.Parameters.AddWithValue("@Added_At", DateTime.Now);


            cmd.ExecuteNonQuery();
            con.Close();

            this.textBox4.Clear();
            this.textBox5.Clear();
            this.textBox6.Clear();

            MessageBox.Show("Updated Succesfully!");
            GetItems();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button3.Image = Resources.delete_bin_6_line__1_;
            SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=MIS;User ID=sa;Password=12345678");
            con.Open();

            SqlCommand cmd = new SqlCommand("DELETE dbo.Intakes WHERE Item_No=@Item_No", con);
            cmd.Parameters.AddWithValue("Item_No", int.Parse(textBox7.Text));



            cmd.ExecuteNonQuery();
            con.Close();

            this.textBox7.Clear();
          
            GetItems();
            panel5.Hide();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        public void searchData(string valueToFind) 
        { 
        
            string searchQuery = "SELECT * FROM dbo.Intakes WHERE (Items) LIKE '%" +valueToFind+ "%'";
            SqlDataAdapter adapter = new SqlDataAdapter(searchQuery, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panel5.Hide();
            button3.Image = Resources.delete_bin_6_line__1_;
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            searchData(textBox1.Text);
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
          
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
          
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
        
}
