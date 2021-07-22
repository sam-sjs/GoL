using System;

namespace GoL.Input
{
    public class ConsoleInput : IInput
    {
        public bool KeyAvailable => Console.KeyAvailable;

        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public Key ReadKey()
        {
            return Console.ReadKey(true).Key switch
            {
                ConsoleKey.UpArrow => Key.Up,
                ConsoleKey.DownArrow => Key.Down,
                ConsoleKey.LeftArrow => Key.Left,
                ConsoleKey.RightArrow => Key.Right,
                ConsoleKey.Spacebar => Key.Space,
                ConsoleKey.Enter => Key.Enter,
                ConsoleKey.Q => Key.Quit,
                _ => Key.Invalid
            };
        }
    }
}