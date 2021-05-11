using System;

namespace Lesson22
{
    public class MatrixDeterm : MatrixOperationTemplate
    {
        private int determ = 0;

        public MatrixDeterm(string inFile, string outFile) : base(inFile, outFile) {}

        protected override void MakeOperation()
            => determ = CalculateDeterminant(matrix1);

        protected override void WriteResultToFile()
        {
            WriteLine("Исходная матрица:");
            WriteMatrix(matrix1);
            Write($"Детерминант: {determ}");
        }

        private int CalculateDeterminant(int[,] matr)
        {
            if (matr.GetLength(0) != matr.GetLength(1))
                throw new ArgumentException("determinant can be calculated only for square matrix");

            if (matr.GetLength(0) == 2)
                return matr[0, 0] * matr[1, 1] - matr[0, 1] * matr[1, 0];

            int result = 0;
            for (var i = 0; i < matr.GetLength(0); i++)
            {
                var subMatr = GetSubMatr(matr, 1, i);
                result += (i % 2 == 1 ? 1 : -1) * matr[1, i] * CalculateDeterminant(subMatr);

            }
            return result;
        }

        // Получение матрицы без row-й строки и col-го столбца
        private int[,] GetSubMatr(int[,] matr, int row, int col)
        {
            var res = new int[matr.GetLength(0) - 1, matr.GetLength(1) - 1];
            for (var i = 0; i < res.GetLength(0); i++) 
                for (var j = 0; j < res.GetLength(1); j++) 
                    res[i, j] = matr[i + (i < row ? 0 : 1), j + (j < col ? 0 : 1)];
            return res;
        }
    }
}
