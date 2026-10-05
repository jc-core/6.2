namespace Assignment6_2 {
    internal class NumberStack {

        private int[] slots;
        private int count;

        public int Count {
            get { return count; }
        }

        public NumberStack(int size) {

            slots = new int[size];

        }

        public bool Push(int value) {

            if (count == slots.Length)
                return false;

            slots[count] = value;
            count++;

            return true;

        }

        public bool Pop(out int value) {

            if (count == 0) {
                value = 0;
                return false;
            }

            count--;
            value = slots[count];

            return true;

        }

        public int[] TopToBottom() {

            int[] ordered = new int[count];

            for (int spot = 0; spot < count; spot++)
                ordered[spot] = slots[count - 1 - spot];

            return ordered;

        }
    }
}
