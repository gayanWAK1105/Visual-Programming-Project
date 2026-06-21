using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Visual_Programming.Database;

namespace Visual_Programming
{
    public partial class Form6 : Form
    {
        private int currentPlayerId;
        private string currentPlayerName;
        private string currentGameType;
        public Form6(int playerId, string playerName, string gameType)
        {
            InitializeComponent();
            currentPlayerId = playerId;
            currentPlayerName = playerName;
            currentGameType = gameType;
        }
        private void Form6_Load(object sender, EventArgs e)
        {
            ScoreRepository scoreRepo = new ScoreRepository();
            int highestUnlockedLevel = scoreRepo.GetHighestUnlockedLevel(currentPlayerId, currentGameType);
            flowLayoutPanel1.Controls.Clear();
            for (int level = 1; level <= 10; level++)
            {
                bool isUnlocked = (level <= highestUnlockedLevel + 1);
                LevelButtonController btn = new LevelButtonController(
                    currentPlayerId,
                    currentPlayerName,
                    currentGameType,
                    level,
                    isUnlocked
                );
                flowLayoutPanel1.Controls.Add(btn);
            }
        }

    }
}
