using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

public class RetargetPressedButton : MonoBehaviour
{
    public Animator anim;
    public int isMacarenaHash;
    ControlSound controlSound;

    void Start()
    {
        anim = GetComponent<Animator>();
        controlSound = GameObject.FindWithTag("SoundController").GetComponent<ControlSound>();
        isMacarenaHash = Animator.StringToHash("isMacarena");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            controlSound.SoundOnOff(1);  
            anim.SetBool(isMacarenaHash, true);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            controlSound.SoundOnOff(0); 
            anim.SetBool(isMacarenaHash, false); 
        }
    }
}
