using PDFSplit.GUI;
using PDFSplit.ProgramSettings;
using System;
using System.Windows.Forms;

namespace PDFSplit {
    static class Program {

        public static Settings Sett {
            get; set;
        }

        public static MainFrame Mframe {
            get; set;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Sett = Settings.LoadSettings();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Mframe = new MainFrame();
            Application.Run(Mframe);
        }
    }
}
