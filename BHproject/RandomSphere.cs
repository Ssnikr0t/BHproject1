using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using ZedGraph;
using System.Drawing;
using System.IO;

namespace BHproject
{
    class RandomSphere
    {
        Random r_teta;
        Random r_pseudophi;
        ZedGraphControl zd;


        public RandomSphere(ZedGraphControl zd)
        {
            r_teta = new Random();
            r_pseudophi = new Random();
            this.zd = zd;
            
        }

        public double[,] RandomizeForSphere(int N)
        {
       /*     GraphPane gr = zd.GraphPane;
            gr.CurveList.Clear();
            gr.Title.Text = "Random Sphere";

            PointPairList list = new PointPairList();
            JimRandom rnd = new JimRandom();*/
            //StreamWriter wr = new StreamWriter("E:\\testrand.txt");

            double[,] arr = new double[N, 2];

            double pseudophi, teta;

            double max = Math.PI;

            for (int i = 0; i < N; i++)
            {
                // pseudophi = r_pseudophi.Next(0, Convert.ToInt16(2 * max)) + r_pseudophi.NextDouble();
                //  teta = r_pseudophi.Next(0, 90) + r_pseudophi.NextDouble();
               // pseudophi = rnd.Next(0, Convert.ToInt16(2 * max)) + rnd.NextDouble();
             //   teta = rnd.Next(0, 90) + rnd.NextDouble();
                //  list.Add(pseudophi, teta);

                pseudophi = CDll1.Rand(0.0, 2.0 * max);
                teta = CDll1.Rand(0.0, 90.0);

                if (pseudophi <= max)
                {

                    if ((-1.0 * max * Math.Sin((teta * Math.PI) / 180.0)) + max <= pseudophi)
                    {

                        if (teta != 0.0)
                        {
                            double phi = 360.0 - (180.0 * (max - pseudophi)) / ((max * Math.Sin((teta * Math.PI) / 180.0)));

                            arr[i, 0] = teta;
                            arr[i, 1] = phi;
                            //list.Add(phi, teta);
                        }
                        else
                            i--;
                    }
                    else
                        i--;
                }

                else
                {
                    if ((max * Math.Sin((teta * Math.PI) / 180.0)) + max >= pseudophi)
                    {

                        if (teta != 0.0)
                        {
                            double phi = (180.0 * (-max + pseudophi)) / ((max * Math.Sin((teta * Math.PI) / 180.0)));

                            arr[i, 0] = teta;
                            arr[i, 1] = phi;
                       //    list.Add(phi, teta);

                        }
                        else
                            i--;
                    }
                    else
                        i--;

                }


            }



      /*      LineItem myCurve = gr.AddCurve("Random", list, Color.Blue, SymbolType.Diamond);
            myCurve.Line.IsVisible = true;
            myCurve.Symbol.Fill.Color = Color.Blue;
            myCurve.Symbol.Fill.Type = FillType.Solid;
            myCurve.Symbol.Size = 2;

            gr.XAxis.Title.Text = "Phi";            
            gr.XAxis.Scale.Min = 0;
           // gr.XAxis.Title.Text = "PseudoPhi";
          //  gr.XAxis.Scale.Max = 2*max;
            gr.XAxis.Scale.Max = 360;

            gr.YAxis.Scale.Min = 0;
            gr.YAxis.Scale.Max = 90;
            gr.YAxis.Title.Text = "Theta";
            zd.AxisChange();

            zd.Invalidate();*/

            /*   for (int i = 0; i < N; i++)
               {              
                wr.WriteLine(arr[i,0]);
                wr.WriteLine(arr[i, 1]);
               }
               wr.Close();*/

            return arr;

        }

      /*  public double[,] RandomizeForSphere2(int N)
        {
            // N = 600000;
            double[,] arr = new double[N, 2];

         

            double pseudophi, teta;

            double max = Math.PI * R;
           // StreamWriter wr = new StreamWriter("E:\\testrand.txt");
           // wr.WriteLine(max);
            for (int i = 0; i < N; i++)
            {
                pseudophi = r_pseudophi.Next(0, Convert.ToInt16(2.0 * max)) + r_pseudophi.NextDouble();
                teta = r_pseudophi.Next(0, 90) + r_pseudophi.NextDouble();

                if (teta < 20 && pseudophi > 0 && pseudophi < max)
            //        wr.WriteLine(teta + " " + pseudophi);

                if (pseudophi <= max)
                {
                    //y = -pi*R*sin(teta)
                    if ((-1 * max * Math.Sin((teta * Math.PI) / 180)) + max <= pseudophi)
                    {
                        //get

                        if (teta != 0)
                        {

                            double phi = (180 * (max - pseudophi)) / ((max * Math.Sin((teta * Math.PI) / 180)));
                            if (Math.Abs(phi) <= 360)
                            {
                                arr[i, 0] = teta;
                                arr[i, 1] = phi;
                            }
                            //      else
                            //       i--;
                        }
                        else
                        {
                            if (pseudophi == max)
                            {
                                arr[i, 0] = teta;
                                arr[i, 1] = r_pseudophi.Next(0, 360);
                            }
                            else
                            {
                                i--;
                            }
                        }
                    }
                    else
                    {
                        i--;
                    }
                }

                else
                {
                    //y = pi*R*sin(teta)
                    if ((max * Math.Sin((teta * Math.PI) / 180)) + max >= pseudophi)
                    {
                        //get                            

                        if (teta != 0)
                        {
                            double phi = (180 * (-max + pseudophi)) / ((max * Math.Sin((teta * Math.PI) / 180)));
                            if (Math.Abs(phi) <= 360)
                            {
                                arr[i, 0] = teta;
                                arr[i, 1] = phi;
                            }
                            //else
                            //    i--;
                        }
                        else
                        {
                            if (pseudophi == max)
                                arr[i, 1] = r_pseudophi.Next(0, 360);
                            else
                            {
                                i--;
                            }
                        }
                    }
                    else
                    {
                        i--;
                    }
                }

           
            }

           // wr.Close();

            return arr;

        }*/
    }
}
