using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work
{
    class Tool
    {
        public static string PadParagraph(string st, int num)
        {
            string[] lines = st.Split(
            new[] { "\r\n", "\r", "\n" },
            StringSplitOptions.None
            );

            string text = "";
            for (int i = 0; i < lines.Length - 1; i++)
            {
                text += lines[i].PadLeft(num + lines[i].Length) + "\n";
            }
            text += lines[lines.Length - 1].PadLeft(num + lines[lines.Length - 1].Length);
            return text;
        }
    }
}
