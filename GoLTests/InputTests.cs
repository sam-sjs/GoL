using System;
using Xunit;
using System.Collections.Generic;

namespace GoLTests
{
    public class InputTests
    {
        [Fact]
        public void ReadLine_ReturnsExpectedString()
        {
            List<object> inputs = new List<object> { "This is a test input" };
            TestInput input = new TestInput(inputs);
            string expected = "This is a test input";
            
            string actual = input.ReadLine();
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReadKey_ReturnsExpectedKeyInfo()
        {
            List<object> inputs = new List<object>
            {
                new ConsoleKeyInfo('Q', ConsoleKey.Q, false, false, false)
            };
            TestInput input = new TestInput(inputs);
            ConsoleKeyInfo expected = new ConsoleKeyInfo('Q', ConsoleKey.Q, false, false, false);

            ConsoleKeyInfo actual = input.ReadKey();

            Assert.Equal(expected, actual);
        }
    }
}