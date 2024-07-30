using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

namespace Chess_Game_Project
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            string ip = txtipaddress.Text;
            int port = int.Parse(txtportno.Text);
            TcpClient tcpClient = new TcpClient();
            BinaryFormatter bf = new BinaryFormatter();
            tcpClient.Connect(ip, port);
            string player = (string)bf.Deserialize(tcpClient.GetStream());
            Form3 f = new Form3(tcpClient, player);
            f.Show();
            this.Hide();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
