using System.Net.NetworkInformation;

namespace MinSum
{
    public class MinSum
    {
        public static int SumTwoSmallestNumbers(int[] numbers)
        {
            if (numbers == null || numbers.Length < 2)
            {
                throw new ArgumentException("Массив должен включать в себя 2 и более элентов.");
            }
            int firstMin = int.MaxValue;
            int secondMin = int.MaxValue;

            foreach (int number in numbers)
            {
                if (number < firstMin)
                {
                    secondMin = firstMin;
                    firstMin = number;
                }
                else if (number < secondMin)
                {
                    secondMin = number;
                }

            }
            var result = firstMin + secondMin;
            return result;
        }
    }
    public class Tests
    {
        public static void RunTests()
        {
            Test1();
            Test2();
            Test3();
            Test4();
            Test5();
        }

        private static void Test1()
        {
            int[] numbers = { 4, 0, 3, 19, 492, -10, 1 };
            var result = MinSum.SumTwoSmallestNumbers(numbers);
            Console.WriteLine($"Тест 1: {(result == -10 ? "Выполнено" : "Провалено")} ");
        }
        private static void Test2()
        {
            int[] numbers = { 4, 4, 4, 4, 4 };
            var result = MinSum.SumTwoSmallestNumbers(numbers);
            Console.WriteLine($"Тест 2: {(result == 8 ? "Выполнено" : "Провалено")} ");

        }
        private static void Test3()
        {
            try
            {
                var numbers = Array.Empty<int>();
                var result = MinSum.SumTwoSmallestNumbers(numbers);
                Console.WriteLine($"Тест 3: Провалено(ошибка не поймана)");
            }
            catch (ArgumentException) 
            {
                Console.WriteLine($"Тест 3: Выполнено(ошибка поймана)");
            }
        }

        private static void Test4()
        {
            var numbers = new int[1000000];
            var random = new Random();
            for ( int i = 0; i < numbers.Length; i++ )
            {
                numbers[i] = random.Next(-100, 100);
            }
            numbers[^2] = -200;
            numbers[^1] = -201;
            var result = MinSum.SumTwoSmallestNumbers(numbers);
            Console.WriteLine($"Тест 4: {(result == -401 ? "Выполнено" : "Провалено")} ");

        }
        private static void Test5()
        {
            try
            {
                int[] numbers = { 1 };
                var result = MinSum.SumTwoSmallestNumbers(numbers);
                Console.WriteLine($"Тест 5: Провалено(ошибка не поймана)");
            }
            catch (ArgumentException)
            {
                Console.WriteLine($"Тест 5: Выполнено(ошибка поймана)");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Tests.RunTests();
        }
    }
}
