using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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

        public static string[] SplitPDF(string PDFPath) {
            if (!PDF24Exists()) {
                MessageBox.Show("PDF24 konnte nicht gefunden werden!\nFragen Sie gegebenenfalls Ihren Administrator um Rat.", "Ordner nicht vorhanden", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            string path = AbsolutCachePath(PDFPath);
            if (!Directory.Exists(path)) {
                MessageBox.Show("Das überverzeichnis für den Chache existiert nicht!\nFragen Sie gegebenenfalls Ihren Administrator um Rat.", "Ordner nicht vorhanden", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            Directory.CreateDirectory(path + @"\Cache");
            Process PDF24 = new Process();
            PDF24.StartInfo.FileName = @"C:\Program Files (x86)\PDF24\pdf24-DocTool.exe";
            PDF24.StartInfo.Arguments = "-splitByPage -outputDir \"" + path + "\\Cache\" " + PDFPath;
            PDF24.Start();
            PDF24.WaitForExit();
            return Directory.GetFiles(path + @"\Cache\" + new FileInfo(PDFPath).Name);
        }

        public static void JoinPDFs(string[] PDFPaths, string name) {
            Process PDF24 = new Process();
            PDF24.StartInfo.FileName = @"C:\Program Files (x86)\PDF24\pdf24-DocTool.exe";
            PDF24.StartInfo.Arguments = "-join -profile \"default/good\" -outputFile \"" + name + "\" ";
            foreach (string s in PDFPaths) {
                PDF24.StartInfo.Arguments +="\""+ s + "\" ";
            }
            PDF24.StartInfo.Arguments = PDF24.StartInfo.Arguments.Substring(0, PDF24.StartInfo.Arguments.Length - 1);
            PDF24.Start();
            PDF24.WaitForExit();
        }

        private static string AbsolutCachePath(string PDFPath) {
            string path = Sett.Cache;
            path = path.Replace("%work%", new FileInfo(PDFPath).DirectoryName);
            path = path.Replace("%install%", Path.GetDirectoryName(Application.ExecutablePath));
            return path;
        }

        public static void RemoveCache(string PDFPath) {
            string path = Sett.Cache;
            path = path.Replace("%work%", new FileInfo(PDFPath).DirectoryName);
            path = path.Replace("%install%", Path.GetDirectoryName(Application.ExecutablePath));
            Directory.Delete(path + @"\Cache", true);
        }

        private static bool PDF24Exists() {
            return File.Exists(@"C:\Program Files (x86)\PDF24\pdf24-DocTool.exe");
        }
    }
}
