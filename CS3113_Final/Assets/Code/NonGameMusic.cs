using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonGameMusic : MonoBehaviour
{
    private void Awake()
    {
        if(GameObject.FindGameObjectsWithTag("Music").Length > 1)
        {
            Destroy(gameObject);
        }
        else{
            DontDestroyOnLoad(gameObject);
        }
    }
}
