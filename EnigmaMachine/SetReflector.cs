using System;
using System.Windows.Forms;

namespace EnigmaMachine
{
    public partial class SetReflector : Form
    {
        private Reflector reflectorA = new Reflector("A", "A", "EJMZALYXVBWFCRQUONTSPIKHGD");
        private Reflector reflectorB = new Reflector("B", "B", "YRUHQSLDPXNGOKMIEBFZCWVJAT");
        private Reflector reflectorC = new Reflector("C", "C", "FVPJIAOYEDRZXWGCTKUQSBNMHL");
        private Reflector reflectorD = new Reflector("b", "B(thin)", "ENKQAUYWJICOPBLMDXZVFTHRGS");
        private Reflector reflectorE = new Reflector("c", "C(thin)", "RDOBJNTKVEHMLFCWZAXGYIPSUQ");

        public SetReflector(Reflector reflector = null, bool extraRotor = false)
        {
            InitializeComponent();
            if (reflector != null)
            {
                if (reflector.Get_Id == "A")
                    checkedListBox.SetItemChecked(0, true);
                if (reflector.Get_Id == "B")
                    checkedListBox.SetItemChecked(1, true);
                if (reflector.Get_Id == "C")
                    checkedListBox.SetItemChecked(2, true);
                if (reflector.Get_Id == "b")
                    checkedListBox.SetItemChecked(3, true);
                if (reflector.Get_Id == "c")
                    checkedListBox.SetItemChecked(4, true);
            }
        }

        public Reflector GetReflector
        {
            get
            {
                if (checkedListBox.GetItemChecked(0))
                    return reflectorA;
                if (checkedListBox.GetItemChecked(1))
                    return reflectorB;
                if (checkedListBox.GetItemChecked(2))
                    return reflectorC;
                if (checkedListBox.GetItemChecked(3))
                    return reflectorD;
                if (checkedListBox.GetItemChecked(4))
                    return reflectorE;
                return null;
            }
        }

        public Reflector GetReflectorById(string id)
        {
            if (id == "A")
                return reflectorA;
            if (id == "B")
                return reflectorB;
            if (id == "C")
                return reflectorC;
            if (id == "b")
                return reflectorD;
            if (id == "c")
                return reflectorE;
            return null;
        }

        private void checkedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBox.SetItemChecked(0, false);
            checkedListBox.SetItemChecked(1, false);
            checkedListBox.SetItemChecked(2, false);
            checkedListBox.SetItemChecked(3, false);
            checkedListBox.SetItemChecked(4, false);
            checkedListBox.SetItemChecked(checkedListBox.SelectedIndex, true);
        }
    }
}