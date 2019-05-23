using System;
using System.Collections.Generic;
using System.IO;
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
                                MessageBox.Show("Das Aufteilen der Datei ist abgeschlossen!", "Fertig", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    } else {
                        long maxBytes = Program.Sett.Size;
                        if (Program.Sett.Stype.Equals(SizeType.MB)) {
                            maxBytes *= 1000000;
                        } else {
                            maxBytes *= 1048576;
                        }
                        if (fI.Length <= maxBytes) {
                            MessageBox.Show("Die angegebene Datei ist bereits klein genug!", "Datei klein genug", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        } else {
                            string[] files = Program.SplitPDF(filePathTextBox.Text);
                            if (files != null) {
                                List<string> fewFiles = new List<string>();
                                long bytes = 0;
                                int j = 1;
                                foreach (string s in files) {
                                    FileInfo fIs = new FileInfo(s);
                                    if ((bytes + fIs.Length) > Program.Sett.Size) {
                                        Program.JoinPDFs(fewFiles.ToArray(), fI.FullName.Replace(".pdf", "_" + j + ".pdf"));
                                        fewFiles = new List<string>();
                                        j++;
                                        bytes = 0;
                                    }
                                    fewFiles.Add(s);
                                    bytes += fIs.Length;
                                }
                                if (fewFiles.Count != 0) {
                                    Program.JoinPDFs(fewFiles.ToArray(), fI.FullName.Replace(".pdf", "_" + j + ".pdf"));
                                }
                                Program.RemoveCache(filePathTextBox.Text);
                                MessageBox.Show("Das Aufteilen der Datei ist abgeschlossen!", "Fertig", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
