using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float controlSpeed = 10.0f;
    [SerializeField] private float xRange = 5f;
    [SerializeField] float yRange = 1.0f;

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
        float rawXPos = transform.localPosition.x + xDelta;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yDelta  = verticalThrow * Time.deltaTime * controlSpeed;
        float rawYPos = transform.localPosition.y + yDelta;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);


        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);

    }
}
