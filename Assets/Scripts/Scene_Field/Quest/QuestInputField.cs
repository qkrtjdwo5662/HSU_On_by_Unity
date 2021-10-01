using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestInputField : MonoBehaviour
{
    public GameObject answer;
    public string alright_answer = "2";
    public InputField answerInput;
    // Start is called before the first frame update
    void Awake()
    {
        if(answerInput.text.ToLower() == alright_answer)
        {
            answer.SetActive(true);
        }
        else
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
