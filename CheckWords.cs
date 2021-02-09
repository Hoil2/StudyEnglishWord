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
    public partial class frmCheckWords : Form
    {
        frmBrowser frmBrowser = null;
        frmStudy frmStudy = null;

        List<Label> lblWordList = new List<Label>();
        List<TextBox> txtAnswerList = new List<TextBox>();
        public frmCheckWords()
        {
            InitializeComponent();

            List<int> indexList = WordSelection.SelectStudyWords();

            foreach(var i in indexList)
                AddWordSlot(i);
            //lblWord1.Text = indexList[0];
        }

        void AddWordSlot(int index)
        {
            Label lblWord = new Label();
            lblWord.Text = (lblWordList.Count + 1) + ". " + FileMng.wordDatas[index].word;
            lblWord.Size = new Size(200, 18);
            lblWord.Location = new Point(26, 112 + lblWordList.Count * 63);
            

            //TextBox txtAnswer = new TextBox();
            //txtAnswer.Size = new Size(100, 25);
            //txtAnswer.Location = new Point(171, 112 + lblWordList.Count * 63);
            //txtAnswer.KeyDown += KeyEvent;
            //txtAnswerList.Add(txtAnswer);

            Button btnAnswerList = new Button();
            btnAnswerList.Text = "정답";
            btnAnswerList.Size = new Size(48, 23);
            btnAnswerList.Location = new Point(26, 130 + lblWordList.Count * 63);
            btnAnswerList.Click += new EventHandler(delegate
            {
                //frmAnswerList frmAnswerList = new frmAnswerList(index);
                //frmAnswerList.Show();
            });

            lblWordList.Add(lblWord);
            Controls.Add(lblWord);
            Controls.Add(btnAnswerList);
        }

        private void KeyEvent(object sender, KeyEventArgs e)
        {
            if(e.KeyCode.Equals(Keys.Enter))
            {
                
            }
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

        private void btnStart_Click(object sender, EventArgs e)
        {
            frmStudy = new frmStudy();
            frmStudy.Show();
            //Close();
        }
    }
}
