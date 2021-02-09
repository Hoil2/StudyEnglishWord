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
    public partial class frmMain : Form
    {
        // 컴파일러 환경에서 실행
        // 영어 문장 가져오는 용
        

        public frmMain()
        {
            InitializeComponent();
            
            MaximizeBox = false;

            frmCheckWords frmCheckWords = new frmCheckWords();
            frmCheckWords.Show();

            this.Hide();
            //MessageBox.Show(FileMng.wordDatas[0].word);
            //foreach (var item in FileMng.words)
            //{
            //    listBox1.Items.Add(item);
            //}
            
        }
    }
}
