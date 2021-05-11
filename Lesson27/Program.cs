using System;

namespace Lesson27
{
    class Program
    {
        private const string testFileName = "FileList.txt";

        static void Main(string[] args)
        {
            TextPrinter.InitTextPrinter("out.txt");
            var parser = BuildTestParser();
            var worker = new FileListWorker(parser);
            worker.ProceedFileList(testFileName);

            Console.WriteLine("Program is completed");
            Console.Read();
        }

        static IParser BuildTestParser()
        {
            var parser1 = new ParserCsv();
            var parser2 = new ParserTxt();
            var parser3 = new ParserXml();
            parser2.SetNext(parser3);
            parser1.SetNext(parser2);
            return parser1;
        }


    }
}
