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
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            menuForm menu = new menuForm();
            menu.Show();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

        }

        private float minFontSize = 36f; 
        private float maxFontSize = 46f; 
        private float currentFontSize = 40f;
        private bool growing = true; 
        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
