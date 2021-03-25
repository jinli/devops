using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.RecordInitOnly
{
    public record Person
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
    }
}
