using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AspNetVS2017.Capitulo01.Fretes
{
    public partial class FreteForm : Form
    {
        public FreteForm()
        {
            InitializeComponent();
        }

        private void calcularButton_Click(object sender, EventArgs e)
        {
            var erros = ValidarFormulario();

            if (erros.Count == 0)
            {
                Calcular();
            }
            else
            {
                MessageBox.Show(string.Join(Environment.NewLine, erros),
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void Calcular()
        {
            var frete = 0m;
            var valor = Convert.ToDecimal(valorTextBox.Text);
            var nordeste = new List<string> { "BA", "PE", "AL", "RN", "CE" };

            switch (ufComboBox.Text)
            {
                case "SP":
                    frete = 0.2m;
                    break;
                case "RJ":
                case "ES":
                    frete = 0.3m;
                    break;
                case "MG":
                    frete = 0.35m;
                    break;
                case "AM":
                    frete = 0.6m;
                    break;
                case var uf when nordeste.Contains(uf):
                    frete = 0.5m;
                    break;
                default:
                    frete = 0.75m;
                    break;
                case null:
                    throw new NullReferenceException("Combo UF não pode ser nulo.");
                    //break;
            }

            //if (ufComboBox.Text == "SP")
            //{
            //    frete = 0.2m;
            //}
            //else if (ufComboBox.Text == "RJ")
            //{
            //    frete = 0.3m;
            //}
            //else if (ufComboBox.Text == "AM")
            //{
            //    frete = 0.6m;
            //}
            //else
            //{
            //    frete = 0.75m;
            //}

            freteTextBox.Text = frete.ToString("P2");
            totalTextBox.Text = ((1 + frete) * valor).ToString("c");
        }

        private List<string> ValidarFormulario()
        {
            var erros = new List<string>();

            if (clienteTextBox.Text == string.Empty)
            {
                erros.Add("O campo Cliente é obrigatório.");
            }

            if (string.IsNullOrEmpty(valorTextBox.Text))
            {
                erros.Add("O campo Valor é obrigatório.");
            }
            else
            {
                if (!decimal.TryParse(valorTextBox.Text, out decimal valor))
                {
                    erros.Add("O campo Valor está com formato inválido.");
                }
                else
                {
                    if (valor < 100)
                    {
                        erros.Add("Valor informado abaixo do mínimo (100).");
                    }
                }
            }

            if (ufComboBox.SelectedIndex == -1)
            {
                erros.Add("Selecione a UF.");
            }

            return erros;
        }

        private void limparButton_Click(object sender, EventArgs e)
        {
            clienteTextBox.Text = "";
            valorTextBox.Text = string.Empty;

            ufComboBox.SelectedIndex = -1;

            freteTextBox.Clear();
            totalTextBox.Text = null;
        }
    }
}
