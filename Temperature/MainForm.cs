using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Temperature
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Opacity = 0.9;

            foreach (Button button in Controls.OfType<Button>())
            {
                button.MouseEnter += (s, e) =>
                {
                    button.BackColor = Color.White;
                    button.ForeColor = Color.Black;
                };

                button.MouseLeave += (s, e) =>
                {
                    button.BackColor = Color.Black;
                    button.ForeColor = Color.White;
                };
            }
        }

        private static bool refresh = true;

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            Capture = false;
            Message m = Message.Create(Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            WndProc(ref m);
        }

        private void TextBoxCelsius_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxFahrenheit.Clear();
            TextBoxKelvin.Clear();
            Util.CheckEditSymbol(sender, e);

            refresh = false;
            Refresh.Text = "Clear";
        }

        private void TextBoxFahrenheit_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxCelsius.Clear();
            TextBoxKelvin.Clear();
            Util.CheckEditSymbol(sender, e);

            refresh = false;
            Refresh.Text = "Clear";
        }

        private void TextBoxKelvin_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxCelsius.Clear();
            TextBoxFahrenheit.Clear();
            Util.CheckEditSymbol(sender, e);

            refresh = false;
            Refresh.Text = "Clear";
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            if ((TextBoxCelsius.Text == "" && TextBoxFahrenheit.Text == "" && TextBoxKelvin.Text == "") ||
                (TextBoxCelsius.Text == "-" || TextBoxFahrenheit.Text == "-" || TextBoxKelvin.Text == "-"))
            {
                ClearAllTextBoxes();
                return;
            }

            if (refresh)
            {
                IScales scales;

                if (TextBoxCelsius.Text != "")
                {
                    scales = new Celsius(Convert.ToDouble(TextBoxCelsius.Text.Replace('.', ',')));
                }
                else if (TextBoxFahrenheit.Text != "")
                {
                    scales = new Fahrenheit(Convert.ToDouble(TextBoxFahrenheit.Text.Replace('.', ',')));
                }
                else
                {
                    scales = new Kelvin(Convert.ToDouble(TextBoxKelvin.Text.Replace('.', ',')));
                }

                TextBoxCelsius.Text = $"{scales.GetCelsius():f2}";
                TextBoxFahrenheit.Text = $"{scales.GetFahrenheit():f2}";
                TextBoxKelvin.Text = $"{scales.GetKelvin():f2}";
            }
            else
            {
                ClearAllTextBoxes();
            }

            refresh = !refresh;
            Refresh.Text = refresh ? "Refresh" : "Clear";
        }

        private void ClearAllTextBoxes()
        {
            foreach (TextBox textBox in Controls.OfType<TextBox>())
            {
                textBox.Clear();
            }
        }

        private void ButtonMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}