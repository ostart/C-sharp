using System;

namespace AlgorithmsDataStructures
{
    public class StackExtra
    {
        public static bool IsBalances(string str)
        {
            var stack = new Stack<char>();
            var temp = str;

            while (temp.Length > 0)
            {
                if(temp[0] == '(')
                    stack.Push(temp[0]);
                if (temp[0] == ')')
                {
                    if (stack.Size() == 0) return false;
                    stack.Pop();
                }    
                temp = temp.Substring(1);
            }

            return stack.Size() == 0;
        }

        public static int CalculatePolishNotation(string expression)
        {
            var stack1 = new Stack<string>();
            var stack2 = new Stack<int>();

            var charArray = expression.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Array.Reverse(charArray);

            foreach (var character in charArray)
            {
                stack1.Push(character);
            }

            while (stack1.Size() > 0)
            {
                var top = stack1.Pop();
                if (int.TryParse(top, out var result))
                    stack2.Push(result);
                else
                {
                    switch (top)
                    {
                        case "+":
                            var arg1 = stack2.Pop();
                            var arg2 = stack2.Pop();
                            stack2.Push(arg1+arg2);
                            break;
                        case "*":
                            var arg3 = stack2.Pop();
                            var arg4 = stack2.Pop();
                            stack2.Push(arg3 * arg4);
                            break;
                        case "=":
                            return stack2.Pop();
                    }
                }
            }

            return stack2.Pop();
        }
    }
}
