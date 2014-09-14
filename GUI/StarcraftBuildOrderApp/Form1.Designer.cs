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
            this.add_num = new System.Windows.Forms.NumericUpDown();
            this.exch_num = new System.Windows.Forms.NumericUpDown();
            this.del_num = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.neig_num = new System.Windows.Forms.NumericUpDown();
            this.ret_num = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.iteration_num)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.add_num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exch_num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.del_num)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neig_num)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ret_num)).BeginInit();
            this.SuspendLayout();
            // 
            // start_btn
            // 
            this.start_btn.Location = new System.Drawing.Point(319, 49);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(133, 41);
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
            this.sol_list.Size = new System.Drawing.Size(128, 147);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "ADD";
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "DELETE";
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Neighbours number";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 346);
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
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iteration_num)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.add_num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exch_num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.del_num)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neig_num)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ret_num)).EndInit();
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




    }
}

