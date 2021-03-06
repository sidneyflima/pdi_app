using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using PDIApp.Util.UndoRedo;
using PDIApp.Controle;
using PDIApp.Modelo;
using PDIApp.Util;
using PDIApp.Util.Flyweight;
using PDIApp.Util.Calculos;
using PDIApp.Util.Calculos.Cores;

namespace PDIApp.Visao
{
    public partial class FormPrincipal : Form
    {
        #region Constantes

        const int INDICE_MINIMO = 0;
        const int INDICE_MAXIMO = 11;

        const int INDICE_25_POR_CENTO   = 0;
        const int INDICE_50_POR_CENTO   = 1;
        const int INDICE_75_POR_CENTO   = 2;
        const int INDICE_100_POR_CENTO  = 3;
        const int INDICE_150_POR_CENTO  = 4;
        const int INDICE_200_POR_CENTO  = 5;
        const int INDICE_250_POR_CENTO  = 6;
        const int INDICE_300_POR_CENTO  = 7;
        const int INDICE_350_POR_CENTO  = 8;
        const int INDICE_400_POR_CENTO  = 9;
        const int INDICE_450_POR_CENTO  = 10;
        const int INDICE_500_POR_CENTO  = 11;

        #endregion

        #region Atributos

        string imagePath;
        string fileName;
        int indiceComboBox;

        int alturaOriginal;
        int larguraOriginal;

        ImagemPool pool;

        Dictionary<int, double> zoomComboBoxValue;
        ComandoUndoRedo<Bitmap> comandoUndoRedo;

        #endregion

        #region Construtores

        public FormPrincipal()
        {
            InitializeComponent();

            zoomComboBoxValue = new Dictionary<int, double>();

            zoomComboBoxValue.Add(INDICE_25_POR_CENTO,  0.25);
            zoomComboBoxValue.Add(INDICE_50_POR_CENTO,  0.50);
            zoomComboBoxValue.Add(INDICE_75_POR_CENTO,  0.75);
            zoomComboBoxValue.Add(INDICE_100_POR_CENTO, 1.00);
            zoomComboBoxValue.Add(INDICE_150_POR_CENTO, 1.50);
            zoomComboBoxValue.Add(INDICE_200_POR_CENTO, 2.00);
            zoomComboBoxValue.Add(INDICE_250_POR_CENTO, 2.50);
            zoomComboBoxValue.Add(INDICE_300_POR_CENTO, 3.00);
            zoomComboBoxValue.Add(INDICE_350_POR_CENTO, 3.50);
            zoomComboBoxValue.Add(INDICE_400_POR_CENTO, 4.00);
            zoomComboBoxValue.Add(INDICE_450_POR_CENTO, 4.50);
            zoomComboBoxValue.Add(INDICE_500_POR_CENTO, 5.00);

            indiceComboBox = INDICE_100_POR_CENTO;
            zoomComboBox.SelectedIndex = indiceComboBox;

            pool = PoolFactory.Instance.PoolImagem;
            
        }

        #endregion

        #region Eventos

        Point velhaPosicaoMouse = new Point(0, 0);

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            //obtem razao do indice
            int i = zoomComboBox.SelectedIndex;
            double razao;

            this.zoomComboBoxValue.TryGetValue(i, out razao);

            int x = Convert.ToInt32(Math.Ceiling(e.X / razao));
            int y = Convert.ToInt32(Math.Ceiling(e.Y / razao));

            //if (e.Button == MouseButtons.Left)
            //{
            posicaoPixelStripLabel.Text = String.Format("({0},{1})", x.ToString("D4"), y.ToString("D4"));
            //}
            try
            {
                Color c = pool[TipoImagemPool.ATUAL].ImagemBitmap.GetPixel(x, y);

                pixelColorTextBox.BackColor = Color.FromArgb(c.R, c.G, c.B);
                pixelColorTextBox.ForeColor = Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B);


                CalculosFactory f = CalculosFactory.Instance;
                CalculosCores conversor = f.CalculosCores;

                pixelColorTextBox.Text = String.Format("#{0}", c.Name.ToUpper());
                rgbStripLabel.Text = conversor.CorParaString(c);


                double[] vet = conversor.RGBNormalizado(c);
                rgbNormStripLabel.Text = conversor.CorParaString(vet);

                vet = conversor.RGBParaHSI(c);
                hsiNormStripLabel.Text = conversor.CorParaString(vet);

