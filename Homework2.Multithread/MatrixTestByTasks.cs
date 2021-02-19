using System.Threading.Tasks;

namespace Homework2.Multithread
{
    public class MatrixTestByTasks : MatrixTest
    {
        public MatrixTestByTasks(Settings settings) : base(settings) { }

        protected override void MakeMultiplication(int threadCount)
        {
            Task[] tasks = new Task[threadCount];
            for (var i = 0; i < threadCount; i++)
                tasks[i] = Task.Run(MultiplyByItems);
            Task.WaitAll(tasks);
        }
    }
}
