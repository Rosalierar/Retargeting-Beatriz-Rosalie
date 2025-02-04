using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.Animations;
using TMPro;

public class MultiLayers : MonoBehaviour
{
    public Animator animator;
    public TMP_Dropdown dropdownrw;
    public TMP_Dropdown dropdownlw;

    // Start is called before the first frame update
    void Start()
    {
        GameObject characterObject = GameObject.Find("Idle");
        animator = characterObject.GetComponent<Animator>();
        NamesOfDropdowns();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void NamesOfDropdowns()
    {
        List<string> layerName = new List<string>();

        string danceName;

        for (int i = 0; i < animator.layerCount; i++)
        {
            if (i % 2 == 0) // Somente as camadas pares (0,2,4,6,8...)
            {
                danceName = animator.GetLayerName(i);
                //danceName = danceName.Substring(0, danceName.IndexOf(' '));
                layerName.Add(danceName);
                Debug.Log(danceName);
            }
        }

        dropdownrw.ClearOptions();
        dropdownrw.AddOptions(layerName);
        dropdownlw.ClearOptions();
        dropdownlw.AddOptions(layerName);
    }
}

