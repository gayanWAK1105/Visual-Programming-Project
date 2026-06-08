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
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(1012, 661);
            button1.Name = "button1";
            button1.Size = new Size(202, 62);
            button1.TabIndex = 0;
            button1.Text = "Submit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(1277, 661);
            button2.Name = "button2";
            button2.Size = new Size(202, 62);
            button2.TabIndex = 1;
            button2.Text = "Clear";
            button2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(1012, 503);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(467, 120);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1012, 289);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 3;
            label1.Text = "label1";
            label1.Click += label1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ButtonFace;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(188, 465);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(553, 258);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1536, 858);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private Label label1;
        private PictureBox pictureBox1;
    }
}