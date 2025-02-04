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
        GameObject characterObject = GameObject.Find("Kachujin"); 
        animator = characterObject.GetComponent<Animator>();
        NamesOfDropdowns();

        // Adicionando ouvintes para capturar a mudança nos Dropdowns
        dropdownrw.onValueChanged.AddListener(OnRightDropdownChanged);
        dropdownlw.onValueChanged.AddListener(OnLeftDropdownChanged);
    }

    void NamesOfDropdowns()
    {        
        List<string> rightLayerNames = new List<string>(); // Para as camadas ímpares (direito)
        List<string> leftLayerNames = new List<string>();

            string danceName;

        for (int i = 0; i < animator.layerCount; i++)
        {
            danceName = animator.GetLayerName(i);
            
            /*if (i % 2 == 0) // Somente as camadas pares (0,2,4,6,8...)
            {
                danceName = animator.GetLayerName(i);
                //danceName = danceName.Substring(0, danceName.IndexOf(' '));
                layerName.Add(danceName);
                Debug.Log(danceName);
            }*/

            if (i % 2 == 0) // Camadas pares (esquerdo)
            {
                leftLayerNames.Add(danceName); // Adiciona no dropdown esquerdo
                Debug.Log("esquerdo" + danceName);
            }
            if (i == 0 || i % 2 != 0) // Camadas ímpares (direito)
            {
                rightLayerNames.Add(danceName); // Adiciona no dropdown direito
                Debug.Log("direito" + danceName);
            }
        }

        dropdownrw.ClearOptions();
        dropdownrw.AddOptions(rightLayerNames);
        dropdownlw.ClearOptions();
        dropdownlw.AddOptions(leftLayerNames);
    }
    void OnRightDropdownChanged(int index)
    {
        // Chama a função ChangeDance para o lado direito
        ControlRight controlRightScript = GameObject.Find("Kachujin").GetComponent<ControlRight>();
        controlRightScript.ChangeDance(index);  // index + 1, pois os dropdowns geralmente começam no índice 0
    }

    void OnLeftDropdownChanged(int index)
    {
        // Chama a função ChangeDance para o lado esquerdo
        ControlLeft controlLeftScript = GameObject.Find("Kachujin").GetComponent<ControlLeft>();
        controlLeftScript.ChangeDance(index);  // index + 1
    }
}

