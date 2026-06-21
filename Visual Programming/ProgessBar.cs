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
    public partial class ProgessBar : UserControl
    {
        // ── Bike travel constants ───────────────────────────────────────────
        private const float StartX = 0f;
        private const float FinishX = 210f;
        private const int BikeY = 14;

        // ── Animation state ─────────────────────────────────────────────────
        private float currentX = StartX;
        private float targetX = StartX;
        private System.Windows.Forms.Timer animTimer;

        public ProgessBar()
        {
            InitializeComponent();

            // Force bike to starting position
            pictureBox1.Left = (int)StartX;
            pictureBox1.Top = BikeY;

            // Setup smooth animation timer (~60 FPS)
            animTimer = new System.Windows.Forms.Timer();
            animTimer.Interval = 16;
            animTimer.Tick += AnimTimer_Tick;
        }

        // ════════════════════════════════════════════════════════════════════
        // PUBLIC API
        // ════════════════════════════════════════════════════════════════════

        /// <summary>
        /// Sets the progress percentage and smoothly animates the bike.
        /// </summary>
        /// <param name="percentage">Value from 0.0 to 1.0</param>
        public void SetProgress(float percentage)
        {
            percentage = Math.Clamp(percentage, 0f, 1f);
            targetX = StartX + percentage * (FinishX - StartX);
            animTimer.Start();
        }

        /// <summary>
        /// Instantly sets the bike to a specific progress without animation.
        /// Used when restoring saved state.
        /// </summary>
        /// <param name="percentage">Value from 0.0 to 1.0</param>
        public void SetProgressImmediate(float percentage)
        {
            percentage = Math.Clamp(percentage, 0f, 1f);
            currentX = StartX + percentage * (FinishX - StartX);
            targetX = currentX;
            pictureBox1.Left = (int)currentX;
            pictureBox1.Top = BikeY;
            animTimer.Stop();
        }

        /// <summary>
        /// Resets the bike to the starting position with no animation.
        /// </summary>
        public void ResetProgress()
        {
            currentX = StartX;
            targetX = StartX;
            pictureBox1.Left = (int)StartX;
            pictureBox1.Top = BikeY;
            animTimer.Stop();
        }

        // ════════════════════════════════════════════════════════════════════
        // ANIMATION
        // ════════════════════════════════════════════════════════════════════

        private void AnimTimer_Tick(object? sender, EventArgs e)
        {
            float dx = targetX - currentX;

            if (Math.Abs(dx) < 1f)
            {
                // Snap to target — animation complete
                currentX = targetX;
                pictureBox1.Left = (int)currentX;
                pictureBox1.Top = BikeY;
                animTimer.Stop();
                return;
            }

            // Smooth ease-out interpolation
            currentX += dx * 0.15f;
            pictureBox1.Left = (int)currentX;
            pictureBox1.Top = BikeY;
        }
    }
}
