using Microsoft.Extensions.Configuration;
using System;

namespace Lesson18
{
    public class Settings
    {
        private const int defaultNumberCount = 50;
        private const SortMethodEnum defaultSortMethod = SortMethodEnum.SelectionSort;

        public int NumberCount { get; private set; }
        public string SourceFile { get; private set; }
        public string ResultFile { get; private set; }
        public SortMethodEnum SortMethod { get; private set; }

        public Settings(string basePath, string file)
        {
            IConfiguration config = new ConfigurationBuilder()
                                        .SetBasePath(basePath)
                                        .AddJsonFile(file)
                                        .Build();

            NumberCount = int.TryParse(config[nameof(NumberCount)], out var numberCount) ? numberCount : defaultNumberCount;
            SourceFile = config[nameof(SourceFile)];
            ResultFile = config[nameof(ResultFile)];
            SortMethod = Enum.TryParse<SortMethodEnum>(config[nameof(SortMethod)], out var sortMethod) &&
                         Enum.IsDefined(sortMethod) ? sortMethod : defaultSortMethod;
        }
    }
}
