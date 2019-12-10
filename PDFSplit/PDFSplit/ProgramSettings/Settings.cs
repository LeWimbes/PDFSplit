using System.Collections.Specialized;
using System.Globalization;

namespace PDFSplit.ProgramSettings {
    public class Settings {
        private static Settings Instance;

        /// <summary>
        /// Gets or creates the single instance of this class.
        /// </summary>
        /// <returns>the instance of this class.</returns>
        public static Settings GetInstance() {
            if (Instance == null)
                Instance = new Settings(
                    Properties.Settings.Default.QUnit,
                    Properties.Settings.Default.Size,
                    Properties.Settings.Default.Language,
                    Properties.Settings.Default.AvailableLanguages);
            return Instance;
        }

        /// <summary>
        /// QUnit holds the <see cref="QuantityUnit"/> specified by the user.
        /// </summary>
        public QuantityUnit QUnit {
            get; set;
        }

        /// <summary>
        /// Size holds the amount/size specified by the user.
        /// </summary>
        public int Size {
            get; set;
        }

        private string _Language;
        /// <summary>
        /// Language holds application language specified by the user.
        /// </summary>
        public string Language {
            get {
                if (_Language.Equals("auto"))
                    return CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
                return _Language;
            }
            set {
                _Language = value;
            }
        }

        /// <summary>
        /// AvailableLanguages holds which language files are available.
        /// </summary>
        public StringCollection AvailableLanguages {
            get; private set;
        }

        /// <summary>
        /// Creates an instance of <see cref="Settings"/> with the given arguments.
        /// </summary>
        /// <param name="qUnit">is the <see cref="QuantityUnit"/> which will be hold by this instance.</param>
        /// <param name="size">is the amount/size which will be hold by this instance.</param>
        /// <param name="language">is the language which will be used for strings.</param>
        /// <param name="availableLanguages">is a list of all available languages.</param>
        private Settings(QuantityUnit qUnit, int size, string language, StringCollection availableLanguages) {
            QUnit = qUnit;
            Size = size;
            Language = language;
            AvailableLanguages = availableLanguages;
        }

        /// <summary>
        /// Saves the fields of this <see cref="Settings"/> to the default settings file.
        /// </summary>
        public void Save() {
            Properties.Settings.Default.QUnit = QUnit;
            Properties.Settings.Default.Size = Size;
            Properties.Settings.Default.Language = Language;
            Properties.Settings.Default.Save();
        }
        
        /// <summary>
        /// Only to avoid calling the default constructor from outside this class.
        /// </summary>
        private Settings() {
        }
    }
}
