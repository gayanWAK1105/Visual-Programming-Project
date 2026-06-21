using System;
using System.Windows.Forms;

namespace Visual_Programming
{
    public partial class Form1 : Form
    {
        private int currentPlayerId;
        private string currentPlayerName;

        public Form1(int playerId, string playerName)
        {
            InitializeComponent();
            currentPlayerId = playerId;
            currentPlayerName = playerName;
        }

        // Addition
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(currentPlayerId, currentPlayerName, "Addition", 1);
            this.Hide();
            form2.ShowDialog();
            this.Show();
        }

        // Subtraction
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(currentPlayerId, currentPlayerName, "Subtraction", 1);
            this.Hide();
            form2.ShowDialog();
            this.Show();
        }

        // Multiplication
        private void button3_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5(currentPlayerId, currentPlayerName, "Multiplication", 1);
            this.Hide();
            form5.ShowDialog();
            this.Show();
        }

        // Division
        private void button4_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(currentPlayerId, currentPlayerName, "Division", 1);
            this.Hide();
            form4.ShowDialog();
            this.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = $"ALGORIDE - Welcome {currentPlayerName}";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
