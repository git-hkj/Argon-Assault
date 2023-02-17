using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputAction movement;
    [SerializeField] private InputAction fire;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //To activate 
    void OnEnable()
    {
        movement.Enable();
    }

    //To deactivate
    void OnDisable()
    {
        movement.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        float horizontalPush = movement.ReadValue<Vector2>().x;
        float verticalThrow  = movement.ReadValue<Vector2>().y;
       
    }
}
