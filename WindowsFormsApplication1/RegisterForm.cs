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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(UsernameTextBox.Text) ||
                string.IsNullOrWhiteSpace(PasswordTextBox.Text))
            {
                System.Windows.Forms.MessageBox.Show("Username and Password is requied!");

                return;
            }
            else
            {
                string strErrorMessages = string.Empty;
                if (UsernameTextBox.Text.Length<6)
                {
                    strErrorMessages =
                        "Username length should be at least 6 characters!";
                }
                if(PasswordTextBox.Text.Length<8)
                {
                    if(strErrorMessages !=string.Empty)
                    {
                        strErrorMessages +=
                            System.Environment.NewLine;
                    }
                    strErrorMessages +=
                        "Password length should be at least 8 characters!";
                }
                if (strErrorMessages != string.Empty)
                {
                    System.Windows.Forms.MessageBox.Show(strErrorMessages);

                    return;
                }
            }
          

            Models.DatabaseContext oDatabaseContext = null;
            try
            {
                oDatabaseContext = new Models.DatabaseContext();

                Models.user ouser = new Models.user();

                ouser.IsActive = true;
                ouser.UserName = UsernameTextBox.Text;
                ouser.FullName = FullNameTextBox.Text;
                ouser.PassWord = PasswordTextBox.Text;
                oDatabaseContext.users.Add(ouser);
                oDatabaseContext.SaveChanges();

                System.Windows.Forms.MessageBox.Show("Registration Done!");

                UsernameTextBox.Text = string.Empty;
                PasswordTextBox.Text = string.Empty;
                FullNameTextBox.Text = string.Empty;




            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show("Error" + ex.Message);
            }
            finally
            {
                if(oDatabaseContext!=null)
                {
                    oDatabaseContext.Dispose();
                    oDatabaseContext = null;
                }
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            UsernameTextBox.Text = string.Empty;
            PasswordTextBox.Text = string.Empty;
            FullNameTextBox.Text = string.Empty;
        }
    }
}
