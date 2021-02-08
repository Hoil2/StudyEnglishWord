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

        List<Label> lblQuestion;
        List<TextBox> txtAnswer;
        public frmStudy()
        {
            InitializeComponent();
            lblQuestion = new List<Label>();
            txtAnswer = new List<TextBox>();

            AddMeaningQuizSlot(FileMng.wordDatas[0].word);
            AddMeaningQuizSlot(FileMng.wordDatas[1].word);
            AddMeaningQuizSlot(FileMng.wordDatas[2].word);
        }
        
        /// <summary>
        /// 단어 보여주고 뜻 맞추는 슬롯 추가
        /// </summary>
        void AddMeaningQuizSlot(string que)
        {
            // 단어
            Label question = new Label();
            question.Text = que;
            question.Font = new Font(Font.FontFamily, fontSize);
            question.Location = new Point(60, 60 + lblQuestion.Count * 80);

            // 정답칸
            TextBox answer = new TextBox();
            answer.Font = new Font(Font.FontFamily, fontSize);
            answer.Size = new Size(120, 25);
            answer.Location = new Point(63, 83 + lblQuestion.Count * 80);

            lblQuestion.Add(question);
            txtAnswer.Add(answer);

            Controls.Add(question);
            Controls.Add(answer);
        }
    }
}

