using Microsoft.Extensions.Configuration;
using System;

namespace Homework2.Multithread
{
    public class Settings
    {
        private const int defaultMatrixSize = 1000;
        private const int defaultMaxThreadCount = 10;
        private const MatrixTestTypes defaultTestType = MatrixTestTypes.MatrixTestByTasks;

        public int MatrixSize { get; private set; }
        public int MaxThreadCount { get; private set; }
        public MatrixTestTypes MatrixTestType { get; private set; }

        public Settings(string basePath, string file)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile(file);
            IConfiguration config = builder.Build();

            MatrixSize = int.TryParse(config[nameof(MatrixSize)], out var matrixSize) ? matrixSize : defaultMatrixSize;
            MaxThreadCount = int.TryParse(config[nameof(MaxThreadCount)], out var maxThreadCount) ? maxThreadCount : defaultMaxThreadCount;
            MatrixTestType = Enum.TryParse<MatrixTestTypes>(config[nameof(MatrixTestType)], out var testType) &&
                             Enum.IsDefined<MatrixTestTypes>(testType) ? testType : defaultTestType;
        }
    }
}
