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
    public partial class updateProFile : Form
    {
        public updateProFile()
        {
            InitializeComponent();
        }

        private void updateProFile_Load(object sender, EventArgs e)
        {

            Models.DatabaseContext oDatabaseContext = null;
            try
            {
                oDatabaseContext = new Models.DatabaseContext();
                Models.user ouser = oDatabaseContext.users.Where
                        (current => current.ID==Infrastructure.Utility.AuthenticatedUser.ID)
                        .FirstOrDefault();


                FullNameTextBox.Text = ouser.FullName;
                DescriptionTextBox.Text = ouser.Description;

                if (ouser == null)
                {
                    System.Windows.Forms.Application.Exit();
                }
            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (oDatabaseContext != null)
                {
                    oDatabaseContext.Dispose();
                    oDatabaseContext = null;
                }
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Models.DatabaseContext oDatabaseContext = null;
            try
            {
                oDatabaseContext = new Models.DatabaseContext();
                Models.user ouser = oDatabaseContext.users.Where
                        (current => current.ID == Infrastructure.Utility.AuthenticatedUser.ID)
                        .FirstOrDefault();


                ouser.FullName= FullNameTextBox.Text;
                ouser.Description = DescriptionTextBox.Text;
                oDatabaseContext.SaveChanges();

                Infrastructure.Utility.AuthenticatedUser = ouser;

                System.Windows.Forms.MessageBox.Show("Your profile was updated successfully...");

                if (ouser == null)
                {
                    System.Windows.Forms.Application.Exit();
                }
            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (oDatabaseContext != null)
                {
                    oDatabaseContext.Dispose();
                    oDatabaseContext = null;
                }
            }
        }
    }
}
