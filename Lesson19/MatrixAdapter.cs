using System.Text;

namespace Lesson19
{
    class MatrixAdapter : IMatrixWorker
    {
        private readonly IVectorWorker vectorWorker;

        public MatrixAdapter(IVectorWorker vectorWorker)
            => this.vectorWorker = vectorWorker;

        public string MatrixToString(int[][] matrix)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < matrix.Length; i++)
                sb.Append(vectorWorker.VectorToString(matrix[i]) + "\n");
            return sb.ToString();
        }

        public int[][] SumMatrix(int[][] m1, int[][] m2)
        {
            var res = new int[m1.Length][];
            for (var i = 0; i < res.Length; i++)
                res[i] = vectorWorker.SumVectors(m1[i], m2[i]);
            return res;
        }

        public int[][] StringToMatrix(string str)
        {
            var res = new int[Program.MatrixSize][];
            var lines = str.Split('\n');
            for (var i = 0; i < Program.MatrixSize; i++)
                res[i] = vectorWorker.StringToVector(lines[i]);
            return res;
        }
    }
}
