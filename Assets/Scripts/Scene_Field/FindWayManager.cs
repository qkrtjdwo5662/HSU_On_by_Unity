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
    public Transform Hakgun;
    
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
    public Button HakgunBtn;

    public GameObject GoBugiPanel;
    public Button GoBtn;
    public GameObject miniMap;

    public AudioClip c;
    public AudioSource audio;
    

    private Transform temp;
    private GameObject Me;
    public void openNaviUI(Transform t) 
    {
        temp = t;
        GoBugiPanel.SetActive(true);
        bugi.transform.position = Me.transform.position;

    }
    public void GotoDestination(Transform t)
    {
        bugi.SetActive(true);
        navi.StartGuide(t);

    }

    void Start()
    {
        EntryBtn.onClick.AddListener(()=> {
            audio.PlayOneShot(c);
            openNaviUI(Entry.transform);
            miniMap.SetActive(false);
            Entry.gameObject.SetActive(true);
            SangSang.gameObject.SetActive(false);
            YeonGu.gameObject.SetActive(false);
            NakSan.gameObject.SetActive(false);
            ChangUi.gameObject.SetActive(false);
            WooChon.gameObject.SetActive(false);
            JanDi.gameObject.SetActive(false);
            JinRi.gameObject.SetActive(false);
            TamGu.gameObject.SetActive(false);
            GongHakA.gameObject.SetActive(false);
            GongHakB.gameObject.SetActive(false);
            SangBil.gameObject.SetActive(false);
            JiSun.gameObject.SetActive(false);
            HakSong.gameObject.SetActive(false);
            MiRae.gameObject.SetActive(false);
            Hakgun.gameObject.SetActive(false);
});
        SangSangBtn.onClick.AddListener(() => {
            audio.PlayOneShot(c);
            openNaviUI(SangSang.transform);
            miniMap.SetActive(false);
            Entry.gameObject.SetActive(false);
            SangSang.gameObject.SetActive(true);
            YeonGu.gameObject.SetActive(false);
            NakSan.gameObject.SetActive(false);
            ChangUi.gameObject.SetActive(false);
            WooChon.gameObject.SetActive(false);
            JanDi.gameObject.SetActive(false);
            JinRi.gameObject.SetActive(false);
            TamGu.gameObject.SetActive(false);
            GongHakA.gameObject.SetActive(false);
            GongHakB.gameObject.SetActive(false);
            SangBil.gameObject.SetActive(false);
            JiSun.gameObject.SetActive(false);
            HakSong.gameObject.SetActive(false);
            MiRae.gameObject.SetActive(false);
            Hakgun.gameObject.SetActive(false);
        });        
        YeonGuBtn.onClick.AddListener(() => {
            audio.PlayOneShot(c);
            openNaviUI(YeonGu.transform);
            miniMap.SetActive(false);
            Entry.gameObject.SetActive(false);
            SangSang.gameObject.SetActive(false);
            YeonGu.gameObject.SetActive(true);
            NakSan.gameObject.SetActive(false);
            ChangUi.gameObject.SetActive(false);
            WooChon.gameObject.SetActive(false);
            JanDi.gameObject.SetActive(false);
            JinRi.gameObject.SetActive(false);
            TamGu.gameObject.SetActive(false);
            GongHakA.gameObject.SetActive(false);
            GongHakB.gameObject.SetActive(false);
            SangBil.gameObject.SetActive(false);
            JiSun.gameObject.SetActive(false);
            HakSong.gameObject.SetActive(false);
            MiRae.gameObject.SetActive(false);
            Hakgun.gameObject.SetActive(false);
        });
        NakSanBtn.onClick.AddListener(() => {
            audio.PlayOneShot(c);
            openNaviUI(NakSan.transform);
            miniMap.SetActive(false);
            Entry.gameObject.SetActive(false);
            SangSang.gameObject.SetActive(false);
            YeonGu.gameObject.SetActive(false);
            NakSan.gameObject.SetActive(true);
            ChangUi.gameObject.SetActive(false);
            WooChon.gameObject.SetActive(false);
            JanDi.gameObject.SetActive(false);
            JinRi.gameObject.SetActive(false);
            TamGu.gameObject.SetActive(false);
            GongHakA.gameObject.SetActive(false);
            GongHakB.gameObject.SetActive(false);
            SangBil.gameObject.SetActive(false);
            JiSun.gameObject.SetActive(false);
            HakSong.gameObject.SetActive(false);
            MiRae.gameObject.SetActive(false);
            Hakgun.gameObject.SetActive(false);
        });
        ChangUiBtn.onClick.AddListener(() => {
            audio.PlayOneShot(c);
            openNaviUI(ChangUi.transform);
            miniMap.SetActive(false);
            Entry.gameObject.SetActive(false);
            SangSang.gameObject.SetActive(false);
            YeonGu.gameObject.SetActive(false);
            NakSan.gameObject.SetActive(false);
            ChangUi.gameObject.SetActive(true);
            WooChon.gameObject.SetActive(false);
            JanDi.gameObject.SetActive(false);
            JinRi.gameObject.SetActive(false);
            TamGu.gameObject.SetActive(false);
            GongHakA.gameObject.SetActive(false);
            GongHakB.gameObject.SetActive(false);
            SangBil.gameObject.SetActive(false);
            JiSun.gameObject.SetActive(false);
            HakSong.gameObject.SetActive(false);
            MiRae.gameObject.SetActive(false);
            Hakgun.gameObject.SetActive(false);
        });

        WooChonBtn.onClick.AddListener(() => {
            audio.PlayOneShot(c);
            openNaviUI(WooChon.transform);
            miniMap.SetActive(false);
            Entry.gameObject.SetActive(false);
            SangSang.gameObject.SetActive(false);
            YeonGu.gameObject.SetActive(false);
            NakSan.gameObject.SetActive(false);
            ChangUi.gameObject.SetActive(false);
            WooChon.gameObject.SetActive(true);
            JanDi.gameObject.SetActive(false);
            JinRi.gameObject.SetActive(false);
            TamGu.gameObject.SetActive(false);
            GongHakA.gameObject.SetActive(false);
            GongHakB.gameObject.SetActive(false);
            SangBil.gameObject.SetActive(false);
            JiSun.gameObject.SetActive(false);
            HakSong.gameObject.SetActive(false);
            MiRae.gameObject.SetActive(false);
            Hakgun.gameObject.SetActive(false);
        });

        JanDiBtn.onClick.AddListener(() => {
            audio.PlayOneShot(c);
            openNaviUI(JanDi.transform);
            miniMap.SetActive(false);
            Entry.gameObject.SetActive(false);
            SangSang.gameObject.SetActive(false);
            YeonGu.gameObject.SetActive(false);
            NakSan.gameObject.SetActive(false);
            ChangUi.gameObject.SetActive(false);
            WooChon.gameObject.SetActive(false);
            JanDi.gameObject.SetActive(true);
            JinRi.gameObject.SetActive(false);
            TamGu.gameObject.SetActive(false);
            GongHakA.gameObject.SetActive(false);
            GongHakB.gameObject.SetActive(false);
            SangBil.gameObject.SetActive(false);
            JiSun.gameObject.SetActive(false);
            HakSong.gameObject.SetActive(false);
            MiRae.gameObject.SetActive(false);
            Hakgun.gameObject.SetActive(false);
        });
        JinRiBtn.onClick.AddListener(() => {
            audio.PlayOneShot(c);
            openNaviUI(JinRi.transform);
            miniMap.SetActive(false);
            Entry.gameObject.SetActive(false);
            SangSang.gameObject.SetActive(false);
            YeonGu.gameObject.SetActive(false);
            NakSan.gameObject.SetActive(false);
            ChangUi.gameObject.SetActive(false);
            WooChon.gameObject.SetActive(false);
            JanDi.gameObject.SetActive(false);
            JinRi.gameObject.SetActive(true);
            TamGu.gameObject.SetActive(false);
            GongHakA.gameObject.SetActive(false);
            GongHakB.gameObject.SetActive(false);
            SangBil.gameObject.SetActive(false);
            JiSun.gameObject.SetActive(false);
            HakSong.gameObject.SetActive(false);
            MiRae.gameObject.SetActive(false);
            Hakgun.gameObject.SetActive(false);
        });
        TamGuBtn.onClick.AddListener(() => {
            audio.PlayOneShot(c);
            openNaviUI(TamGu.transform);
            miniMap.SetActive(false);
            Entry.gameObject.SetActive(false);
            SangSang.gameObject.SetActive(false);
            YeonGu.gameObject.SetActive(false);
            NakSan.gameObject.SetActive(false);
            ChangUi.gameObject.SetActive(false);
            WooChon.gameObject.SetActive(false);
            JanDi.gameObject.SetActive(false);
            JinRi.gameObject.SetActive(false);
            TamGu.gameObject.SetActive(true);
            GongHakA.gameObject.SetActive(false);
            GongHakB.gameObject.SetActive(false);
            SangBil.gameObject.SetActive(false);
            JiSun.gameObject.SetActive(false);
            HakSong.gameObject.SetActive(false);
            MiRae.gameObject.SetActive(false);
            Hakgun.gameObject.SetActive(false);
        });
        GongHakABtn.onClick.AddListener(() => {
            audio.PlayOneShot(c);
            openNaviUI(GongHakA.transform);
            miniMap.SetActive(false);
            Entry.gameObject.SetActive(false);
            SangSang.gameObject.SetActive(false);
            YeonGu.gameObject.SetActive(false);
            NakSan.gameObject.SetActive(false);
            ChangUi.gameObject.SetActive(false);
            WooChon.gameObject.SetActive(false);
            JanDi.gameObject.SetActive(false);
            JinRi.gameObject.SetActive(false);
            TamGu.gameObject.SetActive(false);
            GongHakA.gameObject.SetActive(true);
            GongHakB.gameObject.SetActive(false);
            SangBil.gameObject.SetActive(false);
            JiSun.gameObject.SetActive(false);
            HakSong.gameObject.SetActive(false);
            MiRae.gameObject.SetActive(false);
            Hakgun.gameObject.SetActive(false);
        });
        GongHakBBtn.onClick.AddListener(() => {
            audio.PlayOneShot(c);
            openNaviUI(GongHakB.transform);
            miniMap.SetActive(false);
            Entry.gameObject.SetActive(false);
            SangSang.gameObject.SetActive(false);
            YeonGu.gameObject.SetActive(false);
            NakSan.gameObject.SetActive(false);
            ChangUi.gameObject.SetActive(false);
            WooChon.gameObject.SetActive(false);
            JanDi.gameObject.SetActive(false);
            JinRi.gameObject.SetActive(false);
            TamGu.gameObject.SetActive(false);
            GongHakA.gameObject.SetActive(false);
            GongHakB.gameObject.SetActive(true);
            SangBil.gameObject.SetActive(false);
            JiSun.gameObject.SetActive(false);
            HakSong.gameObject.SetActive(false);
            MiRae.gameObject.SetActive(false);
            Hakgun.gameObject.SetActive(false);
        });
        SangBilBtn.onClick.AddListener(() => {
            audio.PlayOneShot(c);
            openNaviUI(SangBil.transform);
            miniMap.SetActive(false);
            Entry.gameObject.SetActive(false);
            SangSang.gameObject.SetActive(false);
            YeonGu.gameObject.SetActive(false);
            NakSan.gameObject.SetActive(false);
            ChangUi.gameObject.SetActive(false);
            WooChon.gameObject.SetActive(false);
            JanDi.gameObject.SetActive(false);
            JinRi.gameObject.SetActive(false);
            TamGu.gameObject.SetActive(false);
            GongHakA.gameObject.SetActive(false);
            GongHakB.gameObject.SetActive(false);
            SangBil.gameObject.SetActive(true);
            JiSun.gameObject.SetActive(false);
            HakSong.gameObject.SetActive(false);
            MiRae.gameObject.SetActive(false);
            Hakgun.gameObject.SetActive(false);
        });
        JiSunBtn.onClick.AddListener(() => {
            audio.PlayOneShot(c);
            openNaviUI(JiSun.transform);
            miniMap.SetActive(false);
            Entry.gameObject.SetActive(false);
            SangSang.gameObject.SetActive(false);
            YeonGu.gameObject.SetActive(false);
            NakSan.gameObject.SetActive(false);
            ChangUi.gameObject.SetActive(false);
            WooChon.gameObject.SetActive(false);
            JanDi.gameObject.SetActive(false);
            JinRi.gameObject.SetActive(false);
            TamGu.gameObject.SetActive(false);
            GongHakA.gameObject.SetActive(false);
            GongHakB.gameObject.SetActive(false);
            SangBil.gameObject.SetActive(false);
            JiSun.gameObject.SetActive(true);
            HakSong.gameObject.SetActive(false);
            MiRae.gameObject.SetActive(false);
            Hakgun.gameObject.SetActive(false);
        });
        HakSongBtn.onClick.AddListener(() => {
            audio.PlayOneShot(c);
            openNaviUI(HakSong.transform);
            miniMap.SetActive(false);
            Entry.gameObject.SetActive(false);
            SangSang.gameObject.SetActive(false);
            YeonGu.gameObject.SetActive(false);
            NakSan.gameObject.SetActive(false);
            ChangUi.gameObject.SetActive(false);
            WooChon.gameObject.SetActive(false);
            JanDi.gameObject.SetActive(false);
            JinRi.gameObject.SetActive(false);
            TamGu.gameObject.SetActive(false);
            GongHakA.gameObject.SetActive(false);
            GongHakB.gameObject.SetActive(false);
            SangBil.gameObject.SetActive(false);
            JiSun.gameObject.SetActive(false);
            HakSong.gameObject.SetActive(true);
            MiRae.gameObject.SetActive(false);
            Hakgun.gameObject.SetActive(false);
        });
        MiRaeBtn.onClick.AddListener(() => {
            audio.PlayOneShot(c);
            openNaviUI(MiRae.transform);
            miniMap.SetActive(false);
            Entry.gameObject.SetActive(false);
            SangSang.gameObject.SetActive(false);
            YeonGu.gameObject.SetActive(false);
            NakSan.gameObject.SetActive(false);
            ChangUi.gameObject.SetActive(false);
            WooChon.gameObject.SetActive(false);
            JanDi.gameObject.SetActive(false);
            JinRi.gameObject.SetActive(false);
            TamGu.gameObject.SetActive(false);
            GongHakA.gameObject.SetActive(false);
            GongHakB.gameObject.SetActive(false);
            SangBil.gameObject.SetActive(false);
            JiSun.gameObject.SetActive(false);
            HakSong.gameObject.SetActive(false);
            MiRae.gameObject.SetActive(true);
            Hakgun.gameObject.SetActive(false);
        });
        HakgunBtn.onClick.AddListener(() => {
            audio.PlayOneShot(c);
            openNaviUI(Hakgun.transform);
            miniMap.SetActive(false);
            Entry.gameObject.SetActive(false);
            SangSang.gameObject.SetActive(false);
            YeonGu.gameObject.SetActive(false);
            NakSan.gameObject.SetActive(false);
            ChangUi.gameObject.SetActive(false);
            WooChon.gameObject.SetActive(false);
            JanDi.gameObject.SetActive(false);
            JinRi.gameObject.SetActive(false);
            TamGu.gameObject.SetActive(false);
            GongHakA.gameObject.SetActive(false);
            GongHakB.gameObject.SetActive(false);
            SangBil.gameObject.SetActive(false);
            JiSun.gameObject.SetActive(false);
            HakSong.gameObject.SetActive(false);
            MiRae.gameObject.SetActive(false);
            Hakgun.gameObject.SetActive(true);
        });

        GoBtn.onClick.AddListener(()=> {
            GoBugiPanel.SetActive(false);
            GotoDestination(temp);
        });
        StartCoroutine(FindMe());
    }

    // Update is called once per frame
    void Update()
    {
        if (!bugi.activeInHierarchy) {
            bugi.transform.position = Me.transform.position;
        }
    }
    IEnumerator FindMe()
    {


        while (true)
        {
            Me = GameObject.Find("Me");

            if (Me != null)
            {
                break;
            }
            yield return null;
        }
    }
}
