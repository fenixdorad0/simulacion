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
          
            //valorReal.Visible = true;
            textBox5.Visible = true;
        }
      
 
      
        private void CalcularSecante(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Clear();                
                Decimal plazo,abonoInteresTexbox,tasaEfectivaAnual, abonoCapital, coutaSinSeguro, valorSeguro, coutaMensualSeguro, saldo,porcentajeSeguro;
                decimal countConSeguro=0, countSinSeguro=0;
                Decimal ximenos1a, ximenos1, xi, fxi, fximenos1, ximas1, ximas1a, error = 100;
                decimal cont1 = 1;             
                abonoInteresTexbox = Convert.ToDecimal(textBox1.Text);
                tasaEfectivaAnual = Convert.ToDecimal(textBox2.Text);
                saldo = Convert.ToDecimal(textBox3.Text);
                plazo = Convert.ToDecimal(textBox4.Text);
                porcentajeSeguro = Convert.ToDecimal(textBox5.Text);
                insertarDatagridView(0, 0, saldo * porcentajeSeguro, 0, saldo,0,0);                          
                decimal saldoa = saldo;
                valorSeguro = saldoa * porcentajeSeguro;
                abonoCapital = saldoa / plazo;                
                while ( cont1 <= plazo)
                {
                    decimal abonoInteres = saldo * abonoInteresTexbox;
                    coutaSinSeguro = abonoInteres + abonoCapital;
                    coutaMensualSeguro = valorSeguro + coutaSinSeguro;
                    saldo = saldo - (saldoa / plazo);
                    cont1 = cont1 + 1;
                    if (cont1 > plazo )
                    {
                        insertarDatagridView(abonoCapital, coutaSinSeguro, 0, coutaSinSeguro, saldo, cont1-1, abonoInteres);
                    }
                    else
                    {
                        insertarDatagridView(abonoCapital, coutaSinSeguro, valorSeguro, coutaMensualSeguro, saldo, cont1-1, abonoInteres);
                    }
                    
                    
                    countConSeguro = countConSeguro + coutaMensualSeguro;
                    countSinSeguro = countSinSeguro + coutaSinSeguro;

                }
                MessageBox.Show(
                    "pago total sin seguro: "+
                    Decimal.Round(Convert.ToDecimal(countSinSeguro), 2)+
                    "pago total con seguro: " +
                    Decimal.Round(Convert.ToDecimal(countConSeguro), 2)
                    );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void insertarDatagridView(decimal abonoCapital, decimal coutaSinSeguro, decimal valorSeguro, decimal coutaMensualSeguro, decimal saldo, decimal cont1, decimal abonoInteres)
        {
            dataGridView1.Rows.Add(
                                    Decimal.Round(Convert.ToDecimal(cont1)),
                                    Decimal.Round(Convert.ToDecimal(abonoInteres), 2),
                                    Decimal.Round(Convert.ToDecimal(abonoCapital), 2),
                                    Decimal.Round(Convert.ToDecimal(coutaSinSeguro), 2),
                                    Decimal.Round(Convert.ToDecimal(valorSeguro), 2),
                                    Decimal.Round(Convert.ToDecimal(coutaMensualSeguro), 2),
                                    Decimal.Round(Convert.ToDecimal(saldo), 2));
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
