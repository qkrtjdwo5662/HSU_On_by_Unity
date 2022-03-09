using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;
using Firebase;
using Firebase.Database;
using System.Threading.Tasks;
using Firebase.Extensions;

public class RandomBox : MonoBehaviour
{    
    //Join.cs
    public Join join;
    //FirebaseAuth auth;

    //돈
    public int money;
    //돈
    
    public Text MyMoney;
    public Text MyMoneyP;
    public int itemCount;
    public GameObject NomoneyPanel;
    public GameObject DrawShop;
    public GameObject DrawWindow;
    public GameObject S;
    public GameObject A;
    public GameObject B;
    public GameObject GatchaPanel;
    public Image DrawImage;
    //인벤 채울 이미지
    //머리 색
    public Image HCS1; //HCS1
    public Image HCS2; //HCS2
    public Image HCA1; //HCA1
    public Image HCA2;
    public Image HCA3;
    public Image HCB1;
    public Image HCB2;
    public Image HCB3;
    public Image HCB4;
    public Image HCB5;
    
    public Sprite HCImage1;
    public Sprite HCImage2;
    public Sprite HCImage3;
    public Sprite HCImage4;
    public Sprite HCImage5;
    public Sprite HCImage6;
    public Sprite HCImage7;
    public Sprite HCImage8;
    public Sprite HCImage9;
    public Sprite HCImage10;

    public Button HCSlot1;
    public Button HCSlot2;
    public Button HCSlot3;
    public Button HCSlot4;
    public Button HCSlot5;
    public Button HCSlot6;
    public Button HCSlot7;
    public Button HCSlot8;
    public Button HCSlot9;
    public Button HCSlot10;
    //머리색 끝

    //펫
    public Image PS1;
    public Image PS2;
    public Image PA1;
    public Image PA2;
    public Image PA3;
    public Image PB1;
    public Image PB2;
    public Image PB3;
    public Image PB4;
    public Image PB5;

    public Sprite PImage1;
    public Sprite PImage2;
    public Sprite PImage3;
    public Sprite PImage4;
    public Sprite PImage5;
    public Sprite PImage6;
    public Sprite PImage7;
    public Sprite PImage8;
    public Sprite PImage9;
    public Sprite PImage10;

    public Button PSlot1;
    public Button PSlot2;
    public Button PSlot3;
    public Button PSlot4;
    public Button PSlot5;
    public Button PSlot6;
    public Button PSlot7;
    public Button PSlot8;
    public Button PSlot9;
    public Button PSlot10;
    //펫 끝

    //상의
    public Image CS1;
    public Image CS2;
    public Image CA1;
    public Image CA2;
    public Image CA3;
    public Image CB1;
    public Image CB2;
    public Image CB3;
    public Image CB4;
    public Image CB5;

    public Sprite CImage1;
    public Sprite CImage2;
    public Sprite CImage3;
    public Sprite CImage4;
    public Sprite CImage5;
    public Sprite CImage6;
    public Sprite CImage7;
    public Sprite CImage8;
    public Sprite CImage9;
    public Sprite CImage10;

    public Button CSlot1;
    public Button CSlot2;
    public Button CSlot3;
    public Button CSlot4;
    public Button CSlot5;
    public Button CSlot6;
    public Button CSlot7;
    public Button CSlot8;
    public Button CSlot9;
    public Button CSlot10;
    //상의 끝

    //하의
    public Image BS1;
    public Image BS2;
    public Image BA1;
    public Image BA2;
    public Image BA3;
    public Image BB1;
    public Image BB2;
    public Image BB3;
    public Image BB4;
    public Image BB5;

    public Sprite BImage1;
    public Sprite BImage2;
    public Sprite BImage3;
    public Sprite BImage4;
    public Sprite BImage5;
    public Sprite BImage6;
    public Sprite BImage7;
    public Sprite BImage8;
    public Sprite BImage9;
    public Sprite BImage10;

    public Button BSlot1;
    public Button BSlot2;
    public Button BSlot3;
    public Button BSlot4;
    public Button BSlot5;
    public Button BSlot6;
    public Button BSlot7;
    public Button BSlot8;
    public Button BSlot9;
    public Button BSlot10;
    //하의 끝    
    public int RandomInt;
    // Start is called before the first frame update


    void Start()
    {
        join = GameObject.Find("Join").GetComponent<Join>();
        StartCoroutine(WaitQuery());
    }
    IEnumerator WaitQuery() {
        while (true) {
            if (join.isQueryEnd) {
                SettingInventory();
                break;
            }
            yield return null;
        }
    }

