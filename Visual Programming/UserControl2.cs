using System;
using System.Drawing;
using System.Windows.Forms;

namespace Visual_Programming
{
    public partial class UserControl2 : UserControl
    {
        private int playerId;
        private string playerName;
        private string gameType;
        private int currentLevel;
        private int nextLevel;
        private int currentScore;
        private int highScore;
        private int correctAnswers;
        private int timeTaken;

        public UserControl2()
        {
            InitializeComponent();
        }

        public UserControl2(int playerId, string playerName, string gameType, int currentLevel, int nextLevel, int currentScore, int highScore, int correctAnswers, int timeTaken) : this()
        {
            this.playerId = playerId;
            this.playerName = playerName;
            this.gameType = gameType;
            this.currentLevel = currentLevel;
            this.nextLevel = nextLevel;
            this.currentScore = currentScore;
            this.highScore = highScore;
            this.correctAnswers = correctAnswers;
            this.timeTaken = timeTaken;

            lblLevelNo.Text = $"{nextLevel}";
            
            // Start font breathing animation
            timer1.Start();
        }

        private void UserControl2_Load(object sender, EventArgs e)
        {
        }

        private void lblLevelUp_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
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

            lblLevelUp.Font = new Font(lblLevelUp.Font.FontFamily, currentFontSize, lblLevelUp.Font.Style);
        }

        private void btnExit_Click(object sender, EventArgs e)
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
            // Start next level
            var parentForm = this.FindForm();
            if (parentForm != null)
            {
                parentForm.Hide();
                Form newGameForm = null;
                if (gameType == "Addition" || gameType == "Subtraction")
                {
                    newGameForm = new Form2(playerId, playerName, gameType, nextLevel);
                }
                else if (gameType == "Multiplication")
                {
                    newGameForm = new Form5(playerId, playerName, gameType, nextLevel);
                }
                else if (gameType == "Division")
                {
                    newGameForm = new Form4(playerId, playerName, gameType, nextLevel);
                }

                if (newGameForm != null)
                {
                    newGameForm.ShowDialog();
                }
                parentForm.Close();
            }
        }

        public void setLevel(string level)
        {
            lblLevelNo.Text = level;
        }
    }
}
