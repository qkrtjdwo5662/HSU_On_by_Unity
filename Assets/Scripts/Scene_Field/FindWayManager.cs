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


    public void GotoDestination(Transform t) 
    {
        bugi.SetActive(true);
        bugi.transform.position = GameObject.Find("Me").GetComponent<Transform>().position + new Vector3(0, 2, 0);
        navi.StartGuide(t);

    }
    void Start()
    {
        EntryBtn.onClick.AddListener(()=> {
            GotoDestination(Entry.transform);
        });
        SangSangBtn.onClick.AddListener(() => {
            GotoDestination(SangSang.transform);
        });        
        YeonGuBtn.onClick.AddListener(() => {
            GotoDestination(YeonGu.transform);
        });
        NakSanBtn.onClick.AddListener(() => {
            GotoDestination(NakSan.transform);
        });
        ChangUiBtn.onClick.AddListener(() => {
            GotoDestination(ChangUi.transform);
        });
/*        WooChonBtn.onClick.AddListener(() => {
            GotoDestination(WooChon.transform);
        });*/
        JanDiBtn.onClick.AddListener(() => {
            GotoDestination(JanDi.transform);
        });
        JinRiBtn.onClick.AddListener(() => {
            GotoDestination(JinRi.transform);
        });
        TamGuBtn.onClick.AddListener(() => {
            GotoDestination(TamGu.transform);
        });
        GongHakABtn.onClick.AddListener(() => {
            GotoDestination(GongHakA.transform);
        });
        GongHakBBtn.onClick.AddListener(() => {
            GotoDestination(GongHakB.transform);
        });
        JiSunBtn.onClick.AddListener(() => {
            GotoDestination(JiSun.transform);
        });
        HakSongBtn.onClick.AddListener(() => {
            GotoDestination(HakSong.transform);
        });
        MiRaeBtn.onClick.AddListener(() => {
            GotoDestination(MiRae.transform);
        });


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
