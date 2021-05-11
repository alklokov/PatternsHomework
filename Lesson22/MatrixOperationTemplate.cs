using System;
using System.Linq;
using System.IO;

namespace Lesson22
{
    public abstract class MatrixOperationTemplate
    {
        public const int MatrixSize = 3;
        protected const char sep = ',';

        protected string inFile;
        protected string outFile;
        protected string inputData;
        protected int[,] matrix1, matrix2;

        public static MatrixOperationTemplate CreateOperation(MatrixOperationsEnum oper, string inFile, string outFile)
        {
            return oper switch
            {
                MatrixOperationsEnum.Determinant => new MatrixDeterm(inFile, outFile),
                MatrixOperationsEnum.Transpone => new MatrixTranspon(inFile, outFile),
                MatrixOperationsEnum.Sum => new MatrixSum(inFile, outFile),
                _ => null,
            };
        }

        public MatrixOperationTemplate(string inFile, string outFile)
            => (this.inFile, this.outFile) = (inFile, outFile);

        //Шаблонный метод
        public void RunOperation()
        {
            try
            {
                inputData = ReadDataFromFile();
                ParseData();
                MakeOperation();
                InitOutput();
                WriteResultToFile();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private string ReadDataFromFile()
            => File.ReadAllText(inFile);

        private void InitOutput()
            => File.WriteAllText(outFile, "");


        protected virtual void ParseData()
        {
            var lines = inputData.Split("\n");
            if (lines.Length < MatrixSize)
                throw new ArgumentOutOfRangeException();
            matrix1 = LinesToMatrix(lines, 0, MatrixSize - 1);
        }

        protected int[,] LinesToMatrix(string[] lines, int indexFrom, int indexTo)
        {
            var matrix = new int[MatrixSize, MatrixSize];
            for (var i = indexFrom; i <= indexTo; i++)
            {
                var nums = lines[i].Split(sep).Select(str => int.Parse(str)).ToArray();
                for (var j = 0; j < MatrixSize; j++)
                    matrix[i - indexFrom, j] = nums[j];
            }
            return matrix;
        }

        protected abstract void MakeOperation();

        protected abstract void WriteResultToFile();

        protected void WriteMatrix(int[,] matr)
        {
            for (var i = 0; i < matr.GetLength(0); i++)
            {
                for (var j = 0; j < matr.GetLength(1); j++)
                    Write(matr[i, j] + " ");
                WriteLine();
            }
        }

        protected void WriteLine(string text = "")
            => Write(text + "\n");

        protected void Write(string text)
            => File.AppendAllText(outFile, text);
    }
}
