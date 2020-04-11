namespace Temperature
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonMinimize = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelC = new System.Windows.Forms.Label();
            this.labelF = new System.Windows.Forms.Label();
            this.labelK = new System.Windows.Forms.Label();
            this.TextBoxCelsius = new System.Windows.Forms.TextBox();
            this.TextBoxFahrenheit = new System.Windows.Forms.TextBox();
            this.TextBoxKelvin = new System.Windows.Forms.TextBox();
            this.Refrash = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonMinimize
            // 
            this.buttonMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMinimize.BackColor = System.Drawing.Color.Black;
            this.buttonMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMinimize.ForeColor = System.Drawing.Color.White;
            this.buttonMinimize.Location = new System.Drawing.Point(242, 9);
            this.buttonMinimize.Margin = new System.Windows.Forms.Padding(0);
            this.buttonMinimize.Name = "buttonMinimize";
            this.buttonMinimize.Size = new System.Drawing.Size(25, 25);
            this.buttonMinimize.TabIndex = 24;
            this.buttonMinimize.Text = "_";
            this.buttonMinimize.UseVisualStyleBackColor = false;
            this.buttonMinimize.Click += new System.EventHandler(this.ButtonMinimize_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.BackColor = System.Drawing.Color.Black;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonClose.ForeColor = System.Drawing.Color.White;
            this.buttonClose.Location = new System.Drawing.Point(266, 9);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(25, 25);
            this.buttonClose.TabIndex = 23;
            this.buttonClose.Text = "×";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // labelC
            // 
            this.labelC.AutoSize = true;
            this.labelC.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelC.ForeColor = System.Drawing.Color.White;
            this.labelC.Location = new System.Drawing.Point(55, 93);
            this.labelC.Margin = new System.Windows.Forms.Padding(3);
            this.labelC.Name = "labelC";
            this.labelC.Size = new System.Drawing.Size(38, 29);
            this.labelC.TabIndex = 28;
            this.labelC.Text = "°C";
            // 
            // labelF
            // 
            this.labelF.AutoSize = true;
            this.labelF.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelF.ForeColor = System.Drawing.Color.White;
            this.labelF.Location = new System.Drawing.Point(55, 148);
            this.labelF.Margin = new System.Windows.Forms.Padding(3);
            this.labelF.Name = "labelF";
            this.labelF.Size = new System.Drawing.Size(36, 29);
            this.labelF.TabIndex = 30;
            this.labelF.Text = "°F";
            // 
            // labelK
            // 
            this.labelK.AutoSize = true;
            this.labelK.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelK.ForeColor = System.Drawing.Color.White;
            this.labelK.Location = new System.Drawing.Point(54, 203);
            this.labelK.Margin = new System.Windows.Forms.Padding(3);
            this.labelK.Name = "labelK";
            this.labelK.Size = new System.Drawing.Size(37, 29);
            this.labelK.TabIndex = 32;
            this.labelK.Text = "°K";
            // 
            // TextBoxCelsius
            // 
            this.TextBoxCelsius.BackColor = System.Drawing.Color.Black;
            this.TextBoxCelsius.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextBoxCelsius.ForeColor = System.Drawing.Color.White;
            this.TextBoxCelsius.Location = new System.Drawing.Point(106, 90);
            this.TextBoxCelsius.Margin = new System.Windows.Forms.Padding(10);
            this.TextBoxCelsius.Name = "TextBoxCelsius";
            this.TextBoxCelsius.Size = new System.Drawing.Size(140, 35);
            this.TextBoxCelsius.TabIndex = 34;
            this.TextBoxCelsius.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxCelsius_KeyPress);
            // 
            // TextBoxFahrenheit
            // 
            this.TextBoxFahrenheit.BackColor = System.Drawing.Color.Black;
            this.TextBoxFahrenheit.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextBoxFahrenheit.ForeColor = System.Drawing.Color.White;
            this.TextBoxFahrenheit.Location = new System.Drawing.Point(106, 145);
            this.TextBoxFahrenheit.Margin = new System.Windows.Forms.Padding(10);
            this.TextBoxFahrenheit.Name = "TextBoxFahrenheit";
            this.TextBoxFahrenheit.Size = new System.Drawing.Size(140, 35);
            this.TextBoxFahrenheit.TabIndex = 35;
            this.TextBoxFahrenheit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxFahrenheit_KeyPress);
            // 
            // TextBoxKelvin
            // 
            this.TextBoxKelvin.BackColor = System.Drawing.Color.Black;
            this.TextBoxKelvin.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextBoxKelvin.ForeColor = System.Drawing.Color.White;
            this.TextBoxKelvin.Location = new System.Drawing.Point(104, 200);
            this.TextBoxKelvin.Margin = new System.Windows.Forms.Padding(10);
            this.TextBoxKelvin.Name = "TextBoxKelvin";
            this.TextBoxKelvin.Size = new System.Drawing.Size(140, 35);
            this.TextBoxKelvin.TabIndex = 36;
            this.TextBoxKelvin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxKelvin_KeyPress);
            // 
            // Refrash
            // 
            this.Refrash.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Refrash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Refrash.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Refrash.ForeColor = System.Drawing.Color.White;
            this.Refrash.Location = new System.Drawing.Point(62, 255);
            this.Refrash.Margin = new System.Windows.Forms.Padding(10);
            this.Refrash.Name = "Refrash";
            this.Refrash.Size = new System.Drawing.Size(182, 35);
            this.Refrash.TabIndex = 37;
            this.Refrash.Text = "Refrash";
            this.Refrash.UseVisualStyleBackColor = true;
            this.Refrash.Click += new System.EventHandler(this.Refrash_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(300, 380);
            this.Controls.Add(this.Refrash);
            this.Controls.Add(this.TextBoxKelvin);
            this.Controls.Add(this.TextBoxFahrenheit);
            this.Controls.Add(this.TextBoxCelsius);
            this.Controls.Add(this.labelK);
            this.Controls.Add(this.labelF);
            this.Controls.Add(this.labelC);
            this.Controls.Add(this.buttonMinimize);
            this.Controls.Add(this.buttonClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Temperature";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonMinimize;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label labelC;
        private System.Windows.Forms.Label labelF;
        private System.Windows.Forms.Label labelK;
        private System.Windows.Forms.TextBox TextBoxCelsius;
        private System.Windows.Forms.TextBox TextBoxFahrenheit;
        private System.Windows.Forms.TextBox TextBoxKelvin;
        private System.Windows.Forms.Button Refrash;
    }
}

