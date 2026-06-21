using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO; // Added for file operations
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visual_Programming
{
    public partial class menuForm : Form
    {
        public menuForm()
        {
            InitializeComponent();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string enteredName = txtName.Text.Trim();

                if (enteredName != "")
                {
                    try
                    {
                        // 1. CHANGE THIS TO YOUR EXACT FOLDER PATH
                        // The '@' symbol allows you to use normal backslashes (\) without errors
                        string targetFolderPath = @"C:\Users\sthmu\Desktop\Users";

                        // 2. Automatically create the folder if it doesn't exist yet
                        if (!Directory.Exists(targetFolderPath))
                        {
                            Directory.CreateDirectory(targetFolderPath);
                        }

                        // 3. Clean the input to remove invalid characters (like /, \, :, *, etc.)
                        string safeFileName = string.Join("_", enteredName.Split(Path.GetInvalidFileNameChars()));

                        // 4. Combine your custom path and the file name safely
                        string filePath = Path.Combine(targetFolderPath, safeFileName + ".txt");

                        // 5. Create the text file and write content into it
                        using (StreamWriter sw = File.CreateText(filePath))
                        {
                            sw.WriteLine("=====================================");
                            sw.WriteLine("         ALGORIDE USER PROFILE       ");
                            sw.WriteLine("=====================================");
                            sw.WriteLine("User Name: " + enteredName);
                            sw.WriteLine("Created On: " + DateTime.Now.ToString("F"));
                            sw.WriteLine("=====================================");
                        }

                        // 6. Reveal UI elements
                        lblGo.Visible = true;
                        btnStart.Visible = true;



                        e.SuppressKeyPress = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while creating the file: " + ex.Message,
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter your name!", "ALGORIDE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
            DialogResult dialogResult = MessageBox.Show(
                "Do you want to exit the game?",
                "ALGORIDE - Exit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
            
        }
        

        private void menuForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.ShowDialog();
        }

        private void menuForm_Load(object sender, EventArgs e)
        {

        }

        private void btnStart_Click_1(object sender, EventArgs e)
        {
            Form1 form1=new Form1();
            this.Hide();
            form1.ShowDialog();
        }
    }
}