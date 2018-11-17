using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptTests
{
    internal static class LinqTests
    {
        private static List<string> abc = new List<string> { "11", "22", "33", "44" };
        public static void TestWhere()
        {
            var w = abc.Where(d => d == "ss");
            var ab = w.ToList();
        }
    }
}
