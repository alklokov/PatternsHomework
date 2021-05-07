using System;

namespace Lesson18
{
    public class Configurator
    {
        /// <summary>
        /// Подготовка файла с исходным массивом
        /// </summary>
        public void PrepareArray()
        {
            var worker = new FileWorker();
            worker.GenerateSourceFile();
        }

        public SortWorker CreateSortWorker()
        {
            switch (Program.Settings.SortMethod)
            {
                case SortMethodEnum.SelectionSort:
                    return new SortWorkerSelection();
                case SortMethodEnum.InsertionSort:
                    return new SortWorkerInsertion();
                case SortMethodEnum.MergeSort:
                    return new SortWorkerMerge();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}