using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StarcraftBuildOrderApp.simulation;
using StarcraftBuildOrderApp.cost_calc;
using StarcraftBuildOrderApp.tabusearch;


namespace StarcraftBuildOrderApp
{
    public partial class Form1 : Form
    {

        private Label[] unit_label = new Label[6];
        private NumericUpDown[] unit_cnt = new NumericUpDown[6];
        
        private string[] unit_names = new string[] {"NO UNIT", "SCV", "MARINE", "FIREBAT", "GHOST", "VULTURE", "TANK", "GOLIATH", "COMMAND CENTER", "SUPPLY DEPOT", "BARRACKS", "ACADEMY", "FACTORY", "MACHINE SHOP", "ARMORY" };

        private bool stop_iterations = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreatingNewButtons();
            
        }


        private void CreatingNewButtons()
        {
            int vertical = 40;


            for (int i = 0; i < unit_label.Length; i++)
            {
                unit_label[i] = new Label();
                unit_label[i].Size = new Size(80, 40);
                unit_label[i].Location = new Point(40, vertical);
                unit_label[i].Text = unit_names[i+2];


                unit_cnt[i] = new NumericUpDown();
                //unit_cnt[i].Size = new Size(80, 40);
                unit_cnt[i].Location = new Point(120, vertical);
 



                vertical += 50;
                this.Controls.Add(unit_label[i]);
                this.Controls.Add(unit_cnt[i]);
            }
        }



        private void start_btn_Click(object sender, EventArgs e)
        {

            start_btn.Enabled = false;
            stop_btn.Enabled = true;

            cost.fullfill_coef = (float)(1000);
            cost.illegal_coef = (float)(10000);
            cost.ovrload_coef = (float)(10000);
            cost.clear_req_unit();

            time_lbl.Text = "";
            stop_iterations = false;

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < unit_cnt[i].Value; j++)
                {
                    cost.add_build_req((unit_type)(i + 2));
                }
            }

            if (cost.req_count() == 0)
            {
                status_lbl.Text = "Error - no build requirements";
                start_btn.Enabled = true;
                stop_btn.Enabled = false;
                return;
            }

            cost.add_req_unit();
            TabuSearch tabu = new TabuSearch((int)(neig_num.Value), (int)(ret_num.Value), new Solution(20));
            tabu.setOperationsProbability((int)(add_num.Value), (int)(exch_num.Value), (int)(del_num.Value));
            Solution s = tabu.iterate(tabu.bestSolution);

            int iter_num = (int)(iteration_num.Value);

            for (int i = 0; i < iter_num && !stop_iterations; i++)
            {
                s = tabu.iterate(s);
                status_lbl.Text = "Best score: " + tabu.bestSolutionValue + ", \t" + (int)(i + 1) + "/" + iter_num;
                Application.DoEvents();

            }


            time_lbl.Text = "Best time: " + cost.calc_time(tabu.bestSolution.getEnums());

            sol_list.Items.Clear();

            for (int i = 0; i < tabu.bestSolution.getItemsQuantity(); i++)
            {
                sol_list.Items.Add( unit_names[(int)(tabu.bestSolution.getEnums()[i])] );
            }


            //sol_lbl.Text = tabu.bestSolution.ToString();

            start_btn.Enabled = true;
            stop_btn.Enabled = false;
        }

    


        private void change_num(NumericUpDown second, NumericUpDown third)
        {
            int sum = (int)(add_num.Value + exch_num.Value + del_num.Value);
            int nxt = (int)(second.Value);

            if ((nxt - (sum - 100)) < 1)
            {
                second.Value = 1;
                third.Value -= (sum - 100);
            }
            else
            {
                second.Value = nxt - (sum - 100);
            }
        }

        private void add_num_ValueChanged(object sender, EventArgs e)
        {
            change_num(exch_num, del_num);
           
         
        }

        private void exch_num_ValueChanged(object sender, EventArgs e)
        {
            change_num(del_num, add_num);
           
        }

        private void del_num_ValueChanged(object sender, EventArgs e)
        {
            change_num(add_num, exch_num);
        }

        private void stop_btn_Click(object sender, EventArgs e)
        {
            stop_iterations = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            stop_iterations = true;
        }









    }
}
