using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Temperature.Model;
using Temperature.Controller;

namespace Temperature
{
    public partial class MainForm : Form
    {
        private static bool refresh = true;
        private static Label[] labels;
        private static TextBox[] textBoxes;
        private static IScale[] scales;

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

            labels = new Label[] { label1, label2, label3 };
            textBoxes = new TextBox[] { TextBox1, TextBox2, TextBox3 };
            scales = ScalesControl.GetScales();

            RefreshDisplay();
            ClearAllTextBoxes();
        }


        private void RefreshDisplay()
        {
            for (int i = 0; i < textBoxes.Length; i++)
            {
                labels[i].Text = scales[i].Name;
                textBoxes[i].Text = scales[i].Degrees.ToString();
            }
        }

        private void RefreshScales()
        {
            double celsius = 0;

            for (int i = 0; i < textBoxes.Length; i++)
            {
                if (textBoxes[i].Text != "")
                {
                    scales[i].Degrees = Convert.ToDouble(textBoxes[i].Text);
                    celsius = scales[i].ConvertToCelsius();
                    break;
                }
            }

            for (int i = 0; i < textBoxes.Length; i++)
            {
                scales[i].Degrees = scales[i].ConvertFromCelsius(celsius);

                textBoxes[i].Text = $"{scales[i].Degrees:f2}";
            }

            refresh = false;
            Refresh.Text = "Clear";
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            if ((TextBox1.Text == "" && TextBox2.Text == "" && TextBox3.Text == "") ||
                (TextBox1.Text == "-" || TextBox2.Text == "-" || TextBox3.Text == "-"))
            {
                ClearAllTextBoxes();
                return;
            }

            if (refresh)
            {
                RefreshScales();
            }
            else
            {
                ClearAllTextBoxes();
            }
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            Capture = false;
            Message m = Message.Create(Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            WndProc(ref m);
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox2.Clear();
            TextBox3.Clear();
            Util.CheckEditSymbol(sender, e);
        }

        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox1.Clear();
            TextBox3.Clear();
            Util.CheckEditSymbol(sender, e);
        }

        private void TextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox1.Clear();
            TextBox2.Clear();
            Util.CheckEditSymbol(sender, e);
        }

        private void ClearAllTextBoxes()
        {
            foreach (var textBox in textBoxes)
            {
                textBox.Clear();
            }

            refresh = true;
            Refresh.Text = "Refresh";
        }

        private void ButtonMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Back || e.KeyData == Keys.Delete)
            {
                ClearAllTextBoxes();
            }
        }
    }
}