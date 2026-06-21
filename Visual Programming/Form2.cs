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
using Visual_Programming.Database;

namespace Visual_Programming
{
    public partial class Form2 : Form
    {
        // ── Game State ─────────────────────────────────────────────────────
        private GameState gameState;
        private Random random = new Random();

        // ── Player / DB Info ───────────────────────────────────────────────
        private int currentPlayerId;
        private string currentPlayerName;
        private string currentGameType;
        private ScoreRepository scoreRepository = new ScoreRepository();

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

            public Form2(int playerId, string playerName, string gameType, int level)
        {
            InitializeComponent();
            
            this.AcceptButton = button1;

            currentPlayerId = playerId;
            currentPlayerName = playerName;
            currentGameType = gameType;

            // Load new game state
            gameState = new GameState { PlayerName = playerName };

            // Apply the requested level
            gameState.ResetForLevel(level);

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

            levelStopwatch.Restart();
            UpdateInfoLabel();
            GenerateQuestion();
        }

        private void GenerateQuestion()
        {
            // Generate question using centralized LevelManager with the gameType
            var (n1, n2, answer) = LevelManager.GenerateQuestionForLevel(
                gameState.CurrentLevel, currentGameType, random);
            num1 = n1;
            num2 = n2;
            correctAnswer = answer;

            // Determine sign
            string operatorSign = currentGameType switch
            {
                "Subtraction" => "-",
                "Multiplication" => "x",
                "Division" => "÷",
                _ => "+"
            };

            // Update UI
            label1.Text = $"{num1} {operatorSign} {num2} = ?";
            textBox1.Clear();
            textBox1.Enabled = true;
            button1.Enabled = true;
            waitingForCrash = false;
            textBox1.Focus();

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
            Console.WriteLine("ANimation_collisionDetected");
            
            // If waitingForCrash is false, it means the user didn't submit a wrong answer
            // but the car crashed into them anyway (timeout).
            if (!waitingForCrash)
            {
                ScoreManager.RecordWrongAnswer(gameState);
                UpdateInfoLabel();
            }

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

            // Check level complete
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
            animation1.StopRoad();

            // Fetch stored high score and update if needed
            int storedHighScore = scoreRepository.GetHighScore(currentPlayerId, currentGameType, gameState.CurrentLevel);
            if (gameState.LevelScore > storedHighScore)
            {
                scoreRepository.UpdateHighScore(currentPlayerId, currentGameType, gameState.CurrentLevel, gameState.LevelScore);
                storedHighScore = gameState.LevelScore;
            }

            int nextLevel = gameState.CurrentLevel + 1;

            // Instantiate and add UserControl2 overlay in the center of the Form
            UserControl2 uc2 = new UserControl2(
                currentPlayerId,
                currentPlayerName,
                currentGameType,
                gameState.CurrentLevel,
                nextLevel,
                gameState.LevelScore,
                storedHighScore,
                gameState.CorrectAnswersThisLevel,
                (int)(levelStopwatch.ElapsedMilliseconds / 1000)
            );

            uc2.Location = new Point((this.ClientSize.Width - uc2.Width) / 2, (this.ClientSize.Height - uc2.Height) / 2);
            this.Controls.Add(uc2);
            uc2.BringToFront();
        }

        // ════════════════════════════════════════════════════════════════════
        // GAME OVER
        // ════════════════════════════════════════════════════════════════════

        private void HandleGameOver()
        {
            animation1.StopRoad();

            int storedHighScore = scoreRepository.GetHighScore(currentPlayerId, currentGameType, gameState.CurrentLevel);

            // Instantiate and add UserControl1 overlay in the center of the Form
            UserControl1 uc1 = new UserControl1(
                currentPlayerId,
                currentPlayerName,
                currentGameType,
                gameState.CurrentLevel,
                gameState.LevelScore,
                storedHighScore
            );

            uc1.Location = new Point((this.ClientSize.Width - uc1.Width) / 2, (this.ClientSize.Height - uc1.Height) / 2);
            this.Controls.Add(uc1);
            uc1.BringToFront();
        }

        // ════════════════════════════════════════════════════════════════════
        // PAUSE SYSTEM
        // ════════════════════════════════════════════════════════════════════

        private void PauseButton_Click(object? sender, EventArgs e)
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                if (animation1.IsIdle)
                {
                    EnterPausedState();
                }
                else
                {
                    pauseRequested = true;

                    if (playImage != null)
                        pauseButton.BackgroundImage = playImage;
                }
            }
        }

        private void EnterPausedState()
        {
            isPaused = true;
            pauseRequested = false;
            questionStopwatch.Stop();

            textBox1.Enabled = false;
            button1.Enabled = false;

            if (playImage != null)
                pauseButton.BackgroundImage = playImage;
        }

        private void ResumeGame()
        {
            isPaused = false;

            if (pauseImage != null)
                pauseButton.BackgroundImage = pauseImage;

            textBox1.Enabled = true;
            button1.Enabled = true;
            GenerateQuestion();
        }

        // ════════════════════════════════════════════════════════════════════
        // EXISTING EVENT HANDLERS (preserved for designer compatibility)
        // ════════════════════════════════════════════════════════════════════

        private void label1_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }

        private void button2_Click(object? sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void animation1_Load(object sender, EventArgs e) { }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e) { }
        private void Form2_Load_1(object sender, EventArgs e) { }
        private void pauseButton_Click_1(object sender, EventArgs e) { }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e) { }
    }
}
