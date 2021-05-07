using System;
using System.IO;
using System.Linq;

namespace Lesson18
{
    public class FileWorker
    {
        private readonly Settings settings;
        private const char sep = ',';

        public FileWorker()
            => settings = Program.Settings;

        public void GenerateSourceFile()
        {
            var rnd = new Random();
            var arr = Enumerable.Range(0, settings.NumberCount).Select(i => rnd.Next(0, 1000)).ToArray();
            File.WriteAllText(settings.SourceFile, string.Join(sep, arr));
        }

        public void PrepareResultFile()
            => File.WriteAllText(settings.ResultFile, $"Array Sort. Method: {settings.SortMethod}\r\n");
        
        public int[] ReadSourceArray()
        {
            try
            {
                string str = File.ReadAllText(settings.SourceFile);
                return str.Split(sep).Select(str => int.Parse(str)).ToArray();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void WriteArray(int[] arr)
            => WriteText(string.Join(sep, arr));

        public void WriteText(string text)
            => File.AppendAllText(settings.ResultFile, text + "\r\n");
    }
}
