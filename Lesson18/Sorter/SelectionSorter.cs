namespace Lesson18
{
    public class SelectionSorter : ISorter
    {
        public void Sort(int[] array)
        {
            int iMax;
            for (var i = array.Length - 1; i > 0; i--)
            {
                iMax = 0;
                for (var j = 1; j <= i; j++)
                    if (array[j] > array[iMax])
                        iMax = j;
                (array[iMax], array[i]) = (array[i], array[iMax]);
            }
        }
    }
}
