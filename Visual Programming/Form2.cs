using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Visual_Programming
{
    public partial class Form2 : Form
    {
        Random random = new Random();

        int num1;
        int num2;
        int correctAnswer;

        public Form2()
        {
            InitializeComponent();
            GenerateQuestion();
            button2.Click += button2_Click;
        }

        private void GenerateQuestion()
        {
            num1 = random.Next(1, 11); // 1 to 10
            num2 = random.Next(1, 11);

            correctAnswer = num1 + num2;

            label1.Text = $"{num1} + {num2} = ?";
            textBox1.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int userAnswer))
            {
                MessageBox.Show("Enter a valid number.");
                return;
            }

            bool isCorrect = userAnswer == correctAnswer;

            PlayAnimation(isCorrect);

            if (isCorrect)
            {
                GenerateQuestion();
            }
            else
            {
                textBox1.Clear();
            }
        }

        private void PlayAnimation(bool success)
        {
            if (success)
            {
                // Correct answer animation
                MessageBox.Show("Correct!");
            }
            else
            {
                // Wrong answer animation
                MessageBox.Show("Wrong Answer!");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object? sender, EventArgs e)
        {
            textBox1.Clear();
        }
    }
}
