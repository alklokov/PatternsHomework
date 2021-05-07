using System;
using System.Text;
using System.Linq;
using System.IO;

namespace Lesson18
{
    class Program
    {
        public static Settings Settings;

        static void Main(string[] args)
        {
            Settings = new Settings(Directory.GetCurrentDirectory(), "appsettings.json");
            var configurator = new Configurator();
            configurator.PrepareArray();
            SortWorker worker = configurator.CreateSortWorker();
            worker.Run();

            Console.WriteLine("Test is done.\nPress any key...");
            Console.ReadLine();
        }
    }
}
