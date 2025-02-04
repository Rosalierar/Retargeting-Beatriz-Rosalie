using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlRight : MonoBehaviour
{
    Animator animator;

    public void ChangeDance(int index)
    {
        GameObject characterObject = GameObject.Find("Kachujin");
        animator = characterObject.GetComponent<Animator>();
        int indexcamada = (2 * index) - 1;

        indexcamada = indexcamada == -1 ? 0 : indexcamada;

        Debug.Log("Iniciou mudança RW weight");

        for (int i = 0; i < animator.layerCount; i++)
        {
            if (i == 0 || i % 2 != 0) //impares
            {
                if (indexcamada == i)
                {
                    animator.SetLayerWeight(i, 1);
                    Debug.Log("AW Mudou peso para 1. Camada:" + i);
                }
                else
                {
                    animator.SetLayerWeight(i, 0);
                    Debug.Log("AW Mudou peso para 0. Camada:" + i);
                }
            }
        }
        Debug.Log("Terminou mudança RW weight");

    }
}
