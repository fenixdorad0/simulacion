using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BunifuProProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        } 

    

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            bunifuCustomLabel5.Text = "Secante";
            //simson
            calcularSimson.Visible = true;
            
            limA.Text = "XI-1";
            limB.Text = "XI";
            listBox1.Items.Clear();
            //valorReal.Visible = true;
            textBox5.Visible = true;
        }
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            //trapiezo
            bunifuCustomLabel5.Text = "Falsa posición";
            calcularSimson.Visible = false;
          
            limA.Text = "Xl";
            limB.Text = "XU";
            listBox1.Items.Clear();
            //valorReal.Visible = true;
            textBox5.Visible = true;
        }
      
 
      
        private void CalcularSecante(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Clear();
                Decimal plazo,abonoInteresTexbox,tasaEfectivaAnual, abonoCapital, coutaSinSeguro, valorSeguro, coutaMensualSeguro, saldo,porcentajeSeguro;
                Decimal ximenos1a, ximenos1, xi, fxi, fximenos1, ximas1, ximas1a, error = 100;
                decimal cont1 = 1;             
                abonoInteresTexbox = Convert.ToDecimal(textBox1.Text);
                tasaEfectivaAnual = Convert.ToDecimal(textBox2.Text);
                saldo = Convert.ToDecimal(textBox3.Text);
                plazo = Convert.ToDecimal(textBox4.Text);
                porcentajeSeguro = Convert.ToDecimal(textBox5.Text);
                string texto =
                    "Couta " + Convert.ToString(Decimal.Round(Convert.ToDecimal(0)) + "   " +
                    "Abono a intereses " + Convert.ToString(Decimal.Round(Convert.ToDecimal(0), 0)) + "   " +
                    "Abono a capital " + Convert.ToString(Decimal.Round(Convert.ToDecimal(0), 0)) + "   " +
                    "Couota mensusal sin seguro " + Convert.ToString(Decimal.Round(Convert.ToDecimal(saldo / plazo), 0)) + "   " +
                    "valor del seguro de vida asociado a la deuda " + Convert.ToString(Decimal.Round(Convert.ToDecimal(saldo * porcentajeSeguro), 0)) + "   " +
                    "couta mensual más seguros" + Convert.ToString(Decimal.Round(Convert.ToDecimal(0), 0)) + "   " +
                    "saldo" + Convert.ToString(Decimal.Round(Convert.ToDecimal(saldo), 0)));
                listBox1.Items.Add(texto);
                decimal saldoa = saldo;
                valorSeguro = saldoa * porcentajeSeguro;
                abonoCapital = saldoa / plazo;
                
                while ( cont1 <= plazo)
                {
                    decimal abonoInteres = saldo * abonoInteresTexbox;                    
                    coutaSinSeguro = abonoInteres + abonoCapital;
                    coutaMensualSeguro = valorSeguro + coutaSinSeguro;
                    saldo = saldo - (saldoa / plazo);
                    texto =
                     "Couta " + Convert.ToString(Decimal.Round(Convert.ToDecimal(cont1)) + "   " +
                     "Abono a intereses " + Convert.ToString(Decimal.Round(Convert.ToDecimal(abonoInteres), 2)) + "   " +
                     "Abono a capital " + Convert.ToString(Decimal.Round(Convert.ToDecimal(abonoCapital), 2)) + "   " +
                     "Couota mensusal sin seguro " + Convert.ToString(Decimal.Round(Convert.ToDecimal(coutaSinSeguro), 2)) + "   " +
                     "valor del seguro de vida asociado a la deuda " + Convert.ToString(Decimal.Round(Convert.ToDecimal(valorSeguro), 2)) + "   " +
                     "couta mensual más seguros" + Convert.ToString(Decimal.Round(Convert.ToDecimal(coutaMensualSeguro), 2)) + "   " +
                     "saldo" + Convert.ToString(Decimal.Round(Convert.ToDecimal(saldo), 2)));
                    listBox1.Items.Add(texto);
                    cont1 = cont1 + 1;
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
         
        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
         
    }
}
