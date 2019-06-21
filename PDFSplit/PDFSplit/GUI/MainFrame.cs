using System;
using System.IO;
using System.Windows.Forms;

namespace PDFSplit.GUI {
    public partial class MainFrame : Form {

        private SettingsFrame Settf;
        private PdfFile pdf;

        public MainFrame() {
            InitializeComponent();
            selectFileButton.Click += new EventHandler(SelectFileButton_Click);
            startStopButton.Click += new EventHandler(StartStopButton_Click);
            settingsButton.Click += new EventHandler(SettingsButton_Click);
        }

        private void SelectFileButton_Click(object sender, EventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog {
                Title = "Wählen Sie eine PDF-Datei aus",
                Filter = "PDF-Dateien (*.pdf)|*.pdf"
            };
            if (ofd.ShowDialog() == DialogResult.OK) {
                filePathTextBox.Text = ofd.FileName;
            }
        }

        private void StartStopButton_Click(object sender, EventArgs e) {
            if (startStopButton.Text.Equals("Start splitting")) {
                pdf = new PdfFile(filePathTextBox.Text);
                pdf.StartSplitting();
            } else {
                pdf.StopSplitting();
            }
        }

        private void SettingsButton_Click(object sender, EventArgs e) {
            if (Settf == null || Settf.IsDisposed) {
                Settf = new SettingsFrame();
                Settf.Show();
            }
        }
    }
}
