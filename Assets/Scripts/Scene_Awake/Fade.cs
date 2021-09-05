using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    public UnityEngine.UI.Image fade;
    float fades;
    float time = 0f;

    public int fadeTime=5;

    public float ftime = 0.05f;



    public enum FadeType { In, Out }
    public FadeType fadeType;
    // Start is called before the first frame update
    void Start()
    {
        switch (fadeType) {
            case FadeType.In:
                fades = 1.0f;
                break;
            case FadeType.Out:
                fades = 0.0f;
                break;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (fadeType)
        {
            case FadeType.In:
                time += Time.deltaTime*fadeTime;
                if (fades > 0.0f & time >= 0.1f)
                {
                    fades -= ftime;
                    fade.color = new Color(0, 0, 0, fades);
                    time = 0;
                }
                else if (fades <= 0.0f)
                {
                    time = 0;
                }
                break;
            case FadeType.Out:
                time += Time.deltaTime*fadeTime;
                if (fades < 1.0f & time >= 0.1f)
                {
                    fades += ftime;
                    fade.color = new Color(0, 0, 0, fades);
                    time = 0;
                }
                else if (fades >= 1.0f)
                {
                    time = 0;
                }
                break;
        }
        
    }

    
}
