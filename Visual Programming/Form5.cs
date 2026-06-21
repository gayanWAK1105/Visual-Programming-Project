using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Visual_Programming
{
    public partial class Form5 : Form
    {
        Random random = new Random();

        int num1;
        int num2;
        int correctAnswer;

        public Form5()
        {
            InitializeComponent();
            button2.Click += button2_Click;
            animation1.SuccessAnimationComplete += Animation1_SuccessAnimationComplete;
            animation1.CollisionDetected += Animation1_CollisionDetected;
            GenerateQuestion();
        }

        private void GenerateQuestion()
        {
            num1 = random.Next(1, 11); // 1 to 10
            num2 = random.Next(1, 11);

            correctAnswer = num1 * num2;

            label1.Text = $"{num1} x {num2} = ?";
            textBox1.Clear();

            // Start the obstacle scene — car spawns in bike's current lane
            animation1.SpawnQuestionCar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int userAnswer))
            {
                MessageBox.Show("Enter a valid number.");
                return;
            }

            // Ignore input while animation is busy (dodging, settling, crashing)
            if (animation1.IsBikeChangingLane())
                return;

            bool isCorrect = userAnswer == correctAnswer;

            if (isCorrect)
            {
                // Dodge to the opposite lane
                int oppositeLane = animation1.CurrentLane == 0 ? 1 : 0;
                animation1.MoveToLaneSmooth(oppositeLane);
                Console.WriteLine("answer correct");
            }
            else
            {
                // Wrong answer — speed up, collision is inevitable
                animation1.TriggerWrongAnswer();
                textBox1.Clear();
                Console.WriteLine("Wrong answer");
            }
        }

        private void Animation1_SuccessAnimationComplete(object? sender, EventArgs e)
        {
            // Successful dodge complete — next question
            GenerateQuestion();
        }

        private void Animation1_CollisionDetected(object? sender, EventArgs e)
        {
            // Crash — show message and restart with next question
            MessageBox.Show("Boom! You crashed! Try again!");
            GenerateQuestion();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object? sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void animation1_Load(object sender, EventArgs e)
        {

        }



        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
                e.SuppressKeyPress = true;
            }
        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
