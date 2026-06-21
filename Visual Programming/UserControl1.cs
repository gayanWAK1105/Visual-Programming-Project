using System;
using System.Drawing;
using System.Windows.Forms;

namespace Visual_Programming
{
    public partial class UserControl1 : UserControl
    {
        private int playerId;
        private string playerName;
        private string gameType;
        private int currentLevel;
        private int currentScore;
        private int highScore;

        public UserControl1()
        {
            InitializeComponent();
        }

        public UserControl1(int playerId, string playerName, string gameType, int currentLevel, int currentScore, int highScore) : this()
        {
            this.playerId = playerId;
            this.playerName = playerName;
            this.gameType = gameType;
            this.currentLevel = currentLevel;
            this.currentScore = currentScore;
            this.highScore = highScore;

            lblScore.Text = $"{currentScore}";
            
            // Start font breathing animation
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            var parentForm = this.FindForm();
            if (parentForm != null)
            {
                parentForm.Hide();
                Form1 form = new Form1(playerId, playerName);
                form.ShowDialog();
                parentForm.Close();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // Restart the level
            var parentForm = this.FindForm();
            if (parentForm != null)
            {
                parentForm.Hide();
                Form newGameForm = null;
                if (gameType == "Addition" || gameType == "Subtraction")
                {
                    newGameForm = new Form2(playerId, playerName, gameType, currentLevel);
                }
                else if (gameType == "Multiplication")
                {
                    newGameForm = new Form5(playerId, playerName, gameType, currentLevel);
                }
                else if (gameType == "Division")
                {
                    newGameForm = new Form4(playerId, playerName, gameType, currentLevel);
                }

                if (newGameForm != null)
                {
                    newGameForm.ShowDialog();
                }
                parentForm.Close();
            }
        }

        private float minFontSize = 48f;
        private float maxFontSize = 60f;
        private float currentFontSize = 55f;
        private bool growing = true;
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (growing)
            {
                currentFontSize += 0.5f;
                if (currentFontSize >= maxFontSize)
                {
                    growing = false;
                }
            }
            else
            {
                currentFontSize -= 0.5f;
                if (currentFontSize <= minFontSize)
                {
                    growing = true;
                }
            }

            lblGameOver.Font = new Font(lblGameOver.Font.FontFamily, currentFontSize, lblGameOver.Font.Style);
        }

        public void setScore(string score)
        {
            lblScore.Text = score;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}
