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

namespace Practica5_PerceptronIris
{
    public partial class Form1 : Form
    {
        int indice, contador;
        double w1, w2, w3, w4, umbral;
        public Form1()
        {
            InitializeComponent();
            generaTabla();
            
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            indice = comboBox1.SelectedIndex;
            if (indice == 0)
            {
                contador = 0;
                ponerSetosaVersicolor();
                borrarColumnaYcalc();
            }
            else if (indice == 1)
            {
                contador = 0;
                ponerSetosaVirginica();
                borrarColumnaYcalc();
            }
            else if (indice == 2)
            {
                contador = 0;
                ponerVersicolorVirginica();
                borrarColumnaYcalc();
            }
        }

        public void ponerSetosaVersicolor()
        {
            int i;
            string aux;
            TextReader Leer = new StreamReader("datos.txt");
            for (i = 0; i < 100; i++)
            {         
                aux = Leer.ReadLine();
                dgv1.Rows[i].Cells[0].Value = aux.Substring(0,3);
                dgv1.Rows[i].Cells[1].Value = aux.Substring(4,3);
                dgv1.Rows[i].Cells[2].Value = aux.Substring(8,3);
                dgv1.Rows[i].Cells[3].Value = aux.Substring(12,3);
                if (i < 50)
                {
                    dgv1.Rows[i].Cells[4].Value = -1;
                    dgv1.Rows[i].Cells[0].Style.BackColor = Color.LightSalmon;
                    dgv1.Rows[i].Cells[1].Style.BackColor = Color.LightSalmon;
                    dgv1.Rows[i].Cells[2].Style.BackColor = Color.LightSalmon;
                    dgv1.Rows[i].Cells[3].Style.BackColor = Color.LightSalmon;
                }
                else 
                {
                    dgv1.Rows[i].Cells[4].Value = 1;
                    dgv1.Rows[i].Cells[0].Style.BackColor = Color.LightPink;
                    dgv1.Rows[i].Cells[1].Style.BackColor = Color.LightPink;
                    dgv1.Rows[i].Cells[2].Style.BackColor = Color.LightPink;
                    dgv1.Rows[i].Cells[3].Style.BackColor = Color.LightPink;
                }
                aux = "";
            }
            Leer.Close();
        }
        public void ponerSetosaVirginica()
        {
            int i;
            string aux;
            TextReader Leer = new StreamReader("datos.txt");
            for (i = 0; i < 150; i++)
            {
                aux = Leer.ReadLine();
                if (i < 50)
                {
                    dgv1.Rows[i].Cells[4].Value = -1;
                    dgv1.Rows[i].Cells[0].Value = aux.Substring(0, 3);
                    dgv1.Rows[i].Cells[1].Value = aux.Substring(4, 3);
                    dgv1.Rows[i].Cells[2].Value = aux.Substring(8, 3);
                    dgv1.Rows[i].Cells[3].Value = aux.Substring(12, 3);

                    dgv1.Rows[i].Cells[0].Style.BackColor = Color.LightCyan;
                    dgv1.Rows[i].Cells[1].Style.BackColor = Color.LightCyan;
                    dgv1.Rows[i].Cells[2].Style.BackColor = Color.LightCyan;
                    dgv1.Rows[i].Cells[3].Style.BackColor = Color.LightCyan;
                }
                else if (i > 99)
                {
                    dgv1.Rows[i-50].Cells[4].Value = 1;
                    dgv1.Rows[i - 50].Cells[0].Value = aux.Substring(0, 3);
                    dgv1.Rows[i - 50].Cells[1].Value = aux.Substring(4, 3);
                    dgv1.Rows[i - 50].Cells[2].Value = aux.Substring(8, 3);
                    dgv1.Rows[i - 50].Cells[3].Value = aux.Substring(12, 3);

                    dgv1.Rows[i - 50].Cells[0].Style.BackColor = Color.LightGreen;
                    dgv1.Rows[i - 50].Cells[1].Style.BackColor = Color.LightGreen;
                    dgv1.Rows[i - 50].Cells[2].Style.BackColor = Color.LightGreen;
                    dgv1.Rows[i - 50].Cells[3].Style.BackColor = Color.LightGreen;
                }

                aux = "";
            }
            Leer.Close();
        }

