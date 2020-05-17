using System.Windows.Forms;

namespace Temperature
{
    static class Util
    {
        public static void CheckEditSymbol(object sender, KeyPressEventArgs e)
        {
            var edit = (TextBox)sender;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            if ((edit.Text == "" || edit.Text.IndexOf('.') > -1) && (e.KeyChar == '.'))
            {
                e.Handled = true;
            }

            if ((edit.Text != "" || edit.Text.IndexOf('-') > -1) && (e.KeyChar == '-'))
            {
                e.Handled = true;
            }
        }
    }
}