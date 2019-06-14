using PDFSplit.ProgramSettings;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PDFSplit.GUI {
    public partial class SettingsFrame : Form {
        public SettingsFrame() {
            InitializeComponent();

            unitComboBox.Items.Add(QuantityUnit.MB);
            unitComboBox.Items.Add(QuantityUnit.MiB);
            unitComboBox.Items.Add(QuantityUnit.Seiten);
            unitComboBox.SelectedItem = Program.Sett.QUnit;

            sizeNumericTextBox.Text = Program.Sett.Size.ToString();

            safeButton.Click += new EventHandler(SafeButton_Click);
        }

        private void SafeButton_Click(object sender, EventArgs e) {

            // Check whether a Item is selected
            if (unitComboBox.SelectedItem != null) {
                Program.Sett.QUnit = (QuantityUnit)unitComboBox.SelectedItem;
                Program.Sett.SafeToFile();
            } else {
                MessageBox.Show("Die Einheit ist ungültig!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            // Check whether a valid number was entered
            if (sizeNumericTextBox.Text != "" && int.TryParse(sizeNumericTextBox.Text, out int size) && size > 0) {
                Program.Sett.Size = size;
                Program.Sett.SafeToFile();
            } else {
                MessageBox.Show("Die Ganzzahl muss größer 0 sein!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Program.Sett.SafeToFile();

            this.Close();
        }
    }
}
