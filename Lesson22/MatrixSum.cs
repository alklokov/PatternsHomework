using System;

namespace Lesson22
{
    public class MatrixSum : MatrixOperationTemplate
    {
        private int[,] result = new int[MatrixSize, MatrixSize];

        public MatrixSum(string inFile, string outFile) : base(inFile, outFile) {}

        protected override void ParseData()
        {
            var lines = inputData.Split("\n");
            if (lines.Length < MatrixSize * 2)
                throw new ArgumentOutOfRangeException();
            matrix1 = LinesToMatrix(lines, 0, MatrixSize - 1);
            matrix2 = LinesToMatrix(lines, MatrixSize, MatrixSize * 2 - 1);
        }

        protected override void MakeOperation()
        {
            for (var i = 0; i < MatrixSize; i++)
                for (var j = 0; j < MatrixSize; j++)
                    result[i, j] = matrix1[i, j] + matrix2[i, j];
        }

        protected override void WriteResultToFile()
        {
            WriteLine("Исходная матрица 1:");
            WriteMatrix(matrix1);
            WriteLine("Исходная матрица 2:");
            WriteMatrix(matrix2);
            WriteLine("Сумма матриц:");
            WriteMatrix(result);
        }
    }
}
