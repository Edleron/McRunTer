using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runningSpeed;
    public float xSpeed;
    public float limitX;

    private float touchXDelta   = 0;
    private float newX          = 0;



    private void Update()
    {
        SwipeCheck();
    }

    private void SwipeCheck()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            // Debug.Log(Input.GetTouch(0).deltaPosition.x / Screen.width);
            touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;
        }
        else if (Input.GetMouseButton(0))
        {
            touchXDelta = Input.GetAxis("Mouse X");
        }
        else
        {
            touchXDelta = 0;
        }

        newX = transform.position.x + xSpeed * touchXDelta * Time.deltaTime;
        newX = Math.Clamp(newX, -limitX, limitX);

        Vector3 position = new Vector3(newX, transform.position.y, transform.position.z + runningSpeed * Time.deltaTime);
        transform.position = position;

    }
}
