using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;//대화 데이터 저장

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    // Update is called once per frame
    void GenerateData()
    {
       talkData.Add(100, new string[] { "안녕! 난 100번 npc야" });

    }
    
    /*public string GetTalk(int id, int talkIndex)//대사를 전달
	{
        return TalkData[id][talkIndex];
	}
    */
}  
