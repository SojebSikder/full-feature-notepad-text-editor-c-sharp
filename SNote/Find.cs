using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SNote
{
    public partial class Find : Form
    {
      


      //  private readonly Form1 _Main;

        public Find() {
            InitializeComponent();          
        }

       

        public void btnfind_Click(object sender, EventArgs e)
        {
           /* Form1 frm2 = new Form1();
            frm2.GetRichTextBox().Text = "hello world";
            * */


            /*
           int index = 0; string temp = richTextBox1.Text; richTextBox1.Text = ""; richTextBox1.Text = temp;
            while (index < richTextBox1.Text.LastIndexOf(txtFind.Text))
            {
               
                richTextBox1.Find(txtFind.Text, index, richTextBox1.TextLength, RichTextBoxFinds.None);
                richTextBox1.SelectionBackColor = Color.Red;
                index = richTextBox1.Text.IndexOf(txtFind.Text, index) + 1;
            }
             * */
             

           
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            richTextBox1.Clear();
        }

        public void Find_Load(object sender, EventArgs e)
        {           
          
            
        }

        private void btnreplace_Click(object sender, EventArgs e)
        {
            int index = 0; string temp = richTextBox1.Text; richTextBox1.Text = ""; richTextBox1.Text = temp;
            while (index < richTextBox1.Text.LastIndexOf(txtFind.Text))
            {
               // richTextBox1.Find(txtFind.Text, index, richTextBox1.TextLength, RichTextBoxFinds.None);
                richTextBox1.Text.Replace("sojeb","sikder");
                //richTextBox1.SelectionBackColor = Color.Red;
                index = richTextBox1.Text.IndexOf(txtFind.Text, index) + 1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        /*    var SearchText = richTextBox1.Text;
            var MatchCase = checkBox1.Checked;
            var bSearchDown = rddown.Checked;

            if (!_Main.FindAndSelect(SearchText, MatchCase, bSearchDown))
            {
                MessageBox.Show(this, CONST.CannotFindMessage.FormatUsingObject(new { SearchText = SearchText }), "Notepad Clone");
            }
            */

        }
    }
}
