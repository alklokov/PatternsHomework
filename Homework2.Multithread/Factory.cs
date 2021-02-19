using System;

namespace Homework2.Multithread
{
    public class Factory
    {
        /// <summary>
        /// Создание матрицы указанного размера со случайными значениями элементов
        /// </summary>
        /// <param name="rows">число строк</param>
        /// <param name="cols">число столбцов</param>
        /// <returns>созданная матрица</returns>
        public static double[,] CreateRandomMatrix(int rows, int cols)
        {
            var rnd = new Random();
            var matrix = new double[rows, cols];

            for (var i = 0; i < rows; i++)
                for (var j = 0; j < cols; j++)
                    matrix[i, j] = rnd.NextDouble();
            return matrix;
        }

        public static MatrixTest CreateMatrixTest(Settings settings)
        {
            return settings.MatrixTestType switch
            {
                MatrixTestTypes.MatrixTestByTasks => new MatrixTestByTasks(settings),
                MatrixTestTypes.MatrixTestByThreads => new MatrixTestByThreads(settings),
                _ => throw new ArgumentOutOfRangeException(),
            };
        }
    }
}