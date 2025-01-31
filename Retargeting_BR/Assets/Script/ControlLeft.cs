using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlLeft : MonoBehaviour
{
    Animator animator;

    public AudioSource audiosource;

    public void ChangeDance(int index)
    {
        GameObject characterObject1 = GameObject.Find("Canvas");
        audiosource = characterObject1.GetComponent<AudioSource>();
        GameObject characterObject2 = GameObject.Find("Idle");
        animator = characterObject2.GetComponent<Animator>();
        int indexcamada = (2 * index);
        string danceName; string dirName;
        //indexcamada = indexcamada == -1 ? 0 : indexcamada;
        Debug.Log("Iniciou mudança LW weight");
        for (int i = 0; i < animator.layerCount; i++)
        {
            if (i % 2 == 0) // pares
                if (indexcamada == i)
                {
                    animator.SetLayerWeight(i, 1);
                    danceName = animator.GetLayerName(i);
                    danceName = danceName.Substring(0, danceName.IndexOf(' '));
                    dirName = "Sounds/" + danceName;
                    audiosource.clip = Resources.Load<AudioClip>(dirName);
                    Debug.Log(audiosource.clip);
                    audiosource.Play();
                    Debug.Log("AudioClip: " + dirName);
                }
                else
                {
                    animator.SetLayerWeight(i, 0);
                }
        }
        Debug.Log("Terminou mudança LW weight");
    }
}
