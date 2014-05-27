using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using System.IO;

namespace BHproject
{
    public partial class Form1 : Form
    {
        DateTime dt;
        GraphPane gr;
        int eq;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PointPairList list = new PointPairList();
            double radvec = Convert.ToDouble(textBox2.Text);
            double point_of_view = Convert.ToDouble(textBox1.Text);
            int photon_amount = int.Parse(textBox3.Text) * 1000;

            RandomSphere random = new RandomSphere(null);//R

            double[,] arr = random.RandomizeForSphere(photon_amount);//N
           // double[,] arr = new double[photon_amount, 2];
            //   LsodarDll.Lsodar(ref radvec, ref teta, ref phi, out rteta, out rphi, out Energy, ref rcondition);
          //  ReadRand(arr);

            var theta = new double[photon_amount];
            var phi = new double[photon_amount];
            var energies = new double[photon_amount];
            var rc = new int[photon_amount];

            
            progressBar1.Minimum = 0;
            progressBar1.Maximum = photon_amount;
            progressBar1.Step = 50000;

            for (int i = 0; i < photon_amount; i++)
            {
                theta[i] = arr[i, 0];
                phi[i] = arr[i, 1];
                rc[i] = -2;
            }

         //   DateTime dt = new DateTime();
            dt = DateTime.Now;

            for (int i = 0; i < photon_amount; i += 50000)
            {
                LsodarDll.Lsodar1(ref i, ref radvec, ref photon_amount, theta, phi, energies, rc);
                progressBar1.PerformStep();
            }
        
            //DateTime dt1 = new DateTime();
            //dt1 = DateTime.Now;
            textBox4.Text = Convert.ToString(DateTime.Now - dt);
                //Dasha's part of code

            // LsodarDll.Lsodar1(ref radvec, ref photon_amount, theta, phi, energies, rc);
            List<int> Energies = new List<int>();
            List<int> N = new List<int>();

          //  int count = 0;

            for (int i = 0; i < photon_amount; i++)
            {
                if (rc[i] == 0)

                    if (theta[i] <= point_of_view + 0.2 && theta[i] >= point_of_view - 0.2)
                    {
                        Energies.Add(Convert.ToInt32(energies[i] * 100.0));
                      //  count++;
                    }

            }


            int count1;
            double max = Energies.Max();

            while (Energies.Count > 0)
            {
                eq = Energies[0];
                count1 = Energies.Count;
                Energies.RemoveAll(Equal);
                list.Add(eq, -Energies.Count + count1);
                N.Add(-Energies.Count + count1);

            }
            list.Sort();
            gr.CurveList.Clear();

            

            LineItem myCurve = gr.AddCurve("Spectr", list, Color.Red, SymbolType.Diamond);


            myCurve.Line.IsVisible = true;


            myCurve.Symbol.Fill.Color = Color.Red;


            myCurve.Symbol.Fill.Type = FillType.Solid;


            myCurve.Symbol.Size = 5;


            gr.XAxis.Scale.Min = 0;
            gr.XAxis.Scale.Max = max;


            gr.YAxis.Scale.Min = 0;
            gr.YAxis.Scale.Max = N.Max();


            zedGraphControl1.AxisChange();


            zedGraphControl1.Invalidate();

           // textBox5.Text = Convert.ToString(DateTime.Now - dt1);


       /*     //Danya's part of code
            list.Clear();
            double rteta, Energy;
            for (int i = 0; i < photon_amount; i++)
            {
                if (rc[i] == 0)
                {
                    rteta = theta[i];
                    Energy = energies[i];
                    if (rteta <= point_of_view + 1.0 && rteta >= point_of_view - 1.0)
                    {
                        int f = (int)(Energy * 1000) - 500;
                        photons[f]++;
                    }
                }
            }


            gr1.CurveList.Clear();
            for (int i = 0; i < photons.Length; i++)
            {
                if (photons[i] != 0) list.Add(i + 500, photons[i]);
            }

            LineItem myCurve1 = gr1.AddCurve("Spectr", list, Color.Blue, SymbolType.Diamond);


            myCurve1.Line.IsVisible = true;


            myCurve1.Symbol.Fill.Color = Color.Blue;


            myCurve1.Symbol.Fill.Type = FillType.Solid;


            myCurve1.Symbol.Size = 5;



            gr1.XAxis.Scale.Min = 700;
            gr1.XAxis.Scale.Max = 2000;


            gr1.YAxis.Scale.Min = 0;
            gr1.YAxis.Scale.Max = photons.Max();


            zedGraphControl3.AxisChange();

            zedGraphControl3.Invalidate();

            /*switch (rcondition)
            {
                case 0:
                    {
                        textBox4.Text = "В бесконечность";
                        break;
                    }
                case 1:
                    {
                        textBox4.Text = "В диск";
                        break;
                    }
                case 2:
                    {
                        textBox4.Text = "В дыру";
                        break;
                    }
                default:
                    break;
            }*/
            /* textBox7.Text = Convert.ToString(Energy);
             textBox5.Text = Convert.ToString(rteta);
             textBox6.Text = Convert.ToString(rphi);
            */
        }



