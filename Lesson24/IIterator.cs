namespace Lesson24
{
    public interface IIterator<out T>
    {
        T Current { get; }
        bool MoveNext();
        bool MovePrev();
        void Reset();
    }
}
