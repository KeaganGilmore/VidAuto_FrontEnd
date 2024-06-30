using System.Windows.Forms;

namespace VidAutoFrontEnd
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private TabControl mainTabControl;
        private TabPage uploadTab;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.mainTabControl = new TabControl();
            this.uploadTab = new TabPage();

            this.mainTabControl.SuspendLayout();
            this.SuspendLayout();

            // mainTabControl
            this.mainTabControl.Controls.Add(this.uploadTab);
            this.mainTabControl.Dock = DockStyle.Left;
            this.mainTabControl.Height = this.ClientSize.Height / 2;
            this.mainTabControl.Location = new System.Drawing.Point(0, 0);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(400, this.ClientSize.Height);
            this.mainTabControl.TabIndex = 0;

            // uploadTab
            this.uploadTab.Location = new System.Drawing.Point(4, 22);
            this.uploadTab.Name = "uploadTab";
            this.uploadTab.Padding = new System.Windows.Forms.Padding(3);
            this.uploadTab.Size = new System.Drawing.Size(392, 374);
            this.uploadTab.TabIndex = 0;
            this.uploadTab.Text = "Upload Assets";
            this.uploadTab.UseVisualStyleBackColor = true;

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainTabControl);
            this.Name = "MainForm";
            this.Text = "Video Editor";

            this.mainTabControl.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
