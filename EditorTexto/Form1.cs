using System.Collections;
using System.Text;

namespace EditorTexto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {   
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
              openFileDialog1.Filter = "Text Files |*.txt";
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
                
            }
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            richTextBox1.SaveFile(saveFileDialog1.FileName);
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void novaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = " ";
        }

        private void desfazerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void refazerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void recortarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void colarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void selecionarTudoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void sobreOProjetoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Trabalho de AED II - Crysthian e Lucas");
        }

        private void masculinoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void validarPalavrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Carregar o dicionário de palavras
            var dicionario = File.ReadAllLines("dicionario.txt", Encoding.UTF8);

            // Transforma em tabela Hash:
            Hashtable tabela = new Hashtable();

            // Carrego a informações digitadas no programa
            string text = richTextBox1.Text.ToString();

            // Busco e valido através de tabela hash

            // Retorno o richtext sublinhando às palavras que existem no dicionário 
            richTextBox1.Text = text;

            if (richTextBox1.Text == "oi")
            {
                richTextBox1.SelectionColor = Color.Red;
            }
        }
    }
}