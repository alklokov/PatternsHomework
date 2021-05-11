namespace Lesson19
{
    interface IVectorWorker
    {
        int[] StringToVector(string vectorString);
        string VectorToString(int[] vector);
        int[] SumVectors(int[] v1, int[] v2);
    }
}
