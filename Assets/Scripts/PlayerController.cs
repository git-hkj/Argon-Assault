using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float controlSpeed = 10.0f;

    [SerializeField] private float xRange = 5f;
    [SerializeField] private float yRange = 1.0f;
    [SerializeField] private GameObject[] lasers;

    [SerializeField] private float pitchFactor = 2.0f;
    [SerializeField] private float controlPitchFactor = -10.0f;
    [SerializeField] private float yawFactor = 2.0f;
    [SerializeField] private float controlRollFactor = -10.0f;

    [SerializeField] private InputAction fireLaser;     //for new system, Input Manager

    private float verticalThrow;
    private float horizontalPush;

    // Start is called before the first frame update
    void Start()
    {
        
    }

   // Update is called once per frame
    void Update()
    {
        
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

    //To process a translating movement of the ship using input keys
    private void ProcessTranslation()
    {
        horizontalPush = Input.GetAxis("Horizontal");
        verticalThrow = Input.GetAxis("Vertical");

        float xDelta = horizontalPush * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xDelta;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yDelta = verticalThrow * Time.deltaTime * controlSpeed;
        float rawYPos = transform.localPosition.y + yDelta;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);


        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    //To process a rotating movement of the ship using input keys
    private void ProcessRotation()
    {

        //pitch due to local position and control
        float pitchDueToPosition = transform.localPosition.y * pitchFactor;
        float pitchDueToControl = verticalThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControl;
        //yaw due to local position
        float yaw = transform.localPosition.x *yawFactor;
        //roll due to control
        float roll  = horizontalPush * controlRollFactor;
        
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    //To process the laser firing whenever engaged
    void ProcessFiring()
    {
        // if(fire.ReadValue<float>() > 0.5f) for new input system also need OnEnable() and Disable()

        if (Input.GetButton("Fire1"))
        {
            ActivateLaser();
        }
        else
        {
            DeactivateLaser();
        }
    }

    //To switch on the laser whenever the keys are engaged
    private void ActivateLaser()
    {
        foreach (GameObject barrel in lasers)
        {
            var emissionModule = barrel.GetComponent<ParticleSystem.EmissionModule>();
            emissionModule.enabled = true;
        }
    }

    //To switch off the laser once the keys are released
    private void DeactivateLaser()
    {
        foreach (GameObject barrel in lasers)
        {
            var emissionModule = barrel.GetComponent<ParticleSystem.EmissionModule>();
            emissionModule.enabled = false;
        }
    }

    
}
