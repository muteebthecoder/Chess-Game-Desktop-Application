using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Chess_Game_Project
{
    public partial class Main_Form : Form
    {
      
        public Main_Form()
        {
            InitializeComponent();
        }
        int r=0, c=0;
       
        private void Main_Form_Load(object sender, EventArgs e)
        {
           /* PictureBox b=new PictureBox();
            b.Image = Properties.Resources.w_king_1x;

            PictureBox b1 = new PictureBox();
            b1.Image = Properties.Resources.b_king_1x;

            b.Width = 30;
            b.Height = 30;
            b.BorderStyle = BorderStyle.FixedSingle;
            b.SizeMode=PictureBoxSizeMode.StretchImage;

             b.Location = new Point(0, 20);
            panel1.Controls.Add(b);
            b1.Location = new Point(80, 20);
            panel1.Controls.Add(b1);
            //  tableLayoutPanel1.Controls.Add(b);
            tableLayoutPanel1.Controls.Add(new PictureBox() {
                Image = Properties.Resources.b_bishop_1x,
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Dock = DockStyle.Fill,
                Width = 20,
                Height = 20 },
                c, r) ;
            c++;
            tableLayoutPanel1.Controls.Add(new PictureBox() { 
                Image = Properties.Resources.b_king_1x,
                BorderStyle=BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Dock = DockStyle.Fill,
                Width =20,
                Height=20 },
                c, r) ;
            c++;
            tableLayoutPanel1.Controls.Add(new PictureBox() { 
                Image = Properties.Resources.b_queen_1x,
                BorderStyle=BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Dock = DockStyle.Fill,
                Width =20,
                Height=20 },
                c, r );
            */
        }

        private void btnquit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnplay_Click(object sender, EventArgs e)
        {

        }

        private void btn2player_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
            this.Hide();
        }

        private void btnserver_Click(object sender, EventArgs e)
        {
            LoginForm f = new LoginForm();
            f.Show();
        }
    }
}
