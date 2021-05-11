namespace Lesson19
{
    interface IMatrixWorker
    {
        int[][] StringToMatrix(string str);
        string MatrixToString(int[][] matrix);
        int[][] SumMatrix(int[][] m1, int[][] m2);
    }
}
