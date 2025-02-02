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
            Debug.LogError("Animator não atribuído!");
            return;
        }
        if (layerDropdown == null)
        {
            // Caso o Dropdown não tenha sido atribuído, tenta encontrar no GameObject
            layerDropdown = GetComponent<TMP_Dropdown>();

            if (layerDropdown == null)
            {
                Debug.LogError("Dropdown não atribuído! Certifique-se de arrastar o objeto Dropdown para o campo no Inspector.");
                return;
            }
        }

        // Atualiza o Dropdown com as camadas do Animator
        UpdateDropdownWithLayers();

        // Define o valor inicial do Dropdown
        layerDropdown.value = 0; // Seleciona a primeira camada por padrão
        layerDropdown.onValueChanged.AddListener(OnLayerSelected); // Chama a função quando uma opção é selecionada

    }
    
    void OnLayerSelected(int index)
    {
        SetLayerWeight(selectedLayer, 0.0f);
        Debug.Log(index);
        if (whatDropdownIs == 1)
        {
            // Apenas permite selecionar opções com índice ímpar
            if (index % 2 != 0 && index != 0)
            {
                selectedLayer = layerDropdown.options[index].text; // Pega o nome da camada selecionada
                SetLayerActive(selectedLayer); // Chama a função para ativar a camada
                SetLayerWeight(selectedLayer, 1.0f);
                Debug.Log("Tou aqui no E");
            }
        }
        if (whatDropdownIs == 2)
        {
            // Apenas permite selecionar opções com índice par
            if (index % 2 == 0 || index == 0)
            {
                selectedLayer = layerDropdown.options[index].text; // Pega o nome da camada selecionada
                SetLayerActive(selectedLayer); // Chama a função para ativar a camada
                SetLayerWeight(selectedLayer, 1.0f);
                Debug.Log("Tou aqui no D");
            }
        }
        
        else { 
        //musica
        }
        
    }

    // Função para pegar as camadas do Animator e preencher o Dropdown
    void UpdateDropdownWithLayers()
    {
        // Verifica se o Animator tem um AnimatorController
        AnimatorController ac = animator.runtimeAnimatorController as AnimatorController;
        if (ac == null)
        {
            Debug.LogError("O AnimatorController não foi encontrado!");
            return;
        }

        // Limpa as opções antigas do Dropdown
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
            if (whatDropdownIs == 1 && i % 2 != 0) // Dropdown 1: camadas ímpares
            {
                options.Add(ac.layers[i].name); // Adiciona apenas camadas ímpares
                Debug.Log("Sou E");
            }
        }

        // Adiciona as opções no Dropdown
        layerDropdown.AddOptions(options);
    }

    // Função para ativar a camada correspondente
    void SetLayerActive(string layerName)
    {
        // Obtém o índice da camada no Animator
        int layerIndex = animator.GetLayerIndex(layerName);
        if (layerIndex != -1)
        {
            // Exemplo: Toca a animação "Idle" na camada selecionada
            animator.Play("Idle", layerIndex);
            // Você pode adicionar outras animações ou manipulações aqui
        }
        else
        {
            Debug.LogWarning($"Camada {layerName} não encontrada no Animator.");
        }
    }
    void SetLayerWeight(string layerName, float weight)
    {
        // Obtém o índice da camada
        int layerIndex = animator.GetLayerIndex(layerName);

        if (layerIndex != -1)
        {
            // Ajusta o peso da camada
            animator.SetLayerWeight(layerIndex, weight);
            Debug.Log($"Peso da camada '{layerName}' ajustado para {weight}.");
        }
        else
        {
            Debug.LogWarning($"Camada '{layerName}' não encontrada no Animator.");
        }
    }

}
