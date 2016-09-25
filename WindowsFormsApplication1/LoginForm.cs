 
using System.Linq;
 

namespace WindowsFormsApplication1
{
    public partial class LoginForm : System.Windows.Forms.Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
               
        }

        private void ResetButton_Click(object sender, System.EventArgs e)
        {
            UsernameTextBox.Text = string.Empty;
            PasswordTextBox.Text = string.Empty;
            UsernameTextBox.Focus();

        }

        private void SubmitButton_Click(object sender, System.EventArgs e)
        {
            RegisterForm frmRegister = new RegisterForm();
            frmRegister.Show();


        }

        private void LoginButton_Click(object sender, System.EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(UsernameTextBox.Text)||
                string.IsNullOrWhiteSpace(PasswordTextBox.Text))
            {
                System.Windows.Forms.MessageBox.Show("Username and Password is requied!");

                return;
            }

            Models.DatabaseContext oDatabaseContext = null;
            try
            {
                oDatabaseContext = new Models.DatabaseContext();


                Models.user ouser = oDatabaseContext.users
                    .Where(curent => string.Compare(UsernameTextBox.Text,curent.UserName, true) == 0)
                    .FirstOrDefault();
                if(ouser==null)
                {
                    System.Windows.Forms.MessageBox.Show("Username and/or Password is not correct!");
                    return;
                }
                if(string.Compare(PasswordTextBox.Text,ouser.PassWord,ignoreCase:false)!=0)
                {
                    System.Windows.Forms.MessageBox.Show("Username and/or Password is not correct!");
                    return;
                }
                if (ouser.IsActive == false)
                {
                    System.Windows.Forms.MessageBox.Show("You can not login to this application! Please contact support.");
                    return;
                }

                Infrastructure.Utility.AuthenticatedUser = ouser;
                Hide();


                MainForm frmMain = new MainForm();
                frmMain.Show();



            }
            catch (System.Exception ex)
            {

                System.Windows.Forms.MessageBox.Show("Error: " + ex.Message);
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
    }
}
