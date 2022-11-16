using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KenSan
{
    public class Sum
    {
        public double AddResult(double a, double b)
        {
            return (a + b) * a / (a - b) + b * a;
        }

    }
}
