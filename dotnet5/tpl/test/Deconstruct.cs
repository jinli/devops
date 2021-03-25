using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class Datapoint
    {
        public DateTime Timestamp;
        public double Value;

        public Datapoint(DateTime ts, double v) => (Timestamp, Value) = (ts, v);

        public void Deconstruct(out DateTime ts, out double v)
        {
            ts = Timestamp;
            v = Value * 10;
        }
    }
}
