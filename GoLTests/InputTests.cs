using System;
using Xunit;
using System.Collections.Generic;
using GoL;

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
                Key.Quit
            };
            TestInput input = new TestInput(inputs);
            Key expected = Key.Quit;

            Key actual = input.ReadKey();

            Assert.Equal(expected, actual);
        }
    }
}