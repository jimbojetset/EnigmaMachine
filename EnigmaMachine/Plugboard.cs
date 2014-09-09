namespace EnigmaMachine
{
    public class Plugboard
    {
        private string _plug_OUT = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private string _plug_IN = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public Plugboard()
        { }

        public string Get_Output(string input)
        {
            return _plug_OUT[_plug_IN.IndexOf(input.ToUpper())].ToString();
        }

        public string Plug_Out { get { return _plug_OUT; } set { _plug_OUT = value; } }

        public string Plug_In { get { return _plug_IN; } set { _plug_IN = value; } }
    }
}