using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudyEnglishWord
{
    public partial class frmMain : Form
    {
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);


        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            frmCheckWords frmCheckWords = new frmCheckWords();
            frmCheckWords.MdiParent = this;
            frmCheckWords.Dock = DockStyle.Fill;
            frmCheckWords.Show();

            //for (int i = 0; i < FileMng.wordDatas.Length; i++)
            //{
            //    if (FileMng.wordDatas[i].word.Equals("in advance"))
            //    {
            //        if (FileMng.wordDatas[i].answer.Count > 0)
            //        {
            //            MessageBox.Show(FileMng.wordDatas[i].answer[0]);
            //            FileMng.wordDatas[i].answer.Clear();
            //            MessageBox.Show(FileMng.wordDatas[i].answer.Count.ToString());
            //            //FileMng.SaveData();
            //            break;
            //        }
            //    }
            //}
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 컴퓨터 종료가 아닐 때, 문제를 풀지 않았다면 종료 x
            if (!frmStudy.completed && e.CloseReason != CloseReason.WindowsShutDown)
                e.Cancel = true;
            else e.Cancel = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ShowWindowAsync(Handle, 1);

            SetForegroundWindow(Handle);
        }
    }
}
