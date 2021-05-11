using System;
using System.IO;

namespace Lesson27
{
    static class TextPrinter
    {
        private static string fileName;

        public static void InitTextPrinter(string fileName)
        {
            TextPrinter.fileName = fileName;
            File.WriteAllText(fileName, DateTime.Now.ToString("G") + "\n\n");
        }
        
        public static void WriteLine(string text)
        {
            File.AppendAllText(fileName, text);
            File.AppendAllText(fileName, "\n");
        }
    }
}
