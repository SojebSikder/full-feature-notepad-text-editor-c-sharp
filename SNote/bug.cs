using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace SNote
{
    public partial class bug : Form
    {
        public bug()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {            
            submitData();         
            MessageBox.Show("Successfully Sent :)");
           
        }

        private void submitData()
        {
            try
            {
                string name = txtName.Text;
                string email = txtemail.Text;
                string info =txtInfo.Text ;

                ASCIIEncoding encoding = new ASCIIEncoding();
                string postData = "product=Snote&&name="+txtName.Text+"&&email="+txtemail.Text+"&&info="+txtInfo.Text+"&&submit=submit";
                byte[] data = encoding.GetBytes(postData);

                WebRequest request = WebRequest.Create("http://sojebsoft.ml/bug/index.php");
                request.Method="POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength =data.Length;

                Stream stream = request.GetRequestStream();
                stream.Write(data,0,data.Length);
                stream.Close();

                WebResponse response = request.GetResponse();
                stream = response.GetResponseStream();

                StreamReader sr = new StreamReader(stream);
               // richTextBox1.Text = sr.ReadToEnd();
               // MessageBox.Show(sr.ReadToEnd());

                sr.Close();
                stream.Close();


            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex);
                //richTextBox1.Text = "Error: " + ex;             
            }
        }
    }
}
