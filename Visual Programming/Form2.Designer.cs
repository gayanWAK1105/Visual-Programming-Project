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
            button1 = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            animation1 = new Animation();
            pauseButton = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(921, 539);
            button1.Name = "button1";
            button1.Size = new Size(202, 61);
            button1.TabIndex = 0;
            button1.Text = "Submit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(1186, 539);
            button2.Name = "button2";
            button2.Size = new Size(202, 61);
            button2.TabIndex = 1;
            button2.Text = "Clear";
            button2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(921, 468);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(467, 47);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged_1;
            textBox1.KeyDown += textBox1_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(921, 341);
            label1.Name = "label1";
            label1.Size = new Size(104, 41);
            label1.TabIndex = 3;
            label1.Text = "label1";
            label1.Click += label1_Click;
            // 
            // animation1
            // 
            animation1.BackgroundImageLayout = ImageLayout.Stretch;
            animation1.Location = new Point(98, 105);
            animation1.Name = "animation1";
            animation1.Size = new Size(619, 636);
            animation1.TabIndex = 4;
            animation1.Load += animation1_Load;
            // 
            // pauseButton
            // 
            pauseButton.BackColor = Color.Transparent;
            pauseButton.BackgroundImage = (Image)resources.GetObject("pauseButton.BackgroundImage");
            pauseButton.BackgroundImageLayout = ImageLayout.Stretch;
            pauseButton.FlatStyle = FlatStyle.Flat;
            pauseButton.Location = new Point(611, 18);
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
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1536, 859);
            Controls.Add(label2);
            Controls.Add(pauseButton);
            Controls.Add(animation1);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private Label label1;
        private Animation animation1;
        private Button pauseButton;
        private Label label2;
    }
}