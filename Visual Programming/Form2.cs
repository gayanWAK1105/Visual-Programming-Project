using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Visual_Programming.Game;
using Visual_Programming.Persistence;

namespace Visual_Programming
{
    public partial class Form2 : Form
    {
        // ── Game State ─────────────────────────────────────────────────────
        private GameState gameState;
        private Random random = new Random();

        // ── Question ────────────────────────────────────────────────────────
        private int num1;
        private int num2;
        private int correctAnswer;
        private bool waitingForCrash = false;

        // ── Question Timer (independent from animation timers) ──────────────
        private Stopwatch questionStopwatch = new Stopwatch();
        private Stopwatch levelStopwatch = new Stopwatch();

        // ── Pause System ────────────────────────────────────────────────────
        private bool pauseRequested = false;
        private bool isPaused = false;

        // ── Pause button images ─────────────────────────────────────────────
        private Image? pauseImage;
        private Image? playImage;

        // ── Progress Bar (added programmatically) ───────────────────────────
        private ProgessBar progressBar1 = null!;

        // ════════════════════════════════════════════════════════════════════
        // CONSTRUCTOR
        // ════════════════════════════════════════════════════════════════════

        public Form2(int level)
        {
            InitializeComponent();

            // Load saved game state
            gameState = SaveManager.Load();

            // Apply the requested level
            // If resuming the same level with progress, keep it.
            // If starting a different level, reset for that level.
            if (gameState.CurrentLevel != level || gameState.Lives <= 0)
            {
                gameState.ResetForLevel(level);
            }

            // Wire events
            button2.Click += button2_Click;
            animation1.SuccessAnimationComplete += Animation1_SuccessAnimationComplete;
            animation1.CollisionDetected += Animation1_CollisionDetected;
            pauseButton.Click += PauseButton_Click;

            // Load pause/play images
            LoadPausePlayImages();

            // Setup UI
            SetupProgressBar();
            UpdateInfoLabel();

            // Display level in label2
            label2.Text = $"Level {gameState.CurrentLevel}";

            // Start the game
            StartLevel(gameState.CurrentLevel);
        }

        // ════════════════════════════════════════════════════════════════════
        // UI SETUP
        // ════════════════════════════════════════════════════════════════════

        private void LoadPausePlayImages()
        {
            // Store the current pause image from the designer
            pauseImage = pauseButton.BackgroundImage;

            // Load play image from Resources folder
            string playPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                "Resources", "play.png");
            if (File.Exists(playPath))
            {
                playImage = Image.FromFile(playPath);
            }
        }

        private void SetupProgressBar()
        {
            progressBar1 = new ProgessBar();
            progressBar1.Location = new Point(850, 700);
            progressBar1.Name = "progressBar1";
            Controls.Add(progressBar1);
            progressBar1.BringToFront();

            // If resuming mid-level, set progress immediately
            if (gameState.QuestionsCompletedThisLevel > 0)
            {
                float progress = (float)gameState.QuestionsCompletedThisLevel
                    / GameState.QuestionsPerLevel;
                progressBar1.SetProgressImmediate(progress);
            }
        }

        private void UpdateInfoLabel()
        {
            label2.Text = $"Level {gameState.CurrentLevel}  |  " +
                          $"♥ x{gameState.Lives}  |  " +
                          $"Score: {gameState.LevelScore}  |  " +
                          $"Q: {gameState.QuestionsCompletedThisLevel}/{GameState.QuestionsPerLevel}";
        }

        // ════════════════════════════════════════════════════════════════════
        // LEVEL MANAGEMENT
        // ════════════════════════════════════════════════════════════════════

        private void StartLevel(int level)
        {
            gameState.CurrentLevel = level;
            progressBar1.ResetProgress();

            // If resuming mid-level, restore progress bar position
            if (gameState.QuestionsCompletedThisLevel > 0)
            {
                float progress = (float)gameState.QuestionsCompletedThisLevel
                    / GameState.QuestionsPerLevel;
                progressBar1.SetProgressImmediate(progress);
            }

            levelStopwatch.Restart();
            UpdateInfoLabel();
            GenerateQuestion();
        }

