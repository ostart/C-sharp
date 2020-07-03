using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures6
{
    public class ASTParser
    {
        public static List<ANode> Parse(string input)
        {
            var preparedInput = AddBrackets(input);
            return GenerateTokens(preparedInput);
        }

        private static List<ANode> GenerateTokens(string preparedInput)
        {
            var result = new List<ANode>();
            var strValue = string.Empty;
            var isDigit = false;
            foreach (var letter in preparedInput)
            {
                if (Char.IsDigit(letter))
                {
                    if (!isDigit) isDigit = true;
                    strValue += letter.ToString();
                }
                else
                {
                    if (isDigit && !string.IsNullOrEmpty(strValue))
                    {
                        result.Add(new ANode { token_type = TokenType.Integer, token_value = strValue });
                        isDigit = false;
                        strValue = string.Empty;
                    }
                    if (letter == '(' || letter == ')')
                    {
                        result.Add(new ANode { token_type = TokenType.Bracket, token_value = letter.ToString() });
                    }
                    else
                    {
                        result.Add(new ANode { token_type = TokenType.Operation, token_value = letter.ToString() });
                    }
                }
            }
            return result;
        }

        private static string AddBrackets(string input)
        {
            if (IsBalancedBrackets('/', input) && IsBalancedBrackets('*', input) && IsBalancedBrackets('-', input) && IsBalancedBrackets('+', input)) return input;
            var str = input;
            if (!IsBalancedBrackets('/', str)) str = BalanceBrackets('/', str);
            if (!IsBalancedBrackets('*', str)) str = BalanceBrackets('*', str);
            if (!IsBalancedBrackets('-', str)) str = BalanceBrackets('-', str);
            if (!IsBalancedBrackets('+', str)) str = BalanceBrackets('+', str);
            return AddBrackets(str);
        }

        private static string BalanceBrackets(char sign, string str)
        {
            var result = str;
            var counter = 0;
            while(result.IndexOf(sign, counter) != -1)
            {
                var index = result.IndexOf(sign, counter);
                var beginOfLeftArg = GetBeginIndexOfLeftArg(index, result);
                result = result.Insert(beginOfLeftArg, "(");
                var endOfRightArg = GetEndIndexOfRightArg(index + 1, result);
                result = result.Insert(endOfRightArg + 1, ")");
                counter = result.IndexOf(sign, counter) + 2;
            }
            return result;
        }

        private static bool IsBalancedBrackets(char sign, string str)
        {
            var indexes = FindIndexes(sign, str);
            foreach (var index in indexes)
            {
                var endOfRightArg = GetEndIndexOfRightArg(index, str);
                var beginOfLeftArg = GetBeginIndexOfLeftArg(index, str);
                try
                {
                    if (str[beginOfLeftArg - 1] != '(' || str[endOfRightArg + 1] != ')') return false;
                }
                catch (System.Exception)
                {
                    return false;
                }   
            }
            return true;
        }

        private static int GetBeginIndexOfLeftArg(int index, string str)
        {
            var nearestIsBracket = str[index - 1] == ')';
            var bracketClosed = 1;
            var nearestIsDigit = Char.IsDigit(str[index - 1]);
            var counter = 2;
            while(index - counter >= 0)
            {
                if (nearestIsBracket && str[index - counter] == '(') return index - counter + 1;
                if (nearestIsBracket)
                {
                    if (str[index - counter] == ')') bracketClosed += 1;
                    if (str[index - counter] == '(')
                    {
                        bracketClosed -= 1;
                        if (bracketClosed == 0) return index - counter;
                    }
                }
                if (nearestIsDigit && !Char.IsDigit(str[index - counter])) return index - counter + 1;
                counter += 1;
            }
            return 0;
        }

        private static int GetEndIndexOfRightArg(int index, string str)
        {
            var nearestIsBracket = str[index + 1] == '(';
            var bracketOpened = 1;
            var nearestIsDigit = Char.IsDigit(str[index + 1]);
            var counter = 2;
            while(index + counter < str.Length)
            {
                if (nearestIsBracket)
                {
                    if (str[index + counter] == '(') bracketOpened += 1;
                    if (str[index + counter] == ')')
                    {
                        bracketOpened -= 1;
                        if (bracketOpened == 0) return index + counter;
                    }
                } 
                if (nearestIsDigit && !Char.IsDigit(str[index + counter])) return index + counter - 1;
                counter += 1;
            }
            return str.Length - 1;
        }

        private static List<int> FindIndexes(char sign, string str)
        {
            var counter = 0;
            var result = new List<int>();
            while(str.IndexOf(sign,counter) != -1)
            {
                result.Add(str.IndexOf(sign,counter));
                counter = str.IndexOf(sign,counter) + 1;
            }
            return result;
        }
    }

    public class ANode
    {
        public TokenType token_type {get;set;}
        public string token_value {get;set;}
    }

    public enum TokenType
    {
        Bracket,
        Operation,
        Integer
    }
}