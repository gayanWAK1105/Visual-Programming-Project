namespace Visual_Programming
{
    partial class Form6
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form6));
            label1 = new Label();
            levelLabel = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Showcard Gothic", 48F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.ForestGreen;
            label1.Location = new Point(378, 56);
            label1.Name = "label1";
            label1.Size = new Size(270, 98);
            label1.TabIndex = 0;
            label1.Text = "LEVEL";
            // 
            // levelLabel
            // 
            levelLabel.AutoSize = true;
            levelLabel.BackColor = Color.Transparent;
            levelLabel.Font = new Font("Showcard Gothic", 72F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            levelLabel.ForeColor = Color.Black;
            levelLabel.Location = new Point(432, 154);
            levelLabel.Name = "levelLabel";
            levelLabel.Size = new Size(128, 149);
            levelLabel.TabIndex = 1;
            levelLabel.Text = "7";
            // 
            // Form6
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1066, 782);
            Controls.Add(levelLabel);
            Controls.Add(label1);
            ForeColor = SystemColors.ButtonShadow;
            Name = "Form6";
            Text = "Form6";
            Load += Form6_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label levelLabel;
    }
}