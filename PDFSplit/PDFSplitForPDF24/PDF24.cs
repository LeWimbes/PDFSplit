using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDFSplitForPDF24 {
    class PDF24 {
        public static bool Exists() {
            return File.Exists(Program.Sett.PDF24);
        }

        public static bool Run(string args) {
            if (PDF24.Exists()) {
                Process PDF24P = new Process();
                PDF24P.StartInfo.FileName = Program.Sett.PDF24;
                PDF24P.StartInfo.Arguments = args;
                PDF24P.Start();
                PDF24P.WaitForExit();
                return true;
            } else {
                MessageBox.Show("PDF24 konnte nicht gefunden werden!\nFragen Sie gegebenenfalls Ihren Administrator um Rat.", "PDF24 nicht gefunden", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
