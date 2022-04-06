using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMask : MonoBehaviour
{
    public EmotionControl EC;

    [SerializeField]
    private GameObject danceMask;
    [SerializeField]
    private GameObject despairMask;
    [SerializeField]
    private GameObject yesMask;
    [SerializeField]
    private GameObject noMask;
    [SerializeField]
    private GameObject victoryMask;
    [SerializeField]
    private Animator ani;

    public PhotonView PV;

    public void AddListenerStart()
    {
    
        EC.dance.onClick.AddListener(DoDanceRPC);
        EC.lose.onClick.AddListener(DoDespairRPC);
        EC.yes.onClick.AddListener(DoYesRPC);
        EC.no.onClick.AddListener(DoNoRPC);
        EC.victory.onClick.AddListener(DoVictoryRPC);
    }


    public void ChangeMaskFunc()
    {

     }



    void DoDanceRPC()
    {
        PV.RPC("DoDance", RpcTarget.AllBuffered);
    }


    void DoDespairRPC()
    {
        PV.RPC("DoDespair", RpcTarget.AllBuffered);
    }


    void DoYesRPC()
    {
        PV.RPC("DoYes", RpcTarget.AllBuffered);
    }


    void DoNoRPC()
    {
        PV.RPC("DoNo", RpcTarget.AllBuffered);
    }


    void DoVictoryRPC()
    {
        PV.RPC("DoVictory", RpcTarget.AllBuffered);
    }




    [PunRPC]
    void DoDance()
    {
       
        danceMask.SetActive(true);
        despairMask.SetActive(false);
        yesMask.SetActive(false);
        noMask.SetActive(false);
        victoryMask.SetActive(false);
    }

    [PunRPC]
    void DoDespair()
    {
        danceMask.SetActive(false);
        despairMask.SetActive(true);
        yesMask.SetActive(false);
        noMask.SetActive(false);
        victoryMask.SetActive(false);
    }

    [PunRPC]
    void DoYes()
    {
        danceMask.SetActive(false);
        despairMask.SetActive(false);
        yesMask.SetActive(true);
        noMask.SetActive(false);
        victoryMask.SetActive(false);
    }

    [PunRPC]
    void DoNo()
    {
        danceMask.SetActive(false);
        despairMask.SetActive(false);
        yesMask.SetActive(false);
        noMask.SetActive(true);
        victoryMask.SetActive(false);
    }

    [PunRPC]
    void DoVictory()
    {
        danceMask.SetActive(false);
        despairMask.SetActive(false);
        yesMask.SetActive(false);
        noMask.SetActive(false);
        victoryMask.SetActive(true);
    }

    public void AlloffMaskRPC()
    {
        PV.RPC("AlloffMask", RpcTarget.AllBuffered);
    }

    [PunRPC]
    void AlloffMask()
    {
        danceMask.SetActive(false);
        despairMask.SetActive(false);
        yesMask.SetActive(false);
        noMask.SetActive(false);
        victoryMask.SetActive(false);
    }

}
