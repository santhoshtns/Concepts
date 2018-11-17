using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptTests
{
    public class DashboardConfigDto
    {
        public string[] UserSelectedChartNames { get; }

        public DashboardConfigDto(string[] userSelectedChartNames)
        {
            UserSelectedChartNames = userSelectedChartNames;
        }
    }

    public class Program
    {
        enum roles
        {
            A,
            B,
            C
        }
        static void Main(string[] args)
        {
            var dto = DateTimeOffset.Now;
            var dto2 = DateTimeOffset.UtcNow;

            NullTest abc1 = null;
            bool res = abc1?.IsSelected ?? false;

            abc1 = new NullTest() { IsSelected = true };
            res = abc1?.IsSelected ?? false;

            StringOps.PerformFetchAndReplace();
            return;

            EmailTemplate o = new EmailTemplate();
            o.To.Add(new EmailContact() { Name = "ss", Email = "EE" });
            o.CC.Add(new EmailContact() { Name = "ss", Email = "EE" });
            o.BCC.Add(new EmailContact() { Name = "ss", Email = "EE" });
            o.From.Name = "ss";
            o.From.Email = "EE";
            var xml = XMLSerialization.GetXml(o);


            var values = Enum.GetNames(typeof(roles));
            foreach (var val in values)
                Console.WriteLine(val);

            Guid guid;
            PdfGenerator pdfGenerator = new PdfGenerator();
            string html = System.IO.File.ReadAllText(@"D:\Work\Samples\ConceptTests\WebConcepts\InvoiceTemp.html");
            pdfGenerator.Generate(html);
            return;


            NullTest nullTest = null;

            //if ((nullTest?.IsSelected ? true : false))
            //{
            //    Console.WriteLine("if (!(categoryBenefitSelection?.Selected ?? false))");
            //}

            //if (!((nullTest?.IsSelected != null) ? nullTest?.IsSelected : false))
            //{
            //    Console.WriteLine("if (!(categoryBenefitSelection?.Selected ?? false))");
            //}

            LinqTests.TestWhere();

            //check for null
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn() { ColumnName = "abc" });
            var dr = dt.NewRow();
            dr[0] = null;
            Console.WriteLine($"dr[0] = {dr[0]}123");
            var ind = dt.Columns.IndexOf("abc");
            ind = dt.Columns.IndexOf("");

            object abc = null;
            Console.WriteLine(dr[0].ToString());

			CrashCourse.Tests();

            //const int ab = -1;
            //Console.Write(ab.ToString());
            //List<roles> ls = new List<roles>() { roles.A };
            //Console.WriteLine(string.Join("', '", ls));
            //string s = $"'{string.Join("','", ls)}'";
            //var obj = new DashboardConfigDto(null);
            //obj.ToString();
            //Console.WriteLine(pokerChips2(new int[] { 6, 2, 4, 10, 3 }));
            //Console.WriteLine(pokerChips2(new int[] { 8, 10, 2, 5, 5 }));
            //matrixElementsSum(new int[3][] {new int[] {0, 1, 1, 2 },
            //new int[]{ 0, 5, 0, 0},
            //new int[]{2, 0, 3, 3} });

            //almostIncreasingSequence2(new int[] { 1, 2, 1, 2 });

            //allLongestStrings(new string[] { "aba", "aa", "ad", "vcd", "aba" });

            //commonCharacterCount("aabcc", s2: "adcaa");
			
			//xml Serialization
            var xmlConfig = @"<Package>
	<ID>52A7B9D2-2F41-40DC-B6CB-6EFDF2196197</ID>
	<Name>Basic</Name>
	<Benefits>
		<Benefit ID=""GTL"" OptionId=""12x"" />
		<Benefit ID=""GPA"" OptionId=""12x"" />
		<Benefit ID=""GHS"" OptionId=""Plan01EE"" />
	</Benefits>
</Package>";
            var xmlConfig2 = @"";
            var package = XMLSerialization.GetPackageObject(xmlConfig);
            //var benefit = XMLSerialization.GetBenefitObject(Constants.BenefitConfig);

        }

        static bool isLucky(int n)
        {
            char[] narr = n.ToString().ToArray();
            int sumPartA = 0;
            int sumPartB = 0;
            int len = narr.Length / 2;
            for (int i = 0; i < narr.Length; i++)
            {
                if (i < len)
                    sumPartA += (int)narr[i];
                else
                    sumPartB += (int)narr[i];
            }
            return sumPartA == sumPartB;
        }

        static int commonCharacterCount(string s1, string s2)
        {
            int commonChars = 0;
            char[] s1Array = s1.ToArray();
            for (int i = 0; i < s1Array.Length; i++)
            {
                int pos = s2.IndexOf(s1Array[i]);
                if (pos >= 0)
                {
                    s2 = s2.Remove(pos, 1);
                    commonChars++;
                }
            }
            return commonChars;
        }

        static string[] allLongestStrings(string[] inputArray)
        {
            List<string> outputs = new List<string>();
            int maxLength = 0;
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (inputArray[i].Length > maxLength)
                {
                    outputs.Clear();
                    maxLength = inputArray[i].Length;
                    outputs.Add(inputArray[i]);
                }
                else if (inputArray[i].Length == maxLength)
                {
                    outputs.Add(inputArray[i]);
                }
            }
            return outputs.ToArray();
        }

        static int matrixElementsSum(int[][] matrix)
        {
            int sum = matrix.SelectMany(item => item).Sum();
            int verLen = matrix.Length;
            int horLen = matrix[0].Length;
            for (int i = 0; i < horLen; i++)
            {
                bool foundZero = false;
                for (int j = 0; j < verLen; j++)
                {
                    if (matrix[j][i] == 0 || foundZero)
                    {
                        foundZero = true;
                        sum -= matrix[j][i];
                    }
                }
            }
            return sum;
        }

        static bool almostIncreasingSequence(int[] sequence)
        {
            var lst = sequence.ToList();
            for (int i = 0; i < sequence.Length; i++)
            {
                bool isIncreasing = true;
                lst.RemoveAt(i);

                for (int j = 0; j < lst.Count - 1; j++)
                {
                    if (lst[j] >= lst[j + 1])
                    {
                        isIncreasing = false;
                        lst.Insert(i, sequence[i]); break;
                    }
                }
                if (isIncreasing)
                {
                    return true;
                }
            }
            return false;
        }

        static bool almostIncreasingSequence2(int[] sequence)
        {
            bool foundOne = false;

            for (int i = -1, j = 0, k = 1; k < sequence.Length; k++)
            {
                bool deleteCurrent = false;

                if (sequence[j] >= sequence[k])
                {
                    if (foundOne)
                    {
                        return false;
                    }
                    foundOne = true;

                    if (k > 1 && sequence[i] >= sequence[k])
                    {
                        deleteCurrent = true;
                    }
                }

                if (!foundOne)
                {
                    i = j;
                }

                if (!deleteCurrent)
                {
                    j = k;
                }
            }

            return true;
        }

        private bool IsIncreasing(int[] sequence)
        {
            for (int j = 0; j < sequence.Length - 1; j++)
            {
                if (sequence[j] > sequence[j + 1])
                {
                    return false;
                }
            }
            return true;
        }

        public static int pokerChips2(int[] chips)
        {
            int avg = (int)chips.Average();
            int diff = 0;
            int steps = 0;
            Console.WriteLine($"Average : {chips.Average()}");
            List<int> diffAvg = chips.ToList().Select(x => x - avg).ToList();
            for (int seat = 0; seat < chips.Length; seat++)
            {
                if (chips[seat] > avg)
                {
                    diff += chips[seat] - avg;
                    chips[seat] = avg;
                }
                if (diff > 0)
                {
                    for (int seat2 = 0; seat2 < chips.Length; seat2++)
                    {
                        if (chips[seat2] < avg)
                        {
                            int adjust = avg - chips[seat2];
                            int tobeAdded = 0;
                            if (diff > adjust)
                                tobeAdded = adjust;
                            else
                                tobeAdded = diff;
                            diff -= tobeAdded;
                            chips[seat2] = chips[seat2] + tobeAdded;
                            steps++;
                        }
                        if (diff == 0)
                        {
                            break;
                        }
                    }
                }
            }
            return steps;
        }
    }
}
