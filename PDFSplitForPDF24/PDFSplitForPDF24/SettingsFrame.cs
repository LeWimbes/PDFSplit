using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDFSplitForPDF24 {
    public partial class SettingsFrame : Form {
        public SettingsFrame() {
            InitializeComponent();

            unitComboBox.Items.Add(SizeType.MB);
            unitComboBox.Items.Add(SizeType.MiB);
            unitComboBox.Items.Add(SizeType.Seiten);
            unitComboBox.SelectedItem = Program.Sett.Stype;

            sizeNumericTextBox.Text = Program.Sett.Size.ToString();

            cacheTextBox.Text = Program.Sett.Cache;
        }
    }
}
