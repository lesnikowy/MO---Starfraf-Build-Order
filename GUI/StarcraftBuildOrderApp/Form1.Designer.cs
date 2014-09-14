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
            this.start_btn = new System.Windows.Forms.Button();
            this.status_lbl = new System.Windows.Forms.Label();
            this.sol_list = new System.Windows.Forms.ListBox();
            this.iteration_num = new System.Windows.Forms.NumericUpDown();
            this.lbl1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.iteration_num)).BeginInit();
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
            this.sol_list.Location = new System.Drawing.Point(326, 146);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 446);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.iteration_num);
            this.Controls.Add(this.sol_list);
            this.Controls.Add(this.status_lbl);
            this.Controls.Add(this.start_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "SC Build Order";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iteration_num)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.Label status_lbl;
        private System.Windows.Forms.ListBox sol_list;
        private System.Windows.Forms.NumericUpDown iteration_num;
        private System.Windows.Forms.Label lbl1;




    }
}

