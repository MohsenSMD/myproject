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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {


            System.Windows.Forms.DialogResult enmResult =
                System.Windows.Forms.MessageBox.Show
                    (text: "آیا به خروج از برنامه اطمینان دارید؟",
                    caption: "سوال",
                    buttons: System.Windows.Forms.MessageBoxButtons.YesNo,
                    icon: System.Windows.Forms.MessageBoxIcon.Question,
                    defaultButton: System.Windows.Forms.MessageBoxDefaultButton.Button2,
                    options: System.Windows.Forms.MessageBoxOptions.RightAlign |
                    System.Windows.Forms.MessageBoxOptions.RtlReading);

            if (enmResult == System.Windows.Forms.DialogResult.Yes)
            {
                System.Windows.Forms.Application.Exit();
            }

        }

        private void updateProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateProFile FrmUpdateProFile = new updateProFile();
            FrmUpdateProFile.Show();
        }
    }
}
