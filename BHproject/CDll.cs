using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace BHproject
{
    class CDll1
    {
        [DllImport("RandNum.dll", EntryPoint = "dRand", CallingConvention = CallingConvention.Cdecl)]
        public extern static double Rand(double left, double right);
    }
}
