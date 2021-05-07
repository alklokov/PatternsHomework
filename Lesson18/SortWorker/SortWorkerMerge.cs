namespace Lesson18
{
    public class SortWorkerMerge : SortWorker
    {
        protected override ISorter CreateSorter()
            => new MergeSorter();
    }
}
