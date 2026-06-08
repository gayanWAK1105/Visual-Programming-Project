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
    public enum AnimationMode
    {
        None,
        Success,
        Fail
    }

    public partial class Animation : UserControl
    {
        public event EventHandler? SuccessAnimationComplete;
        public event EventHandler? CollisionDetected;

        private Random random = new Random();

        // Road movement speed
        private int roadSpeed = 5;

        // Animation variables
        private int animationTicks = 0;
        private AnimationMode animationMode = AnimationMode.None;

        // Lane configurations
        private int currentLane = 0;
        private readonly int[] laneX = { 30, 120, 210, 300 };

        // Timers
        private System.Windows.Forms.Timer timerRoad;
        private System.Windows.Forms.Timer timerSpawn;

        // Spawned obstacles
        private List<PictureBox> activeCars = new List<PictureBox>();

        // Car image pool
        private Image[] carImages;

        public Animation()
        {
            InitializeComponent();
            // Set parent to this UserControl so transparency works correctly without being clipped when roads move
            pictureBox1.Parent = pictureBox2;
            pictureBox1.BackColor = Color.Transparent;

            // Setup resource pool
            carImages = new Image[]
            {
                Properties.Resources.car_3_blue,
                Properties.Resources.car_black,
                Properties.Resources.car_red,
                Properties.Resources.car_yellow
            };

            


            pictureBox2.Left = 0;
            pictureBox3.Left = 0;
            pictureBox2.Top = 0;
            pictureBox3.Top = -pictureBox2.Height;

            pictureBox1.Left = laneX[currentLane];
            pictureBox1.Top = 366;
            pictureBox1.Visible = true;

            // Ensure Z-ordering
            pictureBox2.SendToBack();
            pictureBox3.SendToBack();
            pictureBox1.BringToFront();

            // Double buffering to prevent flickering
            this.DoubleBuffered = true;

            // Initialize components container if not already initialized
            if (this.components == null)
            {
                this.components = new System.ComponentModel.Container();
            }

            // Initialize timers and register for automatic disposal
            timerRoad = new System.Windows.Forms.Timer(this.components);
            timerRoad.Interval = 20; // 50 FPS
            timerRoad.Tick += TimerRoad_Tick;

            timerSpawn = new System.Windows.Forms.Timer(this.components);
            timerSpawn.Interval = 2500; // Spawn every 2.5 seconds
            timerSpawn.Tick += TimerSpawn_Tick;
        }

        public void StartRoad()
        {
            timerRoad.Start();
            timerSpawn.Start();
        }

        public void StopRoad()
        {
            timerRoad.Stop();
            timerSpawn.Stop();
            ClearCars();
        }

        public void ClearCars()
        {
            foreach (var car in activeCars)
            {
                Controls.Remove(car);
                car.Dispose();
            }
            activeCars.Clear();
        }

        public void MoveToLane(int lane)
        {
            if (lane < 0 || lane > 3)
                return;

            currentLane = lane;
            pictureBox1.Left = laneX[currentLane];
        }

        public void MoveLeft()
        {
            if (currentLane > 0)
            {
                currentLane--;
                pictureBox1.Left = laneX[currentLane];
            }
        }

        public void MoveRight()
        {
            if (currentLane < 3)
            {
                currentLane++;
                pictureBox1.Left = laneX[currentLane];
            }
        }

        public void PlaySuccessAnimation()
        {
            roadSpeed = 20;
            animationTicks = 40;
            animationMode = AnimationMode.Success;
            StartRoad(); // Ensure road is running to show the animation
        }

        public void PlayFailureAnimation()
        {
            animationMode = AnimationMode.Fail;
            animationTicks = 20;
            StartRoad(); // Ensure road is running to show the shake animation
        }

        private void SpawnCar()
        {
            PictureBox car = new PictureBox();
            car.Width = 50;
            car.Height = 80;
            car.SizeMode = PictureBoxSizeMode.StretchImage;
            car.Image = carImages[random.Next(carImages.Length)];

            int lane = random.Next(0, 4);
            car.Left = laneX[lane];
            car.Top = -100;
            car.Parent = this;
            car.BackColor = Color.Transparent;

            activeCars.Add(car);
            Controls.Add(car);

            car.BringToFront();
            pictureBox1.BringToFront();
        }

        private void TimerRoad_Tick(object? sender, EventArgs e)
        {
            // Scroll road images
            pictureBox2.Top += roadSpeed;
            pictureBox3.Top += roadSpeed;

            if (pictureBox2.Top >= pictureBox2.Height)
            {
                pictureBox2.Top = pictureBox3.Top - pictureBox2.Height;
            }

            if (pictureBox3.Top >= pictureBox3.Height)
            {
                pictureBox3.Top = pictureBox2.Top - pictureBox3.Height;
            }

            // Move active obstacle cars
            for (int i = activeCars.Count - 1; i >= 0; i--)
            {
                PictureBox car = activeCars[i];
                car.Top += roadSpeed;

                // Remove car if it goes off screen
                if (car.Top > this.Height)
                {
                    Controls.Remove(car);
                    activeCars.RemoveAt(i);
                    car.Dispose();
                }
            }

            // Handle active animation ticks
            if (animationTicks > 0)
            {
                animationTicks--;

                if (animationMode == AnimationMode.Success)
                {
                    if (animationTicks == 0)
                    {
                        roadSpeed = 5;
                        animationMode = AnimationMode.None;
                        StopRoad(); // Pause game after success animation completes
                        SuccessAnimationComplete?.Invoke(this, EventArgs.Empty);
                    }
                }
                else if (animationMode == AnimationMode.Fail)
                {
                    // Bike shake left/right
                    int shakeOffset = (animationTicks % 2 == 0) ? -10 : 10;
                    pictureBox1.Left = laneX[currentLane] + shakeOffset;

                    if (animationTicks == 0)
                    {
                        pictureBox1.Left = laneX[currentLane];
                        animationMode = AnimationMode.None;
                        StopRoad(); // Stop completely
                    }
                }
            }

            // Collision detection
            if (animationMode != AnimationMode.Fail)
            {
                foreach (PictureBox car in activeCars)
                {
                    if (pictureBox1.Bounds.IntersectsWith(car.Bounds))
                    {
                        PlayFailureAnimation();
                        CollisionDetected?.Invoke(this, EventArgs.Empty);
                        break;
                    }
                }
            }
        }

        private void TimerSpawn_Tick(object? sender, EventArgs e)
        {
            // Only spawn if we are not currently playing failure animation
            if (animationMode != AnimationMode.Fail)
            {
                SpawnCar();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
