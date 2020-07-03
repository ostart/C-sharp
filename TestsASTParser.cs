using NUnit.Framework;
using AlgorithmsDataStructures6;
using System.Collections.Generic;

namespace Tests
{
    public class TestsASTParser
    {
        [Test]
        public void Test1ParseFunction()
        {
            var input = "7+3*5-2";
            var result = ASTParser.Parse(input);
            var ethalon = new List<ANode> 
            {
                new ANode { token_type = TokenType.Bracket, token_value = "(" },
                new ANode { token_type = TokenType.Integer, token_value = "7" },
                new ANode { token_type = TokenType.Operation, token_value = "+" },
                new ANode { token_type = TokenType.Bracket, token_value = "(" },
                new ANode { token_type = TokenType.Bracket, token_value = "(" },
                new ANode { token_type = TokenType.Integer, token_value = "3" },
                new ANode { token_type = TokenType.Operation, token_value = "*" },
                new ANode { token_type = TokenType.Integer, token_value = "5" },
                new ANode { token_type = TokenType.Bracket, token_value = ")" },
                new ANode { token_type = TokenType.Operation, token_value = "-" },
                new ANode { token_type = TokenType.Integer, token_value = "2" },
                new ANode { token_type = TokenType.Bracket, token_value = ")" },
                new ANode { token_type = TokenType.Bracket, token_value = ")" }
            };
            Assert.AreEqual(ethalon.Count, result.Count);
            for(var i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(ethalon[i].token_type, result[i].token_type);
                Assert.AreEqual(ethalon[i].token_value, result[i].token_value);
            }
        }

        [Test]
        public void Test2ParseFunction()
        {
            var input = "7+3/25*(5-2)";
            var result = ASTParser.Parse(input);
            var ethalon = new List<ANode> 
            {
                new ANode { token_type = TokenType.Bracket, token_value = "(" },
                new ANode { token_type = TokenType.Integer, token_value = "7" },
                new ANode { token_type = TokenType.Operation, token_value = "+" },
                new ANode { token_type = TokenType.Bracket, token_value = "(" },
                new ANode { token_type = TokenType.Bracket, token_value = "(" },
                new ANode { token_type = TokenType.Integer, token_value = "3" },
                new ANode { token_type = TokenType.Operation, token_value = "/" },
                new ANode { token_type = TokenType.Integer, token_value = "25" },
                new ANode { token_type = TokenType.Bracket, token_value = ")" },
                new ANode { token_type = TokenType.Operation, token_value = "*" },
                new ANode { token_type = TokenType.Bracket, token_value = "(" },
                new ANode { token_type = TokenType.Integer, token_value = "5" },
                new ANode { token_type = TokenType.Operation, token_value = "-" },
                new ANode { token_type = TokenType.Integer, token_value = "2" },
                new ANode { token_type = TokenType.Bracket, token_value = ")" },
                new ANode { token_type = TokenType.Bracket, token_value = ")" },
                new ANode { token_type = TokenType.Bracket, token_value = ")" }
            };
            Assert.AreEqual(ethalon.Count, result.Count);
            for(var i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(ethalon[i].token_type, result[i].token_type);
                Assert.AreEqual(ethalon[i].token_value, result[i].token_value);
            }
        }
    }
}