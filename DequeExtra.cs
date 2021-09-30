namespace AlgorithmsDataStructures
{
    public class DequeExtra
    {
        public static bool IsPalindrome(string inputString)
        {
            var deque = new Deque<char>();
            foreach (var character in inputString.ToCharArray())
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
