using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace VidAutoFrontEnd
{
    public partial class AssetUploadForm : Form
    {
        public AssetUploadForm()
        {
            InitializeComponent();
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string assetsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets");

                // Ensure the Assets directory exists
                if (!Directory.Exists(assetsDirectory))
                {
                    Directory.CreateDirectory(assetsDirectory);
                }

                string[] files = openFileDialog.FileNames;
                foreach (string file in files)
                {
                    string fileName = Path.GetFileName(file);
                    string destinationPath = Path.Combine(assetsDirectory, fileName);
                    File.Copy(file, destinationPath, true);
                    MessageBox.Show($"File '{fileName}' has been uploaded successfully.");

                    // Display the uploaded file in the FlowLayoutPanel
                    DisplayUploadedFile(destinationPath);
                }
            }
        }

        private void DisplayUploadedFile(string filePath)
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Size = new Size(100, 100);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Image = Image.FromFile(filePath);
            pictureBox.Click += (s, e) => MessageBox.Show($"You clicked on {Path.GetFileName(filePath)}");
            flowLayoutPanel.Controls.Add(pictureBox);
        }
    }
}

