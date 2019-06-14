using System.Windows.Forms;

namespace PDFSplit.GUI {
    public class NumericTextBox : TextBox {
        protected override void OnKeyPress(KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
            base.OnKeyPress(e);
        }
    }
}
