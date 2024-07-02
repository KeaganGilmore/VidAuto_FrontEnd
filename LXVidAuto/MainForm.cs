using System;
using System.Drawing;
using System.Windows.Forms;

public partial class MainForm : Form
{
    private Timeline timeline;
    private Label frameInfoLabel;
    private PictureBox framePreviewPictureBox;
    private ProjectDirectory projectDirectory;

    public MainForm()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        this.timeline = new Timeline();
        this.frameInfoLabel = new Label();
        this.framePreviewPictureBox = new PictureBox();
        this.projectDirectory = new ProjectDirectory();

        // Frame Info Label
        this.frameInfoLabel.AutoSize = true;
        this.frameInfoLabel.Location = new Point(10, 10);
        this.frameInfoLabel.Size = new Size(300, 20);

        // Frame Preview PictureBox
        this.framePreviewPictureBox.Location = new Point(10, 40);
        this.framePreviewPictureBox.Size = new Size(100, 100);
        this.framePreviewPictureBox.SizeMode = PictureBoxSizeMode.Zoom;

        // Project Directory Control
        this.projectDirectory.Location = new Point(10, 150);
        this.projectDirectory.Size = new Size(200, 200);
        this.projectDirectory.AssetUploaded += ProjectDirectory_AssetUploaded;

        // Timeline Control
        this.timeline.Location = new Point(220, 150);
        this.timeline.Size = new Size(600, 200);
        this.timeline.FrameChanged += Timeline_FrameChanged;

        // MainForm
        this.ClientSize = new Size(800, 400);
        this.Controls.Add(this.timeline);
        this.Controls.Add(this.frameInfoLabel);
        this.Controls.Add(this.framePreviewPictureBox);
        this.Controls.Add(this.projectDirectory);
        this.Text = "Video Editor";
    }

    private void ProjectDirectory_AssetUploaded(string filePath)
    {
        // Optionally handle any logic needed when a new asset is uploaded to the project directory.
    }

    private void Timeline_FrameChanged(string info, Image? frameImage)
    {
        this.frameInfoLabel.Text = info;
        this.framePreviewPictureBox.Image = frameImage;
    }
}
