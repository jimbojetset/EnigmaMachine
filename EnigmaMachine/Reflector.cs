namespace EnigmaMachine
{
    public class Reflector
    {
        private string _reel_OUT = "";//YRUHQSLDPXNGOKMIEBFZCWVJAT
        private string _reel_IN = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private string _id = "";
        private string _name = "";

        public Reflector(string id, string name, string wiring)
        {
            _reel_OUT = wiring;
            _id = id;
            _name = name;
        }

        public string Get_Reflected(string input)
        {
            int x = _reel_OUT.IndexOf(input.ToUpper());
            return _reel_IN[x].ToString();
        }

        public string Get_Id { get { return _id; } }

        public string Get_Name { get { return _name; } }
    }
}