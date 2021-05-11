using System.Linq;

namespace Lesson19
{
    class VectorWorker : IVectorWorker
    {
        public int[] StringToVector(string vectorString)
            => vectorString.Split(',').Select(str => int.Parse(str)).ToArray();

        public int[] SumVectors(int[] v1, int[] v2)
        {
            var res = new int[v1.Length];
            for (var i = 0; i < res.Length; i++)
                res[i] = v1[i] + v2[i];
            return res;
        }

        public string VectorToString(int[] vector)
            => string.Join(',', vector);
        
    }
}
