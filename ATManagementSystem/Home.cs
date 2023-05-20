using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATManagementSystem
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {
            Balance bal = new Balance();
            this.Hide();
            bal.Show();
        }
        public static String AccNumber;
        private void Home_Load(object sender, EventArgs e)
        {
            AccNumlbl.Text = "Acount Number: " + Login.AccNumber;
            AccNumber = Login.AccNumber;
        }

        private void AccNumlbl_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            Deposit depo = new Deposit();
            depo.Show();
            this.Hide();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            Ministatement mini = new Ministatement();
            mini.Show();
            this.Hide();
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            ChangePin Pin = new ChangePin();
            Pin.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            Withdraw wid = new Withdraw();
            wid.Show();
            this.Hide();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            FASTCASH fcash = new FASTCASH();
            fcash.Show();
            this.Hide();
        }
    }
}
