using System;
using System.Windows.Forms;

namespace EnigmaMachine
{
    public partial class SetPlugboard : Form
    {
        private Plugboard _plugboard;

        public SetPlugboard(Plugboard plugboard)
        {
            InitializeComponent();
            _plugboard = plugboard;
            DisplayPlugboard();
        }

        public void DisplayPlugboard()
        {
            string i = "";
            string o = "";
            foreach (char c in _plugboard.Plug_In)
                i += c + " ";
            i.TrimEnd();
            foreach (char c in _plugboard.Plug_Out)
                o += c + " ";
            o.TrimEnd();
            plugboardLabel1.Text = i;
            plugboardLabel2.Text = o;
        }

        public Plugboard GetPlugboard { get { return _plugboard; } }

        private void setButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(inCombo.Text) && !String.IsNullOrEmpty(outCombo.Text))
            {
                if (inCombo.Text != outCombo.Text && _plugboard.Plug_In.IndexOf(inCombo.Text) == _plugboard.Plug_Out.IndexOf(inCombo.Text) && _plugboard.Plug_In.IndexOf(outCombo.Text) == _plugboard.Plug_Out.IndexOf(outCombo.Text))
                {
                    int i = _plugboard.Plug_In.IndexOf(inCombo.Text);
                    int o = _plugboard.Plug_In.IndexOf(outCombo.Text);
                    _plugboard.Plug_Out = _plugboard.Plug_Out.Remove(i, 1).Insert(i, _plugboard.Plug_In.Substring(o, 1));
                    _plugboard.Plug_Out = _plugboard.Plug_Out.Remove(o, 1).Insert(o, _plugboard.Plug_In.Substring(i, 1));
                }
                else if (inCombo.Text == outCombo.Text)
                {
                    string s = inCombo.Text;
                    string t = String.Empty;
                    for (int x = 0; x < _plugboard.Plug_Out.Length; x++)
                    {
                        if (_plugboard.Plug_In.Substring(x, 1) == s && _plugboard.Plug_Out.Substring(x, 1) != s)
                            _plugboard.Plug_Out = _plugboard.Plug_Out.Remove(x, 1).Insert(x, s);
                        if (_plugboard.Plug_Out.Substring(x, 1) == s && _plugboard.Plug_In.Substring(x, 1) != s)
                            _plugboard.Plug_Out = _plugboard.Plug_Out.Remove(x, 1).Insert(x, _plugboard.Plug_In.Substring(x, 1));
                    }
                }
                else
                {
                    MessageBox.Show("One of the plugs '" + inCombo.Text + "' or '" + outCombo.Text + " may already be assigned.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                inCombo.SelectedIndex = -1;
                outCombo.SelectedIndex = -1;
            }
            DisplayPlugboard();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _plugboard.Plug_Out = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            DisplayPlugboard();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}