using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PDIApp.Visao.CBIR
{
    public partial class FormPrincipalCBIR : Form
    {
        public FormPrincipalCBIR()
        {
            InitializeComponent();
        }

        private void selecionarButton_Click(object sender, EventArgs e)
        {
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                diretorioRaizTextBox.Text = folderDialog.SelectedPath;
                PopularTreeView();
            }
        }

        /// <summary>
        /// Dado o nome do diretorio raiz ele gera a arvore em TreeView
        /// </summary>
        private void PopularTreeView()
        {
            imagesTreeView.Nodes.Clear();
            TreeNode node = new TreeNode(diretorioRaizTextBox.Text);
            imagesTreeView.Nodes.Add(node);
            PopularTreeView(node, diretorioRaizTextBox.Text);
        }

        private void PopularTreeView(TreeNode node, string fullPath)
        {
            try
            {
                IEnumerable<string> directories = Directory.EnumerateDirectories(fullPath);
                IEnumerable<string> files = Directory.EnumerateFiles(fullPath);

                foreach (string s in directories)
                {
                    TreeNode n = new TreeNode(s.Substring(s.LastIndexOf("\\") + 1));
                    node.Nodes.Add(n);
                    PopularTreeView(n, s);
                }

                foreach (string s2 in files)
                    node.Nodes.Add(new TreeNode(s2.Substring(s2.LastIndexOf("\\") + 1)));
            }
            catch (Exception) { }
        }


    }
}
