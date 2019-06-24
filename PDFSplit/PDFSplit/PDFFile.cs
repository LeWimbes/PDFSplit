using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PDFSplit.ProgramSettings;
using System;
using System.Diagnostics;
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

        public PdfFile(string path) {
            Path = path;
        }


        public void StopSplitting() {
            Stop = true;
        }

        public async void StartSplitting() {
            if (CheckFile(Path)) {
                Pdf = PdfReader.Open(Path, PdfDocumentOpenMode.Import);
                Stop = false;

                Task task = new Task(() => Split());
                task.Start();
                await task;
            }
        }

        private void Split() {
            ChangeStartStopButtonText("Stop splitting");
            ChangeBarValue(0);

            if (Program.Sett.QUnit.Equals(QuantityUnit.Seiten)) {
                SplitByPages();
            } else {
                SplitBySize();
            }

            ChangeBarValue(0);
            ChangeStartStopButtonText("Start splitting");
        }

        private void SplitByPages() {
            if (Pdf.PageCount <= Program.Sett.Size) {
                FileSmallEnough();
            } else {
                // create output directory
                string output = CreateOutputDirectory();
                if (output == null) {
                    return;
                }

                string name = CalculateFileName();

                // calculate step size
                if (Pdf.PageCount % Program.Sett.Size == 0) {
                    ChangeBarStep(100 / (Pdf.PageCount / Program.Sett.Size));
                } else {
                    ChangeBarStep(100 / (Pdf.PageCount / Program.Sett.Size + 1));
                }

                int j = 0;
                PdfDocument nPdf = new PdfDocument(CalculateFileName(output, name, j));
                foreach (PdfPage page in Pdf.Pages) {
                    if (Stop) {
                        nPdf.Close();
                        Aborted(output);
                        return;
                    }
                    if (nPdf.PageCount != 0 && nPdf.PageCount == Program.Sett.Size) {
                        nPdf.Close();
                        PerformBarStep();
                        j++;
                        nPdf = new PdfDocument(CalculateFileName(output, name, j));
                    }
                    nPdf.AddPage(page);
                }
                nPdf.Close();
                Done(output);
            }
        }

        private void SplitBySize() {
            long maxBytes = MaxBytes(Program.Sett.Size, Program.Sett.QUnit);

            if (Pdf.FileSize <= maxBytes) {
                FileSmallEnough();
            } else {
                // create output directory
                string output = CreateOutputDirectory();
                if (output == null) {
                    return;
                }

                string name = CalculateFileName();

                // calculate step size
                if ((Pdf.FileSize + (Pdf.FileSize * 0.1)) % maxBytes == 0) {
                    ChangeBarStep(100 / (int)((Pdf.FileSize + (Pdf.FileSize * 0.1)) / maxBytes));
                } else {
                    ChangeBarStep(100 / ((int)((Pdf.FileSize + (Pdf.FileSize * 0.1)) / maxBytes) + 1));
                }

                int j = 0;
                PdfDocument nPdf = new PdfDocument();
                PdfDocument n1Pdf = new PdfDocument();
                n1Pdf.AddPage(Pdf.Pages[0]);
                for (int i = 0; i < Pdf.PageCount; i++) {
                    if (Stop) {
                        if (nPdf.PageCount != 0) {
                            nPdf.Save(CalculateFileName(output, name, j));
                        }
                        nPdf.Close();
                        Aborted(output);
                        return;
                    }
                    nPdf.AddPage(Pdf.Pages[i]);
                    if (i + 1 != Pdf.PageCount) {
                        n1Pdf.AddPage(Pdf.Pages[i + 1]);
                    }

                    if (nPdf.PageCount != 0) {
                        if (Size(n1Pdf) > maxBytes) {
                            nPdf.Save(CalculateFileName(output, name, j));
                            nPdf.Close();
                            PerformBarStep();
                            j++;
                            nPdf = new PdfDocument();
                            n1Pdf = new PdfDocument();
                            n1Pdf.AddPage(Pdf.Pages[i]);
                        }
                    }
                }
                if (nPdf.PageCount != 0) {
                    nPdf.Save(CalculateFileName(output, name, j));
                }
                nPdf.Close();
                Done(output);
            }
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

        private long Size(PdfDocument pdf) {
            MemoryStream ms = new MemoryStream();
            ms.Seek(0, SeekOrigin.Begin);
            pdf.Save(ms);
            return ms.Length;
        }

        private void FileSmallEnough() {
            ChangeBarValue(100);
            MessageBox.Show("Die angegebene Datei ist bereits klein genug!", "Datei klein genug", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Done(String path) {
            ChangeBarValue(100);
            MessageBox.Show("Das Aufteilen der Datei ist abgeschlossen!", "Fertig", MessageBoxButtons.OK, MessageBoxIcon.Information);
            OpenFolder(path);
        }

        private void Aborted(String path) {
            MessageBox.Show("Das Aufteilen der Datei wurde abgebrochen!", "Abbruch", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            OpenFolder(path);
        }

        private void OpenFolder(string path) {
            Process.Start("explorer.exe", path);
        }

        private string CreateOutputDirectory() {
            string directory = Path.Substring(0, Path.LastIndexOf('.')) + " - Output";
            if (Directory.Exists(directory)) {
                int i = 0;
                while (Directory.Exists(fullName(i))) {
                    i++;
                }
                directory = fullName(i);
            }
            try {
                Directory.CreateDirectory(directory);
            } catch (Exception) {
                MessageBox.Show("Der Output Ordner konnte nicht erstellt werden!", "Fehlende Rechte", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            return directory;

            string fullName(int i) {
                return directory + " (" + i + ")";
            }
        }

        private string CalculateFileName() {
            int i = Path.LastIndexOf('\\');
            return Path.Substring(i, Path.LastIndexOf('.') - i);
        }

        private string CalculateFileName(string directory, string name, int i) {
            return directory + "\\" + name + "_" + i + ".pdf";
        }

        private long MaxBytes(int size, QuantityUnit unit) {
            long maxBytes = size;
            if (unit.Equals(QuantityUnit.MB)) {
                maxBytes *= 1000000;
            } else if (unit.Equals(QuantityUnit.MiB)) {
                maxBytes *= 1048576;
            }
            return maxBytes;
        }

        private void ChangeStartStopButtonText(string text) {
            Button StStButton = Program.Mframe.startStopButton;
            if (StStButton.InvokeRequired) {
                MethodInvoker invoker = new MethodInvoker(changeText);
                StStButton.Invoke(invoker);
            } else {
                changeText();
            }
            void changeText() {
                StStButton.Text = text;
            }
        }

        private void ChangeBarValue(int value) {
            ProgressBar Bar = Program.Mframe.progressBar;
            if (Bar.InvokeRequired) {
                MethodInvoker invoker = new MethodInvoker(changeValue);
                Bar.Invoke(invoker);
            } else {
                changeValue();
            }
            void changeValue() {
                Bar.Value = value;
            }
        }

        private void ChangeBarStep(int step) {
            ProgressBar Bar = Program.Mframe.progressBar;
            if (Bar.InvokeRequired) {
                MethodInvoker invoker = new MethodInvoker(changeStep);
                Bar.Invoke(invoker);
            } else {
                changeStep();
            }
            void changeStep() {
                Bar.Step = step;
            }
        }

        private void PerformBarStep() {
            ProgressBar Bar = Program.Mframe.progressBar;
            if (Bar.InvokeRequired) {
                MethodInvoker invoker = new MethodInvoker(performStep);
                Bar.Invoke(invoker);
            } else {
                performStep();
            }
            void performStep() {
                Bar.PerformStep();
            }
        }
    }
}
