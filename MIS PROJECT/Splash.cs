﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIS_PROJECT
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 7;
            if (panel2.Width >= 979)
            {
                timer1.Stop();
                Form1 f1 = new Form1();
                f1.Show();
                this.Hide();
            }
        }

        private void Splash_Load(object sender, EventArgs e)
        {

        }
    }
}
