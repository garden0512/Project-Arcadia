using System.Collections.Generic;
using UnityEngine;

namespace Arcadia.UI.Dialogue
{
    public class TalkManager : MonoBehaviour
    {
        private Dictionary<int, string[]> talkData;

        private void Awake()
        {
            talkData = new Dictionary<int , string[]>();
            GenerateData();
        }

        public void GenerateData()
        {
            talkData.Add(2100, new string[] {"데모입니다","ㄹㅈㄷ"});
            talkData.Add(100, new string[] {"단단한 로봇인 것 같네.", "전원이 없는 것 같아."});
        }

        public string GetTalk(int id, int talkIndex)
        {
            if (talkIndex == talkData[id].Length)
            {
                return null;
            }
            else
            {
                return talkData[id][talkIndex];
            }
        }
    }
}