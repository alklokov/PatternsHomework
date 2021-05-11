using System.IO;

namespace Lesson19
{
    class FileWorker
    {
        public static string ReadText(string file)
            => File.ReadAllText(file);

        public static void WriteText(string file, string text)
            => File.WriteAllText(file, text);
    }
}
