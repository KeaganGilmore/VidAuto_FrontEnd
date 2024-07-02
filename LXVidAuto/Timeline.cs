using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

public class Timeline : UserControl
{
    private Panel timelinePanel;
    private Panel scrubber;
    private List<PictureBox> assets;
    public event Action<string, Image?>? FrameChanged;

    public Timeline()
    {
        InitializeComponent();
        assets = new List<PictureBox>();
        AllowDrop = true;

        DragEnter += Timeline_DragEnter;
        DragDrop += Timeline_DragDrop;
        DragOver += Timeline_DragOver;
    }

    private void InitializeComponent()
    {
        this.timelinePanel = new Panel();
        this.scrubber = new Panel();

        this.timelinePanel.Dock = DockStyle.Fill;
        this.timelinePanel.BackColor = Color.Gray;

        this.scrubber.BackColor = Color.Purple;
        this.scrubber.Size = new Size(2, this.timelinePanel.Height);
        this.scrubber.Location = new Point(0, 0);
        this.scrubber.Cursor = Cursors.Hand;
        this.scrubber.MouseDown += Scrubber_MouseDown;
        this.scrubber.MouseMove += Scrubber_MouseMove;
        this.scrubber.MouseUp += Scrubber_MouseUp;

        this.timelinePanel.Controls.Add(this.scrubber);
        this.Controls.Add(this.timelinePanel);
    }

    private void Timeline_DragEnter(object? sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormats.StringFormat))
        {
            e.Effect = DragDropEffects.Copy;
        }
        else
        {
            e.Effect = DragDropEffects.None;
        }
    }

    private void Timeline_DragOver(object? sender, DragEventArgs e)
    {
        e.Effect = DragDropEffects.Copy;
    }

    private void Timeline_DragDrop(object? sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormats.StringFormat))
        {
            string filePath = (string)e.Data.GetData(DataFormats.StringFormat);
            Point dropLocation = this.timelinePanel.PointToClient(new Point(e.X, e.Y));
            AddAssetToTimeline(filePath, dropLocation);
        }
    }

    private void AddAssetToTimeline(string filePath, Point dropLocation)
    {
        TimeSpan duration = TimeSpan.FromSeconds(10);

        PictureBox assetPictureBox = new PictureBox
        {
            Size = new Size((int)duration.TotalSeconds * 10, 50),
            SizeMode = PictureBoxSizeMode.Zoom,
            Image = Image.FromFile(filePath),
            Tag = $"Asset from {dropLocation.X} to {dropLocation.X + duration.TotalSeconds * 10}"
        };

        assetPictureBox.Location = dropLocation;

        this.timelinePanel.Controls.Add(assetPictureBox);
        assets.Add(assetPictureBox);

        FrameChanged?.Invoke($"Added {Path.GetFileName(filePath)} at {dropLocation.X}", assetPictureBox.Image);
    }

    private bool isDragging = false;
    private Point dragStart;

    private void Scrubber_MouseDown(object? sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            isDragging = true;
            dragStart = e.Location;
        }
    }

    private void Scrubber_MouseMove(object? sender, MouseEventArgs e)
    {
        if (isDragging)
        {
            int newX = scrubber.Left + (e.X - dragStart.X);
            if (newX >= 0 && newX <= this.timelinePanel.Width - scrubber.Width)
            {
                scrubber.Left = newX;
                DetectAssetUnderScrubber(newX);
            }
        }
    }

    private void Scrubber_MouseUp(object? sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            isDragging = false;
        }
    }

    private void DetectAssetUnderScrubber(int x)
    {
        foreach (var asset in assets)
        {
            if (asset.Bounds.Contains(new Point(x, asset.Top + asset.Height / 2)))
            {
                FrameChanged?.Invoke(asset.Tag.ToString(), asset.Image);
                return;
            }
        }
        FrameChanged?.Invoke("No asset under scrubber", null);
    }
}
