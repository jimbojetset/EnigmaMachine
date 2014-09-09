using System;
using System.Windows.Forms;

namespace EnigmaMachine
{
    public partial class InputMessage : Form
    {
        private string _message = String.Empty;

        public InputMessage()
        {
            InitializeComponent();
        }

        public string GetMessage { get { return _message.Replace(" ", ""); } }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            _message = textBox1.Text.ToUpper().Replace("\r", "").Replace("\n","");
            textBox1.Text = _message;
            textBox1.SelectionStart = textBox1.Text.Length + 1;
        }
    }
}