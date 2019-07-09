namespace AlgorithmsDataStructures
{
    public class DequeExtra
    {
        public static bool IsPalindrome(string str)
        {
            var deque = new Deque<char>();
            foreach (var character in str.ToCharArray())
            {
                deque.AddTail(character);
            }

            return CheckPalindrome(deque);
        }

        private static bool CheckPalindrome(Deque<char> deque)
        {
            if (deque.Size() <= 1) return true;
            return deque.RemoveFront() == deque.RemoveTail() && CheckPalindrome(deque);
        }
    }
}
