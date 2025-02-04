using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class ControlSound : MonoBehaviour
{
    RetargetPressedButton retargetPressedButton;
    Animator animator;

    public AudioClip[] music;
    public AudioSource playMusic;
    public int whatMusic = 0;

    public TMP_Dropdown dropdownMusic;

    // Start is called before the first frame update
    void Start()
    {
        retargetPressedButton = GameObject.FindWithTag("Player").GetComponent<RetargetPressedButton>();

        animator = GetComponent<Animator>();

        //playMusic = GetComponent<AudioSource>();
        playMusic = GameObject.FindWithTag("SoundController").GetComponent<AudioSource>();

        if (playMusic != null) 
        {
            playMusic.clip = music[whatMusic]; 
            playMusic.Play();
        }

        // Adicionando ouvintes para capturar a mudança nos Dropdowns relacionado as musicas
        dropdownMusic.onValueChanged.AddListener(OnMusicDropdownChanged);
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
    public void SoundLayers(int index)
    {
        for (int i = 0; i < animator.layerCount; i++)
        {
            if (whatMusic != index && i == index)
            {
                Debug.Log(index);
                whatMusic = index;

                playMusic.Stop();
                playMusic.clip = music[whatMusic];
                playMusic.Play();
            }
        }
    }
    void OnMusicDropdownChanged(int index)
    {
        // Chama a função ChangeDance para o lado esquerdo
        SoundLayers(index);  
    }
}
