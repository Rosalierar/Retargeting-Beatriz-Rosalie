using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeTheScene : MonoBehaviour
{
    public int scene;

    public void ChangeScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
