namespace Lesson22
{
    public class MatrixTranspon : MatrixOperationTemplate
    {
        private int[,] result = new int[MatrixSize, MatrixSize];

        public MatrixTranspon(string inFile, string outFile) : base(inFile, outFile) {}

        protected override void MakeOperation()
        {
            for (var i = 0; i < MatrixSize; i++)
                for (var j = 0; j < MatrixSize; j++)
                    result[i, j] = matrix1[j, i];
        }

        protected override void WriteResultToFile()
        {
            WriteLine("Исходная матрица:");
            WriteMatrix(matrix1);
            WriteLine("Транспонированная матрица:");
            WriteMatrix(result);
        }
    }
}
