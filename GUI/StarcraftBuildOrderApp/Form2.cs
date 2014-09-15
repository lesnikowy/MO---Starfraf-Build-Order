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
        private const float MAX_VALUE = 100000;
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

                if (Form1.local_score[i] <= 0 || Form1.best_score[i] <= 0)
                {
                    continue;
                }

               chart1.Series[0].Points.AddXY(i, Form1.local_score[i]);
                
                chart1.Series[1].Points.AddXY(i, Form1.best_score[i]);
            }

            chart1.ChartAreas[0].RecalculateAxesScale();
            chart1.ChartAreas[0].AxisY.IsStartedFromZero = false;

            

        }

        private void Form2_ResizeEnd(object sender, EventArgs e)
        {
            chart1.Width = this.Width;
            chart1.Height = this.Height;
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
