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
            label1 = new Label();
            btnExit = new Button();
            btnStart = new Button();
            btnMenu = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Showcard Gothic", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(64, 0, 0);
            label1.Location = new Point(96, 50);
            label1.Name = "label1";
            label1.Size = new Size(513, 98);
            label1.TabIndex = 0;
            label1.Text = "GAME OVER!";
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.FromArgb(64, 0, 0);
            btnExit.Cursor = Cursors.Hand;
            btnExit.FlatAppearance.MouseOverBackColor = Color.Red;
            btnExit.Font = new Font("Showcard Gothic", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExit.ForeColor = SystemColors.Control;
            btnExit.Location = new Point(559, 515);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(144, 62);
            btnExit.TabIndex = 1;
            btnExit.Text = "EXIT";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += button1_Click;
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.FromArgb(64, 0, 0);
            btnStart.Cursor = Cursors.Hand;
            btnStart.FlatAppearance.MouseOverBackColor = Color.Green;
            btnStart.Font = new Font("Showcard Gothic", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnStart.ForeColor = SystemColors.Control;
            btnStart.Location = new Point(22, 515);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(156, 62);
            btnStart.TabIndex = 2;
            btnStart.Text = "START";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // btnMenu
            // 
            btnMenu.BackColor = Color.FromArgb(64, 0, 0);
            btnMenu.FlatAppearance.MouseOverBackColor = Color.Navy;
            btnMenu.Font = new Font("Showcard Gothic", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnMenu.ForeColor = SystemColors.ControlLightLight;
            btnMenu.Location = new Point(300, 515);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(141, 62);
            btnMenu.TabIndex = 3;
            btnMenu.Text = "MENU";
            btnMenu.UseVisualStyleBackColor = false;
            btnMenu.Click += btnMenu_Click;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 40;
            timer1.Tick += timer1_Tick;
            // 
            // UserControl1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(btnMenu);
            Controls.Add(btnStart);
            Controls.Add(btnExit);
            Controls.Add(label1);
            DoubleBuffered = true;
            Name = "UserControl1";
            Size = new Size(722, 597);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnExit;
        private Button btnStart;
        private Button btnMenu;
        private System.Windows.Forms.Timer timer1;
    }
}
