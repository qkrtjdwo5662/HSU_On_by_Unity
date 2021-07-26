using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataMgr : MonoBehaviour
{
    public InputField inputName;
    public InputField inputStdId;
    public InputField inputDep;


    public void save()
    {
        PlayerPrefs.SetString("이름", inputName.text);
        PlayerPrefs.SetInt("학번", int.Parse(inputStdId.text));
        PlayerPrefs.SetString("학과", inputDep.text);
        Debug.Log("정보저장");
        LoadingSceneController.Instance.LoadScene("Scene_Field");
    }

}
