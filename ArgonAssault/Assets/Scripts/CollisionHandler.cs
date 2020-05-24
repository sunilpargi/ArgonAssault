using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] int levelloadDelay = 1;

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
        deathFX.SetActive(true);
        Invoke("ReloadScene", levelloadDelay);

    }

    private void StartDeathSequence()
    {
        print("dying");
        SendMessage("OnPlayerDeath");
     

    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }
}
