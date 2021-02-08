using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudyEnglishWord
{
    public partial class frmStudy : Form
    {
        frmBrowser frmBrowser = null;
        public frmStudy()
        {
            InitializeComponent();
        }

        private void btnDictSearch_Click(object sender, EventArgs e)
        {
            FormCollection fc = Application.OpenForms;
            foreach(Form frm in fc)
            {
                if (frm.Name.Equals("frmBrowser"))
                    return;
            }
            frmBrowser = new frmBrowser();
            frmBrowser.Name = "frmBrowser";
            frmBrowser.Show();
        }
    }
}
