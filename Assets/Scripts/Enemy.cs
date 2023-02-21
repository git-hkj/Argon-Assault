using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject deathVFX;
    [SerializeField] Transform parent;
    [SerializeField] int scoreValue = 2;

    ScoreBoard scoreboard;

    void Start()
    {
        scoreboard = FindObjectOfType<ScoreBoard>();
    }
    
    //To process the collision
    void OnParticleCollision(GameObject other)
    {
        ProcessHit(other);
        KillEnemy();
    }

    //To process the hit and track scores
    void ProcessHit(GameObject other)
    {
        Debug.Log($"I'm hit by {other.gameObject.name}");
        scoreboard.ScoreUpdate(scoreValue);
    }
    
    //To process destruction of the enemy
    void KillEnemy()
    {
        GameObject vFx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vFx.transform.parent = parent;
        Destroy(gameObject);
    }

   
}
