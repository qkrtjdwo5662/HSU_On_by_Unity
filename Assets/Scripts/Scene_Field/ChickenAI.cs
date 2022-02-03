using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenAI : MonoBehaviour
{
    private Animator ani;
    public Transform chickenTransform;

    public System.Random r = new System.Random();

    private int nextBehaviour;
    private float time;

    public Transform getTranskform() {
        return chickenTransform;
    }
    public Animator getAnimator() 
    {
        return ani;
    }
    public void setTime(float t) 
    {
        time = t;
        return;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        ani = GetComponent<Animator>();
        DoSomething();

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (ani.GetBool("Walk"))
        {
            if (time >= 2.0f)
            {
                time = 0.0f;
                ani.SetBool("Walk", false);
                DoSomething();
            }
            else
            {
                chickenTransform.Translate(Vector3.forward * Time.deltaTime * 1);
            }

        }
        else if (ani.GetBool("Run"))
        {
            if (time >= 3.0f)
            {
                time = 0.0f;
                ani.SetBool("Run", false);
                DoSomething();
            }
            else
            {
                chickenTransform.Translate(Vector3.forward * Time.deltaTime * 2);
            }
        }
        else if (ani.GetBool("Eat"))
        {
            if (time >= 2.0f)
            {
                time = 0.0f;
                ani.SetBool("Eat", false);
                DoSomething();
            }
        }
        else if (ani.GetBool("TurnHead"))
        {
            if (time >= 2.0f)
            {
                time = 0.0f;
                ani.SetBool("TurnHead", false);
                DoSomething();
            }
        }
        else 
        {
            if (time >= 3.0f)
            {
                time = 0.0f;
                DoSomething();
            }
        }

    }


    private void DoSomething() 
    {
        nextBehaviour = r.Next(0,10);
        switch (nextBehaviour) 
        {
            case 0:
            case 1:
            case 2:
                ani.SetBool("Walk", true);
                chickenTransform.Rotate(0, r.Next(0, 360), 0);
                break;
            case 3:
                ani.SetBool("Run", true);
                chickenTransform.Rotate(0, r.Next(0, 360), 0);
                break;
            case 4:
            case 5:
                ani.SetBool("Eat", true);
                break;
            case 6:
            case 7:
                ani.SetBool("TurnHead", true);
                break;
            case 8:
            case 9:
                ani.SetBool("Walk", false);
                ani.SetBool("Run", false);
                ani.SetBool("Eat", false);
                ani.SetBool("TurnHead", false);
                break;
        }
    }
    
}
