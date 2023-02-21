using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] int scoreValue = 10;
    [SerializeField] int hitPoints = 2;

    ScoreBoard scoreboard;
    GameObject parentGameObject;

    void Start()
    {
        scoreboard = FindObjectOfType<ScoreBoard>();
        parentGameObject = GameObject.FindWithTag("ShortLived");
        AddRigidbody();
    }
    
    //To process the collision
    void OnParticleCollision(GameObject other)
    {
        GameObject vFx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        vFx.transform.parent = parentGameObject.transform;
        ProcessHit(other);
        if (hitPoints < 1)
        {
            KillEnemy();
        }
    }

    //To process the hit 
    void ProcessHit(GameObject other)
    {
        hitPoints--;
        Debug.Log($"I'm hit by {other.gameObject.name}");
    }

    //To process destruction of the enemy and track scores
    void KillEnemy()
    {
        scoreboard.ScoreUpdate(scoreValue);
        GameObject vFx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vFx.transform.parent = parentGameObject.transform;
        Destroy(gameObject);
    }

    //to add rigidbody to the object
    void AddRigidbody()
    {
        gameObject.AddComponent<Rigidbody>();
        GetComponent<Rigidbody>().useGravity = false;
    }
}