        private void GenerateQuestion()
        {
            // Generate question using centralized LevelManager
            var (n1, n2, answer) = LevelManager.GenerateQuestionForLevel(
                gameState.CurrentLevel, random);
            num1 = n1;
            num2 = n2;
            correctAnswer = answer;

            // Update UI
            label1.Text = $"{num1} + {num2} = ?";
            textBox1.Clear();
            textBox1.Enabled = true;
            button1.Enabled = true;
            waitingForCrash = false;

            // Start question timer (independent from animation)
            questionStopwatch.Restart();

            // Start obstacle scene — car spawns in bike's current lane
            animation1.SpawnQuestionCar();
        }

        // ════════════════════════════════════════════════════════════════════
        // ANSWER SUBMISSION
        // ════════════════════════════════════════════════════════════════════

        private void button1_Click(object sender, EventArgs e)
        {
            // Block input while paused or waiting for crash animation
            if (isPaused) return;
            if (waitingForCrash) return;

            if (!int.TryParse(textBox1.Text, out int userAnswer))
            {
                MessageBox.Show("Enter a valid number.");
                return;
            }

            // Ignore input while animation is busy (dodging, settling, crashing)
            if (animation1.IsBikeChangingLane())
                return;

            // Stop question timer
            questionStopwatch.Stop();
            long elapsedMs = questionStopwatch.ElapsedMilliseconds;

            bool isCorrect = userAnswer == correctAnswer;

            if (isCorrect)
            {
                HandleCorrectAnswer(elapsedMs);
            }
            else
            {
                HandleWrongAnswer();
            }
        }

        private void HandleCorrectAnswer(long elapsedMs)
        {
            // Record score using ScoreManager
            ScoreManager.RecordCorrectAnswer(gameState, elapsedMs);

            // Disable input during dodge animation
            textBox1.Enabled = false;
            button1.Enabled = false;

            // Dodge to the opposite lane
            int oppositeLane = animation1.CurrentLane == 0 ? 1 : 0;
            animation1.MoveToLaneSmooth(oppositeLane);

            // Update UI
            UpdateInfoLabel();

            // Auto-save after every question
            SaveManager.Save(gameState);

            Console.WriteLine($"Correct! +{GameState.CalculateScore(elapsedMs)} points");
        }

        private void HandleWrongAnswer()
        {
            // Record wrong answer — loses one life
            ScoreManager.RecordWrongAnswer(gameState);

            // Prevent further input — collision is inevitable
            waitingForCrash = true;
            textBox1.Enabled = false;
            button1.Enabled = false;

            // Update UI (shows reduced lives immediately)
            UpdateInfoLabel();

            // Trigger crash animation — speed up, collision is inevitable
            animation1.TriggerWrongAnswer();
            textBox1.Clear();

            // Auto-save after every question
            SaveManager.Save(gameState);

            Console.WriteLine("Wrong answer — life lost");
        }

        // ════════════════════════════════════════════════════════════════════
        // ANIMATION EVENT HANDLERS
        // ════════════════════════════════════════════════════════════════════

        private void Animation1_SuccessAnimationComplete(object? sender, EventArgs e)
        {
            // Update progress bar (smooth animation)
            float progress = (float)gameState.QuestionsCompletedThisLevel
                / GameState.QuestionsPerLevel;
            progressBar1.SetProgress(progress);

            // Check if level is complete
            if (gameState.QuestionsCompletedThisLevel >= GameState.QuestionsPerLevel)
            {
                HandleLevelComplete();
                return;
            }

            // Check if pause was requested
            if (pauseRequested)
            {
                EnterPausedState();
                return;
            }

            // Continue — next question
            GenerateQuestion();
        }

        private void Animation1_CollisionDetected(object? sender, EventArgs e)
        {
            waitingForCrash = false;

            // Update progress bar
            float progress = (float)gameState.QuestionsCompletedThisLevel
                / GameState.QuestionsPerLevel;
            progressBar1.SetProgress(progress);

            // Game over takes priority
            if (gameState.Lives <= 0)
            {
                HandleGameOver();
                return;
            }

            // Check level complete (wrong answers also count as completed questions)
            if (gameState.QuestionsCompletedThisLevel >= GameState.QuestionsPerLevel)
            {
                HandleLevelComplete();
                return;
            }

            // Check if pause was requested
            if (pauseRequested)
            {
                EnterPausedState();
                return;
            }

            // Continue — next question
            GenerateQuestion();
        }

