using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    Dictionary<string, string[]> talkData;

    void Awake()
    {
        talkData = new Dictionary<string, string[]>();
        GenerateData();
    }

    void GenerateData()
    {
        talkData.Add("TestNPC0", new string[] {
            "안녕 어서 와 ! HSU_ON에 온 걸 환영해 !!",
            "지금부터 내 소개를 해줄게 !나는 퀘스트 가이드 상상부기야 ! 만나서 반가워 ~!",
            "자! 지금부터 나와 같이 몇 가지 퀘스트를 진행할거야 ! 학교에 곳곳에 있는 나를 찾아와서 미션을 수행하면 돼 !",
            "퀘스트의 미션을 완료하면 내가 스탬프를 하나씩 찍어주도록 하지 ! 모든 미션을 완료하면 상품이 기다리고 있으니 기대해도 좋아 ~",
            "바로 시작하자 ! 준비됐지 ?"
        });
        talkData.Add("TestNPC1", new string[] {
            "어 !! 여기야 여기 !!",
            "잘 찾아왔구나 ~여기가 미래관이라는 건물이야 !",
            "미래관에는 학교 도서관과 독서실 등 자유롭게 공부할 수 있는 공간이 구비되어 있어 !",
            "다음에 꼭 나랑 같이 공부하기야 ~약속 !!",
            "자 ! 첫 번째 미션은 학교를 돌아다녀서 암호를 찾아볼 거야 !",
            "내가 근처에 암호를 숨겨놨어 !숨겨진 암호를 찾고 나를 찾아와서 암호를 맞추면 미션 클리어야 ~ ",
            "미션 바로 시작해 볼까 ??"
        });
        talkData.Add("TestNPC0_Yes", new string[]
        {
            "굳구구구구구구구구",
            "멋지군",
            "1111111111",
            "222222222222"
        });
        talkData.Add("TestNPC0_No", new string[]
        {
            "빠이빠이빠이빠이빠이",
            "수고해 학생 ~",
            "1111111111111",
            "2222222222222222",
            "3333333333333"
        });
    }

    public string GetTalk(string name, int talkIndex)
    {
        return talkData[name][talkIndex];
    }
    public int getSize(string name)
    {
        return talkData[name].Length;
    }
}
