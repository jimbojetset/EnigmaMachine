using System;
using System.Windows.Forms;

namespace EnigmaMachine
{
    public partial class SetRotor : Form
    {
        private Rotor rotorI = new Rotor("I", "EKMFLGDQVZNTOWYHXUSPAIBRCJ", 1, 17, 0);
        private Rotor rotorII = new Rotor("II", "AJDKSIRUXBLHWTMCQGZNPYFVOE", 1, 5, 1);
        private Rotor rotorIII = new Rotor("III", "BDFHJLCPRTXVZNYEIWGAKMUSQO", 1, 22, 2);
        private Rotor rotorIV = new Rotor("IV", "ESOVPZJAYQUIRHXLNFTGKDCMWB", 1, 10, 3);
        private Rotor rotorV = new Rotor("V", "VZBRGITYUPSDNHLXAWMJQOFECK", 1, 26, 4);
        private Rotor rotorVI = new Rotor("VI", "JPGVOUMFYQBENHZRDKASXLICTW", 1, 26, 5, true);
        private Rotor rotorVII = new Rotor("VII", "NZJHGRCXMYSWBOUFAIVLPEKQDT", 1, 26, 6, true);
        private Rotor rotorVIII = new Rotor("VIII", "FKQHTLXOCBJSPDZRAMEWNIUYGV", 1, 26, 7, true);
        private Rotor rotorBeta = new Rotor("β", "LEYJVCNIXWPBQMDRTAKZGFUHOS", 1, 26, 8);
        private Rotor rotorGamma = new Rotor("γ", "FSOKANUERHMBTIYCWLQPZXVGJD", 1, 26, 9);

        public SetRotor(Rotor rotor = null, bool extraRotor = false)
        {
            InitializeComponent();
            if (extraRotor)
            {
            }
            if (rotor != null)
            {
                if (rotorI.Get_Rotor_ID == rotor.Get_Rotor_ID)
                {
                    checkedListBox.SetItemChecked(0, true);
                    checkedListBox.SetSelected(0, true);
                    rotorI.Notch = rotor.Notch;
                    rotorI.Ring_POS = rotor.Ring_POS;
                }
                if (rotorII.Get_Rotor_ID == rotor.Get_Rotor_ID)
                {
                    checkedListBox.SetItemChecked(1, true);
                    checkedListBox.SetSelected(1, true);
                    rotorII.Notch = rotor.Notch;
                    rotorII.Ring_POS = rotor.Ring_POS;
                }
                if (rotorIII.Get_Rotor_ID == rotor.Get_Rotor_ID)
                {
                    checkedListBox.SetItemChecked(2, true);
                    checkedListBox.SetSelected(2, true);
                    rotorIII.Notch = rotor.Notch;
                    rotorIII.Ring_POS = rotor.Ring_POS;
                }
                if (rotorIV.Get_Rotor_ID == rotor.Get_Rotor_ID)
                {
                    checkedListBox.SetItemChecked(3, true);
                    checkedListBox.SetSelected(3, true);
                    rotorIV.Notch = rotor.Notch;
                    rotorIV.Ring_POS = rotor.Ring_POS;
                }
                if (rotorV.Get_Rotor_ID == rotor.Get_Rotor_ID)
                {
                    checkedListBox.SetItemChecked(4, true);
                    checkedListBox.SetSelected(4, true);
                    rotorV.Notch = rotor.Notch;
                    rotorV.Ring_POS = rotor.Ring_POS;
                }
                if (rotorVI.Get_Rotor_ID == rotor.Get_Rotor_ID)
                {
                    checkedListBox.SetItemChecked(5, true);
                    checkedListBox.SetSelected(5, true);
                    rotorVI.Notch = rotor.Notch;
                    rotorVI.Ring_POS = rotor.Ring_POS;
                }
                if (rotorVII.Get_Rotor_ID == rotor.Get_Rotor_ID)
                {
                    checkedListBox.SetItemChecked(6, true);
                    checkedListBox.SetSelected(6, true);
                    rotorVII.Notch = rotor.Notch;
                    rotorVII.Ring_POS = rotor.Ring_POS;
                }
                if (rotorVIII.Get_Rotor_ID == rotor.Get_Rotor_ID)
                {
                    checkedListBox.SetItemChecked(7, true);
                    checkedListBox.SetSelected(7, true);
                    rotorVIII.Notch = rotor.Notch;
                    rotorVIII.Ring_POS = rotor.Ring_POS;
                }
                if (rotorBeta.Get_Rotor_ID == rotor.Get_Rotor_ID)
                {
                    checkedListBox.SetItemChecked(8, true);
                    checkedListBox.SetSelected(8, true);
                    rotorBeta.Notch = rotor.Notch;
                    rotorBeta.Ring_POS = rotor.Ring_POS;
                }
                if (rotorGamma.Get_Rotor_ID == rotor.Get_Rotor_ID)
                {
                    checkedListBox.SetItemChecked(9, true);
                    checkedListBox.SetSelected(9, true);
                    rotorGamma.Notch = rotor.Notch;
                    rotorGamma.Ring_POS = rotor.Ring_POS;
                }
                SetParams();
            }
        }

