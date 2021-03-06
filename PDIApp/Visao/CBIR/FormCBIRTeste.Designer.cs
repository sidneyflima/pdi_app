namespace PDIApp.Visao.CBIR
{
    partial class FormCBIRTeste
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.descritorComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.medidaComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.similaridadeTextBox = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.abrirConsultaButton = new System.Windows.Forms.Button();
            this.descritorQueryButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.abrirTesteButton = new System.Windows.Forms.Button();
            this.descritorTesteButton = new System.Windows.Forms.Button();
            this.pictureBoxQuery = new System.Windows.Forms.PictureBox();
            this.pictureBoxTeste = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTeste)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel4);
            this.groupBox1.Controls.Add(this.flowLayoutPanel3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(764, 81);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configurações";
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.button1);
            this.flowLayoutPanel4.Controls.Add(this.progressBar);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(3, 44);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(758, 34);
            this.flowLayoutPanel4.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(227, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Iniciar Cálculo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar.Location = new System.Drawing.Point(236, 3);
            this.progressBar.Maximum = 10;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(514, 23);
            this.progressBar.Step = 7;
            this.progressBar.TabIndex = 1;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.label1);
            this.flowLayoutPanel3.Controls.Add(this.descritorComboBox);
            this.flowLayoutPanel3.Controls.Add(this.label2);
            this.flowLayoutPanel3.Controls.Add(this.medidaComboBox);
            this.flowLayoutPanel3.Controls.Add(this.label3);
            this.flowLayoutPanel3.Controls.Add(this.similaridadeTextBox);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(758, 28);
            this.flowLayoutPanel3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descritor Utilizado: ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // descritorComboBox
            // 
            this.descritorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.descritorComboBox.FormattingEnabled = true;
            this.descritorComboBox.Items.AddRange(new object[] {
            "Color Histogram",
            "Color Coherence Vector",
            "Local Binary Pattern"});
            this.descritorComboBox.Location = new System.Drawing.Point(109, 3);
            this.descritorComboBox.Name = "descritorComboBox";
            this.descritorComboBox.Size = new System.Drawing.Size(121, 21);
            this.descritorComboBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(236, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Medida de Similaridade:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // medidaComboBox
            // 
            this.medidaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.medidaComboBox.FormattingEnabled = true;
            this.medidaComboBox.Items.AddRange(new object[] {
            "Diferenças de Histogramas",
            "Distância d1",
            "Intersecção de Histogramas",
            "Correlação de Histogramas",
            "Distância dLog"});
            this.medidaComboBox.Location = new System.Drawing.Point(379, 3);
            this.medidaComboBox.Name = "medidaComboBox";
            this.medidaComboBox.Size = new System.Drawing.Size(165, 21);
            this.medidaComboBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(550, 0);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(100, 26);
            this.label3.TabIndex = 1;
            this.label3.Text = "Resultado: ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // similaridadeTextBox
            // 
            this.similaridadeTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.similaridadeTextBox.Location = new System.Drawing.Point(656, 3);
            this.similaridadeTextBox.Name = "similaridadeTextBox";
            this.similaridadeTextBox.ReadOnly = true;
            this.similaridadeTextBox.Size = new System.Drawing.Size(94, 20);
            this.similaridadeTextBox.TabIndex = 2;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Arquivo de Imagem|*.bmp;*.png;*.jpg;*.jpeg";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxQuery, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxTeste, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 91);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.9881F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.0119F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(764, 341);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.abrirConsultaButton);
            this.flowLayoutPanel1.Controls.Add(this.descritorQueryButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 306);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(376, 32);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // abrirConsultaButton
            // 
            this.abrirConsultaButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.abrirConsultaButton.Location = new System.Drawing.Point(233, 3);
            this.abrirConsultaButton.Name = "abrirConsultaButton";
            this.abrirConsultaButton.Size = new System.Drawing.Size(140, 25);
            this.abrirConsultaButton.TabIndex = 0;
            this.abrirConsultaButton.Text = "Abrir Imagem Consulta";
            this.abrirConsultaButton.UseVisualStyleBackColor = true;
            this.abrirConsultaButton.Click += new System.EventHandler(this.abrirConsultaButton_Click);
            // 
            // descritorQueryButton
            // 
            this.descritorQueryButton.Location = new System.Drawing.Point(87, 3);
            this.descritorQueryButton.Name = "descritorQueryButton";
            this.descritorQueryButton.Size = new System.Drawing.Size(140, 25);
            this.descritorQueryButton.TabIndex = 1;
            this.descritorQueryButton.Text = "Exibir dados do descritor";
            this.descritorQueryButton.UseVisualStyleBackColor = true;
            this.descritorQueryButton.Click += new System.EventHandler(this.descritorQueryButton_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.abrirTesteButton);
            this.flowLayoutPanel2.Controls.Add(this.descritorTesteButton);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(385, 306);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(376, 32);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // abrirTesteButton
            // 
            this.abrirTesteButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.abrirTesteButton.Location = new System.Drawing.Point(3, 3);
            this.abrirTesteButton.Name = "abrirTesteButton";
            this.abrirTesteButton.Size = new System.Drawing.Size(140, 25);
            this.abrirTesteButton.TabIndex = 0;
            this.abrirTesteButton.Text = "Abrir Imagem de Teste";
            this.abrirTesteButton.UseVisualStyleBackColor = true;
            this.abrirTesteButton.Click += new System.EventHandler(this.abrirTesteButton_Click);
            // 
            // descritorTesteButton
            // 
            this.descritorTesteButton.Location = new System.Drawing.Point(149, 3);
            this.descritorTesteButton.Name = "descritorTesteButton";
            this.descritorTesteButton.Size = new System.Drawing.Size(140, 25);
            this.descritorTesteButton.TabIndex = 1;
            this.descritorTesteButton.Text = "Exibir dados do descritor";
            this.descritorTesteButton.UseVisualStyleBackColor = true;
            this.descritorTesteButton.Click += new System.EventHandler(this.descritorTesteButton_Click);
            // 
            // pictureBoxQuery
            // 
            this.pictureBoxQuery.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxQuery.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxQuery.Name = "pictureBoxQuery";
            this.pictureBoxQuery.Size = new System.Drawing.Size(376, 297);
            this.pictureBoxQuery.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxQuery.TabIndex = 2;
            this.pictureBoxQuery.TabStop = false;
            // 
            // pictureBoxTeste
            // 
            this.pictureBoxTeste.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxTeste.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxTeste.Location = new System.Drawing.Point(385, 3);
            this.pictureBoxTeste.Name = "pictureBoxTeste";
            this.pictureBoxTeste.Size = new System.Drawing.Size(376, 297);
            this.pictureBoxTeste.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxTeste.TabIndex = 3;
            this.pictureBoxTeste.TabStop = false;
            // 
            // FormCBIRTeste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 442);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormCBIRTeste";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowIcon = false;
            this.Text = "Medindo Similaridade entre imagens";
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTeste)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.PictureBox pictureBoxQuery;
        private System.Windows.Forms.PictureBox pictureBoxTeste;
        private System.Windows.Forms.Button abrirConsultaButton;
        private System.Windows.Forms.Button abrirTesteButton;
        private System.Windows.Forms.Button descritorQueryButton;
        private System.Windows.Forms.Button descritorTesteButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox descritorComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox medidaComboBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox similaridadeTextBox;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}