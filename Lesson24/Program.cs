using System;

namespace Lesson24
{
    class Program
    {
        private const bool WriteToFile = false;
        private const string FileName = "out.txt";
        private const int NumberLimit = 10;

        static void Main(string[] args)
        {
            IIterator<int> fibo = new FiboIterator(NumberLimit);
            IWriter writer = CreateWriter();
            TestIterator(fibo, writer);
            Console.ReadLine();
        }

        private static IWriter CreateWriter()
        {
            if (WriteToFile)
                return new FileWriter(FileName);
            else
                return new ConsoleWriter();
        }

        private static void TestIterator(IIterator<int> iterator, IWriter writer)
        {
            writer.WriteLine("Проход в прямом направлении");
            do
            {
                writer.Write(iterator.Current + " ");
            } while (iterator.MoveNext());

            writer.WriteLine();
            writer.WriteLine("Проход в обратном направлении");
            do
            {
                writer.Write(iterator.Current + " ");
            } while (iterator.MovePrev());
        }

    }
}
