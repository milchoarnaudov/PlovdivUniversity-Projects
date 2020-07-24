using System;
using System.Collections.Generic;
using System.Text;

namespace Game.InputOutput
{
    interface IReader
    {
        public char Read();
        public string ReadLine();
    }
}
