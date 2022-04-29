namespace cadl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            progressBar1.Increment(1);
            label3.Text = progressBar1.Value.ToString() + "%";

            if (progressBar1.Value == 100)
            {
                timer1.Stop();
                Form9 fm9 = new Form9();
                this.Hide();
                fm9.ShowDialog();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}