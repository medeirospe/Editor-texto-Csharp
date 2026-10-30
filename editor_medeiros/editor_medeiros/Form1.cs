using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace editor_medeiros
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        StreamReader leitura = null;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Novo()
        {
            rtb_texto.Clear();
            rtb_texto.Focus();
        }
        private void btn_novo_Click(object sender, EventArgs e)
        {
            Novo();
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Novo();
        }

        private void Abrir()
        {
            this.openFileDialog1.Title = "Abrir Arquivo";
            openFileDialog1.InitialDirectory = @"C:\Users\User\Documents\";
            openFileDialog1.FileName = " ";
            openFileDialog1.Filter = "*.TXT|*.txt|Todos Arquivos (*.*)|*.*";

            try
            {
                if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileStream arquivo = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);

                    StreamReader sr = new StreamReader(arquivo);

                    sr.BaseStream.Seek(0, SeekOrigin.Begin);
                    this.rtb_texto.Text = "";
                    string linha = sr.ReadLine();

                    while (linha != null)
                    {
                        this.rtb_texto.Text += linha + "\n";
                        linha = sr.ReadLine();
                    }
                    sr.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Abrir: " + ex.Message, "Sistema Informa.",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_abrir_Click(object sender, EventArgs e)
        {
            Abrir();
        }
        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir();
        }

        private void Salvar()
        {
            try
            {
                if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileStream arquivo = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Write);

                    StreamWriter sw = new StreamWriter(arquivo);
                    sw.Flush();
                    sw.BaseStream.Seek(0, SeekOrigin.Begin);
                    sw.Write(this.rtb_texto.Text);
                    sw.Flush();
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Salvar: " + ex.Message, "Sistema Informa",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_salvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void Copiar()
        {
            if (rtb_texto.SelectionLength > 0)
            {
                rtb_texto.Copy();
            }
        }
        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Copiar();
        }

        private void btn_copiar_Click(object sender, EventArgs e)
        {
            Copiar();
        }

        private void Colar()
        {
            rtb_texto.Paste();
        }
        private void btn_colar_Click(object sender, EventArgs e)
        {
            Colar();
        }

        private void colarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Colar();
        }

        private void Negrito()
        {
            string nomeFonte = rtb_texto.SelectionFont.Name;
            float tamanhoFonte = rtb_texto.SelectionFont.Size;
            bool resp;
            resp = rtb_texto.SelectionFont.Bold;
            
            if (resp == false)
            {
                rtb_texto.SelectionFont = new Font(nomeFonte,
                tamanhoFonte, FontStyle.Bold);
            }
            else
            {
                rtb_texto.SelectionFont = new Font(nomeFonte,
                tamanhoFonte, FontStyle.Regular);
            }
        }

        private void btn_negrito_Click(object sender, EventArgs e)
        {
            Negrito();
        }

        private void negritoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Negrito();
        }

        private void Italico()
        {
            string nomeFonte = rtb_texto.SelectionFont.Name;
            float tamanhoFonte = rtb_texto.SelectionFont.Size;
            bool resp;
            resp = rtb_texto.SelectionFont.Italic;
            
            if (resp == false)
            {
                rtb_texto.SelectionFont = new Font(nomeFonte,
                tamanhoFonte, FontStyle.Italic);
            }
            else
            {
                rtb_texto.SelectionFont = new Font(nomeFonte,
                tamanhoFonte, FontStyle.Regular);
            }
        }

        private void itálicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Italico();
        }

        private void btn_italico_Click(object sender, EventArgs e)
        {
            Italico();
        }

        private void Sublinhar()
        {
            string nomeFonte = rtb_texto.SelectionFont.Name;
            float tamanhoFonte = rtb_texto.SelectionFont.Size;
            bool resp;
            resp = rtb_texto.SelectionFont.Underline;
            
            if (resp == false)
            {
                rtb_texto.SelectionFont = new Font(nomeFonte,
                tamanhoFonte, FontStyle.Underline);
            }
            else
            {
                rtb_texto.SelectionFont = new Font(nomeFonte,
                tamanhoFonte, FontStyle.Regular);
            }
        }

        private void btn_sublinhar_Click(object sender, EventArgs e)
        {
            Sublinhar();
        }

        private void sublinhadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sublinhar();
        }
            
        private void btn_fonte_Click_1(object sender, EventArgs e)
        {
            FontDialog fonte = new FontDialog();
            if (fonte.ShowDialog() == DialogResult.OK)
            {
                rtb_texto.Font = fonte.Font;
            }
        }

        private void Esquerda()
        {
            rtb_texto.SelectionAlignment = HorizontalAlignment.Left;
        }
        private void esquerdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Esquerda();
        }

        private void btn_esquerda_Click(object sender, EventArgs e)
        {
            Esquerda();
        }

        private void Centralizar()
        {
            rtb_texto.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void btn_centralizar_Click(object sender, EventArgs e)
        {
            Centralizar();
        }

        private void centralizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Centralizar();
        }

        private void Direita()
        {
            rtb_texto.SelectionAlignment = HorizontalAlignment.Right;
        }
        private void direitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Direita();
        }

        private void btn_direita_Click(object sender, EventArgs e)
        {
            Direita();
        }
    }
}
