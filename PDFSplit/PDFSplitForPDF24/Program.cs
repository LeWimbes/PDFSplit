using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace PDFSplitForPDF24 {
    static class Program {

        public static Settings Sett {
            get; set;
        }

        public static MainFrame Mframe {
            get; set;
        }
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
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
