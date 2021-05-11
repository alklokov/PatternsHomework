using System.IO;

namespace Lesson27
{
    class ParserXml : ParserBase
    {
        public ParserXml()
        {
            parserExt = ".xml";
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
