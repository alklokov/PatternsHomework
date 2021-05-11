using System;

namespace Lesson19
{
    class Program
    {
        public const int MatrixSize = 3;

        static void Main(string[] args)
        {
            RunTest();

            Console.WriteLine("Press any key");
            Console.ReadLine();
        }

        static void RunTest()
        {
            var adapter = new MatrixAdapter(new VectorWorker());
            var m1 = adapter.StringToMatrix(FileWorker.ReadText("matrix1.txt"));
            var m2 = adapter.StringToMatrix(FileWorker.ReadText("matrix2.txt"));
            var sum = adapter.SumMatrix(m1, m2);
            FileWorker.WriteText("out.txt", $"Сумма матриц:\n{adapter.MatrixToString(sum)}");
        }
    }
}
