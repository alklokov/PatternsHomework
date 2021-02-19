using System.Collections.Generic;
using System.Threading;

namespace Homework2.Multithread
{
    public class MatrixTestByThreads : MatrixTest
    {
        public MatrixTestByThreads(Settings settings) : base(settings) {}

        protected override void MakeMultiplication(int threadCount)
        {
            List<Thread> threads = new List<Thread>(threadCount);
            for (var i = 0; i < threadCount; i++)
            {
                threads.Add(new Thread(MultiplyByItems));
                threads[i].Start();
            }
            threads.ForEach(t => t.Join());
        }
    }
}
