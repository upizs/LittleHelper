using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleHelper.Operations
{
    public class TextCompareOperations
    {

        public bool CompareTexts(IEnumerable<string> texts)
        {
            if (texts.Count() != 2)
                throw new ArgumentException();

            var firstText = texts.First();
            var secondText = texts.Last();
            return string.Equals(firstText, secondText);
        }

    }
}
