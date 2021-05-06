namespace Lesson24
{
    public interface IWriter
    {
        void Write(string text);

        void WriteLine(string text = "");
    }
}
