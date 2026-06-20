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
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Showcard Gothic", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Blue;
            label1.Location = new Point(477, 71);
            label1.Name = "label1";
            label1.Size = new Size(269, 54);
            label1.TabIndex = 0;
            label1.Text = "YOUR NAME";
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.FromArgb(0, 64, 0);
            btnStart.Cursor = Cursors.Hand;
            btnStart.FlatAppearance.BorderSize = 0;
            btnStart.FlatAppearance.MouseOverBackColor = Color.Blue;
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.Font = new Font("Showcard Gothic", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnStart.ForeColor = Color.White;
            btnStart.Location = new Point(514, 620);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(202, 64);
            btnStart.TabIndex = 1;
            btnStart.Text = "START";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Visible = false;
            // 
            // txtName
            // 
            txtName.Cursor = Cursors.IBeam;
            txtName.Font = new Font("Showcard Gothic", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtName.Location = new Point(443, 143);
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
            lblGo.Location = new Point(327, 251);
            lblGo.Name = "lblGo";
            lblGo.Size = new Size(622, 149);
            lblGo.TabIndex = 3;
            lblGo.Text = "LET'S  GO!";
            lblGo.Visible = false;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(0, 64, 0);
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
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
            // menuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1298, 696);
            Controls.Add(button1);
            Controls.Add(lblGo);
            Controls.Add(txtName);
            Controls.Add(btnStart);
            Controls.Add(label1);
            DoubleBuffered = true;
            Name = "menuForm";
            Text = "ALGORIDE";
            FormClosed += menuForm_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnStart;
        private TextBox txtName;
        private Label lblGo;
        private Button button1;
    }
}