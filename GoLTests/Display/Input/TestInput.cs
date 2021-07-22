using System.Collections.Generic;
using GoL.Input;

namespace GoLTests.Input
{
    public class TestInput : IInput
    {
        private readonly List<object> _inputs;
        private int _timesCalled;

        public TestInput(List<object> inputs)
        {
            _inputs = inputs;
        }

        public bool KeyAvailable { get; } = false;

        public string ReadLine()
        {
            return (string) _inputs[_timesCalled++];
        }

        public Key ReadKey()
        {
            return (Key) _inputs[_timesCalled++];
        }
    }
}