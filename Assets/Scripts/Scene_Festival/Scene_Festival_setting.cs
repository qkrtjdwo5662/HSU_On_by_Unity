using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene_Festival_setting : MonoBehaviour
{
    public GameObject NickName;
    public Text NicknameInput;
    public Button Next;
    // Start is called before the first frame update
    void Start()
    {
        Next.onClick.AddListener(nextClick);
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void nextClick() 
    {
        Text t = NickName.GetComponent<Text>();
        t.text = NicknameInput.text;
        LoadingSceneController.Instance.LoadScene("Scene_newCharacter");
    }
}
