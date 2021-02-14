using Microsoft.Win32;
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
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        public static int LearnedWords
        {
            get
            {
                return FileMng.wordDatas.Count(x => x.cnt > 0);
            }
        }
        string strAppName = "StudyEnglishWord";
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            using (RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true))
            {
                try
                {  
                    if (rk.GetValue(strAppName) == null) 
                    { 
                        rk.SetValue(strAppName, Application.ExecutablePath.ToString()); 
                    }
                    rk.Close(); 
                } 
                catch (Exception ex) 
                { 
                    MessageBox.Show("오류: " + ex.Message.ToString()); 
                } 
            }
            RefreshFormText();

            //frmStudy frmStudy = new frmStudy();
            //frmStudy.MdiParent = this;
            //frmStudy.Dock = DockStyle.Fill;
            //frmStudy.Show();
            ShowWindowAsync(Handle, 2);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 컴퓨터 종료가 아닐 때, 문제를 풀지 않았다면 종료 x
            if (e.CloseReason != CloseReason.WindowsShutDown)
                e.Cancel = true;
            else e.Cancel = false;
        }

        // 처음 실행됬을 땐 interval = 1000, 정각에 한번 실행 된 후로 1시간 후 실행
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.Minute == 0)
            {
                RefreshFormText();
                ShowWindowAsync(Handle, 1);
                SetForegroundWindow(Handle);
                timer1.Interval = 360000;
                Show();

                frmCheckWords frmCheckWords = new frmCheckWords();
                frmCheckWords.MdiParent = this;
                frmCheckWords.Dock = DockStyle.Fill;
                frmCheckWords.Show();
            }
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = false; //창을 보이지 않게 한다.
                this.ShowIcon = false; //작업표시줄에서 제거.

                notify.Visible = true; //트레이 아이콘을 표시한다.
            }
        }

        public void RefreshFormText()
        {
            Text = LearnedWords + "/" + FileMng.wordDatas.Count;
        }
    }
}
