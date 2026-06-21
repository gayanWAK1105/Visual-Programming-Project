namespace Visual_Programming
{
    partial class Form5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            animation1 = new Animation();
            textBox1 = new TextBox();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // animation1
            // 
            animation1.BackgroundImageLayout = ImageLayout.Stretch;
            animation1.Location = new Point(36, -6);
            animation1.Name = "animation1";
            animation1.Size = new Size(553, 636);
            animation1.TabIndex = 6;
            animation1.Load += animation1_Load;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(622, 313);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(467, 47);
            textBox1.TabIndex = 8;
            textBox1.TextChanged += textBox1_TextChanged;
            textBox1.KeyDown += textBox1_KeyDown_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Showcard Gothic", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(686, 123);
            label1.Name = "label1";
            label1.Size = new Size(311, 98);
            label1.TabIndex = 11;
            label1.Text = "label1";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(0, 192, 0);
            button1.FlatAppearance.MouseOverBackColor = Color.Green;
            button1.Font = new Font("Showcard Gothic", 22.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ControlLightLight;
            button1.Location = new Point(622, 407);
            button1.Name = "button1";
            button1.Size = new Size(202, 61);
            button1.TabIndex = 12;
            button1.Text = "Submit";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.Blue;
            button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 192);
            button2.Font = new Font("Showcard Gothic", 22.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.ButtonHighlight;
            button2.Location = new Point(887, 407);
            button2.Name = "button2";
            button2.Size = new Size(202, 61);
            button2.TabIndex = 13;
            button2.Text = "Clear";
            button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.Red;
            button3.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 0, 0);
            button3.Font = new Font("Showcard Gothic", 22.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            button3.ForeColor = SystemColors.ControlLightLight;
            button3.Location = new Point(910, 528);
            button3.Name = "button3";
            button3.Size = new Size(179, 68);
            button3.TabIndex = 14;
            button3.Text = "EXIT";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1149, 632);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(animation1);
            Name = "Form5";
            Text = "Form5";
            Load += Form5_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Animation animation1;
        private TextBox textBox1;
        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}