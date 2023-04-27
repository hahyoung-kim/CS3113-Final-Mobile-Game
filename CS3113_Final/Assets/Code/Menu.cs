using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    public void GoDemo(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
