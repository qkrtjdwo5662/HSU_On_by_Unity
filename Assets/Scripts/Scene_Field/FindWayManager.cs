using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindWayManager : MonoBehaviour
{
    public GameObject bugi;
    public SangSangBugiNavigator navi;
    
    public Transform Entry;
    public Transform SangSang;
    public Transform YeonGu;
    public Transform NakSan;
    public Transform ChangUi;
    public Transform WooChon;
    public Transform JanDi;
    public Transform JinRi;
    public Transform TamGu;
    public Transform GongHakA;
    public Transform GongHakB;
    public Transform SangBil;
    public Transform JiSun;
    public Transform HakSong;
    public Transform MiRae;
    
    public Button EntryBtn;
    public Button SangSangBtn;
    public Button YeonGuBtn;
    public Button NakSanBtn;
    public Button ChangUiBtn;
    public Button WooChonBtn;
    public Button JanDiBtn;
    public Button JinRiBtn;
    public Button TamGuBtn;
    public Button GongHakABtn;
    public Button GongHakBBtn;
    public Button SangBilBtn;
    public Button JiSunBtn;
    public Button HakSongBtn;
    public Button MiRaeBtn;

    public GameObject NaviUI;
    public Button GoBtn;
    public GameObject miniMap;

    private Transform temp;
    private GameObject Me;
    public void openNaviUI(Transform t) 
    {
        temp = t;
        NaviUI.SetActive(true);

    }
    public void GotoDestination(Transform t)
    {
        bugi.SetActive(true);
        navi.StartGuide(t);

    }

    void Start()
    {
        EntryBtn.onClick.AddListener(()=> {
            openNaviUI(Entry.transform);
            miniMap.SetActive(false);
        });
        SangSangBtn.onClick.AddListener(() => {
            openNaviUI(SangSang.transform);
            miniMap.SetActive(false);

        });        
        YeonGuBtn.onClick.AddListener(() => {
            openNaviUI(YeonGu.transform);
            miniMap.SetActive(false);

        });
        NakSanBtn.onClick.AddListener(() => {
            openNaviUI(NakSan.transform);
            miniMap.SetActive(false);

        });
        ChangUiBtn.onClick.AddListener(() => {
            openNaviUI(ChangUi.transform);
            miniMap.SetActive(false);

        });
/*        WooChonBtn.onClick.AddListener(() => {
            GotoDestination(WooChon.transform);
            miniMap.SetActive(false);

        });*/
        JanDiBtn.onClick.AddListener(() => {
            openNaviUI(JanDi.transform);
            miniMap.SetActive(false);

        });
        JinRiBtn.onClick.AddListener(() => {
            openNaviUI(JinRi.transform);
            miniMap.SetActive(false);

        });
        TamGuBtn.onClick.AddListener(() => {
            openNaviUI(TamGu.transform);
            miniMap.SetActive(false);

        });
        GongHakABtn.onClick.AddListener(() => {
            openNaviUI(GongHakA.transform);
            miniMap.SetActive(false);

        });
        GongHakBBtn.onClick.AddListener(() => {
            openNaviUI(GongHakB.transform);
            miniMap.SetActive(false);

        });
        JiSunBtn.onClick.AddListener(() => {
            openNaviUI(JiSun.transform);
            miniMap.SetActive(false);

        });
        HakSongBtn.onClick.AddListener(() => {
            openNaviUI(HakSong.transform);
            miniMap.SetActive(false);

        });
        MiRaeBtn.onClick.AddListener(() => {
            openNaviUI(MiRae.transform);
            miniMap.SetActive(false);

        });

        GoBtn.onClick.AddListener(()=> {
            NaviUI.SetActive(false);
            GotoDestination(temp);
        });
        Me = GameObject.Find("Me");
    }

    // Update is called once per frame
    void Update()
    {
        if (!bugi.activeInHierarchy) {
            bugi.transform.position = Me.transform.position;
        }
    }
}
