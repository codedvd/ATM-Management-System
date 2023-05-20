﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATManagementSystem
{
    public partial class Withdraw : Form
    {
        public Withdraw()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Decagon\Documents\ATMDb.mdf;Integrated Security=True;Connect Timeout=30");
        string Acc = Login.AccNumber;

        int bal;
        private void getbalance()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(" select Balance from AccountTbl where AccNum ='" + Acc + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            balancelbl.Text = "Balance NG " + dt.Rows[0][0].ToString();
            bal = Convert.ToInt32(dt.Rows[0][0].ToString());
            Con.Close();
        }
        private void addtransaction()
        {
            string TrType = "WithDraw";
            try
            {
                Con.Open();
                string query = "insert into TransactionTbl values('" + Acc + "','" + TrType + "','" + wdamtTb.Text + "','" + DateTime.Today.Date.ToString() + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                // MessageBox.Show("Account Created Succesfully");
                Con.Close();
                Login log = new Login();
                log.Show();
                this.Hide();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        private void Withdraw_Load(object sender, EventArgs e)
        {
            getbalance();
        }
        int  newbalance;

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if(wdamtTb.Text == "")
            {
                MessageBox.Show("Missing Infirmation");
            }
            else if (Convert.ToInt32(wdamtTb.Text) <= 0)
            {
                MessageBox.Show("Enter a Valid Amount");
            }else if(Convert.ToInt32(wdamtTb.Text) > bal)
            {
                MessageBox.Show("Balance can not be negative");
            }
            else
            {
                try
                {
                    newbalance = bal - Convert.ToInt32(wdamtTb.Text);
                    try
                    {
                        Con.Open();
                        string query = "update AccountTbl set Balance=" + newbalance + " where Accnum='" + Acc + "';";
                        SqlCommand cmd = new SqlCommand(query, Con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Success Withdraw");
                        Con.Close();
                        addtransaction();
                        Home home = new Home();
                        home.Show();
                        this.Hide();
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home home = new Home();
            home.Show();
        }
    }
}
