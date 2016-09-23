using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Models.databasecontext odatabasecontext = null;
            try
            {
                odatabasecontext = new Models.databasecontext();
                Models.Person operson= new Models.Person();

                //operson.Age = 20;
                //operson.Fname = "Mohsen";
                //operson.Lname = "damghani";
                //odatabasecontext.people.Add(operson);
                //odatabasecontext.SaveChanges();

                var vvv = odatabasecontext.people.Where(curent => curent.Age == 20).ToList();
                textBox1.Text = vvv.ToString();

             

                

            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show("error +"+ex);
            }
             finally
            {
                if(odatabasecontext!=null)
                {
                    odatabasecontext.Dispose();
                    odatabasecontext = null;
                }

            }       
        }
    }
}
