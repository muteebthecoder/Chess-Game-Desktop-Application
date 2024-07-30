namespace Chess_Game_Project
{
    partial class Main_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Form));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnplay = new System.Windows.Forms.Button();
            this.btn2player = new System.Windows.Forms.Button();
            this.btnserver = new System.Windows.Forms.Button();
            this.btnquit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(918, 94);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(447, 605);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnplay
            // 
            this.btnplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(27)))), ((int)(((byte)(0)))));
            this.btnplay.FlatAppearance.BorderSize = 0;
            this.btnplay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnplay.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnplay.ForeColor = System.Drawing.Color.White;
            this.btnplay.Location = new System.Drawing.Point(176, 191);
            this.btnplay.Name = "btnplay";
            this.btnplay.Size = new System.Drawing.Size(312, 74);
            this.btnplay.TabIndex = 2;
            this.btnplay.Text = "Play Game";
            this.btnplay.UseVisualStyleBackColor = false;
            this.btnplay.Click += new System.EventHandler(this.btnplay_Click);
            // 
            // btn2player
            // 
            this.btn2player.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(27)))), ((int)(((byte)(0)))));
            this.btn2player.FlatAppearance.BorderSize = 0;
            this.btn2player.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn2player.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn2player.ForeColor = System.Drawing.Color.White;
            this.btn2player.Location = new System.Drawing.Point(176, 284);
            this.btn2player.Name = "btn2player";
            this.btn2player.Size = new System.Drawing.Size(312, 74);
            this.btn2player.TabIndex = 3;
            this.btn2player.Text = "2 Players";
            this.btn2player.UseVisualStyleBackColor = false;
            this.btn2player.Click += new System.EventHandler(this.btn2player_Click);
            // 
            // btnserver
            // 
            this.btnserver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(27)))), ((int)(((byte)(0)))));
            this.btnserver.FlatAppearance.BorderSize = 0;
            this.btnserver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnserver.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnserver.ForeColor = System.Drawing.Color.White;
            this.btnserver.Location = new System.Drawing.Point(176, 375);
            this.btnserver.Name = "btnserver";
            this.btnserver.Size = new System.Drawing.Size(312, 74);
            this.btnserver.TabIndex = 4;
            this.btnserver.Text = "Invite Friends";
            this.btnserver.UseVisualStyleBackColor = false;
            this.btnserver.Click += new System.EventHandler(this.btnserver_Click);
            // 
            // btnquit
            // 
            this.btnquit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(27)))), ((int)(((byte)(0)))));
            this.btnquit.FlatAppearance.BorderSize = 0;
            this.btnquit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnquit.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnquit.ForeColor = System.Drawing.Color.White;
            this.btnquit.Location = new System.Drawing.Point(176, 468);
            this.btnquit.Name = "btnquit";
            this.btnquit.Size = new System.Drawing.Size(312, 74);
            this.btnquit.TabIndex = 5;
            this.btnquit.Text = "Quit Game";
            this.btnquit.UseVisualStyleBackColor = false;
            this.btnquit.Click += new System.EventHandler(this.btnquit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(547, 724);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(212, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Developed By Muteeb Qureshi";
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(26)))), ((int)(((byte)(19)))));
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnquit);
            this.Controls.Add(this.btnserver);
            this.Controls.Add(this.btn2player);
            this.Controls.Add(this.btnplay);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main_Form";
            this.Text = "Main_Form";
            this.Load += new System.EventHandler(this.Main_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnplay;
        private System.Windows.Forms.Button btn2player;
        private System.Windows.Forms.Button btnserver;
        private System.Windows.Forms.Button btnquit;
        private System.Windows.Forms.Label label3;
    }
}