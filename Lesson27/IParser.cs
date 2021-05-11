namespace Lesson27
{
    interface IParser
    {
        void SetNext(IParser next);
        void ParseFile(string fileName);
    }
}
