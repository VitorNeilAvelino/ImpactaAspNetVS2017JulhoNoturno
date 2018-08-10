using System;
using System.Windows.Forms;

namespace AspNetVS2017.Capitulo01.Variaveis
{
    public partial class VariaveisForm : Form
    {
        // abaixo os campos (fields) da classe.
        private int _x = 32;
        private int _w = 45;
        private int _y = 16;
        private int _z = 32;

        public VariaveisForm()
        {
            InitializeComponent();
        }

        private void aritmeticasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // comentário - este bloco não é compilado.

            int a = 2;
            int b = 6, c = 10, d = 13;

            resultadoListBox.Items.Add("a = " + a);
            resultadoListBox.Items.Add(string.Concat("b = ", b));
            resultadoListBox.Items.Add(string.Format("c = {0}", c));
            resultadoListBox.Items.Add($"d = {d}");
            resultadoListBox.Items.Add("-------------------------------");
            resultadoListBox.Items.Add("c * d = " + (c * d));
            resultadoListBox.Items.Add("c / d = " + (c / d));
            resultadoListBox.Items.Add("d % a = " + (d % a));

            //a = a + "3";
            //a = "Vitor";
            //int a = 18;
            //int e = 12;

            //long quantidadeHabitantes = 700;
            //string nome = "Vítor";
            //var valor = 19.56846M;
            //var aprovado = true;
            //var @class = "Noturno";
            //var nascimento = new DateTime(1970, 12, 25);
            //var agora = DateTime.Now;

            //if (aprovado)
            //{

            //}
        }

        private void reduzidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var x = 5;
            //x = x - 3;
            //x -= 3;

            resultadoListBox.Items.Add("x = " + x);
            resultadoListBox.Items.Add("x -= 3 = " + (x -= 3));

        }

        private void incrementaisDecrementaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int a;

            a = 5;
            resultadoListBox.Items.Add("Exemplo de Pré-Incremental");
            resultadoListBox.Items.Add("a = " + a);
            resultadoListBox.Items.Add("2 + ++a = " + (2 + ++a));
            resultadoListBox.Items.Add("a = " + a);

            resultadoListBox.Items.Add(new string('-', 50));

            a = 5;
            resultadoListBox.Items.Add("Exemplo de Pós-Incremental");
            resultadoListBox.Items.Add("a = " + a);
            resultadoListBox.Items.Add("2 + a++ = " + (2 + a++));
            resultadoListBox.Items.Add("a = " + a);
        }

        private void booleanasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirValoresVariaveis();

            resultadoListBox.Items.Add("w <= x = " + (_w <= _x));
            resultadoListBox.Items.Add("x == z = " + (_x == _z));
            resultadoListBox.Items.Add("x != z = " + (_x != _z));

        }

        private void ExibirValoresVariaveis()
        {
            resultadoListBox.Items.Add("x = " + _x);
            resultadoListBox.Items.Add("w = " + _w);
            resultadoListBox.Items.Add("y = " + _y);
            resultadoListBox.Items.Add("z = " + _z);
        }

        private void logicasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExibirValoresVariaveis();

            resultadoListBox.Items.Add("_w <= _x || _y == 16 = " + (_w <= _x || _y == 16));
            resultadoListBox.Items.Add("_x == _z && _z != _x = " + (_x == _z && _z != _x));
            resultadoListBox.Items.Add("!(_y > _w) = " + (!(_y > _w)));
        }

        private void ternariasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ano;

            ano = 2018;
            resultadoListBox.Items.Add(string.Format("O ano {0} é bissexto? {1}.", ano, 
                ano % 4 == 0 ? "Sim" : "Não"));

            ano = 2020;
            resultadoListBox.Items.Add($"O ano {ano} é bissexto? {(DateTime.IsLeapYear(ano) ? "Sim" : "Não")}.");

            //var resposta = "";
            //if (ano % 4 == 0)
            //{
            //    resposta = "Sim";
            //}
            //else
            //{
            //    resposta = "Não'";
            //}

        }
    }
}