        public Rotor GetRotor
        {
            get
            {
                if (checkedListBox.GetItemChecked(0))
                    return rotorI;
                if (checkedListBox.GetItemChecked(1))
                    return rotorII;
                if (checkedListBox.GetItemChecked(2))
                    return rotorIII;
                if (checkedListBox.GetItemChecked(3))
                    return rotorIV;
                if (checkedListBox.GetItemChecked(4))
                    return rotorV;
                if (checkedListBox.GetItemChecked(5))
                    return rotorVI;
                if (checkedListBox.GetItemChecked(6))
                    return rotorVII;
                if (checkedListBox.GetItemChecked(7))
                    return rotorVIII;
                if (checkedListBox.GetItemChecked(8))
                    return rotorBeta;
                if (checkedListBox.GetItemChecked(9))
                    return rotorGamma;
                return null;
            }
        }

        public Rotor GetBasicRotorById(string id)
        {
            if (id == "I")
                return rotorI;
            if (id == "II")
                return rotorII;
            if (id == "III")
                return rotorIII;
            if (id == "IV")
                return rotorIV;
            if (id == "V")
                return rotorV;
            if (id == "VI")
                return rotorVI;
            if (id == "VII")
                return rotorVII;
            if (id == "VIII")
                return rotorVIII;
            if (id == "β")
                return rotorBeta;
            if (id == "γ")
                return rotorGamma;
            return null;
        }

        private void checkedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBox.SetItemChecked(0, false);
            checkedListBox.SetItemChecked(1, false);
            checkedListBox.SetItemChecked(2, false);
            checkedListBox.SetItemChecked(3, false);
            checkedListBox.SetItemChecked(4, false);
            checkedListBox.SetItemChecked(5, false);
            checkedListBox.SetItemChecked(6, false);
            checkedListBox.SetItemChecked(7, false);
            checkedListBox.SetItemChecked(8, false);
            checkedListBox.SetItemChecked(9, false);
            checkedListBox.SetItemChecked(checkedListBox.SelectedIndex, true);
            SetParams();
        }

