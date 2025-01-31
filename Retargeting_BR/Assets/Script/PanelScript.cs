using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class PanelScript : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] Button botao;
    void Start()
    {
        foreach (var parameter in anim.parameters)
        {
            if (parameter.type == AnimatorControllerParameterType.Trigger)
                AddButton(parameter);

        }
    }
    void AddButton(AnimatorControllerParameter parameter)
    {
        var button = Instantiate(botao, transform);
        foreach (var tmpText in button.GetComponentsInChildren<TMP_Text>())
            tmpText.text = parameter.name;
        Debug.Log("P: " + parameter.name);
        button.onClick.AddListener(() => anim.SetTrigger(parameter.nameHash));
    }
}
