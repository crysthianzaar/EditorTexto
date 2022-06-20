using System.Collections;
using System.Text;
using System.Security.Cryptography;

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
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
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

        public int HashGerador(string valor)
        {
            MD5 md5Hasher = MD5.Create();
            var hashed = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(valor));
            var ivalue = BitConverter.ToInt32(hashed, 0);
            return ivalue;
            /*int somador = 1;
            foreach (char letra in valor)
            {
                if (letra.Equals('a'))
                {
                    somador += 1;
                }
                if (letra.Equals('b'))
                {
                    somador += 2;
                }
                if (letra.Equals('c'))
                {
                    somador += 3;
                }
                if (letra.Equals('d'))
                {
                    somador += 4;
                }
                if (letra.Equals('e'))
                {
                    somador += 5;
                }
                if (letra.Equals('f'))
                {
                    somador += 6;
                }
                if (letra.Equals('g'))
                {
                    somador += 7;
                }
                if (letra.Equals('h'))
                {
                    somador += 8;
                }
                if (letra.Equals('i'))
                {
                    somador += 9;
                }
                if (letra.Equals('o'))
                {
                    somador += 11;
                }
            }
            
            //int valorHash = valor.GetHashCode();
            int tamanhoPalavra = valor.Length;
            
            int hash =  tamanhoPalavra*somador;
            return hash; */
        }

        public static void verificaTexto(RichTextBox box, string text, Color color)
        {
            Clipboard.Clear();
            box.SelectAll();
            box.Copy();
            box.Clear();
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text + " ");
            box.SelectionColor = box.ForeColor;
            box.Paste();
        }


        private async void validarPalavrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Carregar o dicionário de palavras
            string dicionario = File.ReadAllText("dicionario.txt", Encoding.UTF8);
            string[] palavras = dicionario.Split(',');

            // Transforma em tabela Hash:
            Hashtable tabela = new Hashtable();

            foreach (var palavra in palavras)
            {
                try
                {
                    int key = HashGerador(palavra);
                    tabela.Add(key, palavra);
                }
                catch
                {

                }
            }

                // Carrego a informações digitadas no programa
                string text = richTextBox1.Text.ToString().ToLower();
                string[] richTextValues = text.Split(' ');
                IEnumerable<string> ReverseData = richTextValues.AsEnumerable().Reverse();

                richTextBox1.Clear();
            // Busco e valido através de tabela hash
            foreach (var valorAtual in ReverseData)
                {
                    int valorKey = HashGerador(valorAtual);
                    if (tabela.Contains(valorKey))
                    {
                       
                       verificaTexto(richTextBox1,valorAtual,Color.Red);
                    }
                    else
                    {
                        verificaTexto(richTextBox1, valorAtual, Color.Black);
                    }
                }
            }
        }
    }