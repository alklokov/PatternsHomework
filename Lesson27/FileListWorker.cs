using System.IO;

namespace Lesson27
{
    class FileListWorker
    {
        private IParser parser;

        public FileListWorker(IParser parser)
            => this.parser = parser;
        
        public void ProceedFileList(string inputFileName)
        {
            foreach (var file in File.ReadLines(inputFileName))
                if (File.Exists(file))
                    parser.ParseFile(file);
        }
    }
}
