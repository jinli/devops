using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            //// Deconstruct
            //var dp = new Datapoint(DateTime.Now, 10);
            //var (ts, v) = dp;
            //Console.WriteLine("{0}, {1}", ts, v);


            // record value comparison
            var p1 = new RecordValueComparison.Person
            {
                FirstName = "Jin",
                LastName = "Li"
            };

            var p2 = new RecordValueComparison.Person
            {
                FirstName = "Jin",
                LastName = "Li"
            };

            Console.WriteLine(p1 == p2);
            Console.WriteLine(p1.Equals(p2));

            //p1.FirstName = "Jin";

            // read only with init-only setter
            var p3 = new RecordInitOnly.Person
            {
                FirstName = "Jin",
                LastName = "Li"
            };

            // p3.FirstName = "Jin";
            Console.WriteLine(p3);


            // positional records (shortcut syntax)
            var p4 = new RecordPositional.Person("Jin", "Li");
            //p4.FirstName = "Jin";
            var (first, last) = p4;
            Console.WriteLine($"{last}, {first}");


            // with expression
            var p5 = p4 with { FirstName = "Justin" };

            Console.WriteLine(p5);
        }
    }
}
