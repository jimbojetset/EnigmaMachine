using System;
using System.Windows.Forms;

namespace EnigmaMachine
{
    public partial class ViewSettings : Form
    {
        public ViewSettings(string data, string title)
        {
            InitializeComponent();
            if (!String.IsNullOrEmpty(title))
                this.Text = title;
            textBox1.Text = data;
            textBox1.SelectionStart = 0;
        }
    }
}