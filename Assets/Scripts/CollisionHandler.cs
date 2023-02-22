using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadDelay = 1.0f;
    [SerializeField] ParticleSystem explosionEffect;
    
    private bool collisionDisabled = false;
    private bool isTransitioning = false;

    // Update is called once per frame
    void Update()
    {
        EnableCheatCodes();
    }

    //To process trigger events
    void OnTriggerEnter(Collider other)
    {
        if (isTransitioning || collisionDisabled)
        {
            return;
        }
        StartCrashSequence();
    }

    //To engage the crash sequence
    void StartCrashSequence()
    {
        Debug.Log("*** May Day !!! May Day !!! ***");
        explosionEffect.Play();
        //GetComponent<MeshRenderer>().enabled =false;
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<PlayerController>().enabled =false;
        Invoke("ReloadLevel",loadDelay);
    }

    //To restart the level upon crashing
    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    //to activate the cheat codes fo debugging
    void EnableCheatCodes()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            ReloadLevel();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            collisionDisabled = !collisionDisabled;   //toggle collision
        }
    }
}
