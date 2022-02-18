using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingAvatar : MonoBehaviour
{

    private PhotonView PV;
    public GameObject model;

    public Texture HC01;
    public Texture HC02;
    public Texture HC03;
    public Texture HC04;
    public Texture HC05;
    public Texture HC06;
    public Texture HC07;
    public Texture HC08;
    public Texture HC09;
    public Texture HC10;

    public Texture C01;
    public Texture C02;
    public Texture C03;
    public Texture C04;
    public Texture C05;
    public Texture C06;
    public Texture C07;
    public Texture C08;
    public Texture C09;
    public Texture C10;

    public Texture P01;
    public Texture P02;
    public Texture P03;
    public Texture P04;
    public Texture P05;
    public Texture P06;
    public Texture P07;
    public Texture P08;
    public Texture P09;
    public Texture P10;

    private Scene_Character_Setting set;

    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        if (PV.IsMine)
        {
            StartCoroutine(FindSet());
        }
    }

    [PunRPC]
    void ChangeHairColor(string color)
    {
        switch (color)
        {
            case "HC1":
                model.GetComponentInChildren<SkinnedMeshRenderer>().materials[2].SetTexture("_MainTex", HC01);
                break;


        }
    }
    [PunRPC]
    void ChangeClothes(string clothes) 
    {
        switch (clothes) {
            case "C1":
                model.GetComponentInChildren<SkinnedMeshRenderer>().materials[0].SetTexture("_MainTex", C01);
                break;
  
            
        }
    }
    [PunRPC]
    void ChangePants(string clothes)
    {
        switch (clothes)
        {
            case "P1":
                model.GetComponentInChildren<SkinnedMeshRenderer>().materials[1].SetTexture("_MainTex", P01);
                break;


        }
    }

    IEnumerator FindSet() 
    {
        while (true)
        {
            set = GameObject.Find("Setting").GetComponent<Scene_Character_Setting>();
            if (set != null) 
            {
                
               /* PV.RPC("ChangeHairColor", RpcTarget.AllBuffered, set.hair);
                PV.RPC("ChangeClothes", RpcTarget.AllBuffered, set.clothes);
                PV.RPC("ChangeHairPants", RpcTarget.AllBuffered, set.pants);*/
                Destroy(this);
                break;
            }
            yield return null;
        }
    }
}
