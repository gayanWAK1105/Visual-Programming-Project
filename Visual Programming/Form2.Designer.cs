namespace Visual_Programming
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            textBox1 = new TextBox();
            animation1 = new Animation();
            pauseButton = new Button();
            label2 = new Label();
            label1 = new Label();
            button1 = new Button();
            button3 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.CausesValidation = false;
            textBox1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(648, 263);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(467, 47);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged_1;
            textBox1.KeyDown += textBox1_KeyDown;
            // 
            // animation1
            // 
            animation1.BackgroundImageLayout = ImageLayout.Stretch;
            animation1.Location = new Point(36, 2);
            animation1.Name = "animation1";
            animation1.Size = new Size(563, 607);
            animation1.TabIndex = 4;
            animation1.Load += animation1_Load;
            // 
            // pauseButton
            // 
            pauseButton.BackColor = Color.Transparent;
            pauseButton.BackgroundImage = (Image)resources.GetObject("pauseButton.BackgroundImage");
            pauseButton.BackgroundImageLayout = ImageLayout.Stretch;
            pauseButton.FlatStyle = FlatStyle.Flat;
            pauseButton.Location = new Point(1021, 35);
            pauseButton.Name = "pauseButton";
            pauseButton.Size = new Size(94, 81);
            pauseButton.TabIndex = 5;
            pauseButton.TextAlign = ContentAlignment.TopCenter;
            pauseButton.UseVisualStyleBackColor = false;
            pauseButton.Click += pauseButton_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(98, 47);
            label2.Name = "label2";
            label2.Size = new Size(104, 41);
            label2.TabIndex = 6;
            label2.Text = "label2";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Showcard Gothic", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(710, 104);
            label1.Name = "label1";
            label1.Size = new Size(311, 98);
            label1.TabIndex = 7;
            label1.Text = "label1";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(0, 192, 0);
            button1.FlatAppearance.MouseOverBackColor = Color.Green;
            button1.Font = new Font("Showcard Gothic", 22.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ControlLightLight;
            button1.Location = new Point(648, 352);
            button1.Name = "button1";
            button1.Size = new Size(202, 61);
            button1.TabIndex = 9;
            button1.Text = "Submit";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.Red;
            button3.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 0, 0);
            button3.Font = new Font("Showcard Gothic", 22.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            button3.ForeColor = SystemColors.ControlLightLight;
            button3.Location = new Point(936, 502);
            button3.Name = "button3";
            button3.Size = new Size(179, 68);
            button3.TabIndex = 11;
            button3.Text = "EXIT";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Blue;
            button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 192);
            button2.Font = new Font("Showcard Gothic", 22.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.ButtonHighlight;
            button2.Location = new Point(913, 352);
            button2.Name = "button2";
            button2.Size = new Size(202, 61);
            button2.TabIndex = 12;
            button2.Text = "Clear";
            button2.UseVisualStyleBackColor = false;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1149, 609);
            Controls.Add(pauseButton);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(animation1);
            Name = "Form2";
            Text = "Form2";
            KeyDown += Form2_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox1;
        private Animation animation1;
        private Button pauseButton;
        private Label label2;
        private Label label1;
        private Button button1;
        private Button button3;
        private Button button2;
    }
}