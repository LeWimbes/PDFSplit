using PDFSplit.ProgramSettings;
using System;
using System.Windows.Forms;

namespace PDFSplit.GUI {
    public partial class SettingsFrame : Form {

        public SettingsFrame() {
            InitializeComponent();

            unitComboBox.Items.Add(QuantityUnit.MB);
            unitComboBox.Items.Add(QuantityUnit.MiB);
            unitComboBox.Items.Add(QuantityUnit.Seiten);
            unitComboBox.SelectedItem = Settings.GetInstance().QUnit;

            sizeNumericTextBox.Text = Settings.GetInstance().Size.ToString();

            safeButton.Click += new EventHandler(SafeButton_Click);
        }

        private void SafeButton_Click(object sender, EventArgs e) {

            // Check whether a Item is selected
            if (unitComboBox.SelectedItem != null) {
               Settings.GetInstance().QUnit = (QuantityUnit)unitComboBox.SelectedItem;
               Settings.GetInstance().Save();
            } else {
                MessageBox.Show(this, "Die Einheit ist ungültig!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            // Check whether a valid number was entered
            if (sizeNumericTextBox.Text != "" && int.TryParse(sizeNumericTextBox.Text, out int size) && size > 0) {
               Settings.GetInstance().Size = size;
               Settings.GetInstance().Save();
            } else {
                MessageBox.Show(this, "Die Ganzzahl muss größer 0 sein!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           Settings.GetInstance().Save();

            Close();
            Dispose();
        }
    }
}
