using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;
using System.Threading;
using Tulpep.NotificationWindow;
using System.Diagnostics;

namespace SNote
{
    public partial class Form1 : Form
    {
        int mov;
        int movX;
        int movY;



        Find fn;
        //TabPage tpage = new TabPage("untitled");
        //RichTextBox rtb = new RichTextBox(); 
        bool hight=false;
        SpeechSynthesizer voice;

         SaveFileDialog sfd = new SaveFileDialog();

         public string LabelText
         {
             get
             {
                 return this.GetRichTextBox().Text;
             }
             set
             {
                 this.GetRichTextBox().Text = value;
             }
         }


        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();
        public Form1()
        {
            InitializeComponent();

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            /*

            char[] separator = { ' ' };

            int wordsCount = GetRichTextBox().Text.Split(separator, StringSplitOptions.RemoveEmptyEntries).Length;

           

            toolStripStatusLabel1.Text = "Letter: " + GetRichTextBox().Text.Length.ToString();
            toolStripStatusLabel2.Text = "Words: " + wordsCount.ToString();

            if (hight == true)
            {

                string tag = "doctype|html|static";
                string any = "<"+GetRichTextBox().Text+">";
                MatchCollection keywordMatches = Regex.Matches(GetRichTextBox().Text, tag);
                MatchCollection keywordMatchesany = Regex.Matches(GetRichTextBox().Text, any);

                int originalIndex = GetRichTextBox().SelectionStart;
                int originalLength = GetRichTextBox().SelectionLength;
                Color originalColor = Color.White;





                GetRichTextBox().SelectionStart = 0;
                GetRichTextBox().SelectionLength = GetRichTextBox().Text.Length;
                GetRichTextBox().SelectionColor = originalColor;

                foreach (Match m in keywordMatches)
                {
                    GetRichTextBox().SelectionStart = m.Index;
                    GetRichTextBox().SelectionLength = m.Length;
                    GetRichTextBox().SelectionColor = Color.Blue;
                }

                foreach (Match m in keywordMatchesany)
                {
                    GetRichTextBox().SelectionStart = m.Index;
                    GetRichTextBox().SelectionLength = m.Length;
                    GetRichTextBox().SelectionColor = Color.Red;
                }

                GetRichTextBox().SelectionStart = originalIndex;
                GetRichTextBox().SelectionLength = originalLength;
                GetRichTextBox().SelectionColor = originalColor;

            }
            
             * */
           
        }

       public RichTextBox GetRichTextBox()
       {
           RichTextBox rtb = null;
           TabPage tp = tabControl1.SelectedTab;
           

           if (tp != null)
           {
               rtb = tp.Controls[0] as RichTextBox;
           }

           return rtb;
       }
        public void newcode()
       {
           TabPage tp = new TabPage("New Document");
           RichTextBox rtb = new RichTextBox();
           rtb.ContextMenuStrip = contextMenuStrip2;
           rtb.ForeColor = Color.White;
           rtb.BackColor = Color.CornflowerBlue;
           rtb.Dock = DockStyle.Fill;

           tp.Controls.Add(rtb);
           tabControl1.TabPages.Add(tp);

           tabControl1.SelectTab(tp);
       }

        public void newnamecode(string name)
        {
            TabPage tp = new TabPage(name);
            RichTextBox rtb = new RichTextBox();
            rtb.ContextMenuStrip = contextMenuStrip2;
            rtb.ForeColor = Color.White;
            rtb.BackColor = Color.CornflowerBlue;
            rtb.Dock = DockStyle.Fill;

            tp.Controls.Add(rtb);
            tabControl1.TabPages.Add(tp);

            tabControl1.SelectTab(tp);
        }


