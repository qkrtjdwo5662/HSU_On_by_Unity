using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomBox : MonoBehaviour
{
    //돈
    public int money = 1800;
    //돈
    public Text MyMoney;
    public int itemCount;
    public Item item;
    public Slot slot;
    public GameObject NomoneyPanel;
    public GameObject DrawShop;
    public GameObject DrawWindow;
    public GameObject S;
    public GameObject A;
    public GameObject B;
    public Image DrawImage;
    //인벤 채울 이미지
    //public List<Slot> InvenList = new List<Slot>() { Slot1, Slot2, Slot3, Slot4, Slot5, Slot6, Slot7, Slot8, Slot9, Slot10 };
    public Image ItemImage1;
    public Image ItemImage2;
    public Image ItemImage3;
    public Image ItemImage4;
    public Image ItemImage5;
    public Image ItemImage6;
    public Image ItemImage7;
    public Image ItemImage8;
    public Image ItemImage9;
    public Image ItemImage10;
    //머리 색
    public Sprite Image1;
    public Sprite Image2;
    public Sprite Image3;
    public Sprite Image4;
    public Sprite Image5;
    public Sprite Image6;
    public Sprite Image7;
    public Sprite Image8;
    public Sprite Image9;
    public Sprite Image10;
    //머리색 끝
    public int RandomInt;
    // Start is called before the first frame update
    void Start()
    {
        //MyMoney = GameObject.Find("Money").GetComponent<Text>();
        MyMoney.text = ""+ money;
    }
    public List<string> GachaList = new List<string>() { "S1", "S2", "A1", "A2", "A3", "B1", "B2", "B3", "B4", "B5" };
    // Update is called once per frame
    void Update()
    {
        //RandomInt = Random.Range(0, 100);
        
    }
    public void Draw()
    {
        DrawShop.SetActive(false);
        DrawWindow.SetActive(true);

        int rand = Random.Range(0, GachaList.Count);
        if (GachaList[rand] == "S1")
        {
            DrawImage.sprite = Image1; //슈퍼레어
            S.SetActive(true);
            //ItemImage.sprite = Image1;
            //GotButton();
            //AddItem(item);
            ItemImage1.sprite = Image1;
            GachaList.RemoveAt(rand);
        }
        else if (GachaList[rand] == "S2")
        {
            DrawImage.sprite = Image2; //슈퍼레어
            A.SetActive(true);
            //GotButton();
            ItemImage2.sprite = Image2;
            //AddItem(item);
            GachaList.RemoveAt(rand);
        }
        else if (GachaList[rand] == "A1")
        {
            DrawImage.sprite = Image3; //레어
            A.SetActive(true);
            //GotButton();
            //ItemImage.sprite = Image2;
            //AddItem(item);
            ItemImage3.sprite = Image3;
            GachaList.RemoveAt(rand);
        }
        else if (GachaList[rand] == "A2")
        {
            DrawImage.sprite = Image4; //레어
            A.SetActive(true);
            //GotButton();
            //ItemImage.sprite = Image2;
            //AddItem(item);
            ItemImage4.sprite = Image4;
            GachaList.RemoveAt(rand);
        }
        else if (GachaList[rand] == "A3")
        {
            DrawImage.sprite = Image5; //레어
            A.SetActive(true);
            //GotButton();
            //ItemImage.sprite = Image2;
            //AddItem(item);
            ItemImage5.sprite = Image5;
            GachaList.RemoveAt(rand);
        }
        else if (GachaList[rand] == "B1")
        {
            DrawImage.sprite = Image6; //노멀
            B.SetActive(true);
            //GotButton();
            //ItemImage.sprite = Image3;
            //AddItem(item);
            ItemImage6.sprite = Image6;
            GachaList.RemoveAt(rand);
        }
        else if (GachaList[rand] == "B2")
        {
            DrawImage.sprite = Image7; //노멀
            B.SetActive(true);
            //GotButton();
            //ItemImage.sprite = Image3;
            //AddItem(item);
            ItemImage7.sprite = Image7;
            GachaList.RemoveAt(rand);
        }
        else if (GachaList[rand] == "B3")
        {
            DrawImage.sprite = Image8; //노멀
            B.SetActive(true);
            //GotButton();
            //ItemImage.sprite = Image3;
            //AddItem(item);
            ItemImage8.sprite = Image8;
            GachaList.RemoveAt(rand);
        }
        else if (GachaList[rand] == "B4")
        {
            DrawImage.sprite = Image9; //노멀
            B.SetActive(true);
            //GotButton();
            //ItemImage.sprite = Image3;
            //AddItem(item);
            ItemImage9.sprite = Image9;
            GachaList.RemoveAt(rand);
        }
        else if (GachaList[rand] == "B5")
        {
            DrawImage.sprite = Image10; //노멀
            B.SetActive(true);
            //GotButton();
            //ItemImage.sprite = Image3;
            //AddItem(item);
            ItemImage10.sprite = Image10;
            GachaList.RemoveAt(rand);
        }
        

    }
    public void DrawButton()
    {
        if (money > 0)
        {
            Draw();
            money -= 200;
            MyMoney.text = money.ToString();
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
        slot.AddItem(item);
    }

}
