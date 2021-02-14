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

        List<int> indexList;
        List<frmAnswerList> frmAnswerLists;
        List<int> removeList;
        public frmCheckWords()
        {
            InitializeComponent();
        }

        private void frmCheckWords_Load(object sender, EventArgs e)
        {
            indexList = WordSelection.SelectStudyWords();
            frmAnswerLists = new List<frmAnswerList>();
            removeList = new List<int>();

            if (indexList.Count == 0)
            {
                frmStudy = new frmStudy();
                frmStudy.MdiParent = MdiParent;
                frmStudy.Dock = DockStyle.Fill;
                frmStudy.Show();
                Close();
            }

            foreach (var i in indexList)
            {
                AddWordSlot(i);
            }
        }
        
        void AddWordSlot(int index)
        {
            Label lblWord = new Label();
            lblWord.Text = (lblWordList.Count + 1) + ". " + FileMng.wordDatas[index].word;
            lblWord.Size = new Size(200, 18);
            lblWord.Location = new Point(26, 112 + lblWordList.Count * 63);

            Button btnAnswerList = new Button();
            btnAnswerList.Text = "정답";
            btnAnswerList.Size = new Size(48, 23);
            btnAnswerList.Location = new Point(26, 130 + lblWordList.Count * 63);
            btnAnswerList.Click += new EventHandler(delegate
            {                
                FormCollection fc = Application.OpenForms;
                foreach (Form frm in fc)
                {
                    if (frm.Name.Equals(index.ToString()))
                        return;
                }
                frmAnswerList frmAnswerList = new frmAnswerList(index);
                frmAnswerList.Name = index.ToString();
                frmAnswerList.Show();
                frmAnswerLists.Add(frmAnswerList);
                Clipboard.SetText(FileMng.wordDatas[index].word);
            });

            Button btnWordRemove = new Button();
            btnWordRemove.Text = "삭제";
            btnWordRemove.Size = new Size(48, 23);
            btnWordRemove.Location = new Point(78, 130 + lblWordList.Count * 63);
            btnWordRemove.Click += new EventHandler(delegate
            {
                if (MessageBox.Show("단어를 삭제하시겠습니까?", "Notice", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Controls.Remove(lblWord);
                    Controls.Remove(btnAnswerList);
                    Controls.Remove(btnWordRemove);
                    removeList.Add(index);
                    indexList.Remove(index);
                    MdiParent.Text = frmMain.LearnedWords + "/" + FileMng.wordDatas.Count;
                }
            });

            lblWordList.Add(lblWord);
            Controls.Add(lblWord);
            Controls.Add(btnAnswerList);
            Controls.Add(btnWordRemove);
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
                FileMng.wordDatas[i].date = DateTime.Now.AddMinutes(58);
            }

            // 단어 삭제
            foreach(var i in removeList)
            {
                FileMng.wordDatas.RemoveAt(i);
            }

            FileMng.SaveData();

            if (frmBrowser != null)
                frmBrowser.Close();

            frmAnswerLists.Clear();

            List<int> indexReviewList = WordSelection.SelectReviewWords();
            if (indexReviewList.Count == 0)
            {
                frmMain.ShowWindowAsync(MdiParent.Handle, 2);
                Close();
                return;
            }

            frmStudy = new frmStudy();
            frmStudy.MdiParent = MdiParent;
            frmStudy.Dock = DockStyle.Fill;
            frmStudy.Show();
            Close();
        }
    }
}
