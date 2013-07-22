using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Runner
{
    class FizzBuzz : IRunnable
    {
        public string Run(string input)
        {
            List<string> outputLines = new List<string>();
            var lines = input.Split(Environment.NewLine.ToArray(), StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                var lineItems = line.Split(" ".ToArray(), StringSplitOptions.RemoveEmptyEntries);
                outputLines.Add(Solve(Int32.Parse(lineItems[0]), Int32.Parse(lineItems[1]), Int32.Parse(lineItems[2])));
            }

            return string.Join(Environment.NewLine, outputLines);
        }

        private string Solve(int a, int b, int n)
        {
            StringBuilder result = new StringBuilder();

            for (int i=1; i <= n; i++)
            {
                string val = "";
                val += i % a == 0 ? "F" : "";
                val += i % b == 0 ? "B" : "";
                val += string.IsNullOrEmpty(val) ? i.ToString() : "";

                 result.AppendFormat("{0} ", val);
            }

            return result.ToString().Trim();
        }
    }
}
