using cadl.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cadl
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Hide();
            f2.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            this.Hide();
            f4.ShowDialog();

        }


        private void Form3_Load(object sender, EventArgs e)
        {
            comboBox3.Enabled = false;
            comboBox5.Enabled = false;


            CountryRepository countryRepo = new CountryRepository();
            var details = countryRepo.GetAllCountries();
            comboBox4.DataSource = details;
            comboBox4.DisplayMember = "CountryName";
            comboBox4.ValueMember = "Id";


            //comboBox4.DataSource = new BindingSource(comboSource, null);
            //comboBox4.DisplayMember = "Value";
            //comboBox4.ValueMember = "Key";
        }



        private void comboBox4_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CountryRepository countryRepo = new CountryRepository();
            var det = countryRepo.GetCountryById(comboBox4.SelectedValue.ToString());
            if (det.Count > 0)
            {
                comboBox3.Enabled = true;
                comboBox3.DataSource = det;
                comboBox3.DisplayMember = "StateName";
                comboBox3.ValueMember = "Id";
            }
            else
            {
                comboBox3.Enabled = false;
                comboBox3.Items.Clear();
            }
            //MessageBox.Show($"{comboBox4.SelectedValue.ToString()}", "CADL - The APP", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void comboBox3__SelectionChangeCommitted(object sender, EventArgs e)
        {
            CountryRepository countryRepo = new CountryRepository();
            var lgaDetails = countryRepo.GetLGAById(comboBox3.SelectedValue.ToString());
            if (lgaDetails.Count > 0)
            {
                comboBox5.Enabled = true;
                comboBox5.DataSource = lgaDetails;
                comboBox5.DisplayMember = "LGAName";
                comboBox5.ValueMember = "LGAId";
            }
            else
            {
                comboBox5.Enabled = false;
                comboBox5.Items.Clear();
            }
        }
    }
}
