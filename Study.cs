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
        public const int fontSize = 11;
        public static bool completed;
        List<Label> lblQuestion, lblAnswerShow;
        List<TextBox> txtAnswer;
        List<int> indexList;
        public frmStudy()
        {
            InitializeComponent();
            lblQuestion = new List<Label>();
            lblAnswerShow = new List<Label>();
            txtAnswer = new List<TextBox>();

            List<int> indexList = WordSelection.SelectReviewWords();

            foreach (var i in indexList)
                AddMeaningQuizSlot(FileMng.wordDatas[i].word);

            Button btnScoring = new Button();
            btnScoring.Text = "제출";
            btnScoring.Font = new Font(Font.FontFamily, 12);
            btnScoring.Size = new Size(75, 47);
            btnScoring.Location = new Point(96, 30 + lblQuestion.Count * 80);

            btnScoring.Click += btnSubmit_Click;

            Controls.Add(btnScoring);
        }
        
        /// <summary>
        /// 단어 보여주고 뜻 맞추는 슬롯 추가
        /// </summary>
        void AddMeaningQuizSlot(string que)
        {
            // 단어
            Label question = new Label();
            question.Text = (lblQuestion.Count + 1) + ". " + que;
            question.Font = new Font(Font.FontFamily, fontSize);
            question.Size = new Size(250, 23);
            question.Location = new Point(60, 40 + lblQuestion.Count * 80);

            Label answerShow = new Label();
            answerShow.Text = "";
            answerShow.Font = new Font(Font.FontFamily, fontSize);
            answerShow.Size = new Size(20, 23);
            answerShow.Location = new Point(42, 40 + lblQuestion.Count * 80);

            // 정답칸
            TextBox answer = new TextBox();
            answer.Font = new Font(Font.FontFamily, fontSize);
            answer.Size = new Size(120, 25);
            answer.Location = new Point(63, 63 + lblQuestion.Count * 80);

            lblQuestion.Add(question);
            lblAnswerShow.Add(answerShow);
            txtAnswer.Add(answer);

            Controls.Add(question);
            Controls.Add(answerShow);
            Controls.Add(answer);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            bool activeCancel = true;
            for(int i = 0; i < indexList.Count; i++)
            {
                if (FileMng.wordDatas[indexList[i]].answer.Exists(x => x.Equals(txtAnswer[i].Text)))
                {
                    lblAnswerShow[i].Text = "○";
                    lblAnswerShow[i].ForeColor = Color.Black;
                }
                else
                {
                    lblAnswerShow[i].Text = "×";
                    lblAnswerShow[i].ForeColor = Color.Red;
                    activeCancel = false;
                }
            }

            if (!activeCancel) return;

            foreach (var i in indexList)
                FileMng.wordDatas[i].date = AddDate(FileMng.wordDatas[i].cnt++);

            FileMng.SaveData();

            Button btnCancel = new Button();
            btnCancel.Text = "닫기";
            btnCancel.Font = new Font(Font.FontFamily, 12);
            btnCancel.Size = new Size(75, 47);
            btnCancel.Location = new Point(180, 30 + lblQuestion.Count * 80);
            btnCancel.Click += new EventHandler(delegate
            {
                completed = true;
                MdiParent.Close();
            });

            Controls.Add(btnCancel);
        }
        DateTime AddDate(int cnt)
        {
            DateTime dateTime;
            if(cnt == 0)
                dateTime = DateTime.Now.AddHours(1);
            else if (cnt == 1)
                dateTime = DateTime.Now.AddDays(1);
            else if(cnt == 2)
                dateTime = DateTime.Now.AddDays(7);
            else if(cnt == 3)
                dateTime = DateTime.Now.AddDays(30);
            else if (cnt == 4)
                dateTime = DateTime.Now.AddDays(180);
            else
                dateTime = DateTime.Now.AddDays(360);

            return dateTime;
        }
    }
}