using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    [SerializeField]
    private Transform lookAt;
    private float boundX = 0.15f;
    private float boundY = 0.05f;
    [SerializeField]
    private GameObject pl;

    private void Start()
    {
        pl = GameObject.FindGameObjectWithTag("Fighter");
        if (pl.name== "Player")
        {
            lookAt = pl.transform;
        }
       
        
    }
    private void LateUpdate()
    {
        Vector3 delta = Vector3.zero;


        //this is to check if we're inside the bounds on the X axis
        float deltaX = lookAt.position.x - transform.position.x;
        if (deltaX > boundX || deltaX < -boundX)
        {
            if (transform.position.x < lookAt.position.x)
            {
                delta.x = deltaX - boundX;

            }
            else
            {
                delta.x = deltaX + boundX;
            }
        }
        
        //this is to check if we're inside the bounds on the Y axis
        float deltaY = lookAt.position.y - transform.position.y;
        if (deltaY > boundY || deltaY < -boundY)
        {
            if (transform.position.y < lookAt.position.y)
            {
                delta.y= deltaY - boundY;

            }
            else
            {
                delta.y = deltaY + boundY;
            }
        }

        transform.position += new Vector3(delta.x, delta.y, 0);

    }

}
