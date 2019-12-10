using PDFSplit.GUI;
using PDFSplit.ProgramSettings;
using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace PDFSplit {
    static class PdfSplit {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            SetLanguage();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(MainFrame.GetInstance());
        }

        private static void SetLanguage() {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(Settings.GetInstance().Language);
        }
    }
}
