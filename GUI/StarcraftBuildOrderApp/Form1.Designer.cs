namespace StarcraftBuildOrderApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.start_btn = new System.Windows.Forms.Button();
            this.status_lbl = new System.Windows.Forms.Label();
            this.sol_list = new System.Windows.Forms.ListBox();
            this.iteration_num = new System.Windows.Forms.NumericUpDown();
            this.lbl1 = new System.Windows.Forms.Label();
            this.time_lbl = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.del_num = new System.Windows.Forms.NumericUpDown();
            this.exch_num = new System.Windows.Forms.NumericUpDown();
            this.add_num = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ret_num = new System.Windows.Forms.NumericUpDown();
            this.neig_num = new System.Windows.Forms.NumericUpDown();
            this.stop_btn = new System.Windows.Forms.Button();
            this.rand_sol_chck = new System.Windows.Forms.CheckBox();
            this.init_sol_list = new System.Windows.Forms.ListBox();
            this.unit_cmb = new System.Windows.Forms.ComboBox();
            this.init_size_num = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.rnd_btn = new System.Windows.Forms.Button();
            this.clc_sc_init_btn = new System.Windows.Forms.Button();
            this.init_time_lbl = new System.Windows.Forms.Label();
            this.init_status_lbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.iteration_num)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.del_num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exch_num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.add_num)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ret_num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neig_num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.init_size_num)).BeginInit();
            this.SuspendLayout();
            // 
            // start_btn
            // 
            this.start_btn.Location = new System.Drawing.Point(319, 49);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(64, 41);
            this.start_btn.TabIndex = 0;
            this.start_btn.Text = "START";
            this.start_btn.UseVisualStyleBackColor = true;
            this.start_btn.Click += new System.EventHandler(this.start_btn_Click);
            // 
            // status_lbl
            // 
            this.status_lbl.AutoSize = true;
            this.status_lbl.Location = new System.Drawing.Point(323, 109);
            this.status_lbl.Name = "status_lbl";
            this.status_lbl.Size = new System.Drawing.Size(60, 13);
            this.status_lbl.TabIndex = 1;
            this.status_lbl.Text = "Best score:";
            // 
            // sol_list
            // 
            this.sol_list.FormattingEnabled = true;
            this.sol_list.Location = new System.Drawing.Point(326, 159);
            this.sol_list.Name = "sol_list";
            this.sol_list.Size = new System.Drawing.Size(128, 186);
            this.sol_list.TabIndex = 2;
            // 
            // iteration_num
            // 
            this.iteration_num.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.iteration_num.Location = new System.Drawing.Point(583, 49);
            this.iteration_num.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.iteration_num.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.iteration_num.Name = "iteration_num";
            this.iteration_num.Size = new System.Drawing.Size(127, 20);
            this.iteration_num.TabIndex = 3;
            this.iteration_num.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(524, 51);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(53, 13);
            this.lbl1.TabIndex = 4;
            this.lbl1.Text = "Iterations:";
            // 
            // time_lbl
            // 
            this.time_lbl.AutoSize = true;
            this.time_lbl.Location = new System.Drawing.Point(323, 130);
            this.time_lbl.Name = "time_lbl";
            this.time_lbl.Size = new System.Drawing.Size(0, 13);
            this.time_lbl.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.del_num);
            this.groupBox1.Controls.Add(this.exch_num);
            this.groupBox1.Controls.Add(this.add_num);
            this.groupBox1.Location = new System.Drawing.Point(518, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(214, 109);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Probability generated movements";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "DELETE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "EXCHANGE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "ADD";
            // 
            // del_num
            // 
            this.del_num.Location = new System.Drawing.Point(129, 77);
            this.del_num.Maximum = new decimal(new int[] {
            98,
            0,
            0,
            0});
            this.del_num.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.del_num.Name = "del_num";
            this.del_num.Size = new System.Drawing.Size(50, 20);
            this.del_num.TabIndex = 2;
            this.del_num.TabStop = false;
            this.del_num.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.del_num.ValueChanged += new System.EventHandler(this.del_num_ValueChanged);
            // 
            // exch_num
            // 
            this.exch_num.Location = new System.Drawing.Point(129, 51);
            this.exch_num.Maximum = new decimal(new int[] {
            98,
            0,
            0,
            0});
            this.exch_num.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.exch_num.Name = "exch_num";
            this.exch_num.Size = new System.Drawing.Size(50, 20);
            this.exch_num.TabIndex = 1;
            this.exch_num.TabStop = false;
            this.exch_num.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.exch_num.ValueChanged += new System.EventHandler(this.exch_num_ValueChanged);
            // 
            // add_num
            // 
            this.add_num.Location = new System.Drawing.Point(129, 25);
            this.add_num.Maximum = new decimal(new int[] {
            98,
            0,
            0,
            0});
            this.add_num.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.add_num.Name = "add_num";
            this.add_num.Size = new System.Drawing.Size(50, 20);
            this.add_num.TabIndex = 0;
            this.add_num.TabStop = false;
            this.add_num.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.add_num.ValueChanged += new System.EventHandler(this.add_num_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.ret_num);
            this.groupBox2.Controls.Add(this.neig_num);
            this.groupBox2.Location = new System.Drawing.Point(516, 221);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(215, 71);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Taboo search";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Retention";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Neighbours number";
            // 
            // ret_num
            // 
            this.ret_num.Location = new System.Drawing.Point(131, 45);
            this.ret_num.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ret_num.Name = "ret_num";
            this.ret_num.Size = new System.Drawing.Size(50, 20);
            this.ret_num.TabIndex = 2;
            this.ret_num.TabStop = false;
            this.ret_num.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // neig_num
            // 
            this.neig_num.Location = new System.Drawing.Point(131, 19);
            this.neig_num.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.neig_num.Name = "neig_num";
            this.neig_num.Size = new System.Drawing.Size(50, 20);
            this.neig_num.TabIndex = 1;
            this.neig_num.TabStop = false;
            this.neig_num.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // stop_btn
            // 
            this.stop_btn.Enabled = false;
            this.stop_btn.Location = new System.Drawing.Point(389, 49);
            this.stop_btn.Name = "stop_btn";
            this.stop_btn.Size = new System.Drawing.Size(65, 41);
            this.stop_btn.TabIndex = 8;
            this.stop_btn.Text = "STOP";
            this.stop_btn.UseVisualStyleBackColor = true;
            this.stop_btn.Click += new System.EventHandler(this.stop_btn_Click);
            // 
            // rand_sol_chck
            // 
            this.rand_sol_chck.AutoSize = true;
            this.rand_sol_chck.Checked = true;
            this.rand_sol_chck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rand_sol_chck.Location = new System.Drawing.Point(527, 308);
            this.rand_sol_chck.Name = "rand_sol_chck";
            this.rand_sol_chck.Size = new System.Drawing.Size(142, 17);
            this.rand_sol_chck.TabIndex = 9;
            this.rand_sol_chck.Text = "Randomize inital solution";
            this.rand_sol_chck.UseVisualStyleBackColor = true;
            this.rand_sol_chck.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // init_sol_list
            // 
            this.init_sol_list.FormattingEnabled = true;
            this.init_sol_list.Location = new System.Drawing.Point(770, 45);
            this.init_sol_list.Name = "init_sol_list";
            this.init_sol_list.Size = new System.Drawing.Size(133, 212);
            this.init_sol_list.TabIndex = 10;
            this.init_sol_list.DoubleClick += new System.EventHandler(this.init_sol_list_DoubleClick);
            // 
            // unit_cmb
            // 
            this.unit_cmb.FormattingEnabled = true;
            this.unit_cmb.Location = new System.Drawing.Point(770, 12);
            this.unit_cmb.Name = "unit_cmb";
            this.unit_cmb.Size = new System.Drawing.Size(133, 21);
            this.unit_cmb.TabIndex = 11;
            this.unit_cmb.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // init_size_num
            // 
            this.init_size_num.Location = new System.Drawing.Point(647, 331);
            this.init_size_num.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.init_size_num.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.init_size_num.Name = "init_size_num";
            this.init_size_num.Size = new System.Drawing.Size(50, 20);
            this.init_size_num.TabIndex = 12;
            this.init_size_num.TabStop = false;
            this.init_size_num.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(524, 333);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Initial solution size";
            // 
            // rnd_btn
            // 
            this.rnd_btn.Location = new System.Drawing.Point(770, 269);
            this.rnd_btn.Name = "rnd_btn";
            this.rnd_btn.Size = new System.Drawing.Size(133, 23);
            this.rnd_btn.TabIndex = 14;
            this.rnd_btn.Text = "Randomize";
            this.rnd_btn.UseVisualStyleBackColor = true;
            this.rnd_btn.Click += new System.EventHandler(this.rnd_btn_Click);
            // 
            // clc_sc_init_btn
            // 
            this.clc_sc_init_btn.Location = new System.Drawing.Point(770, 298);
            this.clc_sc_init_btn.Name = "clc_sc_init_btn";
            this.clc_sc_init_btn.Size = new System.Drawing.Size(133, 23);
            this.clc_sc_init_btn.TabIndex = 15;
            this.clc_sc_init_btn.Text = "Calc score";
            this.clc_sc_init_btn.UseVisualStyleBackColor = true;
            this.clc_sc_init_btn.Click += new System.EventHandler(this.clc_sc_init_btn_Click);
            // 
            // init_time_lbl
            // 
            this.init_time_lbl.AutoSize = true;
            this.init_time_lbl.Location = new System.Drawing.Point(767, 349);
            this.init_time_lbl.Name = "init_time_lbl";
            this.init_time_lbl.Size = new System.Drawing.Size(33, 13);
            this.init_time_lbl.TabIndex = 17;
            this.init_time_lbl.Text = "Time:";
            // 
            // init_status_lbl
            // 
            this.init_status_lbl.AutoSize = true;
            this.init_status_lbl.Location = new System.Drawing.Point(767, 331);
            this.init_status_lbl.Name = "init_status_lbl";
            this.init_status_lbl.Size = new System.Drawing.Size(38, 13);
            this.init_status_lbl.TabIndex = 16;
            this.init_status_lbl.Text = "Score:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 371);
            this.Controls.Add(this.init_time_lbl);
            this.Controls.Add(this.init_status_lbl);
            this.Controls.Add(this.clc_sc_init_btn);
            this.Controls.Add(this.rnd_btn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.init_size_num);
            this.Controls.Add(this.unit_cmb);
            this.Controls.Add(this.init_sol_list);
            this.Controls.Add(this.rand_sol_chck);
            this.Controls.Add(this.stop_btn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.time_lbl);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.iteration_num);
            this.Controls.Add(this.sol_list);
            this.Controls.Add(this.status_lbl);
            this.Controls.Add(this.start_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "SC Build Order";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iteration_num)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.del_num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exch_num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.add_num)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ret_num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neig_num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.init_size_num)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.Label status_lbl;
        private System.Windows.Forms.ListBox sol_list;
        private System.Windows.Forms.NumericUpDown iteration_num;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label time_lbl;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown del_num;
        private System.Windows.Forms.NumericUpDown exch_num;
        private System.Windows.Forms.NumericUpDown add_num;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown ret_num;
        private System.Windows.Forms.NumericUpDown neig_num;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button stop_btn;
        private System.Windows.Forms.CheckBox rand_sol_chck;
        private System.Windows.Forms.ListBox init_sol_list;
        private System.Windows.Forms.ComboBox unit_cmb;
        private System.Windows.Forms.NumericUpDown init_size_num;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button rnd_btn;
        private System.Windows.Forms.Button clc_sc_init_btn;
        private System.Windows.Forms.Label init_time_lbl;
        private System.Windows.Forms.Label init_status_lbl;




    }
}

