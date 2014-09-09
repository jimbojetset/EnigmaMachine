using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace EnigmaMachine
{
    public partial class EnigmaMachine : Form
    {
        private Rotor left_Rotor;
        private Rotor mid_Rotor;
        private Rotor right_Rotor;
        private Rotor extra_Rotor;
        private Reflector reflector;
        private Plugboard plugboard = new Plugboard();
        private string alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private int grouping = 6;
        private bool running = true;
        private bool keyDown = false;
        private bool playSound = false;

        [DllImport("user32.dll")]
        private static extern bool HideCaret(IntPtr hWnd);

        public EnigmaMachine()
        {
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(AssemblyResolver);
            InitializeComponent();
            rotorsToolStripMenuItem_Click(null, null);
            panel6.BackColor = Color.FromArgb(7, 7, 7);
            left_Rotor = new Rotor("I", "EKMFLGDQVZNTOWYHXUSPAIBRCJ", 1, 17);
            mid_Rotor = new Rotor("II", "AJDKSIRUXBLHWTMCQGZNPYFVOE", 1, 5);
            right_Rotor = new Rotor("III", "BDFHJLCPRTXVZNYEIWGAKMUSQO", 1, 22);
            extra_Rotor = new Rotor("IV", "ESOVPZJAYQUIRHXLNFTGKDCMWB", 1, 10);
            reflector = new Reflector("B", "B", "YRUHQSLDPXNGOKMIEBFZCWVJAT");
            DisplayPlugboard();
            Display_Rotors();
        }

        public static Assembly AssemblyResolver(object sender, System.ResolveEventArgs e)
        {
            MessageBox.Show(e.Name, "Unable to Start", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return null;
        }

        private void Display_Rotors()
        {
            if (left_Rotor != null)
            {
                leftTextReel.Text = left_Rotor.Get_Reel_Letter;//left
                textBox10.Text = left_Rotor.Get_Reel_Letter;//left
                reel_1_label.Text = left_Rotor.Get_Rotor_ID;
                textBox4.Text = left_Rotor.Get_Reel_Letter_plus1;
                textBox3.Text = left_Rotor.Get_Reel_Letter_minus1;
            }
            if (mid_Rotor != null)
            {
                midTextReel.Text = mid_Rotor.Get_Reel_Letter;//middle
                textBox11.Text = mid_Rotor.Get_Reel_Letter;//middle
                reel_2_label.Text = mid_Rotor.Get_Rotor_ID;
                textBox6.Text = mid_Rotor.Get_Reel_Letter_plus1;
                textBox5.Text = mid_Rotor.Get_Reel_Letter_minus1;
            }
            if (right_Rotor != null)
            {
                rightTextReel.Text = right_Rotor.Get_Reel_Letter;//right
                textBox12.Text = right_Rotor.Get_Reel_Letter;//right
                reel_3_label.Text = right_Rotor.Get_Rotor_ID;
                textBox8.Text = right_Rotor.Get_Reel_Letter_plus1;
                textBox7.Text = right_Rotor.Get_Reel_Letter_minus1;
            }
            if (extraRotor.Enabled)
            {
                extraTextReel.Text = extra_Rotor.Get_Reel_Letter;//right
                textBox9.Text = extra_Rotor.Get_Reel_Letter;//right
                reel_extra_label.Text = extra_Rotor.Get_Rotor_ID;
                textBox1.Text = extra_Rotor.Get_Reel_Letter_plus1;
                textBox2.Text = extra_Rotor.Get_Reel_Letter_minus1;
            }
            if (reflector != null)
                label1.Text = reflector.Get_Id;
        }

        private bool initialised()
        {
            return left_Rotor != null & mid_Rotor != null && right_Rotor != null && reflector != null && running;
        }

        private string Encode(string s)
        {
            if (initialised())
            {
                s = plugboard.Get_Output(s);
                s = right_Rotor.Get_Enc_FWD(s);
                s = mid_Rotor.Get_Enc_FWD(s);
                s = left_Rotor.Get_Enc_FWD(s);
                if (extraRotor.Enabled)
                    s = extra_Rotor.Get_Enc_FWD(s);
                s = reflector.Get_Reflected(s);
                if (extraRotor.Enabled)
                    s = extra_Rotor.Get_Enc_REV(s);
                s = left_Rotor.Get_Enc_REV(s);
                s = mid_Rotor.Get_Enc_REV(s);
                s = right_Rotor.Get_Enc_REV(s);
                s = plugboard.Get_Output(s);
                return s;
            }
            return "";
        }

        private string DoKeyPress(string key)
        {
            if (initialised())
            {
                if (mid_Rotor.Notch_Hit)
                    left_Rotor.Rotate_FWD();
                if (mid_Rotor.Notch_Hit)
                    mid_Rotor.Rotate_FWD();
                if (right_Rotor.Notch_Hit)
                    mid_Rotor.Rotate_FWD();
                right_Rotor.Rotate_FWD();
                Display_Rotors();
                return Encode(key);
            }
            return "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (left_Rotor != null)
                left_Rotor.Rotate_FWD();
            Display_Rotors();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (left_Rotor != null)
                left_Rotor.Rotate_REV();
            Display_Rotors();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (mid_Rotor != null)
                mid_Rotor.Rotate_FWD();
            Display_Rotors();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (mid_Rotor != null)
                mid_Rotor.Rotate_REV();
            Display_Rotors();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (right_Rotor != null)
                right_Rotor.Rotate_FWD();
            Display_Rotors();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (right_Rotor != null)
                right_Rotor.Rotate_REV();
            Display_Rotors();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (extra_Rotor != null)
                extra_Rotor.Rotate_FWD();
            Display_Rotors();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (extra_Rotor != null)
                extra_Rotor.Rotate_REV();
            Display_Rotors();
        }

        private void LightLamp(TextBox t)
        {
            if (initialised())
            {
                t.ForeColor = Color.White;
                paper.Focus();
            }
        }

        private void ExtinguishLamps()
        {
            foreach (Control t in panel7.Controls)
            {
                if (t.Name.StartsWith("lamp"))
                    t.ForeColor = Color.FromArgb(64, 64, 64, 64);
            }
            paper.Focus();
        }

        private void UpdatePaper(string str = "")
        {
            paper.Text = paper.Text.Replace(" ", "") + str;
            for (int x = 0; x < paper.Text.Length; x++)
            {
                if (x % grouping == 0)
                    paper.Text = paper.Text.Insert(x, " ");
            }
            paper.Text = paper.Text.TrimStart();
            HideCaret(paper.Handle);
        }

        private void EnigmaMachine_KeyDown(object sender, KeyEventArgs e)
        {
            if (initialised() && !keyDown)
            {
                keyDown = true;
                KeysConverter kc = new KeysConverter();
                string keyChar = kc.ConvertToString(e.KeyData).ToUpper();
                paper.Focus();
                if (alpha.Contains(keyChar))
                {
                    string s = DoKeyPress(keyChar);
                    TextBox t = ((TextBox)panel7.Controls["lamp" + s]);
                    LightLamp(t);
                    UpdatePaper(s);
                    t.Refresh();
                    panel6.Refresh();
                    reel_Cover_Panel.Refresh();
                    paper.Refresh();
                    Stream str = Properties.Resources.down;
                    SoundPlayer snd = new SoundPlayer(str);
                    snd.PlaySync();
                    playSound = true;
                }
            }
        }

        private void EnigmaMachine_KeyUp(object sender, KeyEventArgs e)
        {
            if (initialised() && keyDown)
            {
                ExtinguishLamps();
                paper.Focus();
                if (playSound)
                {
                    Application.DoEvents();
                    Stream str = Properties.Resources.up;
                    SoundPlayer snd = new SoundPlayer(str);
                    snd.PlaySync();
                    playSound = false;
                }
            }
            keyDown = false;
        }

        private void EnigmaMachine_Activated(object sender, EventArgs e)
        {
            HideCaret(paper.Handle);
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            paper.Text = "";
        }

        private void plugboardLabel_Click(object sender, EventArgs e)
        {
            SetPlugboard setPlugboard = new SetPlugboard(plugboard);
            var result = setPlugboard.ShowDialog();
            if (result == DialogResult.OK)
            {
                plugboard = setPlugboard.GetPlugboard;
                DisplayPlugboard();
            }
        }

        public void DisplayPlugboard()
        {
            string i = "";
            string o = "";
            foreach (char c in plugboard.Plug_In)
                i += c + " ";
            i.TrimEnd();
            foreach (char c in plugboard.Plug_Out)
                o += c + " ";
            o.TrimEnd();
            plugboardLabel1.Text = i;
            plugboardLabel2.Text = o;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            SetReflector setReflector = new SetReflector(reflector);
            var result = setReflector.ShowDialog();
            if (result == DialogResult.OK)
            {
                reflector = setReflector.GetReflector;
                Display_Rotors();
            }
        }

        private void reel_3_label_Click(object sender, EventArgs e)
        {
            SetRotor setRotor = new SetRotor(right_Rotor);
            var result = setRotor.ShowDialog();
            if (result == DialogResult.OK)
            {
                right_Rotor = setRotor.GetRotor;
                Display_Rotors();
            }
        }

        private void reel_2_label_Click(object sender, EventArgs e)
        {
            SetRotor setRotor = new SetRotor(mid_Rotor);
            var result = setRotor.ShowDialog();
            if (result == DialogResult.OK)
            {
                mid_Rotor = setRotor.GetRotor;
                Display_Rotors();
            }
        }

        private void reel_1_label_Click(object sender, EventArgs e)
        {
            SetRotor setRotor = new SetRotor(left_Rotor);
            var result = setRotor.ShowDialog();
            if (result == DialogResult.OK)
            {
                left_Rotor = setRotor.GetRotor;
                Display_Rotors();
            }
        }

        private void reel_extra_label_Click(object sender, EventArgs e)
        {
            SetRotor setRotor = new SetRotor(extra_Rotor);
            var result = setRotor.ShowDialog();
            if (result == DialogResult.OK)
            {
                extra_Rotor = setRotor.GetRotor;
                Display_Rotors();
            }
        }

        private void ovalShape_Click(object sender, EventArgs e)
        {
            paper.Focus();
            HideCaret(paper.Handle);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            extraRotor.Visible = true;
            extraRotor.Enabled = true;
            button7.Visible = true;
            button8.Visible = true;
            reel_extra_label.Visible = true;
            Display_Rotors();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            extraRotor.Visible = false;
            extraRotor.Enabled = false;
            button7.Visible = false;
            button8.Visible = false;
            reel_extra_label.Visible = false;
        }

        private void groupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grouping = 5;
            UpdatePaper();
        }

        private void groupToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            grouping = 6;
            UpdatePaper();
        }

        private void noGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grouping = 99999;
            UpdatePaper();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void enterMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputMessage inputMessage = new InputMessage();
            var result = inputMessage.ShowDialog();
            if (result == DialogResult.OK)
            {
                DoMessage(inputMessage.GetMessage);
            }
        }

        private void DoMessage(string message)
        {
            foreach (char c in message)
            {
                if (running)
                {
                    string s = DoKeyPress(c.ToString());
                    TextBox t = ((TextBox)panel7.Controls["lamp" + s]);
                    LightLamp(t);
                    UpdatePaper(s);
                    t.Refresh();
                    paper.Refresh();
                    int r = 0;
                    while (r < 10)
                    {
                        Thread.Sleep(1);
                        Application.DoEvents();
                        r++;
                    }
                    ExtinguishLamps();
                }
            }
        }

        private void EnigmaMachine_FormClosing(object sender, FormClosingEventArgs e)
        {
            running = false;
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(paper.Text);
        }

        private void groupToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            grouping = 4;
            UpdatePaper();
        }

        private void groupToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            grouping = 7;
            UpdatePaper();
        }

        private void saveConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewSettings("Enigma Settings That Will Be Saved");
            StringBuilder sb = new StringBuilder();
            sb.Append(right_Rotor.Get_Rotor_ID + "|");   //0
            sb.Append(right_Rotor.Ring_POS + "|");       //1
            sb.Append(right_Rotor.Notch + "|");          //2
            sb.Append(mid_Rotor.Get_Rotor_ID + "|");     //3
            sb.Append(mid_Rotor.Ring_POS + "|");         //4
            sb.Append(mid_Rotor.Notch + "|");            //5
            sb.Append(left_Rotor.Get_Rotor_ID + "|");    //6
            sb.Append(left_Rotor.Ring_POS + "|");        //7
            sb.Append(left_Rotor.Notch + "|");           //8
            sb.Append(extra_Rotor.Get_Rotor_ID + "|");   //9
            sb.Append(extra_Rotor.Ring_POS + "|");       //10
            sb.Append(extra_Rotor.Notch + "|");          //11
            sb.Append(extraRotor.Enabled + "|");         //12
            sb.Append(reflector.Get_Id + "|");           //13
            sb.Append(plugboard.Plug_Out + "|");         //14
            sb.Append(extra_Rotor.Rotor_POS + "|");      //15
            sb.Append(left_Rotor.Rotor_POS + "|");       //16
            sb.Append(mid_Rotor.Rotor_POS + "|");        //17
            sb.Append(right_Rotor.Rotor_POS);            //18
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = "Enigma Config|*.enigma";
            if (savefile.ShowDialog() == DialogResult.OK)
                using (StreamWriter sw = new StreamWriter(savefile.FileName))
                    sw.Write(sb.ToString());
        }

        private void loadConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string config = null;
                OpenFileDialog openfile = new OpenFileDialog();
                openfile.Filter = "Enigma Config|*.enigma";
                if (openfile.ShowDialog() == DialogResult.OK)
                    using (StreamReader sr = new StreamReader(openfile.FileName))
                        config = sr.ReadToEnd();
                string[] data = config.Split('|');
                if (data.Length == 19)
                {
                    string t = data[0];
                    SetRotor setRotor = new SetRotor();
                    right_Rotor = setRotor.GetBasicRotorById(data[0]);
                    right_Rotor.Ring_POS = Convert.ToInt32(data[1]);
                    right_Rotor.Notch = Convert.ToInt32(data[2]);
                    mid_Rotor = setRotor.GetBasicRotorById(data[3]);
                    mid_Rotor.Ring_POS = Convert.ToInt32(data[4]);
                    mid_Rotor.Notch = Convert.ToInt32(data[5]);
                    left_Rotor = setRotor.GetBasicRotorById(data[6]);
                    left_Rotor.Ring_POS = Convert.ToInt32(data[7]);
                    left_Rotor.Notch = Convert.ToInt32(data[8]);
                    extra_Rotor = setRotor.GetBasicRotorById(data[9]);
                    extra_Rotor.Ring_POS = Convert.ToInt32(data[10]);
                    extra_Rotor.Notch = Convert.ToInt32(data[11]);
                    extraRotor.Enabled = Convert.ToBoolean(data[12]);
                    extraRotor.Visible = Convert.ToBoolean(data[12]);
                    SetReflector setReflector = new SetReflector();
                    reflector = setReflector.GetReflectorById(data[13]);
                    plugboard.Plug_Out = data[14];
                    extra_Rotor.Rotor_POS = Convert.ToInt32(data[15]);
                    left_Rotor.Rotor_POS = Convert.ToInt32(data[16]);
                    mid_Rotor.Rotor_POS = Convert.ToInt32(data[17]);
                    right_Rotor.Rotor_POS = Convert.ToInt32(data[18]);
                    setRotor.Dispose();
                    setReflector.Dispose();
                    if (extraRotor.Enabled)
                        rotorsToolStripMenuItem1_Click(null, null);
                    else
                        rotorsToolStripMenuItem_Click(null, null);
                    DisplayPlugboard();
                    Display_Rotors();
                    ViewSettings("Enigma Settings That Were Loaded");
                }
            }
            catch
            {
                MessageBox.Show("There was a problem loading config data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ViewSettings();
        }

        private void ViewSettings(string title = "")
        {
            string e1 = "";
            string e2 = "";
            string e3 = "";
            if (extraRotor.Visible)
            {
                e1 = extra_Rotor.Get_Rotor_ID + " ";
                e2 = extra_Rotor.Ring_POS.ToString();
                e3 = extra_Rotor.Get_Reel_Letter;
            }

            string s = "Rotors:         " + e3 + left_Rotor.Get_Reel_Letter + mid_Rotor.Get_Reel_Letter + right_Rotor.Get_Reel_Letter + Environment.NewLine;

            s += "Reflector:      " + reflector.Get_Name + Environment.NewLine;
            s += "Wheel order:    " + e1 + left_Rotor.Get_Rotor_ID + " " + mid_Rotor.Get_Rotor_ID + " " + right_Rotor.Get_Rotor_ID + Environment.NewLine;
            if (e2.Length == 1)
                e2 = "0" + e2 + " ";
            s += "Ring positions: " + e2;
            e2 = left_Rotor.Ring_POS.ToString();
            if (e2.Length == 1)
                e2 = "0" + e2 + " ";
            s += e2;
            e2 = mid_Rotor.Ring_POS.ToString();
            if (e2.Length == 1)
                e2 = "0" + e2 + " ";
            s += e2;
            e2 = right_Rotor.Ring_POS.ToString();
            if (e2.Length == 1)
                e2 = "0" + e2 + " ";
            s += e2 + Environment.NewLine;
            s += "Plug pairs:	";
            string i = plugboard.Plug_In;
            string o = plugboard.Plug_Out;
            string c = "";
            for (int x = 0; x < i.Length; x++)
                if (o[x].ToString() != i[x].ToString() && c.IndexOf(i[x].ToString()) == -1)
                {
                    s += i[x].ToString() + o[x].ToString() + " ";
                    c += o[x].ToString();
                }
            s = s.TrimEnd();
            ViewSettings viewSettings = new ViewSettings(s, title);
            viewSettings.ShowDialog();
        }

        private void rotorsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //4 rotor
            label1.Width = 30;
            panel6.Visible = false;
            extraRotor.Visible = true;
            extraRotor.Enabled = true;
            button7.Visible = true;
            button8.Visible = true;
            reel_extra_label.Visible = true;

            reel_1_label.Left = 87;
            panel3.Left = 85;
            button1.Left = 122;
            button2.Left = 122;

            reel_2_label.Left = 142;
            panel4.Left = 140;
            button3.Left = 177;
            button4.Left = 177;

            reel_3_label.Left = 197;
            panel1.Left = 195;
            button5.Left = 232;
            button6.Left = 232;

            label3.Left = 250;
            panel6.Left = 34;
            panel6.Width = 267;
            Display_Rotors();
            panel6.Visible = true;
        }

        private void rotorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //3 rotor
            reel_Cover_Panel.Visible = false;
            panel10.Visible = false;
            textBox9.Visible = false;
            label1.Width = 31;
            panel6.Visible = false;
            extraRotor.Visible = false;
            extraRotor.Enabled = false;
            button7.Visible = false;
            button8.Visible = false;
            reel_extra_label.Visible = false;

            reel_1_label.Left = 32;
            panel3.Left = 30;
            button1.Left = 67;
            button2.Left = 67;

            reel_2_label.Left = 87;
            panel4.Left = 85;
            button3.Left = 122;
            button4.Left = 122;

            reel_3_label.Left = 142;
            panel1.Left = 140;
            button5.Left = 177;
            button6.Left = 177;

            label3.Left = 195;
            panel6.Left = 89;
            panel6.Width = 212;
            Display_Rotors();
            panel6.Visible = true;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }
    }
}