using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class typingeffect : MonoBehaviour
{
    public Image Talk;
    public Text Talktext;
    public Button Yesbutton;
    public Button Nobutton;
    public Button Nextbutton;
    public Button Exitbutton;
    /*Dictionary<string, string> mapName = new Dictionary<string, string>();
    //변수 동적 선언 Map 사용*/

    private List<string> ot0 = new List<string>()
    {"안녕 어서 와 ! HSU_ON에 온 걸 환영해 !!",
    "지금부터 내 소개를 해줄게 ! 나는 너희들의 오리엔테이션을 도와줄 상상부기야 ! 만나서 반가워 ~!",
    "학교에 대해서 아직 잘 모르겠지만 이곳은 우리학교 캠퍼스와 비슷하게 제작했어 !",
    "천천히 둘러보면서 우리학교의 건물들이 뭐가 있는지 잘 확인해봐!",
    "자! 지금부터 나와 같이 몇 가지 미션을 진행할거야 ! 내가 미션을 주면 너가 수행한 다음에 나를 찾아오면 돼!",
    "미션을 완료하면 내가 스탬프를 하나씩 찍어주도록 하지 ! 모든 미션을 완료하면 상품이 기다리고 있으니 기대해도 좋아 ~",
    "바로 시작하자 ! 준비됐지?",
    "흥! 어쩔 수 없지.. 준비가 되면 언제든 돌아와! 기다리고 있을게~ ",//no
    "좋아 ~ 잘 선택했어! 위에 퀘스트 창이 생겼을 거야 ! 첫 번째 미션은 미래관 앞에 있는 나를 찾으면 알려줄게 ~",//yes
    "응 ?? 미래관이 어딘지 모르겠다고 ?",
    "미래관은 정문에서 바로 오른쪽에 보면 있을 거야 ! 그럼 기다리고 있을게 ~" };
    //chat dialog List

    public int clickcount = 0;


    // Start is called before the first frame update
    void Start()
    {

    }

    public void TypingEffect()
    {
        StartCoroutine(_typing());
    }

    public void ButtonClickCount()
    {
        clickcount += 1;
        
    }

    IEnumerator _typing()
    {
       
        Nextbutton.gameObject.SetActive(false);
        for (int i = 0; i < ot0[clickcount-1].ToString().Length; i++)
        {
            Talktext.text = ot0[clickcount-1].Substring(0, i);
            yield return new WaitForSeconds(0.01f);

            if (clickcount == 7)//ot0 yes or no
            {
                //yes or no button
                Yesbutton.gameObject.SetActive(true);
                Nobutton.gameObject.SetActive(true);
                Nextbutton.gameObject.SetActive(false);//해결해야함
                Nobutton.onClick.AddListener(ClickNoButtton);
                Yesbutton.onClick.AddListener(ClickYesButton);
            }

            if (clickcount - 1 >= ot0.Count)
            //ot0리스트의 요소의 값보다 clickcount가 같거나 크다면 talk 종료,clickcount 리셋 
            {
                Debug.Log("end");
                StopCoroutine(_typing());
                Talk.gameObject.SetActive(false);
                clickcount = 0;

            }


        }
        Nextbutton.gameObject.SetActive(true);
        Debug.Log(clickcount);
    }
    public void ClickExit()
	{
        Talk.gameObject.SetActive(false);
        //ot0리스트에 null값 반환시 dialog 종료
	}
    public void ClickNoButtton()
	{
        Yesbutton.gameObject.SetActive(false);
        Nobutton.gameObject.SetActive(false);
        clickcount = 8;
        StartCoroutine(_typing());
    }
    public void ClickYesButton()
	{
        Yesbutton.gameObject.SetActive(false);
        Nobutton.gameObject.SetActive(false);
        clickcount = 9;
        StartCoroutine(_typing());
    }
}
