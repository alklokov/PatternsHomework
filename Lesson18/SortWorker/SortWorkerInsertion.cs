namespace Lesson18
{
    public class SortWorkerInsertion : SortWorker
    {
        protected override ISorter CreateSorter()
            => new InsertionSorter();
    }
}
