using System;
using System.IO;
using System.Windows.Forms;

namespace PDFSplit.GUI {
    public partial class MainFrame : Form {

        private SettingsFrame Settf;
        public MainFrame() {
            InitializeComponent();
            selectFileButton.Click += new EventHandler(SelectFileButton_Click);
            startButton.Click += new EventHandler(StartButton_Click);
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

        private void StartButton_Click(object sender, EventArgs e) {
            startButton.Enabled = false;

            PDFFile pdf;
            try {
                pdf = new PDFFile(filePathTextBox.Text);
            } catch (FileNotFoundException) {
                MessageBox.Show("Die angegebene Datei konnte nicht gefunden werden!", "Datei nicht vorhanden", MessageBoxButtons.OK, MessageBoxIcon.Error);
                startButton.Enabled = true;
                return;
            } catch (NotPDFException) {
                MessageBox.Show("Die angegebene Datei ist keine PDF-Datei!", "Keine PDF-Datei", MessageBoxButtons.OK, MessageBoxIcon.Error);
                startButton.Enabled = true;
                return;
            }

            try {
                pdf.Split();
            } catch (FileNotFoundException) {
                MessageBox.Show("Die angegebene Datei konnte nicht gefunden werden!", "Datei nicht vorhanden", MessageBoxButtons.OK, MessageBoxIcon.Error);
                startButton.Enabled = true;
                return;
            } catch (NotPDFException) {
                MessageBox.Show("Die angegebene Datei ist keine PDF-Datei!", "Keine PDF-Datei", MessageBoxButtons.OK, MessageBoxIcon.Error);
                startButton.Enabled = true;
                return;
            }

            startButton.Enabled = true;
        }

        private void SettingsButton_Click(object sender, EventArgs e) {
            if (Settf == null || Settf.IsDisposed) {
                Settf = new SettingsFrame();
                Settf.Show();
            }
        }
    }
}
