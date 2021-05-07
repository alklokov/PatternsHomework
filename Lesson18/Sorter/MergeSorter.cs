namespace Lesson18
{
    public class MergeSorter : ISorter
    {
        public void Sort(int[] array)
        {
            if (array.Length > 1)
            {
                int lLen = array.Length / 2;
                int rLen = array.Length - lLen;
                var lArr = new int[lLen];
                var rArr = new int[rLen];
                for (int i = 0; i < array.Length; i++)
                {
                    if (i < lLen)
                        lArr[i] = array[i];
                    else
                        rArr[i - lLen] = array[i];
                }
                Sort(lArr);
                Sort(rArr);
                Merge(array, lArr, rArr);
            }
        }

        void Merge(int[] merged, int[] lArr, int[] rArr)
        {
            int i = 0;
            int j = 0;
            while (i < lArr.Length || j < rArr.Length)
            {
                if (i < lArr.Length & j < rArr.Length)
                {
                    if (lArr[i] <= rArr[j])
                    {
                        merged[i + j] = lArr[i];
                        i++;
                    }
                    else
                    {
                        merged[i + j] = rArr[j];
                        j++;
                    }
                }
                else if (i < lArr.Length)
                {
                    merged[i + j] = lArr[i];
                    i++;
                }
                else if (j < rArr.Length)
                {
                    merged[i + j] = rArr[j];
                    j++;
                }
            }
        }
    }
}
