using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float controlSpeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   // Update is called once per frame
    void Update()
    {
        float horizontalPush = Input.GetAxis("Horizontal");
        float verticalThrow  = Input.GetAxis("Vertical");

        float xDelta  = horizontalPush * Time.deltaTime *controlSpeed;
        float newXpos = transform.localPosition.x + xDelta;

        float yDelta  = verticalThrow * Time.deltaTime * controlSpeed;
        float newYpos = transform.localPosition.y + yDelta;


        transform.localPosition = new Vector3(newXpos, newYpos, transform.localPosition.z);

    }
}
