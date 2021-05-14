using System;
using System.Collections.Generic;
using GoL;

namespace GoLTests
{
    public class TestInput : IInput
    {
        private readonly List<object> _inputs;
        private int _timesCalled;

        public TestInput(List<object> inputs)
        {
            _inputs = inputs;
        }

        public string ReadLine()
        {
            return (string) _inputs[_timesCalled++];
        }

        public ConsoleKeyInfo ReadKey()
        {
            return (ConsoleKeyInfo) _inputs[_timesCalled++];
        }
    }
}