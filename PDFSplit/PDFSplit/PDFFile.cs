using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PDFSplit.ProgramSettings;
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

        public void Split(ProgressBar bar) {
            CheckFile();

            PdfDocument pdf = PdfReader.Open(path, PdfDocumentOpenMode.Import);

            if (Program.Sett.QUnit.Equals(QuantityUnit.Seiten)) {
                if (pdf.PageCount <= Program.Sett.Size) {
                    bar.Value = 100;
                    MessageBox.Show("Die angegebene Datei ist bereits klein genug!", "Datei klein genug", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else {
                    if (pdf.PageCount % Program.Sett.Size == 0) {
                        bar.Step = 100 / (pdf.PageCount / Program.Sett.Size);
                    } else {
                        bar.Step = 100 / (pdf.PageCount / Program.Sett.Size + 1);
                    }

                    int j = 1;
                    PdfDocument nPdf = new PdfDocument(pdf.FullPath.Replace(".pdf", "_" + j + ".pdf"));
                    for (int i = 0; i < pdf.PageCount; i++) {
                        if (nPdf.PageCount != 0 && nPdf.PageCount == Program.Sett.Size) {
                            nPdf.Close();
                            bar.PerformStep();
                            j++;
                            nPdf = new PdfDocument(pdf.FullPath.Replace(".pdf", "_" + j + ".pdf"));
                        }
                        nPdf.AddPage(pdf.Pages[i]);
                    }
                    nPdf.Close();
                    bar.Value = 100;
                    MessageBox.Show("Das Aufteilen der Datei ist abgeschlossen!", "Fertig", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } else {
                long maxBytes = Program.Sett.Size;
                if (Program.Sett.QUnit.Equals(QuantityUnit.MB)) {
                    maxBytes *= 1000000;
                } else {
                    maxBytes *= 1048576;
                }

                if (pdf.FileSize <= maxBytes) {
                    bar.Value = 100;
                    MessageBox.Show("Die angegebene Datei ist bereits klein genug!", "Datei klein genug", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else {
                    if ((pdf.FileSize + (pdf.FileSize * 0.1)) % maxBytes == 0) {
                        bar.Step = 100 / (int)((pdf.FileSize + (pdf.FileSize * 0.1)) / maxBytes);
                    } else {
                        bar.Step = 100 / ((int)((pdf.FileSize + (pdf.FileSize * 0.1)) / maxBytes) + 1);
                    }

                    int j = 1;
                    PdfDocument nPdf = new PdfDocument();
                    for (int i = 0; i < pdf.PageCount; i++) {
                        if (nPdf.PageCount != 0) {
                            nPdf.Save(pdf.FullPath.Replace(".pdf", "_" + j + ".pdf"));
                            if (((PdfReader.Open(pdf.FullPath.Replace(".pdf", "_" + j + ".pdf"), PdfDocumentOpenMode.InformationOnly).FileSize / nPdf.PageCount) * (nPdf.PageCount + 1)) > maxBytes - (maxBytes * 0.1)) {
                                nPdf.Close();
                                bar.PerformStep();
                                j++;
                                nPdf = new PdfDocument();
                            }
                        }
                        nPdf.AddPage(pdf.Pages[i]);
                    }
                    nPdf.Close();
                    bar.Value = 100;
                    MessageBox.Show("Das Aufteilen der Datei ist abgeschlossen!", "Fertig", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            bar.Value = 0;
        }

        private void CheckFile() {
            if (!File.Exists(path)) {
                throw new FileNotFoundException();
            }
            if (!path.ToLower().EndsWith(".pdf") || PdfReader.TestPdfFile(path) == 0) {
                throw new NotPDFException();
            }
        }
    }
}
