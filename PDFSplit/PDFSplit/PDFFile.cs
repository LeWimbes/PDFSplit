using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
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

            PdfDocument pdf = PdfReader.Open(path, PdfDocumentOpenMode.Import);

            if (Program.Sett.QUnit.Equals(QuantityUnit.Seiten)) {
                if (pdf.PageCount <= Program.Sett.Size) {
                    MessageBox.Show("Die angegebene Datei ist bereits klein genug!", "Datei klein genug", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else {
                    int j = 1;
                    PdfDocument nPdf = new PdfDocument(pdf.FullPath.Replace(".pdf", "_" + j + ".pdf"));
                    for (int i = 0; i < pdf.PageCount; i++) {
                        if (nPdf.PageCount != 0 && nPdf.PageCount == Program.Sett.Size) {
                            nPdf.Close();
                            j++;
                            nPdf = new PdfDocument(pdf.FullPath.Replace(".pdf", "_" + j + ".pdf"));
                        }
                        nPdf.AddPage(pdf.Pages[i]);
                    }
                    nPdf.Close();
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
                    MessageBox.Show("Die angegebene Datei ist bereits klein genug!", "Datei klein genug", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else {
                    int j = 1;
                    PdfDocument nPdf = new PdfDocument();
                    for (int i = 0; i < pdf.PageCount; i++) {
                        if (nPdf.PageCount != 0) {
                            nPdf.Save(pdf.FullPath.Replace(".pdf", "_" + j + ".pdf"));
                            FileInfo fI = new FileInfo(pdf.FullPath.Replace(".pdf", "_" + j + ".pdf"));
                            if (((fI.Length / nPdf.PageCount) * (nPdf.PageCount + 1)) > maxBytes - (maxBytes * 0.1)) {
                                nPdf.Close();
                                j++;
                                nPdf = new PdfDocument();
                            }
                        }
                        nPdf.AddPage(pdf.Pages[i]);
                    }
                    nPdf.Close();
                    MessageBox.Show("Das Aufteilen der Datei ist abgeschlossen!", "Fertig", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
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
