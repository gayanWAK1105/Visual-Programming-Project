namespace Visual_Programming
{
    partial class UserControl2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl2));
            lblLevelUp = new Label();
            btnStart = new Button();
            label1 = new Label();
            label2 = new Label();
            btnExit = new Button();
            btnMenu = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            lblLevelNo = new Label();
            lblLevel = new Label();
            SuspendLayout();
            // 
            // lblLevelUp
            // 
            lblLevelUp.BackColor = Color.Transparent;
            lblLevelUp.FlatStyle = FlatStyle.Flat;
            lblLevelUp.Font = new Font("Showcard Gothic", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLevelUp.ForeColor = Color.White;
            lblLevelUp.Location = new Point(76, 22);
            lblLevelUp.Name = "lblLevelUp";
            lblLevelUp.Size = new Size(623, 190);
            lblLevelUp.TabIndex = 1;
            lblLevelUp.Text = "LEVEL UP!";
            lblLevelUp.TextAlign = ContentAlignment.TopCenter;
            lblLevelUp.Click += lblLevelUp_Click;
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.Blue;
            btnStart.Cursor = Cursors.Hand;
            btnStart.FlatAppearance.BorderSize = 4;
            btnStart.FlatAppearance.MouseOverBackColor = Color.Green;
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.Font = new Font("Showcard Gothic", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnStart.ForeColor = SystemColors.Control;
            btnStart.Location = new Point(284, 489);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(156, 72);
            btnStart.TabIndex = 3;
            btnStart.Text = "START";
            btnStart.UseCompatibleTextRendering = true;
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Showcard Gothic", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(228, 152);
            label1.Name = "label1";
            label1.Size = new Size(256, 50);
            label1.TabIndex = 4;
            label1.Text = "WELL DONE!";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Showcard Gothic", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(204, 202);
            label2.Name = "label2";
            label2.Size = new Size(291, 50);
            label2.TabIndex = 5;
            label2.Text = "You are now";
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Blue;
            btnExit.Cursor = Cursors.Hand;
            btnExit.FlatAppearance.BorderSize = 4;
            btnExit.FlatAppearance.MouseOverBackColor = Color.Red;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Showcard Gothic", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExit.ForeColor = SystemColors.Control;
            btnExit.Location = new Point(531, 489);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(155, 72);
            btnExit.TabIndex = 6;
            btnExit.Text = "EXIT";
            btnExit.UseCompatibleTextRendering = true;
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // btnMenu
            // 
            btnMenu.BackColor = Color.Blue;
            btnMenu.FlatAppearance.BorderSize = 4;
            btnMenu.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 64);
            btnMenu.FlatStyle = FlatStyle.Flat;
            btnMenu.Font = new Font("Showcard Gothic", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnMenu.ForeColor = SystemColors.ControlLightLight;
            btnMenu.Location = new Point(36, 489);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(157, 72);
            btnMenu.TabIndex = 7;
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
            // lblLevelNo
            // 
            lblLevelNo.AutoSize = true;
            lblLevelNo.BackColor = Color.Transparent;
            lblLevelNo.Font = new Font("Showcard Gothic", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLevelNo.ForeColor = Color.Blue;
            lblLevelNo.Location = new Point(367, 272);
            lblLevelNo.Name = "lblLevelNo";
            lblLevelNo.Size = new Size(0, 98);
            lblLevelNo.TabIndex = 8;
            // 
            // lblLevel
            // 
            lblLevel.AutoSize = true;
            lblLevel.BackColor = Color.Transparent;
            lblLevel.Font = new Font("Showcard Gothic", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLevel.ForeColor = Color.Blue;
            lblLevel.Location = new Point(204, 287);
            lblLevel.Name = "lblLevel";
            lblLevel.Size = new Size(134, 50);
            lblLevel.TabIndex = 9;
            lblLevel.Text = "LEVEL";
            // 
            // UserControl2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(lblLevel);
            Controls.Add(lblLevelNo);
            Controls.Add(btnMenu);
            Controls.Add(btnExit);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnStart);
            Controls.Add(lblLevelUp);
            DoubleBuffered = true;
            MaximumSize = new Size(714, 589);
            MinimumSize = new Size(714, 589);
            Name = "UserControl2";
            Size = new Size(714, 589);
            Load += UserControl2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblLevelUp;
        private Button btnStart;
        private Label label1;
        private Label label2;
        private Button btnExit;
        private Button btnMenu;
        private System.Windows.Forms.Timer timer1;
        private Label lblLevelNo;
        private Label lblLevel;
    }
}
