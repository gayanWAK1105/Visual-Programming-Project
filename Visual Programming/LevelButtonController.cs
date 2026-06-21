using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visual_Programming
{
    public partial class LevelButtonController : UserControl
    {
        private int playerId;
        private string playerName;
        private string gameType;
        private int levelNumber;

        public LevelButtonController(int playerId, string playerName, string gameType, int levelNumber, bool isUnlocked)
        {
            InitializeComponent();
            
            this.playerId = playerId;
            this.playerName = playerName;
            this.gameType = gameType;
            this.levelNumber = levelNumber;

            button1.Text = $"LEVEL {levelNumber}";
            button1.Enabled = isUnlocked;

            button1.Click += Button1_Click;
        }

        private void Button1_Click(object? sender, EventArgs e)
        {
            Form2 form2 = new Form2(playerId, playerName, gameType, levelNumber);
            Form parentForm = this.FindForm();
            if (parentForm != null)
            {
                parentForm.Hide();
                form2.ShowDialog();
                parentForm.Show();
            }
        }
    }
}
