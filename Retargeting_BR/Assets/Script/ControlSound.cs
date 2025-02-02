using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

public class ControlSound : MonoBehaviour
{
    PanelScript painelScript;
    RetargetPressedButton retargetPressedButton;

    public AudioClip[] music;
    public AudioSource playMusic;
    public int whatMusic = 0;

    // Start is called before the first frame update
    void Start()
    {
        retargetPressedButton = GameObject.FindWithTag("Player").GetComponent<RetargetPressedButton>();
        painelScript = GameObject.Find("DropdownLeft").GetComponent<PanelScript>();

        playMusic = GetComponent<AudioSource>();

        if (playMusic != null) 
        {
            playMusic.clip = music[whatMusic]; 
            playMusic.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void SoundOnOff(int tf)
    {
        if (whatMusic != tf)
        {
            Debug.Log(tf);
            whatMusic = tf; 

            playMusic.Stop();
            playMusic.clip = music[whatMusic];
            playMusic.Play();
        }
    }
    public void SoundLayers(int tf)
    {
       //if (tf = painelScript.layerDropdown.options[tf].text) { }
    }
}
