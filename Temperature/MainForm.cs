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
            CheckSymbol(sender, e);

            Refrash.Text = "Refrash";
            refresh = true;
        }

        private void TextBoxFahrenheit_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxCelsius.Clear();
            TextBoxKelvin.Clear();
            CheckSymbol(sender, e);

            Refrash.Text = "Refrash";
            refresh = true;
        }

        private void TextBoxKelvin_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBoxCelsius.Clear();
            TextBoxFahrenheit.Clear();
            CheckSymbol(sender, e);

            Refrash.Text = "Refrash";
            refresh = true;
        }

        private void CheckSymbol(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            if ((((sender as TextBox).Text == "") || ((sender as TextBox).Text.IndexOf('.') > -1)) && ((e.KeyChar == '.')))
            {
                e.Handled = true;
            }

            if ((((sender as TextBox).Text != "") || ((sender as TextBox).Text.IndexOf('-') > -1)) && ((e.KeyChar == '-')))
            {
                e.Handled = true;
            }
        }

        private void Refrash_Click(object sender, EventArgs e)
        {
            if ((TextBoxCelsius.Text == "" && TextBoxFahrenheit.Text == "" && TextBoxKelvin.Text == "") ||
                (TextBoxCelsius.Text == "-" || TextBoxFahrenheit.Text == "-" || TextBoxKelvin.Text == "-"))
            {
                TextBoxCelsius.Clear();
                TextBoxFahrenheit.Clear();
                TextBoxKelvin.Clear();

                return;
            }

            if (refresh)
            {
                if (TextBoxCelsius.Text != "")
                {
                    double celsius = Convert.ToDouble(TextBoxCelsius.Text.Replace('.', ','));

                    if (celsius < -273.15)
                    {
                        celsius = -273.15;
                    }

                    TextBoxCelsius.Text = string.Format("{0:f2}", celsius);
                    TextBoxFahrenheit.Text = string.Format("{0:f2}", (celsius * 1.8 + 32));
                    TextBoxKelvin.Text = string.Format("{0:f2}", (celsius + 273.15));
                }
                else if (TextBoxFahrenheit.Text != "")
                {
                    double fahrenheit = Convert.ToDouble(TextBoxFahrenheit.Text.Replace('.', ','));

                    if (fahrenheit < -459.67)
                    {
                        fahrenheit = -459.67;
                    }

                    TextBoxCelsius.Text = string.Format("{0:f2}", ((fahrenheit - 32) * 0.55555556));
                    TextBoxFahrenheit.Text = string.Format("{0:f2}", fahrenheit);
                    TextBoxKelvin.Text = string.Format("{0:f2}", ((fahrenheit - 32) * 0.55555556 + 273.15));
                }
                else
                {
                    double kelvin = Convert.ToDouble(TextBoxKelvin.Text.Replace('.', ','));

                    if (kelvin < 0)
                    {
                        kelvin = 0;
                    }

                    TextBoxCelsius.Text = string.Format("{0:f2}", (kelvin - 273.15));
                    TextBoxFahrenheit.Text = string.Format("{0:f2}", ((kelvin - 273.15) * 0.55555556 + 32));
                    TextBoxKelvin.Text = string.Format("{0:f2}", kelvin);
                }

                refresh = false;
                Refrash.Text = "Clear";
            }
            else
            {
                refresh = true;
                Refrash.Text = "Refrash";

                TextBoxCelsius.Clear();
                TextBoxFahrenheit.Clear();
                TextBoxKelvin.Clear();
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