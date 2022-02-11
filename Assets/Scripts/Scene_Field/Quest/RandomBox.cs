using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomBox : MonoBehaviour
{
    public GameObject DrawShop;
    public GameObject DrawWindow;
    public GameObject S;
    public GameObject A;
    public GameObject B;
    public Image DrawImage;
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

    public int RandomInt;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RandomInt = Random.Range(0, 100);
    }
    public void Draw()
    {
        DrawShop.SetActive(false);
        DrawWindow.SetActive(true);
        if (RandomInt <= 10)
        {
            DrawImage.sprite = Image1; //슈퍼레어
            S.SetActive(true);
        }
        else if (RandomInt > 10 && RandomInt <= 50)
        {
            DrawImage.sprite = Image2; //레어
            A.SetActive(true);
        }
        else if (RandomInt > 50 && RandomInt <= 100)
        {
            DrawImage.sprite = Image3; //노멀
            B.SetActive(true);
        }
    }

    public void ReButton()
    {
        DrawShop.SetActive(true);
        DrawWindow.SetActive(false);
        S.SetActive(false);
        A.SetActive(false);
        B.SetActive(false);
    }
}
