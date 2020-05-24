using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;

    ScoreBoard scoreBoard;
    [SerializeField] int scorePerHit = 20;
    [SerializeField] int Hit = 3;

    void Start()
    {
        AddBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }


    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (Hit <= 0)
        {
            KillEnemy();
        }

    }

    private void ProcessHit()
    {
        scoreBoard.scoreHit(scorePerHit);
        Hit = Hit - 1;
    }

    private void KillEnemy()
    {
        GameObject FX = Instantiate(deathFX, transform.position, Quaternion.identity);
        FX.transform.parent = parent;
        Destroy(gameObject);
    }
}
