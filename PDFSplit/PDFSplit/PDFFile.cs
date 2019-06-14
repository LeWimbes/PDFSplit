using PDFSplit.ProgramSettings;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace PDFSplit {
    class PDFFile {
        private string path {
            get; set;
        }

        public PDFFile(string path) {
            this.path = path;
            CheckFile();
        }

        public void Split() {
            CheckFile();

            FileInfo fI = new FileInfo(path);
            if (Program.Sett.QUnit.Equals(QuantityUnit.Seiten)) {
                string[] files = PDFSplit.SplitPDF(path);
                if (files != null) {
                    if (files.Length <= Program.Sett.Size) {
                        MessageBox.Show("Die angegebene Datei ist bereits klein genug!", "Datei klein genug", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        PDFSplit.RemoveCache(path);
                    } else {
                        string[] fewFiles = new string[Program.Sett.Size];
                        int i = 0;
                        int j = 1;
                        foreach (string s in files) {
                            if (i == Program.Sett.Size) {
                                PDFSplit.JoinPDFs(fewFiles, fI.FullName.Replace(".pdf", "_" + j + ".pdf"));
                                fewFiles = new string[Program.Sett.Size];
                                j++;
                                i = 0;
                            }
                            fewFiles[i] = s;
                            i++;
                        }
                        if (fewFiles.Length != 0) {
                            PDFSplit.JoinPDFs(fewFiles, fI.FullName.Replace(".pdf", "_" + j + ".pdf"));
                        }
                        PDFSplit.RemoveCache(path);
                        MessageBox.Show("Das Aufteilen der Datei ist abgeschlossen!", "Fertig", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            } else {
                long maxBytes = Program.Sett.Size;
                if (Program.Sett.QUnit.Equals(QuantityUnit.MB)) {
                    maxBytes *= 1000000;
                } else {
                    maxBytes *= 1048576;
                }
                if (fI.Length <= maxBytes) {
                    MessageBox.Show("Die angegebene Datei ist bereits klein genug!", "Datei klein genug", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else {
                    string[] files = PDFSplit.SplitPDF(path);
                    if (files != null) {
                        List<string> fewFiles = new List<string>();
                        long bytes = 0;
                        int j = 1;
                        foreach (string s in files) {
                            FileInfo fIs = new FileInfo(s);
                            if ((bytes + fIs.Length) > maxBytes) {
                                PDFSplit.JoinPDFs(fewFiles.ToArray(), fI.FullName.Replace(".pdf", "_" + j + ".pdf"));
                                fewFiles = new List<string>();
                                j++;
                                bytes = 0;
                            }
                            fewFiles.Add(s);
                            bytes += fIs.Length;
                        }
                        if (fewFiles.Count != 0) {
                            PDFSplit.JoinPDFs(fewFiles.ToArray(), fI.FullName.Replace(".pdf", "_" + j + ".pdf"));
                        }
                        PDFSplit.RemoveCache(path);
                        MessageBox.Show("Das Aufteilen der Datei ist abgeschlossen!", "Fertig", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void CheckFile() {
            if (!File.Exists(path)) {
                throw new FileNotFoundException();
            }
            if (!path.ToLower().EndsWith(".pdf")) {
                throw new NotPDFException();
            }
        }
    }
}
