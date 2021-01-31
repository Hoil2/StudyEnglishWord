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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FileMng.LoadWords();
            FileMng.LoadData();

            //foreach (var item in FileMng.words)
            //{
            //    listBox1.Items.Add(item);
            //}
            
        }
    }
}
