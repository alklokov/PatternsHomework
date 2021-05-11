using System;

namespace Lesson27
{
    abstract class ParserBase : IParser
    {
        private IParser next = null;
        protected string parserExt;

        public void SetNext(IParser next)
            => this.next = next;

        public virtual void ParseFile(string fileName)
            => next?.ParseFile(fileName);

        protected void PrintTitle(string fileName)
            => TextPrinter.WriteLine($"обработчик {parserExt.ToUpper()} получил файл {fileName}");

        protected void PrintText(string text)
            => TextPrinter.WriteLine(text + "\n\n");
    }
}