        private void zedGraphControl1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gr = zedGraphControl1.GraphPane;
            dt = new DateTime();            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double a = CDll1.Rand(0, 10);
            textBox1.Text = Convert.ToString(a);
        }

        bool Equal(int energy)
        {
            return energy == eq;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            RandomSphere random = new RandomSphere(null);
            random.RandomizeForSphere(int.Parse(textBox3.Text) * 1000);
            MessageBox.Show("Операция записи успешно выполнена!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PointPairList list = new PointPairList();
            double radvec = Convert.ToDouble(textBox2.Text);
            double point_of_view = Convert.ToDouble(textBox1.Text);
            int photon_amount = int.Parse(textBox3.Text) * 1000;

       //     RandomSphere random = new RandomSphere(null);//R

           // double[,] arr = new double[photon_amount, 2];
          //  double[,] arr = random.RandomizeForSphere(photon_amount);//N

            //   LsodarDll.Lsodar(ref radvec, ref teta, ref phi, out rteta, out rphi, out Energy, ref rcondition);
            RandomSphere random = new RandomSphere(null);//R

            double[,] arr = random.RandomizeForSphere(photon_amount);//N

            var theta = new double[photon_amount];
            var phi = new double[photon_amount];
            var energies = new double[photon_amount];
            var rc = new int[photon_amount];

            //ReadRand(arr);

            progressBar1.Value = 0;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = photon_amount;
            progressBar1.Step = 1;

            for (int i = 0; i < photon_amount; i++)
            {
                theta[i] = arr[i, 0];
                phi[i] = arr[i, 1];
                rc[i] = -2;
            }

            //   DateTime dt = new DateTime();
               dt = DateTime.Now;

            for (int i = 0; i < photon_amount; i ++)
            {
                LsodarDll.Lsodar(ref radvec, ref theta[i], ref phi[i], out theta[i], out phi[i], out energies[i], ref rc[i]);
             //   LsodarDll.Lsodar1(ref i, ref radvec, ref photon_amount, theta, phi, energies, rc);
                progressBar1.PerformStep();
            }

            //DateTime dt1 = new DateTime();
            //dt1 = DateTime.Now;
            textBox5.Text = Convert.ToString(DateTime.Now - dt);
            //Dasha's part of code

            // LsodarDll.Lsodar1(ref radvec, ref photon_amount, theta, phi, energies, rc);
            List<int> Energies = new List<int>();
            List<int> N = new List<int>();

            //  int count = 0;

            for (int i = 0; i < photon_amount; i++)
            {
                if (rc[i] == 0)

                    if (theta[i] <= point_of_view + 0.2 && theta[i] >= point_of_view - 0.2)
                    {
                        Energies.Add(Convert.ToInt32(energies[i] * 100.0));
                        //  count++;
                    }

            }


            int count1;
            double max = Energies.Max();

            while (Energies.Count > 0)
            {
                eq = Energies[0];
                count1 = Energies.Count;
                Energies.RemoveAll(Equal);
                list.Add(eq, -Energies.Count + count1);
                N.Add(-Energies.Count + count1);

            }
            list.Sort();
            gr.CurveList.Clear();



            LineItem myCurve = gr.AddCurve("Spectr", list, Color.Red, SymbolType.Diamond);


            myCurve.Line.IsVisible = true;


            myCurve.Symbol.Fill.Color = Color.Red;


            myCurve.Symbol.Fill.Type = FillType.Solid;


            myCurve.Symbol.Size = 5;


            gr.XAxis.Scale.Min = 0;
            gr.XAxis.Scale.Max = max;


            gr.YAxis.Scale.Min = 0;
            gr.YAxis.Scale.Max = N.Max();


            zedGraphControl1.AxisChange();


            zedGraphControl1.Invalidate();
        }

        void ReadRand(double[,] arr)
        {
            StreamReader reader = new StreamReader("E:\\testrand.txt");

            int i = 0;
            byte j = 0;
            while (!reader.EndOfStream)
            {
                arr[i, j] = Convert.ToDouble(reader.ReadLine());

                if (j == 0)
                    j = 1;
                else
                {
                    i++;
                    j = 0;
                }
            }

            reader.Close();
            MessageBox.Show("Чтение завершено!");
        }
    }
}
