using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudyEnglishWord
{
    [Serializable]
    public class WordData
    {
        public string word;
        public DateTime date;
        public int cnt;
        public List<string> answer;
        public WordData()
        {
            answer = new List<string>();
            word = "";
            cnt = 0;
        }
    }

    public class FileMng
    {
        public static WordData[] wordDatas = new WordData[4672];
        
        
        public static List<string> words = new List<string>();
        public static string dataPath = @"data.dat";
        public static string wordsPath = @"7000words.txt";

        static void Init()
        {
            for (int i = 0; i < wordDatas.Length; i++) 
            {
                wordDatas[i] = new WordData();
            }
        }

        public static void LoadData()
        {
            FileInfo fileInfo = new FileInfo(dataPath);
            if (fileInfo.Exists)
            {
                using (FileStream fs = new FileStream(dataPath, FileMode.OpenOrCreate))
                {
                    BinaryFormatter binary = new BinaryFormatter();
                    try
                    {
                        wordDatas = (WordData[])binary.Deserialize(fs);
                    }
                    catch(Exception ex) 
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        public static void SaveData()
        {
            using (FileStream fs = new FileStream(dataPath, FileMode.Create, FileAccess.Write))
            {
                BinaryFormatter binary = new BinaryFormatter();
                binary.Serialize(fs, wordDatas);
            }
        }

        public static void LoadWords()
        {
            string wordList = File.ReadAllText(wordsPath);

            string word = "";
            int isEnglishWord = 0;
            for (int i = 0; i < wordList.Length; i++)
            {
                if (wordList[i] >= 'a' && wordList[i] <= 'z' || (wordList[i] == ' ' && word.Length != 0))
                {
                    if(EndSpaceCount(word) >= 2) // 공백이 2개 이상일 때 추가
                    {
                        AddWord(word);
                        word = "";
                        continue;
                    }
                    isEnglishWord = 0;
                    word += wordList[i];
                }
                else
                {
                    isEnglishWord++;
                    if (isEnglishWord >= 2) // 영어가 아닌 다른 숫자가 2번 이상 나왔을 때
                    {
                        AddWord(word);      // 알파벳이 하나라도 포함되어 있을 때 추가
                        word = "";
                    }
                }
            }
        }

        public static void LoadWordToData()
        {
            Init();
            LoadWords(); // 4672단어
            for (int i = 0; i < wordDatas.Length; i++)
            {
                wordDatas[i].word = words[i];
            }
            SaveData();
            MessageBox.Show("로드 & 세이브 성공");
        }


        //-----------------------------------------

        static int EndSpaceCount(string word)
        {
            int cnt = 0;
            for(int i = word.Length -1; i >= 0; i--)
            {
                if (word[i] == ' ') cnt++;
                else break;
            }
            return cnt;
        }

        static void AddWord(string word)
        {
            if (word.Length != 0)
            {
                word = RemoveEndSpace(word);
                words.Add(word);
            }
        }


        static string RemoveEndSpace(string str)
        {
            int i = str.Length - 1;
            while (i >= 0)
            {
                if (str[i] == ' ')
                {
                    str = str.Remove(i);
                    i = str.Length - 1;
                }
                else break;

            }
            return str;
        }
    }
}
