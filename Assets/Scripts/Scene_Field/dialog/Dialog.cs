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
        //talkData.Add("NPC, new string[]{}); 
        //talkData.Add("NPC_Yes, new string[]{});
        //talkData.Add("NPC_No, new string[]{});
        talkData.Add("TestNPC0", new string[] {
            "안녕 어서 와 ! HSU_ON에 온 걸 환영해 !!",
            "지금부터 내 소개를 해줄게 ! 나는 너희들의 오리엔테이션을 도와줄 상상부기야 ! 만나서 반가워 ~! ",
            "학교에 대해서 아직 잘 모르겠지만 이곳은 우리 한성대학교 캠퍼스를 똑같이 제작했어! ",
            "천천히 둘러보면서 우리학교의 건물들이 뭐가 있는지 잘 확인해봐! ",
            "자! 지금부터 나와 같이 몇 가지 미션을 진행할거야 ! 내가 미션을 주면 너가 수행한 다음에 나를 찾아오면 돼!",
            "미션을 완료하면 내가 스탬프를 하나씩 찍어주도록 하지 ! 모든 미션을 완료하면 상품이 기다리고 있으니 기대해도 좋아 ~ ",
            "바로 시작하자 ! 준비됐지 ? "
        });
        talkData.Add("TestNPC0_Yes", new string[]
        {
            "좋아 ~ 잘 선택했어! 위에 퀘스트 창이 생겼을 거야 ! 첫 번째 미션은 미래관 앞에 있는 나를 찾으면 알려줄게 ~ ",
            "응 ?? 미래관이 어딘지 모르겠다고 ? ",
            "미래관은 정문에서 바로 오른쪽에 보면 있을 거야 ! 그럼 기다리고 있을게 ~ "
        });
        talkData.Add("TestNPC0_No", new string[]
        {
            "흥! 어쩔 수 없지.. ",
            "준비가 되면 언제든 돌아와! 기다리고 있을게~ "
        });

        talkData.Add("TestNPC1", new string[] {
            "이 곳은 학생들이 자유롭게 공부할 수 있는 학술정보관, 미래관이야 ! ",
            "미래관 지하에는 그라찌에 카페와 문서들을 출력할 수 있는 프린터실이 구비되어있어!",
            "학술정보관 1층에는 열린 공간에서 공부할 수 있는 공간이 마련되어있고~ ",
            "2층과 3층은 각종 도서들을 대여할 수 있는 도서관, 팀프로젝트를 수행할 수 있는 공간이 있어 ! ",
            "그중에서도 대표적인 공간이라고 할 수 있는 곳은 바로 창의열람실이야! 창의열람실은 학술정보관 3층에 있지~ ",
            "그밖에도 4,5,6층에 친구들이 공부할 수 있는 집중열람실, 상상커먼스 등이 있어! 나중에 꼭 공부하러 오기다~? ",
            "자 이제 설명을 잘 들었는지 퀴즈를 낼거야! 준비됐지? 그럼 시작한다~! ",
            "학술정보관의 대표적인 시설 이름은?\n(힌트: ㅊㅇㅇㄹㅅ) "
        });
        talkData.Add("TestNPC1_Yes", new string[]{
            "정답!! ",
            "첫 번째 미션 클리어야! 이어서 두 번째 미션을 하고싶으면 상상관으로 오면 돼! 그럼 먼저 가서 기다리고 있을게~ "
        });
        talkData.Add("TestNPC1_No", new string[]{
            "틀렸어! 다시한번 풀어볼까? ",
            "준비가 되면 다시 말을 걸어줘 ~ "
        });
        talkData.Add("TestNPC1_Mission", new string[]
        {
            "벌써 찾았누? ",
            "쉐끼 굳 ",
            "까까가까까까까깎 "
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
