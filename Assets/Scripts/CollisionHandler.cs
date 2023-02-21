using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadDelay = 1.0f;
    [SerializeField] ParticleSystem explosionEffect;

    void OnTriggerEnter(Collider other)
    {
        StartCrashSequence();
    }

    private void StartCrashSequence()
    {
        Debug.Log("*** May Day !!! May Day !!! ***");
        explosionEffect.Play();
        //GetComponent<MeshRenderer>().enabled =false;
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<PlayerController>().enabled =false;
        Invoke("ReloadLevel",loadDelay);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
