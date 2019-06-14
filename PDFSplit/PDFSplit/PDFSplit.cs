using System.IO;
using System.Windows.Forms;

namespace PDFSplit {
    class PDFSplit {

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