                vet = conversor.RBGParaCIELAB(c);
                labStripLabel.Text = conversor.CorParaString(vet);
            }
            catch (Exception) { }
        }

        private void imagensClarasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvocaModuloTrackBar(Modulo.AJUSTE_TONALIDADE_CLARAS, 0, 255, 255, "Escolha o limite para a correção");
        }

        private void imagensEscurasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvocaModuloTrackBar(Modulo.AJUSTE_TONALIDADE_ESCURAS, 0, 255, 255, "Escolha o limite para a correção");
        }


        private void paletaRGB332bitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvocaModulo(Modulo.CONVERTER_RGB_332);
        }

        private void equalizarHistogramaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvocaModulo(Modulo.EQUALIZAR_HISTOGRAMA);
        }

        private void restaurarFundoButton_Click(object sender, EventArgs e)
        {
            pictureBox.BackColor = Color.FromArgb(255, 32, 32, 32);
        }

        private void exibirHistogramaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirHistograma();
        }

        private void histButton_Click(object sender, EventArgs e)
        {
            ExibirHistograma();
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            DesfazerImagem();
        }

        private void redoButton_Click(object sender, EventArgs e)
        {
            RefazerImagem();
        }

        private void desfazerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DesfazerImagem();
        }

        private void refazerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefazerImagem();
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvocaModuloExibeBanda(BandaCorARGB.RED);
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvocaModuloExibeBanda(BandaCorARGB.GREEN);
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvocaModuloExibeBanda(BandaCorARGB.BLUE);
        }

        private void zoomComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RealizarZoomComboBox();
        }

        private void zoomInButton_Click(object sender, EventArgs e)
        {
            RealizarZoomIn();
        }

        private void zoomOutButton_Click(object sender, EventArgs e)
        {
            RealizarZoomOut();
        }


        private void zoomRestoreButton_Click(object sender, EventArgs e)
        {
            RestaurarZoom();
        }


        private void saveButton_Click(object sender, EventArgs e)
        {
            SalvarImagem(imagePath);
        }

        private void salvarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalvarImagemComo();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            AbrirImagem();
        }

        private void salvarImagemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalvarImagem(imagePath);
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirSobre();
        }

        private void abrirImagemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirImagem();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            FechaImagem();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MudarFundoPainelImagem();
        }

        private void fatiamentoBitABitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvocaModuloTrackBar(Modulo.CONVERTER_BINARIO,
                0, 7, 7, "Selecione qual plano para o fatiamento bit a bit...");
        }

        private void fecharImagemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FechaImagem();
        }

        private void conectadas8ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //chama modulo e obtem numero componentes conexas
            int nComp = InvocaModuloRetorno<Int32>(Modulo.ROTULAR_COMPONENTES_8);
            MessageBox.Show("Numeros de componentes conexas: " + nComp);
        }

        private void conectadas4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //chama modulo e obtem numero componentes conexas
            int nComp = InvocaModuloRetorno<Int32>(Modulo.ROTULAR_COMPONENTES_4);
            MessageBox.Show("Numeros de componentes conexas: " + nComp);
        }

        private void transfIntensidadeRGBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvocaModuloMultiTrackBar(Modulo.TRANSFORMACAO_INTENSIDADE_RGB, ModeloCor.RGB,
                                      0, 100, 0, 100, 0, 100, "Define porcentagem de cada cor (%)");
        }

        private void paraImagemMonocromaticaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvocaModulo(Modulo.CONVERTER_MONOCROMATICO);
        }

        private void paraImagemBináriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvocaModuloTrackBar(Modulo.CONVERTER_BINARIO,
                0, 255, 127, "Definindo limiar para Conversão");
        }

        private void inverterCoresRGBToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            InvocaModulo(Modulo.INVERTER_CORES_RGB);
        }

        private void ajustarIntensidadeRGBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvocaModuloTrackBar(Modulo.AJUSTE_INTENSIDADE_RGB,
                0, 255, 127, "Escolhendo valor de 0 a 255 para ajustar intensidade");
        }

        private void cbirButton_Click(object sender, EventArgs e)
        {
            IniciaBuscaConteudo();
        }

        private void iniciarBuscaPorConteúdoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IniciaBuscaConteudo();
        }


        #region Filtros

        private void filtroDeMédiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvocaModuloTrackBar(Modulo.FILTRO_MEDIA, 1, 30, 3, "Escolhe tamanho da mascara");
        }

        private void filtroDeMédiaPonderadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvocaModulo(Modulo.FILTRO_MEDIA_PONDERADA);
        }

        private void filtroGaussianoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvocaModulo(Modulo.FILTRO_GAUSSIANO);
        }

        private void filtroDeMedianaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvocaModuloTrackBar(Modulo.FILTRO_MEDIANA, 1, 30, 3, "Escolhe tamanho da mascara");
        }

        private void filtroDeMinimoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvocaModuloTrackBar(Modulo.FILTRO_MAXIMO, 1, 30, 3, "Escolhe tamanho da mascara");
        }

        private void filtroDeMaximoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvocaModuloTrackBar(Modulo.FILTRO_MINIMO, 1, 30, 3, "Escolhe tamanho da mascara");
        }

        private void filtroDeModaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvocaModuloTrackBar(Modulo.FILTRO_MODA, 1, 30, 3, "Escolhe tamanho da mascara");
        }

        private void filtroLaplaciano4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvocaModulo(Modulo.FILTRO_LAPLACIANO_4);
        }

        private void filtroLaplaciano8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvocaModulo(Modulo.FILTRO_LAPLACIANO_8);
        }

        private void filtroDeRobertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvocaModulo(Modulo.FILTRO_ROBERTS_DIAGONAL_PRINCIPAL);
        }

        private void filtroDeRobert2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvocaModulo(Modulo.FILTRO_ROBERTS_DIAGONAL_SECUNDARIA);
        }

        private void filtroDeSobelhorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvocaModulo(Modulo.FILTRO_SOBEL_HORIZONTAL);
        }

        private void filtroDeSobelverticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvocaModulo(Modulo.FILTRO_SOBEL_VERTICAL);
        }

        #endregion

        #endregion

        #region Metodos

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
 	        base.OnPaint(e);
        }

        private void IniciaBuscaConteudo()
        {
            if (new CBIR.SplashCBIR().ShowDialog() == DialogResult.OK)
                //new CBIR.FormPrincipalCBIR().Show();
                new CBIR.FormCBIRTeste().Show();
        }

        #region Abrindo Salvando e Fechando Imagem

        #region Abrir

        /// <summary>
        /// Ação para funcionalidade de abrir uma imagem
        /// </summary>
        private void AbrirImagem()
        {
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //obtem caminho da imagem e nome do arquivo
                    this.imagePath = openFileDialog.FileName;
                    this.fileName = Path.GetFileName(imagePath);
                    nomeArquivoStripLabel.Text = fileName;
                    
                    //leitura do stream
                    Stream stream = openFileDialog.OpenFile();
                    
                    //obtem bitmap pelo stream
                    Bitmap imagemOriginal = new Bitmap(stream);

                    imagemOriginal.SetPixel(imagemOriginal.Width - 4, 6, Color.Black);

                    //muda a imagem bitmap no pool de imagens
                    pool[TipoImagemPool.ORIGINAL].ImagemBitmap = imagemOriginal;
                    pictureBox.Image = imagemOriginal;

                    //fecha o stream
                    stream.Close();

                    //define altura e largura da imagem
                    alturaOriginal = pictureBox.Image.Height;
                    larguraOriginal = pictureBox.Image.Width;

                    //define altura e largura do picturebox
                    pictureBox.Height = alturaOriginal;
                    pictureBox.Width = larguraOriginal;

                    //define qual o zoom
                    zoomComboBox.SelectedIndex = INDICE_100_POR_CENTO;
                    indiceComboBox = INDICE_100_POR_CENTO;
                    
                    //adiciona imagem ao undo redo 
                    if (comandoUndoRedo == null)
                        comandoUndoRedo = new ComandoUndoRedo<Bitmap>(imagemOriginal);
                    else
                        comandoUndoRedo.Limpar(imagemOriginal);
                    
                    //define imagem atual no pool
                    pool[TipoImagemPool.ATUAL].ImagemBitmap = imagemOriginal;

                    //mudar visibilidades
                    MudarVisibilidadeUndoRedo();
                    MudarVisibilidade(true);
                    //definir resolucao
                    resolucaoStripStatusLabel.Text = String.Format("{0} x {1}",
                                                                    larguraOriginal,
                                                                    alturaOriginal);
                    
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                MudarVisibilidade(false);
            }
        }

        #endregion

        #region Salvar

        /// <summary>
        /// Abre dialogo para salvar imagem e a salva
        /// </summary>
        private void SalvarImagemComo()
        {
            //...abre dialogo para salvar
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                Salvar(saveFileDialog.FileName);
        }

        /// <summary>
        /// Salva uma imagem
        /// </summary>
        /// <param name="imagePath">O nome completo do arquivo</param>
        private void SalvarImagem(string imagePath)
        {
            if (MessageBox.Show("Deseja realmente salvar esta imagem? Isto pode apagar a imagem anterior!",
                "Alerta", MessageBoxButtons.YesNo)
                != DialogResult.Yes)
                return;

            Salvar(imagePath);
        }

        /// <summary>
        /// Salva uma imagem
        /// </summary>
        /// <param name="imagePath">O nome completo do arquivo</param>
        private void Salvar(string imagePath)
        { 
            try
            {
                ImageFormat format;
                //obtem a extensao da imagem
                string extension = Path.GetExtension(imagePath);
                //configura o formato de acordo com a extensao
                switch (extension)
                {
                    case ".jpg":
                        format = ImageFormat.Jpeg;
                        break;
                    case ".png":
                        format = ImageFormat.Png;
                        break;
                    default:
                        format = ImageFormat.Bmp;
                        break;
                }

                //salva a imagem
                pictureBox.Image.Save(imagePath, format);
                MessageBox.Show(String.Format("Salvo em {0}.", imagePath));
            }
            catch (System.Runtime.InteropServices.ExternalException e)
            {
                MessageBox.Show(e.ErrorCode + ": " + e.Message + "\n" + e.HelpLink);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        #endregion

        #region Fechar

        /// <summary>
        /// Fecha a imagem
        /// </summary>
        private void FechaImagem()
        {
            fileName = "";
            imagePath = "";
            nomeArquivoStripLabel.Text = "";
            pictureBox.Image = null;
            MudarVisibilidade(false);
        }

        #endregion

        #endregion

        #region Mudança de Visibilidade

        /// <summary>
        /// Muda cor de fundo do painel de edicao
        /// </summary>
        private void MudarFundoPainelImagem()
        {
            if (backgroundColorDialog.ShowDialog() == DialogResult.OK)
                pictureBox.BackColor = backgroundColorDialog.Color;
        }

        /// <summary>
        /// Habilita os componentes ao exibir imagem
        /// </summary>
        /// <param name="enable"></param>
        private void MudarVisibilidade(bool enable)
        {
            panelToolBar.Visible    = enable;
            panelPrincipal.Visible = enable;

            saveButton.Visible      = enable;
            separator1.Visible      = enable;
            separator2.Visible      = enable;

            undoButton.Visible = enable;
            redoButton.Visible = enable;

            //originalButton.Visible  = enable;
            closeButton.Visible     = enable;
            salvarComoToolStripMenuItem.Enabled = enable;
            salvarImagemToolStripMenuItem.Enabled = enable;
            fecharImagemToolStripMenuItem.Enabled = enable;
            editarToolStripMenuItem.Visible = enable;
            pictureBox.Visible = enable;

            resolucaoStripStatusLabel.Visible = enable;
            nomeArquivoStripLabel.Visible = enable;
            separadorStripLabel.Visible = enable;
            posicaoPixelStripLabel.Visible = enable;

            operaçõesToolStripMenuItem.Visible = enable;
            histButton.Visible = enable;
            exibirToolStripMenuItem.Visible = enable;
        }

        /// <summary>
        /// Muda visibilidade de comandos Undo e Redo
        /// </summary>
        private void MudarVisibilidadeUndoRedo()
        {
            desfazerToolStripMenuItem.Enabled = comandoUndoRedo.PodeDesfazer;
            refazerToolStripMenuItem.Enabled = comandoUndoRedo.PodeRefazer;
            undoButton.Enabled = comandoUndoRedo.PodeDesfazer;
            redoButton.Enabled = comandoUndoRedo.PodeRefazer;
        }

        #endregion

        #region Manipulação de Zoom

        /// <summary>
        /// Muda o zoom da imagem
        /// </summary>
        /// <param name="razao">A razao com que o comprimento e altura deve mudar</param>
        private void MudarZoomImagem(double razao)
        {
            pictureBox.Width = Convert.ToInt32(Math.Ceiling(larguraOriginal * razao));
            pictureBox.Height = Convert.ToInt32(Math.Ceiling(alturaOriginal * razao));
        }

        /// <summary>
        /// Realiza zoom pelo indice do combobox
        /// </summary>
        /// <param name="index"></param>
        private void MudarZoomImagem(int index)
        {
            double razao;

            if (zoomComboBoxValue.TryGetValue(index, out razao))
                MudarZoomImagem(razao);
        }

        /// <summary>
        /// Realizar Zoom pelo combobox
        /// </summary>
        private void RealizarZoomComboBox()
        {

            MudarZoomImagem(zoomComboBox.SelectedIndex);
        }

        /// <summary>
        /// Realizar Zoom In
        /// </summary>
        private void RealizarZoomIn()
        {
            if (indiceComboBox != INDICE_MAXIMO)
            {
                indiceComboBox++;
                zoomComboBox.SelectedIndex = indiceComboBox;
            }
        }

        /// <summary>
        /// Realizar Zoom Out
        /// </summary>
        private void RealizarZoomOut()
        {
            if (indiceComboBox != INDICE_MINIMO)
            {
                indiceComboBox--;
                zoomComboBox.SelectedIndex = indiceComboBox;
            }
        }

        /// <summary>
        /// Restaurar Zoom
        /// </summary>
        private void RestaurarZoom()
        {
            indiceComboBox = INDICE_100_POR_CENTO;
            zoomComboBox.SelectedIndex = INDICE_100_POR_CENTO;
        }

        #endregion

        #region Aplicação de Undo e Redo

        private void DesfazerImagem()
        {
            Bitmap imagem = comandoUndoRedo.Desfazer();
            pool[TipoImagemPool.ATUAL].ImagemBitmap = imagem;
            pictureBox.Image = imagem;
            MudarVisibilidadeUndoRedo();
        }

        private void RefazerImagem()
        {
            Bitmap imagem = comandoUndoRedo.Refazer();
            pool[TipoImagemPool.ATUAL].ImagemBitmap = imagem;
            pictureBox.Image = imagem;
            MudarVisibilidadeUndoRedo();
        }

        #endregion

        #region Invocação de Janelas e Módulos

        /// <summary>
        /// Ação para abrir janela Sobre
        /// </summary>
        private static void AbrirSobre()
        {
            FormSobre sobre = new FormSobre();
            sobre.ShowDialog();
            sobre.Dispose();
        }

        /// <summary>
        /// Invoca um módulo, modificando a imagem. Porem utiliza 
        /// o formulario com um track bar
        /// </summary>
        /// <param name="modulo">O modulo (operacao a ser executada)</param>
        private void InvocaModuloTrackBar(Modulo modulo, 
                                                        int min, int max,
                                                        int valor, string formSlideTitulo)
        {
            FormParametroSlide form = new FormParametroSlide(min, max, valor, formSlideTitulo);
            if (form.ShowDialog() == DialogResult.OK)
            {
                //obtem a comanda do modulo
                ModuloCommand mc = ModulosFactory.Instance[modulo];
                
                //adiciona o argumento sobre o limiar
                mc[Constantes.CHAVE_ARGUMENTO_TRACK_BAR] = form.ValorSlide;

                //invoca o modulo de modificacao de imagem
                InvocaModulo(modulo);
            }
        }

        /// <summary>
        /// Invoca um módulo, modificando a imagem. Porem utiliza 
        /// o formulario com um track bar
        /// </summary>
        /// <param name="modulo">O modulo (operacao a ser executada)</param>
        private void InvocaModuloMultiTrackBar(Modulo modulo, ModeloCor cor,
                                              int min1, int max1,
                                              int min2, int max2,
                                              int min3, int max3,
                                              string formSlideTitulo)
        {
            FormParametrosSlideCores form =
                new FormParametrosSlideCores
                (cor, min1, max1, min2, max2, min3, max3, formSlideTitulo);

            if (form.ShowDialog() == DialogResult.OK)
            {
                //obtem a comanda do modulo
                ModuloCommand mc = ModulosFactory.Instance[modulo];

                
                mc[Constantes.CHAVE_PARAMETRO_1] = form.ValorParametro1;
                mc[Constantes.CHAVE_PARAMETRO_2] = form.ValorParametro2;
                mc[Constantes.CHAVE_PARAMETRO_3] = form.ValorParametro3;

                //invoca o modulo de modificacao de imagem
                InvocaModulo(modulo);
            }
        }

        /// <summary>
        /// Invoca modulo para exibir apenas banda de cor, informando 
        /// se ira exibir apenas o vermelho, o verde ou o azul
        /// </summary>
        /// <param name="banda"></param>
        private void InvocaModuloExibeBanda(BandaCorARGB banda)
        {
            Modulo modulo = Modulo.EXIBE_POR_BANDA_COR_RGB;

            //obtem a comanda do modulo
            ModuloCommand mc = ModulosFactory.Instance[modulo];

            //adiciona o argumento sobre o limiar
            mc[Constantes.CHAVE_ARGUMENTO_BANDA_COR] = banda;

            //invoca o modulo de modificacao de imagem
            InvocaModulo(modulo);
        }


        /// <summary>
        /// Invoca um módulo, modificando a imagem
        /// </summary>
        /// <param name="modulo">O modulo (operacao a ser executada)</param>
        private void InvocaModulo(Modulo modulo)
        {
            FormBarraProgresso progresso = new FormBarraProgresso();
            try
            {
                //coloque o cursor do mouse para espera
                MouseEspera();
                //exibe barra
                progresso.Show();
                //executa modulo
                ExecutaModulo(modulo, progresso);
                //configura imagem no picturebox e comando undo redo
                ConfiguraImagemAtual();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                progresso.Close();
                //Volta o cursor
                MouseRetorna();
            }
        }

        /// <summary>
        /// Invoca um módulo, modificando a imagem
        /// </summary>
        /// <param name="modulo">O modulo (operacao a ser executada)</param>
        private T InvocaModuloRetorno<T>(Modulo modulo)
        {
            T valor = default(T);
            FormBarraProgresso progresso = new FormBarraProgresso();

            try
            {
                //coloque o cursor do mouse para espera
                MouseEspera();

                //Aloca o formulário para progresso
                
                progresso.Show();
                //executa modulo
                valor = ExecutaModuloRetorno<T>(modulo, progresso);
                //configura imagem no picturebox e comando undo redo
                ConfiguraImagemAtual();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                progresso.Close();
                //Volta o cursor
                MouseRetorna();
            }

            return valor;
        }

        private void ExecutaModulo(Modulo modulo, FormBarraProgresso progresso)
        {
            //Obtem comando para executar operacao
            ModuloCommand mc = ModulosFactory.Instance[modulo];
            //executar apenas. Tal execução ja modifica a imagem a ser utilizada
            mc.Executar(progresso);
        }

        private T ExecutaModuloRetorno<T>(Modulo modulo, FormBarraProgresso progresso)
        {

            //Obtem comando para executar operacao
            ModuloCommand mc = ModulosFactory.Instance[modulo];
            //executar apenas. Tal execução ja modifica a imagem a ser utilizada
            T valor = mc.ExecutarRetorna<T>(progresso);

            return valor;
        }

        private void ConfiguraImagemAtual()
        {
            //obter imagem pos processada
            Bitmap bitmap = pool[TipoImagemPool.ATUAL].ImagemBitmap;

            //define imagem no pictureBox
            pictureBox.Image = bitmap;

            //adiciona bitmap para undo e redo
            comandoUndoRedo.Adicionar(bitmap);
            MudarVisibilidadeUndoRedo();
        }

        private void MouseRetorna()
        {
            this.Cursor = Cursors.Default;
        }

        private void MouseEspera()
        {
            this.Cursor = Cursors.WaitCursor;
        }

        /// <summary>
        /// Cria um histograma e o exibe como uma nova janela
        /// </summary>
        private void ExibirHistograma()
        {
            
            Histograma[] h = CriarHistograma();
            FormHistograma form = new FormHistograma(h);
            form.Show();
            
        }

        /// <summary>
        /// Cria um histograma da imagem atual
        /// </summary>
        /// <returns></returns>
        private Histograma[] CriarHistograma()
        {
            
            Bitmap bmp = new Bitmap(pictureBox.Image);
            this.Cursor = Cursors.WaitCursor;

            FormBarraProgresso progresso = new FormBarraProgresso();
            progresso.Show();

            ModuloCommand mc = ModulosFactory.Instance.ObtemModuloVisitor(Modulo.CRIAR_HISTOGRAMA);
            Histograma[] hist = mc.ExecutarRetorna<Histograma[]>(progresso);

            this.Cursor = Cursors.Default;
            progresso.Close();

            return hist;
            
        }

        #endregion 

        private void testandoParticionamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvocaModulo(Modulo.TESTE);
        }


        #endregion     
    }
}
