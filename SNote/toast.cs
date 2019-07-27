using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace SNote
{
    public partial class toast : Form
    {
        public toast()
        {
            InitializeComponent();
        }

        private void toast_Load(object sender, EventArgs e)
        {

            
            
        }

        private void toast_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
           // ActiveForm.Opacity = ((double)(trackBar1.Value)/10.0);
            /*
            Form1 fm = new Form1();
            fm.Opacity = ((double)(trackBar1.Value)/10.0);
             * */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
