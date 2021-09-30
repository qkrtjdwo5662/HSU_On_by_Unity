using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AuidoSettingAtFestival : MonoBehaviour
{
    GameObject Audio;
    float volume = 1;
    // Start is called before the first frame update
    void Start()
    {
        Audio = GameObject.Find("AudioObject");
        //Audio.GetComponent<AudioSource>().volume = 0.25f;
        //Destroy(Audio);
    }

    // Update is called once per frame
    void Update()
    {
        volume -= Time.deltaTime;
        if (volume <= 0.25f)
            volume = 0.25f;

        Audio.GetComponent<AudioSource>().volume = volume;
    }
}
