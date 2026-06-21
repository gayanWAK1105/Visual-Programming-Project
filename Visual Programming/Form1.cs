namespace Visual_Programming
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            this.Hide();
            // Show the new form
            form5.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(1);

            // Show the new form
            form2.ShowDialog();
            this.Hide();
            // Optional: Hide this menu so only the game is visible


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(1);
            this.Hide();
            form2.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            this.Hide();
            form4.ShowDialog();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
