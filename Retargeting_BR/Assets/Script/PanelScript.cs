using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEditor.Animations;
using System.Data.Common;
//using UnityEngine.UIElements;

public class PanelScript : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Button botao;
    [SerializeField] TMP_Dropdown layerDropdown;

    [SerializeField] TMP_Text text;
    [SerializeField] string nameOfLayers;

    [SerializeField] int whatDropdownIs;
    string selectedLayer;

    void Start()
    {
        /*foreach (var parameter in anim.parameters)
        {
            if (parameter.type == AnimatorControllerParameterType.Trigger)
                AddButton(parameter);

        }*/

        animator = GameObject.FindWithTag("Player").GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogError("Animator n�o atribu�do!");
            return;
        }
        if (layerDropdown == null)
        {
            // Caso o Dropdown n�o tenha sido atribu�do, tenta encontrar no GameObject
            layerDropdown = GetComponent<TMP_Dropdown>();

            if (layerDropdown == null)
            {
                Debug.LogError("Dropdown n�o atribu�do! Certifique-se de arrastar o objeto Dropdown para o campo no Inspector.");
                return;
            }
        }

        // Atualiza o Dropdown com as camadas do Animator
        UpdateDropdownWithLayers();

        // Define o valor inicial do Dropdown
        layerDropdown.value = 0; // Seleciona a primeira camada por padr�o
        layerDropdown.onValueChanged.AddListener(OnLayerSelected); // Chama a fun��o quando uma op��o � selecionada

    }
    
    void OnLayerSelected(int index)
    {
        SetLayerWeight(selectedLayer, 0.0f);
        Debug.Log(index);
        if (whatDropdownIs == 1)
        {
            // Apenas permite selecionar op��es com �ndice �mpar
            if (index % 2 != 0 && index != 0)
            {
                selectedLayer = layerDropdown.options[index].text; // Pega o nome da camada selecionada
                SetLayerActive(selectedLayer); // Chama a fun��o para ativar a camada
                SetLayerWeight(selectedLayer, 1.0f);
                Debug.Log("Tou aqui no E");
            }
        }
        if (whatDropdownIs == 2)
        {
            // Apenas permite selecionar op��es com �ndice par
            if (index % 2 == 0 || index == 0)
            {
                selectedLayer = layerDropdown.options[index].text; // Pega o nome da camada selecionada
                SetLayerActive(selectedLayer); // Chama a fun��o para ativar a camada
                SetLayerWeight(selectedLayer, 1.0f);
                Debug.Log("Tou aqui no D");
            }
        }
        
        else { 
        //musica
        }
        
    }

    // Fun��o para pegar as camadas do Animator e preencher o Dropdown
    void UpdateDropdownWithLayers()
    {
        // Verifica se o Animator tem um AnimatorController
        AnimatorController ac = animator.runtimeAnimatorController as AnimatorController;
        if (ac == null)
        {
            Debug.LogError("O AnimatorController n�o foi encontrado!");
            return;
        }

        // Limpa as op��es antigas do Dropdown
        layerDropdown.ClearOptions();

        // Cria uma lista para armazenar os nomes das camadas
        List<string> options = new List<string>();

        // Itera sobre as camadas do AnimatorController e filtra conforme o Dropdown
        for (int i = 0; i < ac.layers.Length; i++)
        {
            if (whatDropdownIs == 2 && i % 2 == 0) // Dropdown 2: camadas pares
            {
                options.Add(ac.layers[i].name); // Adiciona apenas camadas pares
                Debug.Log("Sou D");
            }
            if (whatDropdownIs == 1 && i % 2 != 0) // Dropdown 1: camadas �mpares
            {
                options.Add(ac.layers[i].name); // Adiciona apenas camadas �mpares
                Debug.Log("Sou E");
            }
        }

        // Adiciona as op��es no Dropdown
        layerDropdown.AddOptions(options);
    }

    // Fun��o para ativar a camada correspondente
    void SetLayerActive(string layerName)
    {
        // Obt�m o �ndice da camada no Animator
        int layerIndex = animator.GetLayerIndex(layerName);
        if (layerIndex != -1)
        {
            // Exemplo: Toca a anima��o "Idle" na camada selecionada
            animator.Play("Idle", layerIndex);
            // Voc� pode adicionar outras anima��es ou manipula��es aqui
        }
        else
        {
            Debug.LogWarning($"Camada {layerName} n�o encontrada no Animator.");
        }
    }
    void SetLayerWeight(string layerName, float weight)
    {
        // Obt�m o �ndice da camada
        int layerIndex = animator.GetLayerIndex(layerName);

        if (layerIndex != -1)
        {
            // Ajusta o peso da camada
            animator.SetLayerWeight(layerIndex, weight);
            Debug.Log($"Peso da camada '{layerName}' ajustado para {weight}.");
        }
        else
        {
            Debug.LogWarning($"Camada '{layerName}' n�o encontrada no Animator.");
        }
    }

}
