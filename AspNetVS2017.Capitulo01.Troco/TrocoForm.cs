using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AspNetVS2017.Capitulo01.Troco
{
    public partial class TrocoForm : Form
    {
        public TrocoForm()
        {
            InitializeComponent();
        }

        private void calcularButton_Click(object sender, EventArgs e)
        {
            var valorCompra = Convert.ToDecimal(valorCompraTextBox.Text);
            var valorPago = Convert.ToDecimal(valorPagoTextBox.Text);

            var troco = valorPago - valorCompra;

            //trocoTextBox.Text = Convert.ToString(troco);
            trocoTextBox.Text = troco.ToString("C", new CultureInfo("en-US"));

            //ToDo: refatorar para usar vetor e for.
            var moedas = new decimal[] { 1, 0.5m, 0.25m, 0.10m, 0.05m, 0.01m };
            //var indice = 0;

            //foreach (var moeda in moedas)
            //{
            //    //moedasListView.Items[indice++].Text = ((int)(troco / moeda)).ToString();
            //    //moedasListView.Items[moedas.ToList().IndexOf(moeda)].Text = 
            //    //    ((int)(troco / moeda)).ToString();

            //}

            for (int i = 0; i < moedas.Length; i++)
            {
                moedasListView.Items[i].Text = ((int)(troco / moedas[i])).ToString();
                troco %= moedas[i];
            }

            ////var moedas1 = Convert.ToInt32(troco / 1);
            //var moedas1 = (int)troco;
            ////troco = troco - moedas1;
            //troco = troco % 1;

            //var moedas050 = (int)(troco / 0.5M);
            //troco %= 0.5m;

            //var moedas025 = (int)(troco / 0.25M);
            //troco %= 0.25m;

            //var moedas010 = (int)(troco / 0.1M);
            //troco %= 0.1m;

            //var moedas005 = (int)(troco / 0.05M);
            //troco %= 0.05m;

            //var moedas001 = (int)(troco / 0.01M);
            //troco %= 0.01m;

            //moedasListView.Items[0].Text = moedas1.ToString();
            //moedasListView.Items[1].Text = moedas050.ToString();
            //moedasListView.Items[2].Text = moedas025.ToString();
            //moedasListView.Items[3].Text = moedas010.ToString();
            //moedasListView.Items[4].Text = moedas005.ToString();
            //moedasListView.Items[5].Text = moedas001.ToString();            
        }
    }
}
