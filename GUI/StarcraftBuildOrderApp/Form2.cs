using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StarcraftBuildOrderApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            chart1.Location = new Point(0, 0);
            chart1.Width = this.Width;
            chart1.Height = this.Height;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Form1.iterations_done; i++)
            {
                chart1.Series[0].Points.AddXY(i, Form1.local_score[i]);
                chart1.Series[1].Points.AddXY(i, Form1.best_score[i]);
            }

        }

        private void Form2_ResizeEnd(object sender, EventArgs e)
        {
            chart1.Width = this.Width;
            chart1.Height = this.Height;
        }
    }
}
