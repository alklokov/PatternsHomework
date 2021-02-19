using System;
using System.Diagnostics;

namespace Homework2.Multithread
{
    public abstract class MatrixTest
    {
        protected readonly Settings settings;
        private readonly double[,] A, B;
        private readonly object locker = new object();
        private double[,] C;
        private int curRow, curCol;     //текуцая вычисляемая ячейка

        public MatrixTest(Settings settings)
        {
            this.settings = settings;
            A = Factory.CreateRandomMatrix(settings.MatrixSize, settings.MatrixSize);
            B = Factory.CreateRandomMatrix(settings.MatrixSize, settings.MatrixSize);
        }

        /// <summary>
        /// Выполняем умножение с помощью различного числа потоков и замеряем время выполнения
        /// </summary>
        public void RunTest()
        {
            Console.WriteLine($"{settings.MatrixTestType} - Тестирование умножения квадратных матриц размерностью {settings.MatrixSize}\n");
            for (var threadCount = 1; threadCount <= settings.MaxThreadCount; threadCount++)
                MeasureTimeByThreadCount(threadCount);

            Console.WriteLine();
            Console.WriteLine("Тестирование завершено");
        }

        //Измеряем время выполнения для указанного количества потоков
        private void MeasureTimeByThreadCount(int threadCount)
        {
            InitMultiplyParams();
            var stopwatch = new Stopwatch();
            Console.Write($"Число потоков: {threadCount}  ");

            stopwatch.Start();
            MakeMultiplication(threadCount);
            stopwatch.Stop();

            Console.WriteLine($"Время выполнения: {stopwatch.Elapsed}");
        }

        protected abstract void MakeMultiplication(int threadCount);

        private void InitMultiplyParams()
        {
            curRow = 0;
            curCol = -1;
            C = new double[settings.MatrixSize, settings.MatrixSize];
        }

        protected void MultiplyByItems()
        {
            int row, col;
            while (true)
            {
                lock(locker)
                {
                    if (!GetNextItem()) break;
                    row = curRow;
                    col = curCol;
                }
                C[row, col] = CalculateItem(row, col);
            }
        }

        private bool GetNextItem()
        {
            if (++curCol >= settings.MatrixSize)
            {
                if (++curRow >= settings.MatrixSize)
                    return false;
                curCol = 0;
            }
            return true;
        }

        private double CalculateItem(int row, int col)
        {
            double sum = 0.0;
            for (var k = 0; k < settings.MatrixSize; k++)
                sum += A[row, k] * B[k, col];
            return sum;
        }
    }
}
