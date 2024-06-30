using System;
using System.Windows.Forms;

namespace VidAutoFrontEnd
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            var assetUploadForm = new AssetUploadForm
            {
                TopLevel = false,
                Dock = DockStyle.Fill
            };
            uploadTab.Controls.Add(assetUploadForm);
            assetUploadForm.Show();
        }
    }
}
