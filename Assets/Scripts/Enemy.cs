using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] Transform parent;
    [SerializeField] int scoreValue = 10;
    [SerializeField] int hitPoints = 2;

    ScoreBoard scoreboard;

    void Start()
    {
        scoreboard = FindObjectOfType<ScoreBoard>();
    }
    
    //To process the collision
    void OnParticleCollision(GameObject other)
    {
        GameObject vFx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        vFx.transform.parent = parent;
        ProcessHit(other);
        if (hitPoints < 1)
        {
            KillEnemy();
        }
    }

    //To process the hit and track scores
    void ProcessHit(GameObject other)
    {
        hitPoints--;
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
