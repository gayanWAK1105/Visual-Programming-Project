namespace Visual_Programming
{
    partial class menuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(menuForm));
            label1 = new Label();
            btnStart = new Button();
            txtName = new TextBox();
            lblGo = new Label();
            button1 = new Button();
            label2 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Showcard Gothic", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Blue;
            label1.Location = new Point(534, 71);
            label1.Name = "label1";
            label1.Size = new Size(154, 54);
            label1.TabIndex = 0;
            label1.Text = "RIDER";
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.FromArgb(0, 64, 0);
            btnStart.Cursor = Cursors.Hand;
            btnStart.FlatAppearance.BorderColor = Color.White;
            btnStart.FlatAppearance.BorderSize = 4;
            btnStart.FlatAppearance.MouseOverBackColor = Color.Blue;
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.Font = new Font("Showcard Gothic", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnStart.ForeColor = Color.White;
            btnStart.Location = new Point(525, 620);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(184, 64);
            btnStart.TabIndex = 1;
            btnStart.Text = "START";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // txtName
            // 
            txtName.Cursor = Cursors.IBeam;
            txtName.Font = new Font("Showcard Gothic", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtName.Location = new Point(504, 473);
            txtName.Name = "txtName";
            txtName.Size = new Size(340, 57);
            txtName.TabIndex = 2;
            txtName.TextAlign = HorizontalAlignment.Center;
            txtName.TextChanged += txtName_TextChanged;
            txtName.KeyDown += txtName_KeyDown;
            // 
            // lblGo
            // 
            lblGo.AutoSize = true;
            lblGo.BackColor = Color.Transparent;
            lblGo.Font = new Font("Showcard Gothic", 72F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGo.ForeColor = Color.FromArgb(0, 64, 0);
            lblGo.Location = new Point(328, 125);
            lblGo.Name = "lblGo";
            lblGo.Size = new Size(622, 149);
            lblGo.TabIndex = 3;
            lblGo.Text = "LET'S  GO!";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(0, 64, 0);
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderColor = Color.White;
            button1.FlatAppearance.BorderSize = 4;
            button1.FlatAppearance.MouseOverBackColor = Color.Red;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Showcard Gothic", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(1127, 620);
            button1.Name = "button1";
            button1.Size = new Size(143, 64);
            button1.TabIndex = 4;
            button1.Text = "EXIT";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Showcard Gothic", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Beige;
            label2.Location = new Point(153, 473);
            label2.Name = "label2";
            label2.Size = new Size(324, 54);
            label2.TabIndex = 5;
            label2.Text = "New Account";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.Transparent;
            flowLayoutPanel1.Location = new Point(521, 315);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(310, 150);
            flowLayoutPanel1.TabIndex = 6;
            // 
            // menuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1298, 696);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(lblGo);
            Controls.Add(txtName);
            Controls.Add(btnStart);
            Controls.Add(label1);
            DoubleBuffered = true;
            Name = "menuForm";
            Text = "ALGORIDE";
            FormClosed += menuForm_FormClosed;
            Load += menuForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnStart;
        private TextBox txtName;
        private Label lblGo;
        private Button button1;
        private Label label2;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}