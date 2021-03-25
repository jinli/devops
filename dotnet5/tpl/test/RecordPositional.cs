using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.RecordPositional
{
    //public record Person
    //{
    //    public string FirstName { get; init; }
    //    public string LastName { get; init; }

    //    public Person(string first, string last) => (FirstName, LastName) = (first, last);

    //    public void Deconstruct(out string first, out string last)
    //    {
    //        first = FirstName;
    //        last = LastName;
    //    }
    //}

    public record Person(string FirstName, string LastName);
}
