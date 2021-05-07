namespace Lesson18
{
    public class SortWorkerSelection : SortWorker
    {
        protected override ISorter CreateSorter()
            => new SelectionSorter();
    }
}
