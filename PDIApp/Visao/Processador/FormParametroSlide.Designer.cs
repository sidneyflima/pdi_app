namespace PDIApp.Visao
{
    partial class FormParametroSlide
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.barraSlide = new System.Windows.Forms.TrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.maxLabel = new System.Windows.Forms.Label();
            this.minLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.botaoConcluir = new System.Windows.Forms.Button();
            this.valorTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barraSlide)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraSlide
            // 
            this.barraSlide.AutoSize = false;
            this.barraSlide.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barraSlide.Location = new System.Drawing.Point(5, 25);
            this.barraSlide.Name = "barraSlide";
            this.barraSlide.Size = new System.Drawing.Size(434, 40);
            this.barraSlide.TabIndex = 0;
            this.barraSlide.ValueChanged += new System.EventHandler(this.barraSlide_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.maxLabel);
            this.panel1.Controls.Add(this.minLabel);
            this.panel1.Controls.Add(this.barraSlide);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(444, 70);
            this.panel1.TabIndex = 1;
            // 
            // maxLabel
            // 
            this.maxLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.maxLabel.AutoSize = true;
            this.maxLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.maxLabel.Location = new System.Drawing.Point(401, 5);
            this.maxLabel.Name = "maxLabel";
            this.maxLabel.Size = new System.Drawing.Size(38, 13);
            this.maxLabel.TabIndex = 2;
            this.maxLabel.Text = "<max>";
            this.maxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // minLabel
            // 
            this.minLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.minLabel.AutoSize = true;
            this.minLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.minLabel.Location = new System.Drawing.Point(9, 5);
            this.minLabel.Name = "minLabel";
            this.minLabel.Size = new System.Drawing.Size(35, 13);
            this.minLabel.TabIndex = 1;
            this.minLabel.Text = "<min>";
            this.minLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.botaoConcluir);
            this.panel2.Controls.Add(this.valorTextBox);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(444, 35);
            this.panel2.TabIndex = 2;
            // 
            // botaoConcluir
            // 
            this.botaoConcluir.Location = new System.Drawing.Point(356, 8);
            this.botaoConcluir.Name = "botaoConcluir";
            this.botaoConcluir.Size = new System.Drawing.Size(75, 23);
            this.botaoConcluir.TabIndex = 2;
            this.botaoConcluir.Text = "Concluir";
            this.botaoConcluir.UseVisualStyleBackColor = true;
            this.botaoConcluir.Click += new System.EventHandler(this.botaoConcluir_Click);
            // 
            // valorTextBox
            // 
            this.valorTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.valorTextBox.Location = new System.Drawing.Point(115, 10);
            this.valorTextBox.Name = "valorTextBox";
            this.valorTextBox.ReadOnly = true;
            this.valorTextBox.Size = new System.Drawing.Size(100, 20);
            this.valorTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(7, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Valor do Parâmetro:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FormParametroSlide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(444, 101);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormParametroSlide";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parâmetros";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormParametroSlide_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.barraSlide)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TrackBar barraSlide;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label maxLabel;
        private System.Windows.Forms.Label minLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox valorTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button botaoConcluir;
    }
}