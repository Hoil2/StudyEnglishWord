using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyEnglishWord
{
    class WordSelection
    {
        public static int studyWordNum;
        public static List<int> SelectStudyWords()
        {
            List<int> _indexList = new List<int>();
            List<int> indexList = new List<int>();
            for (int i = 0; i < FileMng.wordDatas.Count; i++)
            {
                if(FileMng.wordDatas[i].cnt == 0)
                {
                    _indexList.Add(i);
                }
            }
            
            if(_indexList.Count > studyWordNum)
            {
                for (int i = 0; i < studyWordNum; i++)
                {
                    int idx = new Random().Next(0, _indexList.Count);
                    if(indexList.Exists(x => x.Equals(idx)))
                    {
                        i--;
                        continue;
                    }
                    indexList.Add(idx);
                }
            }

            return indexList;
        }

        public static List<int> SelectReviewWords()
        {
            List<int> indexList = new List<int>();
            for (int i = 0; i < FileMng.wordDatas.Count; i++)
            {
                if (FileMng.wordDatas[i].date == DateTime.MinValue) continue;
                if (DateTime.Now >= FileMng.wordDatas[i].date)
                {
                    indexList.Add(i);
                }
            }

            return indexList;
        }
    }
}
