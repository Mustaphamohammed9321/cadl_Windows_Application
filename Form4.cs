using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace cadl
{
    public partial class Form4 : Form
    {
        
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Documents\Cadl1.mdf;Integrated Security=True;Connect Timeout=30");
        public Form4()
        {
            InitializeComponent();
            
        }

        //private string ConString()
        //{
        //    var constring = ConfigurationManager.AppSettings["CadlConString"].ToString();

        //    var constring2 = ConfigurationManager.ConnectionStrings["CadlConString"].ToString();
        //}


        private void button1_Click(object sender, EventArgs e)
        {
            //Con.Open();
            //string query = "insert into Banktbl values (" + comboBox1.Text + ", '" + textBox21.Text + "', '" + textBox22.Text + "', '" + textBox23.Text + "', '" + textBox24.Text + "', '" + comboBox3.Text + "')";
            //SqlCommand cmd = new SqlCommand("query ", Con);
            //cmd.ExecuteNonQuery();
            //MessageBox.Show("Bank Details Successfully Saved");
            //Con.Close();
          
         
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Hide();
            f2.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            this.Hide();
            form5.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
