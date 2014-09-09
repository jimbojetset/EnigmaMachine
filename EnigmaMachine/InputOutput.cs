using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaMachine
{
    class InputOutput
    {
        private string _reel_OUT = "";//BDFHJLCPRTXVZNYEIWGAKMUSQO
        private string _reel_IN = "ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public InputOutput(string wiring)
        {
            _reel_OUT = wiring + wiring;
        }

        public string Translate_Input(string input , int reel_POS)
        {
            int x = _reel_IN.IndexOf(input.ToUpper()) + reel_POS - 1;
            return _reel_OUT[x].ToString();
        }

        public string Translate_Output(string input, int reel_POS)
        {
            int x = _reel_OUT.IndexOf(input.ToUpper());

            return _reel_IN[x - 1].ToString();
        }
    }
}
