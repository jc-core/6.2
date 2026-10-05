namespace Assignment6_2 {
    internal class Program {

        static NumberStack stack = new(5);

        static void Main(string[] args) {

            Console.WriteLine("Select an option:");

            while (true) {

                Console.WriteLine();
                Console.WriteLine("  1 - Push");
                Console.WriteLine("  2 - Pop");
                Console.WriteLine("  3 - Show Stack");
                Console.WriteLine("  4 - Product of Elements");
                Console.WriteLine("  x - Quit");

                var choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (choice) {
                    case '1':
                        Push();
                        break;
                    case '2':
                        Pop();
                        break;
                    case '3':
                        ShowStack();
                        break;
                    case '4':
                        ProductOfOthers();
                        break;
                    case 'x':
                        return;
                    default:
                        Console.WriteLine("That is not one of the options, please select something from the list.");
                        continue;
                }

                if (EndPrompt())
                    return;

            }

        }

        static void Push() {

            Console.WriteLine();

            int value = ReadInt("Number to push:", true);

            if (stack.Push(value))
                Console.WriteLine($"{value} was pushed onto the stack.");
            else
                Console.WriteLine("There is no room left, pop a number off first.");

        }

        static void Pop() {

            Console.WriteLine();

            if (stack.Pop(out int value))
                Console.WriteLine($"{value} was popped off the stack.");
            else
                Console.WriteLine("There is nothing to pop, push a number first.");

        }

        static void ShowStack() {

            Console.WriteLine();

            if (stack.Count == 0) {
                Console.WriteLine("Nothing is on the stack right now.");
                return;
            }

            Console.WriteLine($"Top to bottom: {string.Join(" ", stack.TopToBottom())}");

        }

        static void ProductOfOthers() {

            Console.WriteLine();
            Console.WriteLine("Each result is the product of every other number in the set.");

            int[] numbers = ReadProductNumbers();

            Console.WriteLine($"Products: {string.Join(" ", ArrayFuncs.ProductExclude(numbers))}");

        }

        static bool EndPrompt() {

            Console.WriteLine();
            Console.Write("Press enter to go back to the menu, or 'x' to quit: ");

            var choice = Console.ReadKey().KeyChar;
            Console.WriteLine();

            return choice == 'x';

        }

        static int ReadInt(string prompt, bool allowNegative) {

            while (true) {

                Console.Write(prompt);

                if (int.TryParse(Console.ReadLine(), out int value) && (value >= 0 || allowNegative))
                    return value;

                Console.WriteLine(allowNegative ? "Only whole numbers are allowed." : "Only positive whole numbers or 0 are allowed.");

            }

        }

        static int[] ReadProductNumbers() {

            while (true) {

                Console.Write("Numbers separated by spaces: ");
                string[] numInputs = (Console.ReadLine() ?? "").Split(' ', StringSplitOptions.RemoveEmptyEntries);

                List<int> parsedNums = new();

                foreach (string numInput in numInputs) {
                    if (int.TryParse(numInput, out int value) && value >= -30 && value <= 30)
                        parsedNums.Add(value);
                }

                if (parsedNums.Count >= 2 && parsedNums.Count <= 6 && parsedNums.Count == numInputs.Length)
                    return parsedNums.ToArray();

                Console.WriteLine("Need 2 to 6 whole numbers, each from -30 to 30, try again.");

            }

        }
    }
}
