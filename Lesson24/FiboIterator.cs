namespace Lesson24
{
    public class FiboIterator : IIterator<int>
    {
        private int prev, cur;
        private int limit, counter;

        /// <summary>
        /// Конструктор по умолчанию - создаем итератор без ограничения количиства чисел
        /// </summary>
        public FiboIterator() : this(0) { }

        /// <summary>
        /// Создаем итератор с ограниченным количеством чисел
        /// </summary>
        /// <param name="limit">количество генерируемых чисел</param>
        public FiboIterator(int limit)
        {
            this.limit = limit > 0 ? limit : 0;
            Reset();
        }
            
        public int Current => cur;

        public bool MoveNext()
        {
            if (limit > 0 && counter >= limit)
                return false;

            counter++;
            (cur, prev) = (cur + prev, cur);
            return true;
        }

        public bool MovePrev()
        {
            if (counter <= 1)
                return false;

            counter--;
            (cur, prev) = (prev, cur - prev);
            return true;
        }

        public void Reset()
        {
            prev = 0;
            cur = 1;
            counter = 1;
        }
    }
}
