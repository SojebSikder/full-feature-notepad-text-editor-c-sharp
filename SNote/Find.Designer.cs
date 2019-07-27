namespace SNote
{
    partial class Find
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.txtRep = new System.Windows.Forms.TextBox();
            this.btnfind = new System.Windows.Forms.Button();
            this.btnReplaceall = new System.Windows.Forms.Button();
            this.btnreplace = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.rdup = new System.Windows.Forms.RadioButton();
            this.rddown = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Find What:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Replace What:";
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(93, 34);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(177, 20);
            this.txtFind.TabIndex = 2;
            // 
            // txtRep
            // 
            this.txtRep.Location = new System.Drawing.Point(93, 90);
            this.txtRep.Name = "txtRep";
            this.txtRep.Size = new System.Drawing.Size(177, 20);
            this.txtRep.TabIndex = 3;
            // 
            // btnfind
            // 
            this.btnfind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnfind.Location = new System.Drawing.Point(289, 31);
            this.btnfind.Name = "btnfind";
            this.btnfind.Size = new System.Drawing.Size(75, 23);
            this.btnfind.TabIndex = 4;
            this.btnfind.Text = "Find Next";
            this.btnfind.UseVisualStyleBackColor = true;
            this.btnfind.Click += new System.EventHandler(this.btnfind_Click);
            // 
            // btnReplaceall
            // 
            this.btnReplaceall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReplaceall.Location = new System.Drawing.Point(289, 87);
            this.btnReplaceall.Name = "btnReplaceall";
            this.btnReplaceall.Size = new System.Drawing.Size(75, 23);
            this.btnReplaceall.TabIndex = 5;
            this.btnReplaceall.Text = "Replcae All";
            this.btnReplaceall.UseVisualStyleBackColor = true;
            // 
            // btnreplace
            // 
            this.btnreplace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnreplace.Location = new System.Drawing.Point(289, 60);
            this.btnreplace.Name = "btnreplace";
            this.btnreplace.Size = new System.Drawing.Size(75, 23);
            this.btnreplace.TabIndex = 6;
            this.btnreplace.Text = "Replace";
            this.btnreplace.UseVisualStyleBackColor = true;
            this.btnreplace.Click += new System.EventHandler(this.btnreplace_Click);
            // 
            // btncancel
            // 
            this.btncancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncancel.Location = new System.Drawing.Point(289, 145);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(75, 23);
            this.btncancel.TabIndex = 7;
            this.btncancel.Text = "Cancel";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(35, 147);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(235, 163);
            this.richTextBox1.TabIndex = 8;
            this.richTextBox1.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(294, 287);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(289, 189);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(81, 17);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "match case";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // rdup
            // 
            this.rdup.AutoSize = true;
            this.rdup.Location = new System.Drawing.Point(289, 226);
            this.rdup.Name = "rdup";
            this.rdup.Size = new System.Drawing.Size(37, 17);
            this.rdup.TabIndex = 11;
            this.rdup.TabStop = true;
            this.rdup.Text = "up";
            this.rdup.UseVisualStyleBackColor = true;
            // 
            // rddown
            // 
            this.rddown.AutoSize = true;
            this.rddown.Location = new System.Drawing.Point(289, 250);
            this.rddown.Name = "rddown";
            this.rddown.Size = new System.Drawing.Size(51, 17);
            this.rddown.TabIndex = 12;
            this.rddown.TabStop = true;
            this.rddown.Text = "down";
            this.rddown.UseVisualStyleBackColor = true;
            // 
            // Find
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(401, 322);
            this.ControlBox = false;
            this.Controls.Add(this.rddown);
            this.Controls.Add(this.rdup);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnreplace);
            this.Controls.Add(this.btnReplaceall);
            this.Controls.Add(this.btnfind);
            this.Controls.Add(this.txtRep);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Find";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Find";
            this.Load += new System.EventHandler(this.Find_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtFind;
        public System.Windows.Forms.TextBox txtRep;
        public System.Windows.Forms.Button btnfind;
        public System.Windows.Forms.Button btnReplaceall;
        public System.Windows.Forms.Button btnreplace;
        public System.Windows.Forms.Button btncancel;
        public System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.RadioButton rdup;
        private System.Windows.Forms.RadioButton rddown;

    }
}