        public void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newcode();     
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Stream myStream;
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = ofd.OpenFile()) != null)
                {
                    string strfilename = ofd.FileName;
                    newnamecode(ofd.FileName);
                    /*
                    TabPage tp = new TabPage(ofd.FileName);
                    RichTextBox rtb = new RichTextBox();
                    rtb.BackColor = Color.CornflowerBlue;
                    rtb.Dock = DockStyle.Fill;

                    tp.Controls.Add(rtb);
                    tabControl1.TabPages.Add(tp);

                    tabControl1.SelectTab(tp); 
                     * */

                    string filetext = File.ReadAllText(strfilename);
                    
                    
                    GetRichTextBox().Text = filetext;
                    
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(sfd.FileName, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.Write(GetRichTextBox().Text);
                }
            }



        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRichTextBox().Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRichTextBox().Paste();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRichTextBox().Cut();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRichTextBox().Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRichTextBox().Redo();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRichTextBox().SelectAll();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("A product of SojebSoft");
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            
            //create new tab at startup
            newcode();
            GetRichTextBox().Focus();
            //...........end

            // setting droping text file
            GetRichTextBox().AllowDrop = true;
            GetRichTextBox().DragDrop += new DragEventHandler(GetRichTextBox_DragDrop);

            toolLab.Text = "Ready";

           //voice recognition seting
            voice = new SpeechSynthesizer();

            Choices commands = new Choices();

            commands.Add(new string[] {"new file","undo","redo", "delete that","close application" });
            GrammarBuilder gBuilder = new GrammarBuilder();
            gBuilder.Append(commands);
            Grammar grammer = new Grammar(gBuilder);
            DictationGrammar dg = new DictationGrammar();

            //  recEngine.LoadGrammar(dg);
            // recEngine.RecognizeAsync();

            recEngine.LoadGrammarAsync(grammer);
            recEngine.SetInputToDefaultAudioDevice();
            recEngine.SpeechRecognized += recEngine_SpeechRecognized;

            

            disableVoiceToolStripMenuItem.Enabled = false;

            //..............................text ................
            GetRichTextBox().SelectionStart = GetRichTextBox().TextLength;

            GetRichTextBox().ScrollToCaret();
            


        }

        public string Content
        {
            get { return GetRichTextBox().Text; }
            set {GetRichTextBox().Text = value; }
        }
        public int SelectionEnd
        {
            get { return SelectionStart + SelectionLength; }
        }
        public int SelectionStart
        {
            get { return GetRichTextBox().SelectionStart; }
            set
            {
                GetRichTextBox().SelectionStart = value;
                GetRichTextBox().ScrollToCaret();
            }
        }

        public int SelectionLength
        {
            get { return GetRichTextBox().SelectionLength; }
            set { GetRichTextBox().SelectionLength = value; }
        }

        private string _LastSearchText;
        private bool _LastMatchCase;
        private bool _LastSearchDown;
        public bool FindAndSelect(string pSearchText, bool pMatchCase, bool pSearchDown)
        {
            int Index;

            var eStringComparison = pMatchCase ? StringComparison.CurrentCulture : StringComparison.CurrentCultureIgnoreCase;

            if (pSearchDown)
            {
                Index = Content.IndexOf(pSearchText, SelectionEnd, eStringComparison);
            }
            else
            {
                Index = Content.LastIndexOf(pSearchText, SelectionStart, SelectionStart, eStringComparison);
            }

            if (Index == -1) return false;

            _LastSearchText = pSearchText;
            _LastMatchCase = pMatchCase;
            _LastSearchDown = pSearchDown;

            SelectionStart = Index;
            SelectionLength = pSearchText.Length;

            return true;
        }



        void GetRichTextBox_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileNames = e.Data.GetData(DataFormats.FileDrop) as string[];

            if(fileNames != null)
            {
                foreach (string  name in fileNames)
                {
                    try
                    {
                        GetRichTextBox().AppendText(File.ReadAllText(name));
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

        }
        /*
         var data = e.Data.GetData(DataFormats.FileDrop);
            if(data != null)
            {
                var fileNames = data as string[];
                if(fileNames.Length > 0)
                GetRichTextBox().LoadFile(fileNames[0]);
            }
         
         * */

        void recEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
           
            switch (e.Result.Text.ToString())
            {
                /*
                 case "":
                 richTextBox1.Text += "\n"+e.Result.Text;
                voice.SelectVoiceByHints(VoiceGender.Female);
                voice.SpeakAsync("");
                break;
                      
                 */

                case "new file":                   
                    voice.SelectVoiceByHints(VoiceGender.Female);
                    voice.SpeakAsync("new file created");
                    GetRichTextBox().Clear();
                    break;

                case "undo":
                    GetRichTextBox().Undo();
                    voice.SelectVoiceByHints(VoiceGender.Female);
                    voice.SpeakAsync("undo");
                    break;
                case "redo":
                    GetRichTextBox().Redo();
                    voice.SelectVoiceByHints(VoiceGender.Female);
                    voice.SpeakAsync("redo");
                    break;
                case "delete that":
                    voice.SelectVoiceByHints(VoiceGender.Female);
                    voice.SpeakAsync("deleted");
                    break;
                case "close application":
                    voice.SelectVoiceByHints(VoiceGender.Female);
                    voice.SpeakAsync("deleted");
                    break;

                default:
                   
                    break;


            }

         
        }





        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
         
            if (e.KeyData == Keys.Enter && toolStripTextBox1.TextLength > 0)
            {
                int index = 0; string temp = GetRichTextBox().Text; GetRichTextBox().Text = ""; GetRichTextBox().Text = temp;
                while (index < GetRichTextBox().Text.LastIndexOf(toolStripTextBox1.Text))
                {
                    GetRichTextBox().Find(toolStripTextBox1.Text, index, GetRichTextBox().TextLength, RichTextBoxFinds.None);
                    GetRichTextBox().SelectionBackColor = Color.Red;
                    index = GetRichTextBox().Text.IndexOf(toolStripTextBox1.Text, index) + 1;
                }
            }
            
        }
             

        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int index = 0; string temp = GetRichTextBox().Text; GetRichTextBox().Text = ""; GetRichTextBox().Text = temp;
            while (index < GetRichTextBox().Text.LastIndexOf(toolStripTextBox1.Text))
            {
                GetRichTextBox().Find(toolStripTextBox1.Text, index, GetRichTextBox().TextLength, RichTextBoxFinds.None);
                GetRichTextBox().SelectionBackColor = Color.Yellow;
                index = GetRichTextBox().Text.IndexOf(toolStripTextBox1.Text, index) + 1;
            }
        }

        private void toolStripTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.Font = GetRichTextBox().SelectionFont;
            if (fd.ShowDialog() == DialogResult.OK)
            {
                GetRichTextBox().SelectionFont = fd.Font;
            }
        }

        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cr = new ColorDialog();
            if (cr.ShowDialog() == DialogResult.OK)
            {
                GetRichTextBox().BackColor = cr.Color;
            }
        }

        private void speakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            voice.SelectVoiceByHints(VoiceGender.Male);
            voice.SpeakAsync(GetRichTextBox().Text);
        }

        private void saveTextAsAudioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Wav files|*.wav";
                sfd.Title = "Save to a wave file";

                if(sfd.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write);
                    voice.SetOutputToWaveStream(fs);
                    voice.Speak(GetRichTextBox().Text);

                }

            }
        }

        private void textColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cr = new ColorDialog();
            if (cr.ShowDialog() == DialogResult.OK)
            {
                GetRichTextBox().ForeColor = cr.Color;
            }
        }
        
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(GetRichTextBox().Text, new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new PointF(100, 100));
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                printDocument1.Print();
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        private void enableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            enableToolStripMenuItem.Enabled = false;
            disableVoiceToolStripMenuItem.Enabled = true;
            recEngine.RecognizeAsync(RecognizeMode.Multiple);

            voice.SelectVoiceByHints(VoiceGender.Female);
            voice.SpeakAsync("Voice Recognition Start");
        }

        private void disableVoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {

            disableVoiceToolStripMenuItem.Enabled = false;
            enableToolStripMenuItem.Enabled = true;
            recEngine.RecognizeAsyncStop();

            voice.SelectVoiceByHints(VoiceGender.Female);
            voice.SpeakAsync("Voice Recognition Stoped");


        }

        private void commandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string com;
           com= Interaction.InputBox("Enter Command","SNote","",-1,-1);

           // MessageBox.Show(com);
            if(com=="exit")
            {
                Application.Exit();

            }
            if(com=="developer") {
                Process.Start("http://facebook.com/sojebsikder");
            }

            if (com == "calc")
            {
                Process.Start("calc");
            }
           

        }


        //menue colorize
        private void menuStrip1_MouseHover(object sender, EventArgs e)
        {
            //menuStrip1.BackColor = Color.Red;
        }

        private void fileToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            fileToolStripMenuItem.ForeColor = Color.Black;
            fileToolStripMenuItem.BackColor = Color.Black;

            
        }

        private void fileToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            fileToolStripMenuItem.ForeColor = Color.White;
            fileToolStripMenuItem.BackColor =Color.FromArgb(0,0, 0, 64);

           
        }

        private void editToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            editToolStripMenuItem.ForeColor = Color.Black;
            editToolStripMenuItem.BackColor = Color.Black;
        }

        private void toolStripMenuItem1_MouseHover(object sender, EventArgs e)
        {
            toolStripMenuItem1.ForeColor = Color.Black;
            toolStripMenuItem1.BackColor = Color.Black;
        }

        private void developerToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {

            developerToolStripMenuItem.ForeColor = Color.Black;
            developerToolStripMenuItem.BackColor = Color.Black;
        }

        private void toolsToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            toolsToolStripMenuItem.ForeColor = Color.Black;
            toolsToolStripMenuItem.BackColor = Color.Black;
        }

        private void helpToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            helpToolStripMenuItem.ForeColor = Color.Black;
            helpToolStripMenuItem.BackColor = Color.Black;
        }

        private void editToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            editToolStripMenuItem.ForeColor = Color.White;
            editToolStripMenuItem.BackColor = Color.FromArgb(0, 0, 0, 64);
        }

        private void toolStripMenuItem1_MouseLeave(object sender, EventArgs e)
        {
            toolStripMenuItem1.ForeColor = Color.White;
            toolStripMenuItem1.BackColor = Color.FromArgb(0, 0, 0, 64);
        }

        private void developerToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            developerToolStripMenuItem.ForeColor = Color.White;
            developerToolStripMenuItem.BackColor = Color.FromArgb(0, 0, 0, 64);
        }

        private void toolsToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            toolsToolStripMenuItem.ForeColor = Color.White;
            toolsToolStripMenuItem.BackColor = Color.FromArgb(0, 0, 0, 64);
        }

        private void helpToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            helpToolStripMenuItem.ForeColor = Color.White;
            helpToolStripMenuItem.BackColor = Color.FromArgb(0, 0, 0, 64);
        }

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GetRichTextBox().SelectAll();
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GetRichTextBox().Copy();
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GetRichTextBox().Paste();
        }

        private void cutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GetRichTextBox().Cut();
        }

        private void clearClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRichTextBox().Clear();

       }

        private void findReplaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Find df = new Find();
            df.Show();
           
            
             //   GetRichTextBox().Text = fn.mys;
           
            
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

        }

        private void changeOpeacityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toast tt = new toast();
            tt.Show();
            
        }

        private void GetRichTextBox_KeyDown(object sender, KeyEventArgs e)
        {
/*
            char[] separator = { ' ' };

            int wordsCount = GetRichTextBox().Text.Split(separator, StringSplitOptions.RemoveEmptyEntries).Length;



            toolStripStatusLabel1.Text = "Letter: " + GetRichTextBox().Text.Length.ToString();
            toolStripStatusLabel2.Text = "Words: " + wordsCount.ToString();
            */
        }

      
      
    

        private void tabPage1_Click(object sender, EventArgs e)
        {
            /*
            char[] separator = { ' ' };

            int wordsCount = GetRichTextBox().Text.Split(separator, StringSplitOptions.RemoveEmptyEntries).Length;



            toolStripStatusLabel1.Text = "Letter: " + GetRichTextBox().Text.Length.ToString();
            toolStripStatusLabel2.Text = "Words: " + wordsCount.ToString();
            */
        }

        private void closeTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabControl1.SelectedTab);
        }

        private void closeAllTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Snote is a notepad create by sojeb sikder");
        }

        private void syntaxHighlighHtmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hight = true;
        }

        private void stopHighlightingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hight = false;
        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabControl1.SelectedTab);
        }

        private void contextTab_Opening(object sender, CancelEventArgs e)
        {
           
        }

        private void closeAllTabToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
          
        }

        private void bugsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bug bug = new bug();
            bug.Show();
        }

        private void clearToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GetRichTextBox().Clear();
        }

        private void openTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            test ts = new test();
            ts.Show();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            /*
            mov = 1;
            movX = e.X;
            movY = e.Y;
            */
            
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            /*
            if (mov == 1)
            {

                // this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);

                panel2.Size = new Size(MousePosition.X - movX, MousePosition.Y - movY);
            }
             * */
           
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            /*
            mov = 0;
             * */

            
        }

        bool toggle = true;
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (toggle == true)
            {
                panel2.Size = new Size(740, 150);

                btn_Down.Text = "Shrink";
                toggle = false;
            }

           else if (toggle == false)
            {
                panel2.Size = new Size(740, 69);


                btn_Down.Text = "Expand";
                toggle = true;
            }
        }

        bool toggle2 = true;
        private void button1_Click_2(object sender, EventArgs e)
        {
            if (toggle2 == true)
            {
                panel1.Size = new Size(150, 430);

                btnUp.Text = "Shrink";
                toggle2 = false;
            }

            else if (toggle2 == false)
            {
                panel1.Size = new Size(74, 430);


                btnUp.Text = "Expand";
                toggle2 = true;
            }
        }

        
        }
    }
