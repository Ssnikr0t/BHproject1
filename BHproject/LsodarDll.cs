using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace BHproject
{
    class LsodarDll
    {
        [DllImport("Lsodar.dll", EntryPoint = "bhquantum_", CallingConvention = CallingConvention.Cdecl)]
        public extern static void Lsodar(ref double radvec, ref double teta, ref double phi, out double rteta, out double rphi, out double Energy,  ref int rcondition);


        [DllImport("Lsodar.dll", EntryPoint = "testcallingmodule_", CallingConvention = CallingConvention.Cdecl)]
        public extern static void Lsodar1(ref int starti, ref double radvec, ref int n, [In,Out] double[] theta, [In,Out] double[] phi, [In,Out] double[] Energy , [In, Out] int[] rcondition);
        //r_0, nphoton, theta, phi, Energy, Rc
        //  public extern static void dllsub2(ref int n, [In, Out] double[] A, ref int n1, [In,Out] double[] B);
    }
}
