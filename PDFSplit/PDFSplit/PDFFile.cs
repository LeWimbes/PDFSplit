using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PDFSplit.GUI;
using PDFSplit.ProgramSettings;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDFSplit {
    class PdfFile {
        private string Path {
            get; set;
        }

        private bool Stop {
            get; set;
        }

        private PdfDocument Pdf {
            get; set;
        }

        private MainFrame Frame {
            get; set;
        }

        private ProgressBar Bar {
            get; set;
        }

        private Button StStButton {
            get; set;
        }

        public PdfFile(string path) {
            Path = path;
        }


        public void StopSplitting() {
            Stop = true;
        }

        public async void StartSplitting() {
            if (CheckFile(Path)) {
                Pdf = PdfReader.Open(Path, PdfDocumentOpenMode.Import);
                Frame = Program.Mframe;
                Bar = Frame.progressBar;
                StStButton = Frame.startStopButton;
                Stop = false;

                Task task = new Task(() => Split());
                task.Start();
                await task;
            }
        }

        private void ChangeStartStopButtonText(string text) {
            if (StStButton.InvokeRequired) {
                MethodInvoker invoker = new MethodInvoker(changeText);
                StStButton.Invoke(invoker);
                return;
            }
            void changeText() {
                StStButton.Text = text;
            }
        }

        private void ChangeBarValue(int value) {
            if (Bar.InvokeRequired) {
                MethodInvoker invoker = new MethodInvoker(changeValue);
                Bar.Invoke(invoker);
                return;
            }
            void changeValue() {
                Bar.Value = value;
            }
        }

        private void ChangeBarStep(int step) {
            if (Bar.InvokeRequired) {
                MethodInvoker invoker = new MethodInvoker(changeValue);
                Bar.Invoke(invoker);
                return;
            }
            void changeValue() {
                Bar.Step = step;
            }
        }

        private void PerformBarStep() {
            if (Bar.InvokeRequired) {
                MethodInvoker invoker = new MethodInvoker(changeValue);
                Bar.Invoke(invoker);
                return;
            }
            void changeValue() {
                Bar.PerformStep();
            }
        }

        private void Split() {
            ChangeStartStopButtonText("Stop splitting");
            ChangeBarValue(0);

            if (Program.Sett.QUnit.Equals(QuantityUnit.Seiten)) {
                if (Pdf.PageCount <= Program.Sett.Size) {
                    ChangeBarValue(100);
                    MessageBox.Show("Die angegebene Datei ist bereits klein genug!", "Datei klein genug", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else {
                    if (Pdf.PageCount % Program.Sett.Size == 0) {
                        ChangeBarStep(100 / (Pdf.PageCount / Program.Sett.Size));
                    } else {
                        ChangeBarStep(100 / (Pdf.PageCount / Program.Sett.Size + 1));
                    }

                    int j = 1;
                    PdfDocument nPdf = new PdfDocument(Pdf.FullPath.Replace(".pdf", "_" + j + ".pdf"));
                    for (int i = 0; i < Pdf.PageCount; i++) {
                        if (nPdf.PageCount != 0 && nPdf.PageCount == Program.Sett.Size) {
                            nPdf.Close();
                            PerformBarStep();
                            j++;
                            nPdf = new PdfDocument(Pdf.FullPath.Replace(".pdf", "_" + j + ".pdf"));
                        }
                        nPdf.AddPage(Pdf.Pages[i]);
                    }
                    nPdf.Close();
                    ChangeBarValue(100);
                    MessageBox.Show("Das Aufteilen der Datei ist abgeschlossen!", "Fertig", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } else {
                long maxBytes = Program.Sett.Size;
                if (Program.Sett.QUnit.Equals(QuantityUnit.MB)) {
                    maxBytes *= 1000000;
                } else {
                    maxBytes *= 1048576;
                }

                if (Pdf.FileSize <= maxBytes) {
                    ChangeBarValue(100);
                    MessageBox.Show("Die angegebene Datei ist bereits klein genug!", "Datei klein genug", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else {
                    if ((Pdf.FileSize + (Pdf.FileSize * 0.1)) % maxBytes == 0) {
                        ChangeBarStep(100 / (int)((Pdf.FileSize + (Pdf.FileSize * 0.1)) / maxBytes));
                    } else {
                        ChangeBarStep(100 / ((int)((Pdf.FileSize + (Pdf.FileSize * 0.1)) / maxBytes) + 1));
                    }

                    int j = 1;
                    PdfDocument nPdf = new PdfDocument();
                    for (int i = 0; i < Pdf.PageCount; i++) {
                        if (nPdf.PageCount != 0) {
                            nPdf.Save(Pdf.FullPath.Replace(".pdf", "_" + j + ".pdf"));
                            if (((PdfReader.Open(Pdf.FullPath.Replace(".pdf", "_" + j + ".pdf"), PdfDocumentOpenMode.InformationOnly).FileSize / nPdf.PageCount) * (nPdf.PageCount + 1)) > maxBytes - (maxBytes * 0.1)) {
                                nPdf.Close();
                                PerformBarStep();
                                j++;
                                nPdf = new PdfDocument();
                            }
                        }
                        nPdf.AddPage(Pdf.Pages[i]);
                    }
                    nPdf.Close();
                    ChangeBarValue(100);
                    MessageBox.Show("Das Aufteilen der Datei ist abgeschlossen!", "Fertig", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            ChangeBarValue(0);
            ChangeStartStopButtonText("Start splitting");
        }

        private static bool CheckFile(string path) {
            if (!File.Exists(path)) {
                MessageBox.Show("Die angegebene Datei konnte nicht gefunden werden!", "Datei nicht vorhanden", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!path.ToLower().EndsWith(".pdf") || PdfReader.TestPdfFile(path) == 0) {
                MessageBox.Show("Die angegebene Datei ist keine PDF-Datei!", "Keine PDF-Datei", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
