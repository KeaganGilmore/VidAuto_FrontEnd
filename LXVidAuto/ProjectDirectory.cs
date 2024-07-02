using System;
using System.Drawing;
using System.Windows.Forms;

public class ProjectDirectory : UserControl
{
    private FlowLayoutPanel assetsPanel;
    private Button uploadButton;

    public event Action<string>? AssetUploaded;

    public ProjectDirectory()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        this.assetsPanel = new FlowLayoutPanel();
        this.uploadButton = new Button();

        // Upload Button configuration
        this.uploadButton.Text = "Upload Asset";
        this.uploadButton.Dock = DockStyle.Top;
        this.uploadButton.Click += UploadButton_Click;

        // Assets Panel configuration
        this.assetsPanel.Dock = DockStyle.Fill;
        this.assetsPanel.AutoScroll = true;
        this.assetsPanel.AllowDrop = true;

        // ProjectDirectory configuration
        this.Controls.Add(this.assetsPanel);
        this.Controls.Add(this.uploadButton);
    }

    private void UploadButton_Click(object? sender, EventArgs e)
    {
        using OpenFileDialog openFileDialog = new OpenFileDialog
        {
            Filter = "Image Files (*.png; *.jpg; *.jpeg)|*.png; *.jpg; *.jpeg",
            Multiselect = true
        };

        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            foreach (string filePath in openFileDialog.FileNames)
            {
                AddAssetToDirectory(filePath);
            }
        }
    }

    private void AddAssetToDirectory(string filePath)
    {
        PictureBox assetPictureBox = new PictureBox
        {
            Size = new Size(100, 100),
            SizeMode = PictureBoxSizeMode.Zoom,
            Image = Image.FromFile(filePath),
            Tag = filePath
        };

        assetPictureBox.MouseDown += AssetPictureBox_MouseDown;

        this.assetsPanel.Controls.Add(assetPictureBox);

        AssetUploaded?.Invoke(filePath);
    }

    private void AssetPictureBox_MouseDown(object? sender, MouseEventArgs e)
    {
        if (sender is PictureBox pictureBox)
        {
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop(pictureBox.Tag, DragDropEffects.Copy);
            }
        }
    }
}