        private void SetParams()
        {
            if (checkedListBox.SelectedIndex == 0)
            {
                comboBox1.SelectedIndex = rotorI.Ring_POS - 1;
                comboBox2.SelectedIndex = rotorI.Notch - 1;
            }
            if (checkedListBox.SelectedIndex == 1)
            {
                comboBox1.SelectedIndex = rotorII.Ring_POS - 1;
                comboBox2.SelectedIndex = rotorII.Notch - 1;
            }
            if (checkedListBox.SelectedIndex == 2)
            {
                comboBox1.SelectedIndex = rotorIII.Ring_POS - 1;
                comboBox2.SelectedIndex = rotorIII.Notch - 1;
            }
            if (checkedListBox.SelectedIndex == 3)
            {
                comboBox1.SelectedIndex = rotorIV.Ring_POS - 1;
                comboBox2.SelectedIndex = rotorIV.Notch - 1;
            }
            if (checkedListBox.SelectedIndex == 4)
            {
                comboBox1.SelectedIndex = rotorV.Ring_POS - 1;
                comboBox2.SelectedIndex = rotorV.Notch - 1;
            }
            if (checkedListBox.SelectedIndex == 5)
            {
                comboBox1.SelectedIndex = rotorVI.Ring_POS - 1;
                comboBox2.SelectedIndex = rotorVI.Notch - 1;
            }
            if (checkedListBox.SelectedIndex == 6)
            {
                comboBox1.SelectedIndex = rotorVII.Ring_POS - 1;
                comboBox2.SelectedIndex = rotorVII.Notch - 1;
            }
            if (checkedListBox.SelectedIndex == 7)
            {
                comboBox1.SelectedIndex = rotorVIII.Ring_POS - 1;
                comboBox2.SelectedIndex = rotorVIII.Notch - 1;
            }
            if (checkedListBox.SelectedIndex == 8)
            {
                comboBox1.SelectedIndex = rotorBeta.Ring_POS - 1;
                comboBox2.SelectedIndex = rotorBeta.Notch - 1;
            }
            if (checkedListBox.SelectedIndex == 9)
            {
                comboBox1.SelectedIndex = rotorGamma.Ring_POS - 1;
                comboBox2.SelectedIndex = rotorGamma.Notch - 1;
            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (checkedListBox.SelectedIndex == 0)
                rotorI.Ring_POS = comboBox1.SelectedIndex + 1;
            if (checkedListBox.SelectedIndex == 1)
                rotorII.Ring_POS = comboBox1.SelectedIndex + 1;
            if (checkedListBox.SelectedIndex == 2)
                rotorIII.Ring_POS = comboBox1.SelectedIndex + 1;
            if (checkedListBox.SelectedIndex == 3)
                rotorIV.Ring_POS = comboBox1.SelectedIndex + 1;
            if (checkedListBox.SelectedIndex == 4)
                rotorV.Ring_POS = comboBox1.SelectedIndex + 1;
            if (checkedListBox.SelectedIndex == 5)
                rotorVI.Ring_POS = comboBox1.SelectedIndex + 1;
            if (checkedListBox.SelectedIndex == 6)
                rotorVII.Ring_POS = comboBox1.SelectedIndex + 1;
            if (checkedListBox.SelectedIndex == 7)
                rotorVIII.Ring_POS = comboBox1.SelectedIndex + 1;
            if (checkedListBox.SelectedIndex == 8)
                rotorBeta.Ring_POS = comboBox1.SelectedIndex + 1;
            if (checkedListBox.SelectedIndex == 9)
                rotorGamma.Ring_POS = comboBox1.SelectedIndex + 1;
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (checkedListBox.SelectedIndex == 0)
                rotorI.Notch = comboBox2.SelectedIndex + 1;
            if (checkedListBox.SelectedIndex == 1)
                rotorII.Notch = comboBox2.SelectedIndex + 1;
            if (checkedListBox.SelectedIndex == 2)
                rotorIII.Notch = comboBox2.SelectedIndex + 1;
            if (checkedListBox.SelectedIndex == 3)
                rotorIV.Notch = comboBox2.SelectedIndex + 1;
            if (checkedListBox.SelectedIndex == 4)
                rotorV.Notch = comboBox2.SelectedIndex + 1;
            if (checkedListBox.SelectedIndex == 5)
                rotorVI.Notch = comboBox2.SelectedIndex + 1;
            if (checkedListBox.SelectedIndex == 6)
                rotorVII.Notch = comboBox2.SelectedIndex + 1;
            if (checkedListBox.SelectedIndex == 7)
                rotorVIII.Notch = comboBox2.SelectedIndex + 1;
            if (checkedListBox.SelectedIndex == 8)
                rotorBeta.Notch = comboBox2.SelectedIndex + 1;
            if (checkedListBox.SelectedIndex == 9)
                rotorGamma.Notch = comboBox2.SelectedIndex + 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rotorI = new Rotor("I", "EKMFLGDQVZNTOWYHXUSPAIBRCJ", 1, 17, 0);
            rotorII = new Rotor("II", "AJDKSIRUXBLHWTMCQGZNPYFVOE", 1, 5, 1);
            rotorIII = new Rotor("III", "BDFHJLCPRTXVZNYEIWGAKMUSQO", 1, 22, 2);
            rotorIV = new Rotor("IV", "ESOVPZJAYQUIRHXLNFTGKDCMWB", 1, 10, 3);
            rotorV = new Rotor("V", "VZBRGITYUPSDNHLXAWMJQOFECK", 1, 26, 4);
            rotorVI = new Rotor("VI", "VZBRGITYUPSDNHLXAWMJQOFECK", 1, 26, 5, true);
            rotorVII = new Rotor("VII", "VZBRGITYUPSDNHLXAWMJQOFECK", 1, 26, 6, true);
            rotorVIII = new Rotor("VIII", "VZBRGITYUPSDNHLXAWMJQOFECK", 1, 26, 7, true);
            rotorBeta = new Rotor("β", "LEYJVCNIXWPBQMDRTAKZGFUHOS", 1, 26, 8);
            rotorGamma = new Rotor("γ", "FSOKANUERHMBTIYCWLQPZXVGJD", 1, 26, 9);
            SetParams();
        }
    }
}