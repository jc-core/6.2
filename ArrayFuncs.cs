namespace Assignment6_2 {
    internal class ArrayFuncs {

        public static int[] ProductExclude(int[] numbers) {

            int length = numbers.Length;
            int[] products = new int[length];

            int fromLeft = 1;
            int fromRight = 1;

            for (int front = 0; front < length; front++) {

                int back = length - 1 - front;

                if (front < back) {
                    products[front] = fromLeft;
                    products[back] = fromRight;
                }
                else if (front == back) {
                    products[front] = fromLeft * fromRight;
                }
                else {
                    products[front] *= fromLeft;
                    products[back] *= fromRight;
                }

                fromLeft *= numbers[front];
                fromRight *= numbers[back];

            }

            return products;

        }
    }
}