    void SettingInventory()
    {
        money = int.Parse(join.money);
        MyMoney.text = money.ToString();
                    Debug.Log("Money get & save");

        //MyMoneyP.text = money.ToString();
        
        int rand = Random.Range(0, GachaList.Count);
        
        //머리색 시작
        if (join.hair01.Equals("True"))
		{
            DrawImage.sprite = HCImage1; //슈퍼레어
            S.SetActive(true);
            HCS1.sprite = HCImage1;
            HCSlot1.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("HC01");
            Debug.Log("HC01 get & save");
        }

        if(join.hair02.Equals("True"))
		{
            DrawImage.sprite = HCImage2; //슈퍼레어
            A.SetActive(true);
            HCS2.sprite = HCImage2;
            HCSlot2.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("HC02");
            Debug.Log("HC02 get & save");
        }

        if (join.hair03.Equals("True"))
		{
            DrawImage.sprite = HCImage3; //레어
            A.SetActive(true);
            HCSlot3.interactable = true;
            GachaList.RemoveAt(rand);
            HCA1.sprite = HCImage3;
            join.SetValueFireBase("HC03");
            Debug.Log("HC03 get & save");
        }

        if (join.hair04.Equals("True"))
		{

            DrawImage.sprite = HCImage4; //레어
            A.SetActive(true);
            HCSlot4.interactable = true;
            GachaList.RemoveAt(rand);
            HCA2.sprite = HCImage4;
            join.SetValueFireBase("HC04");
            Debug.Log("HC04 get & save");
        }

        if (join.hair05.Equals("True"))
		{
            DrawImage.sprite = HCImage5; //레어
            A.SetActive(true);
            HCSlot5.interactable = true;
            GachaList.RemoveAt(rand);
            HCA3.sprite = HCImage5;
            join.SetValueFireBase("HC05");
            Debug.Log("HC05 get & save");
        }

        if (join.hair06.Equals("True"))
		{
            DrawImage.sprite = HCImage6; //노멀
            B.SetActive(true);
            HCSlot6.interactable = true;
            GachaList.RemoveAt(rand);
            HCB1.sprite = HCImage6;
            join.SetValueFireBase("HC06");
            Debug.Log("HC06 get & save");
        }

        if (join.hair07.Equals("True"))
		{
            DrawImage.sprite = HCImage7; //노멀
            B.SetActive(true);
            HCSlot7.interactable = true;
            GachaList.RemoveAt(rand);
            HCB2.sprite = HCImage7;
            join.SetValueFireBase("HC07");
            Debug.Log("HC07 get & save");

        }
        if (join.hair08.Equals("True"))
		{
            DrawImage.sprite = HCImage8; //노멀
            B.SetActive(true);
            HCSlot8.interactable = true;
            GachaList.RemoveAt(rand);
            HCB3.sprite = HCImage8;
            join.SetValueFireBase("HC08");
            Debug.Log("HC08 get & save");
        }

        if (join.hair09.Equals("True"))
		{
            DrawImage.sprite = HCImage9; //노멀
            B.SetActive(true);
            HCSlot9.interactable = true;
            GachaList.RemoveAt(rand);
            HCB4.sprite = HCImage9;
            join.SetValueFireBase("HC09");
            Debug.Log("HC09 get & save");
        }

        if (join.hair10.Equals("True"))
		{
            DrawImage.sprite = HCImage10; //노멀
            B.SetActive(true);
            HCSlot10.interactable = true;
            GachaList.RemoveAt(rand);
            HCB5.sprite = HCImage10;
            join.SetValueFireBase("HC10");
            Debug.Log("HC10 get & save");
        }
        //머리색 끝

        //펫 시작
        if (GachaList[rand] == "PS1")
        {
            DrawImage.sprite = PImage1; // 슈퍼레어
            S.SetActive(true);
            PS1.sprite = PImage1;
            PSlot1.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("PET01");
            Debug.Log("PET01 get & save");

        }
        if (GachaList[rand] == "PS2")
        {
            DrawImage.sprite = PImage2; // 슈퍼레어
            S.SetActive(true);
            PS2.sprite = PImage2;
            PSlot2.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("PET02");
            Debug.Log("PET02 get & save");

        }
        if (GachaList[rand] == "PA1")
        {
            DrawImage.sprite = PImage3; // 레어
            A.SetActive(true);
            PA1.sprite = PImage3;
            PSlot3.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("PET03");
            Debug.Log("PET03 get & save");

        }
        if (GachaList[rand] == "PA2")
        {
            DrawImage.sprite = PImage4; // 레어
            A.SetActive(true);
            PA2.sprite = PImage4;
            PSlot4.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("PET04");
            Debug.Log("PET04 get & save");

        }
        if (GachaList[rand] == "PA3")
        {
            DrawImage.sprite = PImage5; // 노멀
            A.SetActive(true);
            PA3.sprite = PImage5;
            PSlot5.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("PET05");
            Debug.Log("PET05 get & save");

        }
        if (GachaList[rand] == "PB1")
        {
            DrawImage.sprite = PImage6; // 노멀
            B.SetActive(true);
            PB1.sprite = PImage6;
            PSlot6.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("PET06");
            Debug.Log("PET06 get & save");

        }
        if (GachaList[rand] == "PB2")
        {
            DrawImage.sprite = PImage7; // 노멀
            B.SetActive(true);
            PB2.sprite = PImage7;
            PSlot7.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("PET07");
            Debug.Log("PET07 get & save");

        }
        if (GachaList[rand] == "PB3")
        {
            DrawImage.sprite = PImage8; // 노멀
            B.SetActive(true);
            PB3.sprite = PImage8;
            PSlot8.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("PET08");
            Debug.Log("PET08 get & save");

        }
        if (GachaList[rand] == "PB4")
        {
            DrawImage.sprite = PImage9; // 노멀
            B.SetActive(true);
            PB4.sprite = PImage9;
            PSlot9.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("PET09");
            Debug.Log("PET09 get & save");

        }
        if (GachaList[rand] == "PB5")
        {
            DrawImage.sprite = PImage10; // 노멀
            B.SetActive(true);
            PB5.sprite = PImage10;
            PSlot10.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("PET10");
            Debug.Log("PET10 get & save");

        }
        //펫 끝

        //상의
        else if (GachaList[rand] == "CS1")
        {
            DrawImage.sprite = CImage1; // 슈퍼레어
            S.SetActive(true);
            CS1.sprite = CImage1;
            CSlot1.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("C01");
            Debug.Log("C01 get & save");

        }
        else if (GachaList[rand] == "CS2")
        {
            DrawImage.sprite = CImage2; // 슈퍼레어
            S.SetActive(true);
            CS2.sprite = CImage2;
            CSlot2.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("C02");
            Debug.Log("C02 get & save");

        }
        else if (GachaList[rand] == "CA1")
        {
            DrawImage.sprite = CImage3; // 레어
            A.SetActive(true);
            CA1.sprite = CImage3;
            CSlot3.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("C03");
            Debug.Log("C03 get & save");

        }
        else if (GachaList[rand] == "CA2")
        {
            DrawImage.sprite = CImage4; // 레어
            A.SetActive(true);
            CA2.sprite = CImage4;
            CSlot4.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("C04");
            Debug.Log("C04 get & save");

        }
        else if (GachaList[rand] == "CA3")
        {
            DrawImage.sprite = CImage5; // 레어
            A.SetActive(true);
            CA3.sprite = CImage5;
            CSlot5.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("C05");
            Debug.Log("C05 get & save");

        }
        else if (GachaList[rand] == "CB1")
        {
            DrawImage.sprite = CImage6; // 노멀
            B.SetActive(true);
            CB1.sprite = CImage6;
            CSlot6.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("C06");
            Debug.Log("C06 get & save");

        }
        else if (GachaList[rand] == "CB2")
        {
            DrawImage.sprite = CImage7; // 노멀
            B.SetActive(true);
            CB2.sprite = CImage7;
            CSlot7.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("C07");
            Debug.Log("C07 get & save");

        }
        else if (GachaList[rand] == "CB3")
        {
            DrawImage.sprite = CImage8; // 노멀
            B.SetActive(true);
            CB3.sprite = CImage8;
            CSlot8.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("C08");
            Debug.Log("C08 get & save");

        }
        else if (GachaList[rand] == "CB4")
        {
            DrawImage.sprite = CImage9; // 노멀
            B.SetActive(true);
            CB4.sprite = CImage9;
            CSlot9.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("C09");
            Debug.Log("C09 get & save");

        }
        else if (GachaList[rand] == "CB5")
        {
            DrawImage.sprite = CImage10; // 노멀
            B.SetActive(true);
            CB5.sprite = CImage10;
            CSlot10.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("C10");
            Debug.Log("C10 get & save");

        }
        //상의 끝


        //하의 시작
        if (GachaList[rand] == "BS1")
        {
            DrawImage.sprite = BImage1; // 슈퍼레어
            S.SetActive(true);
            BS1.sprite = BImage1;
            BSlot1.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("P01");
            Debug.Log("P01 get & save");

        }
        if (GachaList[rand] == "BS2")
        {
            DrawImage.sprite = BImage2; // 슈퍼레어
            S.SetActive(true);
            BS2.sprite = BImage2;
            BSlot2.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("P02");
            Debug.Log("P02 get & save");

        }
        if (GachaList[rand] == "BA1")
        {
            DrawImage.sprite = BImage3; // 슈퍼레어
            A.SetActive(true);
            BA1.sprite = BImage3;
            BSlot3.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("P03");
            Debug.Log("P03 get & save");

        }
        if (GachaList[rand] == "BA2")
        {
            DrawImage.sprite = BImage4; // 슈퍼레어
            A.SetActive(true);
            BA2.sprite = BImage4;
            BSlot4.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("P04");
            Debug.Log("P04 get & save");

        }
        if (GachaList[rand] == "BA3")
        {
            DrawImage.sprite = BImage5; // 슈퍼레어
            A.SetActive(true);
            BA3.sprite = BImage5;
            BSlot5.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("P05");
            Debug.Log("P05 get & save");

        }
        if (GachaList[rand] == "BB1")
        {
            DrawImage.sprite = BImage6; // 슈퍼레어
            B.SetActive(true);
            BB1.sprite = BImage6;
            BSlot6.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("P06");
            Debug.Log("P06 get & save");

        }
        if (GachaList[rand] == "BB2")
        {
            DrawImage.sprite = BImage7; // 슈퍼레어
            B.SetActive(true);
            BB2.sprite = BImage7;
            BSlot7.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("P07");
            Debug.Log("P07 get & save");

        }
        if (GachaList[rand] == "BB3")
        {
            DrawImage.sprite = BImage8; // 슈퍼레어
            B.SetActive(true);
            BB3.sprite = BImage8;
            BSlot8.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("P08");
            Debug.Log("P08 get & save");

        }
        if (GachaList[rand] == "BB4")
        {
            DrawImage.sprite = BImage9; // 슈퍼레어
            B.SetActive(true);
            BB4.sprite = BImage9;
            BSlot9.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("P09");
            Debug.Log("P09 get & save");

        }
        if (GachaList[rand] == "BB5")
        {
            DrawImage.sprite = BImage10; // 슈퍼레어
            B.SetActive(true);
            BB5.sprite = BImage10;
            BSlot10.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("P10");
            Debug.Log("P10 get & save");

        }
        //하의 끝





    }
    public List<string> GachaList = new List<string>() { "HCS1", "HCS2", "HCA1", "HCA2", "HCA3", "HCB1", "HCB2", "HCB3", "HCB4", "HCB5", "PS1","PS2", "PA1", "PA2", "PA3", "PB1", "PB2", "PB3", "PB4", "PB5",
        "CS1", "CS2", "CA1", "CA2", "CA3", "CB1", "CB2", "CB3", "CB4", "CB5", "BS1", "BS2", "BA1", "BA2","BA3","BB1", "BB2", "BB3", "BB4", "BB5"};
    // Update is called once per frame
    void Update()
    {
        
        
    }
    public void Draw()
    {
        DrawShop.SetActive(false);
        DrawWindow.SetActive(true);

        int rand = Random.Range(0, GachaList.Count);

        //대가리 색
        if (GachaList[rand] == "HCS1")
        {
            DrawImage.sprite = HCImage1; //슈퍼레어
            S.SetActive(true);
            HCS1.sprite = HCImage1;
            HCSlot1.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("HC01");
        }
        else if (GachaList[rand] == "HCS2")
        {
            DrawImage.sprite = HCImage2; //슈퍼레어
            A.SetActive(true);
            HCS2.sprite = HCImage2;
            HCSlot2.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("HC02");
        }
        else if (GachaList[rand] == "HCA1")
        {
            DrawImage.sprite = HCImage3; //레어
            A.SetActive(true);
            HCSlot3.interactable = true;
            HCA1.sprite = HCImage3;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("HC03");
        }
        else if (GachaList[rand] == "HCA2")
        {
            DrawImage.sprite = HCImage4; //레어
            A.SetActive(true);
            HCSlot4.interactable = true;
            HCA2.sprite = HCImage4;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("HC04");
        }
        else if (GachaList[rand] == "HCA3")
        {
            DrawImage.sprite = HCImage5; //레어
            A.SetActive(true);
            HCSlot5.interactable = true;
            HCA3.sprite = HCImage5;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("HC05");
        }
        else if (GachaList[rand] == "HCB1")
        {
            DrawImage.sprite = HCImage6; //노멀
            B.SetActive(true);
            HCSlot6.interactable = true;
            HCB1.sprite = HCImage6;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("HC06");
        }
        else if (GachaList[rand] == "HCB2")
        {
            DrawImage.sprite = HCImage7; //노멀
            B.SetActive(true);
            HCSlot7.interactable = true;
            HCB2.sprite = HCImage7;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("HC07");
        }
        else if (GachaList[rand] == "HCB3")
        {
            DrawImage.sprite = HCImage8; //노멀
            B.SetActive(true);
            HCSlot8.interactable = true;
            HCB3.sprite = HCImage8;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("HC08");
        }
        else if (GachaList[rand] == "HCB4")
        {
            DrawImage.sprite = HCImage9; //노멀
            B.SetActive(true);
            HCSlot9.interactable = true;
            HCB4.sprite = HCImage9;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("HC09");
        }
        else if (GachaList[rand] == "HCB5")
        {
            DrawImage.sprite = HCImage10; //노멀
            B.SetActive(true);
            HCSlot10.interactable = true;
            HCB5.sprite = HCImage10;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("HC10");
        }
        //대가리 색 끝

        //펫 
        else if (GachaList[rand] == "PS1")
        {
            DrawImage.sprite = PImage1; // 슈퍼레어
            S.SetActive(true);
            PS1.sprite = PImage1;
            PSlot1.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("PET01");

        }
        else if (GachaList[rand] == "PS2")
        {
            DrawImage.sprite = PImage2; // 슈퍼레어
            S.SetActive(true);
            PS2.sprite = PImage2;
            PSlot2.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("PET02");

        }
        else if (GachaList[rand] == "PA1")
        {
            DrawImage.sprite = PImage3; // 레어
            A.SetActive(true);
            PA1.sprite = PImage3;
            PSlot3.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("PET03");

        }
        else if (GachaList[rand] == "PA2")
        {
            DrawImage.sprite = PImage4; // 레어
            A.SetActive(true);
            PA2.sprite = PImage4;
            PSlot4.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("PET04");

        }
        else if (GachaList[rand] == "PA3")
        {
            DrawImage.sprite = PImage5; // 노멀
            A.SetActive(true);
            PA3.sprite = PImage5;
            PSlot5.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("PET05");

        }
        else if (GachaList[rand] == "PB1")
        {
            DrawImage.sprite = PImage6; // 노멀
            B.SetActive(true);
            PB1.sprite = PImage6;
            PSlot6.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("PET06");

        }
        else if (GachaList[rand] == "PB2")
        {
            DrawImage.sprite = PImage7; // 노멀
            B.SetActive(true);
            PB2.sprite = PImage7;
            PSlot7.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("PET07");

        }
        else if (GachaList[rand] == "PB3")
        {
            DrawImage.sprite = PImage8; // 노멀
            B.SetActive(true);
            PB3.sprite = PImage8;
            PSlot8.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("PET08");

        }
        else if (GachaList[rand] == "PB4")
        {
            DrawImage.sprite = PImage9; // 노멀
            B.SetActive(true);
            PB4.sprite = PImage9;
            PSlot9.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("PET09");

        }
        else if (GachaList[rand] == "PB5")
        {
            DrawImage.sprite = PImage10; // 노멀
            B.SetActive(true);
            PB5.sprite = PImage10;
            PSlot10.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("PET10");

        }

        //상의
        else if (GachaList[rand] == "CS1")
        {
            DrawImage.sprite = CImage1; // 슈퍼레어
            S.SetActive(true);
            CS1.sprite = CImage1;
            CSlot1.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("C01");

        }
        else if (GachaList[rand] == "CS2")
        {
            DrawImage.sprite = CImage2; // 슈퍼레어
            S.SetActive(true);
            CS2.sprite = CImage2;
            CSlot2.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("C02");

        }
        else if (GachaList[rand] == "CA1")
        {
            DrawImage.sprite = CImage3; // 레어
            A.SetActive(true);
            CA1.sprite = CImage3;
            CSlot3.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("C03");

        }
        else if (GachaList[rand] == "CA2")
        {
            DrawImage.sprite = CImage4; // 레어
            A.SetActive(true);
            CA2.sprite = CImage4;
            CSlot4.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("C04");

        }
        else if (GachaList[rand] == "CA3")
        {
            DrawImage.sprite = CImage5; // 레어
            A.SetActive(true);
            CA3.sprite = CImage5;
            CSlot5.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("C05");

        }
        else if (GachaList[rand] == "CB1")
        {
            DrawImage.sprite = CImage6; // 노멀
            B.SetActive(true);
            CB1.sprite = CImage6;
            CSlot6.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("C06");

        }
        else if (GachaList[rand] == "CB2")
        {
            DrawImage.sprite = CImage7; // 노멀
            B.SetActive(true);
            CB2.sprite = CImage7;
            CSlot7.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("C07");

        }
        else if (GachaList[rand] == "CB3")
        {
            DrawImage.sprite = CImage8; // 노멀
            B.SetActive(true);
            CB3.sprite = CImage8;
            CSlot8.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("C08");

        }
        else if (GachaList[rand] == "CB4")
        {
            DrawImage.sprite = CImage9; // 노멀
            B.SetActive(true);
            CB4.sprite = CImage9;
            CSlot9.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("C09");

        }
        else if (GachaList[rand] == "CB5")
        {
            DrawImage.sprite = CImage10; // 노멀
            B.SetActive(true);
            CB5.sprite = CImage10;
            CSlot10.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("C10");

        }
        //상의 끝


        //하의 시작
        else if (GachaList[rand] == "BS1")
        {
            DrawImage.sprite = BImage1; // 슈퍼레어
            S.SetActive(true);
            BS1.sprite = BImage1;
            BSlot1.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("P01");

        }
        else if (GachaList[rand] == "BS2")
        {
            DrawImage.sprite = BImage2; // 슈퍼레어
            S.SetActive(true);
            BS2.sprite = BImage2;
            BSlot2.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("P02");

        }
        else if (GachaList[rand] == "BA1")
        {
            DrawImage.sprite = BImage3; // 슈퍼레어
            A.SetActive(true);
            BA1.sprite = BImage3;
            BSlot3.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("P03");

        }
        else if (GachaList[rand] == "BA2")
        {
            DrawImage.sprite = BImage4; // 슈퍼레어
            A.SetActive(true);
            BA2.sprite = BImage4;
            BSlot4.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("P04");

        }
        else if (GachaList[rand] == "BA3")
        {
            DrawImage.sprite = BImage5; // 슈퍼레어
            A.SetActive(true);
            BA3.sprite = BImage5;
            BSlot5.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("P05");

        }
        else if (GachaList[rand] == "BB1")
        {
            DrawImage.sprite = BImage6; // 슈퍼레어
            B.SetActive(true);
            BB1.sprite = BImage6;
            BSlot6.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("P06");

        }
        else if (GachaList[rand] == "BB2")
        {
            DrawImage.sprite = BImage7; // 슈퍼레어
            B.SetActive(true);
            BB2.sprite = BImage7;
            BSlot7.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("P07");

        }
        else if (GachaList[rand] == "BB3")
        {
            DrawImage.sprite = BImage8; // 슈퍼레어
            B.SetActive(true);
            BB3.sprite = BImage8;
            BSlot8.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("P08");

        }
        else if (GachaList[rand] == "BB4")
        {
            DrawImage.sprite = BImage9; // 슈퍼레어
            B.SetActive(true);
            BB4.sprite = BImage9;
            BSlot9.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("P09");

        }
        else if (GachaList[rand] == "BB5")
        {
            DrawImage.sprite = BImage10; // 슈퍼레어
            B.SetActive(true);
            BB5.sprite = BImage10;
            BSlot10.interactable = true;
            GachaList.RemoveAt(rand);
            join.SetValueFireBase("P10");

        }
        //하의 끝
    }
    public void DrawButton()
    {
        if (money > 0)
        {
            Draw();
            money -= 200;
            GatchaPanel.SetActive(true);
            join.SetValueFireBase("Money",money);
            MyMoney.text = money.ToString();
            MyMoneyP.text = money.ToString();

        }
        else if (money <= 0)
        {
            NomoneyPanel.SetActive(true);
            
        }
    }
    public void GotButton()
    {
        DrawShop.SetActive(true);
        DrawWindow.SetActive(false);
        S.SetActive(false);
        A.SetActive(false);
        B.SetActive(false);
        GatchaPanel.SetActive(false);
    }
}
