using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PDIApp.Util.Calculos.CBIR;
using PDIApp.Util.Flyweight;

namespace PDIApp.Visao.CBIR
{
    public partial class FormCBIRTeste : Form
    {
        #region Atributos

        ImagemPool pool;
        IDescritor descritorQuery = null;
        IDescritor descritorTeste = null;

        #endregion

        #region Construtores

        public FormCBIRTeste()
        {
            InitializeComponent();
            pool = PoolFactory.Instance.PoolImagem;
        }

        #endregion

        #region Eventos

        private void abrirConsultaButton_Click(object sender, EventArgs e)
        {
            AbrirImagemQuery();
        }

        private void abrirTesteButton_Click(object sender, EventArgs e)
        {
            AbrirImagemTeste();
        }

        #endregion

        #region Metodos

        #region Abrir Imagens

        private void AbrirImagemQuery()
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Stream stream = openFileDialog.OpenFile();
                pool[TipoImagemPool.QUERY].ImagemBitmap = new Bitmap(stream);
                stream.Close();
            }

            pictureBoxQuery.Image = pool[TipoImagemPool.QUERY].ImagemBitmap;
            descritorQuery = null;
        }

        private void AbrirImagemTeste()
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Stream stream = openFileDialog.OpenFile();
                pool[TipoImagemPool.BANCO].ImagemBitmap = new Bitmap(stream);
                stream.Close();
            }

            pictureBoxTeste.Image = pool[TipoImagemPool.BANCO].ImagemBitmap;
            descritorTeste = null;
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            if (pictureBoxQuery.Image == null)
            {
                progressBar.Value = 0;
                MessageBox.Show("Insira imagem de consulta!");
                return;
            }

            progressBar.Value++;
            if (pictureBoxTeste.Image == null)
            {
                progressBar.Value = 0;
                MessageBox.Show("Insira imagem de testes!");
                return;
            }

            progressBar.Value++;
            CalculosDescritor c = ObterCalculoDescritor();
            if (c == null)
            {
                progressBar.Value = 0;
                MessageBox.Show("Escolha um descritor válida!");
                return;
            }

            progressBar.Value++;
            IMedidaSimilaridade m = ObterMedidaSimilaridade();

            if (m == null)
            {
                progressBar.Value = 0;
                MessageBox.Show("Escolha uma medida de similaridade válida!");
                return;
            }

            try
            {
                progressBar.Value++;
                descritorQuery = c.CalculaDescritor(pool[TipoImagemPool.QUERY]);

                progressBar.Value++;
                descritorTeste = c.CalculaDescritor(pool[TipoImagemPool.BANCO]);

                progressBar.Value++;
                double d = m.CalculaSimilaridade(descritorQuery, descritorTeste);

                progressBar.Value++;
                similaridadeTextBox.Text = d.ToString();

                progressBar.Value = 0;
            }
            catch (Exception ex)
            {
                progressBar.Value = 0;
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Obtem medida de similaridade pelo combobox
        /// </summary>
        /// <returns></returns>
        private IMedidaSimilaridade ObterMedidaSimilaridade()
        {
            IMedidaSimilaridade m;
            int index = medidaComboBox.SelectedIndex;

            switch (index)
            {
                case (int)TiposMedidaSimilaridade.CORRELACAO_HISTOGRAMAS:
                    m = MedidasSimilaridadeFactory.Instance[TiposMedidaSimilaridade.CORRELACAO_HISTOGRAMAS];
                    break;

                case (int)TiposMedidaSimilaridade.DIFERENCA_DE_HISTOGRAMAS:
                    m = MedidasSimilaridadeFactory.Instance[TiposMedidaSimilaridade.DIFERENCA_DE_HISTOGRAMAS];
                    break;

                case (int)TiposMedidaSimilaridade.DISTANCIA_D1:
                    m = MedidasSimilaridadeFactory.Instance[TiposMedidaSimilaridade.DISTANCIA_D1];
                    break;

                case (int)TiposMedidaSimilaridade.DISTANCIA_DLOG:
                    m = MedidasSimilaridadeFactory.Instance[TiposMedidaSimilaridade.DISTANCIA_DLOG];
                    break;

                case (int)TiposMedidaSimilaridade.INTERSECCAO_HISTOGRAMAS:
                    m = MedidasSimilaridadeFactory.Instance[TiposMedidaSimilaridade.INTERSECCAO_HISTOGRAMAS];
                    break;

                default:
                    m = null;
                    break;
            }

            return m;
        }

        private CalculosDescritor ObterCalculoDescritor()
        {
            CalculosDescritor c;
            int index = descritorComboBox.SelectedIndex;

            switch(index)
            {
                case (int) TiposDescritores.HISTOGRAMA_COR:
                    c = DescritoresFactory.Instance[TiposDescritores.HISTOGRAMA_COR];
                    break;

                case (int) TiposDescritores.COLOR_COHERENCE_VETOR:
                    c = DescritoresFactory.Instance[TiposDescritores.COLOR_COHERENCE_VETOR];
                    break;

                case (int) TiposDescritores.LOCAL_BINARY_PATTERN:
                    c = DescritoresFactory.Instance[TiposDescritores.LOCAL_BINARY_PATTERN];
                    break;
                default:
                    c = null;
                    break;
            }

            return c;
        }

        #endregion

        private void descritorQueryButton_Click(object sender, EventArgs e)
        {
            if (descritorQuery == null)
                MessageBox.Show("O calculo ainda nao foi realizado");
            else
                MessageBox.Show(descritorQuery.ToString());
        }

        private void descritorTesteButton_Click(object sender, EventArgs e)
        {
            if (descritorTeste == null)
                MessageBox.Show("O calculo ainda nao foi realizado");
            else
                MessageBox.Show(descritorTeste.ToString());
        }

    }
}
