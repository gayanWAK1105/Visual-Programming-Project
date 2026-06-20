namespace Visual_Programming
{
    partial class Form8
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form8));
            button1 = new Button();
            progressBar = new ProgressBar();
            timer = new System.Windows.Forms.Timer(components);
            label1 = new Label();
            lblPercentage = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(0, 64, 0);
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseOverBackColor = Color.Red;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Showcard Gothic", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(1115, 611);
            button1.Name = "button1";
            button1.Size = new Size(152, 61);
            button1.TabIndex = 0;
            button1.Text = "EXIT";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // progressBar
            // 
            progressBar.BackColor = Color.FromArgb(64, 64, 64);
            progressBar.ForeColor = Color.FromArgb(0, 192, 0);
            progressBar.Location = new Point(445, 264);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(363, 40);
            progressBar.TabIndex = 1;
            progressBar.Click += progressBar1_Click;
            // 
            // timer
            // 
            timer.Enabled = true;
            timer.Tick += timer1_Tick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Showcard Gothic", 72F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(321, 43);
            label1.Name = "label1";
            label1.Size = new Size(643, 149);
            label1.TabIndex = 2;
            label1.Text = "ALGORIDE";
            // 
            // lblPercentage
            // 
            lblPercentage.AutoSize = true;
            lblPercentage.BackColor = Color.Transparent;
            lblPercentage.Font = new Font("Showcard Gothic", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPercentage.ForeColor = Color.Black;
            lblPercentage.Location = new Point(572, 202);
            lblPercentage.Name = "lblPercentage";
            lblPercentage.Size = new Size(0, 59);
            lblPercentage.TabIndex = 3;
            lblPercentage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form8
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1298, 696);
            Controls.Add(lblPercentage);
            Controls.Add(label1);
            Controls.Add(progressBar);
            Controls.Add(button1);
            DoubleBuffered = true;
            Name = "Form8";
            Text = "ALGORIDE";
            FormClosed += Form8_FormClosed;
            Load += Form8_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private ProgressBar progressBar;
        private System.Windows.Forms.Timer timer;
        private Label label1;
        private Label lblPercentage;
    }
}