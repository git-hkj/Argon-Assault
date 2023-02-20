using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   // Start is called before the first frame update
    void Start()
    {
        
    }

   // Update is called once per frame
    void Update()
    {
        float horizontalPush = Input.GetAxis("Horizontal");
        float verticalThrow = Input.GetAxis("Vertical");

        float xDelta = 0.01f;
        float newXpos = transform.localPosition.x + xDelta;


        transform.localPosition = new Vector3(newXpos, transform.localPosition.y, transform.localPosition.z);

    }
}
