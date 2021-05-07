namespace Lesson18
{
    public abstract class SortWorker
    {
        private FileWorker worker;
        private int[] array;

        protected abstract ISorter CreateSorter();  //Фабричный метод

        public void Run()
        {
            if (!PrepareOk()) return;

            worker.WriteText("Исходный массив:");
            worker.WriteArray(array);
            var sorter = CreateSorter();
            sorter.Sort(array);
            worker.WriteText("Отсортированный массив:");
            worker.WriteArray(array);
        }

        private bool PrepareOk()
        {
            worker = new FileWorker();
            worker.PrepareResultFile();
            array = worker.ReadSourceArray();
            if (array == null)
            {
                worker.WriteText("Ошибка исходного файла с массивом");
                return false;
            }
            return true;
        }
    }
}
