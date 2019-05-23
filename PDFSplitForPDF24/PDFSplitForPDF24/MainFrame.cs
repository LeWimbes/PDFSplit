using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDFSplitForPDF24 {
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

            if (filePathTextBox.Text.ToLower().EndsWith(".pdf")) {
                if (File.Exists(filePathTextBox.Text)) {
                    FileInfo fI = new FileInfo(filePathTextBox.Text);
                    if (Program.Sett.Stype.Equals(SizeType.Seiten)) {
                        string[] files = Program.SplitPDF(filePathTextBox.Text);
                        if (files != null) {
                            if (files.Length <= Program.Sett.Size) {
                                MessageBox.Show("Die angegebene Datei ist bereits klein genug!", "Datei klein genug", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Program.RemoveCache(filePathTextBox.Text);
                            } else {
                                string[] fewFiles = new string[Program.Sett.Size];
                                int i = 0;
                                int j = 1;
                                foreach (string s in files) {
                                    if (i == Program.Sett.Size) {
                                        Program.JoinPDFs(fewFiles, fI.FullName.Replace(".pdf", "_" + j + ".pdf"));
                                        fewFiles = new string[Program.Sett.Size];
                                        j++;
                                        i = 0;
                                    }
                                    fewFiles[i] = s;
                                    i++;
                                }
                                if (fewFiles.Length != 0) {
                                    Program.JoinPDFs(fewFiles, fI.FullName.Replace(".pdf", "_" + j + ".pdf"));
                                }
                                Program.RemoveCache(filePathTextBox.Text);
                            }
                        }
                    } else {
                        int maxBytes = Program.Sett.Size;
                        if (Program.Sett.Stype.Equals(SizeType.MB)) {
                            maxBytes *= 1000000;
                        } else {
                            maxBytes *= 1048576;
                        }
                        if (fI.Length >= maxBytes) { // <=
                            MessageBox.Show("Die angegebene Datei ist bereits klein genug!", "Datei klein genug", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        } else {
                            string[] files = Program.SplitPDF(filePathTextBox.Text);
                            if (files != null) {
                                filePathTextBox.Text = files.Length.ToString();
                                //TODO
                            }
                        }
                    }
                } else {
                    MessageBox.Show("Die angegebene Datei konnte nicht gefunden werden!", "Datei nicht vorhanden", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else {
                MessageBox.Show("Die angegebene Datei ist keine PDF-Datei!", "Keine PDF-Datei", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
