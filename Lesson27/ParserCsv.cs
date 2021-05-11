using System.IO;
using System.Text;

namespace Lesson27
{
    class ParserCsv : ParserBase
    {
        public ParserCsv()
        {
            parserExt = ".csv";
        }

        public override void ParseFile(string fileName)
        {
            if (Path.GetExtension(fileName).ToLower() == parserExt)
            {
                PrintTitle(fileName);
                string text = File.ReadAllText(fileName);
                PrintText(text);
                return;
            }
            base.ParseFile(fileName);
        }
    }
}

