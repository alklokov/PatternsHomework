using System;
using System.IO;

namespace Lesson24
{
    public class FileWriter : IWriter
    {
        private readonly string fileName;

        public FileWriter(string fileName)
        {
            this.fileName = fileName;
            File.WriteAllText(fileName, $"TEST RUN. {DateTime.Now:G}\n");
        }

        public void Write(string text)
            => File.AppendAllText(fileName, text);

        public void WriteLine(string text)
            => Write(text + Environment.NewLine);
    }
}
