using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrollxy : MonoBehaviour
{
    Vector3 previousPos;
    Vector3 currentPos;
    [SerializeField]
    float RotationSpeed;
    [SerializeField]
    bool rotateInY;
    [SerializeField]
    bool rotateInX;
    // Start is called before the first frame update
    void Start()
    {
        previousPos = new Vector3();
        currentPos = new Vector3();
        previousPos = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            currentPos = Input.mousePosition;
            if(previousPos == Vector3.zero) previousPos = currentPos;
            
            if (rotateInX && currentPos.x > previousPos.x)
            {
                //transform.rotation = Quaternion.Euler(0, RotationSpeed*Time.deltaTime, 0);
                transform.Rotate(0, -RotationSpeed * Time.deltaTime, 0);
            }
            else if (rotateInX && currentPos.x < previousPos.x)
            {
                //transform.rotation = Quaternion.Euler(0, -RotationSpeed * Time.deltaTime, 0);
                transform.Rotate(0, RotationSpeed * Time.deltaTime, 0);
            }

            if (rotateInY && currentPos.y > previousPos.y)
            {
                //transform.rotation = Quaternion.Euler(0, RotationSpeed*Time.deltaTime, 0);
                transform.Rotate(RotationSpeed * Time.deltaTime, 0, 0);
            }
            else if (rotateInY && currentPos.y < previousPos.y)
            {
                //transform.rotation = Quaternion.Euler(0, -RotationSpeed * Time.deltaTime, 0);
                transform.Rotate(-RotationSpeed * Time.deltaTime, 0, 0);
            }
            previousPos = currentPos;
        }

    }

}
