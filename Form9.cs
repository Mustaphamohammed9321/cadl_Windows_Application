using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RepoDb;
using cadl.Repository;

namespace cadl
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserRepository _userRepo = new UserRepository();
            var res = _userRepo.LoginAsync(new Models.DTO.RequestDTO.LoginRequest { Username = textBox1.Text, Password = textBox2.Text });

            switch (res.Result.ResponseCode)
            {
                case 90:  //warning
                    MessageBox.Show(res.Result.ResponseMessage.ToString());
                    textBox1.Text = "";
                    textBox2.Text = "";
                    break;

                case 99:   //error
                    MessageBox.Show(res.Result.ResponseMessage.ToString());
                    textBox1.Text = "";
                    textBox2.Text = "";
                    break;

                case 00:   //success
                    Form2 f2 = new Form2();
                    this.Hide();
                    MessageBox.Show(res.Result.ResponseMessage.ToString());
                    //MessageBox.Show("You have Successfully Login to Cadl Desktop App");
                    f2.Show();
                    break;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult diagRes = MessageBox.Show("Are you sure you want to exit", "CADL - Capital Agricultural Development Limited", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (diagRes == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                Refresh();
            }
        }
    }
}
