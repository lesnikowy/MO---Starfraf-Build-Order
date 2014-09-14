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

        public static  float[] local_score;
        public static float[] best_score;
        public static int iterations_done;

        private string[] unit_names = new string[] {"NO UNIT", "SCV", "MARINE", "FIREBAT", "GHOST", "VULTURE", "TANK", "GOLIATH", "COMMAND CENTER", "SUPPLY DEPOT", "BARRACKS", "ACADEMY", "FACTORY", "MACHINE SHOP", "ARMORY" };

        private bool stop_iterations = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateNewControls();
            for (int i = 1; i < (unit_names.Count() - 1); i++)
            {
                unit_cmb.Items.Add(unit_names[i]);
            }
            
        }


        private void CreateNewControls()
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


        private List<unit_type> generate_from_init_sol()
        {
            List<unit_type> tmp_units = new List<unit_type>();

            for (int i = 0; i < init_sol_list.Items.Count; i++)
            {
                for (int j = 1; j < (unit_names.Count() - 1); j++)
                {
                    if (init_sol_list.Items[i].ToString() == unit_names[j])
                    {
                        tmp_units.Add((unit_type)(j));
                        break;
                    }
                }
            }

            return tmp_units;
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

            Solution init_solution;

            if (rand_sol_chck.Checked)
            {
                init_solution = new Solution((int)(init_size_num.Value));
            }
            else
            {
                if (init_sol_list.Items.Count == 0)
                {
                    status_lbl.Text = "Error - no initial solution";
                    start_btn.Enabled = true;
                    stop_btn.Enabled = false;
                    return;

                }




                init_solution = new Solution(generate_from_init_sol());
                
            }

            TabuSearch tabu = new TabuSearch((int)(neig_num.Value), (int)(ret_num.Value), init_solution);
            tabu.setOperationsProbability((int)(add_num.Value), (int)(exch_num.Value), (int)(del_num.Value));
            Solution s = tabu.iterate(tabu.bestSolution);

            int iter_num = (int)(iteration_num.Value);
             local_score = new float[iter_num];
             best_score = new float[iter_num];
             iterations_done = 0;

             int iter;

             for (iter = 0; iter < iter_num && !stop_iterations; iter++)
            {
                s = tabu.iterate(s);
                local_score[iter] = s.cost;
                best_score[iter] = tabu.bestSolutionValue;
                status_lbl.Text = "Best score: " + tabu.bestSolutionValue + ", \t" + (int)(iter + 1) + "/" + iter_num;
                
                Application.DoEvents();

            }
             iterations_done = iter;

            int build_time = cost.calc_time(tabu.bestSolution.getEnums());

            if (build_time > 0)
            {

                TimeSpan t = TimeSpan.FromSeconds(build_time);

                time_lbl.Text = "Best time: " + t.Minutes + ":" + t.Seconds.ToString("00");
            }
            else
            {
                time_lbl.Text = "Can`t calculate build time";
            }

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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (rand_sol_chck.Checked)
            {
                this.Width = 750;
            }
            else
            {
                this.Width = 946;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (init_sol_list.SelectedIndex >= 0)
            {
                init_sol_list.Items.Insert(init_sol_list.SelectedIndex, unit_cmb.Text);
            }
            else
            {
                init_sol_list.Items.Add(unit_cmb.Text);
            }
           
        }

        private void init_sol_list_DoubleClick(object sender, EventArgs e)
        {
            if (init_sol_list.SelectedIndex >= 0)
            {
                init_sol_list.Items.RemoveAt(init_sol_list.SelectedIndex);
            }
        }

        private void rnd_btn_Click(object sender, EventArgs e)
        {
            init_sol_list.Items.Clear();

            Random rnd = new Random();

            for (int i = 0; i < init_size_num.Value; i++)
            {
                init_sol_list.Items.Add(unit_names[rnd.Next(1,unit_names.Count())]);
            }
        }

        private void clc_sc_init_btn_Click(object sender, EventArgs e)
        {
            cost.fullfill_coef = (float)(1000);
            cost.illegal_coef = (float)(10000);
            cost.ovrload_coef = (float)(10000);
            cost.clear_req_unit();


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

            List<unit_type> tmp_unit = generate_from_init_sol();

            init_status_lbl.Text = "Score: " + cost.calc(tmp_unit);

            int build_time = cost.calc_time(tmp_unit);

            if (build_time > 0)
            {

                TimeSpan t = TimeSpan.FromSeconds(build_time);

                init_time_lbl.Text = "Time: " + t.Minutes + ":" + t.Seconds.ToString("00");
            }
            else
            {
                init_time_lbl.Text = "Can`t calculate build time";
            }
        }

        private void show_graph_btn_Click(object sender, EventArgs e)
        {
            Form2 graph_frm = new Form2();

            graph_frm.Show();
        }









    }
}
