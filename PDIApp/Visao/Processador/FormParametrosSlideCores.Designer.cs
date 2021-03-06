namespace PDIApp.Visao
{
    partial class FormParametrosSlideCores
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.max1Label = new System.Windows.Forms.Label();
            this.min1Label = new System.Windows.Forms.Label();
            this.barraSlide1 = new System.Windows.Forms.TrackBar();
            this.botaoConcluir = new System.Windows.Forms.Button();
            this.valor1TextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.valor2TextBox = new System.Windows.Forms.TextBox();
            this.valor3TextBox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.max2Label = new System.Windows.Forms.Label();
            this.min2Label = new System.Windows.Forms.Label();
            this.barraSlide2 = new System.Windows.Forms.TrackBar();
            this.panel3 = new System.Windows.Forms.Panel();
            this.max3Label = new System.Windows.Forms.Label();
            this.min3Label = new System.Windows.Forms.Label();
            this.barraSlide3 = new System.Windows.Forms.TrackBar();
            this.param1Label = new System.Windows.Forms.Label();
            this.param2Label = new System.Windows.Forms.Label();
            this.param3Label = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barraSlide1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barraSlide2)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barraSlide3)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.max1Label);
            this.panel1.Controls.Add(this.min1Label);
            this.panel1.Controls.Add(this.barraSlide1);
            this.panel1.Location = new System.Drawing.Point(6, 56);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(423, 70);
            this.panel1.TabIndex = 4;
            // 
            // max1Label
            // 
            this.max1Label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.max1Label.AutoSize = true;
            this.max1Label.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.max1Label.Location = new System.Drawing.Point(380, 5);
            this.max1Label.Name = "max1Label";
            this.max1Label.Size = new System.Drawing.Size(38, 13);
            this.max1Label.TabIndex = 2;
            this.max1Label.Text = "<max>";
            this.max1Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // min1Label
            // 
            this.min1Label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.min1Label.AutoSize = true;
            this.min1Label.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.min1Label.Location = new System.Drawing.Point(9, 5);
            this.min1Label.Name = "min1Label";
            this.min1Label.Size = new System.Drawing.Size(35, 13);
            this.min1Label.TabIndex = 1;
            this.min1Label.Text = "<min>";
            this.min1Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // barraSlide1
            // 
            this.barraSlide1.AutoSize = false;
            this.barraSlide1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barraSlide1.Location = new System.Drawing.Point(5, 25);
            this.barraSlide1.Name = "barraSlide1";
            this.barraSlide1.Size = new System.Drawing.Size(413, 40);
            this.barraSlide1.TabIndex = 0;
            this.barraSlide1.ValueChanged += new System.EventHandler(this.barraSlide1_ValueChanged);
            // 
            // botaoConcluir
            // 
            this.botaoConcluir.Location = new System.Drawing.Point(182, 307);
            this.botaoConcluir.Name = "botaoConcluir";
            this.botaoConcluir.Size = new System.Drawing.Size(75, 23);
            this.botaoConcluir.TabIndex = 6;
            this.botaoConcluir.Text = "Concluir";
            this.botaoConcluir.UseVisualStyleBackColor = true;
            this.botaoConcluir.Click += new System.EventHandler(this.botaoConcluir_Click);
            // 
            // valor1TextBox
            // 
            this.valor1TextBox.BackColor = System.Drawing.SystemColors.Window;
            this.valor1TextBox.Location = new System.Drawing.Point(115, 9);
            this.valor1TextBox.Name = "valor1TextBox";
            this.valor1TextBox.ReadOnly = true;
            this.valor1TextBox.Size = new System.Drawing.Size(100, 20);
            this.valor1TextBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(7, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 28);
            this.label1.TabIndex = 3;
            this.label1.Text = "Valor do Parâmetro:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // valor2TextBox
            // 
            this.valor2TextBox.BackColor = System.Drawing.SystemColors.Window;
            this.valor2TextBox.Location = new System.Drawing.Point(221, 9);
            this.valor2TextBox.Name = "valor2TextBox";
            this.valor2TextBox.ReadOnly = true;
            this.valor2TextBox.Size = new System.Drawing.Size(100, 20);
            this.valor2TextBox.TabIndex = 7;
            // 
            // valor3TextBox
            // 
            this.valor3TextBox.BackColor = System.Drawing.SystemColors.Window;
            this.valor3TextBox.Location = new System.Drawing.Point(327, 10);
            this.valor3TextBox.Name = "valor3TextBox";
            this.valor3TextBox.ReadOnly = true;
            this.valor3TextBox.Size = new System.Drawing.Size(100, 20);
            this.valor3TextBox.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.max2Label);
            this.panel2.Controls.Add(this.min2Label);
            this.panel2.Controls.Add(this.barraSlide2);
            this.panel2.Location = new System.Drawing.Point(6, 143);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(423, 70);
            this.panel2.TabIndex = 5;
            // 
            // max2Label
            // 
            this.max2Label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.max2Label.AutoSize = true;
            this.max2Label.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.max2Label.Location = new System.Drawing.Point(383, 5);
            this.max2Label.Name = "max2Label";
            this.max2Label.Size = new System.Drawing.Size(38, 13);
            this.max2Label.TabIndex = 2;
            this.max2Label.Text = "<max>";
            this.max2Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // min2Label
            // 
            this.min2Label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.min2Label.AutoSize = true;
            this.min2Label.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.min2Label.Location = new System.Drawing.Point(9, 5);
            this.min2Label.Name = "min2Label";
            this.min2Label.Size = new System.Drawing.Size(35, 13);
            this.min2Label.TabIndex = 1;
            this.min2Label.Text = "<min>";
            this.min2Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // barraSlide2
            // 
            this.barraSlide2.AutoSize = false;
            this.barraSlide2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barraSlide2.Location = new System.Drawing.Point(5, 25);
            this.barraSlide2.Name = "barraSlide2";
            this.barraSlide2.Size = new System.Drawing.Size(413, 40);
            this.barraSlide2.TabIndex = 0;
            this.barraSlide2.ValueChanged += new System.EventHandler(this.barraSlide2_ValueChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.max3Label);
            this.panel3.Controls.Add(this.min3Label);
            this.panel3.Controls.Add(this.barraSlide3);
            this.panel3.Location = new System.Drawing.Point(4, 231);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(5);
            this.panel3.Size = new System.Drawing.Size(423, 70);
            this.panel3.TabIndex = 5;
            // 
            // max3Label
            // 
            this.max3Label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.max3Label.AutoSize = true;
            this.max3Label.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.max3Label.Location = new System.Drawing.Point(385, 5);
            this.max3Label.Name = "max3Label";
            this.max3Label.Size = new System.Drawing.Size(38, 13);
            this.max3Label.TabIndex = 2;
            this.max3Label.Text = "<max>";
            this.max3Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // min3Label
            // 
            this.min3Label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.min3Label.AutoSize = true;
            this.min3Label.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.min3Label.Location = new System.Drawing.Point(9, 5);
            this.min3Label.Name = "min3Label";
            this.min3Label.Size = new System.Drawing.Size(35, 13);
            this.min3Label.TabIndex = 1;
            this.min3Label.Text = "<min>";
            this.min3Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // barraSlide3
            // 
            this.barraSlide3.AutoSize = false;
            this.barraSlide3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barraSlide3.Location = new System.Drawing.Point(5, 25);
            this.barraSlide3.Name = "barraSlide3";
            this.barraSlide3.Size = new System.Drawing.Size(413, 40);
            this.barraSlide3.TabIndex = 0;
            this.barraSlide3.ValueChanged += new System.EventHandler(this.barraSlide3_ValueChanged);
            // 
            // param1Label
            // 
            this.param1Label.AutoSize = true;
            this.param1Label.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.param1Label.Location = new System.Drawing.Point(9, 41);
            this.param1Label.Name = "param1Label";
            this.param1Label.Size = new System.Drawing.Size(35, 13);
            this.param1Label.TabIndex = 9;
            this.param1Label.Text = "label6";
            // 
            // param2Label
            // 
            this.param2Label.AutoSize = true;
            this.param2Label.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.param2Label.Location = new System.Drawing.Point(9, 128);
            this.param2Label.Name = "param2Label";
            this.param2Label.Size = new System.Drawing.Size(35, 13);
            this.param2Label.TabIndex = 10;
            this.param2Label.Text = "label6";
            // 
            // param3Label
            // 
            this.param3Label.AutoSize = true;
            this.param3Label.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.param3Label.Location = new System.Drawing.Point(7, 216);
            this.param3Label.Name = "param3Label";
            this.param3Label.Size = new System.Drawing.Size(35, 13);
            this.param3Label.TabIndex = 11;
            this.param3Label.Text = "label7";
            // 
            // FormParametrosSlideCores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(443, 337);
            this.Controls.Add(this.param3Label);
            this.Controls.Add(this.param2Label);
            this.Controls.Add(this.param1Label);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.valor3TextBox);
            this.Controls.Add(this.valor2TextBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.botaoConcluir);
            this.Controls.Add(this.valor1TextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormParametrosSlideCores";
            this.Text = "FormParametrosSlideCores";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barraSlide1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barraSlide2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barraSlide3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label max1Label;
        private System.Windows.Forms.Label min1Label;
        private System.Windows.Forms.TrackBar barraSlide1;
        private System.Windows.Forms.Button botaoConcluir;
        private System.Windows.Forms.TextBox valor1TextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox valor2TextBox;
        private System.Windows.Forms.TextBox valor3TextBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label max2Label;
        private System.Windows.Forms.Label min2Label;
        private System.Windows.Forms.TrackBar barraSlide2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label max3Label;
        private System.Windows.Forms.Label min3Label;
        private System.Windows.Forms.TrackBar barraSlide3;
        private System.Windows.Forms.Label param1Label;
        private System.Windows.Forms.Label param2Label;
        private System.Windows.Forms.Label param3Label;
    }
}