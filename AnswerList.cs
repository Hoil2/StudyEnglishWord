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
    public partial class frmAnswerList : Form
    {
        int index;
        List<string> tempAnswerList;
        public frmAnswerList(int i)
        {
            InitializeComponent();

            index = i;
        }

        private void frmAnswerList_Load(object sender, EventArgs e)
        {
            tempAnswerList = FileMng.wordDatas[index].answer;
            Text = FileMng.wordDatas[index].word;
            foreach (var item in FileMng.wordDatas[index].answer)
            {
                lstAnswer.Items.Add(item);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtInput.Text.Equals("")) return;

            lstAnswer.Items.Add(txtInput.Text);
            txtInput.Text = "";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstAnswer.SelectedIndex == -1) return;

            lstAnswer.Items.RemoveAt(lstAnswer.SelectedIndex);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            FileMng.wordDatas[index].answer.Clear();

            foreach (var item in lstAnswer.Items)
                FileMng.wordDatas[index].answer.Add(item.ToString());

            FileMng.SaveData();
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmAnswerList_FormClosing(object sender, FormClosingEventArgs e)
        {
            FileMng.wordDatas[index].answer = tempAnswerList;
        }
    }
}
