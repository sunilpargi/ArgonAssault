using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }


    void Start()
    {
        Invoke("loadFirstScene", 1f);
    }

     void loadFirstScene()
    {
        SceneManager.LoadScene(1);
    }
}