        public void ponerVersicolorVirginica()
        {
            int i;
            string aux;
            TextReader Leer = new StreamReader("datos.txt");
            for (i = 0; i < 150; i++)
            {
                aux = Leer.ReadLine();
                if (i > 49 && i <100)
                {
                    dgv1.Rows[i-50].Cells[4].Value = -1;
                    dgv1.Rows[i - 50].Cells[0].Value = aux.Substring(0, 3);
                    dgv1.Rows[i - 50].Cells[1].Value = aux.Substring(4, 3);
                    dgv1.Rows[i - 50].Cells[2].Value = aux.Substring(8, 3);
                    dgv1.Rows[i - 50].Cells[3].Value = aux.Substring(12, 3);

                    dgv1.Rows[i - 50].Cells[0].Style.BackColor = Color.NavajoWhite;
                    dgv1.Rows[i - 50].Cells[1].Style.BackColor = Color.NavajoWhite;
                    dgv1.Rows[i - 50].Cells[2].Style.BackColor = Color.NavajoWhite;
                    dgv1.Rows[i - 50].Cells[3].Style.BackColor = Color.NavajoWhite;
                }
                else if (i > 99)
                {
                    dgv1.Rows[i - 50].Cells[4].Value = 1;
                    dgv1.Rows[i - 50].Cells[0].Value = aux.Substring(0, 3);
                    dgv1.Rows[i - 50].Cells[1].Value = aux.Substring(4, 3);
                    dgv1.Rows[i - 50].Cells[2].Value = aux.Substring(8, 3);
                    dgv1.Rows[i - 50].Cells[3].Value = aux.Substring(12, 3);

                    dgv1.Rows[i - 50].Cells[0].Style.BackColor = Color.Lavender;
                    dgv1.Rows[i - 50].Cells[1].Style.BackColor = Color.Lavender;
                    dgv1.Rows[i - 50].Cells[2].Style.BackColor = Color.Lavender;
                    dgv1.Rows[i - 50].Cells[3].Style.BackColor = Color.Lavender;
                }
                aux = "";
            }
            Leer.Close();


        }
        public void generaTabla()
        {
            int m, n;
            m = 100;
            n = 6;
            dgv1.RowCount = m;
            dgv1.ColumnCount = n;
            dgv1.Columns[0].HeaderText = "X1";
            dgv1.Columns[1].HeaderText = "X2";
            dgv1.Columns[2].HeaderText = "X3";
            dgv1.Columns[3].HeaderText = "X4";
            dgv1.Columns[4].HeaderText = "Yesp";
            dgv1.Columns[4].DefaultCellStyle.BackColor = Color.LightYellow;
            dgv1.Columns[5].HeaderText = "Ycal";
            dgv1.Columns[5].DefaultCellStyle.BackColor = Color.LightBlue;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //valores aleatorios
            w1 = 1;
            w2 = 1;
            w3 = 1;
            w4 = 1;
            umbral = 0.5;
            int i;
            
            lbx2.Items.Clear();
            primerosValores();
            do
            {
                for (i = 0; i < 100; i++)
                {
                    if (OperaAprendizaje5(dgv1.Rows[i].Cells[0].Value.ToString(), dgv1.Rows[i].Cells[1].Value.ToString(), dgv1.Rows[i].Cells[2].Value.ToString(), dgv1.Rows[i].Cells[3].Value.ToString()) == dgv1.Rows[i].Cells[4].Value.ToString())
                    {
                        //Clasificó bien          
                    }
                    else
                    {
                        //Clasificó mal
                        OperaAprendizaje6(i);
                    }
                }
                //Época terminada
                //Evalua con los valores obtenidos
            }
            while (!EvaluaEpocaActual() && !(contador > 50));

            if (contador > 50)
            {
                lbx2.Items.Add("");
                lbx2.Items.Add("");
                lbx2.Items.Add("->EPOCAS= "+contador.ToString());
                lbx2.Items.Add("->Pesos");
                lbx2.Items.Add("W1 = " + w1.ToString());
                lbx2.Items.Add("W2 = " + w2.ToString());
                lbx2.Items.Add("W3 = " + w3.ToString());
                lbx2.Items.Add("W4 = " + w4.ToString());
                lbx2.Items.Add("Umbral = " + umbral.ToString());
                MessageBox.Show("Solución NO encontrada!!!!");
            }
            else
            {
                lbx2.Items.Add("");
                lbx2.Items.Add("");
                lbx2.Items.Add("->EPOCAS= " + contador.ToString());
                lbx2.Items.Add("->Pesos");
                lbx2.Items.Add("W1 = " + w1.ToString());
                lbx2.Items.Add("W2 = " + w2.ToString());
                lbx2.Items.Add("W3 = " + w3.ToString());
                lbx2.Items.Add("W4 = " + w4.ToString());
                lbx2.Items.Add("Umbral = " + umbral.ToString());
                MessageBox.Show("Solución encontrada!!!!");
            }

        }
        public string OperaAprendizaje5(string x1, string x2, string x3, string x4)
        {
            double x1d, x2d, x3d, x4d, var;
            x1d = double.Parse(x1);
            x2d = double.Parse(x2);
            x3d = double.Parse(x3);
            x4d = double.Parse(x4);
            var = x1d * w1 + x2d * w2 + x3d * w3 + x4d * w4 + umbral;
            if (var > 0)
            {
                return "1";
            }
            else
            {
                return "-1";
            }

        }
        public void OperaAprendizaje6(int fila)
        {
            double dx, dw1, dw2, dw3, dw4, dw0, x1, x2, x3, x4;
            dx = dw1 = dw2 = dw3 = dw4 = dw0 = x1 = x2 = x3 = x4 = 0.0;
            x1 = double.Parse(dgv1.Rows[fila].Cells[0].Value.ToString());
            x2 = double.Parse(dgv1.Rows[fila].Cells[1].Value.ToString());
            x3 = double.Parse(dgv1.Rows[fila].Cells[2].Value.ToString());
            x4 = double.Parse(dgv1.Rows[fila].Cells[3].Value.ToString());
            dx = double.Parse(dgv1.Rows[fila].Cells[4].Value.ToString());
            dw1 = dx * x1;
            dw2 = dx * x2;
            dw3 = dx * x3;
            dw4 = dx * x4;
            w1 = w1 + dw1;
            w2 = w2 + dw2;
            w3 = w3 + dw3;
            w4 = w4 + dw4;
            umbral = umbral + dx;

        }
        public bool EvaluaEpocaActual()
        {
            bool flagaux = true;
            contador++;
            int i;
            lbx2.Items.Add("");
            lbx2.Items.Add("\nEpoca = " + contador.ToString());
            for (i = 0; i < 100; i++)
            {
                if (OperaAprendizaje5(dgv1.Rows[i].Cells[0].Value.ToString(), dgv1.Rows[i].Cells[1].Value.ToString(), dgv1.Rows[i].Cells[2].Value.ToString(), dgv1.Rows[i].Cells[3].Value.ToString()) == dgv1.Rows[i].Cells[4].Value.ToString())
                {
                    //Se Clasificó bien
                    dgv1.Rows[i].Cells[5].Value = OperaAprendizaje5(dgv1.Rows[i].Cells[0].Value.ToString(), dgv1.Rows[i].Cells[1].Value.ToString(), dgv1.Rows[i].Cells[2].Value.ToString(), dgv1.Rows[i].Cells[3].Value.ToString());
                }
                else
                {
                    //Se Clasificó mal
                    dgv1.Rows[i].Cells[5].Value = OperaAprendizaje5(dgv1.Rows[i].Cells[0].Value.ToString(), dgv1.Rows[i].Cells[1].Value.ToString(), dgv1.Rows[i].Cells[2].Value.ToString(), dgv1.Rows[i].Cells[3].Value.ToString());
                    flagaux = false;
                }
                lbx2.Items.Add("->Pesos");
                lbx2.Items.Add("W1 = " + w1.ToString());
                lbx2.Items.Add("W2 = " + w2.ToString());
                lbx2.Items.Add("W3 = " + w3.ToString());
                lbx2.Items.Add("W4 = " + w4.ToString());
                lbx2.Items.Add("Umbral = " + umbral.ToString());
                lbx2.Items.Add("->Entrada " + i.ToString() + "\n");
            }
            return flagaux;

        }
        public void primerosValores()
        {
                lbx2.Items.Add("->Pesos Origs.");
                lbx2.Items.Add("W1 = " + w1.ToString());
                lbx2.Items.Add("W2 = " + w2.ToString());
                lbx2.Items.Add("W3 = " + w3.ToString());
                lbx2.Items.Add("W4 = " + w4.ToString());
                lbx2.Items.Add("Umbral Orig. = " + umbral.ToString());
        }
        public void borrarColumnaYcalc()
        {
            int i;
            for (i = 0; i < 100; i++)
            {
                dgv1.Rows[i].Cells[5].Value = "";
            }
        
        }

    }
}
