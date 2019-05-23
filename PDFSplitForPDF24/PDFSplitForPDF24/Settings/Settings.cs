using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDFSplitForPDF24 {
    class Settings {
        private static readonly string path = Path.GetDirectoryName(Application.ExecutablePath) + @"\settings.json";

        public string Cache {
            get; set;
        }
        public SizeType Stype {
            get; set;
        }
        public int Size {
            get; set;
        }

        private Settings(string cache, SizeType stype, int size) {
            this.Cache = cache;
            this.Stype = stype;
            this.Size = size;
        }
        private Settings() {
        }

        public static Settings LoadSettings() {

            string cache = "%work%";
            SizeType stype = SizeType.MiB;
            int size = 50;
            try {
                if (File.Exists(path)) {
                    Settings Sett = JsonConvert.DeserializeObject<Settings>(File.ReadAllText(path));
                    return Sett;
                } else {
                    Settings Sett = new Settings(cache, stype, size);
                    File.WriteAllText(path, JsonConvert.SerializeObject(Sett, Formatting.Indented));
                    return Sett;
                }
            } catch (UnauthorizedAccessException) {
                MessageBox.Show("Die Konfigurationsdatei kann nicht gelesen oder geschrieben werden!\nKontaktieren Sie Ihren Administrator.", "Fehlende Rechte", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Settings(cache, stype, size);
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
