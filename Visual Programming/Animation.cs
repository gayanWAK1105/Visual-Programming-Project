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
    /// <summary>
    /// Phases of a scripted question-obstacle scene.
    /// </summary>
    public enum ScenePhase
    {
        Idle,           // No scene active, road stopped
        Approaching,    // Car spawned, moving slowly toward bike, waiting for answer
        Dodging,        // Correct answer: bike smoothly changing lane, speed increased
        Settling,       // Car has passed the bike, road decelerating, scene wrapping up
        Crashing        // Wrong answer / collision: shake animation, then game over
    }

    public partial class Animation : UserControl
    {
        // ── Events ──────────────────────────────────────────────────────────
        public event EventHandler? SuccessAnimationComplete;
        public event EventHandler? CollisionDetected;

        // ── Road drawing ────────────────────────────────────────────────────
        private Image roadImage;
        private int roadOffset = 0;

        // ── Speed model ─────────────────────────────────────────────────────
        private int roadSpeed = 2;
        private int carSpeed = 2;
        private const int SlowRoadSpeed = 2;
        private const int SlowCarSpeed = 2;
        private const int NormalRoadSpeed = 6;
        private const int NormalCarSpeed = 8;

        // ── Scene state ─────────────────────────────────────────────────────
        private ScenePhase scenePhase = ScenePhase.Idle;
        private PictureBox? obstacleCar = null;

        // ── 2-lane model ────────────────────────────────────────────────────
        // Left lane  = centered between original lanes 1 & 2 (X30–X120)
        // Right lane = centered between original lanes 3 & 4 (X210–X300)
        private int currentLane = 0; // 0 = Left, 1 = Right
        private readonly int[] laneX = { 75, 255 };

        // ── Smooth lane change ──────────────────────────────────────────────
        private float bikeCurrentX;
        private float bikeTargetX;
        private bool isChangingLane = false;

        // ── Bike resting Y position ─────────────────────────────────────────
        private const float BikeRestY = 300f;

        // ── Crash animation ─────────────────────────────────────────────────
        private int crashTicks = 0;
        private const int CrashTicksDuration = 20;

        // ── Timer ───────────────────────────────────────────────────────────
        private System.Windows.Forms.Timer timerRoad;

        // ── Car image pool (cosmetic randomization only) ────────────────────
        private Random random = new Random();
        private Image[] carImages;

        // ── Public property ─────────────────────────────────────────────────
        /// <summary>
        /// The bike's current logical lane (0 = Left, 1 = Right).
        /// </summary>
        public int CurrentLane => currentLane;

        // ════════════════════════════════════════════════════════════════════
        // CONSTRUCTOR
        // ════════════════════════════════════════════════════════════════════

        public Animation()
        {
            InitializeComponent();

            // Initialize road image resource
            roadImage = Properties.Resources.background_1;

            pictureBox1.BackColor = Color.Transparent;

            // Setup car image pool
            carImages = new Image[]
            {
                Properties.Resources.car_3_blue,
                Properties.Resources.car_black,
                Properties.Resources.car_red,
                Properties.Resources.car_yellow

            };
            for (int i = 0; i < carImages.Length; i++)
            {
                carImages[i] = (Image)carImages[i].Clone();
                carImages[i].RotateFlip(RotateFlipType.Rotate90FlipNone);
            }

            // Initialize bike position in the left lane
            currentLane = 0;
            bikeCurrentX = laneX[currentLane];
            pictureBox1.Left = (int)bikeCurrentX;
            pictureBox1.Top = (int)BikeRestY;
            pictureBox1.Visible = true;

            // Ensure Z-ordering
            pictureBox1.BringToFront();

            // Double buffering to prevent flickering
            this.DoubleBuffered = true;

            // Initialize components container if not already initialized
            if (this.components == null)
            {
                this.components = new System.ComponentModel.Container();
            }

            // Initialize road timer (single timer — no spawn timer needed)
            timerRoad = new System.Windows.Forms.Timer(this.components);
            timerRoad.Interval = 20; // 50 FPS
            timerRoad.Tick += TimerRoad_Tick;
        }

        // ════════════════════════════════════════════════════════════════════
        // PUBLIC API — Called by Form2 to drive scene lifecycle
        // ════════════════════════════════════════════════════════════════════

        /// <summary>
        /// Called when a new question is shown.
        /// Spawns a car in the bike's current lane and begins slow approach.
        /// </summary>
        public void SpawnQuestionCar()
        {
            // Clear any leftover obstacle
            ClearObstacle();

            // Reset bike X to current lane (in case of any leftover state)
            bikeCurrentX = laneX[currentLane];
            pictureBox1.Left = (int)bikeCurrentX;
            pictureBox1.Top = (int)BikeRestY;
            isChangingLane = false;

            // Create the obstacle car
            PictureBox car = new PictureBox();
            car.Width = 70;
            car.Height = 100;
            car.SizeMode = PictureBoxSizeMode.StretchImage;
            car.Image = carImages[random.Next(carImages.Length)];

            // Position car centered within the bike's lane
            int bikeLaneLeft = laneX[currentLane];
            car.Left = bikeLaneLeft + (pictureBox1.Width - car.Width) / 2;
            car.Top = -100; // Start above visible area
            car.BackColor = Color.Transparent;

            Controls.Add(car);
            car.BringToFront();
            pictureBox1.BringToFront();

            obstacleCar = car;

            // Set slow speed for approach phase
            roadSpeed = SlowRoadSpeed;
            carSpeed = SlowCarSpeed;

            // Begin scene
            scenePhase = ScenePhase.Approaching;
            timerRoad.Start();
        }

        /// <summary>
        /// Called when the player answers correctly.
        /// Starts a smooth animated lane change to the target lane.
        /// </summary>
        public void MoveToLaneSmooth(int targetLane)
        {
            if (targetLane < 0 || targetLane > 1) return;
            if (isChangingLane) return;

            currentLane = targetLane;
            bikeTargetX = laneX[targetLane];
            isChangingLane = true;

            // Increase speed for dodge phase
            roadSpeed = NormalRoadSpeed;
            carSpeed = NormalCarSpeed;

            scenePhase = ScenePhase.Dodging;
        }

        /// <summary>
        /// Called when the player answers incorrectly.
        /// Speed increases so collision happens naturally.
        /// </summary>
        public void TriggerWrongAnswer()
        {
            // Increase speed — collision is inevitable
            roadSpeed = NormalRoadSpeed;
            carSpeed = NormalCarSpeed;
            // Scene stays in Approaching — car continues toward bike
        }

        /// <summary>
        /// Returns true if the animation system is busy
        /// (lane change, settling, or crashing).
        /// </summary>
        public bool IsBikeChangingLane()
        {
            return isChangingLane
                || scenePhase == ScenePhase.Dodging
                || scenePhase == ScenePhase.Settling
                || scenePhase == ScenePhase.Crashing;
        }

        /// <summary>
        /// Stops the road timer and clears the obstacle car.
        /// </summary>
        public void StopRoad()
        {
            timerRoad.Stop();
            ClearObstacle();
            scenePhase = ScenePhase.Idle;
        }

        // ════════════════════════════════════════════════════════════════════
        // TIMER TICK — Scene state machine
        // ════════════════════════════════════════════════════════════════════

        private void TimerRoad_Tick(object? sender, EventArgs e)
        {
            // ── Scroll road background ──
            roadOffset += roadSpeed;
            if (roadOffset >= Height)
            {
                roadOffset = 0;
            }
            Invalidate();

            // ── Scene state machine ──
            switch (scenePhase)
            {
                case ScenePhase.Approaching:
                    HandleApproaching();
                    break;

                case ScenePhase.Dodging:
                    HandleDodging();
                    break;

                case ScenePhase.Settling:
                    HandleSettling();
                    break;

                case ScenePhase.Crashing:
                    HandleCrashing();
                    break;

                case ScenePhase.Idle:
                    timerRoad.Stop();
                    break;
            }
        }

        // ════════════════════════════════════════════════════════════════════
        // SCENE PHASE HANDLERS
        // ════════════════════════════════════════════════════════════════════

        /// <summary>
        /// Approaching: car moves slowly toward bike. Waiting for player answer.
        /// Collision triggers crash if player hasn't answered in time.
        /// </summary>
        private void HandleApproaching()
        {
            if (obstacleCar == null) return;

            // Move car downward toward bike
            obstacleCar.Top += carSpeed;

            // Check collision
            if (pictureBox1.Bounds.IntersectsWith(obstacleCar.Bounds))
            {
                StartCrash();
            }
        }

        /// <summary>
        /// Dodging: correct answer submitted. Bike moves laterally to avoid car.
        /// Road and car speed are increased. Bike only moves sideways (no vertical movement).
        /// </summary>
        private void HandleDodging()
        {
            // Move car downward
            if (obstacleCar != null)
            {
                obstacleCar.Top += carSpeed;
            }

            // Smooth lateral bike movement
            if (isChangingLane)
            {
                float dx = bikeTargetX - bikeCurrentX;

                // Calculate lane change speed dynamically based on distance to collision.
                // This ensures the bike always completes the dodge before the car arrives.
                float laneChangeSpeed = 10f; // fallback default

                if (obstacleCar != null)
                {
                    float distanceToCollision = pictureBox1.Top - (obstacleCar.Top + obstacleCar.Height);
                    if (distanceToCollision > 0 && carSpeed > 0)
                    {
                        float framesUntilCollision = distanceToCollision / carSpeed;
                        // Complete the move in 70% of the available frames (safety margin)
                        laneChangeSpeed = Math.Max(8f, Math.Abs(dx) / Math.Max(1f, framesUntilCollision * 0.7f));
                    }
                }

                if (Math.Abs(dx) <= laneChangeSpeed)
                {
                    // Snap to target — lane change complete
                    bikeCurrentX = bikeTargetX;
                    isChangingLane = false;
                }
                else
                {
                    // Move toward target
                    bikeCurrentX += Math.Sign(dx) * laneChangeSpeed;
                }

                pictureBox1.Left = (int)bikeCurrentX;
            }

            // Check if car has passed the bike (car bottom is below bike bottom + margin)
            if (obstacleCar != null && obstacleCar.Top > pictureBox1.Bottom + 20)
            {
                scenePhase = ScenePhase.Settling;
            }

            //// Safety: check collision during dodge (very close timing edge case)
            //if (obstacleCar != null && pictureBox1.Bounds.IntersectsWith(obstacleCar.Bounds))
            //{
            //    StartCrash();
            //}
        }

        /// <summary>
        /// Settling: car has passed the bike. Road decelerates.
        /// Once the car is off-screen, the scene completes.
        /// </summary>
        private void HandleSettling()
        {
            if (obstacleCar != null)
            {
                // Continue moving car off screen
                obstacleCar.Top += carSpeed;

                // Gradually decelerate road and car speed
                if (roadSpeed > SlowRoadSpeed)
                    roadSpeed--;
                if (carSpeed > SlowCarSpeed)
                    carSpeed--;

                // Car is off screen — scene complete
                if (obstacleCar.Top > this.Height)
                {
                    ClearObstacle();
                    roadSpeed = SlowRoadSpeed;
                    carSpeed = SlowCarSpeed;
                    scenePhase = ScenePhase.Idle;
                    timerRoad.Stop();
                    SuccessAnimationComplete?.Invoke(this, EventArgs.Empty);
                }
            }
            else
            {
                // No car present — finish immediately
                scenePhase = ScenePhase.Idle;
                timerRoad.Stop();
                SuccessAnimationComplete?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Initiates the crash sequence (shake animation).
        /// </summary>
        private void StartCrash()
        {
            scenePhase = ScenePhase.Crashing;
            crashTicks = CrashTicksDuration;

            // Stop road and car movement during crash
            roadSpeed = 0;
            carSpeed = 0;
        }

        /// <summary>
        /// Crashing: bike shakes left/right for CrashTicksDuration frames.
        /// When complete, stops everything and fires CollisionDetected.
        /// </summary>
        private void HandleCrashing()
        {
            crashTicks--;

            // Shake bike left/right
            int shakeOffset = (crashTicks % 2 == 0) ? -10 : 10;
            pictureBox1.Left = (int)bikeCurrentX + shakeOffset;

            if (crashTicks <= 0)
            {
                // Reset bike position
                pictureBox1.Left = (int)bikeCurrentX;

                // Stop everything
                scenePhase = ScenePhase.Idle;
                timerRoad.Stop();
                ClearObstacle();

                CollisionDetected?.Invoke(this, EventArgs.Empty);
            }
        }

        // ════════════════════════════════════════════════════════════════════
        // HELPERS
        // ════════════════════════════════════════════════════════════════════

        /// <summary>
        /// Removes and disposes the obstacle car.
        /// </summary>
        private void ClearObstacle()
        {
            if (obstacleCar != null)
            {
                Controls.Remove(obstacleCar);
                obstacleCar.Dispose();
                obstacleCar = null;
            }
        }

        // ════════════════════════════════════════════════════════════════════
        // RENDERING
        // ════════════════════════════════════════════════════════════════════

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (roadImage != null)
            {
                // Performance optimization: fast rendering for scrolling background
                e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Low;
                e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
                e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighSpeed;

                int width = this.Width;
                int height = this.Height;

                // Draw the road twice for seamless vertical scrolling
                e.Graphics.DrawImage(roadImage, 0, roadOffset, width, height);
                e.Graphics.DrawImage(roadImage, 0, roadOffset - height, width, height);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }
    }
}
