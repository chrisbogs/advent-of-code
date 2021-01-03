using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCodeShared.Models
{
    public class CustomsForm
    {
        private List<string> answers = new List<string>();

        public int UniqueAnswers => answers.SelectMany(x => x).Distinct().Count();
        public CustomsForm()
        {
        }

        public static IEnumerable<CustomsForm> Parse(string[] lines)
        {
            var result = new List<CustomsForm>();
            CustomsForm current = new();
            foreach (var line in lines)
            {
                if (line == "")
                {
                    result.Add(current);
                    current = new();
                    continue;
                }
                current.answers.Add(line);
            }

            result.Add(current);
            return result;
        }
    }
}
