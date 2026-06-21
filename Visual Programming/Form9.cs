using System;
using System.Drawing;
using System.Windows.Forms;
using Visual_Programming.Database;
using Visual_Programming.Models;

namespace Visual_Programming
{
    public partial class menuForm : Form
    {
        private PlayerRepository playerRepository;

        public menuForm()
        {
            InitializeComponent();
            playerRepository = new PlayerRepository();
        }

        private void menuForm_Load(object sender, EventArgs e)
        {
            LoadPlayers();
        }

        private void LoadPlayers()
        {
            flowLayoutPanel1.Controls.Clear();
            
            try
            {
                var players = playerRepository.GetAllPlayers();
                
                foreach (var player in players)
                {
                    Button btnPlayer = new Button();
                    btnPlayer.Text = player.PlayerName;
                    btnPlayer.Size = new Size(280, 50); // Adjust width to fit FlowLayoutPanel
                    btnPlayer.BackColor = Color.LightGreen;
                    btnPlayer.Font = new Font("Showcard Gothic", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
                    btnPlayer.Tag = player;
                    
                    btnPlayer.Click += BtnPlayer_Click;
                    
                    flowLayoutPanel1.Controls.Add(btnPlayer);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load players. Ensure MySQL is running and the database is created.\nError: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnPlayer_Click(object? sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is Player player)
            {
                // Open Form1 passing the selected player
                Form1 form1 = new Form1(player.PlayerId, player.PlayerName);
                this.Hide();
                form1.ShowDialog();
                this.Show(); // Re-show after Form1 closes
            }
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string enteredName = txtName.Text.Trim();

                if (enteredName != "")
                {
                    try
                    {
                        // Create player in database
                        Player newPlayer = playerRepository.CreatePlayer(enteredName);
                        
                        // Proceed to Form1
                        Form1 form1 = new Form1(newPlayer.PlayerId, newPlayer.PlayerName);
                        this.Hide();
                        form1.ShowDialog();
                        this.Show(); // Re-show after Form1 closes
                        
                        // Reload players when returning
                        LoadPlayers();
                        txtName.Text = "";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while creating the player: " + ex.Message,
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                    e.SuppressKeyPress = true;
                }
                else
                {
                    MessageBox.Show("Please enter your name!", "ALGORIDE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // Optional: You could use btnStart to confirm the selected player if you added a select feature.
            // For now, players just click the buttons in the FlowLayoutPanel directly, or type a new name and press enter.
            MessageBox.Show("Please click on an existing player name above, or type a new name and press ENTER.", "Select Player", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(
                "Do you want to exit the game?",
                "ALGORIDE - Exit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void menuForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        
        private void txtName_TextChanged(object sender, EventArgs e) { }
    }
}