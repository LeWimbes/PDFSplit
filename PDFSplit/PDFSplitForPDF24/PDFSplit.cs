using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDFSplitForPDF24 {
    class PDFSplit {

        public static string[] SplitPDF(string PDFPath) {
            string path = AbsolutCachePath(PDFPath);
            if (!Directory.Exists(path)) {
                MessageBox.Show("Das Überverzeichnis für den Chache existiert nicht!\nFragen Sie gegebenenfalls Ihren Administrator um Rat.", "Ordner nicht vorhanden", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            Directory.CreateDirectory(path + @"\Cache");
            string args = "-splitByPage -outputDir \"" + path + "\\Cache\" \"" + PDFPath + "\"";
            if (PDF24.Run(args)) {
                return Directory.GetFiles(path + @"\Cache\" + new FileInfo(PDFPath).Name);
            }
            return null;
        }

        public static void JoinPDFs(string[] PDFPaths, string name) {
            string args = "-join -profile \"default/medium\" -outputFile \"" + name + "\" ";
            foreach (string s in PDFPaths) {
                args += "\"" + s + "\" ";
            }
            args = args.Substring(0, args.Length - 1);
            PDF24.Run(args);
        }

        private static string AbsolutCachePath(string PDFPath) {
            string path = Program.Sett.Cache;
            path = path.Replace("%work%", new FileInfo(PDFPath).DirectoryName);
            path = path.Replace("%install%", Path.GetDirectoryName(Application.ExecutablePath));
            return path;
        }

        public static void RemoveCache(string PDFPath) {
            string path = Program.Sett.Cache;
            path = path.Replace("%work%", new FileInfo(PDFPath).DirectoryName);
            path = path.Replace("%install%", Path.GetDirectoryName(Application.ExecutablePath));
            Directory.Delete(path + @"\Cache", true);
        }
    }
}
