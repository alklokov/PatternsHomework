namespace Lesson18
{
    public class InsertionSorter : ISorter
    {
        public void Sort(int[] array)
        {
            int i;
            for (int j = 1; j < array.Length; j++)
            {
                i = j - 1;
                while (i >= 0 && array[i] > array[i + 1])
                {
                    (array[i], array[i + 1]) = (array[i + 1], array[i]);
                    i--;
                }
            }
        }
    }
}
