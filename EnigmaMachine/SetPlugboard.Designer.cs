namespace EnigmaMachine
{
    partial class SetPlugboard
    {

        #region Windows Form Designer generated code


        #endregion

        private System.Windows.Forms.ComboBox inCombo;
        private System.Windows.Forms.ComboBox outCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label plugboardLabel1;
        private System.Windows.Forms.Button setButton;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label plugboardLabel2;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetPlugboard));
            this.inCombo = new System.Windows.Forms.ComboBox();
            this.outCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.plugboardLabel1 = new System.Windows.Forms.Label();
            this.setButton = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.plugboardLabel2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // inCombo
            // 
            this.inCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inCombo.FormattingEnabled = true;
            this.inCombo.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z"});
            this.inCombo.Location = new System.Drawing.Point(15, 214);
            this.inCombo.Name = "inCombo";
            this.inCombo.Size = new System.Drawing.Size(36, 21);
            this.inCombo.TabIndex = 2;
            // 
            // outCombo
            // 
            this.outCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.outCombo.FormattingEnabled = true;
            this.outCombo.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z"});
            this.outCombo.Location = new System.Drawing.Point(72, 214);
            this.outCombo.Name = "outCombo";
            this.outCombo.Size = new System.Drawing.Size(36, 21);
            this.outCombo.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(57, 217);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "̶̶̶̶̶̶̶̶̶̶̶̶̶̶̶̶̶̶̶̶̶̶̶̶̶̶̶̶̶̶̶̶̶̶̶̶̶̶̶̶";
            // 
            // plugboardLabel1
            // 
            this.plugboardLabel1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plugboardLabel1.Location = new System.Drawing.Point(4, 151);
            this.plugboardLabel1.Name = "plugboardLabel1";
            this.plugboardLabel1.Size = new System.Drawing.Size(370, 16);
            this.plugboardLabel1.TabIndex = 5;
            // 
            // setButton
            // 
            this.setButton.Location = new System.Drawing.Point(114, 213);
            this.setButton.Name = "setButton";
            this.setButton.Size = new System.Drawing.Size(51, 23);
            this.setButton.TabIndex = 6;
            this.setButton.Text = "Set";
            this.setButton.UseVisualStyleBackColor = true;
            this.setButton.Click += new System.EventHandler(this.setButton_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(289, 212);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "Done";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(370, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "| | | | | | | | | | | | | | | | | | | | | | | | | |";
            // 
            // plugboardLabel2
            // 
            this.plugboardLabel2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plugboardLabel2.Location = new System.Drawing.Point(4, 184);
            this.plugboardLabel2.Name = "plugboardLabel2";
            this.plugboardLabel2.Size = new System.Drawing.Size(370, 16);
            this.plugboardLabel2.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(170, 213);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(51, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Reset";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(8, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(361, 141);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // SetPlugboard
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 249);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.plugboardLabel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.setButton);
            this.Controls.Add(this.plugboardLabel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.outCombo);
            this.Controls.Add(this.inCombo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SetPlugboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Setup Plugboard (Steckerbrett)";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}