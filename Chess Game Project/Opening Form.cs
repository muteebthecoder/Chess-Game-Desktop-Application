using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_Game_Project
{
    public partial class Opening_Form : Form
    {
        public Opening_Form()
        {
            InitializeComponent();
        }

        private async void Opening_Form_Load(object sender, EventArgs e)
        {
            await Wait();
            Main_Form m=new Main_Form();
            m.Show();
            this.Hide();
        }
        async static Task Wait()
        {
            await Task.Delay(5000);
        }
    }
}
