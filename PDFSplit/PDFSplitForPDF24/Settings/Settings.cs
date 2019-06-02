using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;

namespace PDFSplitForPDF24 {
    class Settings {
        private static readonly string path = Path.GetDirectoryName(Application.ExecutablePath) + @"\settings.json";

        public string Cache {
            get; set;
        }
        public SizeType SType {
            get; set;
        }
        public int Size {
            get; set;
        }

        public string PDF24 {
            get; set;
        }

        private Settings(string cache, SizeType stype, int size, string pdf24) {
            this.Cache = cache;
            this.SType = stype;
            this.Size = size;
            this.PDF24 = pdf24;
        }
        private Settings() {
        }

        public static Settings LoadSettings() {

            string cache = "%work%";
            SizeType stype = SizeType.MiB;
            int size = 50;
            string pdf24 = @"C:\Program Files (x86)\PDF24\pdf24-DocTool.exe";
            try {
                if (File.Exists(path)) {
                    Settings Sett = JsonConvert.DeserializeObject<Settings>(File.ReadAllText(path));
                    return Sett;
                } else {
                    Settings Sett = new Settings(cache, stype, size, pdf24);
                    Sett.SafeToFile();
                    return Sett;
                }
            } catch (UnauthorizedAccessException) {
                MessageBox.Show("Die Konfigurationsdatei kann nicht gelesen oder geschrieben werden!\nKontaktieren Sie Ihren Administrator.", "Fehlende Rechte", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Settings(cache, stype, size, pdf24);
            }
        }

        public void SafeToFile() {
            File.WriteAllText(path, JsonConvert.SerializeObject(this, Formatting.Indented));
        }
    }

    enum SizeType {
        MB,
        MiB,
        Seiten,
    };
}
