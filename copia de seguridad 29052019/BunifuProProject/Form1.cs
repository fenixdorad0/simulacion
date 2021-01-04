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
        private void CalcularSecante(object sender, EventArgs e)
        {            
            try
            {
                
                if (label20.Visible == false & label21.Visible == false & label22.Visible == false)
                {

                    MessageBox.Show("simulación generada correctamente");
                    dataGridView1.Rows.Clear();
                    Decimal abonoInteres, plazo, abonoInteresTexbox, tasaEfectivaAnual, abonoCapital, coutaSinSeguro, valorSeguro, coutaMensualSeguro, saldo, porcentajeSeguro;
                    Decimal countConSeguro = 0, countSinSeguro = 0, countIntereses = 0, countSeguro = 0;
                    Decimal cont1 = 1;
                    abonoInteresTexbox = Convert.ToDecimal(textBox1.Text);
                    tasaEfectivaAnual = Convert.ToDecimal(textBox2.Text);
                    if (bunifuDropdown1.selectedIndex == 1)
                    {
                        
                        saldo = Convert.ToDecimal(textBox3.Text)*(Decimal)25921.659;
                    }
                    else
                    {
                        saldo = Convert.ToDecimal(textBox3.Text);
                       
                    }
                   
                    plazo = Convert.ToDecimal(textBox4.Text);
                    porcentajeSeguro = Convert.ToDecimal(textBox5.Text);
                    insertarDatagridView(0, 0, saldo * porcentajeSeguro, 0, saldo, 0, 0);
                    Decimal saldoa = saldo;



                    abonoCapital = saldoa / plazo;
                    while (cont1 <= plazo)
                    {
                        cont1 = cont1 + 1;
                        if (cont1 > plazo)
                        {
                            valorSeguro = 0;
                            abonoInteres = saldo * abonoInteresTexbox;
                            coutaSinSeguro = abonoInteres + abonoCapital;
                            coutaMensualSeguro = coutaSinSeguro;
                            saldo = saldo - (saldoa / plazo);
                        }
                        else
                        {
                            valorSeguro = saldoa * porcentajeSeguro;
                            abonoInteres = saldo * abonoInteresTexbox;
                            coutaSinSeguro = abonoInteres + abonoCapital;
                            coutaMensualSeguro = valorSeguro + coutaSinSeguro;
                            saldo = saldo - (saldoa / plazo);
                        }
                        insertarDatagridView(abonoCapital, coutaSinSeguro, valorSeguro, coutaMensualSeguro, saldo, cont1 - 1, abonoInteres);
                        countConSeguro = countConSeguro + coutaMensualSeguro;
                        countSinSeguro = countSinSeguro + coutaSinSeguro;
                        countIntereses = countIntereses + abonoInteres;
                        countSeguro = countSeguro + valorSeguro;
                    }
                    insertarDatagridView2(countConSeguro, countSinSeguro, countIntereses, countSeguro, saldoa);
                }
                else
                {
                    MessageBox.Show("Verifique que los parametros esten bien establecidos");
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

        private void BunifuThinButton21_Click(object sender, EventArgs e)
        {
            try
            {
                chart1.Series[0].Points.Clear();
                chart2.Series[0].Points.Clear();
                chart3.Series[0].Points.Clear();
                chart4.Series[0].Points.Clear();
                MessageBox.Show("Datos generados correctamente");
                dataGridView3.Rows.Clear();
                dataGridView4.Rows.Clear();
                decimal x = 34982, a = 342, c = 5423, m = 76392, n, subTotal, residuo, residuoa, resultado;
                decimal cantidadAleatorios =Convert.ToDecimal(AleatoriosTextbox.text),
                    cont = 0;
                decimal[] aleatorios = new decimal[Convert.ToInt32(cantidadAleatorios)];
                decimal min = 0, max = 0;
                subTotal = a * x + c;
                residuo = subTotal % m;
                resultado = residuo / (m - 1);
                residuoa = residuo;
                min = resultado;
                max = resultado;
                insertardatosDatagrid3(x, a, c, m, subTotal, residuo, resultado, cont);
                aleatorios[0] = resultado;
                while (cont < cantidadAleatorios - 1)
                {
                    x = residuoa;
                    subTotal = a * x + c;
                    residuo = subTotal % m;
                    resultado = residuo / (m );
                    chart1.Series[0].Points.Add(Convert.ToDouble(resultado));
                    chart2.Series[0].Points.Add(Convert.ToDouble(resultado));
                    insertardatosDatagrid3(x, a, c, m, subTotal, residuo, resultado, cont + 1);
                    residuoa = residuo;
                    cont++;
                    aleatorios[Convert.ToInt32(cont)] = resultado;
                    mmaxmix(resultado, ref min, ref max);
                }
                label15.Text = Convert.ToString("El valor minimo es \n "+ min);
                label16.Text = Convert.ToString("El valor máximo es \n "+max);
                int cantidadRangos = Convert.ToInt32(rangosTextbox.text);
                Decimal[] rangos = new decimal[cantidadRangos];
                Decimal[] rangosIzq = new decimal[cantidadRangos];
                Decimal[] rangosDer = new decimal[cantidadRangos];          
                Decimal incrementosRango = (max - min) / (cantidadRangos);
                Decimal auxcont = 0;

                for (int i = 0; i < cantidadRangos; i++)
                {
                    if (i == 0)
                    {
                        rangos[i] = min;
                    }
                    else if (i == 1)
                    {
                        auxcont =min + incrementosRango;
                        rangos[i] = auxcont;
                    }
                    else
                    {
                        auxcont = auxcont + incrementosRango;
                        rangos[i] = auxcont;
                    }
                }
                for (int z = 0; z < cantidadRangos;)
                {
                    if (z == cantidadRangos - 1)
                    {
                        rangosIzq[z] = rangos[z];
                        rangosDer[z] = max;
                    }
                    else
                    {
                        rangosIzq[z] = rangos[z];
                        rangosDer[z] = rangos[z + 1];
                    }
                    z++;

                }

                Decimal[] contadoresRangos = new decimal[cantidadRangos];            
                for (int z = 0; z < cantidadAleatorios; z++)
                {
                    for (int y = 0; y < cantidadRangos; y++)
                    {
                        if (y == cantidadRangos - 1)
                        {
                            if (aleatorios[z] >= rangosIzq[y] & aleatorios[z] <= rangosDer[y])
                            {
                                contadoresRangos[y]++;
                            }
                        }
                        else
                        {
                            if (aleatorios[z] >= rangosIzq[y] & aleatorios[z] < rangosDer[y])
                            {
                                contadoresRangos[y]++;
                            }
                        }
                       
                    }
                }
               
                int count = 0;
                for (int y = 0; y < cantidadRangos; y++)
                {
                    dataGridView4.Rows.Add(y, rangosIzq[y], rangosDer[y], contadoresRangos[y]);
                    chart3.Series[0].Points.Add(Convert.ToDouble(contadoresRangos[y]));
                    chart4.Series[0].Points.Add(Convert.ToDouble(contadoresRangos[y]));
                    count = count + (Convert.ToInt32(contadoresRangos[y]));
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private static void mmaxmix(decimal resultado, ref decimal min, ref decimal max)
        {
            if (resultado > max)
            {
                max = resultado;
            }
            else if (resultado < min)
            {
                min = resultado;
            }
        }
        private void insertardatosDatagrid3(decimal x, decimal a, decimal c, decimal m, decimal subTotal, decimal residuo, decimal resultado, decimal cont)
        {
            dataGridView3.Rows.Add(cont,x,a,c,m,subTotal,residuo,resultado);
        }

        private void BunifuImageButton1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            TopMost = true;
        }

        private void BunifuDatepicker1_onValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime fecha = bunifuDatepicker1.Value;
                int años = System.DateTime.Now.Year - fecha.Year;
                if (años < 18)
                {
                    label21.Visible = true;
                }
                else
                {
                    label21.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
          private void insertarDatagridView2(decimal countConSeguro, decimal countSinSeguro, decimal countIntereses, decimal countSeguro, decimal saldoa)
        {
            dataGridView2.Rows.Add(
                                Decimal.Round(Convert.ToDecimal(countIntereses), 0),
                                Decimal.Round(Convert.ToDecimal(saldoa), 0),
                                Decimal.Round(Convert.ToDecimal(countSinSeguro), 0),
                                Decimal.Round(Convert.ToDecimal(countSeguro), 0),
                                Decimal.Round(Convert.ToDecimal(countConSeguro), 0)
                                );
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

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double prueba = Convert.ToDouble(textBox4.Text);
                if (prueba >= 36 & prueba <= 120)
                {
                    label22.Visible = false;
                   
                }
                else
                {
                    label22.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal prueba = Convert.ToDecimal(textBox3.Text);
                if (prueba >= 1000000 & prueba <= 1300000000)
                {
                    label20.Visible = false;
                }
                else
                {
                    label20.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

     
    }
}
