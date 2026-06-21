using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visual_Programming
{
    public partial class UserControl2 : UserControl
    {
        public UserControl2()
        {
            InitializeComponent();
        }

        private void UserControl2_Load(object sender, EventArgs e)
        {

        }

        private void lblLevelUp_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private float minFontSize = 48f;
        private float maxFontSize = 60f;
        private float currentFontSize = 55f;
        private bool growing = true;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (growing)
            {
                currentFontSize += 0.5f; // increase the forn size gradually
                if (currentFontSize >= maxFontSize)
                {
                    growing = false;
                }
            }
            else
            {
                currentFontSize -= 0.5f; // decrease the font size gradually
                if (currentFontSize <= minFontSize)
                {
                    growing = true; // start growing again when reaching the minimum size
                }
            }


            lblLevelUp.Font = new Font(lblLevelUp.Font.FontFamily, currentFontSize, lblLevelUp.Font.Style);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

        }

        public void setLevel(string level)
        {
            lblLevelNo.Text = level;
        }
    }

}


