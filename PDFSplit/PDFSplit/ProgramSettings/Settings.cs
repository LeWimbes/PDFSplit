﻿using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;

namespace PDFSplit.ProgramSettings {
    public class Settings {
        private static readonly string path = Path.GetDirectoryName(Application.ExecutablePath) + @"\settings.json";

        public QuantityUnit QUnit {
            get; set;
        }
        public int Size {
            get; set;
        }

        private Settings(QuantityUnit qUnit, int size) {
            QUnit = qUnit;
            Size = size;
        }
        private Settings() {
        }

        public static Settings LoadSettings() {
            QuantityUnit qUnit = QuantityUnit.MiB;
            int size = 50;
            try {
                if (File.Exists(path)) {
                    Settings Sett = JsonConvert.DeserializeObject<Settings>(File.ReadAllText(path));
                    return Sett;
                } else {
                    Settings Sett = new Settings(qUnit, size);
                    Sett.SafeToFile();
                    return Sett;
                }
            } catch (UnauthorizedAccessException) {
                MessageBox.Show("Die Konfigurationsdatei kann nicht gelesen oder geschrieben werden!\nKontaktieren Sie Ihren Administrator.", "Fehlende Rechte", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Settings(qUnit, size);
            }
        }

        public void SafeToFile() {
            File.WriteAllText(path, JsonConvert.SerializeObject(this, Formatting.Indented));
        }
    }
}
