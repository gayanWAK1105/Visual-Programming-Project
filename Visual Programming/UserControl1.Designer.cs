namespace Visual_Programming
{
    partial class UserControl1
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl1));
            lblGameOver = new Label();
            btnExit = new Button();
            btnStart = new Button();
            btnMenu = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            scoreLBL = new Label();
            lblScore = new Label();
            SuspendLayout();
            // 
            // lblGameOver
            // 
            lblGameOver.BackColor = Color.Transparent;
            lblGameOver.FlatStyle = FlatStyle.Flat;
            lblGameOver.Font = new Font("Showcard Gothic", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGameOver.ForeColor = Color.FromArgb(64, 0, 0);
            lblGameOver.Location = new Point(22, 29);
            lblGameOver.Name = "lblGameOver";
            lblGameOver.Size = new Size(664, 169);
            lblGameOver.TabIndex = 0;
            lblGameOver.Text = "GAME OVER!";
            lblGameOver.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.FromArgb(64, 0, 0);
            btnExit.Cursor = Cursors.Hand;
            btnExit.FlatAppearance.BorderSize = 4;
            btnExit.FlatAppearance.MouseOverBackColor = Color.Red;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Showcard Gothic", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExit.ForeColor = SystemColors.Control;
            btnExit.Location = new Point(542, 505);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(155, 72);
            btnExit.TabIndex = 1;
            btnExit.Text = "EXIT";
            btnExit.UseCompatibleTextRendering = true;
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += button1_Click;
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.FromArgb(64, 0, 0);
            btnStart.Cursor = Cursors.Hand;
            btnStart.FlatAppearance.BorderSize = 4;
            btnStart.FlatAppearance.MouseOverBackColor = Color.Green;
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.Font = new Font("Showcard Gothic", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnStart.ForeColor = SystemColors.Control;
            btnStart.Location = new Point(22, 505);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(156, 72);
            btnStart.TabIndex = 2;
            btnStart.Text = "START";
            btnStart.UseCompatibleTextRendering = true;
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // btnMenu
            // 
            btnMenu.BackColor = Color.FromArgb(64, 0, 0);
            btnMenu.FlatAppearance.BorderSize = 4;
            btnMenu.FlatAppearance.MouseOverBackColor = Color.Navy;
            btnMenu.FlatStyle = FlatStyle.Flat;
            btnMenu.Font = new Font("Showcard Gothic", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnMenu.ForeColor = SystemColors.ControlLightLight;
            btnMenu.Location = new Point(282, 505);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(157, 72);
            btnMenu.TabIndex = 3;
            btnMenu.Text = "MENU";
            btnMenu.UseCompatibleTextRendering = true;
            btnMenu.UseVisualStyleBackColor = false;
            btnMenu.Click += btnMenu_Click;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 40;
            timer1.Tick += timer1_Tick;
            // 
            // scoreLBL
            // 
            scoreLBL.AutoSize = true;
            scoreLBL.BackColor = Color.Transparent;
            scoreLBL.Font = new Font("Showcard Gothic", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            scoreLBL.ForeColor = Color.Black;
            scoreLBL.Location = new Point(282, 183);
            scoreLBL.Name = "scoreLBL";
            scoreLBL.Size = new Size(144, 50);
            scoreLBL.TabIndex = 4;
            scoreLBL.Text = "SCORE";
            scoreLBL.Click += label1_Click;
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.BackColor = Color.Transparent;
            lblScore.Font = new Font("Showcard Gothic", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblScore.Location = new Point(346, 268);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(0, 50);
            lblScore.TabIndex = 5;
            // 
            // UserControl1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            BorderStyle = BorderStyle.Fixed3D;
            Controls.Add(lblScore);
            Controls.Add(scoreLBL);
            Controls.Add(btnMenu);
            Controls.Add(btnStart);
            Controls.Add(btnExit);
            Controls.Add(lblGameOver);
            DoubleBuffered = true;
            MaximumSize = new Size(718, 593);
            MinimumSize = new Size(718, 593);
            Name = "UserControl1";
            Size = new Size(714, 589);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblGameOver;
        private Button btnExit;
        private Button btnStart;
        private Button btnMenu;
        private System.Windows.Forms.Timer timer1;
        private Label scoreLBL;
        private Label lblScore;
    }
}
