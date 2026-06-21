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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();

            timer1.Interval = 100;

            timer1.Start();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
           
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            
        }
    }
}
