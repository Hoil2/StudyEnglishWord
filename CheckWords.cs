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

        List<int> indexList;
        public frmCheckWords()
        {
            InitializeComponent();

            indexList = WordSelection.SelectStudyWords();

            if(indexList.Count == 0)
            {
                frmStudy = new frmStudy();
                frmStudy.MdiParent = MdiParent;
                frmStudy.Dock = DockStyle.Fill;
                frmStudy.Show();
                Close();
            }

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
                frmAnswerList frmAnswerList = new frmAnswerList(index);
                frmAnswerList.Show();
            });

            lblWordList.Add(lblWord);
            Controls.Add(lblWord);
            Controls.Add(btnAnswerList);
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
            foreach (var i in indexList)
            {
                if (FileMng.wordDatas[i].answer.Count == 0)
                {
                    MessageBox.Show(FileMng.wordDatas[i].word + "의 정답을 입력해주세요");
                    return;
                }
            }

            foreach (var i in indexList)
            {
                FileMng.wordDatas[i].cnt++;
                FileMng.wordDatas[i].date = DateTime.Now.AddHours(1);
                MessageBox.Show(FileMng.wordDatas[i].date.ToString("yyyy-MM-dd-HH"));
            }

            frmStudy = new frmStudy();
            frmStudy.MdiParent = MdiParent;
            frmStudy.Dock = DockStyle.Fill;
            frmStudy.Show();
            Close();
        }
    }
}
