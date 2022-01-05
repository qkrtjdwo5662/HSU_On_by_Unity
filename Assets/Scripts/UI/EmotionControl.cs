using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmotionControl : MonoBehaviour
{
    public Button conversation;
    public Button dance;
    public Button yes;
    public Button no;
    public Button victory;
    public Button lose;
    public GameObject EmotionPanel;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        GameObject Character;



        if (Character = GameObject.Find("base"))
        {
            animator = Character.GetComponent<Animator>();

            conversation.onClick.AddListener(DoConversation);
            dance.onClick.AddListener(DoDance);
            yes.onClick.AddListener(DoYes);
            no.onClick.AddListener(DoNo);
            victory.onClick.AddListener(DoVictoy);
            lose.onClick.AddListener(DoLose);
        }

        // Update is called once per frame
        void Update()
        {

        }

        void DoConversation()
        {
            animator.SetBool("conversation", true);
            animator.SetBool("dance", false);
            animator.SetBool("victory", false);
            animator.SetBool("lose", false);
            animator.SetBool("yes", false);
            animator.SetBool("no", false);
            EmotionPanel.SetActive(false);
        }

        void DoDance()
        {
            animator.SetBool("dance", true);
            animator.SetBool("conversation", false);
            animator.SetBool("victory", false);
            animator.SetBool("lose", false);
            animator.SetBool("yes", false);
            animator.SetBool("no", false);
            EmotionPanel.SetActive(false);
        }

        void DoYes()
        {
            animator.SetBool("yes", true);
            animator.SetBool("conversation", false);
            animator.SetBool("dance", false);
            animator.SetBool("victory", false);
            animator.SetBool("lose", false);
            animator.SetBool("no", false);
            EmotionPanel.SetActive(false);
        }
        void DoNo()
        {
            animator.SetBool("no", true);
            animator.SetBool("conversation", false);
            animator.SetBool("dance", false);
            animator.SetBool("victory", false);
            animator.SetBool("lose", false);
            animator.SetBool("yes", false);
            EmotionPanel.SetActive(false);
        }

        void DoVictoy()
        {
            animator.SetBool("victory", true);
            animator.SetBool("conversation", false);
            animator.SetBool("dance", false);
            animator.SetBool("lose", false);
            animator.SetBool("yes", false);
            animator.SetBool("no", false);
            EmotionPanel.SetActive(false);
        }

        void DoLose()
        {
            animator.SetBool("lose", true);
            animator.SetBool("conversation", false);
            animator.SetBool("dance", false);
            animator.SetBool("victory", false);
            animator.SetBool("yes", false);
            animator.SetBool("no", false);
            EmotionPanel.SetActive(false);

        }
    }
}
