using System;
using System.Collections.Generic;
using System.Text;

namespace Game.InputOutput
{
    interface IWriter
    {
        public void Write(string input);
        public void WriteLine(string input);
    }
}
