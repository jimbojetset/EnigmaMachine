using System.Diagnostics;
using System.Windows.Forms;

namespace EnigmaMachine
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            LinkLabel.Link link1 = new LinkLabel.Link();
            link1.LinkData = "http://en.wikipedia.org/wiki/Enigma_machine";
            linkLabel1.Links.Add(link1);
            LinkLabel.Link link2 = new LinkLabel.Link();
            link2.LinkData = "http://wiki.franklinheath.co.uk/index.php/Enigma/Sample_Messages";
            linkLabel2.Links.Add(link2);
            LinkLabel.Link link3 = new LinkLabel.Link();
            link3.LinkData = "http://www.codesandciphers.org.uk/enigma/index.htm";
            linkLabel3.Links.Add(link3);
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var si = new ProcessStartInfo(e.Link.LinkData.ToString());
            Process.Start(si);
        }
    }
}