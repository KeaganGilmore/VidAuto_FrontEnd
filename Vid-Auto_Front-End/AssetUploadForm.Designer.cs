using System.Windows.Forms;

namespace VidAutoFrontEnd
{
    partial class AssetUploadForm
    {
        private System.ComponentModel.IContainer components = null;
        private Button uploadButton;
        private OpenFileDialog openFileDialog;
        private FlowLayoutPanel flowLayoutPanel;

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
            this.uploadButton = new Button();
            this.openFileDialog = new OpenFileDialog();
            this.flowLayoutPanel = new FlowLayoutPanel();
            this.SuspendLayout();

            // uploadButton
            this.uploadButton.Location = new System.Drawing.Point(50, 50);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.Size = new System.Drawing.Size(100, 23);
            this.uploadButton.TabIndex = 0;
            this.uploadButton.Text = "Upload Asset";
            this.uploadButton.UseVisualStyleBackColor = true;
            this.uploadButton.Click += new System.EventHandler(this.uploadButton_Click);

            // openFileDialog
            this.openFileDialog.Multiselect = true;

            // flowLayoutPanel
            this.flowLayoutPanel.Location = new System.Drawing.Point(50, 100);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(300, 300);
            this.flowLayoutPanel.TabIndex = 1;
            this.flowLayoutPanel.AutoScroll = true;

            // AssetUploadForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 450);
            this.Controls.Add(this.uploadButton);
            this.Controls.Add(this.flowLayoutPanel);
            this.Name = "AssetUploadForm";
            this.Text = "Upload Assets";
            this.ResumeLayout(false);
        }
    }
}
