using System;
using System.IO;

namespace Homework2.Multithread
{
    class Program
    {
        static void Main(string[] args)
        {
            var settings = new Settings(Directory.GetCurrentDirectory(), "appsettings.json");
            MatrixTest test = Factory.CreateMatrixTest(settings);
            test.RunTest();
            Console.ReadLine();
        }
    }
}
