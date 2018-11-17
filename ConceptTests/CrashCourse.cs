using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptTests
{
    public static class CrashCourse
    {
        public static void Tests()
        {
            Console.WriteLine(firstDuplicate(new int[] { 2, 1, 3, 5, 3, 2 }));
        }

        static int firstDuplicate(int[] a)
        {
            List<int> lsUniqueValues = new List<int>();
            for (int i = 0; i < a.Length; i++)
            {
                //for (int j = 0; (j < a.Length) && (i != j); j++)
                //{
                //}
                if (lsUniqueValues.Contains(a[i]))
                    return a[i];
                else
                    lsUniqueValues.Add(a[i]);
            }
            return -1;
        }

    }
}
