using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private Transform character;

    public enum ButtonType { Left, Right, Next }
    public ButtonType buttonType;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ButtonDown() {
        switch (buttonType) {
           // case ButtonType.Left:
        }
    }
}