        // ════════════════════════════════════════════════════════════════════
        // LEVEL COMPLETE
        // ════════════════════════════════════════════════════════════════════

        private void HandleLevelComplete()
        {
            levelStopwatch.Stop();

            // Finalize level — updates best score, total score, unlocks next
            ScoreManager.FinalizeLevel(gameState);

            // Save progress
            SaveManager.Save(gameState);

            // Show level complete summary
            TimeSpan elapsed = levelStopwatch.Elapsed;
            int bestScore = gameState.BestScorePerLevel.ContainsKey(gameState.CurrentLevel)
                ? gameState.BestScorePerLevel[gameState.CurrentLevel]
                : gameState.LevelScore;

            MessageBox.Show(
                $"🎉 Level {gameState.CurrentLevel} Complete!\n\n" +
                $"Score: {gameState.LevelScore}\n" +
                $"Best Score: {bestScore}\n" +
                $"Correct: {gameState.CorrectAnswersThisLevel}/{GameState.QuestionsPerLevel}\n" +
                $"Time: {elapsed.Minutes:D2}:{elapsed.Seconds:D2}",
                "Level Complete",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            // Advance to next level
            int nextLevel = gameState.CurrentLevel + 1;
            gameState.ResetForLevel(nextLevel);
            SaveManager.Save(gameState);
            StartLevel(nextLevel);
        }

        // ════════════════════════════════════════════════════════════════════
        // GAME OVER
        // ════════════════════════════════════════════════════════════════════

        private void HandleGameOver()
        {
            animation1.StopRoad();

            var result = MessageBox.Show(
                $"💀 Game Over!\n\n" +
                $"Level: {gameState.CurrentLevel}\n" +
                $"Score: {gameState.LevelScore}\n" +
                $"Correct: {gameState.CorrectAnswersThisLevel}/{gameState.QuestionsCompletedThisLevel}\n\n" +
                $"Yes = Restart Level\nNo = Main Menu",
                "Game Over",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Restart current level
                gameState.ResetForLevel(gameState.CurrentLevel);
                SaveManager.Save(gameState);
                StartLevel(gameState.CurrentLevel);
            }
            else
            {
                // Return to main menu (Form1)
                gameState.ResetForLevel(gameState.CurrentLevel);
                SaveManager.Save(gameState);
                this.Close();
            }
        }

        // ════════════════════════════════════════════════════════════════════
        // PAUSE SYSTEM
        // ════════════════════════════════════════════════════════════════════

        private void PauseButton_Click(object? sender, EventArgs e)
        {
            if (isPaused)
            {
                // Currently paused → Resume
                ResumeGame();
            }
            else
            {
                // Request pause
                if (animation1.IsIdle)
                {
                    // Scene is already idle — pause immediately
                    EnterPausedState();
                }
                else
                {
                    // Scene is active — defer pause until scene completes
                    pauseRequested = true;

                    // Update button image to play
                    if (playImage != null)
                        pauseButton.BackgroundImage = playImage;
                }
            }
        }

        /// <summary>
        /// Enters the paused state. Called after current scene finishes
        /// (SuccessAnimationComplete or CollisionDetected) when pauseRequested is true.
        /// </summary>
        private void EnterPausedState()
        {
            isPaused = true;
            pauseRequested = false;
            questionStopwatch.Stop();

            // Disable input
            textBox1.Enabled = false;
            button1.Enabled = false;

            // Update button image to play
            if (playImage != null)
                pauseButton.BackgroundImage = playImage;
        }

        /// <summary>
        /// Resumes the game from paused state.
        /// Generates the next question and restores normal flow.
        /// </summary>
        private void ResumeGame()
        {
            isPaused = false;

            // Restore button image to pause
            if (pauseImage != null)
                pauseButton.BackgroundImage = pauseImage;

            // Re-enable input and generate next question
            textBox1.Enabled = true;
            button1.Enabled = true;
            GenerateQuestion();
        }

        // ════════════════════════════════════════════════════════════════════
        // EXISTING EVENT HANDLERS (preserved for designer compatibility)
        // ════════════════════════════════════════════════════════════════════

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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

        private void Form2_Load_1(object sender, EventArgs e)
        {
        }

        private void pauseButton_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
