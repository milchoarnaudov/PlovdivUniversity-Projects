using System;
using System.Collections.Generic;
using System.Text;

namespace Game.InputOutput
{
    public class ConsoleIO : IIOEngine
    {
        public char Read()
        {
            return Console.ReadLine()[0];
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void Write(string input)
        {
            Console.Write(input);
        }

        public void WriteLine(string input)
        {
            Console.WriteLine(input);
        }
    }
}
