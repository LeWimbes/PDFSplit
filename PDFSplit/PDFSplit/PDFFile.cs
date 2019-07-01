using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PDFSplit.GUI;
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
            ChangeStartStopButtonText("Vorzeitig beenden");
            EnableStartStopButton();
            ChangeBarValue(0);

            if (Program.Sett.QUnit.Equals(QuantityUnit.Seiten)) {
                SplitByPages();
            } else {
                SplitBySize();
            }

            Pdf = null;
            ChangeBarValue(0);
            ChangeStartStopButtonText("Aufteilen starten");
            EnableComponents();
            EnableStartStopButton();
            GC.Collect();
            GC.WaitForPendingFinalizers();
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
                PdfDocument tempRead;
                PdfDocument temp;

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

                    if (nPdf.PageCount != 0) {
                        MemoryStream ms = ToMemoryStream(nPdf);
                        if (ms.Length > maxBytes) {
                            tempRead = PdfReader.Open(ms, PdfDocumentOpenMode.Import);
                            temp = new PdfDocument(CalculateFileName(output, name, j));
                            for (int k = 0; k < nPdf.PageCount - 1; k++) {
                                temp.AddPage(tempRead.Pages[k]);
                            }
                            temp.Close();
                            PerformBarStep();
                            j++;
                            nPdf = new PdfDocument();
                            nPdf.AddPage(Pdf.Pages[i]);
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
                ShowMessage("Die angegebene Datei konnte nicht gefunden werden!", "Datei nicht vorhanden", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EnableComponents();
                EnableStartStopButton();
                return false;
            }
            if (!path.ToLower().EndsWith(".pdf") || PdfReader.TestPdfFile(path) == 0) {
                ShowMessage("Die angegebene Datei ist keine PDF-Datei!", "Keine PDF-Datei", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EnableComponents();
                EnableStartStopButton();
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

        private MemoryStream ToMemoryStream(PdfDocument pdf) {
            MemoryStream ms = new MemoryStream();
            ms.Seek(0, SeekOrigin.Begin);
            pdf.Save(ms);
            return ms;
        }

        private static void FileSmallEnough() {
            ChangeBarValue(100);
            ShowMessage("Die angegebene Datei ist bereits klein genug!", "Datei klein genug", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Done(string path) {
            ChangeBarValue(100);
            ShowMessage("Das Aufteilen der Datei ist abgeschlossen!", "Fertig", MessageBoxButtons.OK, MessageBoxIcon.Information);
            OpenFolder(path);
        }

        private void Aborted(string path) {
            ShowMessage("Das Aufteilen der Datei wurde abgebrochen!", "Abbruch", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            OpenFolder(path);
        }

        private void OpenFolder(string path) {
            new Task(() -> Process.Start("explorer.exe", path)).Start();
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
                ShowMessage("Der Output Ordner konnte nicht erstellt werden!", "Fehlende Rechte", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private static string CalculateFileName(string directory, string name, int i) {
            return directory + "\\" + name + "_" + i + ".pdf";
        }

        private static long MaxBytes(int size, QuantityUnit unit) {
            long maxBytes = size;
            if (unit.Equals(QuantityUnit.MB)) {
                maxBytes *= 1000000;
            } else if (unit.Equals(QuantityUnit.MiB)) {
                maxBytes *= 1048576;
            }
            return maxBytes;
        }

        private static void ShowMessage(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon) {
            MainFrame mf = Program.Mframe;
            if (mf.InvokeRequired) {
                MethodInvoker invoker = new MethodInvoker(show);
                mf.Invoke(invoker);
            } else {
                show();
            }
            void show() {
                MessageBox.Show(mf, text, caption, buttons, icon);
            }
        }

        private static void EnableComponents() {
            {
                Button SeFiButton = Program.Mframe.selectFileButton;
                if (SeFiButton.InvokeRequired) {
                    MethodInvoker invoker = new MethodInvoker(enableSeFiButton);
                    SeFiButton.Invoke(invoker);
                } else {
                    enableSeFiButton();
                }
                void enableSeFiButton() {
                    SeFiButton.Enabled = true;
                }
            }

            {
                Button SettButton = Program.Mframe.settingsButton;
                if (SettButton.InvokeRequired) {
                    MethodInvoker invoker = new MethodInvoker(enableSettButton);
                    SettButton.Invoke(invoker);
                } else {
                    enableSettButton();
                }
                void enableSettButton() {
                    SettButton.Enabled = true;
                }
            }

            {
                TextBox FiPaBox = Program.Mframe.filePathTextBox;
                if (FiPaBox.InvokeRequired) {
                    MethodInvoker invoker = new MethodInvoker(enableFiPaBox);
                    FiPaBox.Invoke(invoker);
                } else {
                    enableFiPaBox();
                }
                void enableFiPaBox() {
                    FiPaBox.Enabled = true;
                }
            }
        }

        private static void EnableStartStopButton() {
            Button StStButton = Program.Mframe.startStopButton;
            if (StStButton.InvokeRequired) {
                MethodInvoker invoker = new MethodInvoker(enableStStButton);
                StStButton.Invoke(invoker);
            } else {
                enableStStButton();
            }
            void enableStStButton() {
                StStButton.Enabled = true;
            }
        }

        private static void ChangeStartStopButtonText(string text) {
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

        private static void ChangeBarValue(int value) {
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

        private static void ChangeBarStep(int step) {
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

        private static void PerformBarStep() {
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
