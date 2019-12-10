using System;
using System.Windows.Forms;

namespace PDFSplit.GUI {
    public partial class MainFrame : Form {
        private static MainFrame Instance;

        /// <summary>
        /// Gets or creates the single instance of this class.
        /// </summary>
        /// <returns>the instance of this class.</returns>
        public static MainFrame GetInstance() {
            if (Instance == null)
                Instance = new MainFrame();
            return Instance;
        }

        private PdfFile pdf;

        private MainFrame() {
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
            startStopButton.Enabled = false;
            if (startStopButton.Text.Equals("Aufteilen starten")) {
                selectFileButton.Enabled = false;
                settingsButton.Enabled = false;
                filePathTextBox.Enabled = false;
                pdf = new PdfFile(filePathTextBox.Text);
                pdf.StartSplitting();
            } else {
                pdf.StopSplitting();
            }
        }

        private void SettingsButton_Click(object sender, EventArgs e) {
            new SettingsFrame().ShowDialog(this);
        }
    }
}
