

namespace PDIApp.Visao
{
    partial class FormHistograma
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHistograma));
            this.graficoR = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.exibirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exibirHistogramaComoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colunasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linhasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colunasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.areasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.áreaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.àreaSplineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linhasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pontosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.polarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exibirHistograma3DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graficoG = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.graficoB = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.graficoGray = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.graficoR)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graficoG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graficoB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graficoGray)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // graficoR
            // 
            this.graficoR.BackSecondaryColor = System.Drawing.Color.White;
            this.graficoR.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea1.Area3DStyle.Inclination = 90;
            chartArea1.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
            chartArea1.AxisX.LineWidth = 3;
            chartArea1.AxisY.LineWidth = 3;
            chartArea1.BackColor = System.Drawing.Color.DarkRed;
            chartArea1.BackSecondaryColor = System.Drawing.Color.White;
            chartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "ChartArea";
            chartArea1.ShadowOffset = 10;
            this.graficoR.ChartAreas.Add(chartArea1);
            this.graficoR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graficoR.Location = new System.Drawing.Point(10, 10);
            this.graficoR.Name = "graficoR";
            this.graficoR.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.BackSecondaryColor = System.Drawing.Color.DarkRed;
            series1.BorderColor = System.Drawing.Color.DimGray;
            series1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series1.BorderWidth = 0;
            series1.ChartArea = "ChartArea";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            series1.Color = System.Drawing.Color.Red;
            series1.Name = "Histograma";
            series1.YValuesPerPoint = 4;
            this.graficoR.Series.Add(series1);
            this.graficoR.Size = new System.Drawing.Size(366, 243);
            this.graficoR.TabIndex = 0;
            this.graficoR.Text = "Histograma";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Titulo";
            title1.Text = "Histograma da Imagem (R)";
            this.graficoR.Titles.Add(title1);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exibirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // exibirToolStripMenuItem
            // 
            this.exibirToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exibirHistogramaComoToolStripMenuItem,
            this.exibirHistograma3DToolStripMenuItem});
            this.exibirToolStripMenuItem.Name = "exibirToolStripMenuItem";
            this.exibirToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.exibirToolStripMenuItem.Text = "Propriedades";
            // 
            // exibirHistogramaComoToolStripMenuItem
            // 
            this.exibirHistogramaComoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colunasToolStripMenuItem,
            this.areasToolStripMenuItem,
            this.linhasToolStripMenuItem1,
            this.pontosToolStripMenuItem,
            this.radarToolStripMenuItem,
            this.polarToolStripMenuItem});
            this.exibirHistogramaComoToolStripMenuItem.Name = "exibirHistogramaComoToolStripMenuItem";
            this.exibirHistogramaComoToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.exibirHistogramaComoToolStripMenuItem.Text = "Exibir histograma como...";
            // 
            // colunasToolStripMenuItem
            // 
            this.colunasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.linhasToolStripMenuItem,
            this.colunasToolStripMenuItem1});
            this.colunasToolStripMenuItem.Name = "colunasToolStripMenuItem";
            this.colunasToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.colunasToolStripMenuItem.Text = "Barras";
            // 
            // linhasToolStripMenuItem
            // 
            this.linhasToolStripMenuItem.Name = "linhasToolStripMenuItem";
            this.linhasToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.linhasToolStripMenuItem.Text = "Linhas";
            this.linhasToolStripMenuItem.Click += new System.EventHandler(this.linhasToolStripMenuItem_Click);
            // 
            // colunasToolStripMenuItem1
            // 
            this.colunasToolStripMenuItem1.Name = "colunasToolStripMenuItem1";
            this.colunasToolStripMenuItem1.Size = new System.Drawing.Size(117, 22);
            this.colunasToolStripMenuItem1.Text = "Colunas";
            this.colunasToolStripMenuItem1.Click += new System.EventHandler(this.colunasToolStripMenuItem1_Click);
            // 
            // areasToolStripMenuItem
            // 
            this.areasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.áreaToolStripMenuItem,
            this.àreaSplineToolStripMenuItem});
            this.areasToolStripMenuItem.Name = "areasToolStripMenuItem";
            this.areasToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.areasToolStripMenuItem.Text = "Áreas";
            // 
            // áreaToolStripMenuItem
            // 
            this.áreaToolStripMenuItem.Name = "áreaToolStripMenuItem";
            this.áreaToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.áreaToolStripMenuItem.Text = "Área";
            this.áreaToolStripMenuItem.Click += new System.EventHandler(this.areaToolStripMenuItem_Click);
            // 
            // àreaSplineToolStripMenuItem
            // 
            this.àreaSplineToolStripMenuItem.Name = "àreaSplineToolStripMenuItem";
            this.àreaSplineToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.àreaSplineToolStripMenuItem.Text = "Área Spline";
            this.àreaSplineToolStripMenuItem.Click += new System.EventHandler(this.areaSplineToolStripMenuItem_Click);
            // 
            // linhasToolStripMenuItem1
            // 
            this.linhasToolStripMenuItem1.Name = "linhasToolStripMenuItem1";
            this.linhasToolStripMenuItem1.Size = new System.Drawing.Size(111, 22);
            this.linhasToolStripMenuItem1.Text = "Linhas";
            this.linhasToolStripMenuItem1.Click += new System.EventHandler(this.linhasToolStripMenuItem1_Click);
            // 
            // pontosToolStripMenuItem
            // 
            this.pontosToolStripMenuItem.Name = "pontosToolStripMenuItem";
            this.pontosToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.pontosToolStripMenuItem.Text = "Pontos";
            this.pontosToolStripMenuItem.Click += new System.EventHandler(this.pontosToolStripMenuItem_Click);
            // 
            // radarToolStripMenuItem
            // 
            this.radarToolStripMenuItem.Name = "radarToolStripMenuItem";
            this.radarToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.radarToolStripMenuItem.Text = "Radar";
            this.radarToolStripMenuItem.Click += new System.EventHandler(this.radarToolStripMenuItem_Click);
            // 
            // polarToolStripMenuItem
            // 
            this.polarToolStripMenuItem.Name = "polarToolStripMenuItem";
            this.polarToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.polarToolStripMenuItem.Text = "Polar";
            this.polarToolStripMenuItem.Click += new System.EventHandler(this.polarToolStripMenuItem_Click);
            // 
            // exibirHistograma3DToolStripMenuItem
            // 
            this.exibirHistograma3DToolStripMenuItem.CheckOnClick = true;
            this.exibirHistograma3DToolStripMenuItem.Name = "exibirHistograma3DToolStripMenuItem";
            this.exibirHistograma3DToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.exibirHistograma3DToolStripMenuItem.Text = "Exibir Histograma 3D";
            this.exibirHistograma3DToolStripMenuItem.Visible = false;
            this.exibirHistograma3DToolStripMenuItem.Click += new System.EventHandler(this.exibirHistograma3DToolStripMenuItem_Click);
            // 
            // graficoG
            // 
            this.graficoG.BackSecondaryColor = System.Drawing.Color.White;
            this.graficoG.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea2.Area3DStyle.Inclination = 90;
            chartArea2.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
            chartArea2.AxisX.LineWidth = 3;
            chartArea2.AxisY.LineWidth = 3;
            chartArea2.BackColor = System.Drawing.Color.DarkGreen;
            chartArea2.BackSecondaryColor = System.Drawing.Color.Transparent;
            chartArea2.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea2.Name = "ChartArea";
            chartArea2.ShadowOffset = 10;
            this.graficoG.ChartAreas.Add(chartArea2);
            this.graficoG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graficoG.Location = new System.Drawing.Point(10, 10);
            this.graficoG.Name = "graficoG";
            this.graficoG.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series2.BackSecondaryColor = System.Drawing.Color.LightGreen;
            series2.BorderColor = System.Drawing.Color.Black;
            series2.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series2.BorderWidth = 0;
            series2.ChartArea = "ChartArea";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            series2.Color = System.Drawing.Color.Lime;
            series2.Name = "Histograma";
            series2.YValuesPerPoint = 4;
            this.graficoG.Series.Add(series2);
            this.graficoG.Size = new System.Drawing.Size(366, 243);
            this.graficoG.TabIndex = 1;
            this.graficoG.Text = "Histograma";
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "Titulo";
            title2.Text = "Histograma da Imagem (G)";
            this.graficoG.Titles.Add(title2);
            // 
            // graficoB
            // 
            this.graficoB.BackSecondaryColor = System.Drawing.Color.White;
            this.graficoB.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea3.Area3DStyle.Inclination = 90;
            chartArea3.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
            chartArea3.AxisX.LineWidth = 3;
            chartArea3.AxisY.LineWidth = 3;
            chartArea3.BackColor = System.Drawing.Color.DarkBlue;
            chartArea3.BackSecondaryColor = System.Drawing.Color.WhiteSmoke;
            chartArea3.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea3.Name = "ChartArea";
            chartArea3.ShadowOffset = 10;
            this.graficoB.ChartAreas.Add(chartArea3);
            this.graficoB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graficoB.Location = new System.Drawing.Point(10, 10);
            this.graficoB.Name = "graficoB";
            this.graficoB.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series3.BackSecondaryColor = System.Drawing.Color.Gray;
            series3.BorderColor = System.Drawing.Color.DimGray;
            series3.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series3.BorderWidth = 0;
            series3.ChartArea = "ChartArea";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            series3.Color = System.Drawing.Color.RoyalBlue;
            series3.Name = "Histograma";
            series3.YValuesPerPoint = 4;
            this.graficoB.Series.Add(series3);
            this.graficoB.Size = new System.Drawing.Size(366, 243);
            this.graficoB.TabIndex = 2;
            this.graficoB.Text = "Histograma";
            title3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title3.Name = "Titulo";
            title3.Text = "Histograma da Imagem (B)";
            this.graficoB.Titles.Add(title3);
            // 
            // graficoGray
            // 
            this.graficoGray.BackSecondaryColor = System.Drawing.Color.White;
            this.graficoGray.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea4.Area3DStyle.Inclination = 90;
            chartArea4.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic;
            chartArea4.AxisX.LineWidth = 3;
            chartArea4.AxisY.LineWidth = 3;
            chartArea4.BackColor = System.Drawing.Color.DimGray;
            chartArea4.BackSecondaryColor = System.Drawing.Color.WhiteSmoke;
            chartArea4.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea4.Name = "ChartArea";
            chartArea4.ShadowOffset = 10;
            this.graficoGray.ChartAreas.Add(chartArea4);
            this.graficoGray.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graficoGray.Location = new System.Drawing.Point(10, 10);
            this.graficoGray.Name = "graficoGray";
            this.graficoGray.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series4.BackSecondaryColor = System.Drawing.Color.Gray;
            series4.BorderColor = System.Drawing.Color.DimGray;
            series4.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series4.BorderWidth = 0;
            series4.ChartArea = "ChartArea";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            series4.Color = System.Drawing.Color.DarkGray;
            series4.Name = "Histograma";
            series4.YValuesPerPoint = 4;
            this.graficoGray.Series.Add(series4);
            this.graficoGray.Size = new System.Drawing.Size(366, 243);
            this.graficoGray.TabIndex = 3;
            this.graficoGray.Text = "Histograma";
            title4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title4.Name = "Titulo";
            title4.Text = "Histograma da Imagem (Cinza)";
            this.graficoGray.Titles.Add(title4);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 538);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.graficoR);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(386, 263);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.graficoG);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(395, 3);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(386, 263);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.graficoB);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 272);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(10);
            this.panel3.Size = new System.Drawing.Size(386, 263);
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.graficoGray);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(395, 272);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(10);
            this.panel4.Size = new System.Drawing.Size(386, 263);
            this.panel4.TabIndex = 3;
            // 
            // FormHistograma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FormHistograma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Histograma";
            ((System.ComponentModel.ISupportInitialize)(this.graficoR)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graficoG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.graficoB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.graficoGray)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart graficoR;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exibirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exibirHistogramaComoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colunasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pontosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem areasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem áreaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem àreaSplineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linhasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem linhasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colunasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem radarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem polarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exibirHistograma3DToolStripMenuItem;
        private System.Windows.Forms.DataVisualization.Charting.Chart graficoGray;
        private System.Windows.Forms.DataVisualization.Charting.Chart graficoB;
        private System.Windows.Forms.DataVisualization.Charting.Chart graficoG;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
    }
}