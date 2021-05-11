using System;

namespace Lesson22
{
    class Program
    {
        static void Main(string[] args)
        {
            var operation = CreateOperation();
            operation.RunOperation();

            Console.WriteLine("Press any key");
            Console.ReadLine();
        }

        static MatrixOperationTemplate CreateOperation()
        {
            Console.WriteLine("Введите название входного файла: <input.txt>");
            string inFile = Console.ReadLine();
            inFile = string.IsNullOrEmpty(inFile) ? "input.txt" : inFile;
            
            Console.WriteLine("Введите название выходного файла: <out.txt>");
            string outFile = Console.ReadLine();
            outFile = string.IsNullOrEmpty(outFile) ? "out.txt" : outFile;

            MatrixOperationsEnum operation = MatrixOperationsEnum.Determinant;
            Console.WriteLine($"Введите тип операции <{(int)operation}>");
            foreach (var val in Enum.GetValues(typeof(MatrixOperationsEnum)))
                Console.WriteLine($"{(int)val} - {val}");
            if (Enum.TryParse(typeof(MatrixOperationsEnum), Console.ReadLine(), out var op))
                operation = (MatrixOperationsEnum)op;
            
            return MatrixOperationTemplate.CreateOperation(operation, inFile, outFile);
        }
    }
}
