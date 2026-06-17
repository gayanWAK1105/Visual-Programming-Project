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

            // Show the new form
            form5.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();

            // Show the new form
            form2.ShowDialog();

            // Optional: Hide this menu so only the game is visible


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.ShowDialog();

        }
    }
}
