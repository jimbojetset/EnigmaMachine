using System;

namespace EnigmaMachine
{
    public class Rotor
    {
        private int _reel_OFFSET = 0;
        private int _reel_OFFSET_Plus1 = 1;
        private int _reel_OFFSET_Minus1 = 25;
        private int _ring_POS = 0;
        private string _reel_R = "";
        private string _reel_L = "ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private int _notch1 = 0;
        private bool notch = false;
        private bool _extraNotch = false;
        private string _id = "";

        public Rotor(string reelID, string wiring, int ringPos, int notchPos, int id = 0, bool extraNotch = false)
        {
            if (!String.IsNullOrEmpty(reelID))
                _id = reelID;
            else
                throw new Exception("Bad Reel ID");
            if (wiring.Length > 0 && wiring.Length < 27)
                _reel_R = wiring + wiring;
            else
                throw new Exception("Bad Reel Wiring");
            if (ringPos > 0 && ringPos < 27)
                _ring_POS = ringPos - 1;
            else
                throw new Exception("Bad Ring Start Position");
            if (notchPos > 0 && notchPos < 27)
                _notch1 = notchPos;
            else
                throw new Exception("Bad Reel Notch Position");
            _extraNotch = extraNotch;
        }

        public string Get_Rotor_ID { get { return _id; } }

        public int Ring_POS { get { return _ring_POS + 1; } set { _ring_POS = value - 1; } }

        public int Rotor_POS { get { return _reel_OFFSET + 1; } set { _reel_OFFSET = value - 1; } }

        public int Notch { get { return _notch1; } set { _notch1 = value; } }

        public void Rotate_FWD()
        {
            _reel_OFFSET += 1;
            if (_reel_OFFSET > 25)
                _reel_OFFSET = 0;
            if (_reel_OFFSET == _notch1 - 1)
                notch = true;
            else
                notch = false;
            if (_extraNotch && (_reel_OFFSET == _notch1 + 13 || _reel_OFFSET == _notch1 - 13))
                notch = true;
            DoReelOffset();
        }

        public void Rotate_REV()
        {
            _reel_OFFSET -= 1;
            if (_reel_OFFSET < 0)
                _reel_OFFSET = 25;
            if (_reel_OFFSET == _notch1 - 1)
                notch = true;
            else
                notch = false;
            if (_extraNotch && (_reel_OFFSET == _notch1 + 13 || _reel_OFFSET == _notch1 - 13))
                notch = true;
            DoReelOffset();
        }

        private void DoReelOffset()
        {
            _reel_OFFSET_Plus1 = _reel_OFFSET + 1;
            if (_reel_OFFSET_Plus1 > 25)
                _reel_OFFSET_Plus1 = 0;
            _reel_OFFSET_Minus1 = _reel_OFFSET - 1;
            if (_reel_OFFSET_Minus1 < 0)
                _reel_OFFSET_Minus1 = 25;
        }

        public bool Notch_Hit { get { return notch; } }

        public string Get_Reel_Letter { get { return _reel_L[_reel_OFFSET].ToString(); } }

        public string Get_Reel_Letter_plus1 { get { return _reel_L[_reel_OFFSET_Plus1].ToString(); } }

        public string Get_Reel_Letter_minus1 { get { return _reel_L[_reel_OFFSET_Minus1].ToString(); } }

        public string Get_Enc_FWD(string input)
        {
            int x = _reel_L.IndexOf(input.ToUpper()) + _reel_OFFSET - _ring_POS;
            if (x > 25)
                x = x - 26;
            if (x < 0)
                x = x + 26;
            string s = _reel_R[x].ToString();
            int y = _reel_L.IndexOf(s) - _reel_OFFSET + _ring_POS;
            if (y < 0)
                y = y + 26;
            return _reel_L[y].ToString();
        }

        public string Get_Enc_REV(string input)
        {
            int x = _reel_L.IndexOf(input.ToUpper()) + _reel_OFFSET - _ring_POS;
            if (x > 25)
                x = x - 26;
            if (x < 0)
                x = x + 26;
            string s = _reel_L[x].ToString();
            int y = _reel_R.IndexOf(s) - _reel_OFFSET + _ring_POS;
            if (y < 0)
                y = y + 26;
            return _reel_L[y].ToString();
        }
    }
}